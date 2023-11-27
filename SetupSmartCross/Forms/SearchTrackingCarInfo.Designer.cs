namespace SetupSmartCross.Forms
{
    partial class SearchTrackingCarInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTrackingCarInfo));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.ETime = new DevExpress.XtraEditors.TimeEdit();
            this.STime = new DevExpress.XtraEditors.TimeEdit();
            this.EDate = new DevExpress.XtraEditors.DateEdit();
            this.SDate = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.elementHostMap = new System.Windows.Forms.Integration.ElementHost();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gcCarInfo = new DevExpress.XtraGrid.GridControl();
            this.gvCarInfo = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.GROUP_KEY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SEQ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAR_NUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CROSS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CROSS_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CAP_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.X = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Y = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CROSS_COUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.POINT_COUNT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearchPath = new DevExpress.XtraEditors.SimpleButton();
            this.tbCarNum = new DevExpress.XtraEditors.TextEdit();
            this.btnDataSort = new DevExpress.XtraEditors.LabelControl();
            this.lbDataSort = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.popupMenuDataSort = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnDataSortByCarNumAsc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataSortByCarNumDesc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataSortByCrossAsc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataSortByCrossDesc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataSortByPointAsc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataSortByPointDesc = new DevExpress.XtraBars.BarButtonItem();
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemRadioGroup1 = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ETime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcCarInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCarNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDataSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupControl1.Appearance.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.ETime);
            this.groupControl1.Controls.Add(this.STime);
            this.groupControl1.Controls.Add(this.EDate);
            this.groupControl1.Controls.Add(this.SDate);
            this.groupControl1.Controls.Add(this.btnSearch);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(407, 95);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "검색조건";
            // 
            // ETime
            // 
            this.ETime.EditValue = new System.DateTime(2022, 8, 9, 0, 0, 0, 0);
            this.ETime.Location = new System.Drawing.Point(162, 60);
            this.ETime.Name = "ETime";
            this.ETime.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ETime.Properties.Appearance.Options.UseFont = true;
            this.ETime.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ETime.Properties.AppearanceFocused.Options.UseFont = true;
            this.ETime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ETime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.ETime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ETime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.ETime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ETime.Properties.Mask.EditMask = "HH:mm:ss";
            this.ETime.Size = new System.Drawing.Size(78, 22);
            this.ETime.TabIndex = 3;
            this.ETime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // STime
            // 
            this.STime.EditValue = new System.DateTime(2022, 8, 9, 0, 0, 0, 0);
            this.STime.Location = new System.Drawing.Point(162, 34);
            this.STime.Name = "STime";
            this.STime.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.STime.Properties.Appearance.Options.UseFont = true;
            this.STime.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.STime.Properties.AppearanceFocused.Options.UseFont = true;
            this.STime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.STime.Properties.DisplayFormat.FormatString = "HH:mm:ss";
            this.STime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.STime.Properties.EditFormat.FormatString = "HH:mm:ss";
            this.STime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.STime.Properties.Mask.EditMask = "HH:mm:ss";
            this.STime.Size = new System.Drawing.Size(78, 22);
            this.STime.TabIndex = 1;
            this.STime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // EDate
            // 
            this.EDate.EditValue = null;
            this.EDate.Location = new System.Drawing.Point(53, 60);
            this.EDate.Name = "EDate";
            this.EDate.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.EDate.Properties.Appearance.Options.UseFont = true;
            this.EDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.EDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.EDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.EDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.EDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EDate.Size = new System.Drawing.Size(100, 22);
            this.EDate.TabIndex = 2;
            this.EDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // SDate
            // 
            this.SDate.EditValue = null;
            this.SDate.Location = new System.Drawing.Point(53, 34);
            this.SDate.Name = "SDate";
            this.SDate.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.SDate.Properties.Appearance.Options.UseFont = true;
            this.SDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.SDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.SDate.Properties.AppearanceFocused.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.SDate.Properties.AppearanceFocused.Options.UseFont = true;
            this.SDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SDate.Size = new System.Drawing.Size(100, 22);
            this.SDate.TabIndex = 0;
            this.SDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // btnSearch
            // 
            this.btnSearch.AllowFocus = false;
            this.btnSearch.Appearance.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Enabled = false;
            this.btnSearch.Location = new System.Drawing.Point(254, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 48);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "검 색";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            this.btnSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl2.Location = new System.Drawing.Point(27, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(8, 15);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "~";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl1.Location = new System.Drawing.Point(16, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 15);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "기간 :";
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupControl2.Appearance.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.Controls.Add(this.elementHostMap);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(407, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1039, 886);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "지도";
            // 
            // elementHostMap
            // 
            this.elementHostMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHostMap.Location = new System.Drawing.Point(2, 23);
            this.elementHostMap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.elementHostMap.Name = "elementHostMap";
            this.elementHostMap.Size = new System.Drawing.Size(1035, 861);
            this.elementHostMap.TabIndex = 23;
            this.elementHostMap.Text = "elementHost1";
            this.elementHostMap.Child = null;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.groupControl3);
            this.panelControl1.Controls.Add(this.groupControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(407, 886);
            this.panelControl1.TabIndex = 0;
            // 
            // groupControl3
            // 
            this.groupControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.groupControl3.Appearance.Options.UseFont = true;
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.gcCarInfo);
            this.groupControl3.Controls.Add(this.panelControl2);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl3.Location = new System.Drawing.Point(0, 95);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(407, 791);
            this.groupControl3.TabIndex = 1;
            this.groupControl3.Text = "검색결과";
            // 
            // gcCarInfo
            // 
            this.gcCarInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcCarInfo.Location = new System.Drawing.Point(2, 58);
            this.gcCarInfo.LookAndFeel.SkinName = "Office 2010 Black";
            this.gcCarInfo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gcCarInfo.MainView = this.gvCarInfo;
            this.gcCarInfo.Name = "gcCarInfo";
            this.gcCarInfo.Size = new System.Drawing.Size(403, 731);
            this.gcCarInfo.TabIndex = 0;
            this.gcCarInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvCarInfo});
            // 
            // gvCarInfo
            // 
            this.gvCarInfo.Appearance.GroupRow.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.gvCarInfo.Appearance.GroupRow.Options.UseFont = true;
            this.gvCarInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.GROUP_KEY,
            this.ID,
            this.SEQ,
            this.CAR_NUM,
            this.CROSS_ID,
            this.CROSS_NAME,
            this.CAP_DATE,
            this.X,
            this.Y,
            this.CROSS_COUNT,
            this.POINT_COUNT});
            this.gvCarInfo.GridControl = this.gcCarInfo;
            this.gvCarInfo.GroupCount = 1;
            this.gvCarInfo.Name = "gvCarInfo";
            this.gvCarInfo.OptionsMenu.ShowGroupSummaryEditorItem = true;
            this.gvCarInfo.OptionsView.ShowAutoFilterRow = true;
            this.gvCarInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvCarInfo.OptionsView.ShowGroupPanel = false;
            this.gvCarInfo.OptionsView.ShowIndicator = false;
            this.gvCarInfo.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.GROUP_KEY, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gvCarInfo.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gvCarInfo_RowClick);
            this.gvCarInfo.CustomDrawGroupRow += new DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventHandler(this.gvCarInfo_CustomDrawGroupRow);
            this.gvCarInfo.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvCarInfo_FocusedRowChanged);
            // 
            // GROUP_KEY
            // 
            this.GROUP_KEY.Caption = "GROUP_KEY";
            this.GROUP_KEY.FieldName = "GROUP_KEY";
            this.GROUP_KEY.Name = "GROUP_KEY";
            this.GROUP_KEY.OptionsColumn.AllowEdit = false;
            this.GROUP_KEY.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            this.GROUP_KEY.OptionsColumn.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ID.AppearanceCell.Options.UseFont = true;
            this.ID.AppearanceCell.Options.UseTextOptions = true;
            this.ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ID.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.ID.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.ID.AppearanceHeader.Options.UseFont = true;
            this.ID.AppearanceHeader.Options.UseForeColor = true;
            this.ID.AppearanceHeader.Options.UseTextOptions = true;
            this.ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.ID.Caption = "ID";
            this.ID.FieldName = "ID";
            this.ID.Name = "ID";
            this.ID.OptionsColumn.AllowEdit = false;
            this.ID.OptionsColumn.ReadOnly = true;
            // 
            // SEQ
            // 
            this.SEQ.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.SEQ.AppearanceCell.Options.UseFont = true;
            this.SEQ.AppearanceCell.Options.UseTextOptions = true;
            this.SEQ.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SEQ.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SEQ.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.SEQ.AppearanceHeader.Options.UseFont = true;
            this.SEQ.AppearanceHeader.Options.UseTextOptions = true;
            this.SEQ.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.SEQ.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.SEQ.Caption = "순번";
            this.SEQ.FieldName = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.OptionsColumn.AllowEdit = false;
            this.SEQ.OptionsColumn.ReadOnly = true;
            this.SEQ.Visible = true;
            this.SEQ.VisibleIndex = 0;
            this.SEQ.Width = 60;
            // 
            // CAR_NUM
            // 
            this.CAR_NUM.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAR_NUM.AppearanceCell.Options.UseFont = true;
            this.CAR_NUM.AppearanceCell.Options.UseTextOptions = true;
            this.CAR_NUM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAR_NUM.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CAR_NUM.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAR_NUM.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.CAR_NUM.AppearanceHeader.Options.UseFont = true;
            this.CAR_NUM.AppearanceHeader.Options.UseForeColor = true;
            this.CAR_NUM.AppearanceHeader.Options.UseTextOptions = true;
            this.CAR_NUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAR_NUM.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CAR_NUM.Caption = "차량번호";
            this.CAR_NUM.FieldName = "CAR_NUM";
            this.CAR_NUM.Name = "CAR_NUM";
            this.CAR_NUM.OptionsColumn.AllowEdit = false;
            this.CAR_NUM.OptionsColumn.ReadOnly = true;
            this.CAR_NUM.Width = 112;
            // 
            // CROSS_ID
            // 
            this.CROSS_ID.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CROSS_ID.AppearanceCell.Options.UseFont = true;
            this.CROSS_ID.AppearanceCell.Options.UseTextOptions = true;
            this.CROSS_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CROSS_ID.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CROSS_ID.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CROSS_ID.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.CROSS_ID.AppearanceHeader.Options.UseFont = true;
            this.CROSS_ID.AppearanceHeader.Options.UseForeColor = true;
            this.CROSS_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.CROSS_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CROSS_ID.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CROSS_ID.Caption = "CROSS_ID";
            this.CROSS_ID.FieldName = "CROSS_ID";
            this.CROSS_ID.Name = "CROSS_ID";
            this.CROSS_ID.OptionsColumn.AllowEdit = false;
            this.CROSS_ID.OptionsColumn.ReadOnly = true;
            // 
            // CROSS_NAME
            // 
            this.CROSS_NAME.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CROSS_NAME.AppearanceCell.Options.UseFont = true;
            this.CROSS_NAME.AppearanceCell.Options.UseTextOptions = true;
            this.CROSS_NAME.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CROSS_NAME.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CROSS_NAME.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CROSS_NAME.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.CROSS_NAME.AppearanceHeader.Options.UseFont = true;
            this.CROSS_NAME.AppearanceHeader.Options.UseForeColor = true;
            this.CROSS_NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.CROSS_NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CROSS_NAME.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CROSS_NAME.Caption = "지점명";
            this.CROSS_NAME.FieldName = "CROSS_NAME";
            this.CROSS_NAME.Name = "CROSS_NAME";
            this.CROSS_NAME.OptionsColumn.AllowEdit = false;
            this.CROSS_NAME.OptionsColumn.ReadOnly = true;
            this.CROSS_NAME.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.CROSS_NAME.Visible = true;
            this.CROSS_NAME.VisibleIndex = 2;
            this.CROSS_NAME.Width = 205;
            // 
            // CAP_DATE
            // 
            this.CAP_DATE.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAP_DATE.AppearanceCell.Options.UseFont = true;
            this.CAP_DATE.AppearanceCell.Options.UseTextOptions = true;
            this.CAP_DATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAP_DATE.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CAP_DATE.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.CAP_DATE.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.CAP_DATE.AppearanceHeader.Options.UseFont = true;
            this.CAP_DATE.AppearanceHeader.Options.UseForeColor = true;
            this.CAP_DATE.AppearanceHeader.Options.UseTextOptions = true;
            this.CAP_DATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.CAP_DATE.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.CAP_DATE.Caption = "통과시간";
            this.CAP_DATE.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.CAP_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.CAP_DATE.FieldName = "CAP_DATE";
            this.CAP_DATE.Name = "CAP_DATE";
            this.CAP_DATE.OptionsColumn.AllowEdit = false;
            this.CAP_DATE.OptionsColumn.ReadOnly = true;
            this.CAP_DATE.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.CAP_DATE.Visible = true;
            this.CAP_DATE.VisibleIndex = 1;
            this.CAP_DATE.Width = 138;
            // 
            // X
            // 
            this.X.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.X.AppearanceCell.Options.UseFont = true;
            this.X.AppearanceCell.Options.UseTextOptions = true;
            this.X.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.X.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.X.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.X.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.X.AppearanceHeader.Options.UseFont = true;
            this.X.AppearanceHeader.Options.UseForeColor = true;
            this.X.AppearanceHeader.Options.UseTextOptions = true;
            this.X.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.X.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.X.Caption = "X";
            this.X.FieldName = "X";
            this.X.Name = "X";
            this.X.OptionsColumn.AllowEdit = false;
            this.X.OptionsColumn.ReadOnly = true;
            // 
            // Y
            // 
            this.Y.AppearanceCell.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Y.AppearanceCell.Options.UseFont = true;
            this.Y.AppearanceCell.Options.UseTextOptions = true;
            this.Y.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Y.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Y.AppearanceHeader.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Y.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.Y.AppearanceHeader.Options.UseFont = true;
            this.Y.AppearanceHeader.Options.UseForeColor = true;
            this.Y.AppearanceHeader.Options.UseTextOptions = true;
            this.Y.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.Y.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.Y.Caption = "Y";
            this.Y.FieldName = "Y";
            this.Y.Name = "Y";
            this.Y.OptionsColumn.AllowEdit = false;
            this.Y.OptionsColumn.ReadOnly = true;
            // 
            // CROSS_COUNT
            // 
            this.CROSS_COUNT.Caption = "CROSS_COUNT";
            this.CROSS_COUNT.FieldName = "CROSS_COUNT";
            this.CROSS_COUNT.Name = "CROSS_COUNT";
            this.CROSS_COUNT.OptionsColumn.AllowEdit = false;
            this.CROSS_COUNT.OptionsColumn.ReadOnly = true;
            // 
            // POINT_COUNT
            // 
            this.POINT_COUNT.Caption = "POINT_COUNT";
            this.POINT_COUNT.FieldName = "POINT_COUNT";
            this.POINT_COUNT.Name = "POINT_COUNT";
            this.POINT_COUNT.OptionsColumn.AllowEdit = false;
            this.POINT_COUNT.OptionsColumn.ReadOnly = true;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btnSearchPath);
            this.panelControl2.Controls.Add(this.tbCarNum);
            this.panelControl2.Controls.Add(this.btnDataSort);
            this.panelControl2.Controls.Add(this.lbDataSort);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(403, 35);
            this.panelControl2.TabIndex = 1;
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.AllowFocus = false;
            this.btnSearchPath.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchPath.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(214)))), ((int)(((byte)(192)))));
            this.btnSearchPath.Appearance.Options.UseFont = true;
            this.btnSearchPath.Appearance.Options.UseForeColor = true;
            this.btnSearchPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPath.Location = new System.Drawing.Point(355, 6);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(44, 23);
            this.btnSearchPath.TabIndex = 3;
            this.btnSearchPath.Text = "Play";
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchPath_Click);
            // 
            // tbCarNum
            // 
            this.tbCarNum.EditValue = "";
            this.tbCarNum.Location = new System.Drawing.Point(254, 6);
            this.tbCarNum.Name = "tbCarNum";
            this.tbCarNum.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.tbCarNum.Properties.Appearance.Options.UseFont = true;
            this.tbCarNum.Size = new System.Drawing.Size(93, 22);
            this.tbCarNum.TabIndex = 2;
            this.tbCarNum.EditValueChanged += new System.EventHandler(this.tbCarNum_EditValueChanged);
            // 
            // btnDataSort
            // 
            this.btnDataSort.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.btnDataSort.Appearance.HoverImage = global::SetupSmartCross.Properties.Resources.DataSort_Hover;
            this.btnDataSort.Appearance.Image = global::SetupSmartCross.Properties.Resources.DataSort;
            this.btnDataSort.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnDataSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDataSort.Location = new System.Drawing.Point(5, 6);
            this.btnDataSort.Name = "btnDataSort";
            this.btnDataSort.Size = new System.Drawing.Size(23, 23);
            this.btnDataSort.TabIndex = 0;
            this.btnDataSort.Click += new System.EventHandler(this.btnDataSort_Click);
            // 
            // lbDataSort
            // 
            this.lbDataSort.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.lbDataSort.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(214)))), ((int)(((byte)(192)))));
            this.lbDataSort.Location = new System.Drawing.Point(34, 10);
            this.lbDataSort.Name = "lbDataSort";
            this.lbDataSort.Size = new System.Drawing.Size(100, 15);
            this.lbDataSort.TabIndex = 0;
            this.lbDataSort.Text = "차량번호 오름차순";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl3.Location = new System.Drawing.Point(193, 10);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 15);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "차량번호 :";
            // 
            // popupMenuDataSort
            // 
            this.popupMenuDataSort.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByCarNumAsc),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByCarNumDesc),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByCrossAsc),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByCrossDesc),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByPointAsc),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDataSortByPointDesc)});
            this.popupMenuDataSort.Manager = this.barManager;
            this.popupMenuDataSort.Name = "popupMenuDataSort";
            // 
            // btnDataSortByCarNumAsc
            // 
            this.btnDataSortByCarNumAsc.Caption = "차량번호 오름차순";
            this.btnDataSortByCarNumAsc.Id = 0;
            this.btnDataSortByCarNumAsc.Name = "btnDataSortByCarNumAsc";
            this.btnDataSortByCarNumAsc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // btnDataSortByCarNumDesc
            // 
            this.btnDataSortByCarNumDesc.Caption = "차량번호 내림차순";
            this.btnDataSortByCarNumDesc.Id = 1;
            this.btnDataSortByCarNumDesc.Name = "btnDataSortByCarNumDesc";
            this.btnDataSortByCarNumDesc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // btnDataSortByCrossAsc
            // 
            this.btnDataSortByCrossAsc.Caption = "교차로 오름차순";
            this.btnDataSortByCrossAsc.Id = 2;
            this.btnDataSortByCrossAsc.Name = "btnDataSortByCrossAsc";
            this.btnDataSortByCrossAsc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // btnDataSortByCrossDesc
            // 
            this.btnDataSortByCrossDesc.Caption = "교차로 내림차순";
            this.btnDataSortByCrossDesc.Id = 3;
            this.btnDataSortByCrossDesc.Name = "btnDataSortByCrossDesc";
            this.btnDataSortByCrossDesc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // btnDataSortByPointAsc
            // 
            this.btnDataSortByPointAsc.Caption = "검지 오름차순";
            this.btnDataSortByPointAsc.Id = 4;
            this.btnDataSortByPointAsc.Name = "btnDataSortByPointAsc";
            this.btnDataSortByPointAsc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // btnDataSortByPointDesc
            // 
            this.btnDataSortByPointDesc.Caption = "검지 내림차순";
            this.btnDataSortByPointDesc.Id = 5;
            this.btnDataSortByPointDesc.Name = "btnDataSortByPointDesc";
            this.btnDataSortByPointDesc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataSort_ItemClick);
            // 
            // barManager
            // 
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDataSortByCarNumAsc,
            this.btnDataSortByCarNumDesc,
            this.btnDataSortByCrossAsc,
            this.btnDataSortByCrossDesc,
            this.btnDataSortByPointAsc,
            this.btnDataSortByPointDesc,
            this.barEditItem1,
            this.barCheckItem1});
            this.barManager.MaxItemId = 8;
            this.barManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemRadioGroup1});
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1446, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 886);
            this.barDockControlBottom.Size = new System.Drawing.Size(1446, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 886);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1446, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 886);
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemRadioGroup1;
            this.barEditItem1.Id = 6;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemRadioGroup1
            // 
            this.repositoryItemRadioGroup1.Name = "repositoryItemRadioGroup1";
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 7;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // SearchTrackingCarInfo
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1446, 886);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchTrackingCarInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "차량번호 추적";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SearchTrackingCarInfo_FormClosing);
            this.Load += new System.EventHandler(this.SearchTrackingCarInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ETime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcCarInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvCarInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCarNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuDataSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemRadioGroup1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TimeEdit ETime;
        private DevExpress.XtraEditors.TimeEdit STime;
        private DevExpress.XtraEditors.DateEdit EDate;
        private DevExpress.XtraEditors.DateEdit SDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraGrid.GridControl gcCarInfo;
        private DevExpress.XtraGrid.Views.Grid.GridView gvCarInfo;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn CAR_NUM;
        private DevExpress.XtraGrid.Columns.GridColumn CROSS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn CROSS_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn CAP_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn X;
        private DevExpress.XtraGrid.Columns.GridColumn Y;
        private System.Windows.Forms.Integration.ElementHost elementHostMap;
        private DevExpress.XtraGrid.Columns.GridColumn SEQ;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.TextEdit tbCarNum;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton btnSearchPath;
        private DevExpress.XtraGrid.Columns.GridColumn GROUP_KEY;
        private DevExpress.XtraEditors.LabelControl btnDataSort;
        private DevExpress.XtraBars.PopupMenu popupMenuDataSort;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByCarNumAsc;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByCarNumDesc;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByCrossAsc;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByCrossDesc;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByPointAsc;
        private DevExpress.XtraBars.BarButtonItem btnDataSortByPointDesc;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup repositoryItemRadioGroup1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraGrid.Columns.GridColumn CROSS_COUNT;
        private DevExpress.XtraGrid.Columns.GridColumn POINT_COUNT;
        private DevExpress.XtraEditors.LabelControl lbDataSort;
    }
}