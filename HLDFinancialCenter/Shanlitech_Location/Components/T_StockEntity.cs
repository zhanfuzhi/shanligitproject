/********************************************************************************
    File:
          T_StockEntity.cs
    Description:
          库存实体类
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
    ///T_StockEntity实体类(库存)
    ///</summary>
    [Serializable]
    public partial class T_StockEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _EquipmentName=""; // 器材名称
        private String _Model=""; // 型号
        private Int32 _StockNumber=0; // 库存量
        private String _CodeNO=""; // 编码号
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
        /// ID
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 器材名称
        /// </summary>
        public String  EquipmentName
        {
            set { this._EquipmentName = value; }
            get { return this._EquipmentName; }
        }
            
        /// <summary>
        /// 型号
        /// </summary>
        public String  Model
        {
            set { this._Model = value; }
            get { return this._Model; }
        }
            
        /// <summary>
        /// 库存量
        /// </summary>
        public Int32  StockNumber
        {
            set { this._StockNumber = value; }
            get { return this._StockNumber; }
        }
            
        /// <summary>
        /// 编码号
        /// </summary>
        public String  CodeNO
        {
            set { this._CodeNO = value; }
            get { return this._CodeNO; }
        }
            
        #endregion
    }
}
  