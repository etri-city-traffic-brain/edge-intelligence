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
using Common;

namespace SetupSmartCross.Manage
{
    public partial class ManageUser : DevExpress.XtraEditors.XtraForm
    {
        public ManageUser()
        {
            InitializeComponent();
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

        private void ManageUser_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            try
            {
                if(gcUser.DataSource != null)
                {
                    (gcUser.DataSource as DataTable).Clear();
                    (gcUser.DataSource as DataTable).Dispose();
                }

                DataTable dt = new DataTable();

                if (MV.DbManager.Fill(MV.SQL.S_MST_USER, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 정보 로딩실패.")));
                    ////MV.InsertDBLog(LogType.Error, string.Format("사용자 정보 로딩실패."));
                    return;
                }

                gcUser.DataSource = dt;

                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 정보 로딩완료.")));
                ////MV.InsertDBLog(LogType.ProgramUseInfo, string.Format("사용자 정보 로딩완료."));
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                ////MV.InsertDBLog(LogType.Error, string.Format("사용자 정보 로딩실패. - {0}", ex.Message.Replace("'", "")));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManageUserAdd ManageUserAdd = new ManageUserAdd();
            if (ManageUserAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadUser();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowManageUserEdit();
        }

        private void gvUser_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == System.Windows.Forms.MouseButtons.Left)
                ShowManageUserEdit();
        }

        private void ShowManageUserEdit()
        {
            DataRow dr = gvUser.GetFocusedDataRow();

            if (dr == null)
                return;

            string UserID = dr["USER_ID"].ToString();

            if (UserID.ToLower() == "admin")
            {
                XtraMessageBox.Show("admin 계정은 수정 할 수 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ManageUserAdd ManageUserAdd = new ManageUserAdd();
            ManageUserAdd.IsModify = true;
            ManageUserAdd.UserID = dr["USER_ID"].ToString();
            ManageUserAdd.UserName = dr["NAME"].ToString();
            ManageUserAdd.Password = dr["PASSWORD"].ToString();
            ManageUserAdd.GroupName = dr["GROUP_NAME"].ToString();
            ManageUserAdd.Organization = dr["ORGANIZATION"].ToString();
            ManageUserAdd.Class = dr["CLASS"].ToString();
            ManageUserAdd.Contact = dr["CONTACT"].ToString();
            ManageUserAdd.Description = dr["DESCRIPTION"].ToString();

            if (ManageUserAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadUser();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = gvUser.GetFocusedDataRow();

            if (dr == null)
                return;

            string UserID = dr["USER_ID"].ToString();

            if (UserID.ToLower() == "admin")
            {
                XtraMessageBox.Show("admin 계정은 삭제 할 수 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("선택한 정보를 삭제 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_USER, UserID)) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 삭제 실패 - ID: {0}", UserID)));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 삭제 실패\nID: {0}", UserID));
                    XtraMessageBox.Show(string.Format("사용자 삭제 실패 - ID: {0}", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 삭제 완료 - ID: {0}", UserID)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 삭제 완료\nID: {0}", UserID));
                    XtraMessageBox.Show(string.Format("사용자 삭제 완료 - ID: {0}", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadUser();
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}