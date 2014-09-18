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
	ProjID int,    --  ������Ŀ 
	EquipmentName nvarchar(50),    --  �������� 
	BudgetRevenue float,    --  Ԥ������ 
	Measurement nvarchar(50),    --  ������λ 
	BudgetPrice float,    --  Ԥ�㵥�� 
	BudgetNumber int,    --  Ԥ������ 
	BudgetExpenditure float,    --  Ԥ��֧�� 
	BalanceAmount float,    --  ������� 
	Supplier nvarchar(50),    --  ������λ 
	Remark nvarchar(50),    --  ��ע 
	Sort int    --  �������� 
)
;

CREATE TABLE T_ClassDic ( 
	ID int identity(1,1)  NOT NULL,
	ClassNO varchar(50) NOT NULL,    --  ������� 
	ClassName nvarchar(50),    --  ������� 
	ParentClassNO varchar(50),    --  ���� 
	State int,    --  ״̬(0Ϊ������9Ϊɾ��) 
	CreateTime datetime,    --  �������� 
	UpdateTime datetime,    --  �������� 
	Sort int
)
;

CREATE TABLE T_FundsRecord ( 
	ID int identity(1,1)  NOT NULL,    --  ����ID 
	ProjID int,    --  Ԥ����Ŀ 
	BalanceAmount float,    --  ������� 
	UseRemark nvarchar(50),    --  ������; 
	AdvanceAmount float,    --  ֧����� 
	Applicant int,    --  ������ 
	Checker int,    --  ����� 
	Approver int,    --  ��׼�� 
	TransferState int,    --  ��ת״̬��0Ϊ����״̬��1Ϊ���״̬��2Ϊ��׼״̬�� 
	State int,    --  ״̬��0Ϊ��ת״̬��1Ϊ�浵״̬��9Ϊɾ���� 
	AppricationTime datetime,    --  ����ʱ�� 
	CheckTime datetime,    --  ���ʱ�� 
	ApprovalTime datetime,    --  ��׼ʱ�� 
	IntegrityCheckCode varchar(50)    --  ��Ϣ������У���� 
)
;

CREATE TABLE T_OutboundRecord ( 
	ID int identity(1,1)  NOT NULL,
	ProjectNO varchar(50),    --  ��Ŀ���� 
	EquipmentName nvarchar(50),    --  �������� 
	Model varchar(50),    --  �ͺ� 
	OutboundNumber int,    --  ���� 
	BalanceNumber int,    --  ���� 
	OutboundTime datetime,    --  ��ȡʱ�� 
	Applicant int,    --  ������ 
	Approver int,    --  ��׼�� 
	IntegrityCheckCode varchar(50),    --  ��Ϣ������У���� 
	Remark nvarchar(50),
	CodeNO varchar(50)    --  ����ʲ������ 
)
;

CREATE TABLE T_ProjectBudget ( 
	ID int identity(1,1)  NOT NULL,    --  ��Ŀ��� 
	ProjectNO varchar(50),    --  ��Ŀ��� 
	SubjectNO varchar(50),    --  ������Ŀ 
	ClassNO varchar(50),    --  ������� 
	AnnualNO varchar(50),    --  ������� 
	BudgetRevenue float,    --  Ԥ������ 
	BudgetExpenditure float,    --  Ԥ��֧�� 
	BalanceAmount float,    --  ������� 
	Leader int,    --  ��Ŀ�鳤 
	Undertaker int,    --  ָ���а��� 
	State int,    --  ״̬(0Ϊ������9Ϊɾ��) 
	CreateTime datetime,    --  ����ʱ�� 
	UpdateTime datetime,    --  ����ʱ�� 
	Sort int,    --  �������� 
	DepartmentID int    --  ���ڲ��� 
)
;

