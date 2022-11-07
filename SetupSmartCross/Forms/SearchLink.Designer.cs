namespace SetupSmartCross.Forms
{
    partial class SearchLink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchLink));
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageLog = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPageStats = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.xtraTabControl.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl.LookAndFeel.SkinName = "Dark Side";
            this.xtraTabControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPageLog;
            this.xtraTabControl.Size = new System.Drawing.Size(1431, 704);
            this.xtraTabControl.TabIndex = 0;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageLog,
            this.xtraTabPageStats});
            // 
            // xtraTabPageLog
            // 
            this.xtraTabPageLog.Appearance.Header.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.xtraTabPageLog.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageLog.Name = "xtraTabPageLog";
            this.xtraTabPageLog.Size = new System.Drawing.Size(1426, 677);
            this.xtraTabPageLog.Text = "이력";
            // 
            // xtraTabPageStats
            // 
            this.xtraTabPageStats.Appearance.Header.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.xtraTabPageStats.Appearance.Header.Options.UseFont = true;
            this.xtraTabPageStats.Name = "xtraTabPageStats";
            this.xtraTabPageStats.Size = new System.Drawing.Size(1426, 677);
            this.xtraTabPageStats.Text = "통계";
            // 
            // SearchLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1431, 704);
            this.Controls.Add(this.xtraTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "구간 속도 조회";
            this.Load += new System.EventHandler(this.SearchLink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageLog;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageStats;
    }
}