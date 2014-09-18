/********************************************************************************
    File:
          T_StockLogEntity.cs
    Description:
          出入库日志实体类
    Author:
          DDBuildTools
          http://FrameWork.supesoft.com
    Finish DateTime:
          2014-6-27 18:28:22
    History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using FrameWork;

namespace Shanlitech_Location.Components
{
    ///<summary>
    ///T_StockLogEntity实体类(出入库日志)
    ///</summary>
    [Serializable]
    public partial class T_StockLogEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // 自增ID
        private String _CodeNO=""; // 库存资产编码号
        private Int32 _DealType=0; // 处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
        private Int32 _Number=0; // 数量
        private Int32 _Handler=0; // 操作者
        private Int32 _StorID=0; // 入库单ID
        private Int32 _OutbID=0; // 出库单ID
        private DateTime? _LogTime; // 记录时间
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
        /// 自增ID
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 库存资产编码号
        /// </summary>
        public String  CodeNO
        {
            set { this._CodeNO = value; }
            get { return this._CodeNO; }
        }
            
        /// <summary>
        /// 处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
        /// </summary>
        public Int32  DealType
        {
            set { this._DealType = value; }
            get { return this._DealType; }
        }
            
        /// <summary>
        /// 数量
        /// </summary>
        public Int32  Number
        {
            set { this._Number = value; }
            get { return this._Number; }
        }
            
        /// <summary>
        /// 操作者
        /// </summary>
        public Int32  Handler
        {
            set { this._Handler = value; }
            get { return this._Handler; }
        }
            
        /// <summary>
        /// 入库单ID
        /// </summary>
        public Int32  StorID
        {
            set { this._StorID = value; }
            get { return this._StorID; }
        }
            
        /// <summary>
        /// 出库单ID
        /// </summary>
        public Int32  OutbID
        {
            set { this._OutbID = value; }
            get { return this._OutbID; }
        }
            
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime?  LogTime
        {
            set { this._LogTime = value; }
            get { return this._LogTime; }
        }
            
        #endregion
    }
}
  