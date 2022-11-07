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
using DevExpress.XtraEditors.Controls;
using SetupSmartCross.DataBase;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using Common;
using System.IO;
using DevExpress.XtraSplashScreen;

namespace SetupSmartCross.Manage
{
    public partial class ManageCrossCamera : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtCcam = new DataTable();
        private bool bModify = false;
        private int NewCount = 0;
        public ManageCrossCamera()
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

        private void ManageCrossCameraTree_Load(object sender, EventArgs e)
        {
            InitControl();
            LoadData();
        }

        private void ManageCrossCameraTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose.Focus();

            tlCcam.EndCurrentEdit();

            if (dtCcam.GetChanges() != null && dtCcam.GetChanges().Rows.Count > 0)
            {
                if (XtraMessageBox.Show("수정 내용이 있습니다.\n저장 하시겠습니까?", "교차로 카메라", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!CheckCamID())
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (!CheckCamName())
                    {
                        e.Cancel = true;
                        return;
                    }

                    if (Save())
                    {
                        XtraMessageBox.Show(this, string.Format("카메라 저장 성공."), "교차로 카메라 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (bModify)
                DialogResult = System.Windows.Forms.DialogResult.OK;
            else
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        
        private void InitControl()
        {
            rpichkcbDirection.Items.Clear();
            foreach (CODEINFO item in MV.CrossDirection)
            {
                rpichkcbDirection.Items.Add(new CheckedListBoxItem(item.code_name, false));
            }

            rpicbDirection.Items.Clear();
            foreach (CODEINFO item in MV.CrossDirection)
            {
                rpicbDirection.Items.Add(new ComboBoxItem(item.code_name));
            }

            tlCcam.DataSource = dtCcam;
        }

        private void LoadData()
        {
            dtCcam.Clear();
            try
            {
                string sql = string.Format(MV.SQL.S_MST_CCAM, "");
                if (MV.DbManager.Fill(sql, dtCcam) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 로딩 실패.")));
                    return;
                }

                dtCcam.Columns["CAM_ID"].Unique = true;
                dtCcam.Columns["CAM_ID"].AllowDBNull = false;
                dtCcam.Columns["CAM_ID"].MaxLength = 10;

                dtCcam.AcceptChanges();
            }
            catch(Exception ex)
            {

            }

            NewCount = 0;
        }

        private void rpichkRightUse_CheckedChanged(object sender, EventArgs e)
        {
            TreeListNode SelectNode = tlCcam.FocusedNode;
            
            if (SelectNode == null)
                return;

            rpichkRightUse.BeginUpdate();

            if (SelectNode.Level == 0 && SelectNode.Nodes != null)
            {
                if (SelectNode.Nodes.Count == 0)
                {
                    DataRow dr = dtCcam.NewRow();
                    dr["CAM_ID_OLD"] = string.Empty;
                    dr["CAM_ID"] = string.Format("NEW{0}", ++NewCount);
                    dr["PARENT_ID"] = SelectNode["CAM_ID"];
                    dr["NAME"] = SelectNode["NAME"];
                    dr["DIRECTION"] = SelectNode["DIRECTION"];
                    dr["DIRECTION_ID"] = string.Empty;
                    dr["IP"] = SelectNode["IP"];
                    dr["ID"] = SelectNode["ID"];
                    dr["PW"] = SelectNode["PW"];
                    dr["RTSP_URL"] = SelectNode["RTSP_URL"];
                    dr["RTSP_PORT"] = SelectNode["RTSP_PORT"];
                    dr["HTTP_PORT"] = SelectNode["HTTP_PORT"];
                    dr["CROSS_NAME"] = string.Empty;
                    dr["CROSS_ID"] = string.Empty;
                    dr["RIGHT_USE"] = SelectNode["RIGHT_USE"] = "1";
                    SelectNode["RIGHT_USE"] = dr["RIGHT_USE"];
                    tlCcam.AppendNode(dr.ItemArray, SelectNode);
                    SelectNode.Expanded = true;
                }
                else 
                {
                    SelectNode["RIGHT_USE"] = "0";
                    SelectNode.Nodes.RemoveAt(0);
                }

            }
            else if (SelectNode.ParentNode != null)
            {
                SelectNode.ParentNode["RIGHT_USE"] = "0";
                tlCcam.DeleteSelectedNodes();
            }

            tlCcam.EndCurrentEdit();
        }

        private void tlCcam_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            if (e.Node.Level == 0)
            {
                e.Appearance.Font = new Font("맑은 고딕", 9, FontStyle.Bold);
            }
            else if (e.Node.Level == 1 && tlCcam.FocusedNode != e.Node && e.Node.Selected == false)
            {
                e.Appearance.BackColor = Color.White;
            }

            DataRowView dr = tlCcam.GetDataRecordByNode(e.Node) as DataRowView;
            if(dr != null)
            {
                if (dr.Row.RowState != DataRowState.Unchanged)
                    e.Appearance.ForeColor = Color.Red;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = dtCcam.NewRow();
            dr["CAM_ID"] = string.Format("NEW{0}", ++NewCount);
            
            TreeListNode SelectNode = tlCcam.FocusedNode;

            try
            {
                if (SelectNode != null)
                {
                    dr["CAM_ID_OLD"] = string.Empty;
                    dr["PARENT_ID"] = string.Empty;
                    dr["NAME"] = string.Empty;
                    dr["DIRECTION"] = string.Empty;
                    dr["DIRECTION_ID"] = string.Empty;
                    dr["IP"] = SelectNode["IP"];
                    dr["ID"] = SelectNode["ID"];
                    dr["PW"] = SelectNode["PW"];
                    dr["RTSP_URL"] = SelectNode["RTSP_URL"];
                    dr["RTSP_PORT"] = SelectNode["RTSP_PORT"];
                    dr["HTTP_PORT"] = SelectNode["HTTP_PORT"];
                    dr["CROSS_NAME"] = string.Empty;
                    dr["CROSS_ID"] = string.Empty;
                    dr["RIGHT_USE"] = "0";
                }

                dtCcam.Rows.Add(dr);
            }
            catch(Exception ex)
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (XtraMessageBox.Show("선택된 카메라를 삭제 하시겠습니까?", "교차로 카메라 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                tlCcam.DeleteSelectedNodes();
            }           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();

            if (!CheckCamID())
                return;

            if (!CheckCamName())
                return;

            tlCcam.EndCurrentEdit();

            if (XtraMessageBox.Show("현재 설정을 저장 하시겠습니까?", "교차로 카메라 등록", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (Save())
                {
                    LoadData();
                    XtraMessageBox.Show(this, string.Format("카메라 저장 성공."), "교차로 카메라 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private bool Save()
        {
            bool result = true;

            if (dtCcam.GetChanges() == null)
                return result;

            bModify = true;

            foreach (DataRow dr in dtCcam.GetChanges().Rows)
            {
                if (dr.RowState == DataRowState.Unchanged || dr.RowState == DataRowState.Detached)
                    continue;

                string CAM_ID_OLD = dr.RowState == DataRowState.Deleted ? dr["CAM_ID_OLD", DataRowVersion.Original].ToString() : dr["CAM_ID_OLD"].ToString();

                if(dr.RowState == DataRowState.Deleted)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_CCAM_ACCESS_CAM_ID, CAM_ID_OLD)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 삭제 실패 - 카메라ID: {0}", CAM_ID_OLD)));
                        XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID_OLD, MV.DbManager.GetErrorMsg()), "교차로 카메라 삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 카메라 삭제\n카메라ID: {0}", CAM_ID_OLD));

                    continue;
                }

                if(string.IsNullOrEmpty(dr["CAM_ID"].ToString()))
                    continue;

                string CAM_ID = dr["CAM_ID"].ToString();
                string PARENT_ID = dr["PARENT_ID"].ToString();
                string NAME = dr["NAME"].ToString();
                string DIRECTION = dr["DIRECTION"].ToString();
                string DIRECTION_ID = dr["DIRECTION_ID"].ToString();
                string IP = dr["IP"].ToString();
                string ID = dr["ID"].ToString();
                string PW = dr["PW"].ToString();
                string RTSP_URL = dr["RTSP_URL"].ToString();
                string RTSP_PORT = string.IsNullOrEmpty(dr["RTSP_PORT"].ToString()) == true ? "0" : dr["RTSP_PORT"].ToString();
                string HTTP_PORT = string.IsNullOrEmpty(dr["HTTP_PORT"].ToString()) == true ? "0" : dr["HTTP_PORT"].ToString();
                string RIGHT_USE = string.IsNullOrEmpty(dr["RIGHT_USE"].ToString()) == true ? "0" : dr["RIGHT_USE"].ToString();
                string CROSS_ID = dr["CROSS_ID"].ToString();

                List<string> Listdirection = new List<string>();
                Listdirection.AddRange(DIRECTION.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries));

                List<string> ListDirectionOld = new List<string>();
                ListDirectionOld.AddRange(DIRECTION_ID.Split(new string[] { ", ", "," }, StringSplitOptions.RemoveEmptyEntries));

                if (dr.RowState == DataRowState.Added)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_CCAM, CAM_ID, PARENT_ID, NAME, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 등록 실패 - 카메라ID: {0}, 명칭: {1}, 방향: {2}, IP: {3}, ID: {4}, PW: {5}, RTSP Url: {6} RTSP Port: {7}, HTTP Port: {8}, 우회전여부: {9}, 교차로ID: {10}", CAM_ID, NAME, DIRECTION, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID)));
                        XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 등록 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                    //else
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 카메라 추가\n카메라ID: {0}\n명칭: {1}, 방향: {2}\nIP: {3}, ID: {4}, RTSP Url: {5} RTSP Port: {6}, HTTP Port: {7}\n우회전여부: {8}\n교차로ID: {9}", CAM_ID, NAME, DIRECTION, IP, ID, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID));
                }
                else if (dr.RowState == DataRowState.Modified)
                {
                    if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_CCAM, CAM_ID_OLD, CAM_ID, PARENT_ID, NAME, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID)) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 수정 실패 - 카메라ID: {0}, 명칭: {1}, 방향: {2}, IP: {3}, ID: {4}, PW: {5}, RTSP Url: {6} RTSP Port: {7}, HTTP Port: {8}, 우회전여부: {9}, 교차로ID: {10}", CAM_ID, NAME, DIRECTION, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID)));
                        XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 수정 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        result = false;
                    }
                    //else
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 카메라 수정\n이전 카메라ID: {0}, 카메라ID: {1}\n명칭: {2}, 방향: {3}\nIP: {4}, ID: {5}, RTSP Url: {6} RTSP Port: {7}, HTTP Port: {8}\n우회전여부: {9}\n교차로ID: {10}", CAM_ID_OLD, CAM_ID, NAME, DIRECTION, IP, ID, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID));
                }

                if (result)
                {
                    if (Listdirection.Count() <= 0) // 선택된 방향이 없으면 전체삭제
                    {
                        if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_CCAM_ACCESS, CAM_ID_OLD)) < 0)
                        {
                            MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 접근로 전체 삭제 실패 - 카메라ID: {0}", CAM_ID)));
                            XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 접근로 전체 삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            result = false;
                        }
                    }
                    else
                    {
                        foreach (string dir in Listdirection)
                        {
                            string dircode = MV.CrossDirection.GetCode(dir); // 선택된 방향 코드

                            if (string.IsNullOrEmpty(dircode))
                                continue;

                            if (ListDirectionOld != null && ListDirectionOld.Where(p => p == dircode).Count() > 0) // 이전에 등록된 방향 정보가 있으면 업데이트
                            {
                                if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_CCAM_ACCESS, CAM_ID_OLD, dircode, CAM_ID)) < 0)
                                {
                                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 접근로 수정 실패 - 카메라ID: {0}, 방향: {1}", CAM_ID, dir)));
                                    XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 접근로 수정 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    result = false;
                                }

