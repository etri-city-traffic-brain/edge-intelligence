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
    public partial class ManageCrossAdd : DevExpress.XtraEditors.XtraForm
    {
        #region 변수
        private bool IsModify = false;
        private string _GroupID = string.Empty;
        public string GroupID
        {
            set
            {
                _GroupID = value;
                SetInfo();
            }
        }

        private string _CrossID = string.Empty;
        public string CrossID
        {
            get
            {
                return _CrossID;
            }

            set
            {
                _CrossID = value;
                IsModify = true;
                SetInfo();
            }
        }

        private double _OldX = double.NaN;
        private double _OldY = double.NaN;

        private DataTable dtCcam = new DataTable();
        private DataTable dtGroup = new DataTable();
        #endregion

        public ManageCrossAdd()
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
        #region 시작
        private void ManageCrossAdd_Load(object sender, EventArgs e)
        {
            InitControl();
        }
        #endregion

        public void Init()
        {
            IsModify = false;
            _GroupID = string.Empty;
            _CrossID = string.Empty;
            tbCrossName.Text = string.Empty;
            tbX.Text = string.Empty;
            tbY.Text = string.Empty;
            tbZ.Text = string.Empty;
            dtCcam.Clear();
            dtGroup.Clear();
            InitControl();
        }

        #region 컨트롤 초기화
        private void InitControl()
        {
            SetGroup();
            SetCrossType();
            SetCcamAll();
            SetCcam();
            SetInfo();
        }
        #endregion
        #region 정보 입력
        private void SetInfo()
        {

            var local = MV.LoadData.GetLocalGroupInfo(_GroupID);

            if (local != null)
            {
                cbGroup.Text = local.name;
            }

            tbCrossID.Text = _CrossID;

            var cross = MV.LoadData.GetCrossInfo(_CrossID);

            if (cross != null)
            {
                tbCrossName.Text = cross.name;
                tbX.Text = cross.x.ToString();
                tbY.Text = cross.y.ToString();
                tbZ.Text = cross.zoom_level.ToString();

                _OldX = cross.x;
                _OldY = cross.y;

                cbCrossType.Text = MV.CrossType.GetName(cross.cross_type);
            }
        }
        #endregion
        #region 그룹정보 입력
        private void SetGroup()
        {
            dtGroup.Clear();
            string sql = string.Format(MV.SQL.S_MST_LOCAL_GROUP_LEVEL0, LocalType.Cross);
            if (MV.DbManager.Fill(sql, dtGroup) > 0)
            {
                foreach (DataRow dr in dtGroup.Rows)
                {
                    cbGroup.Properties.Items.Add(dr["NAME"].ToString());
                }

                cbGroup.SelectedIndex = 0;
            }
        }
        #endregion
        #region 교차로 타입 입력
        private void SetCrossType()
        {
            cbCrossType.Properties.Items.Clear();
            foreach (CODEINFO item in MV.CrossType)
                cbCrossType.Properties.Items.Add(item.code_name);

            cbCrossType.SelectedIndex = 0;
        }
        #endregion
        #region 전체 카메라 정보 입력
        private void SetCcamAll()
        {
            DataTable dt = new DataTable();
            string sql = string.Format(MV.SQL.S_MST_CCAM, "where IFNULL(A.parent_id, '') = '' ");
            if (MV.DbManager.Fill(sql, dt) > 0)
            {
                gcCcamAll.DataSource = dt;
            }
        }
        #endregion
        #region 등록 카메라 정보 입력
        private void SetCcam()
        {
            string where = string.Format("where cross_id = '{0}' and ifnull(cross_id, '') <> '' ", _CrossID);

            string sql = string.Format(MV.SQL.S_MST_CCAM, where);

            dtCcam.Clear();
            MV.DbManager.Fill(sql, dtCcam);
            gcCcam.DataSource = dtCcam;
        }
        #endregion
        #region 전체카메라 로우 클릭
        private void gvCcamAll_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2)
                {
                    CcamUp();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            CcamUp();
        }


        private void CcamUp()
        {
            try
            {
                foreach (int handle in gvCcamAll.GetSelectedRows())
                {
                    if (!gvCcamAll.IsFilterRow(handle))
                    {
                        string CAM_ID = gvCcamAll.GetRowCellValue(handle, "CAM_ID").ToString();
                        foreach (DataRow dr in dtCcam.Rows)
                        {
                            if (dr["CAM_ID"].ToString() == CAM_ID)
                                return;
                        }

                        DataRow drNew = dtCcam.NewRow();
                        drNew["CAM_ID"] = gvCcamAll.GetRowCellValue(handle, "CAM_ID");
                        drNew["NAME"] = gvCcamAll.GetRowCellValue(handle, "NAME");
                        drNew["CROSS_ID"] = gvCcamAll.GetRowCellValue(handle, "CROSS_ID");
                        drNew["DIRECTION"] = gvCcamAll.GetRowCellValue(handle, "DIRECTION");
                        drNew["CROSS_NAME"] = gvCcamAll.GetRowCellValue(handle, "CROSS_NAME");
                        drNew["RIGHT_USE"] = gvCcamAll.GetRowCellValue(handle, "RIGHT_USE");

                        dtCcam.Rows.Add(drNew);
                        dtCcam.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("실패!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        #endregion
        #region 등록 카메라 로우 클릭
        private void gvCcam_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.Clicks == 2)
                {
                    CcamDown();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            CcamDown();
        }

        private void CcamDown()
        {
            gvCcam.DeleteSelectedRows();
            dtCcam.AcceptChanges();
        }
        #endregion
        #region 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = string.Empty;
            string name = string.Empty;
            double x = 0;
            double y = 0;
            double z = 0;

            try
            {
                _GroupID = dtGroup.Rows[cbGroup.SelectedIndex]["ID"].ToString();

                if (string.IsNullOrEmpty(tbCrossID.Text))
                {
                    XtraMessageBox.Show("ID를 입력해 주세요!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbCrossID.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(_CrossID) || _CrossID != tbCrossID.Text)
                {
                    if (MV.LoadData.GetCrossInfo(tbCrossID.Text) != null)
                    {
                        XtraMessageBox.Show("이미 존재하는 ID 입니다!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tbCrossID.Focus();
                        return;
                    }

                    DataTable dt = new DataTable();
                    if (MV.DbManager.Fill(string.Format(MV.SQL.S_CROSS_CHECK_ID, tbCrossID.Text), dt) > 0)
                    {
                        XtraMessageBox.Show(this, "'중복된 ID는 사용 할 수 없습니다. ", "교차로ID 변경", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbCrossID.Focus();
                        return;
                    }
                }

                if (string.IsNullOrEmpty(tbCrossName.Text))
                {
                    XtraMessageBox.Show("명칭을 입력해 주세요!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbCrossName.Focus();
                    return;
                }

                double.TryParse(tbX.Text, out x);
                double.TryParse(tbY.Text, out y);
                double.TryParse(tbZ.Text, out z);

                if (z == 0)
                    z = 17;

                if (IsModify == false)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_CROSS, tbCrossID.Text, tbCrossName.Text, MV.CrossType.GetCode(cbCrossType.Text), x, y, z, _GroupID)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 추가 실패 -  ID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text)));
                        //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 추가 실패\nID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text));
                        XtraMessageBox.Show(string.Format("교차로 추가 실패 - ID:{0}, 타입: {1}, 명칭: {2}.", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 추가 성공 -  ID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text)));
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 추가 성공\nID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text));
                        //XtraMessageBox.Show(string.Format("교차로 추가 성공 - ID:{0}, 타입: {1}, 명칭: {2}.", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(_CrossID))
                    {
                        if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_CROSS, _CrossID, tbCrossID.Text, tbCrossName.Text, MV.CrossType.GetCode(cbCrossType.Text), x, y, z, _GroupID)) < 0)
                        {

                            MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 수정 실패 -  ID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text)));
                            //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 수정 실패\nID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text));
                            XtraMessageBox.Show(string.Format("교차로 수정 실패 - ID:{0}, 타입: {1}, 명칭: {2}.", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 수정 성공 -  ID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text)));
                            //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 수정 성공\nID:{0}, 타입: {1}, 명칭: {2} .", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text));
                            //XtraMessageBox.Show(string.Format("교차로 수정 성공 - ID:{0}, 타입: {1}, 명칭: {2}.", tbCrossID.Text, cbCrossType.Text, tbCrossName.Text), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                string camid = string.Empty;

                foreach (DataRow dr in dtCcam.Rows)
                {
                    if (camid != string.Empty)
                        camid += ", ";

                    if (name != string.Empty)
                        name += ", ";

                    camid += string.Format("'{0}'", dr["CAM_ID"].ToString());
                    name += string.Format("{0}", dr["name"].ToString());
                }

                if (!string.IsNullOrEmpty(camid))
                {
                    sql = string.Format(MV.SQL.U_MST_CCAM_ACCESS_CHANGE_NULL, _CrossID, camid); // 신규등록 카메라 좌표 초기화

                    if (MV.DbManager.Excute(sql) < 0)
                    {
                        //MV.InsertDBLog(LogType.Error, string.Format("* 매칭 교차로 변경으로 인한 좌표 초기화 실패.\n교차로ID: {0}, 카메라ID: {1} ", _CrossID, camid));
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("매칭 교차로 변경으로 인한 좌표 초기화 실패. : {0}", MV.DbManager.GetErrorMsg())));
                        XtraMessageBox.Show("실패!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if ((_OldX != double.NaN && _OldX != x) || (_OldY != double.NaN && _OldY != y))
                {
                    sql = string.Format(MV.SQL.U_MST_CCAM_ACCESS_XY_NULL, camid);

                    if (MV.DbManager.Excute(sql) < 0)
                    {
                        //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 좌표 변경으로 인한 좌표 초기화 실패.\n교차로ID: {0}, 카메라ID: {1} ", _CrossID, camid));
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 좌표 변경으로 인한 좌표 초기화 실패. : {0}", MV.DbManager.GetErrorMsg())));
                        XtraMessageBox.Show("실패!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                sql = string.Format(MV.SQL.U_MST_CCAM_CROSS_ID_NULL, _CrossID);

                if (MV.DbManager.Excute(sql) >= 0)
                {
                    if (!string.IsNullOrEmpty(camid))
                    {
                        sql = string.Format(MV.SQL.U_MST_CCAM_CROSS_ID, camid, tbCrossID.Text);
                        MV.DbManager.Excute(sql);
                    }

                    XtraMessageBox.Show("성공!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MV.InsertDBLog((int)LogType.Nomal, string.Format("* 교차로 설정 저장 완료\n명칭: {0}, 경도: {1}, 위도: {2}, Zoom: {3}\n카메라: {4} ", tbCrossName.Text, x, y, z, name));

                    _CrossID = tbCrossID.Text;
                    IsModify = true;

                    SetCcamAll();
                    SetCcam();
                    SetInfo();

                    this.Close();
                }
                else
                {
                    //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 설정 저장 교차로ID 초기화 실패\n현장명: {0}, 경도: {1}, 위도: {2}, Zoom: {3}, 카메라: {4} ", tbCrossName.Text, x, y, z, name));
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 설정 저장 교차로ID 초기화 실패. : {0}", MV.DbManager.GetErrorMsg())));
                    XtraMessageBox.Show("실패!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                sql = string.Format(MV.SQL.U_MST_CCAM_ACCESS_NULL);
                MV.DbManager.Excute(sql);
            }
            catch (Exception ex)
            {
                //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 설정 저장 실패\n현장명: {0}, 경도: {1}, 위도: {2}, Zoom: {3}, 카메라: {4} ", tbCrossName.Text, x, y, z, name));

                XtraMessageBox.Show("실패!!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}