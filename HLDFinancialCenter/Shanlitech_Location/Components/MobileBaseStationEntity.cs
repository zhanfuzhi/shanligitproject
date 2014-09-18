/********************************************************************************
    File:
          MobileBaseStationEntity.cs
    Description:
          移动运营商基站数据实体类
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
    ///MobileBaseStationEntity实体类(移动运营商基站数据)
    ///</summary>
    [Serializable]
    public partial class MobileBaseStationEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // 自增主键
        private String _lac=""; // 区域标识
        private String _cid=""; // 基站标识
        private String _mcc=""; // 国家标识
        private String _mnc=""; // 运营商标识
        private Int32 _signalStrength=0; // 信号强度
        private Int32 _locationDataID=0; // 与定位数据的外键关联
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
        /// 区域标识
        /// </summary>
        public String  lac
        {
            set { this._lac = value; }
            get { return this._lac; }
        }
            
        /// <summary>
        /// 基站标识
        /// </summary>
        public String  cid
        {
            set { this._cid = value; }
            get { return this._cid; }
        }
            
        /// <summary>
        /// 国家标识
        /// </summary>
        public String  mcc
        {
            set { this._mcc = value; }
            get { return this._mcc; }
        }
            
        /// <summary>
        /// 运营商标识
        /// </summary>
        public String  mnc
        {
            set { this._mnc = value; }
            get { return this._mnc; }
        }
            
        /// <summary>
        /// 信号强度
        /// </summary>
        public Int32  signalStrength
        {
            set { this._signalStrength = value; }
            get { return this._signalStrength; }
        }
            
        /// <summary>
        /// 与定位数据的外键关联
        /// </summary>
        public Int32  locationDataID
        {
            set { this._locationDataID = value; }
            get { return this._locationDataID; }
        }
            
        #endregion
    }
}
  