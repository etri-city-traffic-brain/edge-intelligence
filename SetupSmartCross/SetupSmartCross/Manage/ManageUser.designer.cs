namespace SetupSmartCross.Manage
{
    partial class ManageUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUser));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gcUser = new DevExpress.XtraGrid.GridControl();
            this.gvUser = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.USER_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PASSWORD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GROUP_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ORGANIZATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CLASS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CONTACT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 506);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1106, 58);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1018, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫 기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(93, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(77, 32);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "삭 제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(174, 13);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 32);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "편 집";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(12, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "신규등록";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gcUser
            // 
            this.gcUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUser.Location = new System.Drawing.Point(0, 0);
            this.gcUser.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcUser.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcUser.MainView = this.gvUser;
            this.gcUser.Name = "gcUser";
            this.gcUser.Size = new System.Drawing.Size(1106, 506);
            this.gcUser.TabIndex = 2;
            this.gcUser.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUser});
            // 
            // gvUser
            // 
            this.gvUser.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.USER_ID,
            this.NAME,
            this.PASSWORD,
            this.GROUP_NAME,
            this.ORGANIZATION,
            this.CLASS,
            this.CONTACT,
            this.DESCRIPTION});
            this.gvUser.GridControl = this.gcUser;
            this.gvUser.Name = "gvUser";
            this.gvUser.OptionsBehavior.ReadOnly = true;
            this.gvUser.OptionsView.ShowAutoFilterRow = true;
            this.gvUser.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvUser.OptionsView.ShowGroupPanel = false;
            this.gvUser.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvUser_RowClick);
            // 
            // USER_ID
            // 
            this.USER_ID.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.USER_ID.AppearanceCell.Options.UseFont = true;
            this.USER_ID.AppearanceCell.Options.UseTextOptions = true;
            this.USER_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.USER_ID.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.USER_ID.AppearanceHeader.Options.UseFont = true;
            this.USER_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.USER_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.USER_ID.Caption = "사용자 ID";
            this.USER_ID.FieldName = "USER_ID";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.OptionsColumn.AllowEdit = false;
            this.USER_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.USER_ID.Visible = true;
            this.USER_ID.VisibleIndex = 0;
            this.USER_ID.Width = 68;
            // 
            // NAME
            // 
            this.NAME.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.NAME.AppearanceCell.Options.UseFont = true;
            this.NAME.AppearanceCell.Options.UseTextOptions = true;
            this.NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.NAME.AppearanceHeader.Options.UseFont = true;
            this.NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.NAME.Caption = "이름";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsColumn.AllowEdit = false;
            this.NAME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
            this.NAME.Width = 155;
            // 
            // PASSWORD
            // 
            this.PASSWORD.Caption = "비밀번호";
            this.PASSWORD.FieldName = "PASSWORD";
            this.PASSWORD.Name = "PASSWORD";
            this.PASSWORD.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            // 
            // GROUP_NAME
            // 
            this.GROUP_NAME.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GROUP_NAME.AppearanceCell.Options.UseFont = true;
            this.GROUP_NAME.AppearanceCell.Options.UseTextOptions = true;
            this.GROUP_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GROUP_NAME.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.GROUP_NAME.AppearanceHeader.Options.UseFont = true;
            this.GROUP_NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.GROUP_NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.GROUP_NAME.Caption = "그룹명";
            this.GROUP_NAME.FieldName = "GROUP_NAME";
            this.GROUP_NAME.Name = "GROUP_NAME";
            this.GROUP_NAME.OptionsColumn.AllowEdit = false;
            this.GROUP_NAME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.GROUP_NAME.Visible = true;
            this.GROUP_NAME.VisibleIndex = 2;
            this.GROUP_NAME.Width = 128;
            // 
            // ORGANIZATION
            // 
            this.ORGANIZATION.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ORGANIZATION.AppearanceCell.Options.UseFont = true;
            this.ORGANIZATION.AppearanceCell.Options.UseTextOptions = true;
            this.ORGANIZATION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORGANIZATION.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ORGANIZATION.AppearanceHeader.Options.UseFont = true;
            this.ORGANIZATION.AppearanceHeader.Options.UseTextOptions = true;
            this.ORGANIZATION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ORGANIZATION.Caption = "소속(기관)";
            this.ORGANIZATION.FieldName = "ORGANIZATION";
            this.ORGANIZATION.Name = "ORGANIZATION";
            this.ORGANIZATION.OptionsColumn.AllowEdit = false;
            this.ORGANIZATION.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.ORGANIZATION.Visible = true;
            this.ORGANIZATION.VisibleIndex = 3;
            this.ORGANIZATION.Width = 118;
            // 
            // CLASS
            // 
            this.CLASS.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CLASS.AppearanceCell.Options.UseFont = true;
            this.CLASS.AppearanceCell.Options.UseTextOptions = true;
            this.CLASS.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CLASS.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CLASS.AppearanceHeader.Options.UseFont = true;
            this.CLASS.AppearanceHeader.Options.UseTextOptions = true;
            this.CLASS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CLASS.Caption = "직급(계급)";
            this.CLASS.FieldName = "CLASS";
            this.CLASS.Name = "CLASS";
            this.CLASS.OptionsColumn.AllowEdit = false;
            this.CLASS.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.CLASS.Visible = true;
            this.CLASS.VisibleIndex = 4;
            this.CLASS.Width = 92;
            // 
            // CONTACT
            // 
            this.CONTACT.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CONTACT.AppearanceCell.Options.UseFont = true;
            this.CONTACT.AppearanceCell.Options.UseTextOptions = true;
            this.CONTACT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CONTACT.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CONTACT.AppearanceHeader.Options.UseFont = true;
            this.CONTACT.AppearanceHeader.Options.UseTextOptions = true;
            this.CONTACT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CONTACT.Caption = "연락처";
            this.CONTACT.FieldName = "CONTACT";
            this.CONTACT.Name = "CONTACT";
            this.CONTACT.OptionsColumn.AllowEdit = false;
            this.CONTACT.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.CONTACT.Visible = true;
            this.CONTACT.VisibleIndex = 5;
            this.CONTACT.Width = 142;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DESCRIPTION.AppearanceCell.Options.UseFont = true;
            this.DESCRIPTION.AppearanceCell.Options.UseTextOptions = true;
            this.DESCRIPTION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DESCRIPTION.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DESCRIPTION.AppearanceHeader.Options.UseFont = true;
            this.DESCRIPTION.AppearanceHeader.Options.UseTextOptions = true;
            this.DESCRIPTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DESCRIPTION.Caption = "설명";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.OptionsColumn.AllowEdit = false;
            this.DESCRIPTION.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 6;
            this.DESCRIPTION.Width = 385;
            // 
            // ManageUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 564);
            this.Controls.Add(this.gcUser);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 관리";
            this.Load += new System.EventHandler(this.ManageUser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.GridControl gcUser;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUser;
        private DevExpress.XtraGrid.Columns.GridColumn USER_ID;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn GROUP_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn ORGANIZATION;
        private DevExpress.XtraGrid.Columns.GridColumn CLASS;
        private DevExpress.XtraGrid.Columns.GridColumn CONTACT;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn PASSWORD;
    }
}