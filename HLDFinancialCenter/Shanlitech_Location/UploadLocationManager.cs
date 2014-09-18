using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Protobuf.Components;
using System.Threading;
using System.Data;
using System.Data.SqlClient;
using Shanlitech_Location.Data;
using System.Configuration;
using ShanliTech.LogLib;
using System.Web;

namespace Shanlitech_Location
{
    public class UploadLocationManager
    {


        private static UploadLocationManager _instance = new UploadLocationManager();
        private UploadLocationManager()
        {
        }
        public static UploadLocationManager Instance
        {
            get { return _instance; }
        }

        private static readonly Queue<Location> _Queue = new Queue<Location>();
        /// <summary>
        /// 将数据加入队列，等待批量插入数据库
        /// </summary>
        /// <param name="location"></param>
        public void AddUploadLocationInsert(Location location)
        {
            _Queue.Enqueue(location);
            //AppLogger.Instance.Log.Info("数据插入队列 >> ");
            lock (this)
            {
                if (thread != null && isReady)
                {
                    //AppLogger.Instance.Log.Info("-- 正在运行，等待 --");
                    return;
                }
                else
                {
                    AppLogger.Instance.Log.Info("线程未启动，启动 ...");
                    thread = new Thread(ReadyToInsert);
                    thread.Start();
                    isReady = true;
                }
            }
        }

