using Common;
using DevExpress.XtraEditors;
using SetupSmartCross.DataBase;
using SetupSmartCross.Manage;
using SetupSmartCross.Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace SetupSmartCross
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        private System.Threading.Timer m_pTimer = null;

        public Main()
        {
            InitializeComponent();

            this.Opacity = 0;

            IniData.Read();

            XtraMessageBox.AllowCustomLookAndFeel = true;
            DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("맑은 고딕", 9);
        }

        #region 로그
        public void MakeLog(string sLog, int bScreen = 1)
        {
            string sMsg;

            sMsg = string.Format("[{0}] {1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, sLog);
            if (MV.LogCtrl != null)
                MV.LogCtrl.AddLog(sMsg, bScreen);
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            else
            {

                IniData.Write();

                if (m_pTimer != null)
                {
                    m_pTimer.Dispose();
                }
                
                if (MV.LoadData != null)
                {
                    MV.LoadData.Close();
                }

                if (MV.DbManager != null)
                {
                    MV.DbManager.Dispose();
                    MV.DbManager = null;
                }

                if (MV.LogCtrl != null)
                {
                    MV.LogCtrl.Close();
                    MV.LogCtrl = null;
                }

                MV.MapIconInfo.Clear();
                MV.IconInfo.Clear();


            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Init();

            if (DBConnect() == false)
            {
                XtraMessageBox.Show(this, "센터 데이터베이스에 연결되지 않았습니다.", string.Empty);

                SetupSystem SetupSystem = new SetupSystem();
                SetupSystem.ShowDialog();

                XtraMessageBox.Show(this, "프로그램을 다시 실행해 주세요.", string.Empty);
                Application.Exit();
                return;
            }

            LoadCode();
            LoadIcon();

            InitForm();

            MakeLog("프로그램 시작.");

            this.Opacity = 100;
        }

        #region Init
        private void Init()
        {
            MV.cpu = new Diagnostics.CPU();
            MV.memory = new Diagnostics.Memory();

            m_pTimer = new System.Threading.Timer(Timer_Tick);
            m_pTimer.Change(1000, 1000);

            MV.LogCtrl = new LogControl("Log", listViewLog, 30);
            MV.LogCtrl.StartThread();

            MV.DbManager = new DataBaseControl.DbManager();
            MV.DbManager.CreateDbWorker();

            MV.LoadData = new DataBase.LoadData();
            MV.LoadData.Start();
        }
        #endregion

        #region 상태변경 타이머
        public void Timer_Tick(Object state)
        {
            if (MV.cpu != null)
            {
                CommonFunction.SimpleInvoke(customProgressBarCPU, () =>
                {
                    customProgressBarCPU.Value = (int)MV.cpu.UsagePercent;
                });
            }

            if (MV.memory != null)
            {
                MV.memory.GetMemory();
                CommonFunction.SimpleInvoke(customProgressBarMemory, () =>
                {
                    customProgressBarMemory.Value = (int)MV.memory.UsagePercent;
                });
            }
        }
        #endregion

        #region DB연결
        public bool DBConnect()
        {
            bool result = false;

            result = MV.DbManager.MySqlConnect(IniData.CenterDbIP, IniData.CenterDbPort, string.Empty, IniData.CenterDbID, IniData.CenterDbPW);
            MV.SQL = new MariaSQL();

            if (!result)
            {
                MakeLog("센터 데이터 베이스 접속 실패");
                return false;
            }

            MakeLog("센터 데이터 베이스 접속 성공");
            return true;
        }
        #endregion

        #region 코드정보 가져오기
        private void LoadCode()
        {
            MV.LoadData.GetCodeInfo(MV.SQL.S_CODE_LOCAL_TYPE, ref MV.LocalType);
            MV.LoadData.GetCodeInfo(MV.SQL.S_CODE_CROSS_DIRECTION, ref MV.CrossDirection);
            MV.LoadData.GetCodeInfo(MV.SQL.S_CODE_CROSS_TYPE, ref MV.CrossType);
            MV.LoadData.GetCodeInfo(MV.SQL.S_CODE_PERMISSION, ref MV.Permission);
        }
        #endregion

        #region 맵아이콘 가져오기
        private void LoadIcon()
        {
            MV.MapIconInfo.Add(IconKey.CrossRoad, new BitmapImage(new Uri(Application.StartupPath + "/Image/crossroad.png")));
            MV.MapIconInfo.Add(IconKey.CrossLengend, new BitmapImage(new Uri(Application.StartupPath + "/Image/crosslegend.png")));
            MV.MapIconInfo.Add(IconKey.AccessLengend, new BitmapImage(new Uri(Application.StartupPath + "/Image/accesslegend.png")));
            MV.MapIconInfo.Add(IconKey.Cctv, new BitmapImage(new Uri(Application.StartupPath + "/Image/cctv.png")));
            MV.MapIconInfo.Add(IconKey.LOS_A, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/A.png")));
            MV.MapIconInfo.Add(IconKey.LOS_B, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/B.png")));
            MV.MapIconInfo.Add(IconKey.LOS_C, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/C.png")));
            MV.MapIconInfo.Add(IconKey.LOS_D, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/D.png")));
            MV.MapIconInfo.Add(IconKey.LOS_E, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/E.png")));
            MV.MapIconInfo.Add(IconKey.LOS_F, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/F.png")));
            MV.MapIconInfo.Add(IconKey.LOS_FF, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/FF.png")));
            MV.MapIconInfo.Add(IconKey.LOS_FFF, new BitmapImage(new Uri(Application.StartupPath + "/Image/LOS/FFF.png")));

            MV.IconInfo.Add(IconKey.CrossRoad, Image.FromFile(Application.StartupPath + "/Image/crossroad.png"));
            MV.IconInfo.Add(IconKey.CrossLengend, Image.FromFile(Application.StartupPath + "/Image/crosslegend.png"));
            MV.IconInfo.Add(IconKey.AccessLengend, Image.FromFile(Application.StartupPath + "/Image/accesslegend.png"));
            MV.IconInfo.Add(IconKey.Cctv, Image.FromFile(Application.StartupPath + "/Image/cctv.png"));
            MV.IconInfo.Add(IconKey.LOS_A, Image.FromFile(Application.StartupPath + "/Image/LOS/A.png"));
            MV.IconInfo.Add(IconKey.LOS_B, Image.FromFile(Application.StartupPath + "/Image/LOS/B.png"));
            MV.IconInfo.Add(IconKey.LOS_C, Image.FromFile(Application.StartupPath + "/Image/LOS/C.png"));
            MV.IconInfo.Add(IconKey.LOS_D, Image.FromFile(Application.StartupPath + "/Image/LOS/D.png"));
            MV.IconInfo.Add(IconKey.LOS_E, Image.FromFile(Application.StartupPath + "/Image/LOS/E.png"));
            MV.IconInfo.Add(IconKey.LOS_F, Image.FromFile(Application.StartupPath + "/Image/LOS/F.png"));
            MV.IconInfo.Add(IconKey.LOS_FF, Image.FromFile(Application.StartupPath + "/Image/LOS/FF.png"));
            MV.IconInfo.Add(IconKey.LOS_FFF, Image.FromFile(Application.StartupPath + "/Image/LOS/FFF.png"));
            MV.IconInfo.Add(IconKey.CrossLengend_S, Image.FromFile(Application.StartupPath + "/Image/crosslegend_S.png"));
            MV.IconInfo.Add(IconKey.LOS_A_S, Image.FromFile(Application.StartupPath + "/Image/LOS/A_S.png"));
            MV.IconInfo.Add(IconKey.LOS_B_S, Image.FromFile(Application.StartupPath + "/Image/LOS/B_S.png"));
            MV.IconInfo.Add(IconKey.LOS_C_S, Image.FromFile(Application.StartupPath + "/Image/LOS/C_S.png"));
            MV.IconInfo.Add(IconKey.LOS_D_S, Image.FromFile(Application.StartupPath + "/Image/LOS/D_S.png"));
            MV.IconInfo.Add(IconKey.LOS_E_S, Image.FromFile(Application.StartupPath + "/Image/LOS/E_S.png"));
            MV.IconInfo.Add(IconKey.LOS_F_S, Image.FromFile(Application.StartupPath + "/Image/LOS/F_S.png"));
            MV.IconInfo.Add(IconKey.LOS_FF_S, Image.FromFile(Application.StartupPath + "/Image/LOS/FF_S.png"));
            MV.IconInfo.Add(IconKey.LOS_FFF_S, Image.FromFile(Application.StartupPath + "/Image/LOS/FFF_S.png"));

        }
        #endregion

        #region Form초기화
        private void InitForm()
        {
        }
        #endregion

        private void btnMainMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (e.Item.Equals(btnProgramExit))
            {
                this.Close();
            }
            else if (e.Item.Equals(btnManageCrossCamera))
            {
                ManageCrossCamera ManageCrossCamera = new ManageCrossCamera();
                ManageCrossCamera.ShowDialog(this);
            }
            else if (e.Item.Equals(btnManageCross))
            {
                ManageCross ManageCross = new ManageCross();
                ManageCross.ShowDialog(this);
            }
            else if (e.Item.Equals(btnManageUser))
            {
                ManageUser ManageUser = new ManageUser();
                ManageUser.ShowDialog(this);
            }
            else if (e.Item.Equals(btnManageUserGroup))
            {
                ManageUserGroup ManageUserGroup = new ManageUserGroup();
                ManageUserGroup.ShowDialog(this);
            }
            else if (e.Item.Equals(btnSetupSystem))
            {
                SetupSystem SetupSystem = new SetupSystem();
                SetupSystem.ShowDialog(this);
            }
           
        }

    }
}
