/********************************************************************************
    File:
          T_FundsRecordEntity.cs
    Description:
          经费使用申请单实体类
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
    ///T_FundsRecordEntity实体类(经费使用申请单)
    ///</summary>
    [Serializable]
    public partial class T_FundsRecordEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0; // 自增ID
        private Int32 _ProjID = 0; // 预算项目
        private Double _BalanceAmount = 0; // 经费余额
        private String _UseRemark = ""; // 申请用途
        private Double _AdvanceAmount = 0; // 支出金额
        private Int32 _Applicant = 0; // 申请人
        private Int32 _Checker = 0; // 审核人
        private Int32 _Approver = 0; // 批准人
        private Int32 _TransferState = 0; // 流转状态（0为申请状态，1为审核状态，2为批准状态）
        private Int32 _State = 0; // 状态（0为流转状态，1为存档状态，9为删除）
        private DateTime? _AppricationTime; // 申请时间
        private DateTime? _CheckTime; // 审核时间
        private DateTime? _ApprovalTime; // 批准时间
        private String _IntegrityCheckCode = ""; // 信息完整性校验码
        private String _ShenHeState = ""; // ShenHeState
        private String _PiZhunState = ""; // PiZhunState
        private String _CunDangState = ""; // CunDangState
        private String _note = ""; // note
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
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        /// <summary>
        /// 预算项目
        /// </summary>
        public Int32 ProjID
        {
            set { this._ProjID = value; }
            get { return this._ProjID; }
        }

        /// <summary>
        /// 经费余额
        /// </summary>
        public Double BalanceAmount
        {
            set { this._BalanceAmount = value; }
            get { return this._BalanceAmount; }
        }

        /// <summary>
        /// 申请用途
        /// </summary>
        public String UseRemark
        {
            set { this._UseRemark = value; }
            get { return this._UseRemark; }
        }

        /// <summary>
        /// 支出金额
        /// </summary>
        public Double AdvanceAmount
        {
            set { this._AdvanceAmount = value; }
            get { return this._AdvanceAmount; }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public Int32 Applicant
        {
            set { this._Applicant = value; }
            get { return this._Applicant; }
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public Int32 Checker
        {
            set { this._Checker = value; }
            get { return this._Checker; }
        }

        /// <summary>
        /// 批准人
        /// </summary>
        public Int32 Approver
        {
            set { this._Approver = value; }
            get { return this._Approver; }
        }

        /// <summary>
        /// 流转状态（0为申请状态，1为审核状态，2为批准状态）
        /// </summary>
        public Int32 TransferState
        {
            set { this._TransferState = value; }
            get { return this._TransferState; }
        }

        /// <summary>
        /// 状态（0为流转状态，1为存档状态，9为删除）
        /// </summary>
        public Int32 State
        {
            set { this._State = value; }
            get { return this._State; }
        }

        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? AppricationTime
        {
            set { this._AppricationTime = value; }
            get { return this._AppricationTime; }
        }

        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? CheckTime
        {
            set { this._CheckTime = value; }
            get { return this._CheckTime; }
        }

        /// <summary>
        /// 批准时间
        /// </summary>
        public DateTime? ApprovalTime
        {
            set { this._ApprovalTime = value; }
            get { return this._ApprovalTime; }
        }

        /// <summary>
        /// 信息完整性校验码
        /// </summary>
        public String IntegrityCheckCode
        {
            set { this._IntegrityCheckCode = value; }
            get { return this._IntegrityCheckCode; }
        }

        /// <summary>
        /// ShenHeState
        /// </summary>
        public String ShenHeState
        {
            set { this._ShenHeState = value; }
            get { return this._ShenHeState; }
        }

        /// <summary>
        /// PiZhunState
        /// </summary>
        public String PiZhunState
        {
            set { this._PiZhunState = value; }
            get { return this._PiZhunState; }
        }

        /// <summary>
        /// CunDangState
        /// </summary>
        public String CunDangState
        {
            set { this._CunDangState = value; }
            get { return this._CunDangState; }
        }

        /// <summary>
        /// note
        /// </summary>
        public String note
        {
            set { this._note = value; }
            get { return this._note; }
        }

        #endregion
    }
}
  