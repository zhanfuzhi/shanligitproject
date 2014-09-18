/********************************************************************************
     File:																
            SqlDataProvider.cs                         
     Description:
            Sql数据库操作类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2013/9/12 11:04:12
     History:
*********************************************************************************/
using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using FrameWork.Components;
using Shanlitech_Location.Components;

namespace Shanlitech_Location.Data
{
    /// <summary>
    /// Sql数据库操作类
    /// </summary>
    public partial class SqlDataProvider : DataProvider
    {

        #region "SqlDataProvider"
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnString = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public SqlDataProvider()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ConnString = ConfigurationManager.AppSettings["MSSql"];
        }

        /// <summary>
        /// 连接数据库字符串
        /// </summary>
        /// <param name="strConn"></param>
        public SqlDataProvider(string strConn)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ConnString = strConn;
        }

        /// <summary>
        /// 获取数据连接
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            try
            {
                return new SqlConnection(ConnString);
            }
            catch
            {
                throw new Exception("没有提供数据庫连接字符串！");
            }
        }
        #endregion

        #region "T_BudgetDetail (预算明细) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_BudgetDetail (预算明细)
        /// </summary>
        /// <param name="fam">T_BudgetDetailEntity实体类(预算明细)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_BudgetDetailInsertUpdateDelete(T_BudgetDetailEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_BudgetDetail_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = fam.ProjID;  //所属项目
                cmd.Parameters.Add("@EquipmentName", SqlDbType.NVarChar).Value = fam.EquipmentName;  //器材名称
                cmd.Parameters.Add("@BudgetRevenue", SqlDbType.Float).Value = fam.BudgetRevenue;  //预算收入
                cmd.Parameters.Add("@Measurement", SqlDbType.NVarChar).Value = fam.Measurement;  //计量单位
                cmd.Parameters.Add("@BudgetPrice", SqlDbType.Float).Value = fam.BudgetPrice;  //预算单价
                cmd.Parameters.Add("@BudgetNumber", SqlDbType.Int).Value = fam.BudgetNumber;  //预算数量
                cmd.Parameters.Add("@BudgetExpenditure", SqlDbType.Float).Value = fam.BudgetExpenditure;  //预算支出
                cmd.Parameters.Add("@BalanceAmount", SqlDbType.Float).Value = fam.BalanceAmount;  //经费余额
                cmd.Parameters.Add("@Supplier", SqlDbType.NVarChar).Value = fam.Supplier;  //供货单位
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = fam.Remark;  //备注
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //递增排序
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_BudgetDetailEntity实体类的List对象 (预算明细)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_BudgetDetailEntity实体类的List对象(预算明细)</returns>
        public override List<T_BudgetDetailEntity> T_BudgetDetailList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_BudgetDetailEntity> mypd = new PopulateDelegate<T_BudgetDetailEntity>(base.PopulateT_BudgetDetailEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_ClassDic (T_ClassDic) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ClassDic (T_ClassDic)
        /// </summary>
        /// <param name="fam">T_ClassDicEntity实体类(T_ClassDic)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ClassDicInsertUpdateDelete(T_ClassDicEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_ClassDic_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ClassNO", SqlDbType.VarChar).Value = fam.ClassNO;  //类别名称
                cmd.Parameters.Add("@ClassName", SqlDbType.NVarChar).Value = fam.ClassName;  //类别名称
                cmd.Parameters.Add("@ParentClassNO", SqlDbType.VarChar).Value = fam.ParentClassNO;  //父类
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //状态(0为正常，9为删除)
                if (fam.CreateTime.HasValue)
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = fam.CreateTime;  //创建日期
                else
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DBNull.Value;  //创建日期
                if (fam.UpdateTime.HasValue)
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = fam.UpdateTime;  //更新日期
                else
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = DBNull.Value;  //更新日期
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //Sort
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_ClassDicEntity实体类的List对象 (T_ClassDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ClassDicEntity实体类的List对象(T_ClassDic)</returns>
        public override List<T_ClassDicEntity> T_ClassDicList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_ClassDicEntity> mypd = new PopulateDelegate<T_ClassDicEntity>(base.PopulateT_ClassDicEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_FundsRecord (经费使用申请单) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_FundsRecord (经费使用申请单)
        /// </summary>
        /// <param name="fam">T_FundsRecordEntity实体类(经费使用申请单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_FundsRecordInsertUpdateDelete(T_FundsRecordEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_FundsRecord_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //自增ID
                cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = fam.ProjID;  //预算项目
                cmd.Parameters.Add("@BalanceAmount", SqlDbType.Float).Value = fam.BalanceAmount;  //经费余额
                cmd.Parameters.Add("@UseRemark", SqlDbType.NVarChar).Value = fam.UseRemark;  //申请用途
                cmd.Parameters.Add("@AdvanceAmount", SqlDbType.Float).Value = fam.AdvanceAmount;  //支出金额
                cmd.Parameters.Add("@Applicant", SqlDbType.Int).Value = fam.Applicant;  //申请人
                cmd.Parameters.Add("@Checker", SqlDbType.Int).Value = fam.Checker;  //审核人
                cmd.Parameters.Add("@Approver", SqlDbType.Int).Value = fam.Approver;  //批准人
                cmd.Parameters.Add("@TransferState", SqlDbType.Int).Value = fam.TransferState;  //流转状态（0为申请状态，1为审核状态，2为批准状态）
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //状态（0为流转状态，1为存档状态，9为删除）
                if (fam.AppricationTime.HasValue)
                    cmd.Parameters.Add("@AppricationTime", SqlDbType.DateTime).Value = fam.AppricationTime;  //申请时间
                else
                    cmd.Parameters.Add("@AppricationTime", SqlDbType.DateTime).Value = DBNull.Value;  //申请时间
                if (fam.CheckTime.HasValue)
                    cmd.Parameters.Add("@CheckTime", SqlDbType.DateTime).Value = fam.CheckTime;  //审核时间
                else
                    cmd.Parameters.Add("@CheckTime", SqlDbType.DateTime).Value = DBNull.Value;  //审核时间
                if (fam.ApprovalTime.HasValue)
                    cmd.Parameters.Add("@ApprovalTime", SqlDbType.DateTime).Value = fam.ApprovalTime;  //批准时间
                else
                    cmd.Parameters.Add("@ApprovalTime", SqlDbType.DateTime).Value = DBNull.Value;  //批准时间
                cmd.Parameters.Add("@IntegrityCheckCode", SqlDbType.VarChar).Value = fam.IntegrityCheckCode;  //信息完整性校验码
                cmd.Parameters.Add("@ShenHeState", SqlDbType.NVarChar).Value = fam.ShenHeState;  //ShenHeState
                cmd.Parameters.Add("@PiZhunState", SqlDbType.NVarChar).Value = fam.PiZhunState;  //PiZhunState
                cmd.Parameters.Add("@CunDangState", SqlDbType.NVarChar).Value = fam.CunDangState;  //CunDangState
                cmd.Parameters.Add("@note", SqlDbType.NVarChar).Value = fam.note;  //note
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_FundsRecordEntity实体类的List对象 (经费使用申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_FundsRecordEntity实体类的List对象(经费使用申请单)</returns>
        public override List<T_FundsRecordEntity> T_FundsRecordList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_FundsRecordEntity> mypd = new PopulateDelegate<T_FundsRecordEntity>(base.PopulateT_FundsRecordEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_OutboundRecord (出库表单) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_OutboundRecord (出库表单)
        /// </summary>
        /// <param name="fam">T_OutboundRecordEntity实体类(出库表单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_OutboundRecordInsertUpdateDelete(T_OutboundRecordEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_OutboundRecord_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ProjectNO", SqlDbType.VarChar).Value = fam.ProjectNO;  //项目名称
                cmd.Parameters.Add("@EquipmentName", SqlDbType.NVarChar).Value = fam.EquipmentName;  //器材名称
                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = fam.Model;  //型号
                cmd.Parameters.Add("@OutboundNumber", SqlDbType.Int).Value = fam.OutboundNumber;  //数量
                cmd.Parameters.Add("@BalanceNumber", SqlDbType.Int).Value = fam.BalanceNumber;  //结余
                if (fam.OutboundTime.HasValue)
                    cmd.Parameters.Add("@OutboundTime", SqlDbType.DateTime).Value = fam.OutboundTime;  //领取时间
                else
                    cmd.Parameters.Add("@OutboundTime", SqlDbType.DateTime).Value = DBNull.Value;  //领取时间
                cmd.Parameters.Add("@Applicant", SqlDbType.Int).Value = fam.Applicant;  //申请人
                cmd.Parameters.Add("@Approver", SqlDbType.Int).Value = fam.Approver;  //批准人
                cmd.Parameters.Add("@IntegrityCheckCode", SqlDbType.VarChar).Value = fam.IntegrityCheckCode;  //信息完整性校验码
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = fam.Remark;  //Remark
                cmd.Parameters.Add("@CodeNO", SqlDbType.VarChar).Value = fam.CodeNO;  //库存资产编码号
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_OutboundRecordEntity实体类的List对象 (出库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_OutboundRecordEntity实体类的List对象(出库表单)</returns>
        public override List<T_OutboundRecordEntity> T_OutboundRecordList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_OutboundRecordEntity> mypd = new PopulateDelegate<T_OutboundRecordEntity>(base.PopulateT_OutboundRecordEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_ProjectBudget (项目预算) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectBudget (项目预算)
        /// </summary>
        /// <param name="fam">T_ProjectBudgetEntity实体类(项目预算)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ProjectBudgetInsertUpdateDelete(T_ProjectBudgetEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_ProjectBudget_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //项目编号
                cmd.Parameters.Add("@ProjectNO", SqlDbType.VarChar).Value = fam.ProjectNO;  //项目编号
                cmd.Parameters.Add("@SubjectNO", SqlDbType.VarChar).Value = fam.SubjectNO;  //所属科目
                cmd.Parameters.Add("@ClassNO", SqlDbType.VarChar).Value = fam.ClassNO;  //所属类别
                cmd.Parameters.Add("@AnnualNO", SqlDbType.VarChar).Value = fam.AnnualNO;  //所属年度
                cmd.Parameters.Add("@BudgetRevenue", SqlDbType.Float).Value = fam.BudgetRevenue;  //预算收入
                cmd.Parameters.Add("@BudgetExpenditure", SqlDbType.Float).Value = fam.BudgetExpenditure;  //预算支出
                cmd.Parameters.Add("@BalanceAmount", SqlDbType.Float).Value = fam.BalanceAmount;  //经费余额
                cmd.Parameters.Add("@Leader", SqlDbType.Int).Value = fam.Leader;  //项目组长
                cmd.Parameters.Add("@Undertaker", SqlDbType.Int).Value = fam.Undertaker;  //指定承办人
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //状态(0为正常，9为删除)
                if (fam.CreateTime.HasValue)
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = fam.CreateTime;  //创建时间
                else
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                if (fam.UpdateTime.HasValue)
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = fam.UpdateTime;  //更新时间
                else
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = DBNull.Value;  //更新时间
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //递增排序
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = fam.DepartmentID;  //所在部门
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_ProjectBudgetEntity实体类的List对象 (项目预算)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectBudgetEntity实体类的List对象(项目预算)</returns>
        public override List<T_ProjectBudgetEntity> T_ProjectBudgetList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_ProjectBudgetEntity> mypd = new PopulateDelegate<T_ProjectBudgetEntity>(base.PopulateT_ProjectBudgetEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_ProjectDic (T_ProjectDic) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectDic (T_ProjectDic)
        /// </summary>
        /// <param name="fam">T_ProjectDicEntity实体类(T_ProjectDic)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ProjectDicInsertUpdateDelete(T_ProjectDicEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_ProjectDic_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@ProjectNO", SqlDbType.VarChar).Value = fam.ProjectNO;  //项目编号
                cmd.Parameters.Add("@ProjectName", SqlDbType.NVarChar).Value = fam.ProjectName;  //ProjectName
                cmd.Parameters.Add("@SubjectNO", SqlDbType.VarChar).Value = fam.SubjectNO;  //所属科目
                cmd.Parameters.Add("@ClassNO", SqlDbType.VarChar).Value = fam.ClassNO;  //所属类别
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //状态(0为正常，9为删除)
                if (fam.CreateTime.HasValue)
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = fam.CreateTime;  //CreateTime
                else
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DBNull.Value;  //CreateTime
                if (fam.UpdateTime.HasValue)
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = fam.UpdateTime;  //UpdateTime
                else
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = DBNull.Value;  //UpdateTime
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_ProjectDicEntity实体类的List对象 (T_ProjectDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectDicEntity实体类的List对象(T_ProjectDic)</returns>
        public override List<T_ProjectDicEntity> T_ProjectDicList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_ProjectDicEntity> mypd = new PopulateDelegate<T_ProjectDicEntity>(base.PopulateT_ProjectDicEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_Stock (库存) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_Stock (库存)
        /// </summary>
        /// <param name="fam">T_StockEntity实体类(库存)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StockInsertUpdateDelete(T_StockEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_Stock_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@EquipmentName", SqlDbType.NVarChar).Value = fam.EquipmentName;  //器材名称
                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = fam.Model;  //型号
                cmd.Parameters.Add("@StockNumber", SqlDbType.Int).Value = fam.StockNumber;  //库存量
                cmd.Parameters.Add("@CodeNO", SqlDbType.VarChar).Value = fam.CodeNO;  //编码号
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_StockEntity实体类的List对象 (库存)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockEntity实体类的List对象(库存)</returns>
        public override List<T_StockEntity> T_StockList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_StockEntity> mypd = new PopulateDelegate<T_StockEntity>(base.PopulateT_StockEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_StockLog (出入库日志) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StockLog (出入库日志)
        /// </summary>
        /// <param name="fam">T_StockLogEntity实体类(出入库日志)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StockLogInsertUpdateDelete(T_StockLogEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_StockLog_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //自增ID
                cmd.Parameters.Add("@CodeNO", SqlDbType.VarChar).Value = fam.CodeNO;  //库存资产编码号
                cmd.Parameters.Add("@DealType", SqlDbType.Int).Value = fam.DealType;  //处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
                cmd.Parameters.Add("@Number", SqlDbType.Int).Value = fam.Number;  //数量
                cmd.Parameters.Add("@Handler", SqlDbType.Int).Value = fam.Handler;  //操作者
                cmd.Parameters.Add("@StorID", SqlDbType.Int).Value = fam.StorID;  //入库单ID
                cmd.Parameters.Add("@OutbID", SqlDbType.Int).Value = fam.OutbID;  //出库单ID
                if (fam.LogTime.HasValue)
                    cmd.Parameters.Add("@LogTime", SqlDbType.DateTime).Value = fam.LogTime;  //记录时间
                else
                    cmd.Parameters.Add("@LogTime", SqlDbType.DateTime).Value = DBNull.Value;  //记录时间
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_StockLogEntity实体类的List对象 (出入库日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockLogEntity实体类的List对象(出入库日志)</returns>
        public override List<T_StockLogEntity> T_StockLogList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_StockLogEntity> mypd = new PopulateDelegate<T_StockLogEntity>(base.PopulateT_StockLogEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_StorageRecord (入库表单) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StorageRecord (入库表单)
        /// </summary>
        /// <param name="fam">T_StorageRecordEntity实体类(入库表单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StorageRecordInsertUpdateDelete(T_StorageRecordEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_StorageRecord_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@VeriID", SqlDbType.Int).Value = fam.VeriID;  //所属核销
                cmd.Parameters.Add("@ProjectNO", SqlDbType.VarChar).Value = fam.ProjectNO;  //所属项目
                cmd.Parameters.Add("@EquipmentName", SqlDbType.NVarChar).Value = fam.EquipmentName;  //器材名称
                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = fam.Model;  //型号
                cmd.Parameters.Add("@StorageNumber", SqlDbType.Int).Value = fam.StorageNumber;  //数量
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Float).Value = fam.UnitPrice;  //单价
                if (fam.StorageTime.HasValue)
                    cmd.Parameters.Add("@StorageTime", SqlDbType.DateTime).Value = fam.StorageTime;  //入库时间
                else
                    cmd.Parameters.Add("@StorageTime", SqlDbType.DateTime).Value = DBNull.Value;  //入库时间
                cmd.Parameters.Add("@Applicant", SqlDbType.Int).Value = fam.Applicant;  //申请人
                cmd.Parameters.Add("@Approver", SqlDbType.Int).Value = fam.Approver;  //批准人
                cmd.Parameters.Add("@PayAmount", SqlDbType.Float).Value = fam.PayAmount;  //实际支出
                cmd.Parameters.Add("@IntegrityCheckCode", SqlDbType.VarChar).Value = fam.IntegrityCheckCode;  //信息完整性校验码
                cmd.Parameters.Add("@Remark", SqlDbType.NVarChar).Value = fam.Remark;  //Remark
                cmd.Parameters.Add("@CodeNO", SqlDbType.VarChar).Value = fam.CodeNO;  //库存资产编码号
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_StorageRecordEntity实体类的List对象 (入库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StorageRecordEntity实体类的List对象(入库表单)</returns>
        public override List<T_StorageRecordEntity> T_StorageRecordList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_StorageRecordEntity> mypd = new PopulateDelegate<T_StorageRecordEntity>(base.PopulateT_StorageRecordEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_SubjectDic (预算科目) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_SubjectDic (预算科目)
        /// </summary>
        /// <param name="fam">T_SubjectDicEntity实体类(预算科目)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_SubjectDicInsertUpdateDelete(T_SubjectDicEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_SubjectDic_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@SubjectNO", SqlDbType.VarChar).Value = fam.SubjectNO;  //科目编号
                cmd.Parameters.Add("@SubjectName", SqlDbType.NVarChar).Value = fam.SubjectName;  //科目名称
                cmd.Parameters.Add("@ClassNO", SqlDbType.VarChar).Value = fam.ClassNO;  //所属类别
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //状态(0为正常，9为删除)
                if (fam.CreateTime.HasValue)
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = fam.CreateTime;  //创建时间
                else
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                if (fam.UpdateTime.HasValue)
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = fam.UpdateTime;  //更新时间
                else
                    cmd.Parameters.Add("@UpdateTime", SqlDbType.DateTime).Value = DBNull.Value;  //更新时间
                cmd.Parameters.Add("@Sort", SqlDbType.Int).Value = fam.Sort;  //Sort
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_SubjectDicEntity实体类的List对象 (预算科目)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_SubjectDicEntity实体类的List对象(预算科目)</returns>
        public override List<T_SubjectDicEntity> T_SubjectDicList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_SubjectDicEntity> mypd = new PopulateDelegate<T_SubjectDicEntity>(base.PopulateT_SubjectDicEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
        }
        #endregion

        #region "T_VerificationRecord (核销申请单) - SQLDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_VerificationRecord (核销申请单)
        /// </summary>
        /// <param name="fam">T_VerificationRecordEntity实体类(核销申请单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_VerificationRecordInsertUpdateDelete(T_VerificationRecordEntity fam)
        {
            Int32 rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.T_VerificationRecord_InsertUpdateDelete", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                //设置参数
                cmd.Parameters.Add("@DataTable_Action_", SqlDbType.VarChar).Value = fam.DataTable_Action_.ToString(); //操作方法 Insert:增加 Update:修改 Delete:删除

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = fam.ID;  //ID
                cmd.Parameters.Add("@FundID", SqlDbType.Int).Value = fam.FundID;  //所属经费申请单
                cmd.Parameters.Add("@ProjID", SqlDbType.Int).Value = fam.ProjID;  //所属项目
                cmd.Parameters.Add("@InvoiceFolder", SqlDbType.VarChar).Value = fam.InvoiceFolder;  //发票联
                cmd.Parameters.Add("@ContractFolder", SqlDbType.VarChar).Value = fam.ContractFolder;  //合同协议
                cmd.Parameters.Add("@Undertaker", SqlDbType.Int).Value = fam.Undertaker;  //承办人
                cmd.Parameters.Add("@Checker", SqlDbType.Int).Value = fam.Checker;  //申请人
                cmd.Parameters.Add("@Approver", SqlDbType.BigInt).Value = fam.Approver;  //批准人
                cmd.Parameters.Add("@TransferState", SqlDbType.Int).Value = fam.TransferState;  //流转状态（0为申请状态，1为审核状态，2为批准状态）
                cmd.Parameters.Add("@State", SqlDbType.Int).Value = fam.State;  //存档状态（0为流转状态，1为存档状态，9为删除）
                if (fam.CreateTime.HasValue)
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = fam.CreateTime;  //创建时间
                else
                    cmd.Parameters.Add("@CreateTime", SqlDbType.DateTime).Value = DBNull.Value;  //创建时间
                if (fam.CheckTime.HasValue)
                    cmd.Parameters.Add("@CheckTime", SqlDbType.DateTime).Value = fam.CheckTime;  //审核时间
                else
                    cmd.Parameters.Add("@CheckTime", SqlDbType.DateTime).Value = DBNull.Value;  //审核时间
                if (fam.ApprovalTime.HasValue)
                    cmd.Parameters.Add("@ApprovalTime", SqlDbType.DateTime).Value = fam.ApprovalTime;  //批准时间
                else
                    cmd.Parameters.Add("@ApprovalTime", SqlDbType.DateTime).Value = DBNull.Value;  //批准时间
                cmd.Parameters.Add("@PayAmount", SqlDbType.Float).Value = fam.PayAmount;  //实际支出
                cmd.Parameters.Add("@IntegrityCheckCode", SqlDbType.VarChar).Value = fam.IntegrityCheckCode;  //信息完整性校验码
                cmd.Parameters.Add("@ShenHeNote", SqlDbType.NVarChar).Value = fam.ShenHeNote;  //审核状态备注
                cmd.Parameters.Add("@PiZhunNote", SqlDbType.NVarChar).Value = fam.PiZhunNote;  //批准状态备注
                cmd.Parameters.Add("@CunDangNote", SqlDbType.NVarChar).Value = fam.CunDangNote;  //CunDangNote
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }

        /// <summary>
        /// 返回T_VerificationRecordEntity实体类的List对象 (核销申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_VerificationRecordEntity实体类的List对象(核销申请单)</returns>
        public override List<T_VerificationRecordEntity> T_VerificationRecordList(QueryParam qp, out int RecordCount)
        {
            PopulateDelegate<T_VerificationRecordEntity> mypd = new PopulateDelegate<T_VerificationRecordEntity>(base.PopulateT_VerificationRecordEntity);
            return this.GetRecordList(mypd, qp, out RecordCount);
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
        /// <returns>返回字段值</returns>
        public override string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value)
        {
            string rStr = "";
            using (SqlConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("select {0} from {1} where upper({2})='{3}'", table_fileds, table_name, where_fileds, where_value);
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    rStr = dr[0].ToString();
                }
                dr.Close();
                dr.Dispose();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rStr;
        }
        #endregion

        #region "更新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns>-1:失败,其它值成功</returns>
        public override int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            int rInt = -1;
            using (SqlConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("Update {0} Set {1}  Where {2}", Table, Table_FiledsValue, Wheres);
                SqlCommand cmd = new SqlCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                rInt = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return rInt;
        }
        #endregion

        #region 公共查询数据函数Sql存储过程版
        /// <summary>
        /// 公共查询数据函数Sql存储过程版(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="pd">委托对象</param>
        /// <param name="pp">查询字符串</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>返回记录集List</returns>
        private List<T> GetRecordList<T>(PopulateDelegate<T> pd, QueryParam pp, out int RecordCount)
        {
            List<T> lst = new List<T>();
            RecordCount = 0;
            using (SqlConnection conn = GetSqlConnection())
            {
                SqlCommand cmd = new SqlCommand("dbo.SupesoftPage", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                // 设置参数
                cmd.Parameters.Add("@TableName", SqlDbType.NVarChar, 500).Value = pp.TableName;
                cmd.Parameters.Add("@ReturnFields", SqlDbType.NVarChar, 500).Value = pp.ReturnFields;
                cmd.Parameters.Add("@Where", SqlDbType.NVarChar, 500).Value = pp.Where;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pp.PageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pp.PageSize;
                cmd.Parameters.Add("@Orderfld", SqlDbType.NVarChar, 200).Value = pp.Orderfld;
                cmd.Parameters.Add("@OrderType", SqlDbType.Int).Value = pp.OrderType;
                // 执行
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Dictionary<string, string> Fileds = new Dictionary<string, string>();
                foreach (DataRow var in dr.GetSchemaTable().Select())
                {
                    Fileds.Add(var[0].ToString(), var[0].ToString());
                }
                while (dr.Read())
                {
                    lst.Add(pd(dr, Fileds));
                }
                // 取记录总数 及页数
                if (dr.NextResult())
                {
                    if (dr.Read())
                    {
                        RecordCount = Convert.ToInt32(dr["RecordCount"]);
                    }
                }

                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return lst;
        }
        #endregion
    }
}
