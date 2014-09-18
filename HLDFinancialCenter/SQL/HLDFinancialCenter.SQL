IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_BudgetDetail') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_BudgetDetail
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_ClassDic') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_ClassDic
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_FundsRecord') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_FundsRecord
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_OutboundRecord') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_OutboundRecord
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_ProjectBudget') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_ProjectBudget
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_ProjectDic') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_ProjectDic
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_Stock') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_Stock
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_StockLog') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_StockLog
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_StorageRecord') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_StorageRecord
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_SubjectDic') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_SubjectDic
;

IF EXISTS (SELECT * FROM dbo.SYSOBJECTS WHERE id = object_id('T_VerificationRecord') AND  OBJECTPROPERTY(id, 'IsUserTable') = 1)
DROP TABLE T_VerificationRecord
;




CREATE TABLE T_BudgetDetail ( 
	ID int identity(1,1)  NOT NULL,
	ProjID int,    --  所属项目 
	EquipmentName nvarchar(50),    --  器材名称 
	BudgetRevenue float,    --  预算收入 
	Measurement nvarchar(50),    --  计量单位 
	BudgetPrice float,    --  预算单价 
	BudgetNumber int,    --  预算数量 
	BudgetExpenditure float,    --  预算支出 
	BalanceAmount float,    --  经费余额 
	Supplier nvarchar(50),    --  供货单位 
	Remark nvarchar(50),    --  备注 
	Sort int    --  递增排序 
)
;

CREATE TABLE T_ClassDic ( 
	ID int identity(1,1)  NOT NULL,
	ClassNO varchar(50) NOT NULL,    --  类别名称 
	ClassName nvarchar(50),    --  类别名称 
	ParentClassNO varchar(50),    --  父类 
	State int,    --  状态(0为正常，9为删除) 
	CreateTime datetime,    --  创建日期 
	UpdateTime datetime,    --  更新日期 
	Sort int
)
;

CREATE TABLE T_FundsRecord ( 
	ID int identity(1,1)  NOT NULL,    --  自增ID 
	ProjID int,    --  预算项目 
	BalanceAmount float,    --  经费余额 
	UseRemark nvarchar(50),    --  申请用途 
	AdvanceAmount float,    --  支出金额 
	Applicant int,    --  申请人 
	Checker int,    --  审核人 
	Approver int,    --  批准人 
	TransferState int,    --  流转状态（0为申请状态，1为审核状态，2为批准状态） 
	State int,    --  状态（0为流转状态，1为存档状态，9为删除） 
	AppricationTime datetime,    --  申请时间 
	CheckTime datetime,    --  审核时间 
	ApprovalTime datetime,    --  批准时间 
	IntegrityCheckCode varchar(50)    --  信息完整性校验码 
)
;

CREATE TABLE T_OutboundRecord ( 
	ID int identity(1,1)  NOT NULL,
	ProjectNO varchar(50),    --  项目名称 
	EquipmentName nvarchar(50),    --  器材名称 
	Model varchar(50),    --  型号 
	OutboundNumber int,    --  数量 
	BalanceNumber int,    --  结余 
	OutboundTime datetime,    --  领取时间 
	Applicant int,    --  申请人 
	Approver int,    --  批准人 
	IntegrityCheckCode varchar(50),    --  信息完整性校验码 
	Remark nvarchar(50),
	CodeNO varchar(50)    --  库存资产编码号 
)
;

CREATE TABLE T_ProjectBudget ( 
	ID int identity(1,1)  NOT NULL,    --  项目编号 
	ProjectNO varchar(50),    --  项目编号 
	SubjectNO varchar(50),    --  所属科目 
	ClassNO varchar(50),    --  所属类别 
	AnnualNO varchar(50),    --  所属年度 
	BudgetRevenue float,    --  预算收入 
	BudgetExpenditure float,    --  预算支出 
	BalanceAmount float,    --  经费余额 
	Leader int,    --  项目组长 
	Undertaker int,    --  指定承办人 
	State int,    --  状态(0为正常，9为删除) 
	CreateTime datetime,    --  创建时间 
	UpdateTime datetime,    --  更新时间 
	Sort int,    --  递增排序 
	DepartmentID int    --  所在部门 
)
;

