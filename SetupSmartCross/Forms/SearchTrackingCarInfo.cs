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
using RexMapControl;
using RexMapControl.Object;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using OsmSharp.Routing;

namespace SetupSmartCross.Forms
{
    public partial class SearchTrackingCarInfo : DevExpress.XtraEditors.XtraForm
    {
        private enum eDataSortType
        {
            CarNumAsc,
            CarNumDesc,
            CrossAsc,
            CrossDesc,
            PointAsc,
            PointDesc,
        }

        #region 변수
        private MapControl _MapControl = new MapControl();
        private string _ObjectLayerCrossKey = "교차로";
        private string _ObjectLayerPathKey = "통과지점";
        private int _PathPointIndex = 0;

        private List<CarInfo> _CarInfos = new List<CarInfo>();

        private string _SelectedCarNum = string.Empty;

        private eDataSortType _DataSortType = eDataSortType.CarNumAsc;

        private BackgroundWorker _bw = new BackgroundWorker();

        private GridSummaryItem _SummaryItemCarNum;
        private GridSummaryItem _SummaryItemPointCount;
        private GridSummaryItem _SummaryItemCrossCount;
        #endregion

        public SearchTrackingCarInfo()
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

        private void SearchTrackingCarInfo_Load(object sender, EventArgs e)
        {
            try
            {
                MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;

                Init();

                LoadMap();

                LoadLocal();

                InitGrid();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        
        private void SearchTrackingCarInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DeleteMapPath();
                DeleteMapObject();

                if(_MapControl != null)
                {
                    _MapControl.Dispose();
                    _MapControl = null;
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void Init()
        {
            SDate.DateTime = DateTime.Now.Date;
            EDate.DateTime = DateTime.Now.Date;
            STime.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            ETime.Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            _bw.DoWork += bw_DoWork;
            _bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            _bw.WorkerSupportsCancellation = true;
        }

        private void InitGrid()
        {
            try
            {
                gvCarInfo.GroupSummary.Clear();
                _SummaryItemCarNum = gvCarInfo.GroupSummary.Add(DevExpress.Data.SummaryItemType.Max, "CAR_NUM", CAR_NUM);
                _SummaryItemPointCount = gvCarInfo.GroupSummary.Add(DevExpress.Data.SummaryItemType.Max, "POINT_COUNT", POINT_COUNT);
                _SummaryItemCrossCount = gvCarInfo.GroupSummary.Add(DevExpress.Data.SummaryItemType.Max, "CROSS_COUNT", CROSS_COUNT);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void LoadLocal()
        {
            try
            {
                MV.LoadData.AddItem(LoadType.LoadLocalData);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
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
                        LoadMapData();
                    }
                });
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

        }

        #region 맵 로딩
        private void LoadMap()
        {
            try
            {
                string RootPath = IniData.MapPath;
                if (!System.IO.Path.IsPathRooted(RootPath))
                    RootPath = string.Format(@"{0}\{1}", Application.StartupPath, RootPath);

                string PbfPath = IniData.MapPbfPath;
                if (!System.IO.Path.IsPathRooted(PbfPath))
                    PbfPath = string.Format(@"{0}\{1}", Application.StartupPath, PbfPath);

                elementHostMap.Child = _MapControl;
                _MapControl.SetMinZoomLevel(IniData.MapMinZoomLevel);
                _MapControl.SetMaxZoomLevel(IniData.MapMaxZoomLevel);
                _MapControl.LoadMap(RootPath, IniData.MapKind == 0 ? MapKind.GoogleMap : MapKind.OpenStreetMap);
                _MapControl.MoveMap(IniData.MapX, IniData.MapY, IniData.MapZ);
                _MapControl.AddObjectLayer(_ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);

                _MapControl.AddPathLayer(_ObjectLayerPathKey, false, MV.MapIconInfo[IconKey.PathPoint], true, false);
                _MapControl.SetPathLineBrush(_ObjectLayerPathKey, new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(180, 0, 167, 141)));

                _MapControl.SetCrossLine(false);
                _MapControl.SetObjectAllCaptionVisible(_ObjectLayerCrossKey, true);

                CommonFunction.SimpleWorker(() =>
                {
                    if (string.IsNullOrEmpty(PbfPath) == false)
                    {
                        var result = _MapControl.LoadPbf(PbfPath);
                    }
                },
                () =>
                {
                    btnSearch.Enabled = true;
                });
               
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

        }
        #endregion

        #region LoadMapData
        public void LoadMapData()
        {

            try
            {

                DeleteMapObject();

                List<CrossInfo> ListCrossInfo = MV.LoadData.ListCrossInfo;

                foreach (var crossinfo in ListCrossInfo)
                {
                    if (crossinfo == null)
                        continue;

                    if (crossinfo.x == 0 && crossinfo.y == 0)
                    {
                        continue;
                    }

                    ObjectCross cross = new ObjectCross(crossinfo.cross_id);
                    cross.IsEditEnabled = false;
                    cross.CaptionText = crossinfo.name;
                    cross.CaptionVisibility = System.Windows.Visibility.Visible;
                    cross.SetObjCaptionVisibility(System.Windows.Visibility.Visible);
                    cross.SetObjToolTip(crossinfo.name, System.Windows.Media.Colors.Red);
                    cross.X = crossinfo.x;
                    cross.Y = crossinfo.y;                   

                    _MapControl.AddObject(_ObjectLayerCrossKey, cross, IconKey.CrossLengend);

                }

                //MapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, true);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region 맵 오브젝트 삭제
        private void DeleteMapObject()
        {
            CommonFunction.SimpleInvoke(this, () =>
            {
                _MapControl.RemoveAllObject(_ObjectLayerCrossKey);
            });
        }
        #endregion

        #region 맵 오브젝트 삭제
        private void DeleteMapPath()
        {
            CommonFunction.SimpleInvoke(this, () =>
            {
                _MapControl.RemovePathPointAll(_ObjectLayerPathKey);
            });
            
            _PathPointIndex = 0;
        }
        #endregion

        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Search();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                btnSearch.Focus();

                Search();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void Search()
        {
            gvCarInfo.BeginDataUpdate();
            try
            {
                _SelectedCarNum = string.Empty;

                gcCarInfo.DataSource = null;
                _CarInfos.Clear();

                string sql = string.Empty;

                string SDateTime = string.Format("{0} {1}", SDate.DateTime.ToString("yyyy-MM-dd"), STime.Time.ToString("HH:mm:ss"));
                string EDateTime = string.Format("{0} {1}", EDate.DateTime.ToString("yyyy-MM-dd"), ETime.Time.ToString("HH:mm:ss"));

                sql = string.Format(MV.SQL.S_CARINFO, SDateTime, EDateTime);

                DataTable dt = new DataTable();
                dt.Clear();
                              
                if(MV.DbManager.Fill(sql, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("차량정보 로딩실패.")));
                    MakeLog(string.Format("[{0}] - {1} \n{2}", System.Reflection.MethodBase.GetCurrentMethod().Name, sql, MV.DbManager.GetErrorMsg()));
                }
                else
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        CarInfo info = new CarInfo();
                                                
                        info.ID = dr["ID"].ToString();
                        ulong seq = 0;
                        ulong.TryParse(dr["SEQ"].ToString(), out seq);
                        info.SEQ = seq;
                        info.CROSS_ID = dr["CROSS_ID"].ToString();
                        info.CROSS_NAME = dr["CROSS_NAME"].ToString();
                        info.CAP_DATE = (DateTime)dr["CAP_DATE"];
                        info.CAR_NUM = dr["CAR_NUM"].ToString();
                        double x;
                        double y;
                        double.TryParse(dr["X"].ToString(), out x);
                        double.TryParse(dr["Y"].ToString(), out y);
                        info.X = x;
                        info.Y = y;
                        int cross_count = 0;
                        int.TryParse(dr["CROSS_COUNT"].ToString(), out cross_count);
                        info.CROSS_COUNT = cross_count;
                        int point_count = 0;
                        int.TryParse(dr["POINT_COUNT"].ToString(), out point_count);
                        info.POINT_COUNT = point_count;

                        info.GROUP_KEY = info.CAR_NUM;
                        
                        _CarInfos.Add(info);
                    }
                }

                gcCarInfo.DataSource = _CarInfos;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
            finally
            {
                gvCarInfo.EndDataUpdate();

                DataSort();
            }
        }

        private void gvCarInfo_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                var carInfo = GetCarInfoByRowHandle(e.RowHandle);

                if (carInfo != null)
                {
                    _MapControl.MoveMap(carInfo.X, carInfo.Y);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void gvCarInfo_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                gvCarInfo.Invalidate();

                WorkTrackingCarInfo();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void tbCarNum_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                gvCarInfo.ActiveFilterString = string.Format("CAR_NUM LIKE '%{0}%'", tbCarNum.Text);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private int GetDataSourceIndex(int rowHandle)
        {
            int index = -1;

            try
            {
                int dataRowHandle = rowHandle;

                if (gvCarInfo.IsGroupRow(rowHandle) == true)
                {
                    dataRowHandle = gvCarInfo.GetDataRowHandleByGroupRowHandle(rowHandle);
                }

                if (gvCarInfo.IsDataRow(dataRowHandle) == true)
                {
                    index = gvCarInfo.GetDataSourceRowIndex(dataRowHandle);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return index;
        }
        
        private CarInfo GetCarInfoByRowHandle(int rowHandle)
        {
            CarInfo carInfo = null;

            try
            {
                int index = GetDataSourceIndex(rowHandle);

                if (index >= 0 && index < _CarInfos.Count)
                {
                    carInfo = _CarInfos[index];
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return carInfo;
        }

        private List<CarInfo> GetCarInfosByRowHandle(int rowHandle)
        {
            List<CarInfo> carInfos = null;
            try
            {
                var carInfo = GetCarInfoByRowHandle(rowHandle);

                carInfos = _CarInfos.Where(p => p.CAR_NUM == carInfo.CAR_NUM).ToList();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return carInfos;
        }

        private void WorkTrackingCarInfo()
        {
            try
            {
                if (_bw.IsBusy == true)
                {
                    _bw.CancelAsync();
                    return;
                }

                _bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    WorkTrackingCarInfo();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }           
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var carInfo = GetCarInfoByRowHandle(gvCarInfo.FocusedRowHandle);

                if (carInfo == null || carInfo.CAR_NUM != _SelectedCarNum)
                {
                    if(InitMapTrackingCarInfo() == false)
                    {
                        e.Cancel = true;
                        return;
                    }

                    _SelectedCarNum = string.Empty;
                }

                if (carInfo != null && carInfo.CAR_NUM != _SelectedCarNum)
                {
                    if (SetMapTrackingCarInfo() == false)
                    {
                        e.Cancel = true;
                        return;
                    }

                    _SelectedCarNum = carInfo.CAR_NUM;
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private bool InitMapTrackingCarInfo()
        {
            bool result = false;
            try
            {
                DeleteMapPath();

                result = true;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
            finally
            {
                result = !_bw.CancellationPending;
            }

            return result;
        }

        private bool SetMapTrackingCarInfo()
        {
            bool result = false;
            try
            {
                var carInfos = GetCarInfosByRowHandle(gvCarInfo.FocusedRowHandle);

                DeleteMapPath();

                CarInfo StartInfo = null;
                CarInfo EndInfo = null;

                foreach (var carInfo in carInfos)
                {
                    if (_bw.CancellationPending == true)
                        return result;

                    EndInfo = carInfo;

                    SetPathCalculates(StartInfo, EndInfo); 

                    StartInfo = EndInfo;
                    EndInfo = null;
                }

                SetPathCalculates(StartInfo, EndInfo);
                result = true;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
            finally
            {
                result = !_bw.CancellationPending;
            }

            return result;
        }

        private void SetPathCalculates(CarInfo StartInfo, CarInfo EndInfo)
        {
            try
            {
                if (StartInfo == null)
                    return;

                string MoveObjectCaptionText = string.Empty;

                if (StartInfo != null && EndInfo != null)
                {
                    MoveObjectCaptionText = string.Format("{0} → {1}", StartInfo.SEQ, EndInfo.SEQ);
                }

                CommonFunction.SimpleInvoke(this, () =>
                {
                    if (StartInfo != null && StartInfo.X > 0 && StartInfo.Y > 0)
                    {
                        string captionText = string.Format("{0} : {1}", StartInfo.SEQ, StartInfo.CAP_DATE.ToString("yyyy-MM-dd HH:mm:ss"));
                        var CaptionBackColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(200, 25, 83, 95));
                        var CaptionFontColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(255, 236, 240, 241));

                        _MapControl.AddPathPoint(_ObjectLayerPathKey, StartInfo.CROSS_ID, StartInfo.X, StartInfo.Y, true, false, null, MV.MapIconInfo[IconKey.PathPoint], CaptionBackColor, CaptionFontColor, System.Windows.Visibility.Collapsed, MoveObjectCaptionText, System.Windows.Visibility.Visible);
                        _MapControl.SetPathPointPopupCaptionTextAdd(_ObjectLayerPathKey, StartInfo.CROSS_ID, captionText);

                        var pathPoint = _MapControl.GetPathPoint(_ObjectLayerPathKey, StartInfo.CROSS_ID);
                    }
                });


                if (StartInfo != null && EndInfo != null && StartInfo.X > 0 && StartInfo.Y > 0 && EndInfo.X > 0 && EndInfo.Y > 0)
                {
                    var waypointroute = _MapControl.GetPathCalculate(StartInfo.X, StartInfo.Y, EndInfo.X, EndInfo.Y);
                    if (waypointroute != null)
                    {
                        RouteSegment seg1 = null;

                        for (int j = 0; j < waypointroute.Segments.Length; j++)
                        {
                            var seg = waypointroute.Segments[j];

                            if (j % 3 == 0)
                            {
                                CommonFunction.SimpleInvoke(this, () =>
                                {
                                    _MapControl.AddPathPoint(_ObjectLayerPathKey, string.Format("Path{0}", _PathPointIndex++), seg.Longitude, seg.Latitude, false, false, null, null, null, null, System.Windows.Visibility.Collapsed, MoveObjectCaptionText, System.Windows.Visibility.Visible);
                                });
                                seg1 = seg;
                            }
                            else if (seg1 != null)
                            {
                                double x = Math.Abs(seg1.Longitude - seg.Longitude);
                                double y = Math.Abs(seg1.Latitude - seg.Latitude);

                                if(x + y > 0.001)
                                {
                                    CommonFunction.SimpleInvoke(this, () =>
                                    {
                                        _MapControl.AddPathPoint(_ObjectLayerPathKey, string.Format("Path{0}", _PathPointIndex++), seg.Longitude, seg.Latitude, false, false, null, null, null, null, System.Windows.Visibility.Collapsed, MoveObjectCaptionText, System.Windows.Visibility.Visible);
                                    });
                                    seg1 = seg;
                                }
                            }
                        }
                    }
                   
                }
               
                
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void gvCarInfo_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            try
            {
                int groupRowHandle = gvCarInfo.FocusedRowHandle;
                int focusedRowHandle = gvCarInfo.FocusedRowHandle;

                if (gvCarInfo.IsDataRow(focusedRowHandle) == true)
                {
                    groupRowHandle = gvCarInfo.GetParentRowHandle(focusedRowHandle);
                }

                if (gvCarInfo.IsGroupRow(groupRowHandle) == true && groupRowHandle == e.RowHandle)
                {
                    e.Appearance.ForeColor = Color.FromArgb(17, 157, 164);
                }
                else
                {
                    e.Appearance.ForeColor = Color.Black;
                }

                GridGroupRowInfo groupRow = e.Info as GridGroupRowInfo;

                CarInfo info = GetCarInfoByRowHandle(e.RowHandle);

                if (info == null)
                    return;

                groupRow.GroupText = string.Format("차량번호: {0}, (검지 = {1}, 교차로 = {2})", info.CAR_NUM, gvCarInfo.GetChildRowCount(e.RowHandle), info.CROSS_COUNT);  
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnSearchPath_Click(object sender, EventArgs e)
        {
            try
            {
                _MapControl.PathMovePlay(_ObjectLayerPathKey);
                var layer = _MapControl.GetPathLayer(_ObjectLayerPathKey);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnDataSort_Click(object sender, EventArgs e)
        {
            try
            {
                Point location = btnDataSort.PointToScreen(btnDataSort.Location);

                location = new Point(location.X - 5, location.Y + btnDataSort.Height - 5);

                popupMenuDataSort.ShowPopup(location);
                
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnDataSort_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (e.Item.Equals(btnDataSortByCarNumAsc) == true) _DataSortType = eDataSortType.CarNumAsc;
                else if (e.Item.Equals(btnDataSortByCarNumDesc) == true) _DataSortType = eDataSortType.CarNumDesc;
                else if (e.Item.Equals(btnDataSortByCrossAsc) == true) _DataSortType = eDataSortType.CrossAsc;
                else if (e.Item.Equals(btnDataSortByCrossDesc) == true) _DataSortType = eDataSortType.CrossDesc;
                else if (e.Item.Equals(btnDataSortByPointAsc) == true) _DataSortType = eDataSortType.PointAsc;
                else if (e.Item.Equals(btnDataSortByPointDesc) == true) _DataSortType = eDataSortType.PointDesc;
                
                lbDataSort.Text = e.Item.Caption;

                DataSort();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }           
        }

        private void DataSort()
        {
            try
            {
                gvCarInfo.BeginDataUpdate();

                if (gvCarInfo.GroupCount > 0)
                {
                    var summaryItem = GetGridSummaryItem();
                    var sortOrder = GetSortOrder();                   
                    var firstGroupingColumn = gvCarInfo.SortInfo[0].Column;

                    gvCarInfo.GroupSummarySortInfo.Clear();
                    gvCarInfo.GroupSummarySortInfo.Add(summaryItem, sortOrder, firstGroupingColumn);
                }

                gvCarInfo.EndDataUpdate();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private GridSummaryItem GetGridSummaryItem()
        {
            GridSummaryItem summaryItem = null;
            try
            {
                switch(_DataSortType)
                {
                    case eDataSortType.CarNumAsc:
                    case eDataSortType.CarNumDesc:
                        summaryItem = _SummaryItemCarNum;
                        break;
                    case eDataSortType.CrossAsc:
                    case eDataSortType.CrossDesc:
                        summaryItem = _SummaryItemCrossCount;
                        break;
                    case eDataSortType.PointAsc:
                    case eDataSortType.PointDesc:
                        summaryItem = _SummaryItemPointCount;
                        break;
                    default:
                        summaryItem = _SummaryItemCarNum;
                        break;
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
            return summaryItem;
        }

        private DevExpress.Data.ColumnSortOrder GetSortOrder()
        {
            DevExpress.Data.ColumnSortOrder sortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            try
            {
                switch (_DataSortType)
                {
                    case eDataSortType.CarNumAsc:
                    case eDataSortType.CrossAsc:
                    case eDataSortType.PointAsc:
                        sortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                        break;
                    case eDataSortType.CrossDesc:
                    case eDataSortType.CarNumDesc:
                    case eDataSortType.PointDesc:
                        sortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                        break;
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
            return sortOrder;
        }
    }
}