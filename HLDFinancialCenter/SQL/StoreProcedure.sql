if exists (select * from dbo.sysobjects where id = object_id(N'[T_BudgetDetail_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_BudgetDetail_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_BudgetDetail_InsertUpdateDelete
Description:
            T_BudgetDetail(预算明细) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:19
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_BudgetDetail_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @ProjID  int = 0,	-- 所属项目
    @EquipmentName  nvarchar(50) = '',	-- 器材名称
    @BudgetRevenue  float = 0,	-- 预算收入
    @Measurement  nvarchar(50) = '',	-- 计量单位
    @BudgetPrice  float = 0,	-- 预算单价
    @BudgetNumber  int = 0,	-- 预算数量
    @BudgetExpenditure  float = 0,	-- 预算支出
    @BalanceAmount  float = 0,	-- 经费余额
    @Supplier  nvarchar(50) = '',	-- 供货单位
    @Remark  nvarchar(50) = '',	-- 备注
    @Sort  int = 0,	-- 递增排序
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_BudgetDetail(
            ProjID , 
            EquipmentName , 
            BudgetRevenue , 
            Measurement , 
            BudgetPrice , 
            BudgetNumber , 
            BudgetExpenditure , 
            BalanceAmount , 
            Supplier , 
            Remark , 
            Sort
        ) VALUES (
            @ProjID , 
            @EquipmentName , 
            @BudgetRevenue , 
            @Measurement , 
            @BudgetPrice , 
            @BudgetNumber , 
            @BudgetExpenditure , 
            @BalanceAmount , 
            @Supplier , 
            @Remark , 
            @Sort
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_BudgetDetail SET 
            ProjID=@ProjID , 
            EquipmentName=@EquipmentName , 
            BudgetRevenue=@BudgetRevenue , 
            Measurement=@Measurement , 
            BudgetPrice=@BudgetPrice , 
            BudgetNumber=@BudgetNumber , 
            BudgetExpenditure=@BudgetExpenditure , 
            BalanceAmount=@BalanceAmount , 
            Supplier=@Supplier , 
            Remark=@Remark , 
            Sort=@Sort
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_BudgetDetail	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_ClassDic_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_ClassDic_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_ClassDic_InsertUpdateDelete
Description:
            T_ClassDic(T_ClassDic) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_ClassDic_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @ClassNO  varchar(50) = '',	-- 类别名称
    @ClassName  nvarchar(50) = '',	-- 类别名称
    @ParentClassNO  varchar(50) = '',	-- 父类
    @State  int = 0,	-- 状态(0为正常，9为删除)
    @CreateTime  datetime = getdate,	-- 创建日期
    @UpdateTime  datetime = getdate,	-- 更新日期
    @Sort  int = 0,	-- Sort
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_ClassDic(
            ClassNO , 
            ClassName , 
            ParentClassNO , 
            State , 
            CreateTime , 
            UpdateTime , 
            Sort
        ) VALUES (
            @ClassNO , 
            @ClassName , 
            @ParentClassNO , 
            @State , 
            @CreateTime , 
            @UpdateTime , 
            @Sort
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_ClassDic SET 
            ClassNO=@ClassNO , 
            ClassName=@ClassName , 
            ParentClassNO=@ParentClassNO , 
            State=@State , 
            CreateTime=@CreateTime , 
            UpdateTime=@UpdateTime , 
            Sort=@Sort
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_ClassDic	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_FundsRecord_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_FundsRecord_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_FundsRecord_InsertUpdateDelete
Description:
            T_FundsRecord(经费使用申请单) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_FundsRecord_InsertUpdateDelete
(

    @ID  int = 0,	-- 自增ID
    @ProjID  int = 0,	-- 预算项目
    @BalanceAmount  float = 0,	-- 经费余额
    @UseRemark  nvarchar(50) = '',	-- 申请用途
    @AdvanceAmount  float = 0,	-- 支出金额
    @Applicant  int = 0,	-- 申请人
    @Checker  int = 0,	-- 审核人
    @Approver  int = 0,	-- 批准人
    @TransferState  int = 0,	-- 流转状态（0为申请状态，1为审核状态，2为批准状态）
    @State  int = 0,	-- 状态（0为流转状态，1为存档状态，9为删除）
    @AppricationTime  datetime = getdate,	-- 申请时间
    @CheckTime  datetime = getdate,	-- 审核时间
    @ApprovalTime  datetime = getdate,	-- 批准时间
    @IntegrityCheckCode  varchar(50) = '',	-- 信息完整性校验码
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_FundsRecord(
            ProjID , 
            BalanceAmount , 
            UseRemark , 
            AdvanceAmount , 
            Applicant , 
            Checker , 
            Approver , 
            TransferState , 
            State , 
            AppricationTime , 
            CheckTime , 
            ApprovalTime , 
            IntegrityCheckCode
        ) VALUES (
            @ProjID , 
            @BalanceAmount , 
            @UseRemark , 
            @AdvanceAmount , 
            @Applicant , 
            @Checker , 
            @Approver , 
            @TransferState , 
            @State , 
            @AppricationTime , 
            @CheckTime , 
            @ApprovalTime , 
            @IntegrityCheckCode
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_FundsRecord SET 
            ProjID=@ProjID , 
            BalanceAmount=@BalanceAmount , 
            UseRemark=@UseRemark , 
            AdvanceAmount=@AdvanceAmount , 
            Applicant=@Applicant , 
            Checker=@Checker , 
            Approver=@Approver , 
            TransferState=@TransferState , 
            State=@State , 
            AppricationTime=@AppricationTime , 
            CheckTime=@CheckTime , 
            ApprovalTime=@ApprovalTime , 
            IntegrityCheckCode=@IntegrityCheckCode
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_FundsRecord	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_OutboundRecord_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_OutboundRecord_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_OutboundRecord_InsertUpdateDelete
Description:
            T_OutboundRecord(出库表单) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_OutboundRecord_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @ProjectNO  varchar(50) = '',	-- 项目名称
    @EquipmentName  nvarchar(50) = '',	-- 器材名称
    @Model  varchar(50) = '',	-- 型号
    @OutboundNumber  int = 0,	-- 数量
    @BalanceNumber  int = 0,	-- 结余
    @OutboundTime  datetime = getdate,	-- 领取时间
    @Applicant  int = 0,	-- 申请人
    @Approver  int = 0,	-- 批准人
    @IntegrityCheckCode  varchar(50) = '',	-- 信息完整性校验码
    @Remark  nvarchar(50) = '',	-- Remark
    @CodeNO  varchar(50) = '',	-- 库存资产编码号
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_OutboundRecord(
            ProjectNO , 
            EquipmentName , 
            Model , 
            OutboundNumber , 
            BalanceNumber , 
            OutboundTime , 
            Applicant , 
            Approver , 
            IntegrityCheckCode , 
            Remark , 
            CodeNO
        ) VALUES (
            @ProjectNO , 
            @EquipmentName , 
            @Model , 
            @OutboundNumber , 
            @BalanceNumber , 
            @OutboundTime , 
            @Applicant , 
            @Approver , 
            @IntegrityCheckCode , 
            @Remark , 
            @CodeNO
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_OutboundRecord SET 
            ProjectNO=@ProjectNO , 
            EquipmentName=@EquipmentName , 
            Model=@Model , 
            OutboundNumber=@OutboundNumber , 
            BalanceNumber=@BalanceNumber , 
            OutboundTime=@OutboundTime , 
            Applicant=@Applicant , 
            Approver=@Approver , 
            IntegrityCheckCode=@IntegrityCheckCode , 
            Remark=@Remark , 
            CodeNO=@CodeNO
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_OutboundRecord	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_ProjectBudget_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_ProjectBudget_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_ProjectBudget_InsertUpdateDelete
Description:
            T_ProjectBudget(项目预算) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_ProjectBudget_InsertUpdateDelete
(

    @ID  int = 0,	-- 项目编号
    @ProjectNO  varchar(50) = '',	-- 项目编号
    @SubjectNO  varchar(50) = '',	-- 所属科目
    @ClassNO  varchar(50) = '',	-- 所属类别
    @AnnualNO  varchar(50) = '',	-- 所属年度
    @BudgetRevenue  float = 0,	-- 预算收入
    @BudgetExpenditure  float = 0,	-- 预算支出
    @BalanceAmount  float = 0,	-- 经费余额
    @Leader  int = 0,	-- 项目组长
    @Undertaker  int = 0,	-- 指定承办人
    @State  int = 0,	-- 状态(0为正常，9为删除)
    @CreateTime  datetime = getdate,	-- 创建时间
    @UpdateTime  datetime = getdate,	-- 更新时间
    @Sort  int = 0,	-- 递增排序
    @DepartmentID  int = 0,	-- 所在部门
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_ProjectBudget(
            ProjectNO , 
            SubjectNO , 
            ClassNO , 
            AnnualNO , 
            BudgetRevenue , 
            BudgetExpenditure , 
            BalanceAmount , 
            Leader , 
            Undertaker , 
            State , 
            CreateTime , 
            UpdateTime , 
            Sort , 
            DepartmentID
        ) VALUES (
            @ProjectNO , 
            @SubjectNO , 
            @ClassNO , 
            @AnnualNO , 
            @BudgetRevenue , 
            @BudgetExpenditure , 
            @BalanceAmount , 
            @Leader , 
            @Undertaker , 
            @State , 
            @CreateTime , 
            @UpdateTime , 
            @Sort , 
            @DepartmentID
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_ProjectBudget SET 
            ProjectNO=@ProjectNO , 
            SubjectNO=@SubjectNO , 
            ClassNO=@ClassNO , 
            AnnualNO=@AnnualNO , 
            BudgetRevenue=@BudgetRevenue , 
            BudgetExpenditure=@BudgetExpenditure , 
            BalanceAmount=@BalanceAmount , 
            Leader=@Leader , 
            Undertaker=@Undertaker , 
            State=@State , 
            CreateTime=@CreateTime , 
            UpdateTime=@UpdateTime , 
            Sort=@Sort , 
            DepartmentID=@DepartmentID
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_ProjectBudget	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_ProjectDic_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_ProjectDic_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_ProjectDic_InsertUpdateDelete
Description:
            T_ProjectDic(T_ProjectDic) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_ProjectDic_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @ProjectNO  varchar(50) = '',	-- 项目编号
    @ProjectName  nvarchar(50) = '',	-- ProjectName
    @SubjectNO  varchar(50) = '',	-- 所属科目
    @ClassNO  varchar(50) = '',	-- 所属类别
    @State  int = 0,	-- 状态(0为正常，9为删除)
    @CreateTime  datetime = getdate,	-- CreateTime
    @UpdateTime  datetime = getdate,	-- UpdateTime
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_ProjectDic(
            ProjectNO , 
            ProjectName , 
            SubjectNO , 
            ClassNO , 
            State , 
            CreateTime , 
            UpdateTime
        ) VALUES (
            @ProjectNO , 
            @ProjectName , 
            @SubjectNO , 
            @ClassNO , 
            @State , 
            @CreateTime , 
            @UpdateTime
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_ProjectDic SET 
            ProjectNO=@ProjectNO , 
            ProjectName=@ProjectName , 
            SubjectNO=@SubjectNO , 
            ClassNO=@ClassNO , 
            State=@State , 
            CreateTime=@CreateTime , 
            UpdateTime=@UpdateTime
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_ProjectDic	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_Stock_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_Stock_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_Stock_InsertUpdateDelete
Description:
            T_Stock(库存) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:21
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_Stock_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @EquipmentName  nvarchar(50) = '',	-- 器材名称
    @Model  varchar(50) = '',	-- 型号
    @StockNumber  int = 0,	-- 库存量
    @CodeNO  varchar(50) = '',	-- 编码号
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_Stock(
            EquipmentName , 
            Model , 
            StockNumber , 
            CodeNO
        ) VALUES (
            @EquipmentName , 
            @Model , 
            @StockNumber , 
            @CodeNO
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_Stock SET 
            EquipmentName=@EquipmentName , 
            Model=@Model , 
            StockNumber=@StockNumber , 
            CodeNO=@CodeNO
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_Stock	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_StockLog_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_StockLog_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_StockLog_InsertUpdateDelete
Description:
            T_StockLog(出入库日志) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:22
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_StockLog_InsertUpdateDelete
(

    @ID  int = 0,	-- 自增ID
    @CodeNO  varchar(50) = '',	-- 库存资产编码号
    @DealType  int = 0,	-- 处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）
    @Number  int = 0,	-- 数量
    @Handler  int = 0,	-- 操作者
    @StorID  int = 0,	-- 入库单ID
    @OutbID  int = 0,	-- 出库单ID
    @LogTime  datetime = getdate,	-- 记录时间
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_StockLog(
            CodeNO , 
            DealType , 
            Number , 
            Handler , 
            StorID , 
            OutbID , 
            LogTime
        ) VALUES (
            @CodeNO , 
            @DealType , 
            @Number , 
            @Handler , 
            @StorID , 
            @OutbID , 
            @LogTime
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_StockLog SET 
            CodeNO=@CodeNO , 
            DealType=@DealType , 
            Number=@Number , 
            Handler=@Handler , 
            StorID=@StorID , 
            OutbID=@OutbID , 
            LogTime=@LogTime
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_StockLog	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_StorageRecord_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_StorageRecord_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_StorageRecord_InsertUpdateDelete
Description:
            T_StorageRecord(入库表单) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:22
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_StorageRecord_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @VeriID  int = 0,	-- 所属核销
    @ProjectNO  varchar(50) = '',	-- 所属项目
    @EquipmentName  nvarchar(50) = '',	-- 器材名称
    @Model  varchar(50) = '',	-- 型号
    @StorageNumber  int = 0,	-- 数量
    @UnitPrice  float = 0,	-- 单价
    @StorageTime  datetime = getdate,	-- 入库时间
    @Applicant  int = 0,	-- 申请人
    @Approver  int = 0,	-- 批准人
    @PayAmount  float = 0,	-- 实际支出
    @IntegrityCheckCode  varchar(50) = '',	-- 信息完整性校验码
    @Remark  nvarchar(50) = '',	-- Remark
    @CodeNO  varchar(50) = '',	-- 库存资产编码号
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_StorageRecord(
            VeriID , 
            ProjectNO , 
            EquipmentName , 
            Model , 
            StorageNumber , 
            UnitPrice , 
            StorageTime , 
            Applicant , 
            Approver , 
            PayAmount , 
            IntegrityCheckCode , 
            Remark , 
            CodeNO
        ) VALUES (
            @VeriID , 
            @ProjectNO , 
            @EquipmentName , 
            @Model , 
            @StorageNumber , 
            @UnitPrice , 
            @StorageTime , 
            @Applicant , 
            @Approver , 
            @PayAmount , 
            @IntegrityCheckCode , 
            @Remark , 
            @CodeNO
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_StorageRecord SET 
            VeriID=@VeriID , 
            ProjectNO=@ProjectNO , 
            EquipmentName=@EquipmentName , 
            Model=@Model , 
            StorageNumber=@StorageNumber , 
            UnitPrice=@UnitPrice , 
            StorageTime=@StorageTime , 
            Applicant=@Applicant , 
            Approver=@Approver , 
            PayAmount=@PayAmount , 
            IntegrityCheckCode=@IntegrityCheckCode , 
            Remark=@Remark , 
            CodeNO=@CodeNO
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_StorageRecord	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_SubjectDic_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_SubjectDic_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_SubjectDic_InsertUpdateDelete
Description:
            T_SubjectDic(预算科目) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:22
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_SubjectDic_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @SubjectNO  varchar(50) = '',	-- 科目编号
    @SubjectName  nvarchar(50) = '',	-- 科目名称
    @ClassNO  varchar(50) = '',	-- 所属类别
    @State  int = 0,	-- 状态(0为正常，9为删除)
    @CreateTime  datetime = getdate,	-- 创建时间
    @UpdateTime  datetime = getdate,	-- 更新时间
    @Sort  int = 0,	-- Sort
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_SubjectDic(
            SubjectNO , 
            SubjectName , 
            ClassNO , 
            State , 
            CreateTime , 
            UpdateTime , 
            Sort
        ) VALUES (
            @SubjectNO , 
            @SubjectName , 
            @ClassNO , 
            @State , 
            @CreateTime , 
            @UpdateTime , 
            @Sort
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_SubjectDic SET 
            SubjectNO=@SubjectNO , 
            SubjectName=@SubjectName , 
            ClassNO=@ClassNO , 
            State=@State , 
            CreateTime=@CreateTime , 
            UpdateTime=@UpdateTime , 
            Sort=@Sort
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_SubjectDic	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  if exists (select * from dbo.sysobjects where id = object_id(N'[T_VerificationRecord_InsertUpdateDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [T_VerificationRecord_InsertUpdateDelete]
GO
/********************************************************************************
Function:  T_VerificationRecord_InsertUpdateDelete
Description:
            T_VerificationRecord(核销申请单) 新增/修改/删除/显示
Author:
            DDBuildTools
            http://FrameWork.supesoft.com
Finish DateTime:
            2014-6-27 18:28:22
Return Value:
            -1:存储过程执行失败
            -2:存在相同的主键
            Insert:返回插入自动ID
            Update:返回更新记录数
            Delete:返回删除记录数
*********************************************************************************/
CREATE PROCEDURE T_VerificationRecord_InsertUpdateDelete
(

    @ID  int = 0,	-- ID
    @FundID  int = 0,	-- 所属经费申请单
    @ProjID  int = 0,	-- 所属项目
    @InvoiceFolder  varchar(50) = '',	-- 发票联
    @ContractFolder  varchar(50) = '',	-- 合同协议
    @Undertaker  int = 0,	-- 承办人
    @Checker  int = 0,	-- 申请人
    @Approver  bigint = 0,	-- 批准人
    @TransferState  int = 0,	-- 流转状态（0为申请状态，1为审核状态，2为批准状态）
    @State  int = 0,	-- 存档状态（0为流转状态，1为存档状态，9为删除）
    @CreateTime  datetime = getdate,	-- 创建时间
    @CheckTime  datetime = getdate,	-- 审核时间
    @ApprovalTime  datetime = getdate,	-- 批准时间
    @PayAmount  float = 0,	-- 实际支出
    @IntegrityCheckCode  varchar(50) = '',	-- 信息完整性校验码
    @DataTable_Action_  varchar(10) = ''		-- 操作方法 Insert:增加 Update:修改 Delete:删除
)
AS
    DECLARE @ReturnValue varchar(18) -- 返回操作结果
    SET @ReturnValue = -1
    -- 新增
    IF (@DataTable_Action_='Insert')
    BEGIN
    
        INSERT INTO T_VerificationRecord(
            FundID , 
            ProjID , 
            InvoiceFolder , 
            ContractFolder , 
            Undertaker , 
            Checker , 
            Approver , 
            TransferState , 
            State , 
            CreateTime , 
            CheckTime , 
            ApprovalTime , 
            PayAmount , 
            IntegrityCheckCode
        ) VALUES (
            @FundID , 
            @ProjID , 
            @InvoiceFolder , 
            @ContractFolder , 
            @Undertaker , 
            @Checker , 
            @Approver , 
            @TransferState , 
            @State , 
            @CreateTime , 
            @CheckTime , 
            @ApprovalTime , 
            @PayAmount , 
            @IntegrityCheckCode
        )
        SELECT @ReturnValue = SCOPE_IDENTITY()
    END

    -- 更新
    IF (@DataTable_Action_='Update')
    BEGIN
    
        UPDATE T_VerificationRecord SET 
            FundID=@FundID , 
            ProjID=@ProjID , 
            InvoiceFolder=@InvoiceFolder , 
            ContractFolder=@ContractFolder , 
            Undertaker=@Undertaker , 
            Checker=@Checker , 
            Approver=@Approver , 
            TransferState=@TransferState , 
            State=@State , 
            CreateTime=@CreateTime , 
            CheckTime=@CheckTime , 
            ApprovalTime=@ApprovalTime , 
            PayAmount=@PayAmount , 
            IntegrityCheckCode=@IntegrityCheckCode
        WHERE (ID=@ID)

        SELECT @ReturnValue = @@ROWCOUNT
    END
    -- 删除
    IF (@DataTable_Action_='Delete')
    BEGIN
        DELETE T_VerificationRecord	WHERE (ID=@ID)
        SET @ReturnValue = @@ROWCOUNT
    END

    SELECT @ReturnValue
GO
  