CREATE TABLE T_ProjectDic ( 
	ID int identity(1,1)  NOT NULL,
	ProjectNO varchar(50) NOT NULL,    --  项目编号 
	ProjectName nvarchar(50),
	SubjectNO varchar(50),    --  所属科目 
	ClassNO varchar(50),    --  所属类别 
	State int,    --  状态(0为正常，9为删除) 
	CreateTime datetime,
	UpdateTime datetime
)
;

CREATE TABLE T_Stock ( 
	ID int identity(1,1)  NOT NULL,
	EquipmentName nvarchar(50),    --  器材名称 
	Model varchar(50),    --  型号 
	StockNumber int,    --  库存量 
	CodeNO varchar(50)    --  编码号 
)
;

CREATE TABLE T_StockLog ( 
	ID int identity(1,1)  NOT NULL,    --  自增ID 
	CodeNO varchar(50),    --  库存资产编码号 
	DealType int,    --  处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库） 
	Number int,    --  数量 
	Handler int,    --  操作者 
	StorID int,    --  入库单ID 
	OutbID int,    --  出库单ID 
	LogTime datetime    --  记录时间 
)
;

CREATE TABLE T_StorageRecord ( 
	ID int identity(1,1)  NOT NULL,
	VeriID int,    --  所属核销 
	ProjectNO varchar(50),    --  所属项目 
	EquipmentName nvarchar(50),    --  器材名称 
	Model varchar(50),    --  型号 
	StorageNumber int,    --  数量 
	UnitPrice float,    --  单价 
	StorageTime datetime,    --  入库时间 
	Applicant int,    --  申请人 
	Approver int,    --  批准人 
	PayAmount float,    --  实际支出 
	IntegrityCheckCode varchar(50),    --  信息完整性校验码 
	Remark nvarchar(50),
	CodeNO varchar(50)    --  库存资产编码号 
)
;

CREATE TABLE T_SubjectDic ( 
	ID int identity(1,1)  NOT NULL,
	SubjectNO varchar(50) NOT NULL,    --  科目编号 
	SubjectName nvarchar(50),    --  科目名称 
	ClassNO varchar(50),    --  所属类别 
	State int,    --  状态(0为正常，9为删除) 
	CreateTime datetime,    --  创建时间 
	UpdateTime datetime,    --  更新时间 
	Sort int
)
;

CREATE TABLE T_VerificationRecord ( 
	ID int identity(1,1)  NOT NULL,
	FundID int,    --  所属经费申请单 
	ProjID int,    --  所属项目 
	InvoiceFolder varchar(50),    --  发票联 
	ContractFolder varchar(50),    --  合同协议 
	Undertaker int,    --  承办人 
	Checker int,    --  申请人 
	Approver bigint,    --  批准人 
	TransferState int,    --  流转状态（0为申请状态，1为审核状态，2为批准状态） 
	State int,    --  存档状态（0为流转状态，1为存档状态，9为删除） 
	CreateTime datetime,    --  创建时间 
	CheckTime datetime,    --  审核时间 
	ApprovalTime datetime,    --  批准时间 
	PayAmount float,    --  实际支出 
	IntegrityCheckCode varchar(50)    --  信息完整性校验码 
)
;


ALTER TABLE T_BudgetDetail ADD CONSTRAINT PK_BudgetDetail 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_ClassDic ADD CONSTRAINT PK_ClassDic 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_FundsRecord ADD CONSTRAINT PK_FundsRecord 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_OutboundRecord ADD CONSTRAINT PK_OutboundRecord 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_ProjectBudget ADD CONSTRAINT PK_ProjectBudget 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_ProjectDic ADD CONSTRAINT PK_ProjectDic 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_Stock ADD CONSTRAINT PK_Stock 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_StockLog ADD CONSTRAINT PK_StockLog 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_StorageRecord ADD CONSTRAINT PK_StorageRecord 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_SubjectDic ADD CONSTRAINT PK_SubjectDic 
	PRIMARY KEY CLUSTERED (ID)
;

ALTER TABLE T_VerificationRecord ADD CONSTRAINT PK_VerificationRecord 
	PRIMARY KEY CLUSTERED (ID)
;









EXEC sp_addextendedproperty 'MS_Description', '预算明细', 'User', dbo, 'table', T_BudgetDetail
;

EXEC sp_addextendedproperty 'MS_Description', '所属项目', 'User', dbo, 'table', T_BudgetDetail, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '器材名称', 'User', dbo, 'table', T_BudgetDetail, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '预算收入', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetRevenue
;

