/********************************************************************************
    File:
          T_BudgetDetailEntity.cs
    Description:
          预算明细实体类
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
    ///T_BudgetDetailEntity实体类(预算明细)
    ///</summary>
    [Serializable]
    public partial class T_BudgetDetailEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private Int32 _ProjID=0; // 所属项目
        private String _EquipmentName=""; // 器材名称
        private Double _BudgetRevenue=0; // 预算收入
        private String _Measurement=""; // 计量单位
        private Double _BudgetPrice=0; // 预算单价
        private Int32 _BudgetNumber=0; // 预算数量
        private Double _BudgetExpenditure=0; // 预算支出
        private Double _BalanceAmount=0; // 经费余额
        private String _Supplier=""; // 供货单位
        private String _Remark=""; // 备注
        private Int32 _Sort=0; // 递增排序
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
        /// 所属项目
        /// </summary>
        public Int32  ProjID
        {
            set { this._ProjID = value; }
            get { return this._ProjID; }
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
        /// 预算收入
        /// </summary>
        public Double  BudgetRevenue
        {
            set { this._BudgetRevenue = value; }
            get { return this._BudgetRevenue; }
        }
            
        /// <summary>
        /// 计量单位
        /// </summary>
        public String  Measurement
        {
            set { this._Measurement = value; }
            get { return this._Measurement; }
        }
            
        /// <summary>
        /// 预算单价
        /// </summary>
        public Double  BudgetPrice
        {
            set { this._BudgetPrice = value; }
            get { return this._BudgetPrice; }
        }
            
        /// <summary>
        /// 预算数量
        /// </summary>
        public Int32  BudgetNumber
        {
            set { this._BudgetNumber = value; }
            get { return this._BudgetNumber; }
        }
            
        /// <summary>
        /// 预算支出
        /// </summary>
        public Double  BudgetExpenditure
        {
            set { this._BudgetExpenditure = value; }
            get { return this._BudgetExpenditure; }
        }
            
        /// <summary>
        /// 经费余额
        /// </summary>
        public Double  BalanceAmount
        {
            set { this._BalanceAmount = value; }
            get { return this._BalanceAmount; }
        }
            
        /// <summary>
        /// 供货单位
        /// </summary>
        public String  Supplier
        {
            set { this._Supplier = value; }
            get { return this._Supplier; }
        }
            
        /// <summary>
        /// 备注
        /// </summary>
        public String  Remark
        {
            set { this._Remark = value; }
            get { return this._Remark; }
        }
            
        /// <summary>
        /// 递增排序
        /// </summary>
        public Int32  Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
            
        #endregion
    }
}
  