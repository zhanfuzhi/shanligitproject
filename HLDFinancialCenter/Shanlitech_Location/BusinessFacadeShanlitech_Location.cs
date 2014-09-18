/********************************************************************************
     File:																
            BusinessFacade.cs                         
     Description:
            业务逻辑类
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
			2013/9/12 11:04:12
     History:
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Shanlitech_Location.Components;
using Shanlitech_Location.Data;

using FrameWork.Components;

namespace Shanlitech_Location
{
    /// <summary>
    /// 业务逻辑类
    /// </summary>
    public partial class BusinessFacadeShanlitech_Location
    {
        #region "T_BudgetDetail(预算明细) - Method"

        /// <summary>
        /// 新增/删除/修改 T_BudgetDetailEntity (预算明细)
        /// </summary>
        /// <param name="fam">T_BudgetDetailEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_BudgetDetailInsertUpdateDelete(T_BudgetDetailEntity fam)
        {
            return DataProvider.Instance().T_BudgetDetailInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_BudgetDetailEntity实体类 单笔资料 (预算明细)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_BudgetDetailEntity实体类 ID为0则无记录</returns>
        public static T_BudgetDetailEntity T_BudgetDetailDisp(Int32 ID)
        {
            T_BudgetDetailEntity fam = new T_BudgetDetailEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_BudgetDetail", "ID", ID);
            int RecordCount = 0;
            List<T_BudgetDetailEntity> lst = T_BudgetDetailList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_BudgetDetailEntity实体类的List对象 (预算明细)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_BudgetDetailEntity实体类的List对象(预算明细)</returns>
        public static List<T_BudgetDetailEntity> T_BudgetDetailList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_BudgetDetail";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_BudgetDetailList(qp, out RecordCount);
        }
        #endregion

        #region "T_ClassDic(T_ClassDic) - Method"

        /// <summary>
        /// 新增/删除/修改 T_ClassDicEntity (T_ClassDic)
        /// </summary>
        /// <param name="fam">T_ClassDicEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_ClassDicInsertUpdateDelete(T_ClassDicEntity fam)
        {
            return DataProvider.Instance().T_ClassDicInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_ClassDicEntity实体类 单笔资料 (T_ClassDic)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_ClassDicEntity实体类 ID为0则无记录</returns>
        public static T_ClassDicEntity T_ClassDicDisp(Int32 ID)
        {
            T_ClassDicEntity fam = new T_ClassDicEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_ClassDic", "ID", ID);
            int RecordCount = 0;
            List<T_ClassDicEntity> lst = T_ClassDicList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_ClassDicEntity实体类的List对象 (T_ClassDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ClassDicEntity实体类的List对象(T_ClassDic)</returns>
        public static List<T_ClassDicEntity> T_ClassDicList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_ClassDic";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_ClassDicList(qp, out RecordCount);
        }
        #endregion

        #region "T_FundsRecord(经费使用申请单) - Method"

        /// <summary>
        /// 新增/删除/修改 T_FundsRecordEntity (经费使用申请单)
        /// </summary>
        /// <param name="fam">T_FundsRecordEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_FundsRecordInsertUpdateDelete(T_FundsRecordEntity fam)
        {
            return DataProvider.Instance().T_FundsRecordInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_FundsRecordEntity实体类 单笔资料 (经费使用申请单)
        /// </summary>
        /// <param name="ID">ID 自增ID</param>
        /// <returns>返回 T_FundsRecordEntity实体类 ID为0则无记录</returns>
        public static T_FundsRecordEntity T_FundsRecordDisp(Int32 ID)
        {
            T_FundsRecordEntity fam = new T_FundsRecordEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_FundsRecord", "ID", ID);
            int RecordCount = 0;
            List<T_FundsRecordEntity> lst = T_FundsRecordList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_FundsRecordEntity实体类的List对象 (经费使用申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_FundsRecordEntity实体类的List对象(经费使用申请单)</returns>
        public static List<T_FundsRecordEntity> T_FundsRecordList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_FundsRecord";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_FundsRecordList(qp, out RecordCount);
        }
        #endregion

        #region "T_OutboundRecord(出库表单) - Method"

        /// <summary>
        /// 新增/删除/修改 T_OutboundRecordEntity (出库表单)
        /// </summary>
        /// <param name="fam">T_OutboundRecordEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_OutboundRecordInsertUpdateDelete(T_OutboundRecordEntity fam)
        {
            return DataProvider.Instance().T_OutboundRecordInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_OutboundRecordEntity实体类 单笔资料 (出库表单)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_OutboundRecordEntity实体类 ID为0则无记录</returns>
        public static T_OutboundRecordEntity T_OutboundRecordDisp(Int32 ID)
        {
            T_OutboundRecordEntity fam = new T_OutboundRecordEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_OutboundRecord", "ID", ID);
            int RecordCount = 0;
            List<T_OutboundRecordEntity> lst = T_OutboundRecordList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_OutboundRecordEntity实体类的List对象 (出库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_OutboundRecordEntity实体类的List对象(出库表单)</returns>
        public static List<T_OutboundRecordEntity> T_OutboundRecordList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_OutboundRecord";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_OutboundRecordList(qp, out RecordCount);
        }
        #endregion

        #region "T_ProjectBudget(项目预算) - Method"

        /// <summary>
        /// 新增/删除/修改 T_ProjectBudgetEntity (项目预算)
        /// </summary>
        /// <param name="fam">T_ProjectBudgetEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_ProjectBudgetInsertUpdateDelete(T_ProjectBudgetEntity fam)
        {
            return DataProvider.Instance().T_ProjectBudgetInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_ProjectBudgetEntity实体类 单笔资料 (项目预算)
        /// </summary>
        /// <param name="ID">ID 项目编号</param>
        /// <returns>返回 T_ProjectBudgetEntity实体类 ID为0则无记录</returns>
        public static T_ProjectBudgetEntity T_ProjectBudgetDisp(Int32 ID)
        {
            T_ProjectBudgetEntity fam = new T_ProjectBudgetEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_ProjectBudget", "ID", ID);
            int RecordCount = 0;
            List<T_ProjectBudgetEntity> lst = T_ProjectBudgetList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_ProjectBudgetEntity实体类的List对象 (项目预算)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectBudgetEntity实体类的List对象(项目预算)</returns>
        public static List<T_ProjectBudgetEntity> T_ProjectBudgetList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_ProjectBudget";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_ProjectBudgetList(qp, out RecordCount);
        }
        #endregion

        #region "T_ProjectDic(T_ProjectDic) - Method"

        /// <summary>
        /// 新增/删除/修改 T_ProjectDicEntity (T_ProjectDic)
        /// </summary>
        /// <param name="fam">T_ProjectDicEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_ProjectDicInsertUpdateDelete(T_ProjectDicEntity fam)
        {
            return DataProvider.Instance().T_ProjectDicInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_ProjectDicEntity实体类 单笔资料 (T_ProjectDic)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_ProjectDicEntity实体类 ID为0则无记录</returns>
        public static T_ProjectDicEntity T_ProjectDicDisp(Int32 ID)
        {
            T_ProjectDicEntity fam = new T_ProjectDicEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_ProjectDic", "ID", ID);
            int RecordCount = 0;
            List<T_ProjectDicEntity> lst = T_ProjectDicList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_ProjectDicEntity实体类的List对象 (T_ProjectDic)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_ProjectDicEntity实体类的List对象(T_ProjectDic)</returns>
        public static List<T_ProjectDicEntity> T_ProjectDicList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_ProjectDic";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_ProjectDicList(qp, out RecordCount);
        }
        #endregion

        #region "T_Stock(库存) - Method"

        /// <summary>
        /// 新增/删除/修改 T_StockEntity (库存)
        /// </summary>
        /// <param name="fam">T_StockEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_StockInsertUpdateDelete(T_StockEntity fam)
        {
            return DataProvider.Instance().T_StockInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_StockEntity实体类 单笔资料 (库存)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_StockEntity实体类 ID为0则无记录</returns>
        public static T_StockEntity T_StockDisp(Int32 ID)
        {
            T_StockEntity fam = new T_StockEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_Stock", "ID", ID);
            int RecordCount = 0;
            List<T_StockEntity> lst = T_StockList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_StockEntity实体类的List对象 (库存)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockEntity实体类的List对象(库存)</returns>
        public static List<T_StockEntity> T_StockList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_Stock";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_StockList(qp, out RecordCount);
        }
        #endregion

        #region "T_StockLog(出入库日志) - Method"

        /// <summary>
        /// 新增/删除/修改 T_StockLogEntity (出入库日志)
        /// </summary>
        /// <param name="fam">T_StockLogEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_StockLogInsertUpdateDelete(T_StockLogEntity fam)
        {
            return DataProvider.Instance().T_StockLogInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_StockLogEntity实体类 单笔资料 (出入库日志)
        /// </summary>
        /// <param name="ID">ID 自增ID</param>
        /// <returns>返回 T_StockLogEntity实体类 ID为0则无记录</returns>
        public static T_StockLogEntity T_StockLogDisp(Int32 ID)
        {
            T_StockLogEntity fam = new T_StockLogEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_StockLog", "ID", ID);
            int RecordCount = 0;
            List<T_StockLogEntity> lst = T_StockLogList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_StockLogEntity实体类的List对象 (出入库日志)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StockLogEntity实体类的List对象(出入库日志)</returns>
        public static List<T_StockLogEntity> T_StockLogList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_StockLog";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_StockLogList(qp, out RecordCount);
        }
        #endregion

        #region "T_StorageRecord(入库表单) - Method"

        /// <summary>
        /// 新增/删除/修改 T_StorageRecordEntity (入库表单)
        /// </summary>
        /// <param name="fam">T_StorageRecordEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_StorageRecordInsertUpdateDelete(T_StorageRecordEntity fam)
        {
            return DataProvider.Instance().T_StorageRecordInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_StorageRecordEntity实体类 单笔资料 (入库表单)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_StorageRecordEntity实体类 ID为0则无记录</returns>
        public static T_StorageRecordEntity T_StorageRecordDisp(Int32 ID)
        {
            T_StorageRecordEntity fam = new T_StorageRecordEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_StorageRecord", "ID", ID);
            int RecordCount = 0;
            List<T_StorageRecordEntity> lst = T_StorageRecordList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_StorageRecordEntity实体类的List对象 (入库表单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_StorageRecordEntity实体类的List对象(入库表单)</returns>
        public static List<T_StorageRecordEntity> T_StorageRecordList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_StorageRecord";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_StorageRecordList(qp, out RecordCount);
        }
        #endregion

        #region "T_SubjectDic(预算科目) - Method"

        /// <summary>
        /// 新增/删除/修改 T_SubjectDicEntity (预算科目)
        /// </summary>
        /// <param name="fam">T_SubjectDicEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_SubjectDicInsertUpdateDelete(T_SubjectDicEntity fam)
        {
            return DataProvider.Instance().T_SubjectDicInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_SubjectDicEntity实体类 单笔资料 (预算科目)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_SubjectDicEntity实体类 ID为0则无记录</returns>
        public static T_SubjectDicEntity T_SubjectDicDisp(Int32 ID)
        {
            T_SubjectDicEntity fam = new T_SubjectDicEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_SubjectDic", "ID", ID);
            int RecordCount = 0;
            List<T_SubjectDicEntity> lst = T_SubjectDicList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_SubjectDicEntity实体类的List对象 (预算科目)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_SubjectDicEntity实体类的List对象(预算科目)</returns>
        public static List<T_SubjectDicEntity> T_SubjectDicList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_SubjectDic";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_SubjectDicList(qp, out RecordCount);
        }
        #endregion

        #region "T_VerificationRecord(核销申请单) - Method"

        /// <summary>
        /// 新增/删除/修改 T_VerificationRecordEntity (核销申请单)
        /// </summary>
        /// <param name="fam">T_VerificationRecordEntity实体类</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public static Int32 T_VerificationRecordInsertUpdateDelete(T_VerificationRecordEntity fam)
        {
            return DataProvider.Instance().T_VerificationRecordInsertUpdateDelete(fam);
        }

        /// <summary>
        /// 根据ID返回 T_VerificationRecordEntity实体类 单笔资料 (核销申请单)
        /// </summary>
        /// <param name="ID">ID ID</param>
        /// <returns>返回 T_VerificationRecordEntity实体类 ID为0则无记录</returns>
        public static T_VerificationRecordEntity T_VerificationRecordDisp(Int32 ID)
        {
            T_VerificationRecordEntity fam = new T_VerificationRecordEntity();
            QueryParam qp = new QueryParam();
            qp.PageIndex = 1;
            qp.PageSize = 1;
            qp.Where = string.Format(" Where {0}.{1} = {2}", "T_VerificationRecord", "ID", ID);
            int RecordCount = 0;
            List<T_VerificationRecordEntity> lst = T_VerificationRecordList(qp, out RecordCount);
            if (RecordCount > 0)
            {
                fam = lst[0];
            }
            return fam;
        }

        /// <summary>
        /// 返回T_VerificationRecordEntity实体类的List对象 (核销申请单)
        /// </summary>
        /// <param name="qp">查询类(非安全函数,传入参数请进行Sql字符串过滤)</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>T_VerificationRecordEntity实体类的List对象(核销申请单)</returns>
        public static List<T_VerificationRecordEntity> T_VerificationRecordList(QueryParam qp, out int RecordCount)
        {
            qp.TableName = "T_VerificationRecord";
            if (qp.Orderfld == null)
            {
                qp.Orderfld = "ID";
            }
            else if (qp.Orderfld != "ID")
            {
                qp.Orderfld += ",ID";
            }

            if (qp.ReturnFields == null)
            {
                qp.ReturnFields = "*";
            }
            else
            {
                qp.ReturnFields += ",";
                qp.ReturnFields += qp.Orderfld;
            }
            return DataProvider.Instance().T_VerificationRecordList(qp, out RecordCount);
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
        public static string get_table_fileds(string table_name, string table_fileds, string where_fileds, string where_value)
        {
            return DataProvider.Instance().get_table_fileds(table_name, table_fileds, where_fileds, where_value);
        }
        #endregion

        #region "列新表中字段值"
        /// <summary>
        /// 更新表中字段值(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="Table">表名</param>
        /// <param name="Table_FiledsValue">需要更新值(不用带Set)</param>
        /// <param name="Wheres">更新条件(不用带Where)</param>
        /// <returns></returns>
        public static int Update_Table_Fileds(string Table, string Table_FiledsValue, string Wheres)
        {
            return DataProvider.Instance().Update_Table_Fileds(Table, Table_FiledsValue, Wheres);
        }

        #endregion
    }
}
