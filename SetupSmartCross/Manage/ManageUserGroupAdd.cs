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
using SetupSmartCross.DataBase;

namespace SetupSmartCross.Manage
{
    public partial class ManageUserGroupAdd : DevExpress.XtraEditors.XtraForm
    {

        public bool IsModify = false;

        public string GroupName
        {
            get
            {
                return tbGroupName.Text;
            }
            set
            {
                tbGroupName.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return tbDescription.Text;
            }
            set
            {
                tbDescription.Text = value;
            }
        }

        public string Permission
        {
            get
            {
                int nPm = 0;
                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in cklbPermission.CheckedItems)
                {
                    int v = int.Parse(item.Value.ToString());
                    nPm |= (0x01 << v);
                }
                return nPm.ToString();
            }
            set
            {
                int nPm = int.Parse(value);

                foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in cklbPermission.Items)
                {
                    int v = int.Parse(item.Value.ToString());
                    item.CheckState = (nPm & (0x01 << v)) > 0 ? CheckState.Checked : CheckState.Unchecked;
                }
            }
        }

        public ManageUserGroupAdd()
        {
            InitializeComponent();
            LoadUserGroupPermission();
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

        private void ManageUserGroupAdd_Load(object sender, EventArgs e)
        {
            if (IsModify == true)
            {
                this.Text = "사용자 그룹 편집";
                tbGroupName.ReadOnly = true;
            }
            else
            {
                ckbAllPermission.Checked = true;
            }
        }

        private void LoadUserGroupPermission()
        {
            try
            {
                cklbPermission.Items.Clear();
                foreach (CODEINFO code in MV.Permission)
                {
                    DevExpress.XtraEditors.Controls.CheckedListBoxItem item = new DevExpress.XtraEditors.Controls.CheckedListBoxItem(code.code_id, code.code_name);

                    cklbPermission.Items.Add(item);
                }

                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 권한 로딩완료.")));
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                ////MV.InsertDBLog(LogType.Error, string.Format("사용자 그룹 권한 로딩 실패. - {0}", ex.Message.Replace("'", "")));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GroupName))
            {
                XtraMessageBox.Show("그룹이름을 입력해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbGroupName.Select();
                return;
            }

            if (string.IsNullOrEmpty(Description))
            {
                XtraMessageBox.Show("설명을 입력해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDescription.Select();
                return;
            }

            if (IsModify == false && IsGetDBSameGroupName(GroupName))
            {
                XtraMessageBox.Show("이미 같은 그룹이름이 등록되어 있습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbGroupName.Select();
                return;
            }

            if (IsModify == true)
            {
                if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_USER_GROUP, GroupName, Description, Permission)) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 수정 실패 - 그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission)));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 그룹 수정 실패\n그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission));
                    XtraMessageBox.Show(string.Format("사용자 그룹 수정 실패 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 수정 완료 - 그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 그룹 수정 완료\n그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission));
                    XtraMessageBox.Show(string.Format("사용자 그룹 수정 완료 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Select();
                    this.Close();
                }
            }
            else
            {

                if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_USER_GROUP, GroupName, Description, Permission)) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 등록 실패 - 그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission)));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 그룹 등록 실패\n그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission));
                    XtraMessageBox.Show(string.Format("사용자 그룹 등록 실패 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 등록 완료 - 그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 그룹 등록 완료\n그룹명: {0}, 설명: {1}, 권한: {2}", GroupName, Description, Permission));
                    XtraMessageBox.Show(string.Format("사용자 그룹 등록 완료 - 그룹명: {0}", GroupName), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Select();
                    this.Close();
                }
            }
        }

        private bool IsGetDBSameGroupName(string strGroupName)
        {
            DataTable dt = new DataTable();

            try
            {
                if (MV.DbManager.Fill(string.Format(MV.SQL.S_MST_USER_GROUP_NAME, strGroupName), dt) > 0)
                {
                    if (dt.Rows.Count > 0)
                        return true;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                dt.Clear();
                dt.Dispose();
            }

            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ckbAllPermission_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAllPermission.Checked == true)
            {
                cklbPermission.CheckAll();
            }
            else
            {
                cklbPermission.UnCheckAll();
            }
        }

        private void cklbPermission_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            ckbAllPermission.CheckedChanged -= ckbAllPermission_CheckedChanged;
            if (cklbPermission.CheckedItemsCount == cklbPermission.ItemCount)
            {
                ckbAllPermission.CheckState = CheckState.Checked;
            }
            else
            {
                ckbAllPermission.CheckState = CheckState.Unchecked;
            }
            ckbAllPermission.CheckedChanged += ckbAllPermission_CheckedChanged;
        }
    }
}