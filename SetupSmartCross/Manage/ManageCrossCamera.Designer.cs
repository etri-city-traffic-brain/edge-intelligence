namespace SetupSmartCross.Manage
{
    partial class ManageCrossCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCrossCamera));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.tlCcam = new DevExpress.XtraTreeList.TreeList();
            this.CAM_ID_OLD = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CAM_ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.DIRECTION = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rpicbDirection = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.IP = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.PW = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rpitbPassword = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.RTSP_URL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.RTSP_PORT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.HTTP_PORT = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.RIGHT_USE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rpichkRightUse = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.rpichkcbDirection = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlCcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpicbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpitbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpichkRightUse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpichkcbDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Controls.Add(this.btnRefresh);
            this.panelControl1.Controls.Add(this.btnDelete);
            this.panelControl1.Controls.Add(this.btnAdd);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 574);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1171, 47);
            this.panelControl1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1084, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫 기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.AllowFocus = false;
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(1003, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "저 장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.AllowFocus = false;
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(174, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "새로고침";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AllowFocus = false;
            this.btnDelete.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(93, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "삭 제";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AllowFocus = false;
            this.btnAdd.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "추 가";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tlCcam
            // 
            this.tlCcam.Appearance.HorzLine.BackColor = System.Drawing.Color.Gray;
            this.tlCcam.Appearance.HorzLine.Options.UseBackColor = true;
            this.tlCcam.Appearance.Row.BackColor = System.Drawing.Color.LightBlue;
            this.tlCcam.Appearance.Row.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tlCcam.Appearance.Row.Options.UseBackColor = true;
            this.tlCcam.Appearance.Row.Options.UseFont = true;
            this.tlCcam.Appearance.VertLine.BackColor = System.Drawing.Color.Gray;
            this.tlCcam.Appearance.VertLine.Options.UseBackColor = true;
            this.tlCcam.ColumnPanelRowHeight = 40;
            this.tlCcam.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.CAM_ID_OLD,
            this.CAM_ID,
            this.NAME,
            this.DIRECTION,
            this.IP,
            this.ID,
            this.PW,
            this.RTSP_URL,
            this.RTSP_PORT,
            this.HTTP_PORT,
            this.RIGHT_USE});
            this.tlCcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlCcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.tlCcam.KeyFieldName = "CAM_ID";
            this.tlCcam.Location = new System.Drawing.Point(0, 0);
            this.tlCcam.LookAndFeel.SkinName = "Office 2010 Black";
            this.tlCcam.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlCcam.Name = "tlCcam";
            this.tlCcam.OptionsBehavior.AutoFocusNewNode = true;
            this.tlCcam.OptionsBehavior.EnableFiltering = true;
            this.tlCcam.OptionsBehavior.ImmediateEditor = false;
            this.tlCcam.OptionsBehavior.UseTabKey = true;
            this.tlCcam.OptionsSelection.MultiSelect = true;
            this.tlCcam.OptionsView.ShowAutoFilterRow = true;
            this.tlCcam.OptionsView.ShowFilterPanelMode = DevExpress.XtraTreeList.ShowFilterPanelMode.Never;
            this.tlCcam.ParentFieldName = "PARENT_ID";
            this.tlCcam.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.rpicbDirection,
            this.rpichkcbDirection,
            this.rpichkRightUse,
            this.rpitbPassword});
            this.tlCcam.Size = new System.Drawing.Size(1171, 574);
            this.tlCcam.TabIndex = 2;
            this.tlCcam.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.tlCcam_CustomDrawNodeCell);
            // 
            // CAM_ID_OLD
            // 
            this.CAM_ID_OLD.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAM_ID_OLD.AppearanceCell.Options.UseFont = true;
            this.CAM_ID_OLD.AppearanceCell.Options.UseTextOptions = true;
            this.CAM_ID_OLD.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAM_ID_OLD.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAM_ID_OLD.AppearanceHeader.Options.UseFont = true;
            this.CAM_ID_OLD.AppearanceHeader.Options.UseTextOptions = true;
            this.CAM_ID_OLD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAM_ID_OLD.Caption = "CAM_ID_OLD";
            this.CAM_ID_OLD.FieldName = "CAM_ID_OLD";
            this.CAM_ID_OLD.Name = "CAM_ID_OLD";
            this.CAM_ID_OLD.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            // 
            // CAM_ID
            // 
            this.CAM_ID.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAM_ID.AppearanceCell.Options.UseFont = true;
            this.CAM_ID.AppearanceCell.Options.UseTextOptions = true;
            this.CAM_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAM_ID.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAM_ID.AppearanceHeader.Options.UseFont = true;
            this.CAM_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.CAM_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAM_ID.Caption = "카메라ID";
            this.CAM_ID.FieldName = "CAM_ID";
            this.CAM_ID.Name = "CAM_ID";
            this.CAM_ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.CAM_ID.Visible = true;
            this.CAM_ID.VisibleIndex = 0;
            this.CAM_ID.Width = 143;
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
            this.NAME.Caption = "명칭";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 1;
            this.NAME.Width = 210;
            // 
            // DIRECTION
            // 
            this.DIRECTION.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DIRECTION.AppearanceCell.Options.UseFont = true;
            this.DIRECTION.AppearanceCell.Options.UseTextOptions = true;
            this.DIRECTION.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DIRECTION.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.DIRECTION.AppearanceHeader.Options.UseFont = true;
            this.DIRECTION.AppearanceHeader.Options.UseTextOptions = true;
            this.DIRECTION.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.DIRECTION.Caption = "방향";
            this.DIRECTION.ColumnEdit = this.rpicbDirection;
            this.DIRECTION.FieldName = "DIRECTION";
            this.DIRECTION.Name = "DIRECTION";
            this.DIRECTION.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.DIRECTION.Visible = true;
            this.DIRECTION.VisibleIndex = 2;
            this.DIRECTION.Width = 76;
            // 
            // rpicbDirection
            // 
            this.rpicbDirection.AutoHeight = false;
            this.rpicbDirection.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpicbDirection.Name = "rpicbDirection";
            this.rpicbDirection.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // IP
            // 
            this.IP.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.IP.AppearanceCell.Options.UseFont = true;
            this.IP.AppearanceCell.Options.UseTextOptions = true;
            this.IP.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IP.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.IP.AppearanceHeader.Options.UseFont = true;
            this.IP.AppearanceHeader.Options.UseTextOptions = true;
            this.IP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.IP.Caption = "IP";
            this.IP.FieldName = "IP";
            this.IP.Name = "IP";
            this.IP.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.IP.Visible = true;
            this.IP.VisibleIndex = 3;
            this.IP.Width = 145;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.AppearanceCell.Options.UseTextOptions = true;
            this.ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ID.AppearanceHeader.Options.UseFont = true;
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.ID.Visible = true;
            this.ID.VisibleIndex = 4;
            this.ID.Width = 86;
            // 
            // PW
            // 
            this.PW.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.PW.AppearanceCell.Options.UseFont = true;
            this.PW.AppearanceCell.Options.UseTextOptions = true;
            this.PW.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PW.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.PW.AppearanceHeader.Options.UseFont = true;
            this.PW.AppearanceHeader.Options.UseTextOptions = true;
            this.PW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.PW.Caption = "PW";
            this.PW.ColumnEdit = this.rpitbPassword;
            this.PW.FieldName = "PW";
            this.PW.Name = "PW";
            this.PW.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.PW.Visible = true;
            this.PW.VisibleIndex = 5;
            this.PW.Width = 85;
            // 
            // rpitbPassword
            // 
            this.rpitbPassword.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.rpitbPassword.Appearance.Options.UseFont = true;
            this.rpitbPassword.AutoHeight = false;
            this.rpitbPassword.Name = "rpitbPassword";
            this.rpitbPassword.PasswordChar = '*';
            // 
            // RTSP_URL
            // 
            this.RTSP_URL.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RTSP_URL.AppearanceCell.Options.UseFont = true;
            this.RTSP_URL.AppearanceCell.Options.UseTextOptions = true;
            this.RTSP_URL.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RTSP_URL.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RTSP_URL.AppearanceHeader.Options.UseFont = true;
            this.RTSP_URL.AppearanceHeader.Options.UseTextOptions = true;
            this.RTSP_URL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RTSP_URL.Caption = "RTSP\nUrl";
            this.RTSP_URL.FieldName = "RTSP_URL";
            this.RTSP_URL.Name = "RTSP_URL";
            this.RTSP_URL.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.RTSP_URL.Visible = true;
            this.RTSP_URL.VisibleIndex = 6;
            this.RTSP_URL.Width = 209;
            // 
            // RTSP_PORT
            // 
            this.RTSP_PORT.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RTSP_PORT.AppearanceCell.Options.UseFont = true;
            this.RTSP_PORT.AppearanceCell.Options.UseTextOptions = true;
            this.RTSP_PORT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RTSP_PORT.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RTSP_PORT.AppearanceHeader.Options.UseFont = true;
            this.RTSP_PORT.AppearanceHeader.Options.UseTextOptions = true;
            this.RTSP_PORT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RTSP_PORT.Caption = "RTSP\nPort";
            this.RTSP_PORT.FieldName = "RTSP_PORT";
            this.RTSP_PORT.Name = "RTSP_PORT";
            this.RTSP_PORT.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.RTSP_PORT.Visible = true;
            this.RTSP_PORT.VisibleIndex = 7;
            this.RTSP_PORT.Width = 63;
            // 
            // HTTP_PORT
            // 
            this.HTTP_PORT.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.HTTP_PORT.AppearanceCell.Options.UseFont = true;
            this.HTTP_PORT.AppearanceCell.Options.UseTextOptions = true;
            this.HTTP_PORT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.HTTP_PORT.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.HTTP_PORT.AppearanceHeader.Options.UseFont = true;
            this.HTTP_PORT.AppearanceHeader.Options.UseTextOptions = true;
            this.HTTP_PORT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.HTTP_PORT.Caption = "HTTP\nPort";
            this.HTTP_PORT.FieldName = "HTTP_PORT";
            this.HTTP_PORT.Name = "HTTP_PORT";
            this.HTTP_PORT.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.HTTP_PORT.Visible = true;
            this.HTTP_PORT.VisibleIndex = 8;
            this.HTTP_PORT.Width = 58;
            // 
            // RIGHT_USE
            // 
            this.RIGHT_USE.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RIGHT_USE.AppearanceCell.Options.UseFont = true;
            this.RIGHT_USE.AppearanceCell.Options.UseTextOptions = true;
            this.RIGHT_USE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RIGHT_USE.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.RIGHT_USE.AppearanceHeader.Options.UseFont = true;
            this.RIGHT_USE.AppearanceHeader.Options.UseTextOptions = true;
            this.RIGHT_USE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.RIGHT_USE.Caption = "우회전\n여부";
            this.RIGHT_USE.ColumnEdit = this.rpichkRightUse;
            this.RIGHT_USE.FieldName = "RIGHT_USE";
            this.RIGHT_USE.Name = "RIGHT_USE";
            this.RIGHT_USE.OptionsFilter.AutoFilterCondition = DevExpress.XtraTreeList.Columns.AutoFilterCondition.Contains;
            this.RIGHT_USE.Visible = true;
            this.RIGHT_USE.VisibleIndex = 9;
            this.RIGHT_USE.Width = 78;
            // 
            // rpichkRightUse
            // 
            this.rpichkRightUse.AutoHeight = false;
            this.rpichkRightUse.Name = "rpichkRightUse";
            this.rpichkRightUse.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.rpichkRightUse.ValueChecked = 1;
            this.rpichkRightUse.ValueGrayed = 0;
            this.rpichkRightUse.ValueUnchecked = 0;
            this.rpichkRightUse.CheckedChanged += new System.EventHandler(this.rpichkRightUse_CheckedChanged);
            // 
            // rpichkcbDirection
            // 
            this.rpichkcbDirection.AutoHeight = false;
            this.rpichkcbDirection.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpichkcbDirection.Name = "rpichkcbDirection";
            // 
            // ManageCrossCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1171, 621);
            this.Controls.Add(this.tlCcam);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageCrossCamera";
            this.ShowIcon = false;
            this.Text = "교차로 카메라 등록";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCrossCameraTree_FormClosing);
            this.Load += new System.EventHandler(this.ManageCrossCameraTree_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlCcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpicbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpitbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpichkRightUse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpichkcbDirection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CAM_ID_OLD;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn DIRECTION;
        private DevExpress.XtraTreeList.Columns.TreeListColumn IP;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn PW;
        private DevExpress.XtraTreeList.Columns.TreeListColumn RTSP_URL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn RTSP_PORT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn HTTP_PORT;
        private DevExpress.XtraTreeList.Columns.TreeListColumn RIGHT_USE;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox rpicbDirection;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit rpichkcbDirection;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CAM_ID;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit rpichkRightUse;
        private DevExpress.XtraTreeList.TreeList tlCcam;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit rpitbPassword;
    }
}