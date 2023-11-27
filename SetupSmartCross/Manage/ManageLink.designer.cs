namespace SetupSmartCross.Manage
{
    partial class ManageLink
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
            this.components = new System.ComponentModel.Container();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.tlLocal = new RexControl.DevTreeList(this.components);
            this.ID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.NAME = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.STATUSINFO = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.LEVEL = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.CAP_DATE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.LOCAL_TYPE = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.tbFindText = new DevExpress.XtraEditors.TextEdit();
            this.chkShowID = new DevExpress.XtraEditors.CheckEdit();
            this.btnTreeExpend = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcLink = new DevExpress.XtraGrid.GridControl();
            this.gvLink = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcEnd = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnLevelAdd = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel0Add = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel0Delete = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel0Modify = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel1Modify = new DevExpress.XtraBars.BarButtonItem();
            this.btnLevel1Delete = new DevExpress.XtraBars.BarButtonItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.chkMapShowCaption = new DevExpress.XtraEditors.CheckEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.elementHostMap = new System.Windows.Forms.Integration.ElementHost();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFindText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowID.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMapShowCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraTabControl1);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(331, 752);
            this.panelControl2.TabIndex = 13;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(327, 704);
            this.xtraTabControl1.TabIndex = 13;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.groupControl2);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(321, 675);
            this.xtraTabPage1.Text = "교차로 목록";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.tlLocal);
            this.groupControl2.Controls.Add(this.tbFindText);
            this.groupControl2.Controls.Add(this.chkShowID);
            this.groupControl2.Controls.Add(this.btnTreeExpend);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 0);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(321, 675);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "현장정보";
            // 
            // tlLocal
            // 
            this.tlLocal.AllowDrop = true;
            this.tlLocal.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.ID,
            this.NAME,
            this.STATUSINFO,
            this.LEVEL,
            this.CAP_DATE,
            this.LOCAL_TYPE});
            this.tlLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlLocal.Location = new System.Drawing.Point(2, 44);
            this.tlLocal.LookAndFeel.SkinName = "Liquid Sky";
            this.tlLocal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlLocal.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.tlLocal.Name = "tlLocal";
            this.tlLocal.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.tlLocal.OptionsBehavior.Editable = false;
            this.tlLocal.OptionsPrint.PrintAllNodes = true;
            this.tlLocal.OptionsSelection.MultiSelect = true;
            this.tlLocal.OptionsView.ShowColumns = false;
            this.tlLocal.OptionsView.ShowHorzLines = false;
            this.tlLocal.OptionsView.ShowIndicator = false;
            this.tlLocal.OptionsView.ShowVertLines = false;
            this.tlLocal.ParentFieldName = "PARENT_ID";
            this.tlLocal.Size = new System.Drawing.Size(317, 629);
            this.tlLocal.TabIndex = 0;
            this.tlLocal.ToolTipMember = "";
            this.tlLocal.TreeLevelWidth = 21;
            this.tlLocal.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.tlLocal_FocusedNodeChanged);
            this.tlLocal.SelectionChanged += new System.EventHandler(this.tlLocal_SelectionChanged);
            // 
            // ID
            // 
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            // 
            // NAME
            // 
            this.NAME.Caption = "NAME";
            this.NAME.FieldName = "NAME";
            this.NAME.Name = "NAME";
            this.NAME.Visible = true;
            this.NAME.VisibleIndex = 0;
            // 
            // STATUSINFO
            // 
            this.STATUSINFO.Caption = "STATUSINFO";
            this.STATUSINFO.FieldName = "STATUSINFO";
            this.STATUSINFO.Name = "STATUSINFO";
            // 
            // LEVEL
            // 
            this.LEVEL.Caption = "LEVEL";
            this.LEVEL.FieldName = "LEVEL";
            this.LEVEL.Name = "LEVEL";
            // 
            // CAP_DATE
            // 
            this.CAP_DATE.Caption = "CAP_DATE";
            this.CAP_DATE.FieldName = "CAP_DATE";
            this.CAP_DATE.Name = "CAP_DATE";
            // 
            // LOCAL_TYPE
            // 
            this.LOCAL_TYPE.Caption = "LOCAL_TYPE";
            this.LOCAL_TYPE.FieldName = "LOCAL_TYPE";
            this.LOCAL_TYPE.Name = "LOCAL_TYPE";
            // 
            // tbFindText
            // 
            this.tbFindText.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbFindText.EditValue = "";
            this.tbFindText.Location = new System.Drawing.Point(2, 22);
            this.tbFindText.Name = "tbFindText";
            this.tbFindText.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindText.Properties.Appearance.Options.UseFont = true;
            this.tbFindText.Properties.LookAndFeel.SkinName = "Liquid Sky";
            this.tbFindText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tbFindText.Properties.NullValuePrompt = "검색어 입력 후 \'Enter\' 를 눌러주세요";
            this.tbFindText.Size = new System.Drawing.Size(317, 22);
            this.tbFindText.TabIndex = 12;
            this.tbFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFindText_KeyDown);
            // 
            // chkShowID
            // 
            this.chkShowID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowID.Location = new System.Drawing.Point(179, 1);
            this.chkShowID.Name = "chkShowID";
            this.chkShowID.Properties.AllowFocused = false;
            this.chkShowID.Properties.Appearance.Options.UseFont = true;
            this.chkShowID.Properties.Caption = "ID보기";
            this.chkShowID.Properties.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.chkShowID.Size = new System.Drawing.Size(55, 19);
            this.chkShowID.TabIndex = 11;
            this.chkShowID.CheckedChanged += new System.EventHandler(this.chkShowID_CheckedChanged);
            // 
            // btnTreeExpend
            // 
            this.btnTreeExpend.AllowFocus = false;
            this.btnTreeExpend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTreeExpend.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTreeExpend.Appearance.Options.UseFont = true;
            this.btnTreeExpend.Appearance.Options.UseForeColor = true;
            this.btnTreeExpend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTreeExpend.Location = new System.Drawing.Point(239, 0);
            this.btnTreeExpend.Name = "btnTreeExpend";
            this.btnTreeExpend.Size = new System.Drawing.Size(80, 22);
            this.btnTreeExpend.TabIndex = 3;
            this.btnTreeExpend.Text = "전체 펼치기";
            this.btnTreeExpend.Click += new System.EventHandler(this.btnTreeExpend_Click);
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcLink);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(321, 675);
            this.xtraTabPage2.Text = "구간 목록";
            // 
            // gcLink
            // 
            this.gcLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLink.Location = new System.Drawing.Point(0, 0);
            this.gcLink.MainView = this.gvLink;
            this.gcLink.MenuManager = this.barManager;
            this.gcLink.Name = "gcLink";
            this.gcLink.Size = new System.Drawing.Size(321, 675);
            this.gcLink.TabIndex = 0;
            this.gcLink.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLink});
            // 
            // gvLink
            // 
            this.gvLink.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gvLink.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvLink.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvLink.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvLink.Appearance.Row.BackColor = System.Drawing.Color.White;
            this.gvLink.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.gvLink.Appearance.Row.Options.UseBackColor = true;
            this.gvLink.Appearance.Row.Options.UseForeColor = true;
            this.gvLink.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcID,
            this.gcName,
            this.gcStart,
            this.gcEnd});
            this.gvLink.DetailHeight = 375;
            this.gvLink.GridControl = this.gcLink;
            this.gvLink.IndicatorWidth = 20;
            this.gvLink.Name = "gvLink";
            this.gvLink.OptionsCustomization.AllowColumnMoving = false;
            this.gvLink.OptionsCustomization.AllowColumnResizing = false;
            this.gvLink.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvLink.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gvLink.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gvLink.OptionsView.ShowGroupPanel = false;
            this.gvLink.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvLink_RowClick);
            this.gvLink.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvLink_CustomDrawRowIndicator);
            // 
            // gcID
            // 
            this.gcID.AppearanceCell.Options.UseTextOptions = true;
            this.gcID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcID.AppearanceHeader.Options.UseTextOptions = true;
            this.gcID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcID.Caption = "ID";
            this.gcID.FieldName = "ID";
            this.gcID.Name = "gcID";
            this.gcID.OptionsColumn.AllowEdit = false;
            this.gcID.OptionsColumn.ReadOnly = true;
            this.gcID.Visible = true;
            this.gcID.VisibleIndex = 0;
            // 
            // gcName
            // 
            this.gcName.AppearanceCell.Options.UseTextOptions = true;
            this.gcName.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.AppearanceHeader.Options.UseTextOptions = true;
            this.gcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcName.Caption = "구간명";
            this.gcName.FieldName = "NAME";
            this.gcName.Name = "gcName";
            this.gcName.OptionsColumn.AllowEdit = false;
            this.gcName.OptionsColumn.ReadOnly = true;
            this.gcName.Visible = true;
            this.gcName.VisibleIndex = 1;
            // 
            // gcStart
            // 
            this.gcStart.AppearanceHeader.Options.UseTextOptions = true;
            this.gcStart.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcStart.Caption = "시작교차로";
            this.gcStart.FieldName = "START";
            this.gcStart.Name = "gcStart";
            this.gcStart.OptionsColumn.AllowEdit = false;
            this.gcStart.OptionsColumn.ReadOnly = true;
            this.gcStart.Visible = true;
            this.gcStart.VisibleIndex = 2;
            // 
            // gcEnd
            // 
            this.gcEnd.AppearanceHeader.Options.UseTextOptions = true;
            this.gcEnd.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcEnd.Caption = "종료교차로";
            this.gcEnd.FieldName = "END";
            this.gcEnd.Name = "gcEnd";
            this.gcEnd.OptionsColumn.AllowEdit = false;
            this.gcEnd.OptionsColumn.ReadOnly = true;
            this.gcEnd.Visible = true;
            this.gcEnd.VisibleIndex = 3;
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnLevelAdd,
            this.btnLevel0Add,
            this.btnLevel0Delete,
            this.btnLevel0Modify,
            this.btnLevel1Modify,
            this.btnLevel1Delete});
            this.barManager.MaxItemId = 6;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1145, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 752);
            this.barDockControlBottom.Size = new System.Drawing.Size(1145, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 752);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1145, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 752);
            // 
            // btnLevelAdd
            // 
            this.btnLevelAdd.Caption = "추가";
            this.btnLevelAdd.Id = 0;
            this.btnLevelAdd.Name = "btnLevelAdd";
            // 
            // btnLevel0Add
            // 
            this.btnLevel0Add.Caption = "추가";
            this.btnLevel0Add.Id = 1;
            this.btnLevel0Add.Name = "btnLevel0Add";
            // 
            // btnLevel0Delete
            // 
            this.btnLevel0Delete.Caption = "삭제";
            this.btnLevel0Delete.Id = 2;
            this.btnLevel0Delete.Name = "btnLevel0Delete";
            // 
            // btnLevel0Modify
            // 
            this.btnLevel0Modify.Caption = "수정";
            this.btnLevel0Modify.Id = 3;
            this.btnLevel0Modify.Name = "btnLevel0Modify";
            // 
            // btnLevel1Modify
            // 
            this.btnLevel1Modify.Caption = "수정";
            this.btnLevel1Modify.Id = 4;
            this.btnLevel1Modify.Name = "btnLevel1Modify";
            // 
            // btnLevel1Delete
            // 
            this.btnLevel1Delete.Caption = "삭제";
            this.btnLevel1Delete.Id = 5;
            this.btnLevel1Delete.Name = "btnLevel1Delete";
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 706);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(327, 44);
            this.panelControl1.TabIndex = 14;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Controls.Add(this.chkMapShowCaption);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(331, 706);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(814, 46);
            this.panelControl3.TabIndex = 15;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(650, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "저 장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkMapShowCaption
            // 
            this.chkMapShowCaption.Location = new System.Drawing.Point(16, 13);
            this.chkMapShowCaption.MenuManager = this.barManager;
            this.chkMapShowCaption.Name = "chkMapShowCaption";
            this.chkMapShowCaption.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkMapShowCaption.Properties.Appearance.Options.UseFont = true;
            this.chkMapShowCaption.Properties.Appearance.Options.UseForeColor = true;
            this.chkMapShowCaption.Properties.Caption = "명칭 보기";
            this.chkMapShowCaption.Size = new System.Drawing.Size(75, 19);
            this.chkMapShowCaption.TabIndex = 3;
            this.chkMapShowCaption.CheckedChanged += new System.EventHandler(this.chkMapShowCaption_CheckedChanged);
            // 
            // btnClose
            // 
            this.btnClose.AllowFocus = false;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Location = new System.Drawing.Point(734, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "닫 기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // elementHostMap
            // 
            this.elementHostMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMap.Location = new System.Drawing.Point(2, 22);
            this.elementHostMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMap.Name = "elementHostMap";
            this.elementHostMap.Size = new System.Drawing.Size(810, 682);
            this.elementHostMap.TabIndex = 20;
            this.elementHostMap.Text = "elementHost1";
            this.elementHostMap.Child = null;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.elementHostMap);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(331, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(814, 706);
            this.groupControl1.TabIndex = 25;
            this.groupControl1.Text = "구간 수정";
            // 
            // ManageLink
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1145, 752);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ManageLink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "구간 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageLink_FormClosing);
            this.Load += new System.EventHandler(this.ManageLink_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFindText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowID.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMapShowCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private RexControl.DevTreeList tlLocal;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnLevelAdd;
        private DevExpress.XtraBars.BarButtonItem btnLevel0Add;
        private DevExpress.XtraBars.BarButtonItem btnLevel0Delete;
        private DevExpress.XtraBars.BarButtonItem btnLevel0Modify;
        private DevExpress.XtraTreeList.Columns.TreeListColumn ID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn NAME;
        private DevExpress.XtraTreeList.Columns.TreeListColumn STATUSINFO;
        private DevExpress.XtraTreeList.Columns.TreeListColumn LEVEL;
        private DevExpress.XtraTreeList.Columns.TreeListColumn CAP_DATE;
        private DevExpress.XtraTreeList.Columns.TreeListColumn LOCAL_TYPE;
        private DevExpress.XtraBars.BarButtonItem btnLevel1Modify;
        private DevExpress.XtraBars.BarButtonItem btnLevel1Delete;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnTreeExpend;
        private System.Windows.Forms.Integration.ElementHost elementHostMap;
        private DevExpress.XtraEditors.CheckEdit chkMapShowCaption;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkShowID;
        private DevExpress.XtraEditors.TextEdit tbFindText;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gcLink;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLink;
        private DevExpress.XtraGrid.Columns.GridColumn gcID;
        private DevExpress.XtraGrid.Columns.GridColumn gcStart;
        private DevExpress.XtraGrid.Columns.GridColumn gcEnd;
        private DevExpress.XtraGrid.Columns.GridColumn gcName;
    }
}