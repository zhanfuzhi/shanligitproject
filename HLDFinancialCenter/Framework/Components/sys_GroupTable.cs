/************************************************************************************
 *      Copyright (C) 2008 supesoft.com,All Rights Reserved						    *
 *      File:																		*
 *				sys_GroupTable.cs                                		        	*
 *      Description:																*
 *				 部门实体类      		            							    *
 *      Author:																		*
 *				Lzppcc														        *
 *				Lzppcc@hotmail.com													*
 *				http://www.supesoft.com												*
 *      Finish DateTime:															*
 *				2007年8月6日														*
 *      History:																	*
 ***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace FrameWork.Components
{
    /// <summary>
    /// 部门实体类
    /// </summary>
    public class sys_GroupTable
    {
        #region OLD
        //#region "Private Variables"
        //private string _DB_Option_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除 
        //private int _GroupID = 0;  // 分类ID号
        //private string _G_CName;  // 分类中文说明
        //private int _G_ParentID = 0;  // 上级分类ID0:为最高级
        //private int _G_ShowOrder = 0;  // 显示顺序
        //private int _G_Level = 0;  // 当前分类所在层数
        //private int _G_ChildCount = 0;  // 当前分类子分类数
        //private int _G_Delete = 0;  // 是否删除1:是0:否
        //#endregion

        //#region "Public Variables"
        ///// <summary>
        ///// 操作方法 Insert:增加 Update:修改 Delete:删除 
        ///// </summary>
        //public string DB_Option_Action_
        //{
        //    set { this._DB_Option_Action_ = value; }
        //    get { return this._DB_Option_Action_; }
        //}

        ///// <summary>
        ///// 分类ID号
        ///// </summary>
        //public int GroupID
        //{
        //    set { this._GroupID = value; }
        //    get { return this._GroupID; }
        //}

        ///// <summary>
        ///// 分类中文说明
        ///// </summary>
        //public string G_CName
        //{
        //    set { this._G_CName = value; }
        //    get { return this._G_CName; }
        //}

        ///// <summary>
        ///// 上级分类ID0:为最高级
        ///// </summary>
        //public int G_ParentID
        //{
        //    set { this._G_ParentID = value; }
        //    get { return this._G_ParentID; }
        //}

        ///// <summary>
        ///// 显示顺序
        ///// </summary>
        //public int G_ShowOrder
        //{
        //    set { this._G_ShowOrder = value; }
        //    get { return this._G_ShowOrder; }
        //}

        ///// <summary>
        ///// 当前分类所在层数
        ///// </summary>
        //public int G_Level
        //{
        //    set { this._G_Level = value; }
        //    get { return this._G_Level; }
        //}

        ///// <summary>
        ///// 当前分类子分类数
        ///// </summary>
        //public int G_ChildCount
        //{
        //    set { this._G_ChildCount = value; }
        //    get { return this._G_ChildCount; }
        //}

        ///// <summary>
        ///// 是否删除1:是0:否
        ///// </summary>
        //public int G_Delete
        //{
        //    set { this._G_Delete = value; }
        //    get { return this._G_Delete; }
        //}

        //#endregion
        #endregion

        #region "Private Variables"
        private string _DB_Option_Action_;
        //private DataTable_Action _DataTable_Action_;  // 操作方法 Insert:增加 Update:修改 Delete:删除
        private Int32 _GroupID = 0; // 编号
        private String _G_CName = ""; // 部门名称
        private Int32 _G_ParentID = 0; // 父ID
        private Int32 _G_ShowOrder = 0; // 序号
        private Int32 _G_Level = 0; // 级别
        private Int32 _G_ChildCount = 0; // 子类数量
        private Int64 _G_Delete = 0; // 是否删除：1是，0否
        
        private String _Address = ""; // 地址
        private String _CertificateNumber = ""; // 资质证书编号
        private String _Fax = ""; // 传真
        private String _EmailAddress = ""; // email地址
        private String _Tel = ""; // 联系电话
        private String _ZipCode = ""; // 邮政编码
        private Int32 _Type = 0; // 部门类型

        #endregion

        #region "Public Variables"
        /// <summary>
        /// 操作方法 Insert:增加 Update:修改 Delete:删除 
        /// </summary>
        public string DB_Option_Action_
        {
            set { this._DB_Option_Action_ = value; }
            get { return this._DB_Option_Action_; }
        }
        /////<summary>
        ///// 操作方法 Insert:增加 Update:修改 Delete:删除
        /////</summary>
        //public DataTable_Action DataTable_Action_
        //{
        //    set { this._DataTable_Action_ = value; }
        //    get { return this._DataTable_Action_; }
        //}
        /// <summary>
        /// 编号
        /// </summary>
        public Int32 GroupID
        {
            set { this._GroupID = value; }
            get { return this._GroupID; }
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        public String G_CName
        {
            set { this._G_CName = value; }
            get { return this._G_CName; }
        }

        /// <summary>
        /// 父ID
        /// </summary>
        public Int32 G_ParentID
        {
            set { this._G_ParentID = value; }
            get { return this._G_ParentID; }
        }

        /// <summary>
        /// 序号
        /// </summary>
        public Int32 G_ShowOrder
        {
            set { this._G_ShowOrder = value; }
            get { return this._G_ShowOrder; }
        }

        /// <summary>
        /// 级别
        /// </summary>
        public Int32 G_Level
        {
            set { this._G_Level = value; }
            get { return this._G_Level; }
        }

        /// <summary>
        /// 子类数量
        /// </summary>
        public Int32 G_ChildCount
        {
            set { this._G_ChildCount = value; }
            get { return this._G_ChildCount; }
        }

        /// <summary>
        /// 是否删除：1是，0否
        /// </summary>
        public Int64 G_Delete
        {
            set { this._G_Delete = value; }
            get { return this._G_Delete; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public String Address
        {
            set { this._Address = value; }
            get { return this._Address; }
        }

        /// <summary>
        /// 资质证书编号
        /// </summary>
        public String CertificateNumber
        {
            set { this._CertificateNumber = value; }
            get { return this._CertificateNumber; }
        }

        /// <summary>
        /// 传真
        /// </summary>
        public String Fax
        {
            set { this._Fax = value; }
            get { return this._Fax; }
        }

        /// <summary>
        /// email地址
        /// </summary>
        public String EmailAddress
        {
            set { this._EmailAddress = value; }
            get { return this._EmailAddress; }
        }

        /// <summary>
        /// 联系电话
        /// </summary>
        public String Tel
        {
            set { this._Tel = value; }
            get { return this._Tel; }
        }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public String ZipCode
        {
            set { this._ZipCode = value; }
            get { return this._ZipCode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        #endregion
    }
}
