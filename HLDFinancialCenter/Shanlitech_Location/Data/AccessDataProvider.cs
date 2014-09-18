/********************************************************************************
     File:																
            AccessDataProvider.cs                         
     Description:
            Access数据库操作类
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
using System.Data.OleDb;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using Shanlitech_Location.Components;
using FrameWork.Components;

namespace Shanlitech_Location.Data
{
    /// <summary>
    /// Access数据库访问类
    /// </summary>
    public partial class AccessDataProvider : DataProvider
    {
        #region "AccessDataProvider"
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnString = string.Empty;
        /// <summary>
        /// 构造函数
        /// </summary>
        public AccessDataProvider()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            ConnString = string.Format("Provider=Microsoft.Jet.OleDb.4.0;Data Source={0}{1};Persist Security Info=True;", AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["Access"]);
        }
        /// <summary>
        /// 获取数据连接
        /// </summary>
        /// <returns></returns>
        public OleDbConnection GetSqlConnection()
        {
            try
            {
                return new OleDbConnection(ConnString);
            }
            catch
            {
                throw new Exception("没有提供数据庫连接字符串Access！");
            }
        }
        #endregion

        #region "T_BudgetDetail (预算明细) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_BudgetDetail (预算明细)
        /// </summary>
        /// <param name="fam">T_BudgetDetailEntity实体类实体类(预算明细)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_BudgetDetailInsertUpdateDelete(T_BudgetDetailEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_BudgetDetail(ProjID,EquipmentName,BudgetRevenue,Measurement,BudgetPrice,BudgetNumber,BudgetExpenditure,BalanceAmount,Supplier,Remark,Sort)VALUES(@ProjID,@EquipmentName,@BudgetRevenue,@Measurement,@BudgetPrice,@BudgetNumber,@BudgetExpenditure,@BalanceAmount,@Supplier,@Remark,@Sort)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //所属项目
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@BudgetRevenue", OleDbType.Currency).Value = fam.BudgetRevenue; //预算收入
                    cmd.Parameters.Add("@Measurement", OleDbType.VarWChar).Value = fam.Measurement; //计量单位
                    cmd.Parameters.Add("@BudgetPrice", OleDbType.Currency).Value = fam.BudgetPrice; //预算单价
                    cmd.Parameters.Add("@BudgetNumber", OleDbType.Integer).Value = fam.BudgetNumber; //预算数量
                    cmd.Parameters.Add("@BudgetExpenditure", OleDbType.Currency).Value = fam.BudgetExpenditure; //预算支出
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@Supplier", OleDbType.VarWChar).Value = fam.Supplier; //供货单位
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //备注
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //递增排序
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_BudgetDetail SET ProjID = @ProjID,EquipmentName = @EquipmentName,BudgetRevenue = @BudgetRevenue,Measurement = @Measurement,BudgetPrice = @BudgetPrice,BudgetNumber = @BudgetNumber,BudgetExpenditure = @BudgetExpenditure,BalanceAmount = @BalanceAmount,Supplier = @Supplier,Remark = @Remark,Sort = @Sort WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //所属项目
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@BudgetRevenue", OleDbType.Currency).Value = fam.BudgetRevenue; //预算收入
                    cmd.Parameters.Add("@Measurement", OleDbType.VarWChar).Value = fam.Measurement; //计量单位
                    cmd.Parameters.Add("@BudgetPrice", OleDbType.Currency).Value = fam.BudgetPrice; //预算单价
                    cmd.Parameters.Add("@BudgetNumber", OleDbType.Integer).Value = fam.BudgetNumber; //预算数量
                    cmd.Parameters.Add("@BudgetExpenditure", OleDbType.Currency).Value = fam.BudgetExpenditure; //预算支出
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@Supplier", OleDbType.VarWChar).Value = fam.Supplier; //供货单位
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //备注
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //递增排序
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_BudgetDetail  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_ClassDic (T_ClassDic) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ClassDic (T_ClassDic)
        /// </summary>
        /// <param name="fam">T_ClassDicEntity实体类实体类(T_ClassDic)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ClassDicInsertUpdateDelete(T_ClassDicEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_ClassDic(ClassNO,ClassName,ParentClassNO,State,CreateTime,UpdateTime,Sort)VALUES(@ClassNO,@ClassName,@ParentClassNO,@State,@CreateTime,@UpdateTime,@Sort)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //类别名称
                    cmd.Parameters.Add("@ClassName", OleDbType.VarWChar).Value = fam.ClassName; //类别名称
                    cmd.Parameters.Add("@ParentClassNO", OleDbType.VarChar).Value = fam.ParentClassNO; //父类
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建日期
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建日期
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新日期
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新日期
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //Sort
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_ClassDic SET ClassNO = @ClassNO,ClassName = @ClassName,ParentClassNO = @ParentClassNO,State = @State,CreateTime = @CreateTime,UpdateTime = @UpdateTime,Sort = @Sort WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //类别名称
                    cmd.Parameters.Add("@ClassName", OleDbType.VarWChar).Value = fam.ClassName; //类别名称
                    cmd.Parameters.Add("@ParentClassNO", OleDbType.VarChar).Value = fam.ParentClassNO; //父类
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建日期
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建日期
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新日期
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新日期
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //Sort
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_ClassDic  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_FundsRecord (经费使用申请单) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_FundsRecord (经费使用申请单)
        /// </summary>
        /// <param name="fam">T_FundsRecordEntity实体类实体类(经费使用申请单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_FundsRecordInsertUpdateDelete(T_FundsRecordEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_FundsRecord(ProjID,BalanceAmount,UseRemark,AdvanceAmount,Applicant,Checker,Approver,TransferState,State,AppricationTime,CheckTime,ApprovalTime,IntegrityCheckCode,ShenHeState,PiZhunState,CunDangState,note)VALUES(@ProjID,@BalanceAmount,@UseRemark,@AdvanceAmount,@Applicant,@Checker,@Approver,@TransferState,@State,@AppricationTime,@CheckTime,@ApprovalTime,@IntegrityCheckCode,@ShenHeState,@PiZhunState,@CunDangState,@note)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //预算项目
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@UseRemark", OleDbType.VarWChar).Value = fam.UseRemark; //申请用途
                    cmd.Parameters.Add("@AdvanceAmount", OleDbType.Currency).Value = fam.AdvanceAmount; //支出金额
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Checker", OleDbType.Integer).Value = fam.Checker; //审核人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@TransferState", OleDbType.Integer).Value = fam.TransferState; //流转状态（0为申请状态，1为审核状态，2为批准状态）
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态（0为流转状态，1为存档状态，9为删除）
                    if (fam.AppricationTime.HasValue)
                        cmd.Parameters.Add("@AppricationTime", OleDbType.Date).Value = fam.AppricationTime; //申请时间
                    else
                        cmd.Parameters.Add("@AppricationTime", OleDbType.Date).Value = DBNull.Value; //申请时间
                    if (fam.CheckTime.HasValue)
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = fam.CheckTime; //审核时间
                    else
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = DBNull.Value; //审核时间
                    if (fam.ApprovalTime.HasValue)
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = fam.ApprovalTime; //批准时间
                    else
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = DBNull.Value; //批准时间
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@ShenHeState", OleDbType.VarWChar).Value = fam.ShenHeState; //ShenHeState
                    cmd.Parameters.Add("@PiZhunState", OleDbType.VarWChar).Value = fam.PiZhunState; //PiZhunState
                    cmd.Parameters.Add("@CunDangState", OleDbType.VarWChar).Value = fam.CunDangState; //CunDangState
                    cmd.Parameters.Add("@note", OleDbType.VarWChar).Value = fam.note; //note
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_FundsRecord SET ProjID = @ProjID,BalanceAmount = @BalanceAmount,UseRemark = @UseRemark,AdvanceAmount = @AdvanceAmount,Applicant = @Applicant,Checker = @Checker,Approver = @Approver,TransferState = @TransferState,State = @State,AppricationTime = @AppricationTime,CheckTime = @CheckTime,ApprovalTime = @ApprovalTime,IntegrityCheckCode = @IntegrityCheckCode,ShenHeState = @ShenHeState,PiZhunState = @PiZhunState,CunDangState = @CunDangState,note = @note WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //预算项目
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@UseRemark", OleDbType.VarWChar).Value = fam.UseRemark; //申请用途
                    cmd.Parameters.Add("@AdvanceAmount", OleDbType.Currency).Value = fam.AdvanceAmount; //支出金额
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Checker", OleDbType.Integer).Value = fam.Checker; //审核人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@TransferState", OleDbType.Integer).Value = fam.TransferState; //流转状态（0为申请状态，1为审核状态，2为批准状态）
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态（0为流转状态，1为存档状态，9为删除）
                    if (fam.AppricationTime.HasValue)
                        cmd.Parameters.Add("@AppricationTime", OleDbType.Date).Value = fam.AppricationTime; //申请时间
                    else
                        cmd.Parameters.Add("@AppricationTime", OleDbType.Date).Value = DBNull.Value; //申请时间
                    if (fam.CheckTime.HasValue)
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = fam.CheckTime; //审核时间
                    else
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = DBNull.Value; //审核时间
                    if (fam.ApprovalTime.HasValue)
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = fam.ApprovalTime; //批准时间
                    else
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = DBNull.Value; //批准时间
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@ShenHeState", OleDbType.VarWChar).Value = fam.ShenHeState; //ShenHeState
                    cmd.Parameters.Add("@PiZhunState", OleDbType.VarWChar).Value = fam.PiZhunState; //PiZhunState
                    cmd.Parameters.Add("@CunDangState", OleDbType.VarWChar).Value = fam.CunDangState; //CunDangState
                    cmd.Parameters.Add("@note", OleDbType.VarWChar).Value = fam.note; //note
                    cmd.Parameters.Add("@自增ID", OleDbType.Integer).Value = fam.ID; //自增ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_FundsRecord  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //自增ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_OutboundRecord (出库表单) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_OutboundRecord (出库表单)
        /// </summary>
        /// <param name="fam">T_OutboundRecordEntity实体类实体类(出库表单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_OutboundRecordInsertUpdateDelete(T_OutboundRecordEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_OutboundRecord(ProjectNO,EquipmentName,Model,OutboundNumber,BalanceNumber,OutboundTime,Applicant,Approver,IntegrityCheckCode,Remark,CodeNO)VALUES(@ProjectNO,@EquipmentName,@Model,@OutboundNumber,@BalanceNumber,@OutboundTime,@Applicant,@Approver,@IntegrityCheckCode,@Remark,@CodeNO)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目名称
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@OutboundNumber", OleDbType.Integer).Value = fam.OutboundNumber; //数量
                    cmd.Parameters.Add("@BalanceNumber", OleDbType.Integer).Value = fam.BalanceNumber; //结余
                    if (fam.OutboundTime.HasValue)
                        cmd.Parameters.Add("@OutboundTime", OleDbType.Date).Value = fam.OutboundTime; //领取时间
                    else
                        cmd.Parameters.Add("@OutboundTime", OleDbType.Date).Value = DBNull.Value; //领取时间
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //Remark
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_OutboundRecord SET ProjectNO = @ProjectNO,EquipmentName = @EquipmentName,Model = @Model,OutboundNumber = @OutboundNumber,BalanceNumber = @BalanceNumber,OutboundTime = @OutboundTime,Applicant = @Applicant,Approver = @Approver,IntegrityCheckCode = @IntegrityCheckCode,Remark = @Remark,CodeNO = @CodeNO WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目名称
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@OutboundNumber", OleDbType.Integer).Value = fam.OutboundNumber; //数量
                    cmd.Parameters.Add("@BalanceNumber", OleDbType.Integer).Value = fam.BalanceNumber; //结余
                    if (fam.OutboundTime.HasValue)
                        cmd.Parameters.Add("@OutboundTime", OleDbType.Date).Value = fam.OutboundTime; //领取时间
                    else
                        cmd.Parameters.Add("@OutboundTime", OleDbType.Date).Value = DBNull.Value; //领取时间
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //Remark
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_OutboundRecord  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_ProjectBudget (项目预算) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectBudget (项目预算)
        /// </summary>
        /// <param name="fam">T_ProjectBudgetEntity实体类实体类(项目预算)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ProjectBudgetInsertUpdateDelete(T_ProjectBudgetEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_ProjectBudget(ProjectNO,SubjectNO,ClassNO,AnnualNO,BudgetRevenue,BudgetExpenditure,BalanceAmount,Leader,Undertaker,State,CreateTime,UpdateTime,Sort,DepartmentID)VALUES(@ProjectNO,@SubjectNO,@ClassNO,@AnnualNO,@BudgetRevenue,@BudgetExpenditure,@BalanceAmount,@Leader,@Undertaker,@State,@CreateTime,@UpdateTime,@Sort,@DepartmentID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目编号
                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //所属科目
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@AnnualNO", OleDbType.VarChar).Value = fam.AnnualNO; //所属年度
                    cmd.Parameters.Add("@BudgetRevenue", OleDbType.Currency).Value = fam.BudgetRevenue; //预算收入
                    cmd.Parameters.Add("@BudgetExpenditure", OleDbType.Currency).Value = fam.BudgetExpenditure; //预算支出
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@Leader", OleDbType.Integer).Value = fam.Leader; //项目组长
                    cmd.Parameters.Add("@Undertaker", OleDbType.Integer).Value = fam.Undertaker; //指定承办人
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新时间
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新时间
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //递增排序
                    cmd.Parameters.Add("@DepartmentID", OleDbType.Integer).Value = fam.DepartmentID; //所在部门
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_ProjectBudget SET ProjectNO = @ProjectNO,SubjectNO = @SubjectNO,ClassNO = @ClassNO,AnnualNO = @AnnualNO,BudgetRevenue = @BudgetRevenue,BudgetExpenditure = @BudgetExpenditure,BalanceAmount = @BalanceAmount,Leader = @Leader,Undertaker = @Undertaker,State = @State,CreateTime = @CreateTime,UpdateTime = @UpdateTime,Sort = @Sort,DepartmentID = @DepartmentID WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目编号
                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //所属科目
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@AnnualNO", OleDbType.VarChar).Value = fam.AnnualNO; //所属年度
                    cmd.Parameters.Add("@BudgetRevenue", OleDbType.Currency).Value = fam.BudgetRevenue; //预算收入
                    cmd.Parameters.Add("@BudgetExpenditure", OleDbType.Currency).Value = fam.BudgetExpenditure; //预算支出
                    cmd.Parameters.Add("@BalanceAmount", OleDbType.Currency).Value = fam.BalanceAmount; //经费余额
                    cmd.Parameters.Add("@Leader", OleDbType.Integer).Value = fam.Leader; //项目组长
                    cmd.Parameters.Add("@Undertaker", OleDbType.Integer).Value = fam.Undertaker; //指定承办人
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新时间
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新时间
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //递增排序
                    cmd.Parameters.Add("@DepartmentID", OleDbType.Integer).Value = fam.DepartmentID; //所在部门
                    cmd.Parameters.Add("@项目编号", OleDbType.Integer).Value = fam.ID; //项目编号
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_ProjectBudget  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //项目编号
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_ProjectDic (T_ProjectDic) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_ProjectDic (T_ProjectDic)
        /// </summary>
        /// <param name="fam">T_ProjectDicEntity实体类实体类(T_ProjectDic)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_ProjectDicInsertUpdateDelete(T_ProjectDicEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_ProjectDic(ProjectNO,ProjectName,SubjectNO,ClassNO,State,CreateTime,UpdateTime)VALUES(@ProjectNO,@ProjectName,@SubjectNO,@ClassNO,@State,@CreateTime,@UpdateTime)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目编号
                    cmd.Parameters.Add("@ProjectName", OleDbType.VarWChar).Value = fam.ProjectName; //ProjectName
                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //所属科目
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //CreateTime
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //CreateTime
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //UpdateTime
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //UpdateTime
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_ProjectDic SET ProjectNO = @ProjectNO,ProjectName = @ProjectName,SubjectNO = @SubjectNO,ClassNO = @ClassNO,State = @State,CreateTime = @CreateTime,UpdateTime = @UpdateTime WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //项目编号
                    cmd.Parameters.Add("@ProjectName", OleDbType.VarWChar).Value = fam.ProjectName; //ProjectName
                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //所属科目
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //CreateTime
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //CreateTime
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //UpdateTime
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //UpdateTime
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_ProjectDic  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_Stock (库存) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_Stock (库存)
        /// </summary>
        /// <param name="fam">T_StockEntity实体类实体类(库存)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StockInsertUpdateDelete(T_StockEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_Stock(EquipmentName,Model,StockNumber,CodeNO)VALUES(@EquipmentName,@Model,@StockNumber,@CodeNO)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@StockNumber", OleDbType.Integer).Value = fam.StockNumber; //库存量
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //编码号
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_Stock SET EquipmentName = @EquipmentName,Model = @Model,StockNumber = @StockNumber,CodeNO = @CodeNO WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@StockNumber", OleDbType.Integer).Value = fam.StockNumber; //库存量
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //编码号
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_Stock  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_StockLog (出入库日志) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StockLog (出入库日志)
        /// </summary>
        /// <param name="fam">T_StockLogEntity实体类实体类(出入库日志)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StockLogInsertUpdateDelete(T_StockLogEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_StockLog(CodeNO,DealType,Number,Handler,StorID,OutbID,LogTime)VALUES(@CodeNO,@DealType,@Number,@Handler,@StorID,@OutbID,@LogTime)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                    cmd.Parameters.Add("@DealType", OleDbType.Integer).Value = fam.DealType; //处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
                    cmd.Parameters.Add("@Number", OleDbType.Integer).Value = fam.Number; //数量
                    cmd.Parameters.Add("@Handler", OleDbType.Integer).Value = fam.Handler; //操作者
                    cmd.Parameters.Add("@StorID", OleDbType.Integer).Value = fam.StorID; //入库单ID
                    cmd.Parameters.Add("@OutbID", OleDbType.Integer).Value = fam.OutbID; //出库单ID
                    if (fam.LogTime.HasValue)
                        cmd.Parameters.Add("@LogTime", OleDbType.Date).Value = fam.LogTime; //记录时间
                    else
                        cmd.Parameters.Add("@LogTime", OleDbType.Date).Value = DBNull.Value; //记录时间
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_StockLog SET CodeNO = @CodeNO,DealType = @DealType,Number = @Number,Handler = @Handler,StorID = @StorID,OutbID = @OutbID,LogTime = @LogTime WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                    cmd.Parameters.Add("@DealType", OleDbType.Integer).Value = fam.DealType; //处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
                    cmd.Parameters.Add("@Number", OleDbType.Integer).Value = fam.Number; //数量
                    cmd.Parameters.Add("@Handler", OleDbType.Integer).Value = fam.Handler; //操作者
                    cmd.Parameters.Add("@StorID", OleDbType.Integer).Value = fam.StorID; //入库单ID
                    cmd.Parameters.Add("@OutbID", OleDbType.Integer).Value = fam.OutbID; //出库单ID
                    if (fam.LogTime.HasValue)
                        cmd.Parameters.Add("@LogTime", OleDbType.Date).Value = fam.LogTime; //记录时间
                    else
                        cmd.Parameters.Add("@LogTime", OleDbType.Date).Value = DBNull.Value; //记录时间
                    cmd.Parameters.Add("@自增ID", OleDbType.Integer).Value = fam.ID; //自增ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_StockLog  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //自增ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_StorageRecord (入库表单) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_StorageRecord (入库表单)
        /// </summary>
        /// <param name="fam">T_StorageRecordEntity实体类实体类(入库表单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_StorageRecordInsertUpdateDelete(T_StorageRecordEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_StorageRecord(VeriID,ProjectNO,EquipmentName,Model,StorageNumber,UnitPrice,StorageTime,Applicant,Approver,PayAmount,IntegrityCheckCode,Remark,CodeNO)VALUES(@VeriID,@ProjectNO,@EquipmentName,@Model,@StorageNumber,@UnitPrice,@StorageTime,@Applicant,@Approver,@PayAmount,@IntegrityCheckCode,@Remark,@CodeNO)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@VeriID", OleDbType.Integer).Value = fam.VeriID; //所属核销
                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //所属项目
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@StorageNumber", OleDbType.Integer).Value = fam.StorageNumber; //数量
                    cmd.Parameters.Add("@UnitPrice", OleDbType.Currency).Value = fam.UnitPrice; //单价
                    if (fam.StorageTime.HasValue)
                        cmd.Parameters.Add("@StorageTime", OleDbType.Date).Value = fam.StorageTime; //入库时间
                    else
                        cmd.Parameters.Add("@StorageTime", OleDbType.Date).Value = DBNull.Value; //入库时间
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@PayAmount", OleDbType.Currency).Value = fam.PayAmount; //实际支出
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //Remark
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_StorageRecord SET VeriID = @VeriID,ProjectNO = @ProjectNO,EquipmentName = @EquipmentName,Model = @Model,StorageNumber = @StorageNumber,UnitPrice = @UnitPrice,StorageTime = @StorageTime,Applicant = @Applicant,Approver = @Approver,PayAmount = @PayAmount,IntegrityCheckCode = @IntegrityCheckCode,Remark = @Remark,CodeNO = @CodeNO WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@VeriID", OleDbType.Integer).Value = fam.VeriID; //所属核销
                    cmd.Parameters.Add("@ProjectNO", OleDbType.VarChar).Value = fam.ProjectNO; //所属项目
                    cmd.Parameters.Add("@EquipmentName", OleDbType.VarWChar).Value = fam.EquipmentName; //器材名称
                    cmd.Parameters.Add("@Model", OleDbType.VarChar).Value = fam.Model; //型号
                    cmd.Parameters.Add("@StorageNumber", OleDbType.Integer).Value = fam.StorageNumber; //数量
                    cmd.Parameters.Add("@UnitPrice", OleDbType.Currency).Value = fam.UnitPrice; //单价
                    if (fam.StorageTime.HasValue)
                        cmd.Parameters.Add("@StorageTime", OleDbType.Date).Value = fam.StorageTime; //入库时间
                    else
                        cmd.Parameters.Add("@StorageTime", OleDbType.Date).Value = DBNull.Value; //入库时间
                    cmd.Parameters.Add("@Applicant", OleDbType.Integer).Value = fam.Applicant; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.Integer).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@PayAmount", OleDbType.Currency).Value = fam.PayAmount; //实际支出
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@Remark", OleDbType.VarWChar).Value = fam.Remark; //Remark
                    cmd.Parameters.Add("@CodeNO", OleDbType.VarChar).Value = fam.CodeNO; //库存资产编码号
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_StorageRecord  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_SubjectDic (预算科目) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_SubjectDic (预算科目)
        /// </summary>
        /// <param name="fam">T_SubjectDicEntity实体类实体类(预算科目)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_SubjectDicInsertUpdateDelete(T_SubjectDicEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_SubjectDic(SubjectNO,SubjectName,ClassNO,State,CreateTime,UpdateTime,Sort)VALUES(@SubjectNO,@SubjectName,@ClassNO,@State,@CreateTime,@UpdateTime,@Sort)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //科目编号
                    cmd.Parameters.Add("@SubjectName", OleDbType.VarWChar).Value = fam.SubjectName; //科目名称
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新时间
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新时间
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //Sort
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_SubjectDic SET SubjectNO = @SubjectNO,SubjectName = @SubjectName,ClassNO = @ClassNO,State = @State,CreateTime = @CreateTime,UpdateTime = @UpdateTime,Sort = @Sort WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@SubjectNO", OleDbType.VarChar).Value = fam.SubjectNO; //科目编号
                    cmd.Parameters.Add("@SubjectName", OleDbType.VarWChar).Value = fam.SubjectName; //科目名称
                    cmd.Parameters.Add("@ClassNO", OleDbType.VarChar).Value = fam.ClassNO; //所属类别
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //状态(0为正常，9为删除)
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.UpdateTime.HasValue)
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = fam.UpdateTime; //更新时间
                    else
                        cmd.Parameters.Add("@UpdateTime", OleDbType.Date).Value = DBNull.Value; //更新时间
                    cmd.Parameters.Add("@Sort", OleDbType.Integer).Value = fam.Sort; //Sort
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_SubjectDic  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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

        #region "T_VerificationRecord (核销申请单) - AccessDataProvider"

        /// <summary>
        /// 新增/删除/修改 T_VerificationRecord (核销申请单)
        /// </summary>
        /// <param name="fam">T_VerificationRecordEntity实体类实体类(核销申请单)</param>
        /// <returns>-1:存储过程执行失败,-2:存在相同的主键,Insert:返回插入自动ID,Update:返回更新记录数,Delete:返回删除记录数</returns>
        public override Int32 T_VerificationRecordInsertUpdateDelete(T_VerificationRecordEntity fam)
        {
            Int32 rInt = -1;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string CommTxt;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = Conn;
                Conn.Open();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {

                    CommTxt = "Insert into 	T_VerificationRecord(FundID,ProjID,InvoiceFolder,ContractFolder,Undertaker,Checker,Approver,TransferState,State,CreateTime,CheckTime,ApprovalTime,PayAmount,IntegrityCheckCode,ShenHeNote,PiZhunNote,CunDangNote)VALUES(@FundID,@ProjID,@InvoiceFolder,@ContractFolder,@Undertaker,@Checker,@Approver,@TransferState,@State,@CreateTime,@CheckTime,@ApprovalTime,@PayAmount,@IntegrityCheckCode,@ShenHeNote,@PiZhunNote,@CunDangNote)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@FundID", OleDbType.Integer).Value = fam.FundID; //所属经费申请单
                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //所属项目
                    cmd.Parameters.Add("@InvoiceFolder", OleDbType.VarChar).Value = fam.InvoiceFolder; //发票联
                    cmd.Parameters.Add("@ContractFolder", OleDbType.VarChar).Value = fam.ContractFolder; //合同协议
                    cmd.Parameters.Add("@Undertaker", OleDbType.Integer).Value = fam.Undertaker; //承办人
                    cmd.Parameters.Add("@Checker", OleDbType.Integer).Value = fam.Checker; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.BigInt).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@TransferState", OleDbType.Integer).Value = fam.TransferState; //流转状态（0为申请状态，1为审核状态，2为批准状态）
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //存档状态（0为流转状态，1为存档状态，9为删除）
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.CheckTime.HasValue)
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = fam.CheckTime; //审核时间
                    else
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = DBNull.Value; //审核时间
                    if (fam.ApprovalTime.HasValue)
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = fam.ApprovalTime; //批准时间
                    else
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = DBNull.Value; //批准时间
                    cmd.Parameters.Add("@PayAmount", OleDbType.Currency).Value = fam.PayAmount; //实际支出
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@ShenHeNote", OleDbType.VarWChar).Value = fam.ShenHeNote; //审核状态备注
                    cmd.Parameters.Add("@PiZhunNote", OleDbType.VarWChar).Value = fam.PiZhunNote; //批准状态备注
                    cmd.Parameters.Add("@CunDangNote", OleDbType.VarWChar).Value = fam.CunDangNote; //CunDangNote
                }
                else if (fam.DataTable_Action_.ToString() == "Update")
                {

                    CommTxt = "UPDATE T_VerificationRecord SET FundID = @FundID,ProjID = @ProjID,InvoiceFolder = @InvoiceFolder,ContractFolder = @ContractFolder,Undertaker = @Undertaker,Checker = @Checker,Approver = @Approver,TransferState = @TransferState,State = @State,CreateTime = @CreateTime,CheckTime = @CheckTime,ApprovalTime = @ApprovalTime,PayAmount = @PayAmount,IntegrityCheckCode = @IntegrityCheckCode,ShenHeNote = @ShenHeNote,PiZhunNote = @PiZhunNote,CunDangNote = @CunDangNote WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;

                    cmd.Parameters.Add("@FundID", OleDbType.Integer).Value = fam.FundID; //所属经费申请单
                    cmd.Parameters.Add("@ProjID", OleDbType.Integer).Value = fam.ProjID; //所属项目
                    cmd.Parameters.Add("@InvoiceFolder", OleDbType.VarChar).Value = fam.InvoiceFolder; //发票联
                    cmd.Parameters.Add("@ContractFolder", OleDbType.VarChar).Value = fam.ContractFolder; //合同协议
                    cmd.Parameters.Add("@Undertaker", OleDbType.Integer).Value = fam.Undertaker; //承办人
                    cmd.Parameters.Add("@Checker", OleDbType.Integer).Value = fam.Checker; //申请人
                    cmd.Parameters.Add("@Approver", OleDbType.BigInt).Value = fam.Approver; //批准人
                    cmd.Parameters.Add("@TransferState", OleDbType.Integer).Value = fam.TransferState; //流转状态（0为申请状态，1为审核状态，2为批准状态）
                    cmd.Parameters.Add("@State", OleDbType.Integer).Value = fam.State; //存档状态（0为流转状态，1为存档状态，9为删除）
                    if (fam.CreateTime.HasValue)
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = fam.CreateTime; //创建时间
                    else
                        cmd.Parameters.Add("@CreateTime", OleDbType.Date).Value = DBNull.Value; //创建时间
                    if (fam.CheckTime.HasValue)
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = fam.CheckTime; //审核时间
                    else
                        cmd.Parameters.Add("@CheckTime", OleDbType.Date).Value = DBNull.Value; //审核时间
                    if (fam.ApprovalTime.HasValue)
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = fam.ApprovalTime; //批准时间
                    else
                        cmd.Parameters.Add("@ApprovalTime", OleDbType.Date).Value = DBNull.Value; //批准时间
                    cmd.Parameters.Add("@PayAmount", OleDbType.Currency).Value = fam.PayAmount; //实际支出
                    cmd.Parameters.Add("@IntegrityCheckCode", OleDbType.VarChar).Value = fam.IntegrityCheckCode; //信息完整性校验码
                    cmd.Parameters.Add("@ShenHeNote", OleDbType.VarWChar).Value = fam.ShenHeNote; //审核状态备注
                    cmd.Parameters.Add("@PiZhunNote", OleDbType.VarWChar).Value = fam.PiZhunNote; //批准状态备注
                    cmd.Parameters.Add("@CunDangNote", OleDbType.VarWChar).Value = fam.CunDangNote; //CunDangNote
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else if (fam.DataTable_Action_.ToString() == "Delete")
                {
                    CommTxt = "Delete from  T_VerificationRecord  WHERE (ID = @ID)";
                    cmd.CommandText = CommTxt;
                    cmd.Parameters.Add("@ID", OleDbType.Integer).Value = fam.ID; //ID
                }
                else
                    throw new ApplicationException("无法识别的操作命令!");

                rInt = cmd.ExecuteNonQuery();
                if (fam.DataTable_Action_.ToString() == "Insert")
                {
                    cmd.CommandText = "SELECT @@identity";
                    rInt = Convert.ToInt32(cmd.ExecuteScalar());
                }
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
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("select {0} from {1} where ucase({2})='{3}'", table_fileds, table_name, where_fileds, where_value);
                OleDbCommand cmd = new OleDbCommand(strSql, Conn);
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                OleDbDataReader dr = cmd.ExecuteReader();
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
            int rInt = 0;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                string strSql = string.Format("Update {0} Set {1}  Where {2}", Table, Table_FiledsValue, Wheres);
                OleDbCommand cmd = new OleDbCommand(strSql, Conn);
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
          
        #region "公共查询数据函数Access版"
        /// <summary>
        /// 公共查询数据函数Access版(非安全函数,传入参数请进行Sql字符串过滤)
        /// </summary>
        /// <param name="pd">委托对象</param>
        /// <param name="pp">查询字符串</param>
        /// <param name="RecordCount">返回记录总数</param>
        /// <returns>返回记录集List</returns>
        private List<T> GetRecordList<T>(PopulateDelegate<T> pd, QueryParam pp, out int RecordCount)
        {
            List<T> lst = new List<T>();
            RecordCount = 0;
            using (OleDbConnection Conn = GetSqlConnection())
            {
                StringBuilder sb = new StringBuilder();
                OleDbCommand cmd = new OleDbCommand();
                OleDbDataReader dr = null;
                cmd.Connection = Conn;

                int TotalRecordForPageIndex = pp.PageIndex * pp.PageSize;
                string OrderBy;
                string CutOrderBy;
                if (pp.OrderType == 1)
                {
                    OrderBy = " Order by " + pp.Orderfld.Replace(","," desc,") + " desc ";
                    CutOrderBy = " Order by " + pp.Orderfld.Replace(","," asc,") + " asc ";
                }
                else
                {
                    OrderBy = " Order by " + pp.Orderfld.Replace(",", " asc,") + " asc ";
                    CutOrderBy = " Order by " + pp.Orderfld.Replace(",", " desc,") + " desc ";
                }
                sb.AppendFormat("SELECT * FROM (SELECT TOP {0} * FROM (SELECT TOP {1} {2}	FROM {3} {4} {5}) TB2	{6}) TB3 {5} ", pp.PageSize, TotalRecordForPageIndex, pp.ReturnFields, pp.TableName, pp.Where, OrderBy, CutOrderBy);
                cmd.CommandText = sb.ToString();
                Conn.Open();
                dr = cmd.ExecuteReader();
                Dictionary<string, string> Fileds = new Dictionary<string,string>();
                foreach (DataRow var in dr.GetSchemaTable().Select())
                {
                    Fileds.Add(var[0].ToString(), var[0].ToString());
                }
                while (dr.Read())
                {
                    lst.Add(pd(dr,Fileds));
                }
                dr.Close();
                cmd.Parameters.Clear();
                // 取记录总数
                cmd.CommandText = string.Format("SELECT Count(1) From {0} {1}", pp.TableName, pp.Where);
                RecordCount = Convert.ToInt32(cmd.ExecuteScalar());
                dr.Dispose();
                dr.Close();
                cmd.Dispose();
                Conn.Dispose();
                Conn.Close();
            }
            return lst;
        }
        #endregion
    }
} 
  