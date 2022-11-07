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
using DevExpress.XtraTreeList.Nodes;
using SetupSmartCross.DataBase;
using DevExpress.XtraTreeList;
using RexMapControl;
using Common;
using System.Windows.Media.Imaging;
using RexMapControl.Object;
using System.Windows.Media.Media3D;
using RexMapControl.Path;
using System.Windows.Input;
using RexMapControl.Section;
using System.Collections;
using System.Windows.Shapes;

namespace SetupSmartCross.Manage
{
    public partial class ManageLink : DevExpress.XtraEditors.XtraForm
    {
        private MapControl MapControl = new MapControl();
        private string ObjectLayerCrossKey = "교차로";
        private string ObjectLineLayerKey = "구간";
        private string SelectCrossID = string.Empty;
        private Dictionary<string, bool> DicExpanded = new Dictionary<string, bool>();
        private ArrayList DicChangeLineLocation = new ArrayList();
        private bool bExpand = false;
        private int linkID = 0;
        private bool sectionState = false;
        private DataTable LinkTable = new DataTable();

        public ManageLink()
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

            Console.WriteLine(sMsg);
        }
        #endregion

        private void ManageLink_Load(object sender, EventArgs e)
        {
            try
            {
                MV.LoadData.LoadLocalDataBegin += LoadData_LoadLocalDataBegin;
                MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;

                tlLocal.FocusedNodeChanged -= tlLocal_FocusedNodeChanged;
                tlLocal.SelectionChanged -= tlLocal_SelectionChanged;
                tlLocal.FocusedNodeChanged += tlLocal_FocusedNodeChanged;
                tlLocal.SelectionChanged += tlLocal_SelectionChanged;

                LoadMap();
                InitTreeListLocal();
                GridInit();
                gcLink.DataSource = LinkTable;

                LoadLocal();
                LoadLink();

                SetMapLine();
                SetLink();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void GridInit()
        {
            LinkTable.Columns.Add("ID");
            LinkTable.Columns.Add("NAME");
            LinkTable.Columns.Add("START");
            LinkTable.Columns.Add("END");
        }

        #region 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageLink_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (getUpdateLineChecked() > 0)
            {
                if (XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveMapLocation())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            elementHostMap.Child = null;

            MapControl.lineDoubleClick -= mapControl_lineDoubleClick;
            MapControl.MouseDown -= MapControl_MouseClick;

            DeleteMapObject();

            MapControl.RemoveObjectLayer(ObjectLayerCrossKey);
            MapControl.RemoveObjectLayer(ObjectLineLayerKey);

            DicChangeLineLocation.Clear();
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
                tlLocal.SetDrawNodeLevelInfo(0, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.CrossRoad], Color.Red);
                tlLocal.SetDrawNodeLevelInfo(0, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.CrossRoad], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(1, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.CrossLengend_S], Color.Red);
                tlLocal.SetDrawNodeLevelInfo(1, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.CrossLengend_S], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(2, ((int)TreeLocalIcon.Off).ToString(), MV.IconInfo[IconKey.Cctv], Color.Red);
                tlLocal.SetDrawNodeLevelInfo(2, ((int)TreeLocalIcon.On).ToString(), MV.IconInfo[IconKey.Cctv], Color.Black);
                tlLocal.SetDrawNodeLevelInfo(3, ((int)TreeLocalIcon.Off).ToString(), null, Color.Red);
                tlLocal.SetDrawNodeLevelInfo(3, ((int)TreeLocalIcon.On).ToString(), null, Color.Black);

                tlLocal.ShowPopupMenu = true;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

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

        string FocuseNodeID = string.Empty;
        void LoadData_LoadLocalDataBegin(object sender, EventArgs e)
        {
            try
            {
                tlLocal.SelectionChanged -= tlLocal_SelectionChanged;
                tlLocal.FocusedNodeChanged -= tlLocal_FocusedNodeChanged;

                if (tlLocal.FocusedNode != null)
                    FocuseNodeID = tlLocal.FocusedNode["ID"].ToString();

                DicExpanded.Clear();
                tlLocal.GetTreeExpanded("ID", tlLocal.Nodes, ref DicExpanded);
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
                        DataTable temp = (tlLocal.DataSource as DataTable);
                        if (temp != null)
                        {
                            temp.Dispose();
                        }

                        tlLocal.DataSource = load.dtLocal;
                        tlLocal.SetTreeExpanded("ID", tlLocal.Nodes, DicExpanded);
                        DicExpanded.Clear();

                        SetMapCross(tlLocal.Nodes);

                        tlLocal.SelectionChanged += tlLocal_SelectionChanged;
                        tlLocal.FocusedNodeChanged += tlLocal_FocusedNodeChanged;

                        if (string.IsNullOrEmpty(FocuseNodeID))
                        {
                            tlLocal.CollapseAll();
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
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

        }

        private void SetMapLine()
        {
            try
            {
                IEnumerable<ObjectLink> linkInfo = MV.LoadData.GetLinkInfo();

                if (linkInfo == null || linkInfo.Count() <= 0)
                    return;

                foreach (ObjectLink objectLink in linkInfo)
                {
                    System.Windows.Media.Brush _LineBrush = System.Windows.Media.Brushes.DarkGray;
                    if (objectLink.linkCheck)
                    {
                         _LineBrush = System.Windows.Media.Brushes.Green;
                    }
                    objectLink.brush = _LineBrush;
                    MapControl.LoadLinkPoint(ObjectLineLayerKey, objectLink, true,true);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return;
        }

        private void SetLink()
        {
            try
            {
                LinkTable.Clear();
                MV.DbManager.Fill(MV.SQL.S_LINK_INFO, LinkTable);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }

        #region 트리 클릭
        private void tlLocal_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (TreeListNode node in tlLocal.Selection)
                {
                    if (node.Level == 2 || node.Level == 3)
                    {
                        TreeListNode SelectNode = node;

                        if (node.Level == 3)
                            SelectNode = node.ParentNode;

                        string CamID = SelectNode["ID"].ToString();
                        IEnumerable<CCamAccessInfo> info = MV.LoadData.GetCCamAccessInfo(CamID);

                        if (info != null)
                        {
                            foreach (CCamAccessInfo accinfo in info)
                            {
                                string ObjectKey = string.Format("{0}&{1}", CamID, accinfo.direction);

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

        private void tlLocal_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

            try
            {
                SelectedNodeMoveMap();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region 트리 검색
        private void tbFindText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (sender.Equals(tbFindText))
                        tbFindTextEditValueChanged();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
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
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
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
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return Expanded;
        }
        #endregion
        #region 트리 확장
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
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

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
                MapControl.AddObjectLayer(ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);
                MapControl.AddSectionLayer(ObjectLineLayerKey, true, MV.MapIconInfo[IconKey.CrossRoad]);
                MapControl.SetPathLineBrush(ObjectLineLayerKey, System.Windows.Media.Brushes.Red);
                MapControl.SetCrossLine(true);

                MapControl.MouseDown += MapControl_MouseClick;
                MapControl.lineDoubleClick += mapControl_lineDoubleClick;

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

        }
        #endregion
        #region 맵 오브젝트 삭제
        private void DeleteMapObject()
        {
            foreach (ObjectCross obj in MapControl.GetObjectAll(ObjectLayerCrossKey).Cast<ObjectCross>())
            {
                obj.CustomMouseClick -= cross_CustomMouseClick;
            }
            MapControl.RemoveAllObject(ObjectLayerCrossKey);
            MapControl.RemoveAllLine(ObjectLineLayerKey);

        }
        #endregion
        #region 맵 등록
        private void SetMapCross(TreeListNodes Nodes)
        {
            try
            {
                if (Nodes == null)
                    return;

                double dX = 0;
                double dY = 0;
                foreach (TreeListNode node in Nodes)
                {
                    string localtype = node["LOCAL_TYPE"].ToString();
                    string ID = node["ID"].ToString();

                    if (node.Level == 0)
                    {
                        SetMapCross(node.Nodes);
                    }
                    else if (localtype == LocalType.Cross && node.Level == 1) // 교차로
                    {
                        CrossInfo info = MV.LoadData.GetCrossInfo(ID);

                        if (info == null)
                            continue;

                        if (info.x == 0 && info.y == 0)
                        {
                            dX = MapControl.X;
                            dY = MapControl.Y;

                        }
                        else
                        {
                            dX = info.x;
                            dY = info.y;
                        }

                        ObjectCross cross = new ObjectCross(ID);
                        cross.CaptionText = info.name;
                        cross.CaptionVisibility = System.Windows.Visibility.Collapsed;
                        cross.SetObjToolTip(info.name, System.Windows.Media.Colors.Green);
                        cross.X = dX;
                        cross.Y = dY;
                        cross.IsEditEnabled = false;
                        cross.CustomMouseClick += cross_CustomMouseClick;
                        MapControl.AddObject(ObjectLayerCrossKey, cross, IconKey.CrossLengend);

                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region 맵 이벤트

        private void UpdateLink(string linkID)
        {
            MapControl.RemoveAllLine(ObjectLineLayerKey);
        }

        void mapControl_lineDoubleClick(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SectionLine sectionLine = sender as SectionLine;
            ManageLinkAdd manageLInkAdd = new ManageLinkAdd(true, sectionLine);
            if (manageLInkAdd.ShowDialog(this) == DialogResult.OK)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "구간정보가 수정되었습니다.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateLink(sectionLine.objectLink.link_id);
                RefreshLinkData();
            }
        }

        private void addChangeLineLocation(string link)
        {
            if (!DicChangeLineLocation.Contains(link))
            {
                DicChangeLineLocation.Add(link);
            }
        }

        void MapControl_MouseClick(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (sectionState)
                {
                    System.Windows.Point currentPosition = e.GetPosition(MapControl as System.Windows.UIElement);
                    double Left = (double)(MapControl.MapRange.Left + currentPosition.X);
                    double Top = (double)(MapControl.MapRange.Top + currentPosition.Y);
                    var pos = Util.GetScreenPosToGeoPos(Left, Top, MapControl.Z);
                    string strLink = linkID.ToString();
                    //string LayerKey, ObjectLinkPoint linkPoint, bool IsVisible = true, bool IsEditEnabled = true, string CaptionText = null, BitmapImage Image = null, string crossID = null, Brush brush = null
                    MapControl.AddSectionPoint(ObjectLineLayerKey, new ObjectLinkPoint(linkID.ToString(), pos.X, pos.Y), true, true, "", null, null);
                    addChangeLineLocation(strLink);
                }
            }
        }
        #endregion

        void cross_CustomMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                ObjectCross cross = sender as ObjectCross;
                string strLink = linkID.ToString();
                if (sectionState)
                {
                    MapControl.AddSectionPoint(ObjectLineLayerKey, new ObjectLinkPoint(linkID.ToString(), cross.X, cross.Y), true, true, "종점", null, cross.Key);

                    sectionState = false;
                    SectionLine sectionLine = MapControl.GetSectionDrawLineData(ObjectLineLayerKey, strLink);
                    if (sectionLine != null)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "구간정보를 추가 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation(true);
                            ManageLinkAdd manageLInkAdd = new ManageLinkAdd(false,  sectionLine);
                            if (manageLInkAdd.ShowDialog(this) == DialogResult.OK)
                            {
                                //MapControl.LoadLinkPoint(ObjectLineLayerKey, objectLink, true, true);
                                DevExpress.XtraEditors.XtraMessageBox.Show(this, "구간정보가 추가되었습니다", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                UpdateLink(strLink);
                                RefreshLinkData();
                                linkID++;
                            }
                            else
                            {
                                MapControl.RemoveLink(ObjectLineLayerKey, manageLInkAdd.linkID);
                            }
                        }
                        else
                        {
                            MapControl.RemoveLink(ObjectLineLayerKey, linkID.ToString());
                        }
                    }

                }
                else
                {
                    MapControl.AddSectionPoint(ObjectLineLayerKey, new ObjectLinkPoint(strLink, cross.X, cross.Y), true, true, "시점", null, cross.Key);

                    sectionState = true;
                }
            }
            catch (Exception e1)
            {
                Console.Write("e1" + e1.StackTrace);
            }
        }

        public int getUpdateLineChecked()
        {
            object[] objectList = MapControl.GetSectionDrawingLine(ObjectLineLayerKey);
            foreach (SectionLine objectLink in objectList)
            {
                if (objectLink.updateStat)
                {
                    objectLink.updateStat = false;
                    addChangeLineLocation(objectLink.objectLink.link_id);
                }
            }

            return DicChangeLineLocation.Count;
        }


        #region 맵 위치정보 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveMapLocation();
        }

        private bool SaveMapLocation(bool popupStat = false)
        {
            int count = getUpdateLineChecked();
            bool updateStat = true;
            for (int i = 0; i < count; i++)
            {
                SectionLine sectionLine = MapControl.GetSectionDrawLineData(ObjectLineLayerKey, DicChangeLineLocation[i].ToString());
                if(sectionLine== null)
                {
                    continue;
                }
                double distance = sectionLine.GetDistance();
                int maxTravelTime = ((int)((distance / 5) * 3.6));
                int minTravelTime = ((int)((distance / 90) * 3.6));
                string linkID = DicChangeLineLocation[i].ToString();
                if (linkID.IndexOf("L") == -1)
                    continue;
                if (MV.DbManager.Excute(string.Format(MV.SQL.U_MST_LINK_TRAVELTIME, linkID,distance,minTravelTime,maxTravelTime)) < 0)
                {
                }
                if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_LINK_POINT, linkID)) < 0)
                {
                }
                else
                {
                    ArrayList arrPoint = sectionLine.getPoint();
                    if (arrPoint.Count == 0)
                    {
                        if (MV.DbManager.Excute(string.Format(MV.SQL.D_MST_LINK, linkID)) < 0)
                        {
                            updateStat = false;
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        for (int j = 0; j < arrPoint.Count; j++)
                        {
                            SectionPoint secPoint = arrPoint[j] as SectionPoint;
                            secPoint.objectPoint.seq = (j + 1).ToString();
                            if (MV.DbManager.Excute(string.Format(MV.SQL.I_MST_LINK_POINT, linkID, secPoint.objectPoint.seq, secPoint.objectPoint.X, secPoint.objectPoint.Y)) < 0)
                            {
                                updateStat = false;
                            }
                            else
                            {
                            }
                        }
                    }
                }
            }
            if (updateStat && !popupStat)
            {
                this.DialogResult= DialogResult.OK;
                XtraMessageBox.Show(this, "변경 완료", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (DicChangeLineLocation.Count >= 0)
            {
                DicChangeLineLocation.Clear();
            }
            return updateStat;

        }
        #endregion
        #region 맵 명칭 보기
        private void chkMapShowCaption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, chkMapShowCaption.Checked);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region 트리 노드선택 맵이동
        private void SelectedNodeMoveMap()
        {
            try
            {
                TreeListNode node = tlLocal.FocusedNode;
                TreeListNode parentNode = node;

                if (node != null)
                {
                    string localtype = node["LOCAL_TYPE"].ToString();

                    if (localtype == LocalType.Cross)
                    {
                        if (node.Level != 1 && node.Level != 2 && node.Level != 3)
                            return;

                        if (node.Level == 2)
                            parentNode = node.ParentNode;

                        if (node.Level == 3)
                            parentNode = node.ParentNode.ParentNode;

                        SelectCrossID = parentNode["ID"].ToString();


                        ObjectCross cross = MapControl.GetObject(ObjectLayerCrossKey, SelectCrossID) as ObjectCross;

                        if (cross != null)
                        {
                            MapControl.MoveMap(cross.X, cross.Y);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        private void chkShowID_CheckedChanged(object sender, EventArgs e)
        {
            ID.Visible = chkShowID.Checked;
            NAME.Visible = !chkShowID.Checked;
        }

        private void gvLink_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gvLink_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                DataRowView dr = gvLink.GetFocusedRow() as DataRowView;
                if (dr != null)
                {
                    SelectCrossID = dr[4].ToString();
                    ObjectCross cross = MapControl.GetObject(ObjectLayerCrossKey, SelectCrossID) as ObjectCross;
                    if (cross != null)
                    {
                        MapControl.MoveMap(cross.X, cross.Y);

                        if (e.Clicks == 2)
                        {
                            using(ManageLinkAdd dlg = new ManageLinkAdd(dr))
                            {
                                if(dlg.ShowDialog() == DialogResult.OK)
                                {
                                    RefreshLinkData();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }

        private void RefreshLinkData()
        {
            try
            {
                MV.LoadData.LoadMstLink();
                DeleteMapObject();
                SetMapCross(tlLocal.Nodes);
                SetMapLine();
                SetLink();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message));
            }
        }
    }
}