CREATE TABLE T_ProjectDic ( 
	ID int identity(1,1)  NOT NULL,
	ProjectNO varchar(50) NOT NULL,    --  ��Ŀ��� 
	ProjectName nvarchar(50),
	SubjectNO varchar(50),    --  ������Ŀ 
	ClassNO varchar(50),    --  ������� 
	State int,    --  ״̬(0Ϊ������9Ϊɾ��) 
	CreateTime datetime,
	UpdateTime datetime
)
;

CREATE TABLE T_Stock ( 
	ID int identity(1,1)  NOT NULL,
	EquipmentName nvarchar(50),    --  �������� 
	Model varchar(50),    --  �ͺ� 
	StockNumber int,    --  ����� 
	CodeNO varchar(50)    --  ����� 
)
;

CREATE TABLE T_StockLog ( 
	ID int identity(1,1)  NOT NULL,    --  ����ID 
	CodeNO varchar(50),    --  ����ʲ������ 
	DealType int,    --  �������ͣ�0Ϊƽ����⣬1Ϊ������⣬2Ϊ������⣬10Ϊƽ����⣬11Ϊ������⣬12Ϊ�۾ɳ��⣩ 
	Number int,    --  ���� 
	Handler int,    --  ������ 
	StorID int,    --  ��ⵥID 
	OutbID int,    --  ���ⵥID 
	LogTime datetime    --  ��¼ʱ�� 
)
;

CREATE TABLE T_StorageRecord ( 
	ID int identity(1,1)  NOT NULL,
	VeriID int,    --  �������� 
	ProjectNO varchar(50),    --  ������Ŀ 
	EquipmentName nvarchar(50),    --  �������� 
	Model varchar(50),    --  �ͺ� 
	StorageNumber int,    --  ���� 
	UnitPrice float,    --  ���� 
	StorageTime datetime,    --  ���ʱ�� 
	Applicant int,    --  ������ 
	Approver int,    --  ��׼�� 
	PayAmount float,    --  ʵ��֧�� 
	IntegrityCheckCode varchar(50),    --  ��Ϣ������У���� 
	Remark nvarchar(50),
	CodeNO varchar(50)    --  ����ʲ������ 
)
;

CREATE TABLE T_SubjectDic ( 
	ID int identity(1,1)  NOT NULL,
	SubjectNO varchar(50) NOT NULL,    --  ��Ŀ��� 
	SubjectName nvarchar(50),    --  ��Ŀ���� 
	ClassNO varchar(50),    --  ������� 
	State int,    --  ״̬(0Ϊ������9Ϊɾ��) 
	CreateTime datetime,    --  ����ʱ�� 
	UpdateTime datetime,    --  ����ʱ�� 
	Sort int
)
;

