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
    public partial class ManageUserGroup : DevExpress.XtraEditors.XtraForm
    {
        public ManageUserGroup()
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

        private void ManageUserGroup_Load(object sender, EventArgs e)
        {
            LoadUserGroup();
        }

        private void LoadUserGroup()
        {
            try
            {
                DataTable dt = new DataTable();

                if (MV.DbManager.Fill(MV.SQL.S_MST_USER_GROUP, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 정보 로딩실패.")));
                    ////MV.InsertDBLog(LogType.Error, string.Format("사용자 그룹 정보 로딩실패."));
                    return;
                }

                gcUserGroup.DataSource = dt;

                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 정보 로딩완료.")));
                ////MV.InsertDBLog(LogType.ProgramUseInfo, string.Format("사용자 그룹 정보 로딩완료."));
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                ////MV.InsertDBLog(LogType.Error, string.Format("사용자 그룹 정보 로딩실패. - {0}", ex.Message.Replace("'", "")));
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ManageUserGroupAdd ManageUserGroupAdd = new ManageUserGroupAdd();
            if (ManageUserGroupAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadUserGroup();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowManageUserGroupEdit();
        }

        private void gvUserGroup_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (e.Clicks == 2 && e.Button == System.Windows.Forms.MouseButtons.Left)
                ShowManageUserGroupEdit();
        }

        private void ShowManageUserGroupEdit()
        {
            DataRow dr = gvUserGroup.GetFocusedDataRow();

            if (dr == null)
                return;

            string GroupName = dr["NAME"].ToString();

            if (GroupName.ToLower() == "관리자")
            {
                XtraMessageBox.Show("관리자 그룹은 수정 할 수 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ManageUserGroupAdd ManageUserGroupAdd = new ManageUserGroupAdd();
            ManageUserGroupAdd.IsModify = true;
            ManageUserGroupAdd.GroupName = dr["NAME"].ToString();
            ManageUserGroupAdd.Description = dr["DESCRIPTION"].ToString();
            ManageUserGroupAdd.Permission = dr["PERMISSION"].ToString();

            if (ManageUserGroupAdd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadUserGroup();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRow dr = gvUserGroup.GetFocusedDataRow();

            if (dr == null)
                return;

            string GroupName = dr["NAME"].ToString();

            if (GroupName.ToLower() == "관리자")
            {
                XtraMessageBox.Show("관리자 그룹은 삭제 할 수 없습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (XtraMessageBox.Show("선택한 정보를 삭제 하시겠습니까?\n그룹에 등록된 사용자 정보도 함께 삭제 됩니다.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {

                if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_USER_GROUP_USER, GroupName)) >= 0)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_USER_GROUP, GroupName)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 삭제 실패 - 그룹명: {0}", GroupName)));
                        //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 그룹 삭제 실패\n그룹명: {0}", GroupName));
                        XtraMessageBox.Show(string.Format("사용자 그룹 삭제 실패 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 삭제 완료 - 그룹명: {0}", GroupName)));
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 그룹 삭제 완료\n그룹명: {0}", GroupName));
                        XtraMessageBox.Show(string.Format("사용자 그룹 삭제 완료 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LoadUserGroup();
            } 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}