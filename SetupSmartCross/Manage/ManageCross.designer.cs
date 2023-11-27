namespace SetupSmartCross.Manage
{
    partial class ManageCross
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageCross));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
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
            this.gcMiniMapTitle = new DevExpress.XtraEditors.GroupControl();
            this.elementHostMiniMap = new System.Windows.Forms.Integration.ElementHost();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkMiniMapShowCaption = new DevExpress.XtraEditors.CheckEdit();
            this.btnMiniMapSave = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.chkMapShowCaption = new DevExpress.XtraEditors.CheckEdit();
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
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.popupMenuLevel = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenuLevel0 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popupMenuLevel1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.elementHostMap = new System.Windows.Forms.Integration.ElementHost();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tlLocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFindText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMiniMapTitle)).BeginInit();
            this.gcMiniMapTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMiniMapShowCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMapShowCaption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.groupControl2);
            this.panelControl2.Controls.Add(this.gcMiniMapTitle);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(331, 702);
            this.panelControl2.TabIndex = 13;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.tlLocal);
            this.groupControl2.Controls.Add(this.tbFindText);
            this.groupControl2.Controls.Add(this.chkShowID);
            this.groupControl2.Controls.Add(this.btnTreeExpend);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(2, 2);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(327, 433);
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
            this.tlLocal.Location = new System.Drawing.Point(2, 45);
            this.tlLocal.LookAndFeel.SkinName = "Liquid Sky";
            this.tlLocal.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tlLocal.Name = "tlLocal";
            this.tlLocal.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.tlLocal.OptionsBehavior.DragNodes = true;
            this.tlLocal.OptionsBehavior.Editable = false;
            this.tlLocal.OptionsPrint.PrintAllNodes = true;
            this.tlLocal.OptionsSelection.MultiSelect = true;
            this.tlLocal.OptionsView.ShowColumns = false;
            this.tlLocal.OptionsView.ShowHorzLines = false;
            this.tlLocal.OptionsView.ShowIndicator = false;
            this.tlLocal.OptionsView.ShowVertLines = false;
            this.tlLocal.ParentFieldName = "PARENT_ID";
            this.tlLocal.Size = new System.Drawing.Size(323, 386);
            this.tlLocal.TabIndex = 0;
            this.tlLocal.ToolTipMember = "";
            this.tlLocal.TreeLevelWidth = 21;
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
            this.tbFindText.Location = new System.Drawing.Point(2, 23);
            this.tbFindText.Name = "tbFindText";
            this.tbFindText.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFindText.Properties.Appearance.Options.UseFont = true;
            this.tbFindText.Properties.LookAndFeel.SkinName = "Liquid Sky";
            this.tbFindText.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tbFindText.Properties.NullValuePrompt = "검색어 입력 후 \'Enter\' 를 눌러주세요";
            this.tbFindText.Properties.NullValuePromptShowForEmptyValue = true;
            this.tbFindText.Size = new System.Drawing.Size(323, 22);
            this.tbFindText.TabIndex = 12;
            this.tbFindText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFindText_KeyDown);
            // 
            // chkShowID
            // 
            this.chkShowID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowID.Location = new System.Drawing.Point(185, 1);
            this.chkShowID.Name = "chkShowID";
            this.chkShowID.Properties.AllowFocused = false;
            this.chkShowID.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
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
            this.btnTreeExpend.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnTreeExpend.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTreeExpend.Appearance.Options.UseFont = true;
            this.btnTreeExpend.Appearance.Options.UseForeColor = true;
            this.btnTreeExpend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTreeExpend.Location = new System.Drawing.Point(246, 0);
            this.btnTreeExpend.Name = "btnTreeExpend";
            this.btnTreeExpend.Size = new System.Drawing.Size(80, 21);
            this.btnTreeExpend.TabIndex = 3;
            this.btnTreeExpend.Text = "전체 펼치기";
            this.btnTreeExpend.Click += new System.EventHandler(this.btnTreeExpend_Click);
            // 
            // gcMiniMapTitle
            // 
            this.gcMiniMapTitle.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.gcMiniMapTitle.AppearanceCaption.ForeColor = System.Drawing.Color.Gold;
            this.gcMiniMapTitle.AppearanceCaption.Options.UseFont = true;
            this.gcMiniMapTitle.AppearanceCaption.Options.UseForeColor = true;
            this.gcMiniMapTitle.AppearanceCaption.Options.UseTextOptions = true;
            this.gcMiniMapTitle.AppearanceCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcMiniMapTitle.AppearanceCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gcMiniMapTitle.Controls.Add(this.elementHostMiniMap);
            this.gcMiniMapTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcMiniMapTitle.Location = new System.Drawing.Point(2, 435);
            this.gcMiniMapTitle.Name = "gcMiniMapTitle";
            this.gcMiniMapTitle.Size = new System.Drawing.Size(327, 224);
            this.gcMiniMapTitle.TabIndex = 0;
            // 
            // elementHostMiniMap
            // 
            this.elementHostMiniMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMiniMap.Location = new System.Drawing.Point(2, 25);
            this.elementHostMiniMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMiniMap.Name = "elementHostMiniMap";
            this.elementHostMiniMap.Size = new System.Drawing.Size(323, 197);
            this.elementHostMiniMap.TabIndex = 21;
            this.elementHostMiniMap.Text = "elementHost1";
            this.elementHostMiniMap.Child = null;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkMiniMapShowCaption);
            this.panelControl1.Controls.Add(this.btnMiniMapSave);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(2, 659);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(327, 41);
            this.panelControl1.TabIndex = 14;
            // 
            // chkMiniMapShowCaption
            // 
            this.chkMiniMapShowCaption.Location = new System.Drawing.Point(5, 13);
            this.chkMiniMapShowCaption.Name = "chkMiniMapShowCaption";
            this.chkMiniMapShowCaption.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkMiniMapShowCaption.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkMiniMapShowCaption.Properties.Appearance.Options.UseFont = true;
            this.chkMiniMapShowCaption.Properties.Appearance.Options.UseForeColor = true;
            this.chkMiniMapShowCaption.Properties.Caption = "명칭 보기";
            this.chkMiniMapShowCaption.Size = new System.Drawing.Size(75, 19);
            this.chkMiniMapShowCaption.TabIndex = 3;
            this.chkMiniMapShowCaption.CheckedChanged += new System.EventHandler(this.chkMiniMapShowCaption_CheckedChanged);
            // 
            // btnMiniMapSave
            // 
            this.btnMiniMapSave.AllowFocus = false;
            this.btnMiniMapSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMiniMapSave.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnMiniMapSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnMiniMapSave.Appearance.Options.UseFont = true;
            this.btnMiniMapSave.Appearance.Options.UseForeColor = true;
            this.btnMiniMapSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMiniMapSave.Image = ((System.Drawing.Image)(resources.GetObject("btnMiniMapSave.Image")));
            this.btnMiniMapSave.Location = new System.Drawing.Point(176, 11);
            this.btnMiniMapSave.Name = "btnMiniMapSave";
            this.btnMiniMapSave.Size = new System.Drawing.Size(139, 23);
            this.btnMiniMapSave.TabIndex = 2;
            this.btnMiniMapSave.Text = "미니맵 Zoom 저장";
            this.btnMiniMapSave.Click += new System.EventHandler(this.btnMiniMapSave_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.chkMapShowCaption);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnSave);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl3.Location = new System.Drawing.Point(331, 659);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(814, 43);
            this.panelControl3.TabIndex = 15;
            // 
            // chkMapShowCaption
            // 
            this.chkMapShowCaption.Location = new System.Drawing.Point(16, 12);
            this.chkMapShowCaption.MenuManager = this.barManager;
            this.chkMapShowCaption.Name = "chkMapShowCaption";
            this.chkMapShowCaption.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.chkMapShowCaption.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkMapShowCaption.Properties.Appearance.Options.UseFont = true;
            this.chkMapShowCaption.Properties.Appearance.Options.UseForeColor = true;
            this.chkMapShowCaption.Properties.Caption = "명칭 보기";
            this.chkMapShowCaption.Size = new System.Drawing.Size(75, 19);
            this.chkMapShowCaption.TabIndex = 3;
            this.chkMapShowCaption.CheckedChanged += new System.EventHandler(this.chkMapShowCaption_CheckedChanged);
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
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 702);
            this.barDockControlBottom.Size = new System.Drawing.Size(1145, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 702);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1145, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 702);
            // 
            // btnLevelAdd
            // 
            this.btnLevelAdd.Caption = "추가";
            this.btnLevelAdd.Id = 0;
            this.btnLevelAdd.Name = "btnLevelAdd";
            this.btnLevelAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevelAdd_ItemClick);
            // 
            // btnLevel0Add
            // 
            this.btnLevel0Add.Caption = "추가";
            this.btnLevel0Add.Id = 1;
            this.btnLevel0Add.Name = "btnLevel0Add";
            this.btnLevel0Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel0Add_ItemClick);
            // 
            // btnLevel0Delete
            // 
            this.btnLevel0Delete.Caption = "삭제";
            this.btnLevel0Delete.Id = 2;
            this.btnLevel0Delete.Name = "btnLevel0Delete";
            this.btnLevel0Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel0Delete_ItemClick);
            // 
            // btnLevel0Modify
            // 
            this.btnLevel0Modify.Caption = "수정";
            this.btnLevel0Modify.Id = 3;
            this.btnLevel0Modify.Name = "btnLevel0Modify";
            this.btnLevel0Modify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel0Modify_ItemClick);
            // 
            // btnLevel1Modify
            // 
            this.btnLevel1Modify.Caption = "수정";
            this.btnLevel1Modify.Id = 4;
            this.btnLevel1Modify.Name = "btnLevel1Modify";
            this.btnLevel1Modify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel1Modify_ItemClick);
            // 
            // btnLevel1Delete
            // 
            this.btnLevel1Delete.Caption = "삭제";
            this.btnLevel1Delete.Id = 5;
            this.btnLevel1Delete.Name = "btnLevel1Delete";
            this.btnLevel1Delete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLevel1Delete_ItemClick);
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
            this.btnClose.Location = new System.Drawing.Point(727, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
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
            this.btnSave.Location = new System.Drawing.Point(594, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "교차로 위치 저장";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // popupMenuLevel
            // 
            this.popupMenuLevel.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevelAdd)});
            this.popupMenuLevel.Manager = this.barManager;
            this.popupMenuLevel.Name = "popupMenuLevel";
            // 
            // popupMenuLevel0
            // 
            this.popupMenuLevel0.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevel0Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevel0Modify),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevel0Delete)});
            this.popupMenuLevel0.Manager = this.barManager;
            this.popupMenuLevel0.Name = "popupMenuLevel0";
            // 
            // popupMenuLevel1
            // 
            this.popupMenuLevel1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevel1Modify),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnLevel1Delete)});
            this.popupMenuLevel1.Manager = this.barManager;
            this.popupMenuLevel1.Name = "popupMenuLevel1";
            // 
            // elementHostMap
            // 
            this.elementHostMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMap.Location = new System.Drawing.Point(2, 23);
            this.elementHostMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMap.Name = "elementHostMap";
            this.elementHostMap.Size = new System.Drawing.Size(810, 634);
            this.elementHostMap.TabIndex = 20;
            this.elementHostMap.Text = "elementHost1";
            this.elementHostMap.Child = null;
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.elementHostMap);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(331, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(814, 659);
            this.groupControl1.TabIndex = 25;
            this.groupControl1.Text = "교차로 위치 이동";
            // 
            // ManageCross
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 702);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageCross";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "교차로 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ManageCross_FormClosing);
            this.Load += new System.EventHandler(this.ManageCross_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tlLocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbFindText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMiniMapTitle)).EndInit();
            this.gcMiniMapTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMiniMapShowCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMapShowCaption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuLevel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private RexControl.DevTreeList tlLocal;
        private DevExpress.XtraEditors.GroupControl gcMiniMapTitle;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraBars.PopupMenu popupMenuLevel;
        private DevExpress.XtraBars.PopupMenu popupMenuLevel0;
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
        private DevExpress.XtraBars.PopupMenu popupMenuLevel1;
        private DevExpress.XtraEditors.SimpleButton btnMiniMapSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnTreeExpend;
        private System.Windows.Forms.Integration.ElementHost elementHostMap;
        private System.Windows.Forms.Integration.ElementHost elementHostMiniMap;
        private DevExpress.XtraEditors.CheckEdit chkMapShowCaption;
        private DevExpress.XtraEditors.CheckEdit chkMiniMapShowCaption;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chkShowID;
        private DevExpress.XtraEditors.TextEdit tbFindText;
    }
}