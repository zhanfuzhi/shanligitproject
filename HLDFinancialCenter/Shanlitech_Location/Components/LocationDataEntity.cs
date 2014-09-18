/********************************************************************************
    File:
          LocationDataEntity.cs
    Description:
          定位数据表实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2013/9/12 11:04:12
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace Shanlitech_Location.Components
{
    ///<summary>
    ///LocationDataEntity实体类(定位数据表)
    ///</summary>
    [Serializable]
    public partial class LocationDataEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // 自增主键
        private String _appID=""; // 应用程序唯一标识
        private String _userID=""; // 用户唯一标识
        private Int32 _type=0; // 定位类型：
/* 0x01:GPS定位类型
0x02:基站定位类型
0x04:百度定位类型
0x08:百度 & 基站定位类型
0x10:GPS & 基站定位类型 */
        private Int32 _operator_mobile=0; // 运营商：
/* 0x01:移动
0x02:电信
0x04:联通 */
        private String _coordination=""; // 坐标系
        private String _lat=""; // 纬度
        private String _lng=""; // 经度
        private String _address=""; // 地址
        private DateTime? _locate_time; // 定位时间,注意：如果位置不发生变化定位时间是一样的
        private Int32 _error_code=0; // 错误码,暂时仅百度定位时此字段有值，其它暂时保留
        private String _code_description=""; // 错误码描述信息
        private DateTime? _create_time; // 数据创建时间，区别于定位时间
        #endregion

        #region "Public Variables"
        ///<summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除
        ///</summary>
        public DataTable_Action DataTable_Action_
        {
            set { this._DataTable_Action_ = value; }
            get { return this._DataTable_Action_; }
        }
        /// <summary>
        /// 自增主键
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 应用程序唯一标识
        /// </summary>
        public String  appID
        {
            set { this._appID = value; }
            get { return this._appID; }
        }
            
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        public String  userID
        {
            set { this._userID = value; }
            get { return this._userID; }
        }
            
        /// <summary>
        /// 定位类型：
/* 0x01:GPS定位类型
0x02:基站定位类型
0x04:百度定位类型
0x08:百度 & 基站定位类型
0x10:GPS & 基站定位类型 */
        /// </summary>
        public Int32  type
        {
            set { this._type = value; }
            get { return this._type; }
        }
            
        /// <summary>
        /// 运营商：
/* 0x01:移动
0x02:电信
0x04:联通 */
        /// </summary>
        public Int32  operator_mobile
        {
            set { this._operator_mobile = value; }
            get { return this._operator_mobile; }
        }
            
        /// <summary>
        /// 坐标系
        /// </summary>
        public String  coordination
        {
            set { this._coordination = value; }
            get { return this._coordination; }
        }
            
        /// <summary>
        /// 纬度
        /// </summary>
        public String  lat
        {
            set { this._lat = value; }
            get { return this._lat; }
        }
            
        /// <summary>
        /// 经度
        /// </summary>
        public String  lng
        {
            set { this._lng = value; }
            get { return this._lng; }
        }
            
        /// <summary>
        /// 地址
        /// </summary>
        public String  address
        {
            set { this._address = value; }
            get { return this._address; }
        }
            
        /// <summary>
        /// 定位时间,注意：如果位置不发生变化定位时间是一样的
        /// </summary>
        public DateTime?  locate_time
        {
            set { this._locate_time = value; }
            get { return this._locate_time; }
        }
            
        /// <summary>
        /// 错误码,暂时仅百度定位时此字段有值，其它暂时保留
        /// </summary>
        public Int32  error_code
        {
            set { this._error_code = value; }
            get { return this._error_code; }
        }
            
        /// <summary>
        /// 错误码描述信息
        /// </summary>
        public String  code_description
        {
            set { this._code_description = value; }
            get { return this._code_description; }
        }
            
        /// <summary>
        /// 数据创建时间，区别于定位时间
        /// </summary>
        public DateTime?  create_time
        {
            set { this._create_time = value; }
            get { return this._create_time; }
        }
            
        #endregion
    }
}
  