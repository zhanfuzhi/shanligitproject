/********************************************************************************
    File:
          T_SubjectDicEntity.cs
    Description:
          预算科目实体类
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
    ///T_SubjectDicEntity实体类(预算科目)
    ///</summary>
    [Serializable]
    public partial class T_SubjectDicEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _SubjectNO=""; // 科目编号
        private String _SubjectName=""; // 科目名称
        private String _ClassNO=""; // 所属类别
        private Int32 _State=0; // 状态(0为正常，9为删除)
        private DateTime? _CreateTime; // 创建时间
        private DateTime? _UpdateTime; // 更新时间
        private Int32 _Sort=0; // Sort
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
        /// 科目编号
        /// </summary>
        public String  SubjectNO
        {
            set { this._SubjectNO = value; }
            get { return this._SubjectNO; }
        }
            
        /// <summary>
        /// 科目名称
        /// </summary>
        public String  SubjectName
        {
            set { this._SubjectName = value; }
            get { return this._SubjectName; }
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
        /// Sort
        /// </summary>
        public Int32  Sort
        {
            set { this._Sort = value; }
            get { return this._Sort; }
        }
            
        #endregion
    }
}
  