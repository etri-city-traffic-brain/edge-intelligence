using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SetupSmartCross;
using Common;
using System.Collections;

namespace SetupSmartCross.Setup
{
    public partial class SetupSystem : DevExpress.XtraEditors.XtraForm
    {
        public SetupSystem()
        {
            InitializeComponent();

            GetInfo();
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

        private void GetInfo()
        {
            try
            {
                IniData.Read();

                tbDBIP.Text = IniData.CenterDbIP;
                tbDBPort.Text = IniData.CenterDbPort;
                tbDBID.Text = IniData.CenterDbID;
                tbDBPW.Text = IniData.CenterDbPW;

                tbMapPath.Text = IniData.MapPath;

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("센터 설정정보 로딩 실패 - {0}", ex.Message));
                ////MV.InsertDBLog(LogType.Error, string.Format("시스템 설정 정보 가져오기 실패. - {0}", ex.Message.Replace("'", "")));
            }

        }

        private void SetInfo()
        {
            IniData.CenterDbIP = tbDBIP.Text;
            IniData.CenterDbPort = tbDBPort.Text;
            IniData.CenterDbID = tbDBID.Text;
            IniData.CenterDbPW = tbDBPW.Text;
            
            IniData.MapPath = tbMapPath.Text;
            
            IniData.Write();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SetInfo();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void KeyPress_OnlyNumber(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != '-')
            {
                e.Handled = true;
                XtraMessageBox.Show("숫자만 입력해주세요!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnMapPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowser = new FolderBrowserDialog();
            folderbrowser.SelectedPath = tbMapPath.Text;
            if (folderbrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbMapPath.Text = folderbrowser.SelectedPath.Replace(Application.StartupPath, "");
                if (tbMapPath.Text.Substring(0, 1) == @"\")
                {
                    tbMapPath.Text = tbMapPath.Text.Substring(1, tbMapPath.Text.Length - 1);
                }
            }
        }
    }
}