CREATE TABLE T_VerificationRecord ( 
	ID int identity(1,1)  NOT NULL,
	FundID int,    --  �����������뵥 
	ProjID int,    --  ������Ŀ 
	InvoiceFolder varchar(50),    --  ��Ʊ�� 
	ContractFolder varchar(50),    --  ��ͬЭ�� 
	Undertaker int,    --  �а��� 
	Checker int,    --  ������ 
	Approver bigint,    --  ��׼�� 
	TransferState int,    --  ��ת״̬��0Ϊ����״̬��1Ϊ���״̬��2Ϊ��׼״̬�� 
	State int,    --  �浵״̬��0Ϊ��ת״̬��1Ϊ�浵״̬��9Ϊɾ���� 
	CreateTime datetime,    --  ����ʱ�� 
	CheckTime datetime,    --  ���ʱ�� 
	ApprovalTime datetime,    --  ��׼ʱ�� 
	PayAmount float,    --  ʵ��֧�� 
	IntegrityCheckCode varchar(50)    --  ��Ϣ������У���� 
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









EXEC sp_addextendedproperty 'MS_Description', 'Ԥ����ϸ', 'User', dbo, 'table', T_BudgetDetail
;

EXEC sp_addextendedproperty 'MS_Description', '������Ŀ', 'User', dbo, 'table', T_BudgetDetail, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_BudgetDetail, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ������', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetRevenue
;

EXEC sp_addextendedproperty 'MS_Description', '������λ', 'User', dbo, 'table', T_BudgetDetail, 'column', Measurement
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ�㵥��', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetPrice
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ������', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetNumber
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ��֧��', 'User', dbo, 'table', T_BudgetDetail, 'column', BudgetExpenditure
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_BudgetDetail, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '������λ', 'User', dbo, 'table', T_BudgetDetail, 'column', Supplier
;

EXEC sp_addextendedproperty 'MS_Description', '��ע', 'User', dbo, 'table', T_BudgetDetail, 'column', Remark
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_BudgetDetail, 'column', Sort
;


EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ClassDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ClassDic, 'column', ClassName
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_ClassDic, 'column', ParentClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '״̬(0Ϊ������9Ϊɾ��)', 'User', dbo, 'table', T_ClassDic, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_ClassDic, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_ClassDic, 'column', UpdateTime
;


EXEC sp_addextendedproperty 'MS_Description', '����ʹ�����뵥', 'User', dbo, 'table', T_FundsRecord
;
EXEC sp_addextendedproperty 'MS_Description', '����ID', 'User', dbo, 'table', T_FundsRecord, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ����Ŀ', 'User', dbo, 'table', T_FundsRecord, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_FundsRecord, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '������;', 'User', dbo, 'table', T_FundsRecord, 'column', UseRemark
;

EXEC sp_addextendedproperty 'MS_Description', '֧�����', 'User', dbo, 'table', T_FundsRecord, 'column', AdvanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_FundsRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '�����', 'User', dbo, 'table', T_FundsRecord, 'column', Checker
;

EXEC sp_addextendedproperty 'MS_Description', '��׼��', 'User', dbo, 'table', T_FundsRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '��ת״̬��0Ϊ����״̬��1Ϊ���״̬��2Ϊ��׼״̬��', 'User', dbo, 'table', T_FundsRecord, 'column', TransferState
;

EXEC sp_addextendedproperty 'MS_Description', '״̬��0Ϊ��ת״̬��1Ϊ�浵״̬��9Ϊɾ����', 'User', dbo, 'table', T_FundsRecord, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_FundsRecord, 'column', AppricationTime
;

EXEC sp_addextendedproperty 'MS_Description', '���ʱ��', 'User', dbo, 'table', T_FundsRecord, 'column', CheckTime
;

EXEC sp_addextendedproperty 'MS_Description', '��׼ʱ��', 'User', dbo, 'table', T_FundsRecord, 'column', ApprovalTime
;

EXEC sp_addextendedproperty 'MS_Description', '��Ϣ������У����', 'User', dbo, 'table', T_FundsRecord, 'column', IntegrityCheckCode
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_OutboundRecord
;

EXEC sp_addextendedproperty 'MS_Description', '��Ŀ����', 'User', dbo, 'table', T_OutboundRecord, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_OutboundRecord, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '�ͺ�', 'User', dbo, 'table', T_OutboundRecord, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_OutboundRecord, 'column', OutboundNumber
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_OutboundRecord, 'column', BalanceNumber
;

EXEC sp_addextendedproperty 'MS_Description', '��ȡʱ��', 'User', dbo, 'table', T_OutboundRecord, 'column', OutboundTime
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_OutboundRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '��׼��', 'User', dbo, 'table', T_OutboundRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '��Ϣ������У����', 'User', dbo, 'table', T_OutboundRecord, 'column', IntegrityCheckCode
;


EXEC sp_addextendedproperty 'MS_Description', '����ʲ������', 'User', dbo, 'table', T_OutboundRecord, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '��ĿԤ��', 'User', dbo, 'table', T_ProjectBudget
;
EXEC sp_addextendedproperty 'MS_Description', '��Ŀ���', 'User', dbo, 'table', T_ProjectBudget, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', '��Ŀ���', 'User', dbo, 'table', T_ProjectBudget, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '������Ŀ', 'User', dbo, 'table', T_ProjectBudget, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ProjectBudget, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ProjectBudget, 'column', AnnualNO
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ������', 'User', dbo, 'table', T_ProjectBudget, 'column', BudgetRevenue
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ��֧��', 'User', dbo, 'table', T_ProjectBudget, 'column', BudgetExpenditure
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ProjectBudget, 'column', BalanceAmount
;

EXEC sp_addextendedproperty 'MS_Description', '��Ŀ�鳤', 'User', dbo, 'table', T_ProjectBudget, 'column', Leader
;

EXEC sp_addextendedproperty 'MS_Description', 'ָ���а���', 'User', dbo, 'table', T_ProjectBudget, 'column', Undertaker
;

EXEC sp_addextendedproperty 'MS_Description', '״̬(0Ϊ������9Ϊɾ��)', 'User', dbo, 'table', T_ProjectBudget, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_ProjectBudget, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_ProjectBudget, 'column', UpdateTime
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_ProjectBudget, 'column', Sort
;

EXEC sp_addextendedproperty 'MS_Description', '���ڲ���', 'User', dbo, 'table', T_ProjectBudget, 'column', DepartmentID
;


EXEC sp_addextendedproperty 'MS_Description', '��Ŀ���', 'User', dbo, 'table', T_ProjectDic, 'column', ProjectNO
;


EXEC sp_addextendedproperty 'MS_Description', '������Ŀ', 'User', dbo, 'table', T_ProjectDic, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_ProjectDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '״̬(0Ϊ������9Ϊɾ��)', 'User', dbo, 'table', T_ProjectDic, 'column', State
;



EXEC sp_addextendedproperty 'MS_Description', '���', 'User', dbo, 'table', T_Stock
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_Stock, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '�ͺ�', 'User', dbo, 'table', T_Stock, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '�����', 'User', dbo, 'table', T_Stock, 'column', StockNumber
;

EXEC sp_addextendedproperty 'MS_Description', '�����', 'User', dbo, 'table', T_Stock, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������־', 'User', dbo, 'table', T_StockLog
;
EXEC sp_addextendedproperty 'MS_Description', '����ID', 'User', dbo, 'table', T_StockLog, 'column', ID
;

EXEC sp_addextendedproperty 'MS_Description', '����ʲ������', 'User', dbo, 'table', T_StockLog, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', '�������ͣ�0Ϊƽ����⣬1Ϊ������⣬2Ϊ������⣬10Ϊƽ����⣬11Ϊ������⣬12Ϊ�۾ɳ��⣩', 'User', dbo, 'table', T_StockLog, 'column', DealType
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_StockLog, 'column', Number
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_StockLog, 'column', Handler
;

EXEC sp_addextendedproperty 'MS_Description', '��ⵥID', 'User', dbo, 'table', T_StockLog, 'column', StorID
;

EXEC sp_addextendedproperty 'MS_Description', '���ⵥID', 'User', dbo, 'table', T_StockLog, 'column', OutbID
;

EXEC sp_addextendedproperty 'MS_Description', '��¼ʱ��', 'User', dbo, 'table', T_StockLog, 'column', LogTime
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_StorageRecord
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_StorageRecord, 'column', VeriID
;

EXEC sp_addextendedproperty 'MS_Description', '������Ŀ', 'User', dbo, 'table', T_StorageRecord, 'column', ProjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '��������', 'User', dbo, 'table', T_StorageRecord, 'column', EquipmentName
;

EXEC sp_addextendedproperty 'MS_Description', '�ͺ�', 'User', dbo, 'table', T_StorageRecord, 'column', Model
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_StorageRecord, 'column', StorageNumber
;

EXEC sp_addextendedproperty 'MS_Description', '����', 'User', dbo, 'table', T_StorageRecord, 'column', UnitPrice
;

EXEC sp_addextendedproperty 'MS_Description', '���ʱ��', 'User', dbo, 'table', T_StorageRecord, 'column', StorageTime
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_StorageRecord, 'column', Applicant
;

EXEC sp_addextendedproperty 'MS_Description', '��׼��', 'User', dbo, 'table', T_StorageRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', 'ʵ��֧��', 'User', dbo, 'table', T_StorageRecord, 'column', PayAmount
;

EXEC sp_addextendedproperty 'MS_Description', '��Ϣ������У����', 'User', dbo, 'table', T_StorageRecord, 'column', IntegrityCheckCode
;


EXEC sp_addextendedproperty 'MS_Description', '����ʲ������', 'User', dbo, 'table', T_StorageRecord, 'column', CodeNO
;

EXEC sp_addextendedproperty 'MS_Description', 'Ԥ���Ŀ', 'User', dbo, 'table', T_SubjectDic
;

EXEC sp_addextendedproperty 'MS_Description', '��Ŀ���', 'User', dbo, 'table', T_SubjectDic, 'column', SubjectNO
;

EXEC sp_addextendedproperty 'MS_Description', '��Ŀ����', 'User', dbo, 'table', T_SubjectDic, 'column', SubjectName
;

EXEC sp_addextendedproperty 'MS_Description', '�������', 'User', dbo, 'table', T_SubjectDic, 'column', ClassNO
;

EXEC sp_addextendedproperty 'MS_Description', '״̬(0Ϊ������9Ϊɾ��)', 'User', dbo, 'table', T_SubjectDic, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_SubjectDic, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_SubjectDic, 'column', UpdateTime
;


EXEC sp_addextendedproperty 'MS_Description', '�������뵥', 'User', dbo, 'table', T_VerificationRecord
;

EXEC sp_addextendedproperty 'MS_Description', '�����������뵥', 'User', dbo, 'table', T_VerificationRecord, 'column', FundID
;

EXEC sp_addextendedproperty 'MS_Description', '������Ŀ', 'User', dbo, 'table', T_VerificationRecord, 'column', ProjID
;

EXEC sp_addextendedproperty 'MS_Description', '��Ʊ��', 'User', dbo, 'table', T_VerificationRecord, 'column', InvoiceFolder
;

EXEC sp_addextendedproperty 'MS_Description', '��ͬЭ��', 'User', dbo, 'table', T_VerificationRecord, 'column', ContractFolder
;

EXEC sp_addextendedproperty 'MS_Description', '�а���', 'User', dbo, 'table', T_VerificationRecord, 'column', Undertaker
;

EXEC sp_addextendedproperty 'MS_Description', '������', 'User', dbo, 'table', T_VerificationRecord, 'column', Checker
;

EXEC sp_addextendedproperty 'MS_Description', '��׼��', 'User', dbo, 'table', T_VerificationRecord, 'column', Approver
;

EXEC sp_addextendedproperty 'MS_Description', '��ת״̬��0Ϊ����״̬��1Ϊ���״̬��2Ϊ��׼״̬��', 'User', dbo, 'table', T_VerificationRecord, 'column', TransferState
;

EXEC sp_addextendedproperty 'MS_Description', '�浵״̬��0Ϊ��ת״̬��1Ϊ�浵״̬��9Ϊɾ����', 'User', dbo, 'table', T_VerificationRecord, 'column', State
;

EXEC sp_addextendedproperty 'MS_Description', '����ʱ��', 'User', dbo, 'table', T_VerificationRecord, 'column', CreateTime
;

EXEC sp_addextendedproperty 'MS_Description', '���ʱ��', 'User', dbo, 'table', T_VerificationRecord, 'column', CheckTime
;

EXEC sp_addextendedproperty 'MS_Description', '��׼ʱ��', 'User', dbo, 'table', T_VerificationRecord, 'column', ApprovalTime
;

EXEC sp_addextendedproperty 'MS_Description', 'ʵ��֧��', 'User', dbo, 'table', T_VerificationRecord, 'column', PayAmount
;

EXEC sp_addextendedproperty 'MS_Description', '��Ϣ������У����', 'User', dbo, 'table', T_VerificationRecord, 'column', IntegrityCheckCode
;