using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupSmartCross.DataBase
{
    class MariaSQL
    {
        
        public string S_CODE_LOCAL_TYPE = @"SELECT CODE, NAME FROM smarttraffic.mst_code WHERE grp_code = '0' and code = '0' order by seq ";

        public string S_CODE_CROSS_DIRECTION = @"SELECT CODE, NAME FROM smarttraffic.mst_code WHERE grp_code = '3' order by seq ";

        public string S_CODE_CROSS_TYPE = @"SELECT CODE, NAME FROM smarttraffic.mst_code WHERE grp_code = '4' order by seq ";

        public string S_CODE_PERMISSION = @"SELECT code, name FROM smarttraffic.mst_code WHERE grp_code = '2' order by seq ";

        public string S_MST_USER = @"SELECT USER_ID, NAME, PASSWORD, GROUP_NAME, ORGANIZATION, CLASS, CONTACT, DESCRIPTION
                                                FROM smarttraffic.MST_USER ";

        public string I_MST_USER = @"INSERT INTO smarttraffic.MST_USER
                                            (user_id, name, password, group_name, organization, class, contact, description, add_date, add_user)
                                            VALUES( '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}') ";

        public string U_MST_USER = @"UPDATE smarttraffic.MST_USER
                                            SET name='{1}', password='{2}', group_name='{3}', organization='{4}', class='{5}', contact='{6}', description='{7}', add_date='{8}', add_user='{9}'
                                            WHERE USER_ID = '{0}' ";

        public string D_MST_USER = @"DELETE FROM smarttraffic.MST_USER WHERE USER_ID = '{0}' ";

        public string S_MST_USER_USER_ID = @"SELECT * FROM smarttraffic.MST_USER WHERE USER_ID = '{0}'";

        public string S_MST_CCAM = @"SELECT A.CAM_ID AS CAM_ID_OLD, A.CAM_ID, IFNULL(A.PARENT_ID, '') as PARENT_ID, A.NAME, 
                                    D.DIRECTION,  D.DIRECTION_ID, 
                                    A.IP, A.ID, A.PW, A.RTSP_URL, A.RTSP_PORT, A.HTTP_PORT, 
                                    (select NAME from smarttraffic.mst_cross where CROSS_ID = A.CROSS_ID) as CROSS_NAME, A.CROSS_ID, A.RIGHT_USE 
                                    FROM smarttraffic.mst_ccam as A
                                    left join
                                    (
	                                    select cam_id, group_concat((select NAME from smarttraffic.mst_code where grp_code = '3' and code = DIRECTION)) as DIRECTION, group_concat(DIRECTION) as DIRECTION_ID
	                                    from smarttraffic.mst_ccam_access 
	                                    group by cam_id
	                                ) as D 
                                    on A.cam_id = D.CAM_ID
                                    {0} 
                                    order by A.CAM_ID ";



        public string S_MST_USER_GROUP = @"SELECT NAME, DESCRIPTION, PERMISSION FROM smarttraffic.MST_USER_GROUP ORDER BY NAME ";

        public string I_MST_USER_GROUP = @"INSERT INTO smarttraffic.MST_USER_GROUP
                                                    ( name, description, permission)
                                                    VALUES('{0}', '{1}', '{2}') ";

        public string U_MST_USER_GROUP = @"UPDATE smarttraffic.MST_USER_GROUP
                                                    SET description='{1}', permission='{2}'
                                                    WHERE NAME = '{0}' ";

        public string D_MST_USER_GROUP = @"DELETE FROM smarttraffic.MST_USER_GROUP WHERE NAME = '{0}' ";

        public string D_MST_USER_GROUP_USER = @"DELETE FROM smarttraffic.MST_USER WHERE GROUP_NAME = '{0}' ";

        public string S_MST_USER_GROUP_NAME = @"SELECT * FROM smarttraffic.MST_USER_GROUP WHERE NAME = '{0}'";
        
        public string D_MST_CCAM_ACCESS_CAM_ID = @"DELETE FROM smarttraffic.mst_ccam_access WHERE CAM_ID = '{0}';
                                                   DELETE FROM smarttraffic.mst_ccam WHERE CAM_ID = '{0}'; ";

        public string I_MST_CCAM = @"INSERT INTO smarttraffic.mst_ccam( CAM_ID, PARENT_ID, NAME, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, RIGHT_USE, CROSS_ID) 
                                    VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}, {8}, {9}, '{10}') ";

        public string U_MST_CCAM = @"UPDATE smarttraffic.mst_ccam
                                    SET cam_id='{1}', parent_id = '{2}', name='{3}', ip='{4}', id='{5}', pw='{6}', rtsp_url='{7}', rtsp_port={8}, http_port={9}, right_use={10}, cross_id='{11}'
                                    WHERE cam_id='{0}' ";

        public string I_MST_CCAM_ACCESS = @"INSERT INTO smarttraffic.mst_ccam_access (cam_id, direction) VALUES('{0}', '{1}') ";

        public string U_MST_CCAM_ACCESS = @"UPDATE smarttraffic.mst_ccam_access
                                    SET cam_id='{2}'
                                    WHERE cam_id='{0}' AND  direction = '{1}' ";

        public string D_MST_CCAM_ACCESS = @"DELETE FROM smarttraffic.mst_ccam_access
                                    WHERE cam_id='{0}' ";

        public string D_MST_CCAM_ACCESS_DIRECTION = @"DELETE FROM smarttraffic.mst_ccam_access
                                    WHERE cam_id='{0}' AND  direction = '{1}' ";

        public string S_MST_LOCAL_GROUP_CROSS_NEWID = @"SELECT CONCAT('C', LPAD(CAST(IFNULL(MAX(SUBSTRING(id, 5)), 0) as INT) + 1, 5, '0')) as NEWID
                                                        FROM smarttraffic.mst_local_group
                                                        where SUBSTRING(id, 1, 1) = 'C'";
        
        public string I_MST_LOCAL_GROUP = @"INSERT INTO smarttraffic.mst_local_group (id, parent_id, name, level, local_type)
                                                    VALUES('{0}', '{1}', '{2}', {3}, {4}) ";
        public string U_MST_LOCAL_GROUP = @"UPDATE smarttraffic.mst_local_group
                                        SET parent_id='{1}', name='{2}', level={3}, local_type={4}
                                        WHERE id='{0}' ";

        public string D_MST_LOCAL_GROUP = @"DELETE FROM smarttraffic.mst_local_group WHERE ID = '{0}' ";

        public string D_MST_CROSS_ID = @"DELETE FROM smarttraffic.MST_CROSS WHERE CROSS_ID = '{0}' ";

        public string U_MST_CCAM_CROSS_ID_NULL = @"UPDATE smarttraffic.MST_CCAM SET CROSS_ID = null WHERE CROSS_ID = '{0}' ";

        public string U_MST_CCAM_ACCESS_CHANGE_NULL = @"UPDATE smarttraffic.mst_ccam_access
                                                    SET x=null, y=null, angle=null
                                                    WHERE cam_id in 
                                                    (
	                                                    SELECT cam_id
	                                                    FROM smarttraffic.mst_ccam
	                                                    where cross_id <> '{0}'
                                                        and cam_id in ({1})
                                                    ) ";

        public string U_MST_CCAM_ACCESS_XY_NULL = @"UPDATE smarttraffic.mst_ccam_access
                                                    SET x=null, y=null
                                                    WHERE cam_id in ( {0} ) ";

        public string U_MST_CCAM_ACCESS_NULL = @"UPDATE smarttraffic.mst_ccam_access
                                                    SET x=null, y=null, angle=null
                                                    WHERE cam_id in 
                                                    (
	                                                    SELECT cam_id
	                                                    FROM smarttraffic.mst_ccam
	                                                    where ifnull(cross_id, '') = '' 
                                                    ) ";

        public string U_MST_CCAM_CROSS_ID = @"UPDATE smarttraffic.MST_CCAM  SET CROSS_ID = '{1}' WHERE CAM_ID IN ({0}) ";
        
        public string S_MST_LOCAL_GROUP_TREE = @"use smarttraffic;
                                                 WITH recursive TREE_QUERY (ID, PARENT_ID, NAME, level, LOCAL_TYPE )
                                                AS(
                                                    SELECT A.ID, A.PARENT_ID, A.NAME, A.level, A.LOCAL_TYPE
                                                    FROM
                                                    (
                                                        SELECT ID, PARENT_ID, NAME, level, LOCAL_TYPE
                                                        FROM smarttraffic.MST_LOCAL_GROUP AS B
                                                        WHERE LEVEL = 0
                                                        AND LOCAL_TYPE = 0
                                                    ) AS A
                                                    UNION ALL
                                                    SELECT S.ID, S.PARENT_ID, S.NAME, LEVEL + 1, S.LOCAL_TYPE
                                                    FROM
                                                    (
                                                		SELECT ID, PARENT_ID, NAME, LOCAL_TYPE
                                                    	FROM smarttraffic.MST_LOCAL_GROUP AS B
                                                    	UNION ALL
                                                        SELECT CROSS_ID AS ID, LOCAL_GROUP_ID AS PARENT_ID, NAME, {0} as LOCAL_TYPE
                                                        FROM smarttraffic.mst_cross
                                                        UNION ALL
                                                        SELECT CAM_ID AS ID, CROSS_ID AS PARENT_ID, NAME, {0} as LOCAL_TYPE
                                                        FROM smarttraffic.mst_ccam
                                                        WHERE IFNULL(PARENT_ID, '') = ''
                                                        UNION ALL
                                                        SELECT CAM_ID AS ID, PARENT_ID, NAME, {0} as LOCAL_TYPE
                                                        FROM smarttraffic.mst_ccam
                                                        WHERE IFNULL(PARENT_ID, '') <> ''
                                                    ) AS S
                                                    , TREE_QUERY AS T
                                                    WHERE S.PARENT_ID = T.ID
                                                )
                                                SELECT ID, PARENT_ID, NAME, null as CAP_DATE, 0 AS STATUSINFO, LEVEL, LOCAL_TYPE, D.DIRECTION
                                                FROM TREE_QUERY A 
                                                left join
			                                    (
				                                    select cam_id, group_concat((select NAME from smarttraffic.mst_code where grp_code = '3' and code = DIRECTION)) as DIRECTION, group_concat(DIRECTION) as DIRECTION_ID
				                                    from smarttraffic.mst_ccam_access 
				                                    group by cam_id
				                                ) as D 
			                                    on A.ID = D.CAM_ID
                                                ORDER BY NAME  ";


        public string S_MST_LOCAL_GROUP_LEVEL0 = @"SELECT ID, PARENT_ID, NAME, LEVEL, LOCAL_TYPE FROM  smarttraffic.MST_LOCAL_GROUP WHERE LEVEL = 0 and LOCAL_TYPE = {0} ORDER BY NAME ";

        public string S_MST_LOCAL_GROUP_INFO = @"SELECT ID, PARENT_ID, NAME, LEVEL, LOCAL_TYPE
                                                FROM smarttraffic.mst_local_group ";

        public string S_MST_CROSS_INFO = @"SELECT CROSS_ID, NAME, CROSS_TYPE, X, Y, ZOOM_LEVEL, LOCAL_GROUP_ID
                                           FROM smarttraffic.mst_cross ";

        public string S_MST_CCAM_INFO = @"SELECT CAM_ID, PARENT_ID, NAME, IP, ID, PW, RTSP_URL, RTSP_PORT, HTTP_PORT, CROSS_ID, RIGHT_USE
                                          FROM smarttraffic.mst_ccam
                                          order by NAME";

        public string S_MST_CCAM_ACCESS = @"SELECT CAM_ID, DIRECTION, NAME, X, Y, ANGLE
                                            FROM smarttraffic.mst_ccam_access ";

        public string S_MST_CCAM_ACCESS_INFO = @"SELECT CAM_ID, DIRECTION, (select NAME from smarttraffic.mst_code where grp_code = '3' and code = DIRECTION) as DIRECTION_NAME, NAME, X, Y, ANGLE
                                            FROM smarttraffic.mst_ccam_access ";

        public string I_MST_CROSS = @"INSERT INTO smarttraffic.mst_cross
                                        (cross_id, name, cross_type, x, y, zoom_level, local_group_id)
                                        VALUES('{0}', '{1}', '{2}', {3}, {4}, {5}, '{6}') ";       

        public string U_MST_CROSS = @"UPDATE smarttraffic.mst_cross
                                        SET cross_id='{1}', name='{2}', cross_type='{3}', x={4}, y={5}, zoom_level={6}, local_group_id='{7}'
                                        WHERE cross_id='{0}' ";

        public string U_MST_CROSS_GROUP_ID = @"UPDATE smarttraffic.mst_cross
                                        SET local_group_id='{1}'
                                        WHERE cross_id='{0}' ";

        public string U_MST_CROSS_LOCATION = @"UPDATE smarttraffic.mst_cross SET x={1}, y={2} WHERE cross_id='{0}' ";

        public string U_MST_CROSS_ZOOMLEVEL = @"UPDATE smarttraffic.mst_cross SET zoom_level={1} WHERE cross_id='{0}' ";

        public string U_MST_CCAM_ACCESS_LOCATION = @"UPDATE smarttraffic.mst_ccam_access SET x={2}, y={3}, angle={4} WHERE cam_id='{0}' and direction = '{1}' "; 

        public string S_CHECK_ID = @"select id 
                                        from 
                                        (
	                                        select cam_id as id from smarttraffic.mst_ccam where cam_id = '{0}'
	                                        union all 
	                                        select cross_id as id from smarttraffic.mst_cross where cross_id = '{0}'
	                                        union all 
	                                        select  id from  smarttraffic.mst_local_group mlg where id = '{0}'
                                        )as c ";

        public string S_CAM_CHECK_ID = @"select id 
                                        from 
                                        (
	                                        select cross_id as id from smarttraffic.mst_cross where cross_id = '{0}'
	                                        union all 
	                                        select  id from  smarttraffic.mst_local_group mlg where id = '{0}'
                                        )as c ";

        public string S_CROSS_CHECK_ID = @"select id 
                                        from 
                                        (
	                                        select cam_id as id from smarttraffic.mst_ccam where cam_id = '{0}'
	                                        union all 
	                                        select  id from  smarttraffic.mst_local_group mlg where id = '{0}'
                                        )as c ";

        public string S_LOCAL_GROUP_CHECK_ID = @"select id 
                                        from 
                                        (
	                                        select cam_id as id from smarttraffic.mst_ccam where cam_id = '{0}'
	                                        union all 
	                                        select cross_id as id from smarttraffic.mst_cross where cross_id = '{0}'
                                        )as c ";

        public string S_CARINFO = @"SELECT CAR_NUM,
                                    ROW_NUMBER() OVER(partition BY CAR_NUM ORDER BY CAR_NUM, CAP_DATE, ID) AS SEQ, T.ID, T.CROSS_ID, T.CROSS_NAME, T.CAP_DATE, T.X, T.Y,
                                    MAX(CROSS_RANK) over(partition by CAR_NUM) CROSS_COUNT,
                                    COUNT(*) over (partition by CAR_NUM) as POINT_COUNT
                                    FROM 
                                    (
	                                     SELECT C.ID, C.CROSS_ID, MC.NAME AS CROSS_NAME, C.CAP_DATE, C.CAR_NUM, MC.X, MC.Y,
	                                     CASE WHEN MC.name IS NULL THEN 0 ELSE DENSE_RANK() over (partition BY C.CAR_NUM order by C.CAR_NUM, C.CROSS_ID) END as CROSS_RANK
                                        FROM SMARTTRAFFIC.CARINFO AS C
                                        LEFT JOIN
                                        SMARTTRAFFIC.MST_CROSS MC
                                        ON C.CROSS_ID = MC.CROSS_ID
                                        WHERE C.CAP_DATE > '{0}'
                                        AND C.CAP_DATE < '{1}'
                                    ) as T
                                    ORDER BY CAR_NUM, CAP_DATE, ID";

        public string S_TRI_CROSS_5MIN = @"SELECT T.CROSS_ID, T.CAM_ID, C.NAME as CAM_NAME, T.DIRECTION,  (select NAME from smarttraffic.mst_code where grp_code = '3' and code = T.DIRECTION) as DIRECTION_NAME, T.CAP_DATE, T.OCC, T.VOL, T.SPD, T.QUEUE
                                            FROM SMARTTRAFFIC.TRI_CROSS_5MIN as T, SMARTTRAFFIC.MST_CCAM as C
                                            WHERE T.CAP_DATE > DATE_ADD('{0}', INTERVAL -17 MINUTE)
                                            and T.CAM_ID = C.CAM_ID";

        public string S_TRI_CROSS_5MIN_LOG = @"SELECT T.CROSS_ID, T.CAM_ID, C.NAME as CAM_NAME, T.DIRECTION,  (select NAME from smarttraffic.mst_code where grp_code = '3' and code = T.DIRECTION) as DIRECTION_NAME, T.CAP_DATE, T.OCC, T.VOL, T.SPD, T.QUEUE
                                            FROM SMARTTRAFFIC.TRI_CROSS_5MIN_LOG as T, SMARTTRAFFIC.MST_CCAM as C
                                            WHERE T.CAP_DATE = '{0}'
                                            and T.CAM_ID = C.CAM_ID";

        public string I_MST_LINK = @"INSERT INTO smarttraffic.mst_link
                                        (link_id, name, s_cross_id, e_cross_id, distance, min_traveltime, max_traveltime,fast_speed,slow_speed,view_flag)
                                        VALUES('{0}', '{1}', '{2}', '{3}', {4}, {5}, {6}, {7}, {8},'{9}') ";

        public string U_MST_LINK = @"UPDATE smarttraffic.mst_link
                                        SET name='{1}', distance = {2}, min_traveltime={3}, max_traveltime={4},fast_speed ={5},slow_speed={6},view_flag ='{7}'
                                        WHERE link_id='{0}' ";

        public string U_MST_LINK_TRAVELTIME = @"UPDATE smarttraffic.mst_link
                                        SET distance = {1}, min_traveltime={2}, max_traveltime={3}
                                        WHERE link_id='{0}' ";

        public string D_MST_LINK_POINT = @"DELETE from smarttraffic.mst_link_point
                                            WHERE link_id='{0}' ";

        public string D_MST_LINK = @"DELETE from smarttraffic.mst_link
                                            WHERE link_id='{0}' ";

        public string I_MST_LINK_POINT = @"INSERT INTO smarttraffic.mst_link_point
                                        (link_id, seq, x, y)
                                        VALUES('{0}', {1}, {2}, {3}) ";

        public string S_MST_LINK = @"SELECT link_id, name, s_cross_id, e_cross_id, distance, min_traveltime, max_traveltime, fast_speed, slow_speed, view_flag
                                             FROM smarttraffic.mst_link  
                                         ORDER BY link_id desc";

        public string S_MST_LINK_CAPDATE = @"SELECT ml.link_id, cap_date, ifnull(vol, 0) as vol, ifnull(spd, 0) as spd, ifnull(traveltime, 0) as traveltime, view_flag
                                            FROM smarttraffic.mst_link ml 
                                            left join smarttraffic.tri_link_5min_log tlm on ml.link_id = tlm.link_id and cap_date >= subdate(now(), INTERVAL 15 minute)
                                            WHERE view_flag = '1'
                                            ORDER BY link_id,cap_date desc;";

        public string S_MST_LINK_POINT = @"SELECT b.link_id, b.seq, b.x, b.y
                                             FROM smarttraffic.mst_link a, smarttraffic.mst_link_point b
                                            WHERE a.link_id = b.link_id
                                         ORDER BY link_id,seq ";

        public string S_MST_LINK_UPDATE = @"SELECT b.link_id, b.seq, b.X, b.Y
                                             FROM smarttraffic.mst_link a, smarttraffic.mst_link_point b
                                            WHERE a.link_id = b.link_id
                                              AND a.link_id = '{0}' 
                                         ORDER BY link_id,seq ";
        
        public string S_MST_LINK_LAST = @"select link_id from smarttraffic.mst_link order by link_id desc limit 1";

        public string S_LINK_INFO = @"select link_id as 'ID', name as 'NAME', (select name from smarttraffic.mst_cross where cross_id = s_cross_id) as 'START', 
                                    (select name from smarttraffic.mst_cross where cross_id = e_cross_id) as 'END',
                                    s_cross_id, e_cross_id, min_traveltime, max_traveltime, round(fast_speed), round(slow_speed), distance, view_flag from smarttraffic.mst_link";


        public string S_TRI_LINK_LOG = @"select ROUND(@rownum := (@rownum+1), 0) AS ROWNUM,t.*
                                                 from
                                                (
	                                                select mcs.name as s_cross_id,mce.name as e_cross_id, m.link_id,m.name, cap_date, car_num, round(spd, 2) as spd, traveltime, view_flag,s_cap_date,e_cap_date
                                                      from
		                                                    (
			                                                    SELECT distinct ml.link_id,ml.name, cap_date, car_num, spd, traveltime, view_flag , s_cross_id,e_cross_id,e_cap_date,s_cap_date
			                                                      FROM smarttraffic.mst_link ml
			                                                      join smarttraffic.tri_link_log tlm on ml.link_id = tlm.link_id
			                                                      join smarttraffic.mst_cross mc on mc.cross_id in (ml.s_cross_id, ml.e_cross_id)
			                                                      join smarttraffic.mst_local_group mlg on mc.local_group_id = mlg.id and mlg.local_type = 0
 			                                                       where view_flag = '1' 
			                                                       AND cap_date >= '{0}' 
			                                                       AND cap_date < '{1}'
                                                                   {2}
                                                                   limit {3}, {4}
	                                                         ) as m 
		                                            left join smarttraffic.mst_cross mcs on mcs.cross_id = m.s_cross_id
		                                            left join smarttraffic.mst_cross mce on mce.cross_id = m.e_cross_id 
                                                ) as t,(SELECT @rownum :=(0+{3})) as rowtb ORDER BY link_id,cap_date ";

        public string S_TRI_LINK_LOG_COUNT = @"select count(*) as LINK_LOG_COUNT
                                                 from
                                                (
	                                                select mcs.name as s_cross_id,mce.name as e_cross_id, m.link_id,m.name, cap_date, car_num, round(spd, 2) as spd, traveltime, view_flag,s_cap_date,e_cap_date
                                                      from
		                                                    (
			                                                    SELECT distinct ml.link_id,ml.name, cap_date, car_num, spd, traveltime, view_flag , s_cross_id,e_cross_id,e_cap_date,s_cap_date
			                                                      FROM smarttraffic.mst_link ml
			                                                      join smarttraffic.tri_link_log tlm on ml.link_id = tlm.link_id
			                                                      join smarttraffic.mst_cross mc on mc.cross_id in (ml.s_cross_id, ml.e_cross_id)
			                                                      join smarttraffic.mst_local_group mlg on mc.local_group_id = mlg.id and mlg.local_type = 0
 			                                                       where view_flag = '1' 
			                                                       AND cap_date >= '{0}' 
			                                                       AND cap_date < '{1}'
                                                                   {2}
	                                                         ) as m 
		                                            left join smarttraffic.mst_cross mcs on mcs.cross_id = m.s_cross_id
		                                            left join smarttraffic.mst_cross mce on mce.cross_id = m.e_cross_id 
                                                ) as t  ";

        public string S_TRI_LINK_STATS = @"select * from smarttraffic.mst_link";

        public string S_TRI_LINK_STATS_LOG = @"select ROUND(@rownum := @rownum+1, 0) AS ROWNUM, s_cross_id,e_cross_id, link_id,name, cap_date, vol, spd, traveltime, view_flag 
                                                 from
                                                (
	                                                select mcs.name as s_cross_id,mce.name as e_cross_id, m.link_id,m.name, cap_date, vol, spd, traveltime, view_flag
                                                      from
		                                                    (
			                                                     SELECT distinct ml.link_id,ml.name, cap_date, vol, spd, traveltime, view_flag , s_cross_id,e_cross_id
																FROM smarttraffic.mst_link ml
			                                                      join smarttraffic.tri_link_5min_log tlm on ml.link_id = tlm.link_id
			                                                      join smarttraffic.mst_cross mc on mc.cross_id in (ml.s_cross_id, ml.e_cross_id)
			                                                      join smarttraffic.mst_local_group mlg on mc.local_group_id = mlg.id and mlg.local_type = 0
 			                                                       where view_flag = '1' 
			                                                       AND cap_date >= '{0}' 
			                                                       AND cap_date < '{1}'
                                                                   {2}
	                                                         ) as m 
		                                            left join smarttraffic.mst_cross mcs on mcs.cross_id = m.s_cross_id
		                                            left join smarttraffic.mst_cross mce on mce.cross_id = m.e_cross_id 
                                                ) as t,(SELECT @rownum :=0) as rowtb ORDER BY link_id,cap_date;";

        public string S_TRI_LINK_STATS_15_LOG = @"select ROUND(@rownum := @rownum+1, 0) AS ROWNUM, s_cross_id,e_cross_id, link_id,name, cap_date, vol, spd, traveltime, view_flag 
											 from
											(
												select mcs.name as s_cross_id,mce.name as e_cross_id, m.link_id,m.name, cap_date, 
												sum(vol) as vol, ifnull(avg(case when spd = 0 then null else spd end), 0) as spd, ifnull(avg(case when traveltime = 0 then null else traveltime end), 0) as traveltime, view_flag
												  from
														(
															 SELECT distinct ml.link_id,ml.name, case when date_format(cap_date, '%i') < 15 then date_format(cap_date, '%Y-%m-%d %H:00:00')
																	  when date_format(cap_date, '%i') < 30 then date_format(cap_date, '%Y-%m-%d %H:15:00')
																	  when date_format(cap_date, '%i') < 45 then date_format(cap_date, '%Y-%m-%d %H:30:00')
																	  when date_format(cap_date, '%i') < 60 then date_format(cap_date, '%Y-%m-%d %H:45:00') end as cap_date, 
															vol, spd, traveltime, view_flag , s_cross_id,e_cross_id
															FROM smarttraffic.mst_link ml
															  join smarttraffic.tri_link_5min_log tlm on ml.link_id = tlm.link_id
															  join smarttraffic.mst_cross mc on mc.cross_id in (ml.s_cross_id, ml.e_cross_id)
															  join smarttraffic.mst_local_group mlg on mc.local_group_id = mlg.id and mlg.local_type = 0
															    where view_flag = '1' 
				   												AND cap_date >= '{0}' 
			                                                    AND cap_date < '{1}'
                                                                {2}
														 ) as m 
												left join smarttraffic.mst_cross mcs on mcs.cross_id = m.s_cross_id
												left join smarttraffic.mst_cross mce on mce.cross_id = m.e_cross_id 
												group by link_id, cap_date
											) as t,(SELECT @rownum :=0) as rowtb 
											ORDER BY link_id, cap_date;";

        public string S_TRI_LINK_STATS_OTHER_LOG = @"select ROUND(@rownum := @rownum+1, 0) AS ROWNUM, s_cross_id,e_cross_id, link_id,name, cap_date, vol, spd, traveltime, view_flag 
											 from
											(
												select mcs.name as s_cross_id,mce.name as e_cross_id, m.link_id,m.name, cap_date, 
												sum(vol) as vol, ifnull(avg(case when spd = 0 then null else spd end), 0) as spd, ifnull(avg(case when traveltime = 0 then null else traveltime end), 0) as traveltime, view_flag
												  from
														(
															 SELECT distinct ml.link_id,ml.name, date_format(cap_date, '{3}') as cap_date, vol, spd, traveltime, view_flag , s_cross_id,e_cross_id
															FROM smarttraffic.mst_link ml
															  join smarttraffic.tri_link_5min_log tlm on ml.link_id = tlm.link_id
															  join smarttraffic.mst_cross mc on mc.cross_id in (ml.s_cross_id, ml.e_cross_id)
															  join smarttraffic.mst_local_group mlg on mc.local_group_id = mlg.id and mlg.local_type = 0
															    where view_flag = '1' 
				   												AND cap_date >= '{0}' 
			                                                    AND cap_date < '{1}'
                                                                {2}
														 ) as m 
												left join smarttraffic.mst_cross mcs on mcs.cross_id = m.s_cross_id
												left join smarttraffic.mst_cross mce on mce.cross_id = m.e_cross_id 
												group by link_id, cap_date
											) as t,(SELECT @rownum :=0) as rowtb 
											ORDER BY link_id, cap_date ";

    }
}
