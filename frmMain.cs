using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace FileDeploy
{
    public partial class frmMain : Form
    {
        List<string> sourceFiles = new List<string>();
        List<string> targetFolders = new List<string>();

        public frmMain()
        {
            InitializeComponent();
        }
        
        private void clbSources_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select files to be deployed";
                openFileDialog.InitialDirectory = ".";
                openFileDialog.Filter = "Files to deploy|*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        sourceFiles.Add(file);
                        this.clbSources.Items.Add(string.Format("{0,-12}", Path.GetFileName(file)) + " (" + Path.GetDirectoryName(Path.GetFullPath(file)) + " )");
                        this.clbSources.SetItemChecked(this.clbSources.Items.Count - 1, true);
                    }
                }
            }
        }
        
        private void clbTargets_DoubleClick(object sender, EventArgs e)
        {
            FolderSelectDialog folderBrowserDialog = new FolderSelectDialog();
            folderBrowserDialog.Title = "Choose folder to deploy";

            if (folderBrowserDialog.ShowDialog(this.Handle))
            {
                string target = folderBrowserDialog.FileName;
                targetFolders.Add(target);
                this.clbTargets.Items.Add(target);
                this.clbTargets.SetItemChecked(this.clbTargets.Items.Count - 1, true);
            }
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            this.txtOutput.SelectionStart = this.txtOutput.TextLength;
            this.txtOutput.ScrollToCaret();
        }

        int countPass = 0;
        int countFail = 0;
        bool todryrun = false;
        bool toremove = false;
        
        Thread trdReplace = null;
        volatile bool going = false;

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (trdReplace == null)
            {
                this.txtOutput.Clear();
                countPass = 0;
                countFail = 0;
                todryrun = this.chkDryRun.Checked;
                toremove = this.chkRemove.Checked;

                List<string> sources = new List<string>();
                List<string> targets = new List<string>();

                for (var i = 0; i < this.clbSources.Items.Count; ++i)
                {
                    if (this.clbSources.GetItemChecked(i))
                        sources.Add(sourceFiles[i]);
                }

                for (var i = 0; i < this.clbTargets.Items.Count; ++i)
                {
                    if (this.clbTargets.GetItemChecked(i))
                        targets.Add(targetFolders[i]);
                }

                this.txtOutput.Text = sources.Count + " Files => " + targets.Count + " Folders" + Environment.NewLine;

                if (sources.Count > 0 && targets.Count > 0 &&
                    MessageBox.Show("Good to go?", "File Deploy", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.btnGo.Text = "Stop";
                    going = true;
                    foreach (string folder in targets)
                    {
                        DeployFiles(sources, folder);
                        if (!going)
                            break;
                    }
                    trdReplace = new Thread(new ThreadStart(
                        () =>
                        {
                            foreach (string folder in targets)
                            {
                                DeployFiles(sources, folder);
                                if (!going)
                                    break;
                            }

                            this.Invoke((MethodInvoker)delegate
                            {
                                this.btnGo.Enabled = true;
                                if (todryrun)
                                    this.txtOutput.Text += Environment.NewLine + Environment.NewLine + "=== Dry run, no files changed ===";

                                if (toremove)
                                        this.txtOutput.Text += Environment.NewLine + Environment.NewLine + countPass + " files removed";
                                    else
                                    this.txtOutput.Text += Environment.NewLine + Environment.NewLine + countPass + " files replaced";

                                this.txtOutput.Text += Environment.NewLine + countFail + " errors";
                            });

                            EngGo();
                        }
                        ));
                    trdReplace.Start();
                }
            }
            else
            {
                going = false;
                new Thread(new ThreadStart(
                    () =>
                    {
                        trdReplace.Join();
                        EngGo();
                    }
                )).Start();
            }
        }

        private void DeployFiles(List<string> files, string folder)
        {
            if (!going)
                return;

            if (!Directory.Exists(folder))
            //if (!(new DirectoryInfo(folder)).Exists)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtOutput.Text += Environment.NewLine + "Folder Not Exists - " + folder;
                        ++this.countFail;
                    });
                }
                return;
            }

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.txtOutput.Text += Environment.NewLine + " - " + folder;
                });
            }

            if (!going)
                return;

            try
            {
                Directory.GetFiles(folder);
            }
            catch
            {
                if (this.InvokeRequired)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.txtOutput.Text += Environment.NewLine + "Failed to Read Folder - " + folder;
                        ++this.countFail;
                    });
                }
                return;
            }

            foreach (string file in files)
            {
                if (!going)
                    break;

                string thisDestFile = Path.GetFullPath(folder) + "\\" + Path.GetFileName(file);
                if (File.Exists(thisDestFile)
                //if ( (new FileInfo(thisDestFile).Exists)
                    && !thisDestFile.Equals(Path.GetFullPath(file), StringComparison.OrdinalIgnoreCase)
                    )
                {
                    try
                    {
                        if (toremove)
                        {
                            if (!todryrun)
                                File.Delete(thisDestFile);

                            if (this.InvokeRequired)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.txtOutput.Text += Environment.NewLine + "Removed - " + thisDestFile;
                                    ++this.countPass;
                                });
                            }
                        }
                        else
                        {
                            if (!todryrun)
                                File.Copy(file, thisDestFile, true);

                            if (this.InvokeRequired)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.txtOutput.Text += Environment.NewLine + "OK - " + Path.GetFileName(file) + " => " + folder;
                                    ++this.countPass;
                                });
                            }
                        }
                    }
                    catch
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                this.txtOutput.Text += Environment.NewLine + "Failed to Copy File - " + Path.GetFileName(file) + " => " + folder;
                                ++this.countFail;
                            });
                        }
                    }
                }
            }

            if (!going)
                return;

            foreach (string desentFolder in Directory.GetDirectories(folder))
            {
                if (!going)
                    break;
                DeployFiles(files, desentFolder);
            }
        }
        
        private void EngGo()
        {
            trdReplace = null;
            if (this.InvokeRequired)
                this.Invoke((MethodInvoker)delegate
                {
                    this.btnGo.Text = "Go";
                });
        }

        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            System.Diagnostics.Process.Start(@"https://github.com/lzp729/FileDeploy");
        }
    }
}
