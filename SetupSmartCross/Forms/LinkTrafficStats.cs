using Common;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTreeList.Nodes;
using SetupSmartCross.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace SetupSmartCross.Forms
{

    public partial class LinkTrafficeStats : DevExpress.XtraEditors.XtraUserControl
    {
        private enum SearchInterval
        {
            FIVE,
            FIFTEEN,
            HOUR,
            DAY,
            MONTH
        }

        private bool bExpand = true;
        private Dictionary<string, bool> DicExpanded = new Dictionary<string, bool>();
        private Dictionary<string, bool> DicChecked = new Dictionary<string, bool>();
        private Color color;
        private SearchInterval searchInterval = SearchInterval.FIVE;


        private DataTable dtLog = new DataTable();
        private DataTable dtLinkInfo = new DataTable();

        private string _SDateTime = string.Empty;
        private string _EDateTime = string.Empty;
        private string _FocusedDataTime = string.Empty;
        private List<int> _DataIndex = new List<int>();

        public LinkTrafficeStats()
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
        private void CrossTrafficStats_Load(object sender, EventArgs e)
        {
            searchLink();
            MV.LoadData.LoadLocalDataBegin += LoadData_LoadLocalDataBegin;
            MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;
            InitTreeListLocal();

            MV.LoadData.AddItem(LoadType.LoadLocalData);

            dtSDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            dtSTime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            dtEDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            dtETime.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            gcTrafficStats.DataSource = dtLog;

            gcLinkInfo.DataSource = dtLinkInfo;

            color = Color.FromArgb(250, 237, 182);

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


        private void gvTrafficStats_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int RowHandle = gvTrafficStats.FocusedRowHandle;

            if (gvTrafficStats.IsFilterRow(e.RowHandle))
                return;

            if (_DataIndex.FindIndex(p => p == e.RowHandle) >= 0)
            {
                e.Appearance.ForeColor = Color.Blue;
            }
            else
            {
                e.Appearance.ForeColor = Color.Black;
            }

            if (e.Column.FieldName == "cap_date")
                switch (searchInterval)
                {
                    case SearchInterval.FIVE:
                    case SearchInterval.FIFTEEN:
                        e.Column.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
                        break;
                    case SearchInterval.HOUR:
                        e.Column.DisplayFormat.FormatString = "yyyy년 MM월 dd일 HH시";
                        break;
                    case SearchInterval.DAY:
                        e.Column.DisplayFormat.FormatString = "yyyy년 MM월 dd일";
                        break;
                    case SearchInterval.MONTH:
                        e.Column.DisplayFormat.FormatString = "yyyy년 MM월";
                        break;
                }
        }


        private void gvTrafficStats_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var FocusedRow = gvTrafficStats.GetFocusedDataRow();

            if (FocusedRow != null)
            {
                string name = FocusedRow["name"].ToString();
                string s_cross_id = FocusedRow["s_cross_id"].ToString();
                string e_cross_id = FocusedRow["e_cross_id"].ToString();
                string name_cross = "";
                if (!string.IsNullOrEmpty(name))
                {
                    name_cross = name;
                }
                name_cross += string.Format("({0}->{1})", s_cross_id, e_cross_id);
                lbTrafficStatsTitle.Text = name_cross;

                string sFocusedCapDate = FocusedRow["CAP_DATE"].ToString();

                int nUnitMin = 0;
                DateTime SCapDate = DateTime.MinValue;
                DateTime ECapDate = DateTime.MinValue;
                DateTime FCapDate = DateTime.MinValue;

                if (!DateTime.TryParse(sFocusedCapDate, out FCapDate))
                    return;

                string LabelFormat = "yy/MM/dd\nHH:mm";
                switch (searchInterval)
                {
                    case SearchInterval.FIVE:
                        nUnitMin = 5;
                        LabelFormat = "yy/MM/dd\nHH:mm";
                        SCapDate = FCapDate.AddMinutes(nUnitMin * -10);
                        ECapDate = FCapDate.AddMinutes(nUnitMin * 10);
                        break;
                    case SearchInterval.FIFTEEN:
                        nUnitMin = 15;
                        LabelFormat = "yy/MM/dd\nHH:mm";
                        SCapDate = FCapDate.AddMinutes(nUnitMin * -10);
                        ECapDate = FCapDate.AddMinutes(nUnitMin * 10);
                        break;
                    case SearchInterval.HOUR:
                        LabelFormat = "yy/MM/dd\nHH시";
                        SCapDate = FCapDate.AddHours(-10);
                        ECapDate = FCapDate.AddHours(12);
                        break;
                    case SearchInterval.DAY:
                        LabelFormat = "yy/MM/dd";
                        SCapDate = FCapDate.AddDays(-3);
                        ECapDate = FCapDate.AddDays(5);
                        break;
                    case SearchInterval.MONTH:
                        LabelFormat = "yy/MM";
                        SCapDate = FCapDate.AddMonths(-5);
                        ECapDate = FCapDate.AddMonths(7);
                        break;
                }

                _FocusedDataTime = FCapDate.ToString(LabelFormat);

                _DataIndex.Clear();

                foreach (Series series in Chart_TrafficStats.Series)
                {
                    series.Points.Clear();
                }

                using (DataView dv = new DataView(dtLog))
                {
                    string linkID = FocusedRow["link_id"].ToString();
                    dv.RowFilter = string.Format("link_id = '{0}' AND CAP_DATE > '{1}' AND CAP_DATE < '{2}'", linkID, SCapDate.ToString("yyyy-MM-dd HH:mm:ss"), ECapDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    DateTime TempTime = SCapDate;

                    int interval = 0;
                    switch (searchInterval)
                    {
                        case SearchInterval.FIVE:
                            interval = TempTime.Minute % 5;
                            TempTime = TempTime.AddMinutes(-interval);
                            break;
                        case SearchInterval.FIFTEEN:
                            interval = TempTime.Minute % 15;
                            TempTime = TempTime.AddMinutes(-interval);
                            break;
                        case SearchInterval.HOUR:
                            TempTime = TempTime.AddHours(-1);
                            break;
                        case SearchInterval.DAY:
                            TempTime = TempTime.AddDays(-1);
                            break;
                        case SearchInterval.MONTH:
                            TempTime = TempTime.AddMonths(-1);
                            break;
                    }

                    string arg = string.Empty;

                    List<SeriesPoint> GoSeriesPoint = new List<SeriesPoint>();
                    List<SeriesPoint> SpdSeriesPoint = new List<SeriesPoint>();

                    foreach (DataRowView dr in dv)
                    {
                        DateTime CapDate = DateTime.MinValue;

                        if (!DateTime.TryParse(dr["CAP_DATE"].ToString(), out CapDate))
                            continue;

                        #region 빈값채우기
                        while (TempTime < CapDate)
                        {
                            arg = TempTime.ToString(LabelFormat);
                            GoSeriesPoint.Add(new SeriesPoint(arg));
                            SpdSeriesPoint.Add(new SeriesPoint(arg));
                            switch (searchInterval)
                            {
                                case SearchInterval.FIVE:
                                case SearchInterval.FIFTEEN:
                                    TempTime = TempTime.AddMinutes(nUnitMin);
                                    break;
                                case SearchInterval.HOUR:
                                    TempTime = TempTime.AddHours(1);
                                    break;
                                case SearchInterval.DAY:
                                    TempTime = TempTime.AddDays(1);
                                    break;
                                case SearchInterval.MONTH:
                                    TempTime = TempTime.AddMonths(1);
                                    break;
                            }
                        }
                        #endregion

                        int DataIndex = dtLog.Rows.IndexOf(dr.Row);
                        _DataIndex.Add(DataIndex);

                        int vol = 0;
                        double douSpd = 0;

                        try
                        {
                            int.TryParse(dr["vol"].ToString(), out vol);
                            Double.TryParse(dr["spd"].ToString(), out douSpd);
                            douSpd = Math.Round(douSpd, 2);
                        }
                        catch (Exception)
                        {

                        }

                        arg = TempTime.ToString(LabelFormat);
                        if (vol > 0)
                            GoSeriesPoint.Add(new SeriesPoint(arg, dr["vol"].ToString()));
                        else
                            GoSeriesPoint.Add(new SeriesPoint(arg));

                        if (douSpd >= 0.0f)
                            SpdSeriesPoint.Add(new SeriesPoint(arg, dr["spd"].ToString()));
                        else
                            SpdSeriesPoint.Add(new SeriesPoint(arg));

                        TempTime = TempTime.AddMinutes(nUnitMin);
                    }

                    #region 빈값채우기
                    while (TempTime < ECapDate)
                    {
                        arg = TempTime.ToString(LabelFormat);
                        GoSeriesPoint.Add(new SeriesPoint(arg));
                        SpdSeriesPoint.Add(new SeriesPoint(arg));
                        switch (searchInterval)
                        {
                            case SearchInterval.FIVE:
                            case SearchInterval.FIFTEEN:
                                TempTime = TempTime.AddMinutes(nUnitMin);
                                break;
                            case SearchInterval.HOUR:
                                TempTime = TempTime.AddHours(1);
                                break;
                            case SearchInterval.DAY:
                                TempTime = TempTime.AddDays(1);
                                break;
                            case SearchInterval.MONTH:
                                TempTime = TempTime.AddMonths(1);
                                break;
                        }
                    }
                    #endregion

                    Chart_TrafficStats.Series[0].Points.AddRange(GoSeriesPoint.ToArray());
                    Chart_TrafficStats.Series[1].Points.AddRange(SpdSeriesPoint.ToArray());

                    GoSeriesPoint.Clear();
                    SpdSeriesPoint.Clear();
                }

                if (Chart_TrafficStats.Diagram != null)
                {
                    XYDiagram ChartDiagram = Chart_TrafficStats.Diagram as XYDiagram;
                    if (ChartDiagram != null)
                    {
                        ChartDiagram.AxisX.WholeRange.SetMinMaxValues(SCapDate, ECapDate);
                        ChartDiagram.AxisX.VisualRange.SetMinMaxValues(SCapDate, ECapDate);
                    }
                }
            }

            Chart_TrafficStats.RefreshData();
            gcTrafficStats.Refresh();
        }

        private void Chart_LocalMonitor_CustomDrawAxisLabel(object sender, CustomDrawAxisLabelEventArgs e)
        {
            if (e.Item.Text == _FocusedDataTime)
                e.Item.TextColor = Color.Gold;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SplashScreenManager.ShowForm(this, typeof(ProgressDlg), true, true);

            DateTime _SDate;
            DateTime _EDate;


            _SDateTime = string.Format("{0} {1}", dtSDate.Value.ToString("yyyy-MM-dd"), dtSTime.Value.ToString("HH:mm:ss"));
            _EDateTime = string.Format("{0} {1}", dtEDate.Value.ToString("yyyy-MM-dd"), dtETime.Value.ToString("HH:mm:ss"));

            DateTime.TryParse(_SDateTime, out _SDate);
            DateTime.TryParse(_EDateTime, out _EDate);

            if (_SDate > _EDate)
            {
                SplashScreenManager.CloseForm(false);
                XtraMessageBox.Show(this, "종료 날짜를 시작 날짜 이후로 설정해 주세요 .", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //InitChart();
            if (tbControl.SelectedTabPageIndex == 0)
            {
                Search();
            }
            else if (tbControl.SelectedTabPageIndex == 1)
            {
                searchLinkData();
            }
            SplashScreenManager.CloseForm(false);
        }

        private void searchLinkData()
        {
            try
            {

                if (gvLinkInfo.SelectedRowsCount <= 0)
                {
                    SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show(this, "구간를 선택해 주세요.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string CheckID = checkLink();

                dbSearchLink(CheckID, _SDateTime, _EDateTime);

            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                XtraMessageBox.Show(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                //MV.InsertDBLog(LogType.Error, string.Format("로그정보 로딩실패. - {0}", ex.Message.Replace("'", "")));
            }
        }

        private void Search()
        {
            try
            {
                if (tlLocal.GetAllCheckedNodes().Count <= 0)
                {
                    SplashScreenManager.CloseForm(false);
                    XtraMessageBox.Show(this, "장비를 선택해 주세요.", "검색", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string CheckID = GetCheckID();


                dbSearchLog(CheckID, _SDateTime, _EDateTime);

            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm(false);
                XtraMessageBox.Show(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message), System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name);
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
                //MV.InsertDBLog(LogType.Error, string.Format("로그정보 로딩실패. - {0}", ex.Message.Replace("'", "")));
            }

        }

        private string checkLink()
        {
            string CheckID = string.Empty;
            if (gvLinkInfo.DataRowCount != gvLinkInfo.SelectedRowsCount)
            {
                foreach (int rowHandle in gvLinkInfo.GetSelectedRows())
                {
                    string link_id = gvLinkInfo.GetRowCellValue(rowHandle, "link_id").ToString();

                    if (!string.IsNullOrEmpty(CheckID))
                        CheckID += ", ";
                    CheckID += string.Format("'{0}'", link_id);
                }
            }

            return CheckID;
        }

        private string GetCheckID()
        {
            string CheckID = string.Empty;
            try
            {
                if (tlLocal.AllNodesCount != tlLocal.GetAllCheckedNodes().Count)
                {
                    foreach (TreeListNode node in tlLocal.GetAllCheckedNodes().Where(p => p.Level >= 1)) // && p["LOCAL_TYPE"].ToString() == LocalType.Cross
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

        private void btnExcelSave_Click(object sender, EventArgs e)
        {
            if (dtLog.Rows.Count == 0)
            {
                MessageBox.Show("저장할 데이터가 없습니다.", "엑셀저장", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (*.xlsx)|*.xlsx";
            sfd.FileName = string.Format("구간 통계_{0}.xlsx", DateTime.Now.ToString("yyyyMMddHHmmss"));
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XlsxExportOptions options = new XlsxExportOptions(TextExportMode.Value);
                gcTrafficStats.ExportToXlsx(sfd.FileName, options);

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

                //MV.InsertDBLog(LogType.Nomal, string.Format("* 구간 통계 엑셀저장\n단위: {0}\n조회기간 : {1} ~ {2}\n저장건수: {3}건", "5분", _SDateTime, _EDateTime, dtLog.Rows.Count));
            }

        }

        private void searchLink()
        {
            string sql = string.Empty;
            string where = string.Empty;
            dtLinkInfo.Clear();
            if (MV.DbManager.Fill(MV.SQL.S_TRI_LINK_STATS, dtLinkInfo) < 0)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("구간 정보 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                //MV.InsertDBLog(LogType.Error, string.Format("구간 정보 로딩실패. "));
            }
        }

        private void dbSearchLink(string CheckID, string SDateTime, string EDateTime)
        {
            string sql = string.Empty;
            string where = string.Empty;

            if (!string.IsNullOrEmpty(CheckID))
            {
                where += string.Format("AND ml.link_id IN ({0}) ", CheckID);
            }

            string interval = "%Y-%m-%d %H:00:00";
            switch (cbSearchRange.SelectedIndex)
            {
                case 0:
                    searchInterval = SearchInterval.FIVE;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_LOG, SDateTime, EDateTime, where);
                    break;
                case 1:
                    searchInterval = SearchInterval.FIFTEEN;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_15_LOG, SDateTime, EDateTime, where);
                    break;
                case 2:
                    searchInterval = SearchInterval.HOUR;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
                case 3:
                    searchInterval = SearchInterval.DAY;
                    interval = "%Y-%m-%d 00:00:00";
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
                case 4:
                    searchInterval = SearchInterval.MONTH;
                    interval = "%Y-%m-01 00:00:00";
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
            }

            dtLog.Clear();
            if (MV.DbManager.Fill(sql, dtLog) < 0)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("통계 이력 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                //MV.InsertDBLog(LogType.Error, string.Format("통계 이력 로딩실패. "));
            }

            lbSearchCount.Text = string.Format("총  {0:#,##0} 건", dtLog.Rows.Count);
        }

        private void dbSearchLog(string CheckID, string SDateTime, string EDateTime)
        {
            string sql = string.Empty;
            string where = string.Empty;


            if (!string.IsNullOrEmpty(CheckID))
            {
                where += string.Format("AND (s_cross_id IN ({0}) OR e_cross_id IN ({0})) ", CheckID);
            }

            string interval = "%Y-%m-%d %H:00:00";
            switch (cbSearchRange.SelectedIndex)
            {
                case 0:
                    searchInterval = SearchInterval.FIVE;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_LOG, SDateTime, EDateTime, where);
                    break;
                case 1:
                    searchInterval = SearchInterval.FIFTEEN;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_15_LOG, SDateTime, EDateTime, where);
                    break;
                case 2:
                    searchInterval = SearchInterval.HOUR;
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
                case 3:
                    searchInterval = SearchInterval.DAY;
                    interval = "%Y-%m-%d 00:00:00";
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
                case 4:
                    searchInterval = SearchInterval.MONTH;
                    interval = "%Y-%m-01 00:00:00";
                    sql = string.Format(MV.SQL.S_TRI_LINK_STATS_OTHER_LOG, SDateTime, EDateTime, where, interval);
                    break;
            }


            dtLog.Clear();
            if (MV.DbManager.Fill(sql, dtLog) < 0)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("통계 이력 로딩실패. - {0}", MV.DbManager.GetErrorMsg())));
                //MV.InsertDBLog(LogType.Error, string.Format("통계 이력 로딩실패. "));
            }

            lbSearchCount.Text = string.Format("총  {0:#,##0} 건", dtLog.Rows.Count);

        }

        private void gvTrafficStats_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.RowHandle == gvTrafficStats.FocusedRowHandle)
            {
                e.Appearance.BackColor = Color.Wheat;
            }
        }

        private void chkShowID_CheckedChanged(object sender, EventArgs e)
        {
            STATS_ID.Visible = chkShowID.Checked;
            STATS_NAME.Visible = !chkShowID.Checked;
        }
    }
}
