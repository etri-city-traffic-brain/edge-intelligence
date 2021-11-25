namespace SetupSmartCross
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.defaultLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.barMain = new DevExpress.XtraBars.Bar();
            this.barSubItemProgram = new DevExpress.XtraBars.BarSubItem();
            this.btnProgramExit = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemManage = new DevExpress.XtraBars.BarSubItem();
            this.btnManageCrossCamera = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageCross = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUser = new DevExpress.XtraBars.BarButtonItem();
            this.btnManageUserGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItemSetup = new DevExpress.XtraBars.BarSubItem();
            this.btnSetupSystem = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.listViewLog = new System.Windows.Forms.ListView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.customProgressBarMemory = new Common.CustomProgressBar();
            this.customProgressBarCPU = new Common.CustomProgressBar();
            this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPageMap = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
            this.xtraTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel
            // 
            this.defaultLookAndFeel.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.defaultLookAndFeel.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // barManager
            // 
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barMain});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.DockWindowTabFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItemProgram,
            this.btnProgramExit,
            this.barSubItemManage,
            this.barSubItemSetup,
            this.btnManageCrossCamera,
            this.btnManageCross,
            this.btnSetupSystem,
            this.btnManageUser,
            this.btnManageUserGroup});
            this.barManager.MainMenu = this.barMain;
            this.barManager.MaxItemId = 11;
            // 
            // barMain
            // 
            this.barMain.BarAppearance.Normal.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.barMain.BarAppearance.Normal.Options.UseFont = true;
            this.barMain.BarAppearance.Pressed.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.barMain.BarAppearance.Pressed.Options.UseFont = true;
            this.barMain.BarName = "Main menu";
            this.barMain.DockCol = 0;
            this.barMain.DockRow = 0;
            this.barMain.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.barMain.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemProgram),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemManage),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItemSetup)});
            this.barMain.OptionsBar.DrawBorder = false;
            this.barMain.OptionsBar.DrawDragBorder = false;
            this.barMain.OptionsBar.MultiLine = true;
            this.barMain.OptionsBar.UseWholeRow = true;
            this.barMain.Text = "Main menu";
            // 
            // barSubItemProgram
            // 
            this.barSubItemProgram.Caption = "프로그램";
            this.barSubItemProgram.Id = 0;
            this.barSubItemProgram.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnProgramExit)});
            this.barSubItemProgram.Name = "barSubItemProgram";
            // 
            // btnProgramExit
            // 
            this.btnProgramExit.Caption = "종료";
            this.btnProgramExit.Id = 1;
            this.btnProgramExit.Name = "btnProgramExit";
            this.btnProgramExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // barSubItemManage
            // 
            this.barSubItemManage.Caption = "관리";
            this.barSubItemManage.Id = 4;
            this.barSubItemManage.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnManageCrossCamera),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnManageCross),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnManageUser),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnManageUserGroup)});
            this.barSubItemManage.Name = "barSubItemManage";
            // 
            // btnManageCrossCamera
            // 
            this.btnManageCrossCamera.Caption = "교차로 카메라 관리";
            this.btnManageCrossCamera.Id = 6;
            this.btnManageCrossCamera.Name = "btnManageCrossCamera";
            this.btnManageCrossCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // btnManageCross
            // 
            this.btnManageCross.Caption = "교차로 관리";
            this.btnManageCross.Id = 7;
            this.btnManageCross.Name = "btnManageCross";
            this.btnManageCross.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // btnManageUser
            // 
            this.btnManageUser.Caption = "사용자 관리";
            this.btnManageUser.Id = 9;
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // btnManageUserGroup
            // 
            this.btnManageUserGroup.Caption = "사용자 그룹 관리";
            this.btnManageUserGroup.Id = 10;
            this.btnManageUserGroup.Name = "btnManageUserGroup";
            this.btnManageUserGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // barSubItemSetup
            // 
            this.barSubItemSetup.Caption = "설정";
            this.barSubItemSetup.Id = 5;
            this.barSubItemSetup.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnSetupSystem)});
            this.barSubItemSetup.Name = "barSubItemSetup";
            // 
            // btnSetupSystem
            // 
            this.btnSetupSystem.Caption = "시스템 설정";
            this.btnSetupSystem.Id = 8;
            this.btnSetupSystem.Name = "btnSetupSystem";
            this.btnSetupSystem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMainMenu_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(740, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 668);
            this.barDockControlBottom.Size = new System.Drawing.Size(740, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 644);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(740, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 644);
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.panelControl4);
            this.panelControl2.Controls.Add(this.panelControl3);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 497);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(740, 171);
            this.panelControl2.TabIndex = 5;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.listViewLog);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(171, 0);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(569, 171);
            this.panelControl4.TabIndex = 7;
            // 
            // listViewLog
            // 
            this.listViewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewLog.Location = new System.Drawing.Point(2, 2);
            this.listViewLog.Margin = new System.Windows.Forms.Padding(0);
            this.listViewLog.Name = "listViewLog";
            this.listViewLog.Size = new System.Drawing.Size(565, 167);
            this.listViewLog.TabIndex = 2;
            this.listViewLog.UseCompatibleStateImageBehavior = false;
            this.listViewLog.View = System.Windows.Forms.View.List;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Controls.Add(this.customProgressBarMemory);
            this.panelControl3.Controls.Add(this.customProgressBarCPU);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(171, 171);
            this.panelControl3.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl2.Location = new System.Drawing.Point(101, 144);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(45, 15);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Memory";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.labelControl1.Location = new System.Drawing.Point(36, 144);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(23, 15);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "CPU";
            // 
            // customProgressBarMemory
            // 
            this.customProgressBarMemory.CustomText = "";
            this.customProgressBarMemory.Location = new System.Drawing.Point(91, 14);
            this.customProgressBarMemory.Name = "customProgressBarMemory";
            this.customProgressBarMemory.PercentView = true;
            this.customProgressBarMemory.ProgressColor = System.Drawing.Color.ForestGreen;
            this.customProgressBarMemory.ProgressDashed = 5;
            this.customProgressBarMemory.ProgressKind = Common.CustomProgressBar.ProgressBarKind.Vertical;
            this.customProgressBarMemory.ShowText = true;
            this.customProgressBarMemory.Size = new System.Drawing.Size(65, 124);
            this.customProgressBarMemory.TabIndex = 0;
            this.customProgressBarMemory.TextColor = System.Drawing.Color.Black;
            this.customProgressBarMemory.TextFont = new System.Drawing.Font("맑은 고딕", 11F);
            // 
            // customProgressBarCPU
            // 
            this.customProgressBarCPU.CustomText = "";
            this.customProgressBarCPU.Location = new System.Drawing.Point(15, 14);
            this.customProgressBarCPU.Name = "customProgressBarCPU";
            this.customProgressBarCPU.PercentView = true;
            this.customProgressBarCPU.ProgressColor = System.Drawing.Color.ForestGreen;
            this.customProgressBarCPU.ProgressDashed = 5;
            this.customProgressBarCPU.ProgressKind = Common.CustomProgressBar.ProgressBarKind.Vertical;
            this.customProgressBarCPU.ShowText = true;
            this.customProgressBarCPU.Size = new System.Drawing.Size(65, 124);
            this.customProgressBarCPU.TabIndex = 0;
            this.customProgressBarCPU.TextColor = System.Drawing.Color.Black;
            this.customProgressBarCPU.TextFont = new System.Drawing.Font("맑은 고딕", 11F);
            // 
            // xtraTabControl
            // 
            this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl.Location = new System.Drawing.Point(0, 24);
            this.xtraTabControl.Name = "xtraTabControl";
            this.xtraTabControl.SelectedTabPage = this.xtraTabPageMap;
            this.xtraTabControl.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl.Size = new System.Drawing.Size(740, 473);
            this.xtraTabControl.TabIndex = 10;
            this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageMap,
            this.xtraTabPage2});
            // 
            // xtraTabPageMap
            // 
            this.xtraTabPageMap.Name = "xtraTabPageMap";
            this.xtraTabPageMap.Size = new System.Drawing.Size(734, 467);
            this.xtraTabPageMap.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(294, 271);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // Main
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 668);
            this.Controls.Add(this.xtraTabControl);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 700);
            this.Name = "Main";
            this.Text = "스마트교차로 카메라 설정";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
            this.xtraTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel;
        private DevExpress.XtraBars.BarManager barManager;
        private DevExpress.XtraBars.Bar barMain;
        private DevExpress.XtraBars.BarSubItem barSubItemProgram;
        private DevExpress.XtraBars.BarButtonItem btnProgramExit;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarSubItem barSubItemManage;
        private DevExpress.XtraBars.BarButtonItem btnManageCrossCamera;
        private DevExpress.XtraBars.BarButtonItem btnManageCross;
        private DevExpress.XtraBars.BarSubItem barSubItemSetup;
        private DevExpress.XtraBars.BarButtonItem btnSetupSystem;
        private DevExpress.XtraBars.BarButtonItem btnManageUser;
        private DevExpress.XtraBars.BarButtonItem btnManageUserGroup;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.ListView listViewLog;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Common.CustomProgressBar customProgressBarMemory;
        private Common.CustomProgressBar customProgressBarCPU;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl;
        private DevExpress.XtraTab.XtraTabPage xtraTabPageMap;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;


    }
}

