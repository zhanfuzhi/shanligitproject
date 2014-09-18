/********************************************************************************
    File:
          T_StorageRecordEntity.cs
    Description:
          入库表单实体类
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
    ///T_StorageRecordEntity实体类(入库表单)
    ///</summary>
    [Serializable]
    public partial class T_StorageRecordEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _VeriID=0; // 所属核销
        private String _ProjectNO=""; // 所属项目
        private String _EquipmentName=""; // 器材名称
        private String _Model=""; // 型号
        private Int32 _StorageNumber=0; // 数量
        private Double _UnitPrice=0; // 单价
        private DateTime? _StorageTime; // 入库时间
        private Int32 _Applicant=0; // 申请人
        private Int32 _Approver=0; // 批准人
        private Double _PayAmount=0; // 实际支出
        private String _IntegrityCheckCode=""; // 信息完整性校验码
        private String _Remark=""; // Remark
        private String _CodeNO=""; // 库存资产编码号
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
        /// 所属核销
        /// </summary>
        public Int32  VeriID
        {
            set { this._VeriID = value; }
            get { return this._VeriID; }
        }
            
        /// <summary>
        /// 所属项目
        /// </summary>
        public String  ProjectNO
        {
            set { this._ProjectNO = value; }
            get { return this._ProjectNO; }
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
        /// 数量
        /// </summary>
        public Int32  StorageNumber
        {
            set { this._StorageNumber = value; }
            get { return this._StorageNumber; }
        }
            
        /// <summary>
        /// 单价
        /// </summary>
        public Double  UnitPrice
        {
            set { this._UnitPrice = value; }
            get { return this._UnitPrice; }
        }
            
        /// <summary>
        /// 入库时间
        /// </summary>
        public DateTime?  StorageTime
        {
            set { this._StorageTime = value; }
            get { return this._StorageTime; }
        }
            
        /// <summary>
        /// 申请人
        /// </summary>
        public Int32  Applicant
        {
            set { this._Applicant = value; }
            get { return this._Applicant; }
        }
            
        /// <summary>
        /// 批准人
        /// </summary>
        public Int32  Approver
        {
            set { this._Approver = value; }
            get { return this._Approver; }
        }
            
        /// <summary>
        /// 实际支出
        /// </summary>
        public Double  PayAmount
        {
            set { this._PayAmount = value; }
            get { return this._PayAmount; }
        }
            
        /// <summary>
        /// 信息完整性校验码
        /// </summary>
        public String  IntegrityCheckCode
        {
            set { this._IntegrityCheckCode = value; }
            get { return this._IntegrityCheckCode; }
        }
            
        /// <summary>
        /// Remark
        /// </summary>
        public String  Remark
        {
            set { this._Remark = value; }
            get { return this._Remark; }
        }
            
        /// <summary>
        /// 库存资产编码号
        /// </summary>
        public String  CodeNO
        {
            set { this._CodeNO = value; }
            get { return this._CodeNO; }
        }
            
        #endregion
    }
}
  