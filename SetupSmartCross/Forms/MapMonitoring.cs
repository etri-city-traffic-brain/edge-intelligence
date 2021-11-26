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
using RexMapControl;
using SetupSmartCross.DataBase;
using Common;
using RexMapControl.Object;

namespace SetupSmartCross.Forms
{
    public partial class MapMonitoring : DevExpress.XtraEditors.XtraUserControl
    {
        #region 변수
        private MapControl MapControl = new MapControl();
        private string ObjectLayerCrossKey = "교차로";
        private string ObjectLayerAccessKey = "접근로";
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

                LoadMap();

                LoadLocal();
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

                elementHostMap.Child = MapControl;
                MapControl.SetMinZoomLevel(IniData.MapMinZoomLevel);
                MapControl.SetMaxZoomLevel(IniData.MapMaxZoomLevel);
                MapControl.LoadMap(RootPath, IniData.MapKind == 0 ? MapKind.GoogleMap : MapKind.OpenStreetMap);
                MapControl.MoveMap(IniData.MapX, IniData.MapY, IniData.MapZ);
                MapControl.AddObjectLayer(ObjectLayerAccessKey, MV.MapIconInfo[IconKey.AccessLengend], MV.MapIconInfo);
                MapControl.AddObjectLayer(ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);
                MapControl.CrossLineVisible(true);
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
                        access.SetObjToolTip(AccessName, System.Windows.Media.Colors.Red);
                        access.X = dX;
                        access.Y = dY;
                        access.Angle = dAngle;
                        access.IsEditEnabled = false;
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
    }
}