EXEC sp_addextendedproperty 'MS_Description', '计量单位', 'User', dbo, 'table', T_BudgetDetail, 'column', Measurement
;

EXEC sp_addextendedproperty 'MS_Description', '预算单价', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetPrice
;

EXEC sp_addextendedproperty 'MS_Description', '预算数量', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetNumber
;

EXEC sp_addextendedproperty 'MS_Description', '预算支出', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetExpenditure
;

EXEC sp_addextendedproperty 'MS_Description', '经费余额', 'User', dbo, 'table', T_BudgetDetail, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '供货单位', 'User', dbo, 'table', T_BudgetDetail, 'column', Supplier
;

EXEC sp_addextendedproperty 'MS_Description', '备注', 'User', dbo, 'table', T_BudgetDetail, 'column', Remark
;

EXEC sp_addextendedproperty 'MS_Description', '递增排序', 'User', dbo, 'table', T_BudgetDetail, 'column', Sort
;


EXEC sp_addextendedproperty 'MS_Description', '类别名称', 'User', dbo, 'table', T_ClassDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '类别名称', 'User', dbo, 'table', T_ClassDic, 'column', ClassName
;

EXEC sp_addextendedproperty 'MS_Description', '父类', 'User', dbo, 'table', T_ClassDic, 'column', ParentClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '状态(0为正常，9为删除)', 'User', dbo, 'table', T_ClassDic, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '创建日期', 'User', dbo, 'table', T_ClassDic, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '更新日期', 'User', dbo, 'table', T_ClassDic, 'column', UpdateTime
;


EXEC sp_addextendedproperty 'MS_Description', '经费使用申请单', 'User', dbo, 'table', T_FundsRecord
;
EXEC sp_addextendedproperty 'MS_Description', '自增ID', 'User', dbo, 'table', T_FundsRecord, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', '预算项目', 'User', dbo, 'table', T_FundsRecord, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '经费余额', 'User', dbo, 'table', T_FundsRecord, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '申请用途', 'User', dbo, 'table', T_FundsRecord, 'column', UseRemark
;

EXEC sp_addextendedproperty 'MS_Description', '支出金额', 'User', dbo, 'table', T_FundsRecord, 'column', AdvanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '申请人', 'User', dbo, 'table', T_FundsRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '审核人', 'User', dbo, 'table', T_FundsRecord, 'column', Checker
;

EXEC sp_addextendedproperty 'MS_Description', '批准人', 'User', dbo, 'table', T_FundsRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '流转状态（0为申请状态，1为审核状态，2为批准状态）', 'User', dbo, 'table', T_FundsRecord, 'column', TransferState
;

EXEC sp_addextendedproperty 'MS_Description', '状态（0为流转状态，1为存档状态，9为删除）', 'User', dbo, 'table', T_FundsRecord, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '申请时间', 'User', dbo, 'table', T_FundsRecord, 'column', AppricationTime
;

EXEC sp_addextendedproperty 'MS_Description', '审核时间', 'User', dbo, 'table', T_FundsRecord, 'column', CheckTime
;

EXEC sp_addextendedproperty 'MS_Description', '批准时间', 'User', dbo, 'table', T_FundsRecord, 'column', ApprovalTime
;

EXEC sp_addextendedproperty 'MS_Description', '信息完整性校验码', 'User', dbo, 'table', T_FundsRecord, 'column', IntegrityCheckCode
;

EXEC sp_addextendedproperty 'MS_Description', '出库表单', 'User', dbo, 'table', T_OutboundRecord
;

EXEC sp_addextendedproperty 'MS_Description', '项目名称', 'User', dbo, 'table', T_OutboundRecord, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '器材名称', 'User', dbo, 'table', T_OutboundRecord, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '型号', 'User', dbo, 'table', T_OutboundRecord, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '数量', 'User', dbo, 'table', T_OutboundRecord, 'column', OutboundNumber
;

EXEC sp_addextendedproperty 'MS_Description', '结余', 'User', dbo, 'table', T_OutboundRecord, 'column', BalanceNumber
;

EXEC sp_addextendedproperty 'MS_Description', '领取时间', 'User', dbo, 'table', T_OutboundRecord, 'column', OutboundTime
;

