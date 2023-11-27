using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Common;
using SetupSmartCross.DataBase;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraPrinting;

namespace SetupSmartCross.Forms
{
    public partial class LinkTrafficLog : DevExpress.XtraEditors.XtraUserControl
    {

        private bool bExpand = true;
        private Dictionary<string, bool> DicExpanded = new Dictionary<string, bool>();
        private Dictionary<string, bool> DicChecked = new Dictionary<string, bool>();
        private DataTable dtLog = new DataTable();
        private DataTable dtExcel = new DataTable();

        private DateTime _SDateTime = DateTime.MinValue;
        private DateTime _EDateTime = DateTime.MinValue;
        private string _Where= string.Empty;
        private int _SavePercentage = 0;

        private DataTable dtLinkInfo = new DataTable();

        public LinkTrafficLog()
        {
            InitializeComponent();
        }

        private string checkLink()
        {
            string CheckID = string.Empty;
            if (gvLinkInfo.DataRowCount != gvLinkInfo.SelectedRowsCount)
            {
                foreach(int rowHandle in gvLinkInfo.GetSelectedRows())
                {
                    string link_id = gvLinkInfo.GetRowCellValue(rowHandle, "link_id").ToString();

                    if (!string.IsNullOrEmpty(CheckID))
                        CheckID += ", ";
                    CheckID += string.Format("'{0}'", link_id);
                }
            }

            return CheckID;
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
        private void CrossTrafficLog_Load(object sender, EventArgs e)
        {
            searchLink();
            MV.LoadData.LoadLocalDataBegin += LoadData_LoadLocalDataBegin;
            MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;
            MV.LoadData.LoadStatusEnd += LoadData_LoadStatusEnd;

            InitTreeListLocal();
          
            MV.LoadData.AddItem(LoadType.LoadLocalData);

            dtSDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtSTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            dtEDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtETime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            gcTrafficLog.DataSource = dtLog;
            gcLinkInfo.DataSource = dtLinkInfo;

        }
        #endregion

        #region Loading Local

        string FocuseNodeID = string.Empty;
        void LoadData_LoadLocalDataBegin(object sender, EventArgs e)
        {
            try
            {
                if (tlLocal.FocusedNode != null)
                    FocuseNodeID = tlLocal.FocusedNode["ID"].ToString();

                DicExpanded.Clear();
                tlLocal.GetTreeExpanded("ID", tlLocal.Nodes, ref DicExpanded);

                DicChecked.Clear();
                tlLocal.GetTreeChecked("ID", tlLocal.Nodes, ref DicChecked);

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void LoadData_LoadLocalDataEnd(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.SimpleInvoke(this, () =>
                {
                    LoadData load = sender as LoadData;
                    if (load != null)
                    {

                        DataView dv = new DataView(load.dtLocal);
                        dv.RowFilter = "LEVEL <= 1 and LOCAL_TYPE = 0";
                        tlLocal.DataSource = dv;
                        tlLocal.SetTreeExpanded("ID", tlLocal.Nodes, DicExpanded);
                        DicExpanded.Clear();

                        tlLocal.SetTreeChecked("ID", tlLocal.Nodes, DicChecked);
                        DicChecked.Clear();
                        
                        if (string.IsNullOrEmpty(FocuseNodeID))
                        {
                            tlLocal.CheckAll();
                            tlLocal.ExpandAll();
                        }
                        else
                        {
                            tlLocal.FocusedNode = tlLocal.FindNodeByKeyID(FocuseNodeID);
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region Loading Status
        void LoadData_LoadStatusEnd(object sender, EventArgs e)
        {
            try
            {
                Console.WriteLine("LoadData_LoadStatusEnd");
                CommonFunction.SimpleInvoke(this, () =>
                {
                    LoadData load = sender as LoadData;
                    if (load != null)
                    {

                        foreach (DataRow dr in load.dtStatusInfo.Rows)
                        {
                            var node = tlLocal.FindNodeByKeyID(dr["ID"].ToString());
                            if (node != null)
                            {
                                node.SetValue("STATUSINFO", dr["STATUSINFO"].ToString());
                                node.SetValue("CAP_DATE", dr["CAP_DATE"].ToString());
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region 트리 초기화
        private void InitTreeListLocal()
        {
            try
            {
                tlLocal.ShowPopupMenu = true;
                tlLocal.MaxLevel = 1;
                tlLocal.DragNodesMode = DevExpress.XtraTreeList.TreeListDragNodesMode.Standard;
                tlLocal.DrawNodeImageColumName = "STATUSINFO";
                tlLocal.SetDrawNodeLevelInfo(0, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.CrossRoad], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(0, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.CrossRoad], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(1, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.CrossLengend_S], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(1, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.CrossLengend_S], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(2, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.Cctv], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(2, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.Cctv], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(3, ((int)TreeLocalIcon.Off).ToString(), null, Color.Black);
                tlLocal.SetDrawNodeLevelInfo(3, ((int)TreeLocalIcon.On).ToString(), null, Color.Black);

                tlLocal.ShowPopupMenu = true;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region 트리 이벤트
        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender.Equals(tbFindText))
                        tbFindTextEditValueChanged();
                    else
                        btnSearch_Click(btnSearch, new EventArgs());
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void tbFindTextEditValueChanged()
        {
            try
            {
                if (bExpand)
                    tlLocal.ExpandAll();
                else
                    tlLocal.CollapseAll();

                if (!string.IsNullOrEmpty(tbFindText.Text))
                {
                    tlLocal.Selection.Clear();
                    SearchTreeInfo(tlLocal.Nodes, tbFindText.Text);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private bool SearchTreeInfo(TreeListNodes Nodes, string FindeText)
        {
            bool Expanded = false;
            try
            {
                foreach (TreeListNode node in Nodes)
                {
                    node.Expanded = SearchTreeInfo(node.Nodes, FindeText);
                    if (node.Expanded)
                    {
                        Expanded = true;
                    }

                    string Value = chkShowID.Checked ? node.GetValue("ID").ToString() : node.GetValue("NAME").ToString();

                    if (!string.IsNullOrEmpty(Value))
                    {
                        if (Value.Contains(FindeText) == true)
                        {
                            node.Selected = true;
                            Expanded = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return Expanded;
        }

        private void btnTreeExpend_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bExpand)
                {
                    btnTreeExpend.Text = "전체 접기";
                    tlLocal.ExpandAll();
                    bExpand = true;
                }
                else
                {
                    btnTreeExpend.Text = "전체 펼치기";
                    tlLocal.CollapseAll();
                    bExpand = false;
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnTreeChecked_Click(object sender, EventArgs e)
        {
            if (btnTreeChecked.Text == "전체 해제")
            {
                btnTreeChecked.Text = "전체 선택";
                tlLocal.UncheckAll();
            }
            else
            {
                btnTreeChecked.Text = "전체 해제";
                tlLocal.CheckAll();
            }
        }
        #endregion
        
        
        private void dbSearchLink(string CheckID, string SDateTime, string EDateTime)
        {
            
        }

        private bool isDataCheck()
        {
            if (_SDateTime > _EDateTime)
            {
                SplashScreenManager.CloseForm(false);
                XtraMessageBox.Show(this, "종료 날짜를 시작 날짜 이후로 설정해 주세요 .", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            TimeSpan sp = _EDateTime - _SDateTime;

            if (sp.Days > 31)
            {
                SplashScreenManager.CloseForm(false);
                XtraMessageBox.Show(this, "최대 조회가능 기간은 31일 입니다.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            dtLog.Clear();
            SplashScreenManager.ShowForm(this, typeof(ProgressDlg), true, true);

            DateTime.TryParse(string.Format("{0} {1}", dtSDate.Value.ToString("yyyy-MM-dd"), dtSTime.Value.ToString("HH:mm:ss")), out _SDateTime);
            DateTime.TryParse(string.Format("{0} {1}", dtEDate.Value.ToString("yyyy-MM-dd"), dtETime.Value.ToString("HH:mm:ss")), out _EDateTime);
            if (isDataCheck())
            {
                SearchCount();
            }

            SplashScreenManager.CloseForm(false);
        }

        private string GetCheckID()
        {
            string CheckID = string.Empty;
            try
            {
                if (tlLocal.AllNodesCount != tlLocal.GetAllCheckedNodes().Count)
                {
                    foreach (TreeListNode node in tlLocal.GetAllCheckedNodes().Where(p => p.Level >= 1 )) // && p["LOCAL_TYPE"].ToString() == LocalType.Cross
                    {
                        if (!string.IsNullOrEmpty(CheckID))
                            CheckID += ", ";

                        CheckID += string.Format("'{0}'", node["ID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }

            return CheckID;
        }

        #region 검색

        private void searchLink()
        {
            dtLinkInfo.Clear();
            if (MV.DbManager.Fill(MV.SQL.S_TRI_LINK_STATS, dtLinkInfo) < 0)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 정보 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                //MV.InsertDBLog(LogType.Error, string.Format("구간 정보 로딩실패. "));
            }
        }

        private void SearchCount()
        {
            //cross검색시
            string CheckID = string.Empty;
            string sql = string.Empty;
            int RowCount = 0;
            DataTable dataCount = new DataTable();

            if (tbControl.SelectedTabPageIndex == 0)
            {
                try
                {
                    if (tlLocal.GetAllCheckedNodes().Count <= 0)
                    {
                        dtLog.Clear();
                        SplashScreenManager.CloseForm(false);
                        XtraMessageBox.Show(this, "장비를 선택해 주세요.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    CheckID = GetCheckID();

                    if (!string.IsNullOrEmpty(CheckID))
                    {
                        _Where = string.Format("AND (s_cross_id IN ({0}) OR e_cross_id IN ({0})) ", CheckID);
                    }
                    else
                    {
                        _Where = string.Empty;
                    }


                    sql = string.Format(MV.SQL.S_TRI_LINK_LOG_COUNT, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where);

                    if (MV.DbManager.Fill(sql, dataCount) < 0)
                    {
                        MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 TOTAL 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                    }

                }
                catch (Exception ex)
                {
                    SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                    MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                    //MV.InsertDBLog(LogType.Error, string.Format("로그정보 로딩실패. - {0}", ex.Message.Replace("'", "")));
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else if (tbControl.SelectedTabPageIndex == 1)
            {
                if (gvLinkInfo.SelectedRowsCount <= 0)
                {
                    dtLog.Clear();
                    SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show(this, "구간를 선택해 주세요.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                CheckID = checkLink();
                if (!string.IsNullOrEmpty(CheckID))
                {
                    _Where = string.Format("AND ml.link_id IN ({0}) ", CheckID);
                }
                else
                    _Where = string.Empty;
                sql = string.Format(MV.SQL.S_TRI_LINK_LOG_COUNT, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where);
                if (MV.DbManager.Fill(sql, dataCount) < 0)
                {
                    MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                    //MV.InsertDBLog(LogType.Error, string.Format("구간 원시 이력 로딩실패. "));
                }
            }

            if (dataCount.Rows.Count > 0)
            {
                int.TryParse(dataCount.Rows[0]["LINK_LOG_COUNT"].ToString(), out RowCount);
            }
            lbSearchCount.Text = string.Format("총  {0:#,##0} 건", RowCount);
            int PageCounts = (int)Math.Ceiling((double)RowCount / 10000.0);
            cbPageNumber.Properties.Items.Clear();
            cbPageNumber.SelectedIndex = -1;
            for (int i = 1; i <= PageCounts; i++)
            {
                cbPageNumber.Properties.Items.Add(i.ToString());
            }
            cbPageNumber.SelectedIndex = 0;
        }

        private void searchLog(int PageNumber, int PageCount = -1)
        {

            string CheckID = string.Empty;
            string sql = string.Empty;
            if (tbControl.SelectedTabPageIndex == 0)
            {
                try
                {
                    if (PageCount == -1)
                    {
                        dtLog.Clear();
                        sql = string.Format(MV.SQL.S_TRI_LINK_LOG, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where, (PageNumber - 1) * 10000, 10000);
                        if (MV.DbManager.Fill(sql, dtLog) < 0)
                        {
                            MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 TOTAL 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                        }
                    }
                    else
                    {
                        dtExcel.Clear();

                        sql = string.Format(MV.SQL.S_TRI_LINK_LOG, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where, (PageNumber > 0) ? (PageNumber - 1) * 10000 : PageNumber, PageCount * 10000);
                        if (MV.DbManager.Fill(sql, dtExcel) < 0)
                        {
                            XtraMessageBox.Show(this, "error.", MV.DbManager.GetErrorMsg(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 TOTAL 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                        }
                    }

                }
                catch (Exception)
                {
                    XtraMessageBox.Show(this, "error.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if(tbControl.SelectedTabPageIndex == 1)
            {

                if (PageCount == -1)
                {
                    dtLog.Clear();
                    sql = string.Format(MV.SQL.S_TRI_LINK_LOG, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where, (PageNumber - 1) * 10000, 10000);
                    if (MV.DbManager.Fill(sql, dtLog) < 0)
                    {
                        MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 TOTAL 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                    }
                }
                else
                {
                    dtExcel.Clear();

                    sql = string.Format(MV.SQL.S_TRI_LINK_LOG, _SDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _EDateTime.ToString("yyyy-MM-dd HH:mm:ss"), _Where, (PageNumber > 0) ? (PageNumber - 1) * 10000 : PageNumber, PageCount * 10000);
                    if (MV.DbManager.Fill(sql, dtExcel) < 0)
                    {
                        XtraMessageBox.Show(this, "error.", MV.DbManager.GetErrorMsg(), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 원시 이력 TOTAL 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                    }
                }
            }
         

        }
        #endregion



        private void btnExcelSave_Click(object sender, EventArgs e)
        {
            //if (dtLog.Rows.Count == 0)
            //{
            //    MessageBox.Show("저장할 데이터가 없습니다.", "엑셀저장", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            SaveExcelFileOption SaveOption = new SaveExcelFileOption();

            if (SaveOption.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = string.Format("구간 원시 이력_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"));
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    int PageNumber = 1;
                    int.TryParse(cbPageNumber.Text, out PageNumber);

                    //SplashScreenManager.ShowForm(MV.MainCrtl, typeof(ProgressDlg), true, true, false);

                    string SavePageOption = string.Empty;
                    try
                    {

                        if (SaveOption.SavePageSelect == SavePageSelect.AllPage)
                        {
                            searchLog(1, cbPageNumber.Properties.Items.Count);

                            SavePageOption = "전체 페이지 저장";
                        }
                        else if (SaveOption.SavePageSelect == SavePageSelect.SelectPage)
                        {
                            string[] values = SaveOption.SelectValue.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                            SavePageOption = "선택 페이지 저장, Page: " + SaveOption.SelectValue;

                            if (values != null && values.Count() == 2)
                            {
                                int StartPage = 1;
                                int EndPage = 1;
                                int.TryParse(values[0].Trim(), out StartPage);
                                int.TryParse(values[1].Trim(), out EndPage);

                                if (StartPage > EndPage)
                                {
                                    int Temp = StartPage;
                                    StartPage = EndPage;
                                    EndPage = StartPage;
                                }

                                searchLog(StartPage, (EndPage - StartPage) + 1);
                            }

                        }
                        else
                        {
                            searchLog(PageNumber, 1);

                            SavePageOption = "현재 페이지 저장, Page: " + PageNumber.ToString();

                        }

                        gcTrafficLog.DataSource = dtExcel;
                    }
                    catch(Exception ex)
                    {

                    }

                    SplashScreenManager.CloseForm(false);

                    _SavePercentage = 0;
                    XlsxExportOptions options = new XlsxExportOptions(TextExportMode.Value);
                    gcTrafficLog.ExportToXlsx(sfd.FileName, options);

                    int RowCount = dtExcel.Rows.Count;
                    dtExcel.Clear();

                    gcTrafficLog.DataSource = dtLog;

                    if (_SavePercentage == 100)
                    {
                        if (XtraMessageBox.Show(this, "저장이 완료되었습니다.\n저장된 내용을 확인 하시겠습니까?", "엑셀 저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                System.Diagnostics.Process Prc = new System.Diagnostics.Process();
                                Prc.StartInfo.FileName = sfd.FileName;
                                Prc.StartInfo.Verb = "Open";
                                Prc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                                Prc.Start();
                                
                            }
                            catch
                            {
                                XtraMessageBox.Show(this, "일시적으로 파일을 불러오지 못하였습니다. 경로를 확안하여 주시기 바랍니다.", "엑셀 저장", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                    }
                }
            }
        }

        private void cbPageNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            int PageNumber = 1;
            int.TryParse(cbPageNumber.Text, out PageNumber);

            if (cbPageNumber.SelectedIndex <= 0)
                btnPrevPage.Enabled = false;
            else
                btnPrevPage.Enabled = true;

            if (cbPageNumber.SelectedIndex >= cbPageNumber.Properties.Items.Count - 1)
                btnNextPage.Enabled = false;
            else
                btnNextPage.Enabled = true;

            searchLog(PageNumber);
        }

        private void btnPrevPage_Click(object sender, EventArgs e)
        {
            if(cbPageNumber.SelectedIndex > 0)
            {
                cbPageNumber.SelectedIndex = cbPageNumber.SelectedIndex - 1;
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (cbPageNumber.SelectedIndex < cbPageNumber.Properties.Items.Count - 1)
            {
                cbPageNumber.SelectedIndex = cbPageNumber.SelectedIndex + 1;
            }
        }

        private void gvTrafficLog_PrintExportProgress(object sender, ProgressChangedEventArgs e)
        {
            _SavePercentage = e.ProgressPercentage;
        }

        private void chkShowID_CheckedChanged(object sender, EventArgs e)
        {
            TRAFFIC_ID.Visible = chkShowID.Checked;
            TRAFFIC_NAME.Visible = !chkShowID.Checked;
        }

        private void gvTrafficStats_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == gvTrafficStats.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Wheat;
            }  
        }
           
    }
}
