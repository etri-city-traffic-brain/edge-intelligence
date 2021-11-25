namespace SetupSmartCross.Manage
{
    partial class ManageUserGroupAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserGroupAdd));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbGroupName = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbAllPermission = new DevExpress.XtraEditors.CheckEdit();
            this.cklbPermission = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllPermission.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cklbPermission)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbDescription);
            this.groupBox2.Controls.Add(this.tbGroupName);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.labelControl1);
            this.groupBox2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(361, 167);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "기본설정";
            // 
            // tbDescription
            // 
            this.tbDescription.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tbDescription.Location = new System.Drawing.Point(84, 56);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(264, 95);
            this.tbDescription.TabIndex = 11;
            // 
            // tbGroupName
            // 
            this.tbGroupName.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tbGroupName.Location = new System.Drawing.Point(84, 26);
            this.tbGroupName.Name = "tbGroupName";
            this.tbGroupName.Size = new System.Drawing.Size(264, 23);
            this.tbGroupName.TabIndex = 10;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl2.Location = new System.Drawing.Point(14, 59);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 15);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "설명 :";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl1.Location = new System.Drawing.Point(14, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(55, 15);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "그룹이름 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckbAllPermission);
            this.groupBox1.Controls.Add(this.cklbPermission);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(12, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(361, 299);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "권 한";
            // 
            // ckbAllPermission
            // 
            this.ckbAllPermission.Location = new System.Drawing.Point(281, 0);
            this.ckbAllPermission.Name = "ckbAllPermission";
            this.ckbAllPermission.Properties.AllowFocused = false;
            this.ckbAllPermission.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.ckbAllPermission.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ckbAllPermission.Properties.Appearance.Options.UseBackColor = true;
            this.ckbAllPermission.Properties.Appearance.Options.UseFont = true;
            this.ckbAllPermission.Properties.Caption = "전체선택";
            this.ckbAllPermission.Size = new System.Drawing.Size(67, 19);
            this.ckbAllPermission.TabIndex = 1;
            this.ckbAllPermission.CheckedChanged += new System.EventHandler(this.ckbAllPermission_CheckedChanged);
            // 
            // cklbPermission
            // 
            this.cklbPermission.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.cklbPermission.Appearance.Options.UseFont = true;
            this.cklbPermission.Location = new System.Drawing.Point(14, 27);
            this.cklbPermission.LookAndFeel.SkinName = "Office 2010 Black";
            this.cklbPermission.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cklbPermission.Name = "cklbPermission";
            this.cklbPermission.Size = new System.Drawing.Size(334, 256);
            this.cklbPermission.TabIndex = 0;
            this.cklbPermission.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.cklbPermission_ItemCheck);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(100, 491);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 32);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "저 장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(207, 491);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 32);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "닫 기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ManageUserGroupAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 531);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageUserGroupAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 그룹 추가";
            this.Load += new System.EventHandler(this.ManageUserGroupAdd_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckbAllPermission.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cklbPermission)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.TextBox tbGroupName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.CheckedListBoxControl cklbPermission;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.CheckEdit ckbAllPermission;
    }
}