EXEC sp_addextendedproperty 'MS_Description', '申请人', 'User', dbo, 'table', T_OutboundRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '批准人', 'User', dbo, 'table', T_OutboundRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '信息完整性校验码', 'User', dbo, 'table', T_OutboundRecord, 'column', IntegrityCheckCode
;


EXEC sp_addextendedproperty 'MS_Description', '库存资产编码号', 'User', dbo, 'table', T_OutboundRecord, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '项目预算', 'User', dbo, 'table', T_ProjectBudget
;
EXEC sp_addextendedproperty 'MS_Description', '项目编号', 'User', dbo, 'table', T_ProjectBudget, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', '项目编号', 'User', dbo, 'table', T_ProjectBudget, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '所属科目', 'User', dbo, 'table', T_ProjectBudget, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '所属类别', 'User', dbo, 'table', T_ProjectBudget, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '所属年度', 'User', dbo, 'table', T_ProjectBudget, 'column', AnnualNO
;

EXEC sp_addextendedproperty 'MS_Description', '预算收入', 'User', dbo, 'table', T_ProjectBudget, 'column', BudgetRevenue
;

EXEC sp_addextendedproperty 'MS_Description', '预算支出', 'User', dbo, 'table', T_ProjectBudget, 'column', BudgetExpenditure
;

EXEC sp_addextendedproperty 'MS_Description', '经费余额', 'User', dbo, 'table', T_ProjectBudget, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '项目组长', 'User', dbo, 'table', T_ProjectBudget, 'column', Leader
;

EXEC sp_addextendedproperty 'MS_Description', '指定承办人', 'User', dbo, 'table', T_ProjectBudget, 'column', Undertaker
;

EXEC sp_addextendedproperty 'MS_Description', '状态(0为正常，9为删除)', 'User', dbo, 'table', T_ProjectBudget, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '创建时间', 'User', dbo, 'table', T_ProjectBudget, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '更新时间', 'User', dbo, 'table', T_ProjectBudget, 'column', UpdateTime
;

EXEC sp_addextendedproperty 'MS_Description', '递增排序', 'User', dbo, 'table', T_ProjectBudget, 'column', Sort
;

EXEC sp_addextendedproperty 'MS_Description', '所在部门', 'User', dbo, 'table', T_ProjectBudget, 'column', DepartmentID
;


EXEC sp_addextendedproperty 'MS_Description', '项目编号', 'User', dbo, 'table', T_ProjectDic, 'column', ProjectNO
;


EXEC sp_addextendedproperty 'MS_Description', '所属科目', 'User', dbo, 'table', T_ProjectDic, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '所属类别', 'User', dbo, 'table', T_ProjectDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '状态(0为正常，9为删除)', 'User', dbo, 'table', T_ProjectDic, 'column', State
;



EXEC sp_addextendedproperty 'MS_Description', '库存', 'User', dbo, 'table', T_Stock
;

EXEC sp_addextendedproperty 'MS_Description', '器材名称', 'User', dbo, 'table', T_Stock, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '型号', 'User', dbo, 'table', T_Stock, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '库存量', 'User', dbo, 'table', T_Stock, 'column', StockNumber
;

EXEC sp_addextendedproperty 'MS_Description', '编码号', 'User', dbo, 'table', T_Stock, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '出入库日志', 'User', dbo, 'table', T_StockLog
;
EXEC sp_addextendedproperty 'MS_Description', '自增ID', 'User', dbo, 'table', T_StockLog, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', '库存资产编码号', 'User', dbo, 'table', T_StockLog, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '处理类型（0为平衡入库，1为核销入库，2为受赠入库，10为平衡出库，11为申领出库，12为折旧出库）', 'User', dbo, 'table', T_StockLog, 'column', DealType
;

EXEC sp_addextendedproperty 'MS_Description', '数量', 'User', dbo, 'table', T_StockLog, 'column', Number
;

EXEC sp_addextendedproperty 'MS_Description', '操作者', 'User', dbo, 'table', T_StockLog, 'column', Handler
;

EXEC sp_addextendedproperty 'MS_Description', '入库单ID', 'User', dbo, 'table', T_StockLog, 'column', StorID
;

EXEC sp_addextendedproperty 'MS_Description', '出库单ID', 'User', dbo, 'table', T_StockLog, 'column', OutbID
;

EXEC sp_addextendedproperty 'MS_Description', '记录时间', 'User', dbo, 'table', T_StockLog, 'column', LogTime
;

