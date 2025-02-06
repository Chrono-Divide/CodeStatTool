namespace CodeStatTool
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        // 自定義標題欄 Panel
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;

        // 允許垂直拉伸的 Panel
        private System.Windows.Forms.Panel panelResize;

        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Button btnGenerateStats;
        private System.Windows.Forms.Label lblSelectedFolder;
        private System.Windows.Forms.TextBox txtOutput;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        // CheckedListBox，列出可統計的各語言或檔案類型
        private System.Windows.Forms.CheckedListBox clbLanguages;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();

            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.btnGenerateStats = new System.Windows.Forms.Button();
            this.lblSelectedFolder = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelResize = new System.Windows.Forms.Panel();
            this.clbLanguages = new System.Windows.Forms.CheckedListBox();

            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Black;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(900, 32);
            this.panelTitleBar.TabIndex = 0;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            this.panelTitleBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseMove);
            this.panelTitleBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseUp);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(96, 17);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CodeStatTool";

            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(868, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(32, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.BackColor = System.Drawing.Color.Black;
            this.btnSelectFolder.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSelectFolder.FlatAppearance.BorderSize = 1;
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectFolder.ForeColor = System.Drawing.Color.White;
            this.btnSelectFolder.Location = new System.Drawing.Point(20, 50);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(130, 32);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = false;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);

            // 
            // btnGenerateStats
            // 
            this.btnGenerateStats.BackColor = System.Drawing.Color.Black;
            this.btnGenerateStats.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGenerateStats.FlatAppearance.BorderSize = 1;
            this.btnGenerateStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateStats.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
            this.btnGenerateStats.ForeColor = System.Drawing.Color.White;
            this.btnGenerateStats.Location = new System.Drawing.Point(170, 50);
            this.btnGenerateStats.Name = "btnGenerateStats";
            this.btnGenerateStats.Size = new System.Drawing.Size(150, 32);
            this.btnGenerateStats.TabIndex = 2;
            this.btnGenerateStats.Text = "Generate Statistics";
            this.btnGenerateStats.UseVisualStyleBackColor = false;
            this.btnGenerateStats.Click += new System.EventHandler(this.btnGenerateStats_Click);

            // 
            // lblSelectedFolder
            // 
            this.lblSelectedFolder.AutoSize = true;
            this.lblSelectedFolder.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblSelectedFolder.ForeColor = System.Drawing.Color.White;
            this.lblSelectedFolder.Location = new System.Drawing.Point(20, 90);
            this.lblSelectedFolder.Name = "lblSelectedFolder";
            this.lblSelectedFolder.Size = new System.Drawing.Size(119, 14);
            this.lblSelectedFolder.TabIndex = 3;
            this.lblSelectedFolder.Text = "No folder selected";

            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtOutput.ForeColor = System.Drawing.Color.Lime;
            this.txtOutput.Location = new System.Drawing.Point(20, 110);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(650, 370);
            this.txtOutput.TabIndex = 4;

            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);

            // 
            // panelResize
            // 
            this.panelResize.BackColor = System.Drawing.Color.Black;
            this.panelResize.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelResize.Location = new System.Drawing.Point(0, 518);
            this.panelResize.Name = "panelResize";
            this.panelResize.Size = new System.Drawing.Size(900, 6);
            this.panelResize.TabIndex = 5;
            this.panelResize.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.panelResize.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelResize_MouseDown);
            this.panelResize.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelResize_MouseMove);
            this.panelResize.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelResize_MouseUp);

            // 
            // clbLanguages
            // 
            this.clbLanguages.BackColor = System.Drawing.Color.Black;
            this.clbLanguages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbLanguages.CheckOnClick = true;
            this.clbLanguages.Font = new System.Drawing.Font("Consolas", 9F);
            this.clbLanguages.ForeColor = System.Drawing.Color.White;
            this.clbLanguages.FormattingEnabled = true;
            this.clbLanguages.Location = new System.Drawing.Point(690, 110);
            this.clbLanguages.Name = "clbLanguages";
            this.clbLanguages.Size = new System.Drawing.Size(180, 368);
            this.clbLanguages.TabIndex = 6;
            // (程式執行時以程式碼方式加入語言項)

            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ClientSize = new System.Drawing.Size(900, 524);
            this.Controls.Add(this.clbLanguages);
            this.Controls.Add(this.panelResize);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblSelectedFolder);
            this.Controls.Add(this.btnGenerateStats);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.panelTitleBar);
            this.Font = new System.Drawing.Font("Consolas", 9F);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CodeStatTool";
            this.BackColor = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.frmMain_Load);

            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