                                ListDirectionOld.Remove(dircode);
                            }
                            else
                            {
                                if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_CCAM_ACCESS, CAM_ID, dircode)) < 0)
                                {
                                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 접근로 등록 실패 - 카메라ID: {0}, 방향: {1}", CAM_ID, dir)));
                                    XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 접근로 등록 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    result = false;
                                }
                            }
                        }

                        foreach (string dir in ListDirectionOld)
                        {
                            if (string.IsNullOrEmpty(dir))
                                continue;

                            if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_CCAM_ACCESS_DIRECTION, CAM_ID_OLD, dir)) < 0)
                            {
                                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 접근로 삭제 실패 - 카메라ID: {0}, 방향: {1}", CAM_ID, dir)));
                                XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, MV.DbManager.GetErrorMsg()), "교차로 카메라 접근로 삭제 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                result = false;
                            }
                        }
                    }
                }
            }

            return result;
        }

        private bool CheckCamID()
        {
            DataTable dt = new DataTable();
            foreach (DataRow dr in dtCcam.Rows)
            {
                if (dr.RowState == DataRowState.Deleted || dr.RowState == DataRowState.Detached)
                    continue;

                string CAM_ID = dr["CAM_ID"].ToString();

                if(CAM_ID.Contains("NEW"))
                {
                    XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, "'NEW'가 포함된 ID는 사용 할 수 없습니다. "), "카메라ID 변경", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false ;
                }

                dt.Clear();
                if (MV.DbManager.Fill(string.Format(MV.SQL.S_CAM_CHECK_ID, CAM_ID), dt) > 0)
                {
                    XtraMessageBox.Show(this, string.Format("카메라ID: {0} - {1}", CAM_ID, "'중복된 ID는 사용 할 수 없습니다. "), "카메라ID 변경", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private bool CheckCamName()
        {
            try
            {
                dtCcam.Columns["NAME"].AllowDBNull = false;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(this, string.Format("명칭이 빈 값이 있습니다.\n수정해 주세요."), "교차로 카메라 등록", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                dtCcam.Columns["NAME"].AllowDBNull = true;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}