EXEC sp_addextendedproperty 'MS_Description', '入库表单', 'User', dbo, 'table', T_StorageRecord
;

EXEC sp_addextendedproperty 'MS_Description', '所属核销', 'User', dbo, 'table', T_StorageRecord, 'column', VeriID
;

EXEC sp_addextendedproperty 'MS_Description', '所属项目', 'User', dbo, 'table', T_StorageRecord, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '器材名称', 'User', dbo, 'table', T_StorageRecord, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '型号', 'User', dbo, 'table', T_StorageRecord, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '数量', 'User', dbo, 'table', T_StorageRecord, 'column', StorageNumber
;

EXEC sp_addextendedproperty 'MS_Description', '单价', 'User', dbo, 'table', T_StorageRecord, 'column', UnitPrice
;

EXEC sp_addextendedproperty 'MS_Description', '入库时间', 'User', dbo, 'table', T_StorageRecord, 'column', StorageTime
;

EXEC sp_addextendedproperty 'MS_Description', '申请人', 'User', dbo, 'table', T_StorageRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '批准人', 'User', dbo, 'table', T_StorageRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '实际支出', 'User', dbo, 'table', T_StorageRecord, 'column', PayAmount
;

EXEC sp_addextendedproperty 'MS_Description', '信息完整性校验码', 'User', dbo, 'table', T_StorageRecord, 'column', IntegrityCheckCode
;


EXEC sp_addextendedproperty 'MS_Description', '库存资产编码号', 'User', dbo, 'table', T_StorageRecord, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '预算科目', 'User', dbo, 'table', T_SubjectDic
;

EXEC sp_addextendedproperty 'MS_Description', '科目编号', 'User', dbo, 'table', T_SubjectDic, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '科目名称', 'User', dbo, 'table', T_SubjectDic, 'column', SubjectName
;

EXEC sp_addextendedproperty 'MS_Description', '所属类别', 'User', dbo, 'table', T_SubjectDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '状态(0为正常，9为删除)', 'User', dbo, 'table', T_SubjectDic, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '创建时间', 'User', dbo, 'table', T_SubjectDic, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '更新时间', 'User', dbo, 'table', T_SubjectDic, 'column', UpdateTime
;


EXEC sp_addextendedproperty 'MS_Description', '核销申请单', 'User', dbo, 'table', T_VerificationRecord
;

EXEC sp_addextendedproperty 'MS_Description', '所属经费申请单', 'User', dbo, 'table', T_VerificationRecord, 'column', FundID
;

EXEC sp_addextendedproperty 'MS_Description', '所属项目', 'User', dbo, 'table', T_VerificationRecord, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '发票联', 'User', dbo, 'table', T_VerificationRecord, 'column', InvoiceFolder
;

EXEC sp_addextendedproperty 'MS_Description', '合同协议', 'User', dbo, 'table', T_VerificationRecord, 'column', ContractFolder
;

EXEC sp_addextendedproperty 'MS_Description', '承办人', 'User', dbo, 'table', T_VerificationRecord, 'column', Undertaker
;

EXEC sp_addextendedproperty 'MS_Description', '申请人', 'User', dbo, 'table', T_VerificationRecord, 'column', Checker
;

EXEC sp_addextendedproperty 'MS_Description', '批准人', 'User', dbo, 'table', T_VerificationRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '流转状态（0为申请状态，1为审核状态，2为批准状态）', 'User', dbo, 'table', T_VerificationRecord, 'column', TransferState
;

EXEC sp_addextendedproperty 'MS_Description', '存档状态（0为流转状态，1为存档状态，9为删除）', 'User', dbo, 'table', T_VerificationRecord, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '创建时间', 'User', dbo, 'table', T_VerificationRecord, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '审核时间', 'User', dbo, 'table', T_VerificationRecord, 'column', CheckTime
;

EXEC sp_addextendedproperty 'MS_Description', '批准时间', 'User', dbo, 'table', T_VerificationRecord, 'column', ApprovalTime
;

EXEC sp_addextendedproperty 'MS_Description', '实际支出', 'User', dbo, 'table', T_VerificationRecord, 'column', PayAmount
;

EXEC sp_addextendedproperty 'MS_Description', '信息完整性校验码', 'User', dbo, 'table', T_VerificationRecord, 'column', IntegrityCheckCode
;
