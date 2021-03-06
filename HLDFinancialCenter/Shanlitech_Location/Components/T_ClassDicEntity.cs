﻿/********************************************************************************
    File:
          T_ClassDicEntity.cs
    Description:
          T_ClassDic实体类
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
    ///T_ClassDicEntity实体类(T_ClassDic)
    ///</summary>
    [Serializable]
    public partial class T_ClassDicEntity
    {
        #region "Private Variables"
        private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _ID=0; // ID
        private String _ClassNO=""; // 类别名称
        private String _ClassName=""; // 类别名称
        private String _ParentClassNO=""; // 父类
        private Int32 _State=0; // 状态(0为正常，9为删除)
        private DateTime? _CreateTime; // 创建日期
        private DateTime? _UpdateTime; // 更新日期
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
        /// 类别名称
        /// </summary>
        public String  ClassNO
        {
            set { this._ClassNO = value; }
            get { return this._ClassNO; }
        }
            
        /// <summary>
        /// 类别名称
        /// </summary>
        public String  ClassName
        {
            set { this._ClassName = value; }
            get { return this._ClassName; }
        }
            
        /// <summary>
        /// 父类
        /// </summary>
        public String  ParentClassNO
        {
            set { this._ParentClassNO = value; }
            get { return this._ParentClassNO; }
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
        /// 创建日期
        /// </summary>
        public DateTime?  CreateTime
        {
            set { this._CreateTime = value; }
            get { return this._CreateTime; }
        }
            
        /// <summary>
        /// 更新日期
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
  