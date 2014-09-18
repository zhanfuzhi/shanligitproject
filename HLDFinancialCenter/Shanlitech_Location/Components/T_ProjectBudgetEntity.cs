/********************************************************************************
    File:
          T_ProjectBudgetEntity.cs
    Description:
          项目预算实体类
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
    ///T_ProjectBudgetEntity实体类(项目预算)
    ///</summary>
    [Serializable]
    public partial class T_ProjectBudgetEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // 项目编号
        private String _ProjectNO=""; // 项目编号
        private String _SubjectNO=""; // 所属科目
        private String _ClassNO=""; // 所属类别
        private String _AnnualNO=""; // 所属年度
        private Double _BudgetRevenue=0; // 预算收入
        private Double _BudgetExpenditure=0; // 预算支出
        private Double _BalanceAmount=0; // 经费余额
        private Int32 _Leader=0; // 项目组长
        private Int32 _Undertaker=0; // 指定承办人
        private Int32 _State=0; // 状态(0为正常，9为删除)
        private DateTime? _CreateTime; // 创建时间
        private DateTime? _UpdateTime; // 更新时间
        private Int32 _Sort=0; // 递增排序
        private Int32 _DepartmentID=0; // 所在部门
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
        /// 项目编号
        /// </summary>
        public Int32  ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }
            
        /// <summary>
        /// 项目编号
        /// </summary>
        public String  ProjectNO
        {
            set { this._ProjectNO = value; }
            get { return this._ProjectNO; }
        }
            
        /// <summary>
        /// 所属科目
        /// </summary>
        public String  SubjectNO
        {
            set { this._SubjectNO = value; }
            get { return this._SubjectNO; }
        }
            
        /// <summary>
        /// 所属类别
        /// </summary>
        public String  ClassNO
        {
            set { this._ClassNO = value; }
            get { return this._ClassNO; }
        }
            
        /// <summary>
        /// 所属年度
        /// </summary>
        public String  AnnualNO
        {
            set { this._AnnualNO = value; }
            get { return this._AnnualNO; }
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
        /// 项目组长
        /// </summary>
        public Int32  Leader
        {
            set { this._Leader = value; }
            get { return this._Leader; }
        }
            
        /// <summary>
        /// 指定承办人
        /// </summary>
        public Int32  Undertaker
        {
            set { this._Undertaker = value; }
            get { return this._Undertaker; }
        }
            
        /// <summary>
        /// 状态(0为正常，9为删除)
        /// </summary>
        public Int32  State
        {
            set { this._State = value; }
            get { return this._State; }
        }
            
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime?  CreateTime
        {
            set { this._CreateTime = value; }
            get { return this._CreateTime; }
        }
            
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime?  UpdateTime
        {
            set { this._UpdateTime = value; }
            get { return this._UpdateTime; }
        }
            
        /// <summary>
        /// 递增排序
        /// </summary>
        public Int32  Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
            
        /// <summary>
        /// 所在部门
        /// </summary>
        public Int32  DepartmentID
        {
            set { this._DepartmentID = value; }
            get { return this._DepartmentID; }
        }
            
        #endregion
    }
}
  