        private Thread thread = null;
        readonly static string conStr = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["DBType"].ToString()].ToString();
        private bool isDoing = false;
        private bool isReady = false;
        private void ReadyToInsert()
        {
            isReady = true;
            while (true)
            {
                //开始准备插入动作


                //取出队列数据个数
                Queue<Location> syncQueue = _Queue;

                int _count = syncQueue.Count;
                if (_count > 0)
                {
                    //AppLogger.Instance.Log.Info("数据: " + _count);
                }
                else
                {
                    continue;
                }
                //syncQueue
                //lock (this)
                //{
                DateTime start = DateTime.Now;
                if (_count > 0 && !isDoing)
                {
                    isDoing = true;

                    #region 插入数据
                    DateTime a = DateTime.Now;
                    using (SqlConnection connection = new SqlConnection(conStr))
                    {
                        connection.Open();
                        SqlTransaction transaction = connection.BeginTransaction("Transaction1");

                        AppLogger.Instance.Log.Info("open connect 耗时：" + (DateTime.Now.Subtract(a).TotalMilliseconds));

                        //取出数据，放入List
                        DataTable _LocationTable = GetTableSchema("LocationData");
                        DataTable _MobileBaseStationTable = GetTableSchema("BaseStation");
                        DataTable _TelecomBaseStationTable = GetTableSchema("BaseStation");
                        DataTable _UnicomBaseStationTable = GetTableSchema("BaseStation");

                        Guid Batch = Guid.NewGuid();
                        DateTime b = DateTime.Now;
                        for (int i = 0; i < _count; i++)
                        {
                            Guid single = Guid.NewGuid();
                            Location tmp = syncQueue.Dequeue();
                            DataRow dr = _LocationTable.NewRow();

                            #region LocationData字段赋值

                            dr["_AppID"] = tmp.AppID;
                            dr["_UserID"] = tmp.UserID;
                            dr["_Type"] = tmp.Type;
                            dr["_Operator_Mobile"] = (int)BusinessFacadeShanlitech_Location.convertProtoOperatorTo(tmp.Operator);
                            dr["_Coordination"] = tmp.Coordination;
                            dr["_Lat"] = tmp.Lat;
                            dr["_Lng"] = tmp.Lng;
                            dr["_Address"] = tmp.Address;
                            dr["_Locate_Time"] = DateTime.Parse(tmp.LocateTime);
                            dr["_Error_Code"] = tmp.ErrorCode;
                            dr["_Code_Description"] = tmp.CodeDescription;
                            dr["_Create_Time"] = DateTime.Now;
                            dr["_GUID"] = single.ToString();
                            dr["_BATCH"] = Batch.ToString();

                            #endregion

                            _LocationTable.Rows.Add(dr);

                            #region BaseStationTable数据装入

                            int _Count = tmp.StationCount;
                            if (_Count > 0)
                            {
                                foreach (BaseStation item in tmp.StationList)
                                {

                                    DataRow drr = null;
                                    switch (BusinessFacadeShanlitech_Location.BaseStationType(item.Mnc))
                                    {
                                        case Enumerations.OperatorMobile.Mobile:
                                            drr = _MobileBaseStationTable.NewRow();

                                            drr["_Lac"] = item.Lac;
                                            drr["_Cid"] = item.Cid;
                                            drr["_Mcc"] = item.Mcc;
                                            drr["_Mnc"] = item.Mnc;
                                            drr["_SignalStrength"] = item.SignalStrength;
                                            //drr["_LocationDataID"]=
                                            drr["_GUID"] = single.ToString();

                                            _MobileBaseStationTable.Rows.Add(drr);
                                            break;
                                        case Enumerations.OperatorMobile.Telecom:
                                            drr = _TelecomBaseStationTable.NewRow();

                                            drr["_Lac"] = item.Lac;
                                            drr["_Cid"] = item.Cid;
                                            drr["_Mcc"] = item.Mcc;
                                            drr["_Mnc"] = item.Mnc;
                                            drr["_SignalStrength"] = item.SignalStrength;
                                            //drr["_LocationDataID"]=
                                            drr["_GUID"] = single.ToString();

                                            _TelecomBaseStationTable.Rows.Add(drr);
                                            break;
                                        case Enumerations.OperatorMobile.Unicom:
                                            drr = _UnicomBaseStationTable.NewRow();

                                            drr["_Lac"] = item.Lac;
                                            drr["_Cid"] = item.Cid;
                                            drr["_Mcc"] = item.Mcc;
                                            drr["_Mnc"] = item.Mnc;
                                            drr["_SignalStrength"] = item.SignalStrength;
                                            //drr["_LocationDataID"]=
                                            drr["_GUID"] = single.ToString();

                                            _UnicomBaseStationTable.Rows.Add(drr);
                                            break;
                                    }
                                }
                            }

                            #endregion
                        }
                        AppLogger.Instance.Log.Info("For 耗时：" + (DateTime.Now.Subtract(b).TotalMilliseconds));
                        DateTime c = DateTime.Now;
                        //执行批量插入操作
                        BulkToDB(_LocationTable, "LocationData", connection, transaction);
                        AppLogger.Instance.Log.Info("BulkToDB 耗时：" + (DateTime.Now.Subtract(c).TotalMilliseconds));
                        #region BaseStation批量插入操作
                        DateTime d = DateTime.Now;

                        DataSet _LocationTableTmp = GetNewImportData(Batch.ToString());//
                        Dictionary<string, long> dicGuidToID = new Dictionary<string, long>();
                        foreach (DataRow dr in _LocationTableTmp.Tables[0].Rows)
                        {
                            dicGuidToID.Add(dr[1].ToString(), Convert.ToInt64(dr[0]));
                        }// 
                        if (_MobileBaseStationTable.Rows.Count > 0)
                        {
                            foreach (DataRow dr in _MobileBaseStationTable.Rows)//
                            {
                                dr["_LocationDataID"] = dicGuidToID[dr["_GUID"].ToString()].ToString();
                            }
                            _MobileBaseStationTable.Columns.Remove("_GUID");//
                            BulkToDB(_MobileBaseStationTable, "MobileBaseStation", connection, transaction);//给从表插入数据  
                        }
                        if (_TelecomBaseStationTable.Rows.Count > 0)
                        {
                            foreach (DataRow dr in _TelecomBaseStationTable.Rows)//  
                            {
                                dr["_LocationDataID"] = dicGuidToID[dr["_GUID"].ToString()].ToString();
                            }
                            _TelecomBaseStationTable.Columns.Remove("_GUID");//
                            BulkToDB(_TelecomBaseStationTable, "TelecomBaseStation", connection, transaction);//给从表插入数据  
                        }
                        if (_UnicomBaseStationTable.Rows.Count > 0)
                        {
                            foreach (DataRow dr in _UnicomBaseStationTable.Rows)//
                            {
                                dr["_LocationDataID"] = dicGuidToID[dr["_GUID"].ToString()].ToString();
                            }
                            _UnicomBaseStationTable.Columns.Remove("_GUID");//
                            BulkToDB(_UnicomBaseStationTable, "UnicomBaseStation", connection, transaction);//给从表插入数据  
                        }

                        AppLogger.Instance.Log.Info("Attachment 总耗时：" + (DateTime.Now.Subtract(d).TotalMilliseconds));
                        #endregion

                        transaction.Commit();
                        connection.Close();
                    }

                    #endregion

                    isDoing = false;
                }

                AppLogger.Instance.Log.Info(_count + " 耗时：" + (DateTime.Now.Subtract(start).TotalMilliseconds));
                //}// end lock
            }// end while
            isReady = false;
        }

