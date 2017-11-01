namespace FileDeploy
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlPanel = new System.Windows.Forms.Panel();
            this.lblDirection = new System.Windows.Forms.Label();
            this.clbTargets = new System.Windows.Forms.CheckedListBox();
            this.clbSources = new System.Windows.Forms.CheckedListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkRemove = new System.Windows.Forms.CheckBox();
            this.chkDryRun = new System.Windows.Forms.CheckBox();
            this.lnk = new System.Windows.Forms.LinkLabel();
            this.pnlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPanel
            // 
            this.pnlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPanel.Controls.Add(this.lblDirection);
            this.pnlPanel.Controls.Add(this.clbTargets);
            this.pnlPanel.Controls.Add(this.clbSources);
            this.pnlPanel.Location = new System.Drawing.Point(12, 42);
            this.pnlPanel.Name = "pnlPanel";
            this.pnlPanel.Size = new System.Drawing.Size(760, 187);
            this.pnlPanel.TabIndex = 0;
            // 
            // lblDirection
            // 
            this.lblDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDirection.Location = new System.Drawing.Point(370, 0);
            this.lblDirection.MaximumSize = new System.Drawing.Size(20, 187);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(20, 187);
            this.lblDirection.TabIndex = 2;
            this.lblDirection.Text = "=>";
            this.lblDirection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clbTargets
            // 
            this.clbTargets.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.clbTargets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbTargets.CheckOnClick = true;
            this.clbTargets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clbTargets.Dock = System.Windows.Forms.DockStyle.Right;
            this.clbTargets.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbTargets.ForeColor = System.Drawing.Color.Red;
            this.clbTargets.FormattingEnabled = true;
            this.clbTargets.Location = new System.Drawing.Point(390, 0);
            this.clbTargets.Name = "clbTargets";
            this.clbTargets.Size = new System.Drawing.Size(370, 187);
            this.clbTargets.TabIndex = 1;
            this.clbTargets.DoubleClick += new System.EventHandler(this.clbTargets_DoubleClick);
            // 
            // clbSources
            // 
            this.clbSources.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.clbSources.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbSources.CheckOnClick = true;
            this.clbSources.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clbSources.Dock = System.Windows.Forms.DockStyle.Left;
            this.clbSources.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clbSources.ForeColor = System.Drawing.Color.Green;
            this.clbSources.FormattingEnabled = true;
            this.clbSources.Location = new System.Drawing.Point(0, 0);
            this.clbSources.Name = "clbSources";
            this.clbSources.Size = new System.Drawing.Size(370, 187);
            this.clbSources.TabIndex = 0;
            this.clbSources.DoubleClick += new System.EventHandler(this.clbSources_DoubleClick);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(12, 258);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(760, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(12, 287);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(760, 222);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 9);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(520, 26);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Replace each files in right panel folders of the same name with left panel files," +
    "  recursively into all sub-folders. \r\nDouble-Click or Drag to add files or folde" +
    "rs.";
            // 
            // chkRemove
            // 
            this.chkRemove.AutoSize = true;
            this.chkRemove.Location = new System.Drawing.Point(12, 235);
            this.chkRemove.Name = "chkRemove";
            this.chkRemove.Size = new System.Drawing.Size(148, 17);
            this.chkRemove.TabIndex = 5;
            this.chkRemove.Text = "Remove all those maches";
            this.chkRemove.UseVisualStyleBackColor = true;
            // 
            // chkDryRun
            // 
            this.chkDryRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDryRun.AutoSize = true;
            this.chkDryRun.Checked = true;
            this.chkDryRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDryRun.Location = new System.Drawing.Point(579, 12);
            this.chkDryRun.Name = "chkDryRun";
            this.chkDryRun.Size = new System.Drawing.Size(193, 17);
            this.chkDryRun.TabIndex = 6;
            this.chkDryRun.Text = "Dry run ( Count only, no file actions)";
            this.chkDryRun.UseVisualStyleBackColor = true;
            // 
            // lnk
            // 
            this.lnk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnk.AutoSize = true;
            this.lnk.Location = new System.Drawing.Point(711, 539);
            this.lnk.Name = "lnk";
            this.lnk.Size = new System.Drawing.Size(61, 13);
            this.lnk.TabIndex = 7;
            this.lnk.TabStop = true;
            this.lnk.Text = "Get Source";
            this.lnk.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lnk);
            this.Controls.Add(this.chkDryRun);
            this.Controls.Add(this.chkRemove);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.pnlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "File Deploy";
            this.pnlPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPanel;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.CheckedListBox clbSources;
        private System.Windows.Forms.CheckedListBox clbTargets;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkRemove;
        private System.Windows.Forms.CheckBox chkDryRun;
        private System.Windows.Forms.LinkLabel lnk;
    }
}

