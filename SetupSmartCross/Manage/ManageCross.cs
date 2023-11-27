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

namespace SetupSmartCross.Manage
{
    public partial class ManageCross : DevExpress.XtraEditors.XtraForm
    {
        private MapControl MapControl = new MapControl();
        private MapControl MiniMapControl = new MapControl();

        private string ObjectLayerCrossKey = "교차로";
        private string ObjectLayerAccessKey = "접근로";
        private string SelectCrossID = string.Empty;

        private Dictionary<string, bool> DicExpanded = new Dictionary<string, bool>();
        private Dictionary<string, string> DicChangeCrossLocation = new Dictionary<string, string>();
        private Dictionary<string, string> DicChangeAccessLocation = new Dictionary<string, string>();

        private bool bExpand = false;

        public ManageCross()
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

        private void ManageCross_Load(object sender, EventArgs e)
        {
            try
            {
                MV.LoadData.LoadLocalDataBegin += LoadData_LoadLocalDataBegin;
                MV.LoadData.LoadLocalDataEnd += LoadData_LoadLocalDataEnd;
                MV.LoadData.LoadStatusEnd += LoadData_LoadStatusEnd;
                              
                LoadMap();
                InitTreeListLocal();
                LoadLocal();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        #region 닫기
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageCross_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!SaveMapLocation())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            elementHostMap.Child = null;
            elementHostMiniMap.Child = null;

            MapControl.MoveMapEvent -= MapControl_MoveMapEvent;
            MiniMapControl.MoveMapEvent -= MapControl_MoveMapEvent;

            DeleteMapObject();

            MapControl.RemoveObjectLayer(ObjectLayerCrossKey);
            MapControl.RemoveObjectLayer(ObjectLayerAccessKey);

            MiniMapControl.RemoveObjectLayer(ObjectLayerCrossKey);
            MiniMapControl.RemoveObjectLayer(ObjectLayerAccessKey);

            MV.LoadData.LoadLocalDataBegin -= LoadData_LoadLocalDataBegin;
            MV.LoadData.LoadLocalDataEnd -= LoadData_LoadLocalDataEnd;
            MV.LoadData.LoadStatusEnd -= LoadData_LoadStatusEnd;

            DicChangeCrossLocation.Clear();
            DicChangeAccessLocation.Clear();
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
                tlLocal.DragOver += tlLocal_DragOver;
                tlLocal.DragDrop += tlLocal_DragDrop;

                tlLocal.SetPopupMenuInfo(-1, popupMenuLevel);
                tlLocal.SetPopupMenuInfo(0, popupMenuLevel0);
                tlLocal.SetPopupMenuInfo(1, popupMenuLevel1);
                tlLocal.ShowPopupMenu = true;
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region 현장 트리 로딩
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

                        DeleteMapObject();
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

        #region Loading Status
        void LoadData_LoadStatusEnd(object sender, EventArgs e)
        {
            try
            {
                CommonFunction.SimpleInvoke(this, () =>
                {
                    LoadData load = sender as LoadData;
                    if (load != null)
                    {
                        tlLocal.SelectionChanged -= tlLocal_SelectionChanged;
                        tlLocal.FocusedNodeChanged -= tlLocal_FocusedNodeChanged;
                        using (DataTable dt = load.dtStatusInfo)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                var node = tlLocal.FindNodeByKeyID(dr["ID"].ToString());
                                if (node != null)
                                {
                                    node.SetValue("STATUSINFO", dr["STATUS"].ToString());
                                    node.SetValue("CAP_DATE", dr["CAP_DATE"].ToString());
                                }
                            }
                        }
                        tlLocal.SelectionChanged += tlLocal_SelectionChanged;
                        tlLocal.FocusedNodeChanged += tlLocal_FocusedNodeChanged;
                    }
                });
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
        #endregion
        #region 트리메뉴클릭
        private void btnLevelAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveMapLocation();
                    }
                }

                ManageGroupAdd ManageGroupAdd = new ManageGroupAdd();
                ManageGroupAdd.ShowDialog(this);

