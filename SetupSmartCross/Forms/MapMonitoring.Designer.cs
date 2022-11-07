namespace SetupSmartCross.Forms
{
    partial class MapMonitoring
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.elementHostMap = new System.Windows.Forms.Integration.ElementHost();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbMinute = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cbHour = new DevExpress.XtraEditors.ComboBoxEdit();
            this.chkbtnRealTime = new DevExpress.XtraEditors.CheckButton();
            this.deSearchDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lbSearchDateTime = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMinute.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHour.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSearchDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSearchDate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // elementHostMap
            // 
            this.elementHostMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.elementHostMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMap.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.elementHostMap.Location = new System.Drawing.Point(0, 33);
            this.elementHostMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMap.Name = "elementHostMap";
            this.elementHostMap.Size = new System.Drawing.Size(658, 513);
            this.elementHostMap.TabIndex = 22;
            this.elementHostMap.Text = "elementHost1";
            this.elementHostMap.Child = null;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.panelControl1.Appearance.Options.UseFont = true;
            this.panelControl1.Controls.Add(this.cbMinute);
            this.panelControl1.Controls.Add(this.cbHour);
            this.panelControl1.Controls.Add(this.chkbtnRealTime);
            this.panelControl1.Controls.Add(this.deSearchDate);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.lbSearchDateTime);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(658, 33);
            this.panelControl1.TabIndex = 23;
            // 
            // cbMinute
            // 
            this.cbMinute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbMinute.Enabled = false;
            this.cbMinute.Location = new System.Drawing.Point(608, 5);
            this.cbMinute.Name = "cbMinute";
            this.cbMinute.Properties.AllowFocused = false;
            this.cbMinute.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cbMinute.Properties.Appearance.Options.UseFont = true;
            this.cbMinute.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbMinute.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbMinute.Size = new System.Drawing.Size(40, 22);
            this.cbMinute.TabIndex = 3;
            this.cbMinute.EditValueChanged += new System.EventHandler(this.Search_DateTimeChanged);
            this.cbMinute.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // cbHour
            // 
            this.cbHour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbHour.Enabled = false;
            this.cbHour.Location = new System.Drawing.Point(561, 5);
            this.cbHour.Name = "cbHour";
            this.cbHour.Properties.AllowFocused = false;
            this.cbHour.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.cbHour.Properties.Appearance.Options.UseFont = true;
            this.cbHour.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbHour.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbHour.Size = new System.Drawing.Size(40, 22);
            this.cbHour.TabIndex = 2;
            this.cbHour.EditValueChanged += new System.EventHandler(this.Search_DateTimeChanged);
            this.cbHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // chkbtnRealTime
            // 
            this.chkbtnRealTime.AllowFocus = false;
            this.chkbtnRealTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkbtnRealTime.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.chkbtnRealTime.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.chkbtnRealTime.Appearance.Options.UseFont = true;
            this.chkbtnRealTime.Appearance.Options.UseForeColor = true;
            this.chkbtnRealTime.Checked = true;
            this.chkbtnRealTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkbtnRealTime.Location = new System.Drawing.Point(355, 5);
            this.chkbtnRealTime.Name = "chkbtnRealTime";
            this.chkbtnRealTime.Size = new System.Drawing.Size(51, 23);
            this.chkbtnRealTime.TabIndex = 0;
            this.chkbtnRealTime.Text = "실시간";
            this.chkbtnRealTime.CheckedChanged += new System.EventHandler(this.chkbtnRealTime_CheckedChanged);
            // 
            // deSearchDate
            // 
            this.deSearchDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deSearchDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deSearchDate.EditValue = null;
            this.deSearchDate.Enabled = false;
            this.deSearchDate.Location = new System.Drawing.Point(454, 5);
            this.deSearchDate.Name = "deSearchDate";
            this.deSearchDate.Properties.AllowFocused = false;
            this.deSearchDate.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.deSearchDate.Properties.Appearance.Options.UseFont = true;
            this.deSearchDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deSearchDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deSearchDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.deSearchDate.Size = new System.Drawing.Size(100, 22);
            this.deSearchDate.TabIndex = 1;
            this.deSearchDate.DateTimeChanged += new System.EventHandler(this.Search_DateTimeChanged);
            this.deSearchDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Gold;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.Location = new System.Drawing.Point(11, 8);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 15);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "교통정보 :";
            // 
            // lbSearchDateTime
            // 
            this.lbSearchDateTime.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.lbSearchDateTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lbSearchDateTime.Location = new System.Drawing.Point(72, 8);
            this.lbSearchDateTime.Name = "lbSearchDateTime";
            this.lbSearchDateTime.Size = new System.Drawing.Size(0, 15);
            this.lbSearchDateTime.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl1.Location = new System.Drawing.Point(417, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "일시 :";
            // 
            // MapMonitoring
            // 
            this.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.elementHostMap);
            this.Controls.Add(this.panelControl1);
            this.Name = "MapMonitoring";
            this.Size = new System.Drawing.Size(658, 546);
            this.Load += new System.EventHandler(this.MapMonitoring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbMinute.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHour.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSearchDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deSearchDate.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost elementHostMap;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit deSearchDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckButton chkbtnRealTime;
        private DevExpress.XtraEditors.ComboBoxEdit cbMinute;
        private DevExpress.XtraEditors.ComboBoxEdit cbHour;
        private DevExpress.XtraEditors.LabelControl lbSearchDateTime;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
