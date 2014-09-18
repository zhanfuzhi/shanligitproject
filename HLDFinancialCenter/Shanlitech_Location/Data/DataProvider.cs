/********************************************************************************
     File:																
            DataProvider.cs                         
     Description:
            抽象数据操作类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2013/9/12 11:04:12
     History:
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using FrameWork.Components;
using Shanlitech_Location.Components;

namespace Shanlitech_Location.Data
{
    /// <summary>
    /// 委托将DataReader转为实体类
    /// </summary>
    /// <param name="dr">记录集</param>
    /// <param name="Fileds">字段名列表</param>
    /// <returns></returns>
    public delegate T PopulateDelegate<T>(IDataReader dr, Dictionary<string, string> Fileds);

    /// <summary>
    /// 数据抽象类
    /// </summary>
    public abstract partial class DataProvider
    {

        #region "DataProvider Instance"
        private static DataProvider _defaultInstance = null;
        static DataProvider()
        {
            DataProvider dataProvider;
            if (FrameWork.Common.GetDBType == "MsSql")
                dataProvider = new SqlDataProvider();
            else if (FrameWork.Common.GetDBType == "Access")
                dataProvider = new AccessDataProvider();
            else
                throw new ApplicationException("数据库配置不对！");
            _defaultInstance = dataProvider;
        }

        /// <summary>
        /// 数据访问抽象层实例
        /// </summary>
        /// <returns></returns>
        public static DataProvider Instance()
        {

            return _defaultInstance;
        }

        /// <summary>
        /// 数据访问抽象层实例
        /// </summary>
        /// <param name="strConn">数据库连接字符串</param>
        /// <returns></returns>
        public static DataProvider Instance(string strConn)
        {
            return new SqlDataProvider(strConn);
        }
        #endregion


        #region "T_BudgetDetail(预算明细) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_BudgetDetailEntity (预算明细)
        /// </summary>
        /// <param name="fam">T_BudgetDetail实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_BudgetDetailInsertUpdateDelete(T_BudgetDetailEntity fam);

        /// <summary>
        /// 返回T_BudgetDetailEntity实体类的List对象 (预算明细)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_BudgetDetailEntity实体类的List对象(预算明细)</returns>
        public abstract List<T_BudgetDetailEntity> T_BudgetDetailList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_BudgetDetailEntity实体类 (预算明细)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_BudgetDetailEntity</returns>
        protected T_BudgetDetailEntity PopulateT_BudgetDetailEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_BudgetDetailEntity nc = new T_BudgetDetailEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ProjID") && !Convert.IsDBNull(dr["ProjID"])) nc.ProjID = Convert.ToInt32(dr["ProjID"]); // 所属项目
            if (Fileds.ContainsKey("EquipmentName") && !Convert.IsDBNull(dr["EquipmentName"])) nc.EquipmentName = Convert.ToString(dr["EquipmentName"]).Trim(); // 器材名称
            if (Fileds.ContainsKey("BudgetRevenue") && !Convert.IsDBNull(dr["BudgetRevenue"])) nc.BudgetRevenue = Convert.ToDouble(dr["BudgetRevenue"]); // 预算收入
            if (Fileds.ContainsKey("Measurement") && !Convert.IsDBNull(dr["Measurement"])) nc.Measurement = Convert.ToString(dr["Measurement"]).Trim(); // 计量单位
            if (Fileds.ContainsKey("BudgetPrice") && !Convert.IsDBNull(dr["BudgetPrice"])) nc.BudgetPrice = Convert.ToDouble(dr["BudgetPrice"]); // 预算单价
            if (Fileds.ContainsKey("BudgetNumber") && !Convert.IsDBNull(dr["BudgetNumber"])) nc.BudgetNumber = Convert.ToInt32(dr["BudgetNumber"]); // 预算数量
            if (Fileds.ContainsKey("BudgetExpenditure") && !Convert.IsDBNull(dr["BudgetExpenditure"])) nc.BudgetExpenditure = Convert.ToDouble(dr["BudgetExpenditure"]); // 预算支出
            if (Fileds.ContainsKey("BalanceAmount") && !Convert.IsDBNull(dr["BalanceAmount"])) nc.BalanceAmount = Convert.ToDouble(dr["BalanceAmount"]); // 经费余额
            if (Fileds.ContainsKey("Supplier") && !Convert.IsDBNull(dr["Supplier"])) nc.Supplier = Convert.ToString(dr["Supplier"]).Trim(); // 供货单位
            if (Fileds.ContainsKey("Remark") && !Convert.IsDBNull(dr["Remark"])) nc.Remark = Convert.ToString(dr["Remark"]).Trim(); // 备注
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 递增排序
            return nc;
        }
        #endregion

        #region "T_ClassDic(T_ClassDic) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ClassDicEntity (T_ClassDic)
        /// </summary>
        /// <param name="fam">T_ClassDic实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_ClassDicInsertUpdateDelete(T_ClassDicEntity fam);

        /// <summary>
        /// 返回T_ClassDicEntity实体类的List对象 (T_ClassDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ClassDicEntity实体类的List对象(T_ClassDic)</returns>
        public abstract List<T_ClassDicEntity> T_ClassDicList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_ClassDicEntity实体类 (T_ClassDic)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_ClassDicEntity</returns>
        protected T_ClassDicEntity PopulateT_ClassDicEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_ClassDicEntity nc = new T_ClassDicEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ClassNO") && !Convert.IsDBNull(dr["ClassNO"])) nc.ClassNO = Convert.ToString(dr["ClassNO"]).Trim(); // 类别名称
            if (Fileds.ContainsKey("ClassName") && !Convert.IsDBNull(dr["ClassName"])) nc.ClassName = Convert.ToString(dr["ClassName"]).Trim(); // 类别名称
            if (Fileds.ContainsKey("ParentClassNO") && !Convert.IsDBNull(dr["ParentClassNO"])) nc.ParentClassNO = Convert.ToString(dr["ParentClassNO"]).Trim(); // 父类
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 状态(0为正常，9为删除)
            if (Fileds.ContainsKey("CreateTime") && !Convert.IsDBNull(dr["CreateTime"])) nc.CreateTime = Convert.ToDateTime(dr["CreateTime"]); // 创建日期
            if (Fileds.ContainsKey("UpdateTime") && !Convert.IsDBNull(dr["UpdateTime"])) nc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]); // 更新日期
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // Sort
            return nc;
        }
        #endregion

        #region "T_FundsRecord(经费使用申请单) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_FundsRecordEntity (经费使用申请单)
        /// </summary>
        /// <param name="fam">T_FundsRecord实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_FundsRecordInsertUpdateDelete(T_FundsRecordEntity fam);

        /// <summary>
        /// 返回T_FundsRecordEntity实体类的List对象 (经费使用申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_FundsRecordEntity实体类的List对象(经费使用申请单)</returns>
        public abstract List<T_FundsRecordEntity> T_FundsRecordList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_FundsRecordEntity实体类 (经费使用申请单)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_FundsRecordEntity</returns>
        protected T_FundsRecordEntity PopulateT_FundsRecordEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_FundsRecordEntity nc = new T_FundsRecordEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // 自增ID
            if (Fileds.ContainsKey("ProjID") && !Convert.IsDBNull(dr["ProjID"])) nc.ProjID = Convert.ToInt32(dr["ProjID"]); // 预算项目
            if (Fileds.ContainsKey("BalanceAmount") && !Convert.IsDBNull(dr["BalanceAmount"])) nc.BalanceAmount = Convert.ToDouble(dr["BalanceAmount"]); // 经费余额
            if (Fileds.ContainsKey("UseRemark") && !Convert.IsDBNull(dr["UseRemark"])) nc.UseRemark = Convert.ToString(dr["UseRemark"]).Trim(); // 申请用途
            if (Fileds.ContainsKey("AdvanceAmount") && !Convert.IsDBNull(dr["AdvanceAmount"])) nc.AdvanceAmount = Convert.ToDouble(dr["AdvanceAmount"]); // 支出金额
            if (Fileds.ContainsKey("Applicant") && !Convert.IsDBNull(dr["Applicant"])) nc.Applicant = Convert.ToInt32(dr["Applicant"]); // 申请人
            if (Fileds.ContainsKey("Checker") && !Convert.IsDBNull(dr["Checker"])) nc.Checker = Convert.ToInt32(dr["Checker"]); // 审核人
            if (Fileds.ContainsKey("Approver") && !Convert.IsDBNull(dr["Approver"])) nc.Approver = Convert.ToInt32(dr["Approver"]); // 批准人
            if (Fileds.ContainsKey("TransferState") && !Convert.IsDBNull(dr["TransferState"])) nc.TransferState = Convert.ToInt32(dr["TransferState"]); // 流转状态（0为申请状态，1为审核状态，2为批准状态）
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 状态（0为流转状态，1为存档状态，9为删除）
            if (Fileds.ContainsKey("AppricationTime") && !Convert.IsDBNull(dr["AppricationTime"])) nc.AppricationTime = Convert.ToDateTime(dr["AppricationTime"]); // 申请时间
            if (Fileds.ContainsKey("CheckTime") && !Convert.IsDBNull(dr["CheckTime"])) nc.CheckTime = Convert.ToDateTime(dr["CheckTime"]); // 审核时间
            if (Fileds.ContainsKey("ApprovalTime") && !Convert.IsDBNull(dr["ApprovalTime"])) nc.ApprovalTime = Convert.ToDateTime(dr["ApprovalTime"]); // 批准时间
            if (Fileds.ContainsKey("IntegrityCheckCode") && !Convert.IsDBNull(dr["IntegrityCheckCode"])) nc.IntegrityCheckCode = Convert.ToString(dr["IntegrityCheckCode"]).Trim(); // 信息完整性校验码
            if (Fileds.ContainsKey("ShenHeState") && !Convert.IsDBNull(dr["ShenHeState"])) nc.ShenHeState = Convert.ToString(dr["ShenHeState"]).Trim(); // ShenHeState
            if (Fileds.ContainsKey("PiZhunState") && !Convert.IsDBNull(dr["PiZhunState"])) nc.PiZhunState = Convert.ToString(dr["PiZhunState"]).Trim(); // PiZhunState
            if (Fileds.ContainsKey("CunDangState") && !Convert.IsDBNull(dr["CunDangState"])) nc.CunDangState = Convert.ToString(dr["CunDangState"]).Trim(); // CunDangState
            if (Fileds.ContainsKey("note") && !Convert.IsDBNull(dr["note"])) nc.note = Convert.ToString(dr["note"]).Trim(); // note
            return nc;
        }
        #endregion

        #region "T_OutboundRecord(出库表单) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_OutboundRecordEntity (出库表单)
        /// </summary>
        /// <param name="fam">T_OutboundRecord实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_OutboundRecordInsertUpdateDelete(T_OutboundRecordEntity fam);

        /// <summary>
        /// 返回T_OutboundRecordEntity实体类的List对象 (出库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_OutboundRecordEntity实体类的List对象(出库表单)</returns>
        public abstract List<T_OutboundRecordEntity> T_OutboundRecordList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_OutboundRecordEntity实体类 (出库表单)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_OutboundRecordEntity</returns>
        protected T_OutboundRecordEntity PopulateT_OutboundRecordEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_OutboundRecordEntity nc = new T_OutboundRecordEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ProjectNO") && !Convert.IsDBNull(dr["ProjectNO"])) nc.ProjectNO = Convert.ToString(dr["ProjectNO"]).Trim(); // 项目名称
            if (Fileds.ContainsKey("EquipmentName") && !Convert.IsDBNull(dr["EquipmentName"])) nc.EquipmentName = Convert.ToString(dr["EquipmentName"]).Trim(); // 器材名称
            if (Fileds.ContainsKey("Model") && !Convert.IsDBNull(dr["Model"])) nc.Model = Convert.ToString(dr["Model"]).Trim(); // 型号
            if (Fileds.ContainsKey("OutboundNumber") && !Convert.IsDBNull(dr["OutboundNumber"])) nc.OutboundNumber = Convert.ToInt32(dr["OutboundNumber"]); // 数量
            if (Fileds.ContainsKey("BalanceNumber") && !Convert.IsDBNull(dr["BalanceNumber"])) nc.BalanceNumber = Convert.ToInt32(dr["BalanceNumber"]); // 结余
            if (Fileds.ContainsKey("OutboundTime") && !Convert.IsDBNull(dr["OutboundTime"])) nc.OutboundTime = Convert.ToDateTime(dr["OutboundTime"]); // 领取时间
            if (Fileds.ContainsKey("Applicant") && !Convert.IsDBNull(dr["Applicant"])) nc.Applicant = Convert.ToInt32(dr["Applicant"]); // 申请人
            if (Fileds.ContainsKey("Approver") && !Convert.IsDBNull(dr["Approver"])) nc.Approver = Convert.ToInt32(dr["Approver"]); // 批准人
            if (Fileds.ContainsKey("IntegrityCheckCode") && !Convert.IsDBNull(dr["IntegrityCheckCode"])) nc.IntegrityCheckCode = Convert.ToString(dr["IntegrityCheckCode"]).Trim(); // 信息完整性校验码
            if (Fileds.ContainsKey("Remark") && !Convert.IsDBNull(dr["Remark"])) nc.Remark = Convert.ToString(dr["Remark"]).Trim(); // Remark
            if (Fileds.ContainsKey("CodeNO") && !Convert.IsDBNull(dr["CodeNO"])) nc.CodeNO = Convert.ToString(dr["CodeNO"]).Trim(); // 库存资产编码号
            return nc;
        }
        #endregion

        #region "T_ProjectBudget(项目预算) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectBudgetEntity (项目预算)
        /// </summary>
        /// <param name="fam">T_ProjectBudget实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_ProjectBudgetInsertUpdateDelete(T_ProjectBudgetEntity fam);

        /// <summary>
        /// 返回T_ProjectBudgetEntity实体类的List对象 (项目预算)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectBudgetEntity实体类的List对象(项目预算)</returns>
        public abstract List<T_ProjectBudgetEntity> T_ProjectBudgetList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_ProjectBudgetEntity实体类 (项目预算)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_ProjectBudgetEntity</returns>
        protected T_ProjectBudgetEntity PopulateT_ProjectBudgetEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_ProjectBudgetEntity nc = new T_ProjectBudgetEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // 项目编号
            if (Fileds.ContainsKey("ProjectNO") && !Convert.IsDBNull(dr["ProjectNO"])) nc.ProjectNO = Convert.ToString(dr["ProjectNO"]).Trim(); // 项目编号
            if (Fileds.ContainsKey("SubjectNO") && !Convert.IsDBNull(dr["SubjectNO"])) nc.SubjectNO = Convert.ToString(dr["SubjectNO"]).Trim(); // 所属科目
            if (Fileds.ContainsKey("ClassNO") && !Convert.IsDBNull(dr["ClassNO"])) nc.ClassNO = Convert.ToString(dr["ClassNO"]).Trim(); // 所属类别
            if (Fileds.ContainsKey("AnnualNO") && !Convert.IsDBNull(dr["AnnualNO"])) nc.AnnualNO = Convert.ToString(dr["AnnualNO"]).Trim(); // 所属年度
            if (Fileds.ContainsKey("BudgetRevenue") && !Convert.IsDBNull(dr["BudgetRevenue"])) nc.BudgetRevenue = Convert.ToDouble(dr["BudgetRevenue"]); // 预算收入
            if (Fileds.ContainsKey("BudgetExpenditure") && !Convert.IsDBNull(dr["BudgetExpenditure"])) nc.BudgetExpenditure = Convert.ToDouble(dr["BudgetExpenditure"]); // 预算支出
            if (Fileds.ContainsKey("BalanceAmount") && !Convert.IsDBNull(dr["BalanceAmount"])) nc.BalanceAmount = Convert.ToDouble(dr["BalanceAmount"]); // 经费余额
            if (Fileds.ContainsKey("Leader") && !Convert.IsDBNull(dr["Leader"])) nc.Leader = Convert.ToInt32(dr["Leader"]); // 项目组长
            if (Fileds.ContainsKey("Undertaker") && !Convert.IsDBNull(dr["Undertaker"])) nc.Undertaker = Convert.ToInt32(dr["Undertaker"]); // 指定承办人
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 状态(0为正常，9为删除)
            if (Fileds.ContainsKey("CreateTime") && !Convert.IsDBNull(dr["CreateTime"])) nc.CreateTime = Convert.ToDateTime(dr["CreateTime"]); // 创建时间
            if (Fileds.ContainsKey("UpdateTime") && !Convert.IsDBNull(dr["UpdateTime"])) nc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]); // 更新时间
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // 递增排序
            if (Fileds.ContainsKey("DepartmentID") && !Convert.IsDBNull(dr["DepartmentID"])) nc.DepartmentID = Convert.ToInt32(dr["DepartmentID"]); // 所在部门
            return nc;
        }
        #endregion

        #region "T_ProjectDic(T_ProjectDic) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectDicEntity (T_ProjectDic)
        /// </summary>
        /// <param name="fam">T_ProjectDic实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_ProjectDicInsertUpdateDelete(T_ProjectDicEntity fam);

        /// <summary>
        /// 返回T_ProjectDicEntity实体类的List对象 (T_ProjectDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectDicEntity实体类的List对象(T_ProjectDic)</returns>
        public abstract List<T_ProjectDicEntity> T_ProjectDicList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_ProjectDicEntity实体类 (T_ProjectDic)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_ProjectDicEntity</returns>
        protected T_ProjectDicEntity PopulateT_ProjectDicEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_ProjectDicEntity nc = new T_ProjectDicEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("ProjectNO") && !Convert.IsDBNull(dr["ProjectNO"])) nc.ProjectNO = Convert.ToString(dr["ProjectNO"]).Trim(); // 项目编号
            if (Fileds.ContainsKey("ProjectName") && !Convert.IsDBNull(dr["ProjectName"])) nc.ProjectName = Convert.ToString(dr["ProjectName"]).Trim(); // ProjectName
            if (Fileds.ContainsKey("SubjectNO") && !Convert.IsDBNull(dr["SubjectNO"])) nc.SubjectNO = Convert.ToString(dr["SubjectNO"]).Trim(); // 所属科目
            if (Fileds.ContainsKey("ClassNO") && !Convert.IsDBNull(dr["ClassNO"])) nc.ClassNO = Convert.ToString(dr["ClassNO"]).Trim(); // 所属类别
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 状态(0为正常，9为删除)
            if (Fileds.ContainsKey("CreateTime") && !Convert.IsDBNull(dr["CreateTime"])) nc.CreateTime = Convert.ToDateTime(dr["CreateTime"]); // CreateTime
            if (Fileds.ContainsKey("UpdateTime") && !Convert.IsDBNull(dr["UpdateTime"])) nc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]); // UpdateTime
            return nc;
        }
        #endregion

        #region "T_Stock(库存) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StockEntity (库存)
        /// </summary>
        /// <param name="fam">T_Stock实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_StockInsertUpdateDelete(T_StockEntity fam);

        /// <summary>
        /// 返回T_StockEntity实体类的List对象 (库存)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockEntity实体类的List对象(库存)</returns>
        public abstract List<T_StockEntity> T_StockList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_StockEntity实体类 (库存)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_StockEntity</returns>
        protected T_StockEntity PopulateT_StockEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_StockEntity nc = new T_StockEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("EquipmentName") && !Convert.IsDBNull(dr["EquipmentName"])) nc.EquipmentName = Convert.ToString(dr["EquipmentName"]).Trim(); // 器材名称
            if (Fileds.ContainsKey("Model") && !Convert.IsDBNull(dr["Model"])) nc.Model = Convert.ToString(dr["Model"]).Trim(); // 型号
            if (Fileds.ContainsKey("StockNumber") && !Convert.IsDBNull(dr["StockNumber"])) nc.StockNumber = Convert.ToInt32(dr["StockNumber"]); // 库存量
            if (Fileds.ContainsKey("CodeNO") && !Convert.IsDBNull(dr["CodeNO"])) nc.CodeNO = Convert.ToString(dr["CodeNO"]).Trim(); // 编码号
            return nc;
        }
        #endregion

        #region "T_StockLog(出入库日志) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StockLogEntity (出入库日志)
        /// </summary>
        /// <param name="fam">T_StockLog实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_StockLogInsertUpdateDelete(T_StockLogEntity fam);

        /// <summary>
        /// 返回T_StockLogEntity实体类的List对象 (出入库日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockLogEntity实体类的List对象(出入库日志)</returns>
        public abstract List<T_StockLogEntity> T_StockLogList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_StockLogEntity实体类 (出入库日志)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_StockLogEntity</returns>
        protected T_StockLogEntity PopulateT_StockLogEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_StockLogEntity nc = new T_StockLogEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // 自增ID
            if (Fileds.ContainsKey("CodeNO") && !Convert.IsDBNull(dr["CodeNO"])) nc.CodeNO = Convert.ToString(dr["CodeNO"]).Trim(); // 库存资产编码号
            if (Fileds.ContainsKey("DealType") && !Convert.IsDBNull(dr["DealType"])) nc.DealType = Convert.ToInt32(dr["DealType"]); // 处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
            if (Fileds.ContainsKey("Number") && !Convert.IsDBNull(dr["Number"])) nc.Number = Convert.ToInt32(dr["Number"]); // 数量
            if (Fileds.ContainsKey("Handler") && !Convert.IsDBNull(dr["Handler"])) nc.Handler = Convert.ToInt32(dr["Handler"]); // 操作者
            if (Fileds.ContainsKey("StorID") && !Convert.IsDBNull(dr["StorID"])) nc.StorID = Convert.ToInt32(dr["StorID"]); // 入库单ID
            if (Fileds.ContainsKey("OutbID") && !Convert.IsDBNull(dr["OutbID"])) nc.OutbID = Convert.ToInt32(dr["OutbID"]); // 出库单ID
            if (Fileds.ContainsKey("LogTime") && !Convert.IsDBNull(dr["LogTime"])) nc.LogTime = Convert.ToDateTime(dr["LogTime"]); // 记录时间
            return nc;
        }
        #endregion

        #region "T_StorageRecord(入库表单) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StorageRecordEntity (入库表单)
        /// </summary>
        /// <param name="fam">T_StorageRecord实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_StorageRecordInsertUpdateDelete(T_StorageRecordEntity fam);

        /// <summary>
        /// 返回T_StorageRecordEntity实体类的List对象 (入库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StorageRecordEntity实体类的List对象(入库表单)</returns>
        public abstract List<T_StorageRecordEntity> T_StorageRecordList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_StorageRecordEntity实体类 (入库表单)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_StorageRecordEntity</returns>
        protected T_StorageRecordEntity PopulateT_StorageRecordEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_StorageRecordEntity nc = new T_StorageRecordEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("VeriID") && !Convert.IsDBNull(dr["VeriID"])) nc.VeriID = Convert.ToInt32(dr["VeriID"]); // 所属核销
            if (Fileds.ContainsKey("ProjectNO") && !Convert.IsDBNull(dr["ProjectNO"])) nc.ProjectNO = Convert.ToString(dr["ProjectNO"]).Trim(); // 所属项目
            if (Fileds.ContainsKey("EquipmentName") && !Convert.IsDBNull(dr["EquipmentName"])) nc.EquipmentName = Convert.ToString(dr["EquipmentName"]).Trim(); // 器材名称
            if (Fileds.ContainsKey("Model") && !Convert.IsDBNull(dr["Model"])) nc.Model = Convert.ToString(dr["Model"]).Trim(); // 型号
            if (Fileds.ContainsKey("StorageNumber") && !Convert.IsDBNull(dr["StorageNumber"])) nc.StorageNumber = Convert.ToInt32(dr["StorageNumber"]); // 数量
            if (Fileds.ContainsKey("UnitPrice") && !Convert.IsDBNull(dr["UnitPrice"])) nc.UnitPrice = Convert.ToDouble(dr["UnitPrice"]); // 单价
            if (Fileds.ContainsKey("StorageTime") && !Convert.IsDBNull(dr["StorageTime"])) nc.StorageTime = Convert.ToDateTime(dr["StorageTime"]); // 入库时间
            if (Fileds.ContainsKey("Applicant") && !Convert.IsDBNull(dr["Applicant"])) nc.Applicant = Convert.ToInt32(dr["Applicant"]); // 申请人
            if (Fileds.ContainsKey("Approver") && !Convert.IsDBNull(dr["Approver"])) nc.Approver = Convert.ToInt32(dr["Approver"]); // 批准人
            if (Fileds.ContainsKey("PayAmount") && !Convert.IsDBNull(dr["PayAmount"])) nc.PayAmount = Convert.ToDouble(dr["PayAmount"]); // 实际支出
            if (Fileds.ContainsKey("IntegrityCheckCode") && !Convert.IsDBNull(dr["IntegrityCheckCode"])) nc.IntegrityCheckCode = Convert.ToString(dr["IntegrityCheckCode"]).Trim(); // 信息完整性校验码
            if (Fileds.ContainsKey("Remark") && !Convert.IsDBNull(dr["Remark"])) nc.Remark = Convert.ToString(dr["Remark"]).Trim(); // Remark
            if (Fileds.ContainsKey("CodeNO") && !Convert.IsDBNull(dr["CodeNO"])) nc.CodeNO = Convert.ToString(dr["CodeNO"]).Trim(); // 库存资产编码号
            return nc;
        }
        #endregion

        #region "T_SubjectDic(预算科目) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_SubjectDicEntity (预算科目)
        /// </summary>
        /// <param name="fam">T_SubjectDic实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_SubjectDicInsertUpdateDelete(T_SubjectDicEntity fam);

        /// <summary>
        /// 返回T_SubjectDicEntity实体类的List对象 (预算科目)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_SubjectDicEntity实体类的List对象(预算科目)</returns>
        public abstract List<T_SubjectDicEntity> T_SubjectDicList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_SubjectDicEntity实体类 (预算科目)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_SubjectDicEntity</returns>
        protected T_SubjectDicEntity PopulateT_SubjectDicEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_SubjectDicEntity nc = new T_SubjectDicEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("SubjectNO") && !Convert.IsDBNull(dr["SubjectNO"])) nc.SubjectNO = Convert.ToString(dr["SubjectNO"]).Trim(); // 科目编号
            if (Fileds.ContainsKey("SubjectName") && !Convert.IsDBNull(dr["SubjectName"])) nc.SubjectName = Convert.ToString(dr["SubjectName"]).Trim(); // 科目名称
            if (Fileds.ContainsKey("ClassNO") && !Convert.IsDBNull(dr["ClassNO"])) nc.ClassNO = Convert.ToString(dr["ClassNO"]).Trim(); // 所属类别
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 状态(0为正常，9为删除)
            if (Fileds.ContainsKey("CreateTime") && !Convert.IsDBNull(dr["CreateTime"])) nc.CreateTime = Convert.ToDateTime(dr["CreateTime"]); // 创建时间
            if (Fileds.ContainsKey("UpdateTime") && !Convert.IsDBNull(dr["UpdateTime"])) nc.UpdateTime = Convert.ToDateTime(dr["UpdateTime"]); // 更新时间
            if (Fileds.ContainsKey("Sort") && !Convert.IsDBNull(dr["Sort"])) nc.Sort = Convert.ToInt32(dr["Sort"]); // Sort
            return nc;
        }
        #endregion

        #region "T_VerificationRecord(核销申请单) - DataProvider"

        /// <summary>
        /// 新增/删除/修改 T_VerificationRecordEntity (核销申请单)
        /// </summary>
        /// <param name="fam">T_VerificationRecord实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public abstract Int32 T_VerificationRecordInsertUpdateDelete(T_VerificationRecordEntity fam);

        /// <summary>
        /// 返回T_VerificationRecordEntity实体类的List对象 (核销申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_VerificationRecordEntity实体类的List对象(核销申请单)</returns>
        public abstract List<T_VerificationRecordEntity> T_VerificationRecordList(QueryParam qp, out int RecordCount);

        /// <summary>
        /// 将记录集转为T_VerificationRecordEntity实体类 (核销申请单)
        /// </summary>
        /// <param name="dr">记录集</param>
        /// <param name="Fileds">字段名列表</param>
        /// <returns>T_VerificationRecordEntity</returns>
        protected T_VerificationRecordEntity PopulateT_VerificationRecordEntity(IDataReader dr, Dictionary<string, string> Fileds)
        {
            T_VerificationRecordEntity nc = new T_VerificationRecordEntity();

            if (Fileds.ContainsKey("ID") && !Convert.IsDBNull(dr["ID"])) nc.ID = Convert.ToInt32(dr["ID"]); // ID
            if (Fileds.ContainsKey("FundID") && !Convert.IsDBNull(dr["FundID"])) nc.FundID = Convert.ToInt32(dr["FundID"]); // 所属经费申请单
            if (Fileds.ContainsKey("ProjID") && !Convert.IsDBNull(dr["ProjID"])) nc.ProjID = Convert.ToInt32(dr["ProjID"]); // 所属项目
            if (Fileds.ContainsKey("InvoiceFolder") && !Convert.IsDBNull(dr["InvoiceFolder"])) nc.InvoiceFolder = Convert.ToString(dr["InvoiceFolder"]).Trim(); // 发票联
            if (Fileds.ContainsKey("ContractFolder") && !Convert.IsDBNull(dr["ContractFolder"])) nc.ContractFolder = Convert.ToString(dr["ContractFolder"]).Trim(); // 合同协议
            if (Fileds.ContainsKey("Undertaker") && !Convert.IsDBNull(dr["Undertaker"])) nc.Undertaker = Convert.ToInt32(dr["Undertaker"]); // 承办人
            if (Fileds.ContainsKey("Checker") && !Convert.IsDBNull(dr["Checker"])) nc.Checker = Convert.ToInt32(dr["Checker"]); // 申请人
            if (Fileds.ContainsKey("Approver") && !Convert.IsDBNull(dr["Approver"])) nc.Approver = Convert.ToInt64(dr["Approver"]); // 批准人
            if (Fileds.ContainsKey("TransferState") && !Convert.IsDBNull(dr["TransferState"])) nc.TransferState = Convert.ToInt32(dr["TransferState"]); // 流转状态（0为申请状态，1为审核状态，2为批准状态）
            if (Fileds.ContainsKey("State") && !Convert.IsDBNull(dr["State"])) nc.State = Convert.ToInt32(dr["State"]); // 存档状态（0为流转状态，1为存档状态，9为删除）
            if (Fileds.ContainsKey("CreateTime") && !Convert.IsDBNull(dr["CreateTime"])) nc.CreateTime = Convert.ToDateTime(dr["CreateTime"]); // 创建时间
            if (Fileds.ContainsKey("CheckTime") && !Convert.IsDBNull(dr["CheckTime"])) nc.CheckTime = Convert.ToDateTime(dr["CheckTime"]); // 审核时间
            if (Fileds.ContainsKey("ApprovalTime") && !Convert.IsDBNull(dr["ApprovalTime"])) nc.ApprovalTime = Convert.ToDateTime(dr["ApprovalTime"]); // 批准时间
            if (Fileds.ContainsKey("PayAmount") && !Convert.IsDBNull(dr["PayAmount"])) nc.PayAmount = Convert.ToDouble(dr["PayAmount"]); // 实际支出
            if (Fileds.ContainsKey("IntegrityCheckCode") && !Convert.IsDBNull(dr["IntegrityCheckCode"])) nc.IntegrityCheckCode = Convert.ToString(dr["IntegrityCheckCode"]).Trim(); // 信息完整性校验码
            if (Fileds.ContainsKey("ShenHeNote") && !Convert.IsDBNull(dr["ShenHeNote"])) nc.ShenHeNote = Convert.ToString(dr["ShenHeNote"]).Trim(); // 审核状态备注
            if (Fileds.ContainsKey("PiZhunNote") && !Convert.IsDBNull(dr["PiZhunNote"])) nc.PiZhunNote = Convert.ToString(dr["PiZhunNote"]).Trim(); // 批准状态备注
            if (Fileds.ContainsKey("CunDangNote") && !Convert.IsDBNull(dr["CunDangNote"])) nc.CunDangNote = Convert.ToString(dr["CunDangNote"]).Trim(); // CunDangNote
            return nc;
        }
        #endregion

        #region "获取表中字段值"
        /// <summary>
        /// 获取表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="table_name">表名</param>
        /// <param name="table_fileds">字段</param>
        /// <param name="where_fileds">查询条件字段</param>
        /// <param name="where_value">查询值</param>
        /// <returns></returns>
        public abstract string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value);
        #endregion

        #region "列新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns></returns>
        public abstract int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres);
        #endregion
    }
}
