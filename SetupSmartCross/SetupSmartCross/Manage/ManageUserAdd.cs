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
    public partial class ManageUserAdd : DevExpress.XtraEditors.XtraForm
    {
        public bool IsModify = false;

        public string UserID
        {
            get
            {
                return tbUserID.Text;
            }
            set
            {
                tbUserID.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return tbUserName.Text;
            }
            set
            {
                tbUserName.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        public string GroupName
        {
            get
            {
                return cbGroupName.SelectedValue == null ? "" : cbGroupName.SelectedValue.ToString();

            }
            set
            {
                cbGroupName.SelectedValue = value;
            }
        }

        public string Organization
        {
            get
            {
                return tbOrganization.Text;
            }
            set
            {
                tbOrganization.Text = value;
            }
        }

        public string Class
        {
            get
            {
                return tbClass.Text;
            }
            set
            {
                tbClass.Text = value;
            }
        }

        public string Contact
        {
            get
            {
                return tbContact.Text;
            }
            set
            {
                tbContact.Text = value;
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

        public ManageUserAdd()
        {
            InitializeComponent();
            LoadLocalGroup();
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

        private void ManageUserAdd_Load(object sender, EventArgs e)
        {
            if (IsModify == true)
            {
                this.Text = "기존 사용자 편집";
                tbUserID.ReadOnly = true;
            }
        }

        private void LoadLocalGroup()
        {
            try
            {
                if (cbGroupName.DataSource != null)
                {
                    (cbGroupName.DataSource as DataTable).Clear();
                    (cbGroupName.DataSource as DataTable).Dispose();
                }

                DataTable dt = new DataTable();

                if (MV.DbManager.Fill(MV.SQL.S_MST_USER_GROUP, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 로딩 실패.")));
                    ////MV.InsertDBLog(LogType.Error, string.Format("사용자 그룹 로딩 실패."));
                    return;
                }

                cbGroupName.DataSource = dt;
                cbGroupName.SelectedIndex = 0;

                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자 그룹 로딩완료.")));
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                ////MV.InsertDBLog(LogType.Error, string.Format("사용자 그룹 로딩 실패. - {0}", ex.Message.Replace("'", "")));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserID))
            {
                XtraMessageBox.Show("사용자 ID를 입력해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserID.Select();
                return;
            }

            if (string.IsNullOrEmpty(UserName))
            {
                XtraMessageBox.Show("사용자 이름을 입력해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserName.Select();
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                XtraMessageBox.Show("계정 암호를 입력해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPassword.Select();
                return;
            }

            if (!tbPassword.Text.Equals(tbConfirmPassword.Text))
            {
                XtraMessageBox.Show("암호 확인 값이 일치 하지 않습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbConfirmPassword.Select();
                return;
            }

            if (IsModify == false && IsGetDBSameUser(UserID))
            {
                XtraMessageBox.Show("이미 같은 사용자 ID가 등록되어 있습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbUserID.Select();
                return;
            }

            if (IsModify == true)
            {
                if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_USER, UserID, UserName, Password, GroupName, Organization, Class, Contact, Description, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), IniData.LoginID)) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자정보 수정 실패 - ID: {0}, 이름: {1}, PW: {2}, 그룹명: {3}, 소속: {4}, 직급: {5}, 연락처: {6}, 설명: {7} ", UserID, UserName, Password, GroupName, Organization, Class, Contact, Description)));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 정보 수정 실패\nID: {0}, 이름: {1}, 그룹명: {2}, 소속: {3}, 직급: {4}, 연락처: {5}, 설명: {6} ", UserID, UserName, GroupName, Organization, Class, Contact, Description));
                    XtraMessageBox.Show(string.Format("사용자정보 수정 실패 - UserID: {0}.", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자정보 수정 완료 -ID: {0}, 이름: {1}, PW: {2}, 그룹명: {3}, 소속: {4}, 직급: {5}, 연락처: {6}, 설명: {7} ", UserID, UserName, Password, GroupName, Organization, Class, Contact, Description)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 정보 수정 완료\nID: {0}, 이름: {1}, 그룹명: {2}, 소속: {3}, 직급: {4}, 연락처: {5}, 설명: {6} ", UserID, UserName, GroupName, Organization, Class, Contact, Description));
                    XtraMessageBox.Show(string.Format("사용자정보 수정 완료 - UserID: {0}.", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Select();
                    this.Close();
                }
            }
            else
            {

                if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_USER, UserID, UserName, Password, GroupName, Organization, Class, Contact, Description, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), IniData.LoginID)) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자정보 등록 실패 - ID: {0}, 이름: {1}, PW: {2}, 그룹명: {3}, 소속: {4}, 직급: {5}, 연락처: {6}, 설명: {7} ", UserID, UserName, Password, GroupName, Organization, Class, Contact, Description)));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 사용자 정보 등록 실패\nID: {0}, 이름: {1}, 그룹명: {2}, 소속: {3}, 직급: {4}, 연락처: {5}, 설명: {6} ", UserID, UserName, GroupName, Organization, Class, Contact, Description));
                    XtraMessageBox.Show(string.Format("사용자정보 등록 실패 - UserID: {0}.", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("사용자정보 등록 완료 - ID: {0}, 이름: {1}, PW: {2}, 그룹명: {3}, 소속: {4}, 직급: {5}, 연락처: {6}, 설명: {7} ", UserID, UserName, Password, GroupName, Organization, Class, Contact, Description)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 사용자 정보 등록 완료\nID: {0}, 이름: {1}, 그룹명: {2}, 소속: {3}, 직급: {4}, 연락처: {5}, 설명: {6} ", UserID, UserName, GroupName, Organization, Class, Contact, Description));
                    XtraMessageBox.Show(string.Format("사용자정보 등록 완료 - UserID: {0}.", UserID), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Select();
                    this.Close();
                }
            }
            
        }

        private bool IsGetDBSameUser(string strUserID)
        {
            DataTable dt = new DataTable();

            try
            {
                if (MV.DbManager.Fill(string.Format(MV.SQL.S_MST_USER_USER_ID, strUserID), dt) > 0)
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
    }
}