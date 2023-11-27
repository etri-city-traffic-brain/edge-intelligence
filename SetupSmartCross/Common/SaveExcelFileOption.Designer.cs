namespace Common
{
    partial class SaveExcelFileOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveExcelFileOption));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.tbSelectValue = new DevExpress.XtraEditors.TextEdit();
            this.chkSelectPage = new DevExpress.XtraEditors.CheckEdit();
            this.chkCurrentPage = new DevExpress.XtraEditors.CheckEdit();
            this.chkAllPage = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSelectValue.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrentPage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllPage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnOK);
            this.panelControl1.Controls.Add(this.btnCancel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 126);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(235, 35);
            this.panelControl1.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnOK.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnOK.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Appearance.Options.UseForeColor = true;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(74, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "확 인";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(155, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "취 소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(235, 126);
            this.panelControl2.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.tbSelectValue);
            this.groupControl1.Controls.Add(this.chkSelectPage);
            this.groupControl1.Controls.Add(this.chkCurrentPage);
            this.groupControl1.Controls.Add(this.chkAllPage);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(231, 122);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "페이지 선택";
            // 
            // tbSelectValue
            // 
            this.tbSelectValue.Enabled = false;
            this.tbSelectValue.Location = new System.Drawing.Point(116, 86);
            this.tbSelectValue.Name = "tbSelectValue";
            this.tbSelectValue.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.LightGray;
            this.tbSelectValue.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.tbSelectValue.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tbSelectValue.Properties.NullValuePrompt = "0-9";
            this.tbSelectValue.Properties.NullValuePromptShowForEmptyValue = true;
            this.tbSelectValue.Size = new System.Drawing.Size(102, 20);
            this.tbSelectValue.TabIndex = 1;
            // 
            // chkSelectPage
            // 
            this.chkSelectPage.Location = new System.Drawing.Point(21, 87);
            this.chkSelectPage.Name = "chkSelectPage";
            this.chkSelectPage.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkSelectPage.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkSelectPage.Properties.Appearance.Options.UseFont = true;
            this.chkSelectPage.Properties.Appearance.Options.UseForeColor = true;
            this.chkSelectPage.Properties.Caption = "선택 페이지";
            this.chkSelectPage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkSelectPage.Properties.RadioGroupIndex = 0;
            this.chkSelectPage.Size = new System.Drawing.Size(89, 19);
            this.chkSelectPage.TabIndex = 0;
            this.chkSelectPage.TabStop = false;
            this.chkSelectPage.CheckedChanged += new System.EventHandler(this.chkSelectPage_CheckedChanged);
            // 
            // chkCurrentPage
            // 
            this.chkCurrentPage.Location = new System.Drawing.Point(21, 62);
            this.chkCurrentPage.Name = "chkCurrentPage";
            this.chkCurrentPage.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkCurrentPage.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkCurrentPage.Properties.Appearance.Options.UseFont = true;
            this.chkCurrentPage.Properties.Appearance.Options.UseForeColor = true;
            this.chkCurrentPage.Properties.Caption = "현재 페이지";
            this.chkCurrentPage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkCurrentPage.Properties.RadioGroupIndex = 0;
            this.chkCurrentPage.Size = new System.Drawing.Size(89, 19);
            this.chkCurrentPage.TabIndex = 0;
            this.chkCurrentPage.TabStop = false;
            // 
            // chkAllPage
            // 
            this.chkAllPage.EditValue = true;
            this.chkAllPage.Location = new System.Drawing.Point(21, 37);
            this.chkAllPage.Name = "chkAllPage";
            this.chkAllPage.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkAllPage.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkAllPage.Properties.Appearance.Options.UseFont = true;
            this.chkAllPage.Properties.Appearance.Options.UseForeColor = true;
            this.chkAllPage.Properties.Caption = "전체 페이지";
            this.chkAllPage.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Radio;
            this.chkAllPage.Properties.RadioGroupIndex = 0;
            this.chkAllPage.Size = new System.Drawing.Size(89, 19);
            this.chkAllPage.TabIndex = 0;
            // 
            // SaveExcelFileOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 161);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SaveExcelFileOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "엑셀 저장 옵션";
            this.Load += new System.EventHandler(this.SaveExcelFileOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSelectValue.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelectPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCurrentPage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllPage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkSelectPage;
        private DevExpress.XtraEditors.CheckEdit chkCurrentPage;
        private DevExpress.XtraEditors.CheckEdit chkAllPage;
        private DevExpress.XtraEditors.TextEdit tbSelectValue;

    }
}