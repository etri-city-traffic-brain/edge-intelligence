namespace SetupSmartCross.Manage
{
    partial class ManageUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUserGroup));
            this.gcUserGroup = new DevExpress.XtraGrid.GridControl();
            this.gvUserGroup = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PERMISSION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcUserGroup
            // 
            this.gcUserGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUserGroup.Location = new System.Drawing.Point(0, 0);
            this.gcUserGroup.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcUserGroup.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcUserGroup.MainView = this.gvUserGroup;
            this.gcUserGroup.Name = "gcUserGroup";
            this.gcUserGroup.Size = new System.Drawing.Size(529, 293);
            this.gcUserGroup.TabIndex = 4;
            this.gcUserGroup.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUserGroup});
            // 
            // gvUserGroup
            // 
            this.gvUserGroup.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.NAME,
            this.DESCRIPTION,
            this.PERMISSION});
            this.gvUserGroup.GridControl = this.gcUserGroup;
            this.gvUserGroup.Name = "gvUserGroup";
            this.gvUserGroup.OptionsBehavior.ReadOnly = true;
            this.gvUserGroup.OptionsView.ShowGroupPanel = false;
            this.gvUserGroup.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvUserGroup_RowClick);
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
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            this.NAME.Width = 143;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DESCRIPTION.AppearanceCell.Options.UseFont = true;
            this.DESCRIPTION.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DESCRIPTION.AppearanceHeader.Options.UseFont = true;
            this.DESCRIPTION.AppearanceHeader.Options.UseTextOptions = true;
            this.DESCRIPTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DESCRIPTION.Caption = "설명";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.OptionsColumn.AllowEdit = false;
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 1;
            this.DESCRIPTION.Width = 337;
            // 
            // PERMISSION
            // 
            this.PERMISSION.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.PERMISSION.AppearanceCell.Options.UseFont = true;
            this.PERMISSION.AppearanceCell.Options.UseTextOptions = true;
            this.PERMISSION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PERMISSION.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.PERMISSION.AppearanceHeader.Options.UseFont = true;
            this.PERMISSION.AppearanceHeader.Options.UseTextOptions = true;
            this.PERMISSION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PERMISSION.Caption = "권한";
            this.PERMISSION.FieldName = "PERMISSION";
            this.PERMISSION.Name = "PERMISSION";
            this.PERMISSION.OptionsColumn.AllowEdit = false;
            this.PERMISSION.Width = 199;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnEdit);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 293);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(529, 58);
            this.panelControl1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(441, 14);
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
            this.btnDelete.Location = new System.Drawing.Point(93, 14);
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
            this.btnEdit.Location = new System.Drawing.Point(174, 14);
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
            this.btnAdd.Location = new System.Drawing.Point(12, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 32);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "신규등록";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ManageUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 351);
            this.Controls.Add(this.gcUserGroup);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManageUserGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 그룹 관리";
            this.Load += new System.EventHandler(this.ManageUserGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcUserGroup;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUserGroup;
        private DevExpress.XtraGrid.Columns.GridColumn NAME;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn PERMISSION;
    }
}