                LoadLocal();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnLevel0Modify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var node = tlLocal.FocusedNode;
                if (node != null)
                {
                    if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation();
                        }
                    }

                    ManageGroupAdd ManageGroupAdd = new ManageGroupAdd();
                    ManageGroupAdd.GroupID = node["ID"].ToString();
                    ManageGroupAdd.ShowDialog(this);

                    LoadLocal();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnLevel0Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var node = tlLocal.FocusedNode;
                if (node != null)
                {
                    if (XtraMessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }

                    if (DevExpress.XtraTreeList.TreeList.AutoFilterNodeId == node.Id)
                        node = tlLocal.Nodes.FirstNode;

                    if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation();
                        }
                    }

                    DeleteNode(node);

                    LoadLocal();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private bool DeleteNode(TreeListNode node)
        {
            try
            {
                if (node.Level > 2)
                    return true;

                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    TreeListNode Child = node.Nodes[i];
                    DeleteNode(Child);
                }

                string sql = string.Empty;
                string ID = node.GetValue("ID").ToString();
                string NAME = node.GetValue("NAME").ToString();
                string LOCAL_TYPE = node.GetValue("LOCAL_TYPE").ToString();


                if (node.Level == 0)
                {
                    sql = string.Format(MV.SQL.D_MST_LOCAL_GROUP, ID);
                    if (MV.DbManager.Excute(sql) <= 0)
                        return false;

                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 현장그룹 삭제 성공\n그룹ID: {0}, 명칭: {1} ", ID, NAME));
                }
                else if (node.Level == 1)
                {
                    if (LOCAL_TYPE == LocalType.Cross)
                    {
                        sql = string.Format(MV.SQL.D_MST_CROSS_ID, ID);
                        if (MV.DbManager.Excute(sql) < 0)
                            return false;

                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 삭제 성공\n교차로ID: {0}, 명칭: {1} ", ID, NAME));
                    }
                }
                else if (node.Level == 2)
                {
                    if (LOCAL_TYPE == LocalType.Cross)
                    {
                        sql = string.Format(MV.SQL.U_MST_CCAM_CROSS_ID_NULL, ID);
                        if (MV.DbManager.Excute(sql) < 0)
                            return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        private void btnLevel0Add_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var node = tlLocal.FocusedNode;
                if (node != null)
                {
                    if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation();
                        }
                    }

                    ManageCrossAdd ManageCrossAdd = new ManageCrossAdd();
                    ManageCrossAdd.GroupID = node["ID"].ToString();
                    ManageCrossAdd.ShowDialog(this);

                    LoadLocal();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnLevel1Modify_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var node = tlLocal.FocusedNode;
                if (node != null)
                {
                    if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation();
                        }
                    }

                    ManageCrossAdd ManageCrossAdd = new ManageCrossAdd();
                    ManageCrossAdd.GroupID = node["PARENT_ID"].ToString();
                    ManageCrossAdd.CrossID = node["ID"].ToString();
                    ManageCrossAdd.ShowDialog(this);

                    LoadLocal();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void btnLevel1Delete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                var node = tlLocal.FocusedNode;
                if (node != null)
                {
                    if (XtraMessageBox.Show("삭제 하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }     

                    if (DevExpress.XtraTreeList.TreeList.AutoFilterNodeId == node.Id)
                        node = tlLocal.Nodes.FirstNode;

                    if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            SaveMapLocation();
                        }
                    }

                    DeleteNode(node);

                    LoadLocal();
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region TreeDrag
        void tlLocal_DragOver(object sender, DragEventArgs e)
        {
            try
            {
                TreeListNode dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

                Point point = tlLocal.PointToClient(new Point(e.X, e.Y));
                DevExpress.XtraTreeList.TreeListHitInfo TreeListHitInfo = tlLocal.CalcHitInfo(point);
                TreeListNode destNode = TreeListHitInfo.Node;

                if (destNode != null)
                {
                    if (destNode["ID"].ToString() != dragNode.ParentNode["ID"].ToString() && dragNode.Level == 1 && destNode.Level == 0 && dragNode.GetValue("LOCAL_TYPE").ToString() == LocalType.Cross)
                    {
                        e.Effect = DragDropEffects.Move;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void tlLocal_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                TreeListNode dragNode = e.Data.GetData(typeof(TreeListNode)) as TreeListNode;

                Point point = tlLocal.PointToClient(new Point(e.X, e.Y));
                DevExpress.XtraTreeList.TreeListHitInfo TreeListHitInfo = tlLocal.CalcHitInfo(point);
                TreeListNode destNode = TreeListHitInfo.Node;

                if (e.Data.GetData(typeof(TreeListNode)) != null)
                {
                    if (destNode != null && dragNode != null && destNode["ID"].ToString() != dragNode.ParentNode["ID"].ToString())
                    {
                        if (dragNode.Level == 1 && destNode.Level == 0 && dragNode.GetValue("LOCAL_TYPE").ToString() == LocalType.Cross)
                        {
                            string GroupID = destNode.GetValue("ID").ToString();
                            TreeListMultiSelection selectedNodes = tlLocal.Selection;
                            if (selectedNodes != null)
                            {

                                for (int i = 0; i < selectedNodes.Count; i++)
                                {
                                    TreeListNode node = selectedNodes[i];
                                    string CrossID = node.GetValue("ID").ToString();
                                    if (SetCrossGroupID(CrossID, GroupID) == false)
                                    {
                                        break;
                                    }
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
            finally
            {
                e.Effect = DragDropEffects.None; // 데이터 입력을 취소하고 다시 로딩
            }

            LoadLocal();

        }

        private bool SetCrossGroupID(string CrossID, string GroupID)
        {
            bool result = true;
            try
            {
                string sql = string.Format(MV.SQL.U_MST_CROSS_GROUP_ID, CrossID, GroupID);
                if (MV.DbManager.Excute(sql) <= 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 그룹 변경 실패 : {0}", MV.DbManager.GetErrorMsg())));
                    //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 그룹 변경 실패\n교차로ID: {0}, 그룹ID: {1} ", CrossID, GroupID));
                    result = false;
                }
                else
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 그룹 변경 성공 - 교차로ID: {0}, 그룹ID: {1} ", CrossID, GroupID)));
                    //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 그룹 변경 성공\n교차로ID: {0}, 그룹ID: {1} ", CrossID, GroupID));
                }

                if (!result)
                    XtraMessageBox.Show("저장 실패.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return result;
        }
        #endregion
        #region 트리 클릭
        private void tlLocal_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                object[] objects = MapControl.GetObjectAll(ObjectLayerAccessKey);

                if (objects != null)
                {
                    foreach (object obj in objects)
                    {
                        if (obj is ObjectCrossArrow)
                        {
                            ObjectCrossArrow acc = obj as ObjectCrossArrow;
                            acc.SetObjStrokeColor(System.Windows.Media.Brushes.Gray, 1);
                        }
                    }
                }

                object[] Miniobjects = MiniMapControl.GetObjectAll(ObjectLayerAccessKey);

                if (Miniobjects != null)
                {
                    foreach (object obj in Miniobjects)
                    {
                        if (obj is ObjectCrossArrow)
                        {
                            ObjectCrossArrow acc = obj as ObjectCrossArrow;
                            acc.SetObjStrokeColor(System.Windows.Media.Brushes.Gray, 1);
                        }
                    }
                }

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

                                ObjectCrossArrow acc = MapControl.GetObject(ObjectLayerAccessKey, ObjectKey) as ObjectCrossArrow;

                                if (acc != null)
                                {
                                    acc.SetObjStrokeColor(System.Windows.Media.Brushes.Lime, 3);
                                }

                                ObjectCrossArrow Miniacc = MiniMapControl.GetObject(ObjectLayerAccessKey, ObjectKey) as ObjectCrossArrow;

                                if (Miniacc != null)
                                {
                                    Miniacc.SetObjStrokeColor(System.Windows.Media.Brushes.Lime, 3);
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
        private void tbFindText_KeyDown(object sender, KeyEventArgs e)
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
                MapControl.AddObjectLayer(ObjectLayerAccessKey, MV.MapIconInfo[IconKey.AccessLengend], MV.MapIconInfo);
                MapControl.AddObjectLayer(ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);               
                MapControl.SetCrossLine(true);
                MapControl.MoveMapEvent += MapControl_MoveMapEvent;

                elementHostMiniMap.Child = MiniMapControl;
                MiniMapControl.LegendVisible(false);
                MiniMapControl.SetMinZoomLevel(IniData.MapMinZoomLevel);
                MiniMapControl.SetMaxZoomLevel(IniData.MapMaxZoomLevel);
                MiniMapControl.LoadMap(RootPath, IniData.MapKind == 0 ? MapKind.GoogleMap : MapKind.OpenStreetMap);
                MiniMapControl.MoveMap(IniData.MapX, IniData.MapY, IniData.MapZ);
                MiniMapControl.AddObjectLayer(ObjectLayerAccessKey, MV.MapIconInfo[IconKey.AccessLengend], MV.MapIconInfo);
                MiniMapControl.AddObjectLayer(ObjectLayerCrossKey, MV.MapIconInfo[IconKey.CrossLengend], MV.MapIconInfo);
                MiniMapControl.MoveMapEvent += MiniMapControl_MoveMapEvent;
                MiniMapControl.SetCrossLine(true);
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
                obj.MoveChange -= cross_MoveChange;
                obj.CustomMouseClick -= cross_CustomMouseClick;
                obj.CustomMouseDoubleClick -= cross_CustomMouseDoubleClick;
            }
            MapControl.RemoveAllObject(ObjectLayerCrossKey);

            foreach (ObjectCrossArrow obj in MapControl.GetObjectAll(ObjectLayerAccessKey).Cast<ObjectCrossArrow>())
            {
                obj.MoveChange -= access_MoveChange;
                obj.CustomMouseClick -= access_CustomMouseClick;
            }
            MapControl.RemoveAllObject(ObjectLayerAccessKey);

            foreach (ObjectCross obj in MiniMapControl.GetObjectAll(ObjectLayerCrossKey).Cast<ObjectCross>())
            {
                obj.MoveChange -= cross_MoveChange;
                obj.CustomMouseClick -= cross_CustomMouseClick;
                obj.CustomMouseDoubleClick -= cross_CustomMouseDoubleClick;
            }
            MiniMapControl.RemoveAllObject(ObjectLayerCrossKey);

            foreach (ObjectCrossArrow obj in MiniMapControl.GetObjectAll(ObjectLayerAccessKey).Cast<ObjectCrossArrow>())
            {
                obj.MoveChange -= access_MoveChange;
                obj.CustomMouseClick -= access_CustomMouseClick;
            }
            MiniMapControl.RemoveAllObject(ObjectLayerAccessKey);
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
                            if(!DicChangeCrossLocation.ContainsKey(ID))
                            {
                                DicChangeCrossLocation.Add(ID, ID);
                            }
                        }
                        else
                        {
                            dX = info.x;
                            dY = info.y;
                        }

                        ObjectCross cross = new ObjectCross(ID);
                        cross.CaptionText = info.name;
                        cross.CaptionVisibility = System.Windows.Visibility.Collapsed;
                        cross.SetObjToolTip(info.name, System.Windows.Media.Colors.Red);
                        cross.X = dX;
                        cross.Y = dY;
                        cross.IsEditEnabled = true;
                        cross.MoveChange += cross_MoveChange;
                        cross.CustomMouseClick += cross_CustomMouseClick;
                        cross.CustomMouseDoubleClick += cross_CustomMouseDoubleClick;

                        MapControl.AddObject(ObjectLayerCrossKey, cross, IconKey.CrossLengend);

                        ObjectCross Minicross = new ObjectCross(ID);
                        Minicross.CaptionText = info.name;
                        Minicross.CaptionVisibility = System.Windows.Visibility.Collapsed;
                        Minicross.SetObjToolTip(info.name, System.Windows.Media.Colors.Red);
                        Minicross.X = dX;
                        Minicross.Y = dY;
                        Minicross.CustomMouseClick += cross_CustomMouseClick;
                        Minicross.CustomMouseDoubleClick += cross_CustomMouseDoubleClick;
                        MiniMapControl.AddObject(ObjectLayerCrossKey, Minicross, IconKey.CrossLengend);

                        SetMapCrossAccess(node.Nodes, dX, dY);

                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private void SetMapCrossAccess(TreeListNodes Nodes, double CrossX, double CrossY)
        {
            try
            {

                double dX = 0;
                double dY = 0;
                double dAngle = 0;
                foreach (TreeListNode node in Nodes)
                {
                    string localtype = node["LOCAL_TYPE"].ToString();
                    string ID = node["ID"].ToString();

                    CCamInfo caminfo = MV.LoadData.GetCCamInfo(ID);

                    if (caminfo == null)
                        continue;

                    IEnumerable<CCamAccessInfo> accessinfo = MV.LoadData.GetCCamAccessInfo(ID);

                    if (accessinfo == null || accessinfo.Count() <= 0)
                        continue;

                    if (localtype == LocalType.Cross && node.Level == 2) // 교차로
                    {
                        foreach (CCamAccessInfo acc in accessinfo)
                        {
                            if (acc.direction == CrossDirection.IN)
                                continue;

                            #region 좌표 초기화
                            dX = acc.x;
                            dY = acc.y;
                            dAngle = acc.angle;
                            if (dX == 0 && dY == 0 && acc.direction != CrossDirection.IN)
                            {
                                string AccessKey = string.Format("{0}&{1}", acc.cam_id, acc.direction);
                                if (!DicChangeAccessLocation.ContainsKey(AccessKey))
                                {
                                    DicChangeAccessLocation.Add(AccessKey, AccessKey);
                                }

                                if (acc.direction == CrossDirection.E)
                                {
                                    dX = CrossX + 0.0002;
                                    dY = CrossY;
                                    dAngle = 90;
                                }
                                else if (acc.direction == CrossDirection.W)
                                {
                                    dX = CrossX - 0.0002;
                                    dY = CrossY;
                                    dAngle = 270;
                                }
                                else if (acc.direction == CrossDirection.S)
                                {
                                    dX = CrossX;
                                    dY = CrossY - 0.0002;
                                    dAngle = 180;
                                }
                                else if (acc.direction == CrossDirection.N)
                                {
                                    dX = CrossX;
                                    dY = CrossY + 0.0002;
                                    dAngle = 0;
                                }
                                if (acc.direction == CrossDirection.NE)
                                {
                                    dX = CrossX + 0.0002;
                                    dY = CrossY + 0.0002;
                                    dAngle = 45;
                                }
                                else if (acc.direction == CrossDirection.NW)
                                {
                                    dX = CrossX - 0.0002;
                                    dY = CrossY + 0.0002;
                                    dAngle = 315;
                                }
                                else if (acc.direction == CrossDirection.SE)
                                {
                                    dX = CrossX + 0.0002;
                                    dY = CrossY - 0.0002;
                                    dAngle = 135;
                                }
                                else if (acc.direction == CrossDirection.SW)
                                {
                                    dX = CrossX - 0.0002;
                                    dY = CrossY - 0.0002;
                                    dAngle = 225;
                                }
                                else
                                {
                                    dX = CrossX;
                                    dY = CrossY;
                                    dAngle = 0;
                                }
                            }
                            #endregion

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
                            access.IsEditEnabled = true;
                            access.MoveChange += access_MoveChange;
                            access.CustomMouseClick += access_CustomMouseClick;
                            MapControl.AddObject(ObjectLayerAccessKey, access);

                            ObjectCrossArrow Miniaccess = new ObjectCrossArrow(AccessId);
                            Miniaccess.CaptionText = AccessName;
                            Miniaccess.CaptionVisibility = System.Windows.Visibility.Collapsed;
                            Miniaccess.SetObjToolTip(AccessName, System.Windows.Media.Colors.Red);
                            Miniaccess.X = dX;
                            Miniaccess.Y = dY;
                            Miniaccess.Angle = dAngle;
                            Miniaccess.CustomMouseClick += access_CustomMouseClick;
                            MiniMapControl.AddObject(ObjectLayerAccessKey, Miniaccess);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }

            return ;
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

                        CrossInfo crossinfo = MV.LoadData.GetCrossInfo(SelectCrossID);

                        if (crossinfo != null)
                        {
                            gcMiniMapTitle.Text = crossinfo.name;
                        }

                        ObjectCross cross = MapControl.GetObject(ObjectLayerCrossKey, SelectCrossID) as ObjectCross;

                        if (cross != null)
                        {
                            MapControl.MoveMap(cross.X, cross.Y);

                            if (crossinfo.zoom_level <= 0)
                            {
                                MiniMapControl.MoveMap(cross.X, cross.Y, IniData.MapMaxZoomLevel);
                            }
                            else
                            {
                                MiniMapControl.MoveMap(cross.X, cross.Y, (int)crossinfo.zoom_level);
                            }
                        }
                        else if (crossinfo != null)
                        {
                            MapControl.MoveMap(crossinfo.x, crossinfo.y);

                            if (crossinfo.zoom_level <= 0)
                            {
                                MiniMapControl.MoveMap(crossinfo.x, crossinfo.y, IniData.MapMaxZoomLevel);
                            }
                            else
                            {
                                MiniMapControl.MoveMap(crossinfo.x, crossinfo.y, (int)crossinfo.zoom_level);
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
        #endregion
        #region 맵 이벤트
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

        void MiniMapControl_MoveMapEvent(object sender, MapControl.MoveMapArgs e)
        {
            try
            {
                if (e.Z >= 15)
                {
                    MiniMapControl.SetObjectLayerVisible(ObjectLayerAccessKey, true);
                }
                else
                {
                    MiniMapControl.SetObjectLayerVisible(ObjectLayerAccessKey, false);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void cross_MoveChange(object sender, ObjectBase.MoveEventArgs e)
        {
            try
            {
                TreeListNode node = tlLocal.FindNodeByKeyID(e.Key);
                if (node != null)
                {
                    foreach (TreeListNode CCam in node.Nodes)
                    {
                        string CCamID = CCam["ID"].ToString();

                        IEnumerable<CCamAccessInfo> accessinfo = MV.LoadData.GetCCamAccessInfo(CCamID);

                        if (accessinfo == null)
                            continue;

                        foreach (CCamAccessInfo acc in accessinfo)
                        {
                            string AccessKey = string.Format("{0}&{1}", acc.cam_id, acc.direction);
                            ObjectCrossArrow arrow = MiniMapControl.GetObject(ObjectLayerAccessKey, AccessKey) as ObjectCrossArrow;

                            if (arrow != null)
                            {
                                double MoveX = arrow.X + (e.X - e.OldX);
                                double MoveY = arrow.Y + (e.Y - e.OldY);

                                MapControl.SetObjectMove(ObjectLayerAccessKey, AccessKey, MoveX, MoveY);
                                MiniMapControl.SetObjectMove(ObjectLayerAccessKey, AccessKey, MoveX, MoveY);

                                if (!DicChangeAccessLocation.ContainsKey(AccessKey))
                                    DicChangeAccessLocation.Add(AccessKey, AccessKey);
                            }
                        }
                    }

                    MiniMapControl.SetObjectMove(ObjectLayerCrossKey, e.Key, e.X, e.Y);

                    if (!DicChangeCrossLocation.ContainsKey(e.Key))
                        DicChangeCrossLocation.Add(e.Key, e.Key);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void access_MoveChange(object sender, ObjectBase.MoveEventArgs e)
        {
            try
            {
                MiniMapControl.SetObjectMove(ObjectLayerAccessKey, e.Key, e.X, e.Y, e.Angle);

                if (!DicChangeAccessLocation.ContainsKey(e.Key))
                    DicChangeAccessLocation.Add(e.Key, e.Key);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void cross_CustomMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                {
                    ObjectCross cross = sender as ObjectCross;

                    if (cross != null)
                    {
                        TreeListNode node = tlLocal.FindNodeByFieldValue("ID", cross.Key);

                        if (node != null)
                        {
                            tlLocal.Selection.Clear();
                            tlLocal.FocusedNode = node;
                            node.Selected = true;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void cross_CustomMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {

                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                {
                    ObjectCross cross = sender as ObjectCross;

                    if (cross != null)
                    {
                        TreeListNode node = tlLocal.FindNodeByFieldValue("ID", cross.Key);

                        if (node != null)
                        {
                            tlLocal.Selection.Clear();
                            tlLocal.FocusedNode = node;
                            node.Selected = true;

                            if (DicChangeAccessLocation.Count > 0 || DicChangeCrossLocation.Count > 0)
                            {
                                if (DevExpress.XtraEditors.XtraMessageBox.Show(this, "변경된 위치정보가 있습니다.\n저장 하시겠습니까?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                                {
                                    SaveMapLocation();
                                }
                            }

                            ManageCrossAdd ManageCrossAdd = new ManageCrossAdd();
                            ManageCrossAdd.GroupID = node["PARENT_ID"].ToString();
                            ManageCrossAdd.CrossID = node["ID"].ToString();
                            ManageCrossAdd.ShowDialog(this);

                            LoadLocal();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        void access_CustomMouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
                {
                    ObjectCrossArrow access = sender as ObjectCrossArrow;

                    if (access != null)
                    {
                        List<string> AccessKey = new List<string>();
                        AccessKey.AddRange(access.Key.Split(new string[] { "&" }, StringSplitOptions.RemoveEmptyEntries));

                        if (AccessKey.Count >= 2)
                        {
                            TreeListNode node = tlLocal.FindNodeByFieldValue("ID", AccessKey[0]);

                            if (node != null)
                            {
                                tlLocal.Selection.Clear();
                                tlLocal.FocusedNode = node;
                                node.Selected = true;

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
        #endregion
        #region 맵 위치정보 저장
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveMapLocation();
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }

        private bool SaveMapLocation()
        {
            bool result = true;
            try
            {

                foreach (string key in DicChangeCrossLocation.Values)
                {
                    var obj = MapControl.GetObject(ObjectLayerCrossKey, key);

                    string sql = string.Empty;

                    if (obj is ObjectCross)
                    {
                        ObjectCross cross = obj as ObjectCross;

                        sql = string.Format(MV.SQL.U_MST_CROSS_LOCATION, cross.Key, cross.X, cross.Y);
                        if (MV.DbManager.Excute(sql) < 0)
                        {
                            MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 위치 저장 실패 : {0}", MV.DbManager.GetErrorMsg())));
                            //MV.InsertDBLog(LogType.Error, string.Format("* 교차로 위치 저장 실패\n교차로ID: {0}, X: {1}, Y: {2} ", cross.Key, cross.X, cross.Y));
                            result = false;
                        }
                        else
                        {
                            //MV.InsertDBLog(LogType.Nomal, string.Format("* 교차로 위치 저장 성공\n교차로ID: {0}, X: {1}, Y: {2} ", cross.Key, cross.X, cross.Y));
                        }
                    }
                }

                foreach (string key in DicChangeAccessLocation.Values)
                {
                    var obj = MapControl.GetObject(ObjectLayerAccessKey, key);

                    string sql = string.Empty;

                    if (obj is ObjectCrossArrow)
                    {
                        ObjectCrossArrow access = obj as ObjectCrossArrow;

                        List<string> AccessKey = new List<string>();
                        AccessKey.AddRange(access.Key.Split(new string[] {"&"}, StringSplitOptions.RemoveEmptyEntries));

                        if (AccessKey.Count < 2)
                        {
                            //MV.InsertDBLog(LogType.Error, string.Format("* 접근로 위치 저장 실패\n접근로ID: {0}, X: {1}, Y: {2}, Angle: {3} ", access.Key, access.X, access.Y, access.Angle));
                        }
                        else
                        {
                            sql = string.Format(MV.SQL.U_MST_CCAM_ACCESS_LOCATION, AccessKey[0], AccessKey[1], access.X, access.Y, access.Angle);
                            if (MV.DbManager.Excute(sql) < 0)
                            {
                                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("접근로 위치 저장 실패 : {0}", MV.DbManager.GetErrorMsg())));
                                //MV.InsertDBLog(LogType.Error, string.Format("* 접근로 위치 저장 실패\n접근로ID: {0}, 방향: {1}, X: {2}, Y: {3}, Angle: {4} ", AccessKey[0], MV.CrossDirection.GetName(AccessKey[1]), access.X, access.Y, access.Angle));
                                result = false;
                            }
                            else
                            {
                                //MV.InsertDBLog(LogType.Nomal, string.Format("* 접근로 위치 저장 성공\n접근로ID: {0}, 방향: {1}, X: {2}, Y: {3}, Angle: {4} ", AccessKey[0], MV.CrossDirection.GetName(AccessKey[1]), access.X, access.Y, access.Angle));
                            }
                        }
                    }
                }

               

                if (result)
                    XtraMessageBox.Show("저장 성공.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    XtraMessageBox.Show("저장 실패.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                if(DicChangeCrossLocation.Count > 0 ||  DicChangeAccessLocation.Count > 0)
                {
                    DicChangeCrossLocation.Clear();
                    DicChangeAccessLocation.Clear();
                    LoadLocal();
                }
               
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                XtraMessageBox.Show("저장 실패.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return result;
        }
        #endregion
        #region 미니맵 줌 저장
        private void btnMiniMapSave_Click(object sender, EventArgs e)
        {
            bool result = true;
            
            try
            {

                if (!string.IsNullOrEmpty(SelectCrossID) && tlLocal.FindNodeByKeyID(SelectCrossID) != null)
                {
                    var center = MiniMapControl.GetCenterPoint3D();
                    
                    string sql = string.Format(MV.SQL.U_MST_CROSS_ZOOMLEVEL, SelectCrossID, center.Z);
                    if (MV.DbManager.Excute(sql) < 0)
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("미니맵 Zoom 저장 실패 : {0}", MV.DbManager.GetErrorMsg())));
                        //MV.InsertDBLog(LogType.Error, string.Format("* 미니맵 Zoom 저장 실패\n교차로ID: {0}, ZoomLevel: {1} ", SelectCrossID, center.Z));
                        result = false;
                    }
                    else
                    {
                        MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("미니맵 Zoom 저장 성공 - 교차로ID: {0}, ZoomLevel: {1} ", SelectCrossID, center.Z)));
                        //MV.InsertDBLog(LogType.Nomal, string.Format("* 미니맵 Zoom 저장 성공\n교차로ID: {0}, ZoomLevel: {1} ", SelectCrossID, center.Z));
                    }

                    if (result)
                        XtraMessageBox.Show("저장 성공.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        XtraMessageBox.Show("저장 실패.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocal();
                }
                else
                    XtraMessageBox.Show("교차로 선택 후 저장해 주세요.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
                XtraMessageBox.Show("저장 실패.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region 맵 명칭 보기
        private void chkMapShowCaption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, chkMapShowCaption.Checked);
                MapControl.SetObjectAllCaptionVisible(ObjectLayerAccessKey, chkMapShowCaption.Checked);
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region 미니맵 명칭 보기
        private void chkMiniMapShowCaption_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                MiniMapControl.SetObjectAllCaptionVisible(ObjectLayerCrossKey, chkMiniMapShowCaption.Checked);
                MiniMapControl.SetObjectAllCaptionVisible(ObjectLayerAccessKey, chkMiniMapShowCaption.Checked);
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

    }
}