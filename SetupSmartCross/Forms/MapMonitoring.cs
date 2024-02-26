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
using RexMapControl2;
using SetupSmartCross.DataBase;
using Common;
using RexMapControl2.Object;
using RexMapControl2.Section;

namespace SetupSmartCross.Forms
{
    public partial class MapMonitoring : DevExpress.XtraEditors.XtraUserControl
    {
        #region 변수
        private MapControl MapControl = new MapControl();
        private string ObjectLayerCrossKey = "교차로";
        private string ObjectLayerAccessKey = "접근로";
        private string ObjectLineLayerKey = "구간";
        #endregion

        public MapMonitoring()
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

        private void MapMonitoring_Load(object sender, EventArgs e)
        {
            try
            {
                MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;
                MV.LoadData.LoadTriCross5MinEnd += LoadData_LoadTriCross5MinEnd;
                MV.LoadData.LoadLinkStatusEnd += LoadData_LoadLinkStatusEnd;

                LoadMap();

                LoadLocal();

                LoadLink();

                SetLink();

                SetLinkStatus();

                deSearchDate.DateTime = DateTime.Now.Date;

                cbHour.Properties.Items.Clear();
                for(int i = 0 ; i < 24; i++)
                {
                    cbHour.Properties.Items.Add(i);
                }

                cbMinute.Properties.Items.Clear();
                for(int i = 0 ; i < 59; i += 5)
                {
                    cbMinute.Properties.Items.Add(i);
                }

                cbHour.SelectedIndex = DateTime.Now.Hour;

                cbMinute.SelectedIndex = DateTime.Now.AddMinutes(-7).Minute / 5;
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

        private void LoadLink()
        {
            try
            {
                MV.LoadData.LoadMstLink();
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

        void LoadData_LoadTriCross5MinEnd(object sender, EventArgs e)
        {
            try
            {
                if (chkbtnRealTime.Checked == true)
                {
                    LoadData load = sender as LoadData;
                    using (DataTable dt = load.dtTriCross5Min)
                    {
                        CommonFunction.SimpleInvoke(this, () =>
                        {
                            lbSearchDateTime.Text = "실시간";
                        });
                        
                        SetCrossTraffic(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

        }

        void LoadData_LoadLinkStatusEnd(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.SimpleInvoke(this, () =>
                {
                    SetLinkStatus();
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

                elementHostMap.Child = MapControl;
                MapControl.SetMinZoomLevel(IniData.MapMinZoomLevel);
                MapControl.SetMaxZoomLevel(IniData.MapMaxZoomLevel);
                MapControl.LoadMap(RootPath, IniData.MapKind == 0 ? MapKind.GoogleMap : MapKind.OpenStreetMap);
                MapControl.MoveMap(IniData.MapX, IniData.MapY, IniData.MapZ);
                MapControl.AddObjectLayer(ObjectLayerAccessKey, MV.MapIconInfo[IconKey.AccessLengend], MV.MapIconInfo);
                MapControl.AddObjectLayer(ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);
                MapControl.AddSectionLayer(ObjectLineLayerKey, true, MV.MapIconInfo[IconKey.CrossRoad]);
                MapControl.SetCrossLine(false);
                MapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, true);
                MapControl.MoveMapEvent += MapControl_MoveMapEvent;
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
                    cross.CaptionText = crossinfo.name;
                    cross.CaptionVisibility = System.Windows.Visibility.Visible;
                    cross.SetObjToolTip(crossinfo.name, System.Windows.Media.Colors.Red);
                    cross.X = crossinfo.x;
                    cross.Y = crossinfo.y;
                    cross.IsEditEnabled = false;

                    MapControl.AddObject(ObjectLayerCrossKey, cross, IconKey.CrossLengend);

                    SetMapCrossAccess(crossinfo.cross_id);
                }

                //MapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, true);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        public void LoadMapLinkData()
        {
            try
            {
                LoadLink();

                SetLink();
                SetLinkStatus();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[EX][{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }



        private void SetLink()
        {
            try
            {
                DeleteLink();

                IEnumerable<ObjectLink> linkInfo = MV.LoadData.GetLinkInfo();

                if (linkInfo == null || linkInfo.Count() <= 0)
                    return;

                foreach (ObjectLink objectLink in linkInfo)
                {
                    if (!objectLink.linkCheck)
                    {
                        continue;
                    }
                    objectLink.brush = System.Windows.Media.Brushes.DimGray;
                    MapControl.LoadLinkPoint(ObjectLineLayerKey, objectLink, false, false);
                    ObjectLinkCheck objectLinkCheck = new ObjectLinkCheck();
                    objectLinkCheck.meter = objectLink.distance;
                    MapControl.SetObjectLineToolTipAdd(true, ObjectLineLayerKey, objectLink.link_id, objectLinkCheck, System.Windows.Media.Color.FromRgb(0, 0, 0));
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return;
        }

        #region 구간 정보 설정
        public void SetLinkStatus()
        {
            MapControl.SetLegendItemVisible(ObjectLineLayerKey, true);
            object[] objectList = MapControl.GetSectionDrawingLine(ObjectLineLayerKey);
            foreach (SectionLine objectLink in objectList)
            {
                if (objectLink != null)
                {
                    bool state = false;
                    objectLink.Visibility = System.Windows.Visibility.Visible;
                    foreach (DataRow dr in MV.LoadData.dtLinkStatus.Rows)
                    {
                        if (dr["link_id"].ToString().Equals(objectLink.objectLink.link_id))
                        {
                            state = true;
                            break;
                        }
                        else
                        {
                            objectLink.objectLink.brush = System.Windows.Media.Brushes.Gray;
                            objectLink.redraw(false);
                        }
                    }
                    if (!state)
                    {
                        if (objectLink.objectLink.brush != System.Windows.Media.Brushes.Gray)
                        {
                            objectLink.objectLink.brush = System.Windows.Media.Brushes.Gray;
                            objectLink.redraw(false);
                        }
                    }
                }
            }

            foreach (DataRow dr in MV.LoadData.dtLinkStatus.Rows)
            {
                string linkID = dr["link_id"].ToString();
                DateTime capdate = string.IsNullOrEmpty(dr["cap_date"].ToString()) ? DateTime.MinValue : (DateTime)dr["cap_date"];
                string vol = dr["vol"].ToString();
                string spd = dr["spd"].ToString();
                string traveltime = dr["traveltime"].ToString();
                string showLInk = dr["view_flag"].ToString();

                SectionLine sectionLIne = MapControl.GetSectionDrawLineData(ObjectLineLayerKey, linkID);
                if (sectionLIne == null || !sectionLIne.objectLink.linkCheck)
                    continue;

                int fastSpeed = (int)sectionLIne.objectLink.fastSpeed;
                int slowSpeed = (int)sectionLIne.objectLink.slowSpeed;
                double dspd = Math.Round(Double.Parse(spd), 2);
                int result = (int)dspd; //result1 : 2

                System.Windows.Media.Brush _LineBrush = System.Windows.Media.Brushes.DarkGray;
                if (sectionLIne.objectLink.linkCheck)
                {
                    if (result >= fastSpeed)
                    {
                        Color color = Color.FromName(IniData.ParamCrossColorFast);
                        _LineBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
                    }
                    else if (result >= slowSpeed && result < fastSpeed)
                    {
                        Color color = Color.FromName(IniData.ParamCrossColorSlow);
                        _LineBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
                    }
                    else if (result > 0 && result < slowSpeed)
                    {
                        Color color = Color.FromName(IniData.ParamCrossColorStop);
                        _LineBrush = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
                    }
                }
                sectionLIne.objectLink.brush = _LineBrush;
                sectionLIne.redraw(false);
                ObjectLinkCheck objectLinkCheck = new ObjectLinkCheck();
                objectLinkCheck.meter = sectionLIne.objectLink.distance;
                objectLinkCheck.capdate = capdate;
                objectLinkCheck.vol = int.Parse(vol);
                objectLinkCheck.spd = (float)dspd;
                objectLinkCheck.travelTime = int.Parse(traveltime);

                sectionLIne.SetObjToolTipAdd(false, System.Windows.Media.Color.FromRgb(0, 0, 0), objectLinkCheck);
            }
        }
        #endregion

        private void SetMapCrossAccess(string CrossID)
        {
            try
            {

                double dX = 0;
                double dY = 0;
                double dAngle = 0;

                var CamInfos = MV.LoadData.GetCrossByCCamInfo(CrossID);

                if (CamInfos == null)
                    return;

                foreach (CCamInfo caminfo in CamInfos)
                {
                    if (caminfo == null)
                        continue;

                    IEnumerable<CCamAccessInfo> accessinfo = MV.LoadData.GetCCamAccessInfo(caminfo.cam_id);

                    if (accessinfo == null || accessinfo.Count() <= 0)
                        continue;

                    foreach (CCamAccessInfo acc in accessinfo)
                    {
                        if (acc.direction == CrossDirection.IN)
                            continue;

                        dX = acc.x;
                        dY = acc.y;
                        dAngle = acc.angle;

                        string AccessId = string.Format("{0}&{1}", acc.cam_id, acc.direction);
                        string AccessName = string.Format("{0} [{1}]", caminfo.name, acc.direction_name);
                        if (!string.IsNullOrEmpty(acc.name))
                            AccessName = string.Format("{0} [{1}]", acc.name, acc.direction_name);

                        ObjectCrossArrow access = new ObjectCrossArrow(AccessId);
                        access.CaptionText = AccessName;
                        access.CaptionVisibility = System.Windows.Visibility.Collapsed;
                        access.SetObjToolTip(AccessName, System.Windows.Media.Colors.Black);
                        access.X = dX;
                        access.Y = dY;
                        access.Angle = dAngle;
                        access.IsEditEnabled = false;
                        access.SetObjFillColor(System.Windows.Media.Colors.DimGray);
                        MapControl.AddObject(ObjectLayerAccessKey, access);
                    }
                }

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return;
        }

        #region 맵 오브젝트 삭제
        private void DeleteMapObject()
        {
            MapControl.RemoveAllObject(ObjectLayerCrossKey);
            MapControl.RemoveAllObject(ObjectLayerAccessKey);
        }

        private void DeleteLink()
        {
            MapControl.RemoveAllLine(ObjectLineLayerKey);
        }
        #endregion


        void MapControl_MoveMapEvent(object sender, MapControl.MoveMapArgs e)
        {
            try
            {
                if (e.Z >= 15)
                {
                    MapControl.SetObjectLayerVisible(ObjectLayerAccessKey, true);
                }
                else
                {
                    MapControl.SetObjectLayerVisible(ObjectLayerAccessKey, false);
                }

                IniData.MapX = MapControl.X;
                IniData.MapY = MapControl.Y;
                IniData.MapZ = (int)MapControl.Z;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        #region 소통정보 등록
        private void SetCrossTraffic(DataTable dt)
        {
            try
            {
                CommonFunction.SimpleInvoke(this, () =>
                    {
                        object[] objects = MapControl.GetObjectAll(ObjectLayerAccessKey);

                        if (objects != null)
                        {
                            foreach (object obj in objects)
                            {
                                if (obj is ObjectCrossArrow)
                                {
                                    ObjectCrossArrow acc = obj as ObjectCrossArrow;
                                    acc.SetObjFillColor(System.Windows.Media.Colors.DimGray);
                                    acc.SetObjStrokeThickness(0);
                                }
                            }
                        }
                    });

                foreach (DataRow dr in dt.Rows)
                {
                    string CamID = dr["CAM_ID"].ToString();
                    string CamName = dr["CAM_NAME"].ToString();
                    string Direction = dr["DIRECTION"].ToString();
                    string DirectionName = dr["DIRECTION_NAME"].ToString();
                    double queue = 0;
                    double.TryParse(dr["QUEUE"].ToString(), out queue);
                    double occ = 0;
                    double.TryParse(dr["OCC"].ToString(), out occ);
                    string ObjectKey = string.Format("{0}&{1}", CamID, Direction);

                    System.Windows.Media.Color mediacolor = System.Windows.Media.Colors.DimGray;
                    if (60 <= queue)
                    {
                        mediacolor = System.Windows.Media.Color.FromRgb(240, 5, 44);
                    }
                    else if (30 <= queue)
                    {
                        mediacolor = System.Windows.Media.Color.FromRgb(255, 222, 0);
                    }
                    else
                    {
                        mediacolor = System.Windows.Media.Color.FromRgb(84, 213, 52);
                    }

                    CommonFunction.SimpleInvoke(this, () =>
                    {
                        ObjectCrossArrow acc = MapControl.GetObject(ObjectLayerAccessKey, ObjectKey) as ObjectCrossArrow;

                        if (acc != null && mediacolor != null)
                        {
                            acc.SetObjFillColor(mediacolor);
                            acc.SetObjToolTipClear();
                            acc.SetObjToolTipAdd(string.Format("{0} [{1}]", CamName, DirectionName), System.Windows.Media.Colors.Black);
                            acc.SetObjToolTipAdd(string.Format("대기행렬: {0}m", queue), System.Windows.Media.Colors.SeaGreen);
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        private void chkbtnRealTime_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chkbtnRealTime.Checked == true)
                {
                    chkbtnRealTime.ForeColor = Color.Gold;
                    MV.LoadData.AddItem(LoadType.LoadTriCross5Min);
                }
                else
                {
                    chkbtnRealTime.ForeColor = Color.FromArgb(129, 129, 129);
                    Search();
                }

                deSearchDate.Enabled = !chkbtnRealTime.Checked;
                cbHour.Enabled = !chkbtnRealTime.Checked;
                cbMinute.Enabled = !chkbtnRealTime.Checked;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void Search()
        {
            try
            {
                if (chkbtnRealTime.Checked == false)
                {
                    DateTime searchDateTime = new DateTime(deSearchDate.DateTime.Year, deSearchDate.DateTime.Month, deSearchDate.DateTime.Day, cbHour.SelectedIndex, cbMinute.SelectedIndex * 5, 0);
                    DataTable dt = MV.LoadData.GetTriCross5MinLog(searchDateTime);

                    lbSearchDateTime.Text = string.Format("{0}", searchDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    SetCrossTraffic(dt);

                    //XtraMessageBox.Show("적용완료.", "교통정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                Search();
            }
        }

        private void Search_DateTimeChanged(object sender, EventArgs e)
        {
            try
            {
                Search();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
    }
}
