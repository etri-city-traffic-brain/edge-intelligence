using Common;
using RexMapControl.Object;
using RexMapControl.Section;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetupSmartCross.DataBase
{
    public enum LoadType
    {
        None = 0x0000000,
        LoadLocalData = 0x0001000,

    }
    public class LoadData
    {
        public event EventHandler LoadLocalDataBegin = null;
        public event EventHandler LoadLocalDataEnd = null;
        public event EventHandler LoadStatusEnd = null;


        private DataTable _dtLocal = new DataTable();
        public DataTable dtLocal
        {
            get { return _dtLocal.Copy(); }
        }

        private DataTable _dtStatusInfo = new DataTable();
        public DataTable dtStatusInfo
        {
            get { return _dtStatusInfo.Copy(); }
        }

        private List<LocalGroupInfo> ListLocalGroupInfo = new List<LocalGroupInfo>();
        private List<CrossInfo> ListCrossInfo = new List<CrossInfo>();

        private List<CCamInfo> ListCCamInfo = new List<CCamInfo>();
        private List<CCamAccessInfo> ListCCamAccessInfo = new List<CCamAccessInfo>();

        private Thread _thread = null;
        private bool _Terminated = false;
        private List<LoadType> _Items = new List<LoadType>();

        public LoadData()
        {
        }

        #region 로그
        public static void MakeLog(string sLog, int bScreen = 1)
        {
            string sMsg;

            sMsg = string.Format("[{0}] {1}", System.Reflection.MethodBase.GetCurrentMethod().ReflectedType.Name, sLog);
            if (MV.LogCtrl != null)
                MV.LogCtrl.AddLog(sMsg, bScreen);
        }
        #endregion

        #region 스레드 종료
        public virtual void Close()
        {
            _Terminated = true;

            if (null != _thread)
            {
                _thread.Abort();
                _thread = null;
            }
        }
        #endregion

        #region 스레드 시작
        public void Start()
        {
            _thread = new Thread(new ParameterizedThreadStart(Run));
            _thread.Start(this);
        }
        #endregion

        #region 스레드 동작
        private void Run(object obj)
        {
            while (!_Terminated)
            {
                Thread.Sleep(1);

                if (_Items.Count > 0)
                {

                    try
                    {
                        LoadType item = LoadType.None;
                        lock (_Items)
                        {
                            item = _Items[0];
                        }

                        if (item != LoadType.None && _Items.Count < 100)
                        {
                            if ((item & LoadType.LoadLocalData) == LoadType.LoadLocalData)
                            {
                                LoadLocalData();
                            }
                        }

                        lock (_Items)
                        {
                            _Items.Remove(item);
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }

            }
        }
        #endregion
        #region 추가
        public void AddItem(LoadType item)
        {
            lock (_Items)
            {
                _Items.Add(item);
            }
        }
        #endregion
        #region 갯수
        public int GetCount()
        {
            int count = 0;
            if (!_Terminated)
            {
                lock (_Items)
                {
                    count = _Items.Count;
                }
            }
            return count;
        }
        #endregion

        #region LoadLocalData
        private void LoadLocalData()
        {
            try
            {
                if (LoadLocalDataBegin != null)
                {
                    EventArgs e = new EventArgs();
                    LoadLocalDataBegin(this, e);
                }

                _dtLocal.Clear();
                string sql = string.Format(MV.SQL.S_MST_LOCAL_GROUP_TREE, LocalType.Cross, (int)TreeLocalIcon.Road);
                if (MV.DbManager.Fill(sql, _dtLocal) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장 정보 로딩실패.")));
                    MakeLog(string.Format("[{0}] - {1} \n{2}", System.Reflection.MethodBase.GetCurrentMethod().Name, sql, MV.DbManager.GetErrorMsg()));
                }

                LoadMstLocalGroup();

                LoadMstCross();

                LoadMstCCam();

                LoadMstListCCamAccess();

                if (LoadLocalDataEnd != null)
                {
                    EventArgs e = new EventArgs();
                    LoadLocalDataEnd(this, e);
                }

                if (LoadStatusEnd != null)
                {
                    EventArgs e = new EventArgs();
                    LoadStatusEnd(this, e);
                }

            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region LoadMstLocalGroup
        private void LoadMstLocalGroup()
        {
            try
            {
                string sql = string.Format(MV.SQL.S_MST_LOCAL_GROUP_INFO);
                DataTable dt = new DataTable();
                if (MV.DbManager.Fill(sql, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("현장 그룹 정보 로딩실패.")));
                    MakeLog(string.Format("[{0}] - {1} \n{2}", System.Reflection.MethodBase.GetCurrentMethod().Name, sql, MV.DbManager.GetErrorMsg()));
                }

                ListLocalGroupInfo.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    LocalGroupInfo info = new LocalGroupInfo();

                    info.id = dr["ID"].ToString();
                    info.parent_id = dr["PARENT_ID"].ToString();
                    info.name = dr["NAME"].ToString();
                    info.level = dr["LEVEL"].ToString();
                    info.local_type = dr["LOCAL_TYPE"].ToString();

                    ListLocalGroupInfo.Add(info);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region LoadMstCross
        private void LoadMstCross()
        {
            try
            {
                string sql = string.Format(MV.SQL.S_MST_CROSS_INFO);
                DataTable dt = new DataTable();
                if (MV.DbManager.Fill(sql, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 정보 로딩실패.")));
                    MakeLog(string.Format("[{0}] - {1} \n{2}", System.Reflection.MethodBase.GetCurrentMethod().Name, sql, MV.DbManager.GetErrorMsg()));
                }

                ListCrossInfo.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    CrossInfo info = new CrossInfo();
                    double temp = 0;
                    info.cross_id = dr["CROSS_ID"].ToString();
                    info.name = dr["NAME"].ToString();
                    info.cross_type = dr["CROSS_TYPE"].ToString();
                    double.TryParse(dr["X"].ToString(), out temp);
                    info.x = temp;
                    double.TryParse(dr["Y"].ToString(), out temp);
                    info.y = temp;
                    double.TryParse(dr["ZOOM_LEVEL"].ToString(), out temp);
                    info.zoom_level = temp;
                    info.local_group_id = dr["LOCAL_GROUP_ID"].ToString();

                    ListCrossInfo.Add(info);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion

        #region LoadMstCCam
        private void LoadMstCCam()
        {
            try
            {
                string sql = string.Format(MV.SQL.S_MST_CCAM_INFO);
                DataTable dt = new DataTable();
                if (MV.DbManager.Fill(sql, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 정보 로딩실패.")));
                    MakeLog(string.Format("[{0}] - {1} \n{2}", System.Reflection.MethodBase.GetCurrentMethod().Name, sql, MV.DbManager.GetErrorMsg()));
                }

                ListCCamInfo.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    CCamInfo info = new CCamInfo();

                    info.cam_id = dr["CAM_ID"].ToString();
                    info.parent_id = dr["PARENT_ID"].ToString();
                    info.name = dr["NAME"].ToString();
                    info.ip = dr["IP"].ToString();
                    info.id = dr["ID"].ToString();
                    info.pw = dr["PW"].ToString();
                    info.rtsp_url = dr["RTSP_URL"].ToString();
                    int.TryParse(dr["RTSP_PORT"].ToString(), out info.rtsp_port);
                    int.TryParse(dr["HTTP_PORT"].ToString(), out info.http_port);
                    info.cross_id = dr["CROSS_ID"].ToString();
                    info.right_use = dr["RIGHT_USE"].ToString();

                    ListCCamInfo.Add(info);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion
        #region LoadMstListCCamAccess
        private void LoadMstListCCamAccess()
        {
            try
            {
                string sql = string.Format(MV.SQL.S_MST_CCAM_ACCESS_INFO);
                DataTable dt = new DataTable();
                if (MV.DbManager.Fill(sql, dt) < 0)
                {
                    MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, string.Format("교차로 카메라 접근로 정보 로딩실패.")));
                }

                ListCCamAccessInfo.Clear();
                foreach (DataRow dr in dt.Rows)
                {
                    CCamAccessInfo info = new CCamAccessInfo();

                    info.cam_id = dr["CAM_ID"].ToString();
                    info.direction = dr["DIRECTION"].ToString();
                    info.direction_name = dr["DIRECTION_NAME"].ToString();
                    info.name = dr["NAME"].ToString();
                    double.TryParse(dr["X"].ToString(), out info.x);
                    double.TryParse(dr["Y"].ToString(), out info.y);
                    double.TryParse(dr["ANGLE"].ToString(), out info.angle);

                    ListCCamAccessInfo.Add(info);
                }
            }
            catch (Exception ex)
            {
                MakeLog(string.Format("[{0}] - {1}", System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message.Replace("'", "")));
            }
        }
        #endregion      

        #region Fill 코드 정보
        public void GetCodeInfo(string Sql, ref CodeInfo CodeInfo)
        {
            if (MV.DbManager == null)
                return;

            DataTable dt = new DataTable();
            if (MV.DbManager.Fill(Sql, dt) < 0)
                return;

            CodeInfo.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                CODEINFO item = new CODEINFO();
                item.code_id = dr["code"].ToString();
                item.code_name = dr["name"].ToString();
                CodeInfo.Add(item);
            }

            dt.Clear();
            dt.Dispose();
        }
        #endregion
        #region 신규 그룹ID 생성
        public string GetLocalGroupID(string localtype)
        {
            string ID = string.Empty;

            if (MV.DbManager == null)
                return ID;

            DataTable dt = new DataTable();

            if (MV.DbManager.Fill(MV.SQL.S_MST_LOCAL_GROUP_CROSS_NEWID, dt) < 0)
                return ID;

            foreach (DataRow dr in dt.Rows)
            {
                ID = dr["NEWID"].ToString();
                break;
            }

            return ID;
        }
        #endregion
        #region 로컬 그룹 정보 가져오기
        public LocalGroupInfo GetLocalGroupInfo(string id)
        {
            LocalGroupInfo info = null;

            if (ListLocalGroupInfo.Count <= 0)
                return info;

            info = ListLocalGroupInfo.Find(p => p.id == id);

            return info;
        }
        #endregion 
        #region 교차로 정보 가져오기
        public CrossInfo GetCrossInfo(string id)
        {
            CrossInfo info = null;

            if (ListCrossInfo.Count <= 0)
                return info;

            info = ListCrossInfo.Find(p => p.cross_id == id);

            return info;
        }
        #endregion 

        #region 교차로 카메라 정보 가져오기
        public CCamInfo GetCCamInfo(string id)
        {
            CCamInfo info = null;

            if (ListCCamInfo.Count <= 0)
                return info;

            info = ListCCamInfo.Find(p => p.cam_id == id);

            return info;
        }
        #endregion
        #region 카메라ID in 접근로 정보 가져오기
        public IEnumerable<CCamAccessInfo> GetCCamAccessInfo(string id)
        {
            if (ListCCamAccessInfo.Count <= 0)
                return null;

            return ListCCamAccessInfo.Where(p => p.cam_id == id);
        }
        #endregion

    }
}
