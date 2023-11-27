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
using SetupSmartCross.DataBase;

namespace SetupSmartCross.Manage
{
    public partial class ManageGroupAdd : DevExpress.XtraEditors.XtraForm
    {
        private bool IsModify = false;
        private string _GroupID = string.Empty;
        public string GroupID 
        {
            set
            {
                _GroupID = value;

                local = MV.LoadData.GetLocalGroupInfo(_GroupID);

                if (local != null)
                {
                    cbLocalType.Text = MV.LocalType.GetName(local.local_type);
                    tbName.Text = local.name;
                }
                IsModify = true;

                this.Text = "현장그룹 편집";
                cbLocalType.ReadOnly = true;
                cbLocalType.Enabled = false;
            }
        }

        private LocalGroupInfo local = null;

        public ManageGroupAdd()
        {
            InitializeComponent();

            cbLocalType.Properties.Items.Clear();
            foreach (CODEINFO item in MV.LocalType)
                cbLocalType.Properties.Items.Add(item.code_name);

            if (cbLocalType.Properties.Items.Count > 0)
                cbLocalType.SelectedIndex = 0;
        }

        #region 로그
        public void MakeLog(string sLog, int bScreen = 3)
        {
            string sMsg;

            sMsg = string.Format("[{0}] {1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, sLog);
            if (MV.LogCtrl != null)
                MV.LogCtrl.AddLog(sMsg, bScreen);
        }
        #endregion  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string localtype = MV.LocalType.GetCode(cbLocalType.Text);

            if (IsModify == false)
            {
                string NewId = MV.LoadData.GetLocalGroupID(localtype);

                if (!string.IsNullOrEmpty(NewId))
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_LOCAL_GROUP, NewId, string.Empty, tbName.Text, 0, localtype)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장그룹 추가 실패 -  ID:{0}, 타입: {1}, 명칭: {2} .", NewId, cbLocalType.Text, tbName.Text)));
                        //MV.InsertDBLog(LogType.Error, string.Format("* 현장그룹 추가 실패\nID:{0}, 타입: {1}, 명칭: {2} .", NewId, cbLocalType.Text, tbName.Text));
                        XtraMessageBox.Show(string.Format("현장그룹 추가 실패 - ID:{0}, 타입: {1}, 명칭: {2}.", NewId, cbLocalType.Text, tbName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장그룹 추가 성공 -  ID:{0}, 타입: {1}, 명칭: {2} .", NewId, cbLocalType.Text, tbName.Text)));
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 현장그룹 추가 성공\nID:{0}, 타입: {1}, 명칭: {2} .", NewId, cbLocalType.Text, tbName.Text));
                        //XtraMessageBox.Show(string.Format("현장그룹 추가 성공 - ID:{0}, 타입: {1}, 명칭: {2}.", NewId, cbLocalType.Text, tbName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    XtraMessageBox.Show(string.Format("현장그룹 추가 신규ID 생성 실패."), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (local != null)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_LOCAL_GROUP, local.id, local.parent_id, tbName.Text, local.level, local.local_type)) < 0)
                    {

                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장그룹 수정 실패 -  ID:{0}, 타입: {1}, 명칭: {2} .", local.id, cbLocalType.Text, tbName.Text)));
                        //MV.InsertDBLog(LogType.Error, string.Format("* 현장그룹 수정 실패\nID:{0}, 타입: {1}, 명칭: {2} .", local.id, cbLocalType.Text, tbName.Text));
                        XtraMessageBox.Show(string.Format("현장그룹 수정 실패 - ID:{0}, 타입: {1}, 명칭: {2}.", local.id, cbLocalType.Text, tbName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장그룹 수정 성공 -  ID:{0}, 타입: {1}, 명칭: {2} .", local.id, cbLocalType.Text, tbName.Text)));
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 현장그룹 수정 성공\nID:{0}, 타입: {1}, 명칭: {2} .", local.id, cbLocalType.Text, tbName.Text));
                        //XtraMessageBox.Show(string.Format("현장그룹 수정 성공 - ID:{0}, 타입: {1}, 명칭: {2}.", local.id, cbLocalType.Text, tbName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } 
            }

            this.Close();

        }

        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == Convert.ToChar(Keys.Enter) )
            {
                btnSave.PerformClick();
            }
        }

        
    }
}