        public static void BulkToDB(DataTable dtSource, String TableName, SqlConnection connection, SqlTransaction transaction)
        {
            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, transaction))
            {
                sqlBulkCopy.DestinationTableName = TableName;//要插入数据的表的名称  
                sqlBulkCopy.BatchSize = dtSource.Rows.Count;//数据的行数  

                //List<SqlBulkCopyColumnMapping> mpList = getMapping(TableName);//获取表映射关系  

                //foreach (SqlBulkCopyColumnMapping mp in mpList)
                //{
                //    sqlBulkCopy.ColumnMappings.Add(mp);
                //}

                if (dtSource != null && dtSource.Rows.Count != 0)
                {
                    sqlBulkCopy.WriteToServer(dtSource);//插入数据  
                    //列“ID”不允许 DBNull.Value。
                }
            }
        }

        private static List<SqlBulkCopyColumnMapping> getMapping(string TableName)
        {
            List<SqlBulkCopyColumnMapping> mpList = new List<SqlBulkCopyColumnMapping>();
            switch (TableName.ToUpper())
            {
                case "LOCATIONDATA":
                    {
                        //mpList.Add(new SqlBulkCopyColumnMapping("_ID", "ID"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_AppID", "appID"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_UserID", "userID"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Type", "type"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Operator_Mobile", "operator_mobile"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Coordination", "coordination"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Lat", "lat"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Lng", "lng"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Address", "address"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Locate_Time", "locate_time"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Error_Code", "error_code"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Code_Description", "code_description"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Create_Time", "create_time"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_GUID", "GUID"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_BATCH", "BATCH"));
                    } break;
                default:
                    {
                        //mpList.Add(new SqlBulkCopyColumnMapping("_Id", "ID"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Lac", "lac"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Cid", "cid"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Mcc", "mcc"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_Mnc", "mnc"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_SignalStrength", "signalStrength"));
                        mpList.Add(new SqlBulkCopyColumnMapping("_LocationDataID", "locationDataID"));
                    } break;
            }
            return mpList;
        }

        public static DataTable GetTableSchema(string TableName)
        {
            DataTable dt = new DataTable();
            switch (TableName.ToUpper())
            {
                case "LOCATIONDATA":
                    dt.Columns.AddRange(new DataColumn[]{
                        new DataColumn("_ID",typeof(Int32)),
                        new DataColumn("_AppID",typeof(string)),
                        new DataColumn("_UserID",typeof(string)),
                        new DataColumn("_Type",typeof(Int32)),
                        new DataColumn("_Operator_Mobile",typeof(Int32)),
                        new DataColumn("_Coordination",typeof(string)),
                        new DataColumn("_Lat",typeof(string)),
                        new DataColumn("_Lng",typeof(string)),
                        new DataColumn("_Address",typeof(string)),
                        new DataColumn("_Locate_Time",typeof(DateTime)),
                        new DataColumn("_Error_Code",typeof(Int32)),
                        new DataColumn("_Code_Description",typeof(string)),
                        new DataColumn("_Create_Time",typeof(DateTime)),
                        new DataColumn("_GUID",typeof(string)),
                        new DataColumn("_BATCH",typeof(string))
                    });
                    break;
                default:
                    dt.Columns.AddRange(new DataColumn[] { 
                        new DataColumn("_ID",typeof(Int32)),
                        new DataColumn("_Lac",typeof(string)),
                        new DataColumn("_Cid",typeof(string)),
                        new DataColumn("_Mcc",typeof(string)),
                        new DataColumn("_Mnc",typeof(string)),
                        new DataColumn("_SignalStrength",typeof(Int32)),
                        new DataColumn("_LocationDataID",typeof(Int32)),
                        new DataColumn("_GUID",typeof(string))
                    });
                    break;

            }
            return dt;
        }
        /// <summary>  
        /// 根据批次Batch获取导进来的临时数据  
        /// </summary>  
        /// <returns></returns>  
        public static DataSet GetNewImportData(string batch)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT [ID],[GUID]")
                .Append(" FROM LocationData WITH (NOLOCK) WHERE BATCH='" + batch + "'");
            DataSet ds = BusinessFacadeShanlitech_Location.ExecuteDataset(strSql.ToString());

            return ds;
        }


        const int bufferSize = 1024;
        public void BeginInsertLocationData(HttpContext context, AsyncCallback cb)
        {
            byte[] buffer = new byte[bufferSize];
            ReadStreamAsyncData _ExtData = new ReadStreamAsyncData { Context = context, Buffer = buffer };
            context.Request.InputStream.BeginRead(buffer, 0, bufferSize, new AsyncCallback(ReadReqStreamCallBack), _ExtData);
        }
        public void ReadReqStreamCallBack(IAsyncResult ar)
        {
            ReadStreamAsyncData _State = ar.AsyncState as ReadStreamAsyncData;
            int len = _State.Context.Request.InputStream.EndRead(ar);
            if (len > 0)
            {
                byte[] buffer;
                if (len == bufferSize) buffer = _State.Buffer;
                else
                {
                    buffer = new byte[len];
                    Array.Copy(_State.Buffer, 0, buffer, 0, len);
                }
                Location loc = Protobuf.Protobuf_Codec.Decode(buffer);
                AddUploadLocationInsert(loc);
               // InsertDB(loc);
            }
        }

        class ReadStreamAsyncData
        {
            public HttpContext Context { get; set; }
            public byte[] Buffer { get; set; }
        }
        private static void InsertDB(Location loc)
        {
            DateTime a = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction("Transaction1");

                AppLogger.Instance.Log.Info("open connect 耗时：" + (DateTime.Now.Subtract(a).TotalMilliseconds));

                //取出数据，放入List
                DataTable _LocationTable = GetTableSchema("LocationData");
                DataTable _MobileBaseStationTable = GetTableSchema("BaseStation");
                DataTable _TelecomBaseStationTable = GetTableSchema("BaseStation");
                DataTable _UnicomBaseStationTable = GetTableSchema("BaseStation");

                Guid Batch = Guid.NewGuid();
                DateTime b = DateTime.Now;
                //for (int i = 0; i < _count; i++)
                //{
                    Guid single = Guid.NewGuid();
                    Location tmp = loc;
                    DataRow dr = _LocationTable.NewRow();

                    #region LocationData字段赋值

                    dr["_AppID"] = tmp.AppID;
                    dr["_UserID"] = tmp.UserID;
                    dr["_Type"] = tmp.Type;
                    dr["_Operator_Mobile"] = (int)BusinessFacadeShanlitech_Location.convertProtoOperatorTo(tmp.Operator);
                    dr["_Coordination"] = tmp.Coordination;
                    dr["_Lat"] = tmp.Lat;
                    dr["_Lng"] = tmp.Lng;
                    dr["_Address"] = tmp.Address;
                    dr["_Locate_Time"] = DateTime.Parse(tmp.LocateTime);
                    dr["_Error_Code"] = tmp.ErrorCode;
                    dr["_Code_Description"] = tmp.CodeDescription;
                    dr["_Create_Time"] = DateTime.Now;
                    dr["_GUID"] = single.ToString();
                    dr["_BATCH"] = Batch.ToString();

                    #endregion

                    _LocationTable.Rows.Add(dr);

                    #region BaseStationTable数据装入

                    int _Count = tmp.StationCount;
                    if (_Count > 0)
                    {
                        foreach (BaseStation item in tmp.StationList)
                        {

                            DataRow drr = null;
                            switch (BusinessFacadeShanlitech_Location.BaseStationType(item.Mnc))
                            {
                                case Enumerations.OperatorMobile.Mobile:
                                    drr = _MobileBaseStationTable.NewRow();

                                    drr["_Lac"] = item.Lac;
                                    drr["_Cid"] = item.Cid;
                                    drr["_Mcc"] = item.Mcc;
                                    drr["_Mnc"] = item.Mnc;
                                    drr["_SignalStrength"] = item.SignalStrength;
                                    //drr["_LocationDataID"]=
                                    drr["_GUID"] = single.ToString();

                                    _MobileBaseStationTable.Rows.Add(drr);
                                    break;
                                case Enumerations.OperatorMobile.Telecom:
                                    drr = _TelecomBaseStationTable.NewRow();

                                    drr["_Lac"] = item.Lac;
                                    drr["_Cid"] = item.Cid;
                                    drr["_Mcc"] = item.Mcc;
                                    drr["_Mnc"] = item.Mnc;
                                    drr["_SignalStrength"] = item.SignalStrength;
                                    //drr["_LocationDataID"]=
                                    drr["_GUID"] = single.ToString();

                                    _TelecomBaseStationTable.Rows.Add(drr);
                                    break;
                                case Enumerations.OperatorMobile.Unicom:
                                    drr = _UnicomBaseStationTable.NewRow();

                                    drr["_Lac"] = item.Lac;
                                    drr["_Cid"] = item.Cid;
                                    drr["_Mcc"] = item.Mcc;
                                    drr["_Mnc"] = item.Mnc;
                                    drr["_SignalStrength"] = item.SignalStrength;
                                    //drr["_LocationDataID"]=
                                    drr["_GUID"] = single.ToString();

                                    _UnicomBaseStationTable.Rows.Add(drr);
                                    break;
                            }
                        }
                    }

                    #endregion
                
                AppLogger.Instance.Log.Info("For 耗时：" + (DateTime.Now.Subtract(b).TotalMilliseconds));
                DateTime c = DateTime.Now;
                //执行批量插入操作
                BulkToDB(_LocationTable, "LocationData", connection, transaction);
                AppLogger.Instance.Log.Info("BulkToDB 耗时：" + (DateTime.Now.Subtract(c).TotalMilliseconds));
                
                #region BaseStation批量插入操作
                DateTime d = DateTime.Now;

                DataSet _LocationTableTmp = GetNewImportData(Batch.ToString());//
                Dictionary<string, long> dicGuidToID = new Dictionary<string, long>();
                foreach (DataRow ddr in _LocationTableTmp.Tables[0].Rows)
                {
                    dicGuidToID.Add(ddr[1].ToString(), Convert.ToInt64(ddr[0]));
                }// 
                if (_MobileBaseStationTable.Rows.Count > 0)
                {
                    foreach (DataRow ddr in _MobileBaseStationTable.Rows)//
                    {
                        ddr["_LocationDataID"] = dicGuidToID[ddr["_GUID"].ToString()].ToString();
                    }
                    _MobileBaseStationTable.Columns.Remove("_GUID");//
                    BulkToDB(_MobileBaseStationTable, "MobileBaseStation", connection, transaction);//给从表插入数据  
                }
                if (_TelecomBaseStationTable.Rows.Count > 0)
                {
                    foreach (DataRow ddr in _TelecomBaseStationTable.Rows)//  
                    {
                        ddr["_LocationDataID"] = dicGuidToID[ddr["_GUID"].ToString()].ToString();
                    }
                    _TelecomBaseStationTable.Columns.Remove("_GUID");//
                    BulkToDB(_TelecomBaseStationTable, "TelecomBaseStation", connection, transaction);//给从表插入数据  
                }
                if (_UnicomBaseStationTable.Rows.Count > 0)
                {
                    foreach (DataRow ddr in _UnicomBaseStationTable.Rows)//
                    {
                        ddr["_LocationDataID"] = dicGuidToID[ddr["_GUID"].ToString()].ToString();
                    }
                    _UnicomBaseStationTable.Columns.Remove("_GUID");//
                    BulkToDB(_UnicomBaseStationTable, "UnicomBaseStation", connection, transaction);//给从表插入数据  
                }

                AppLogger.Instance.Log.Info("Attachment 总耗时：" + (DateTime.Now.Subtract(d).TotalMilliseconds));
                #endregion

                transaction.Commit();
                connection.Close();
            }
        }

    }
}
