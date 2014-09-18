/********************************************************************************
    File:
          T_VerificationRecordEntity.cs
    Description:
          核销申请单实体类
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
    ///T_VerificationRecordEntity实体类(核销申请单)
    ///</summary>
    [Serializable]
    public partial class T_VerificationRecordEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID = 0; // ID
        private Int32 _FundID = 0; // 所属经费申请单
        private Int32 _ProjID = 0; // 所属项目
        private String _InvoiceFolder = ""; // 发票联
        private String _ContractFolder = ""; // 合同协议
        private Int32 _Undertaker = 0; // 承办人
        private Int32 _Checker = 0; // 申请人
        private Int64 _Approver = 0; // 批准人
        private Int32 _TransferState = 0; // 流转状态（0为申请状态，1为审核状态，2为批准状态）
        private Int32 _State = 0; // 存档状态（0为流转状态，1为存档状态，9为删除）
        private DateTime? _CreateTime; // 创建时间
        private DateTime? _CheckTime; // 审核时间
        private DateTime? _ApprovalTime; // 批准时间
        private Double _PayAmount = 0; // 实际支出
        private String _IntegrityCheckCode = ""; // 信息完整性校验码
        private String _ShenHeNote = ""; // 审核状态备注
        private String _PiZhunNote = ""; // 批准状态备注
        private String _CunDangNote = ""; // CunDangNote
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
        public Int32 ID
        {
            set { this._ID = value; }
            get { return this._ID; }
        }

        /// <summary>
        /// 所属经费申请单
        /// </summary>
        public Int32 FundID
        {
            set { this._FundID = value; }
            get { return this._FundID; }
        }

        /// <summary>
        /// 所属项目
        /// </summary>
        public Int32 ProjID
        {
            set { this._ProjID = value; }
            get { return this._ProjID; }
        }

        /// <summary>
        /// 发票联
        /// </summary>
        public String InvoiceFolder
        {
            set { this._InvoiceFolder = value; }
            get { return this._InvoiceFolder; }
        }

        /// <summary>
        /// 合同协议
        /// </summary>
        public String ContractFolder
        {
            set { this._ContractFolder = value; }
            get { return this._ContractFolder; }
        }

        /// <summary>
        /// 承办人
        /// </summary>
        public Int32 Undertaker
        {
            set { this._Undertaker = value; }
            get { return this._Undertaker; }
        }

        /// <summary>
        /// 申请人
        /// </summary>
        public Int32 Checker
        {
            set { this._Checker = value; }
            get { return this._Checker; }
        }

        /// <summary>
        /// 批准人
        /// </summary>
        public Int64 Approver
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
        /// 存档状态（0为流转状态，1为存档状态，9为删除）
        /// </summary>
        public Int32 State
        {
            set { this._State = value; }
            get { return this._State; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { this._CreateTime = value; }
            get { return this._CreateTime; }
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
        /// 实际支出
        /// </summary>
        public Double PayAmount
        {
            set { this._PayAmount = value; }
            get { return this._PayAmount; }
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
        /// 审核状态备注
        /// </summary>
        public String ShenHeNote
        {
            set { this._ShenHeNote = value; }
            get { return this._ShenHeNote; }
        }

        /// <summary>
        /// 批准状态备注
        /// </summary>
        public String PiZhunNote
        {
            set { this._PiZhunNote = value; }
            get { return this._PiZhunNote; }
        }

        /// <summary>
        /// CunDangNote
        /// </summary>
        public String CunDangNote
        {
            set { this._CunDangNote = value; }
            get { return this._CunDangNote; }
        }

        #endregion
    }
}
  