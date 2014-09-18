if exists (select * from sysobjects where id = OBJECT_ID('[sys_Applications]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Applications]

CREATE TABLE [sys_Applications] (
[ApplicationID] [int]  IDENTITY (1, 1)  NOT NULL,
[A_AppName] [nvarchar]  (50) NULL,
[A_AppDescription] [nvarchar]  (200) NULL,
[A_AppUrl] [varchar]  (50) NULL,
[A_Order] [int]  NULL)

ALTER TABLE [sys_Applications] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Applications] PRIMARY KEY  NONCLUSTERED ( [ApplicationID] )
SET IDENTITY_INSERT [sys_Applications] ON

INSERT [sys_Applications] ([ApplicationID],[A_AppName],[A_AppDescription],[A_AppUrl],[A_Order]) VALUES ( 1,N'基础模组',N'基础模组成部分',N'http://framework.web',1)
INSERT [sys_Applications] ([ApplicationID],[A_AppName],[A_AppDescription],[A_Order]) VALUES ( 2,N'财务管理应用',N'中心财务管理软件应用管理',3)

SET IDENTITY_INSERT [sys_Applications] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Event]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Event]

CREATE TABLE [sys_Event] (
[EventID] [int]  IDENTITY (1, 1)  NOT NULL,
[E_U_LoginName] [nvarchar]  (20) NULL,
[E_UserID] [int]  NULL,
[E_DateTime] [datetime]  NOT NULL DEFAULT (getdate()),
[E_ApplicationID] [int]  NULL,
[E_A_AppName] [nvarchar]  (50) NULL,
[E_M_Name] [nvarchar]  (50) NULL,
[E_M_PageCode] [varchar]  (6) NULL,
[E_From] [nvarchar]  (500) NULL,
[E_Type] [tinyint]  NOT NULL DEFAULT (1),
[E_IP] [varchar]  (15) NULL,
[E_Record] [nvarchar]  (500) NULL)

ALTER TABLE [sys_Event] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Event] PRIMARY KEY  NONCLUSTERED ( [EventID] )
SET IDENTITY_INSERT [sys_Event] ON

INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 1,0,N'2014-7-29 10:28:39',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'用户名/密码(admin/1)错误！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 2,N'admin',1,N'2014-7-29 10:32:01',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 3,N'admin',1,N'2014-7-29 10:33:10',1,N'基础模组',N'角色资料管理',N'S00M02',N'/Manager/Module/FrameWork/SystemApp/RoleManager/RoleManager.aspx?CMD=New',1,N'127.0.0.1',N'增加角色ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 4,N'admin',1,N'2014-7-29 10:33:20',1,N'基础模组',N'角色资料管理',N'S00M02',N'/Manager/Module/FrameWork/SystemApp/RoleManager/RoleManager.aspx?RoleID=1&CMD=Look',1,N'127.0.0.1',N'增加角色应用ID(1)成功!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 5,0,N'2014-7-29 10:38:48',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-7-29 10:32:01),从(127.0.0.1)IP登陆在本系统.在线时间:3.94分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 6,N'admin',1,N'2014-7-29 10:38:49',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=7665&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 7,N'admin',1,N'2014-7-29 10:38:49',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=7665&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 8,N'admin',1,N'2014-7-29 15:20:08',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 9,N'admin',1,N'2014-7-29 15:21:03',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=New',1,N'127.0.0.1',N'增加应用ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 10,N'admin',1,N'2014-7-29 15:23:21',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/moduleManager.aspx?CMD=New&S_ID=2&ModuleId=0',1,N'127.0.0.1',N'增加/修改模块ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 11,N'admin',1,N'2014-7-29 15:24:13',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=31&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(31)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 12,N'admin',1,N'2014-7-29 15:25:25',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=32&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(32)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 13,N'admin',1,N'2014-7-29 16:42:54',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ClassDic成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 14,N'admin',1,N'2014-7-29 16:45:44',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 15,N'admin',1,N'2014-7-29 16:46:04',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ClassDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 16,N'admin',1,N'2014-7-29 17:10:56',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ClassDic成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 17,N'admin',1,N'2014-7-29 17:12:39',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 18,N'admin',1,N'2014-7-29 17:14:38',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 19,N'admin',1,N'2014-7-29 17:14:51',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 20,N'admin',1,N'2014-7-29 17:15:07',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 21,N'admin',1,N'2014-7-29 17:15:14',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Delete&IDX=3',1,N'127.0.0.1',N'删除ID:3成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 22,N'admin',1,N'2014-7-29 17:20:11',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=31&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(31)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 23,N'admin',1,N'2014-7-29 17:21:31',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=31&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(31)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 24,N'admin',1,N'2014-7-29 17:55:27',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算科目成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 25,N'admin',1,N'2014-7-29 18:01:06',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算科目成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 26,N'admin',1,N'2014-7-29 18:01:17',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算科目成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 27,N'admin',1,N'2014-7-29 18:01:21',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 28,N'admin',1,N'2014-7-29 18:02:13',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=Delete&IDX=3',1,N'127.0.0.1',N'删除ID:3成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 29,N'admin',1,N'2014-7-29 18:02:43',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 30,N'admin',1,N'2014-7-29 18:03:08',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 31,N'admin',1,N'2014-7-29 18:13:59',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=31&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(31)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 32,N'admin',1,N'2014-7-29 18:16:07',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ProjectDic成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 33,N'admin',1,N'2014-7-29 18:16:39',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ProjectDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 34,N'admin',1,N'2014-7-29 18:16:50',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ProjectDic成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 35,N'admin',1,N'2014-7-29 18:16:54',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Default.aspx',1,N'127.0.0.1',N'批量删除(3)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 36,N'admin',1,N'2014-7-29 18:17:15',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=Delete&IDX=3',1,N'127.0.0.1',N'删除ID:3成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 37,N'admin',1,N'2014-7-29 18:17:25',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改T_ProjectDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 38,N'admin',1,N'2014-7-29 18:30:01',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 39,N'admin',1,N'2014-7-29 18:30:01',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 40,N'admin',1,N'2014-7-29 18:30:33',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 41,N'admin',1,N'2014-7-30 9:29:01',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 42,N'admin',1,N'2014-7-30 9:43:44',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/moduleManager.aspx?CMD=New&S_ID=2&ModuleId=0',1,N'127.0.0.1',N'增加/修改模块ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 43,N'admin',1,N'2014-7-30 9:44:14',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 44,N'admin',1,N'2014-7-30 9:44:39',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=36&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(36)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 45,N'admin',1,N'2014-7-30 10:40:11',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 46,N'admin',1,N'2014-7-30 10:40:11',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 47,N'admin',1,N'2014-7-30 10:40:19',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 48,N'admin',1,N'2014-7-30 10:43:51',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 49,N'admin',1,N'2014-7-30 10:44:03',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 50,N'admin',1,N'2014-7-30 10:55:35',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/UserManager.aspx?CMD=New',1,N'127.0.0.1',N'增加ID(test1)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 51,N'admin',1,N'2014-7-30 10:55:50',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/UserManager.aspx?CMD=New',1,N'127.0.0.1',N'增加ID(test2)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 52,N'admin',1,N'2014-7-30 10:55:57',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 53,N'test1',2,N'2014-7-30 10:56:01',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您test1，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 54,N'test1',2,N'2014-7-30 10:56:08',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 55,N'admin',1,N'2014-7-30 10:56:11',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 56,N'admin',1,N'2014-7-30 14:36:24',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 57,N'admin',1,N'2014-7-30 14:36:24',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 58,N'admin',1,N'2014-7-30 14:36:51',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 59,N'admin',1,N'2014-7-30 14:55:27',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 60,N'admin',1,N'2014-7-30 15:28:17',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改项目预算成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 61,N'admin',1,N'2014-7-30 15:32:34',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 62,N'admin',1,N'2014-7-30 15:33:26',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改项目预算成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 63,N'admin',1,N'2014-7-30 15:33:42',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 64,N'admin',1,N'2014-7-30 15:33:51',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',1,N'127.0.0.1',N'批量删除(1)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 65,N'admin',1,N'2014-7-30 15:34:13',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Delete&IDX=1',1,N'127.0.0.1',N'删除ID:1成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 66,N'admin',1,N'2014-7-30 15:35:17',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改项目预算成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 67,N'admin',1,N'2014-7-30 15:44:25',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 68,N'admin',1,N'2014-7-30 16:14:38',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=37&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(37)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 69,N'admin',1,N'2014-7-30 16:15:19',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/modulemanager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 70,N'admin',1,N'2014-7-30 16:15:47',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=35',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 71,N'admin',1,N'2014-7-30 16:18:27',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?IDX=%273%27',2,N'127.0.0.1',N'IDX字段值：''3''数据类型必需为Int型!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 72,N'admin',1,N'2014-7-30 16:18:27',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?IDX=%273%27',2,N'127.0.0.1',N'CMD字段值：低于系统允许长度1!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 73,N'admin',1,N'2014-7-30 17:04:40',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 74,N'admin',1,N'2014-7-30 17:08:18',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改预算明细成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 75,N'admin',1,N'2014-7-30 17:36:48',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 76,N'admin',1,N'2014-7-30 17:38:10',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 77,N'admin',1,N'2014-7-30 17:38:52',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 78,N'admin',1,N'2014-7-30 17:39:39',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 79,N'admin',1,N'2014-7-30 17:40:24',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 80,N'admin',1,N'2014-7-30 18:01:20',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 81,N'admin',1,N'2014-7-30 18:01:28',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 82,N'admin',1,N'2014-7-31 9:24:31',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 83,N'admin',1,N'2014-7-31 14:03:31',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 84,N'admin',1,N'2014-7-31 14:03:31',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 85,N'admin',1,N'2014-7-31 14:07:30',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 86,N'admin',1,N'2014-7-31 14:41:24',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 87,N'admin',1,N'2014-7-31 14:41:24',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 88,N'admin',1,N'2014-7-31 14:41:29',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 89,N'admin',1,N'2014-7-31 16:46:53',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 90,N'admin',1,N'2014-7-31 16:46:54',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 91,N'admin',1,N'2014-7-31 17:43:53',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 92,0,N'2014-7-31 17:58:48',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-7-31 17:43:53),从(127.0.0.1)IP登陆在本系统.在线时间:13.78分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 93,N'admin',1,N'2014-7-31 17:58:50',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=1301&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 94,N'admin',1,N'2014-7-31 17:58:50',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=1301&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 95,N'admin',1,N'2014-7-31 18:01:03',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 96,N'admin',1,N'2014-7-31 18:01:03',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 97,0,N'2014-7-31 18:01:08',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-7-31 17:58:50),从(127.0.0.1)IP登陆在本系统.在线时间:0.02分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 98,N'admin',1,N'2014-7-31 18:01:09',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3382&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 99,N'admin',1,N'2014-7-31 18:01:09',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3382&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 100,0,N'2014-7-31 18:13:29',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-7-31 18:01:09),从(127.0.0.1)IP登陆在本系统.在线时间:11.22分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 101,N'admin',1,N'2014-7-31 18:13:30',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3353&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 102,N'admin',1,N'2014-7-31 18:13:30',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3353&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 103,N'admin',1,N'2014-7-31 18:15:42',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 104,N'admin',1,N'2014-7-31 18:15:42',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 105,0,N'2014-7-31 18:15:48',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-7-31 18:13:30),从(127.0.0.1)IP登陆在本系统.在线时间:0.06分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 106,N'admin',1,N'2014-7-31 18:15:49',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6630&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 107,N'admin',1,N'2014-7-31 18:15:49',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6630&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 108,N'admin',1,N'2014-7-31 18:39:23',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 109,N'admin',1,N'2014-7-31 18:47:14',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 110,N'admin',1,N'2014-7-31 18:47:27',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 111,N'admin',1,N'2014-7-31 18:47:38',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 112,N'admin',1,N'2014-7-31 18:56:14',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 113,N'admin',1,N'2014-7-31 19:06:25',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 114,N'admin',1,N'2014-8-1 9:55:27',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 115,N'admin',1,N'2014-8-1 10:11:58',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 116,N'admin',1,N'2014-8-1 10:12:15',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 117,N'admin',1,N'2014-8-1 10:45:55',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 118,N'admin',1,N'2014-8-1 10:46:08',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 119,N'admin',1,N'2014-8-1 11:07:00',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'存在相同的模块编码(S03M03)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 120,N'admin',1,N'2014-8-1 11:07:42',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 121,N'admin',1,N'2014-8-1 11:08:16',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 122,N'admin',1,N'2014-8-1 11:08:30',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=35&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 123,N'admin',1,N'2014-8-1 11:15:45',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=44&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(44)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 124,N'admin',1,N'2014-8-1 11:15:58',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=45&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(45)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 125,N'admin',1,N'2014-8-1 11:26:55',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=44&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(44)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 126,N'admin',1,N'2014-8-1 11:27:08',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=45&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(45)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 127,N'admin',1,N'2014-8-1 11:27:31',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=2',2,N'127.0.0.1',N'不存在操作字符串!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 128,N'admin',1,N'2014-8-1 11:52:19',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 129,N'admin',1,N'2014-8-1 11:52:59',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 130,N'admin',1,N'2014-8-1 13:55:09',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 131,N'admin',1,N'2014-8-1 13:55:09',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 132,N'admin',1,N'2014-8-1 13:55:14',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 133,N'admin',1,N'2014-8-1 14:45:13',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改预算科目成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 134,N'admin',1,N'2014-8-1 15:13:01',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 135,N'admin',1,N'2014-8-1 15:13:08',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改预算明细成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 136,N'admin',1,N'2014-8-1 15:19:55',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 137,N'admin',1,N'2014-8-1 15:22:09',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 138,N'admin',1,N'2014-8-1 15:23:17',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 139,N'admin',1,N'2014-8-1 15:23:25',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 140,N'admin',1,N'2014-8-1 15:28:46',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 141,N'admin',1,N'2014-8-1 15:31:18',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 142,N'admin',1,N'2014-8-1 15:31:30',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 143,N'admin',1,N'2014-8-1 15:31:37',1,N'基础模组',N'S03M09',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=6',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 144,N'admin',1,N'2014-8-1 15:55:17',1,N'基础模组',N'S03M10',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 145,N'admin',1,N'2014-8-1 15:59:21',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=37&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(37)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 146,N'admin',1,N'2014-8-1 15:59:33',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=44&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(44)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 147,N'admin',1,N'2014-8-1 15:59:43',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=45&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(45)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 148,N'admin',1,N'2014-8-1 16:00:40',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/modulemanager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 149,N'admin',1,N'2014-8-1 16:04:52',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=35&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 150,N'admin',1,N'2014-8-1 16:04:52',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=35&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 151,N'admin',1,N'2014-8-1 16:11:22',1,N'基础模组',N'S03M11',N'/Manager/Module/ShanliTech/T_FundsRecordFinish/Manager.aspx?CMD=Edit&IDX=5',2,N'127.0.0.1',N'不存在操作字符串!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 152,N'admin',1,N'2014-8-1 17:05:36',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 153,N'admin',1,N'2014-8-1 17:47:20',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 154,N'admin',1,N'2014-8-1 17:49:35',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 155,N'admin',1,N'2014-8-1 18:36:33',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 156,N'admin',1,N'2014-8-2 10:20:53',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 157,N'admin',1,N'2014-8-2 10:22:04',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=37&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(37)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 158,N'admin',1,N'2014-8-2 10:56:24',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 159,0,N'2014-8-2 11:10:14',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-2 10:20:53),从(127.0.0.1)IP登陆在本系统.在线时间:35.57分.')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 160,0,N'2014-8-2 11:10:22',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-2 10:20:53),从(127.0.0.1)IP登陆在本系统.在线时间:35.57分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 161,N'admin',1,N'2014-8-2 11:10:22',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6470&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 162,N'admin',1,N'2014-8-2 11:10:22',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6470&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 163,N'admin',1,N'2014-8-2 13:07:36',1,N'基础模组',N'S03M11',N'/Manager/Module/ShanliTech/T_FundsRecordFinish/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 164,N'admin',1,N'2014-8-2 13:07:36',1,N'基础模组',N'S03M11',N'/Manager/Module/ShanliTech/T_FundsRecordFinish/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 165,N'admin',1,N'2014-8-2 13:09:03',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 166,N'admin',1,N'2014-8-2 13:09:54',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 167,N'admin',1,N'2014-8-2 13:18:45',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 168,N'admin',1,N'2014-8-2 13:19:03',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=47&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(47)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 169,N'admin',1,N'2014-8-2 13:19:13',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 170,N'admin',1,N'2014-8-2 13:19:21',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=47&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(47)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 171,N'admin',1,N'2014-8-2 13:19:31',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/modulemanager.aspx?S_ID=2&ModuleID=35',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 172,N'admin',1,N'2014-8-2 13:35:10',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 173,N'admin',1,N'2014-8-2 13:48:40',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 174,N'admin',1,N'2014-8-2 13:49:08',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=47&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(47)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 175,N'admin',1,N'2014-8-2 13:50:10',1,N'基础模组',N'S03M10',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 176,N'admin',1,N'2014-8-2 14:54:50',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 177,N'admin',1,N'2014-8-2 14:55:31',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 178,N'admin',1,N'2014-8-2 14:56:13',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 179,N'admin',1,N'2014-8-2 14:57:04',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 180,N'admin',1,N'2014-8-2 15:04:49',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=35',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 181,N'admin',1,N'2014-8-2 17:23:43',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 182,N'admin',1,N'2014-8-2 17:26:38',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 183,N'admin',1,N'2014-8-2 17:32:07',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 184,N'admin',1,N'2014-8-2 18:03:58',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 185,N'admin',1,N'2014-8-2 18:12:17',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 186,N'admin',1,N'2014-8-3 10:01:34',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 187,N'admin',1,N'2014-8-3 10:02:23',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=New',1,N'127.0.0.1',N'增加应用ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 188,N'admin',1,N'2014-8-3 10:02:41',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=New',1,N'127.0.0.1',N'增加应用ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 189,N'admin',1,N'2014-8-3 10:03:19',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=New',1,N'127.0.0.1',N'增加应用ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 190,N'admin',1,N'2014-8-3 10:03:30',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=Edit&S_ID=4',1,N'127.0.0.1',N'修改应用ID(4)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 191,N'admin',1,N'2014-8-3 10:07:01',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/Orderby.aspx',1,N'127.0.0.1',N'排序应用成功!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 192,0,N'2014-8-3 10:08:26',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-3 10:01:34),从(127.0.0.1)IP登陆在本系统.在线时间:5.46分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 193,N'admin',1,N'2014-8-3 10:08:27',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=0810&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 194,N'admin',1,N'2014-8-3 10:08:27',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=0810&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 195,N'admin',1,N'2014-8-3 10:10:27',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/moduleManager.aspx?CMD=New&S_ID=2&ModuleId=0',1,N'127.0.0.1',N'增加/修改模块ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 196,N'admin',1,N'2014-8-3 10:11:15',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/moduleManager.aspx?CMD=New&S_ID=2&ModuleId=0',1,N'127.0.0.1',N'增加/修改模块ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 197,N'admin',1,N'2014-8-3 10:11:42',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/moduleManager.aspx?CMD=New&S_ID=2&ModuleId=0',1,N'127.0.0.1',N'增加/修改模块ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 198,N'admin',1,N'2014-8-3 10:13:24',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=35&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(35)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 199,N'admin',1,N'2014-8-3 10:14:55',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=Delete&S_ID=4',1,N'127.0.0.1',N'删除记录ID:(4)成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 200,N'admin',1,N'2014-8-3 10:15:07',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=Delete&S_ID=5',1,N'127.0.0.1',N'删除记录ID:(5)成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 201,N'admin',1,N'2014-8-3 10:15:12',1,N'基础模组',N'应用列表管理',N'S00M00',N'/Manager/Module/FrameWork/SystemApp/AppManager/AppManager.aspx?CMD=Delete&S_ID=3',1,N'127.0.0.1',N'删除记录ID:(3)成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 202,N'admin',1,N'2014-8-3 10:17:11',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleList.aspx?S_ID=2&AppName=%u8d22%u52a1%u7ba1%u7406%u5e94%u7528',1,N'127.0.0.1',N'排序财务管理应用模块成功!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 203,0,N'2014-8-3 11:14:28',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-3 10:08:27),从(127.0.0.1)IP登陆在本系统.在线时间:53.45分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 204,N'admin',1,N'2014-8-3 11:14:29',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=1436&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 205,N'admin',1,N'2014-8-3 11:14:29',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=1436&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 206,N'admin',1,N'2014-8-3 11:14:57',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 207,N'admin',1,N'2014-8-3 11:34:15',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 208,0,N'2014-8-3 11:34:35',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-3 11:14:29),从(127.0.0.1)IP登陆在本系统.在线时间:19.77分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 209,N'admin',1,N'2014-8-3 11:34:36',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3220&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 210,N'admin',1,N'2014-8-3 11:34:36',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3220&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 211,N'admin',1,N'2014-8-3 11:34:52',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 212,N'admin',1,N'2014-8-3 11:35:23',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 213,N'admin',1,N'2014-8-3 11:37:14',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 214,N'admin',1,N'2014-8-3 11:39:03',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 215,N'admin',1,N'2014-8-3 11:42:58',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 216,N'admin',1,N'2014-8-3 11:48:22',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 217,N'admin',1,N'2014-8-3 11:50:03',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 218,N'admin',1,N'2014-8-3 11:54:50',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 219,N'admin',1,N'2014-8-3 11:56:28',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 220,N'admin',1,N'2014-8-3 11:56:38',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 221,N'admin',1,N'2014-8-3 11:58:00',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 222,N'admin',1,N'2014-8-3 11:58:41',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 223,N'admin',1,N'2014-8-3 12:00:27',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 224,N'admin',1,N'2014-8-3 12:02:51',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 225,N'admin',1,N'2014-8-3 12:05:33',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改核销申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 226,N'admin',1,N'2014-8-3 12:05:54',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改核销申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 227,N'admin',1,N'2014-8-3 12:19:37',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 228,N'admin',1,N'2014-8-3 14:15:05',0,N'/Manager/Messages.aspx?CMD=AppError',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 229,N'admin',1,N'2014-8-3 14:15:05',0,N'/Manager/Messages.aspx?CMD=AppError',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 230,N'admin',1,N'2014-8-3 14:15:49',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 231,N'admin',1,N'2014-8-3 14:59:17',1,N'基础模组',N'S06M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 232,N'admin',1,N'2014-8-3 14:59:17',1,N'基础模组',N'S06M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 233,N'admin',1,N'2014-8-3 14:59:22',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 234,N'admin',1,N'2014-8-3 15:03:54',1,N'基础模组',N'S06M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改核销申请单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 235,N'admin',1,N'2014-8-3 15:04:01',1,N'基础模组',N'S06M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改核销申请单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 236,N'admin',1,N'2014-8-3 15:04:05',1,N'基础模组',N'S06M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改核销申请单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 237,N'admin',1,N'2014-8-3 15:04:09',1,N'基础模组',N'S06M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改核销申请单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 238,N'admin',1,N'2014-8-3 16:20:33',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleList.aspx?S_ID=2&AppName=%E8%B4%A2%E5%8A%A1%E7%AE%A1%E7%90%86%E5%BA%94%E7%94%A8',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 239,N'admin',1,N'2014-8-3 16:20:33',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleList.aspx?S_ID=2&AppName=%E8%B4%A2%E5%8A%A1%E7%AE%A1%E7%90%86%E5%BA%94%E7%94%A8',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 240,N'admin',1,N'2014-8-3 16:20:38',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 241,N'admin',1,N'2014-8-3 17:14:39',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=54&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(54)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 242,N'admin',1,N'2014-8-3 17:15:06',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=40&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(40)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 243,N'admin',1,N'2014-8-3 17:15:44',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/modulemanager.aspx?CMD=New&ModuleID=54&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(54)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 244,N'admin',1,N'2014-8-3 17:15:57',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=41&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(41)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 245,N'admin',1,N'2014-8-3 17:16:38',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/modulemanager.aspx?CMD=New&ModuleID=54&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(54)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 246,N'admin',1,N'2014-8-3 17:17:13',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=New&ModuleID=54&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(54)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 247,N'admin',1,N'2014-8-3 17:17:31',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 248,N'admin',1,N'2014-8-3 17:21:17',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 249,N'admin',1,N'2014-8-3 17:22:53',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 250,N'admin',1,N'2014-8-3 17:23:51',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 251,N'admin',1,N'2014-8-3 17:41:28',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 252,N'admin',1,N'2014-8-3 17:41:55',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 253,N'admin',1,N'2014-8-3 17:42:06',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 254,N'admin',1,N'2014-8-3 17:42:17',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 255,N'admin',1,N'2014-8-3 17:42:27',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 256,N'admin',1,N'2014-8-3 17:42:34',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 257,N'admin',1,N'2014-8-3 17:43:53',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 258,N'admin',1,N'2014-8-3 17:44:02',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?ModuleID=54&S_ID=2',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 259,N'admin',1,N'2014-8-3 17:45:25',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 260,N'admin',1,N'2014-8-3 18:16:44',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=46&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(46)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 261,N'admin',1,N'2014-8-3 18:46:12',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?S_ID=2&ModuleID=54',1,N'127.0.0.1',N'排序子模块成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 262,N'admin',1,N'2014-8-4 10:05:37',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 263,N'admin',1,N'2014-8-4 11:23:01',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 264,N'admin',1,N'2014-8-4 14:17:44',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 265,N'admin',1,N'2014-8-4 14:17:44',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 266,N'admin',1,N'2014-8-4 14:17:50',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 267,0,N'2014-8-4 16:04:57',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-4 14:17:50),从(127.0.0.1)IP登陆在本系统.在线时间:85.64分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 268,N'admin',1,N'2014-8-4 16:04:59',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3180&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 269,N'admin',1,N'2014-8-4 16:04:59',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=3180&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 270,N'admin',1,N'2014-8-4 16:16:28',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 271,N'admin',1,N'2014-8-4 16:40:51',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 272,N'admin',1,N'2014-8-4 16:47:32',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 273,N'admin',1,N'2014-8-4 17:09:34',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 274,N'admin',1,N'2014-8-4 17:12:28',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 275,N'admin',1,N'2014-8-4 17:12:33',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改入库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 276,N'admin',1,N'2014-8-4 17:17:11',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改入库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 277,N'admin',1,N'2014-8-4 17:19:14',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=55&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(55)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 278,N'admin',1,N'2014-8-4 17:19:25',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=56&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(56)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 279,N'admin',1,N'2014-8-4 17:19:35',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=57&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(57)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 280,N'admin',1,N'2014-8-4 17:19:43',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=58&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(58)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 281,N'admin',1,N'2014-8-4 17:20:16',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=40&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(40)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 282,N'admin',1,N'2014-8-4 17:20:24',1,N'基础模组',N'应用模块管理',N'S00M07',N'/Manager/Module/FrameWork/SystemApp/ModuleManager/ModuleManager.aspx?CMD=Edit&ModuleID=41&S_ID=2',1,N'127.0.0.1',N'增加/修改模块ID(41)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 283,N'admin',1,N'2014-8-4 17:30:58',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 284,N'admin',1,N'2014-8-4 17:33:01',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改入库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 285,N'admin',1,N'2014-8-4 17:34:04',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 286,N'admin',1,N'2014-8-4 17:38:27',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 287,N'admin',1,N'2014-8-4 17:50:00',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 288,N'admin',1,N'2014-8-4 17:50:17',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改入库表单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 289,N'admin',1,N'2014-8-4 17:50:25',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改入库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 290,N'admin',1,N'2014-8-4 18:02:42',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改入库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 291,N'admin',1,N'2014-8-4 18:03:18',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 292,N'admin',1,N'2014-8-4 18:07:07',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 293,N'admin',1,N'2014-8-4 18:14:55',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 294,N'admin',1,N'2014-8-5 10:00:54',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 295,N'admin',1,N'2014-8-5 11:05:52',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加出库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 296,N'admin',1,N'2014-8-5 11:06:06',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改出库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 297,N'admin',1,N'2014-8-5 11:26:56',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改出库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 298,N'admin',1,N'2014-8-5 11:53:15',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加出库表单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 299,N'admin',1,N'2014-8-5 11:57:15',1,N'基础模组',N'S03M08',N'/Manager/Module/ShanliTech/T_Stock/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加库存成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 300,N'admin',1,N'2014-8-5 13:50:31',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 301,0,N'2014-8-5 14:00:49',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-5 13:50:31),从(127.0.0.1)IP登陆在本系统.在线时间:0.07分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 302,N'admin',1,N'2014-8-5 14:00:50',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=8567&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 303,N'admin',1,N'2014-8-5 14:00:50',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=8567&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 304,N'admin',1,N'2014-8-6 11:06:09',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 305,0,N'2014-8-6 11:06:11',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-6 11:06:09),从(127.0.0.1)IP登陆在本系统.在线时间:0.01分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 306,N'admin',1,N'2014-8-6 11:06:12',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=0180&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 307,N'admin',1,N'2014-8-6 11:06:12',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=0180&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 308,N'admin',1,N'2014-8-6 11:09:02',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 309,N'admin',1,N'2014-8-6 11:09:02',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 310,N'admin',1,N'2014-8-6 11:09:21',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 311,N'admin',1,N'2014-8-6 11:09:27',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改T_ClassDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 312,N'admin',1,N'2014-8-6 11:11:44',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费类别成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 313,N'admin',1,N'2014-8-6 11:12:03',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改预算科目成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 314,N'admin',1,N'2014-8-6 11:12:13',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改T_ProjectDic成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 315,N'admin',1,N'2014-8-6 11:12:26',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改项目预算成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 316,N'admin',1,N'2014-8-6 11:32:49',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 317,N'admin',1,N'2014-8-6 11:50:57',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 318,N'admin',1,N'2014-8-6 11:51:26',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 319,N'admin',1,N'2014-8-6 13:59:26',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 320,N'admin',1,N'2014-8-6 13:59:27',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 321,N'admin',1,N'2014-8-6 14:05:56',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 322,N'admin',1,N'2014-8-6 14:21:03',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改项目预算成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 323,N'admin',1,N'2014-8-6 14:28:30',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 324,N'admin',1,N'2014-8-6 14:30:11',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 325,N'admin',1,N'2014-8-6 14:34:22',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 326,N'admin',1,N'2014-8-6 14:35:17',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 327,N'admin',1,N'2014-8-6 14:38:24',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=6',1,N'127.0.0.1',N'修改预算明细成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 328,N'admin',1,N'2014-8-6 14:38:32',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改预算明细成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 329,N'admin',1,N'2014-8-6 14:38:53',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改预算明细成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 330,N'admin',1,N'2014-8-6 14:39:02',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改预算明细成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 331,N'admin',1,N'2014-8-6 14:46:44',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 332,N'admin',1,N'2014-8-6 14:46:59',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 333,N'admin',1,N'2014-8-6 14:47:09',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 334,N'admin',1,N'2014-8-6 14:56:30',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 335,N'admin',1,N'2014-8-6 14:56:58',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 336,N'admin',1,N'2014-8-6 14:59:47',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 337,N'admin',1,N'2014-8-6 15:02:29',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 338,N'admin',1,N'2014-8-6 15:05:10',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Default.aspx',1,N'127.0.0.1',N'批量删除(9)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 339,N'admin',1,N'2014-8-6 15:05:59',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 340,N'admin',1,N'2014-8-6 15:08:02',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_FundsRecordCunDang/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改经费使用存档单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 341,N'admin',1,N'2014-8-6 15:17:38',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 342,N'admin',1,N'2014-8-6 15:21:43',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 343,N'admin',1,N'2014-8-6 15:21:55',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 344,N'admin',1,N'2014-8-6 15:22:39',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 345,N'admin',1,N'2014-8-6 15:28:20',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 346,N'admin',1,N'2014-8-6 15:31:29',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 347,N'admin',1,N'2014-8-6 15:31:41',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 348,N'admin',1,N'2014-8-6 15:31:56',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 349,N'admin',1,N'2014-8-6 15:32:19',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 350,N'admin',1,N'2014-8-6 15:34:52',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 351,N'admin',1,N'2014-8-6 15:35:21',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 352,N'admin',1,N'2014-8-6 15:35:36',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 353,N'admin',1,N'2014-8-6 15:45:29',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 354,N'admin',1,N'2014-8-6 15:53:59',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 355,N'admin',1,N'2014-8-6 15:56:59',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_FundsRecordCunDang/Manager.aspx?CMD=Edit&IDX=4',1,N'127.0.0.1',N'修改经费使用存档单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 356,N'admin',1,N'2014-8-6 16:00:31',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 357,N'admin',1,N'2014-8-6 16:14:03',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 358,N'admin',1,N'2014-8-6 16:15:11',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 359,N'admin',1,N'2014-8-6 16:22:43',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改核销申请单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 360,N'admin',1,N'2014-8-6 16:25:46',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Delete&IDX=7',1,N'127.0.0.1',N'删除ID:7成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 361,N'admin',1,N'2014-8-6 17:00:51',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',1,N'127.0.0.1',N'批量删除(6)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 362,N'admin',1,N'2014-8-6 17:12:48',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 363,N'admin',1,N'2014-8-6 18:10:28',1,N'基础模组',N'S05M04',N'/Manager/Module/ShanliTech/T_VerificationRecordCunDang/Default.aspx',1,N'127.0.0.1',N'批量删除(1)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 364,N'admin',1,N'2014-8-6 18:22:12',1,N'基础模组',N'S05M05',N'/Manager/Module/ShanliTech/T_VerificationRecordFinish/Default.aspx',1,N'127.0.0.1',N'批量删除(2)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 365,N'admin',1,N'2014-8-7 9:23:50',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 366,N'admin',1,N'2014-8-7 9:24:51',1,N'基础模组',N'S02M01',N'/Manager/Module/ShanliTech/T_ClassDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费类别成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 367,N'admin',1,N'2014-8-7 9:25:14',1,N'基础模组',N'S02M02',N'/Manager/Module/ShanliTech/T_SubjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算科目成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 368,N'admin',1,N'2014-8-7 9:25:32',1,N'基础模组',N'S02M03',N'/Manager/Module/ShanliTech/T_ProjectDic/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加T_ProjectDic成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 369,N'admin',1,N'2014-8-7 9:31:02',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加项目预算成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 370,N'admin',1,N'2014-8-7 9:37:56',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加预算明细成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 371,N'admin',1,N'2014-8-7 9:40:20',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 372,N'admin',1,N'2014-8-7 9:44:41',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=10',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 373,N'admin',1,N'2014-8-8 11:11:55',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 374,N'admin',1,N'2014-8-8 14:14:42',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 375,N'admin',1,N'2014-8-8 14:14:42',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 376,N'admin',1,N'2014-8-8 14:14:51',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 377,N'admin',1,N'2014-8-8 15:04:21',1,N'基础模组',N'角色资料管理',N'S00M02',N'/Manager/Module/FrameWork/SystemApp/RoleManager/RoleManager.aspx?CMD=New',1,N'127.0.0.1',N'增加角色ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 378,N'admin',1,N'2014-8-8 15:05:11',1,N'基础模组',N'角色资料管理',N'S00M02',N'/Manager/Module/FrameWork/SystemApp/RoleManager/RoleManager.aspx?CMD=New',1,N'127.0.0.1',N'增加角色ID(0)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 379,N'admin',1,N'2014-8-8 15:48:45',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 380,N'admin',1,N'2014-8-8 15:48:45',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 381,N'admin',1,N'2014-8-8 15:48:49',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 382,N'admin',1,N'2014-8-8 15:49:03',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/UserManager.aspx?CMD=Edit&UserID=3',1,N'127.0.0.1',N'修改ID(test2)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 383,N'admin',1,N'2014-8-8 15:49:09',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/UserManager.aspx?CMD=Edit&UserID=2',1,N'127.0.0.1',N'修改ID(test1)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_Name],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 384,N'admin',1,N'2014-8-8 15:49:09',1,N'基础模组',N'用户资料管理',N'S00M03',N'/Manager/Module/FrameWork/SystemApp/UserManager/UserManager.aspx?CMD=Edit&UserID=2',1,N'127.0.0.1',N'修改ID(test1)成功!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 385,N'admin',1,N'2014-8-8 18:14:04',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 386,N'admin',1,N'2014-8-8 18:14:04',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 387,N'admin',1,N'2014-8-11 9:32:12',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 388,N'admin',1,N'2014-8-11 11:20:12',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 389,N'admin',1,N'2014-8-11 11:22:27',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改项目预算成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 390,N'admin',1,N'2014-8-11 14:33:04',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值： 数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 391,0,N'2014-8-11 14:41:43',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-11 11:20:12),从(127.0.0.1)IP登陆在本系统.在线时间:192.86分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 392,N'admin',1,N'2014-8-11 14:41:44',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5350&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 393,N'admin',1,N'2014-8-11 14:41:44',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5350&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 394,N'admin',1,N'2014-8-11 14:43:52',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值： 数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 395,N'admin',1,N'2014-8-11 17:57:58',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 396,N'admin',1,N'2014-8-11 17:58:22',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值： 数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 397,N'admin',1,N'2014-8-11 18:01:21',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值：  数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 398,N'admin',1,N'2014-8-11 18:02:02',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值：  数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 399,0,N'2014-8-11 18:07:25',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-11 17:57:58),从(127.0.0.1)IP登陆在本系统.在线时间:4.07分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 400,N'admin',1,N'2014-8-11 18:07:26',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=4286&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 401,N'admin',1,N'2014-8-11 18:07:26',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=4286&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 402,N'admin',1,N'2014-8-11 18:07:37',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',2,N'127.0.0.1',N'ctl00$PageBody$BudgetRevenue_Input字段值：  数据类型必需为Double型!')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 403,N'admin',1,N'2014-8-11 18:13:33',1,N'基础模组',N'S04M01',N'/Manager/Module/ShanliTech/T_ProjectBudget/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改项目预算成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 404,N'admin',1,N'2014-8-12 10:16:38',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 405,N'admin',1,N'2014-8-12 11:26:06',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改预算明细成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 406,N'admin',1,N'2014-8-12 11:26:36',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改预算明细成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 407,N'admin',1,N'2014-8-12 11:41:31',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改预算明细成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 408,N'admin',1,N'2014-8-12 14:11:41',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 409,N'admin',1,N'2014-8-12 14:11:42',1,N'基础模组',N'S04M02',N'/Manager/Module/ShanliTech/T_BudgetDetail/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 410,N'admin',1,N'2014-8-12 14:11:51',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 411,N'admin',1,N'2014-8-14 9:58:35',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 412,N'admin',1,N'2014-8-14 11:24:05',0,N'/Manager/left.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 413,N'admin',1,N'2014-8-14 11:24:06',0,N'/Manager/left.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 414,N'admin',1,N'2014-8-14 11:24:06',0,N'/Manager/right.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 415,N'admin',1,N'2014-8-14 11:24:06',0,N'/Manager/right.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 416,N'admin',1,N'2014-8-14 11:24:23',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 417,N'admin',1,N'2014-8-14 14:29:21',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 418,N'admin',1,N'2014-8-14 14:29:21',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 419,N'admin',1,N'2014-8-14 14:29:37',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 420,N'admin',1,N'2014-8-14 14:45:59',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加经费使用申请单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 421,N'admin',1,N'2014-8-14 14:49:46',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=10',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 422,N'admin',1,N'2014-8-14 15:35:23',1,N'基础模组',N'S03M01',N'/Manager/Module/ShanliTech/T_FundsRecord/Manager.aspx?CMD=Edit&IDX=11',1,N'127.0.0.1',N'修改经费使用申请单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 423,N'admin',1,N'2014-8-14 16:04:08',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=11',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 424,N'admin',1,N'2014-8-14 16:11:42',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=10',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 425,N'admin',1,N'2014-8-14 16:12:13',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=6',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 426,N'admin',1,N'2014-8-14 16:15:06',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 427,N'admin',1,N'2014-8-14 17:22:45',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=10',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 428,N'admin',1,N'2014-8-14 17:36:34',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 429,N'admin',1,N'2014-8-14 17:36:44',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=11',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 430,N'admin',1,N'2014-8-14 17:49:17',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=11',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 431,N'admin',1,N'2014-8-14 17:50:08',1,N'基础模组',N'S03M02',N'/Manager/Module/ShanliTech/T_FundsRecordShenHe/Manager.aspx?CMD=Edit&IDX=6',1,N'127.0.0.1',N'修改经费使用审核单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 432,N'admin',1,N'2014-8-14 17:54:07',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 433,N'admin',1,N'2014-8-14 17:54:28',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 434,N'admin',1,N'2014-8-14 18:08:31',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_FundsRecordCunDang/Manager.aspx?CMD=Edit&IDX=11',1,N'127.0.0.1',N'修改经费使用存档单成功!(ID:11)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 435,N'admin',1,N'2014-8-14 18:12:45',1,N'基础模组',N'S03M03',N'/Manager/Module/ShanliTech/T_FundsRecordPiZhun/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改经费使用批准单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 436,N'admin',1,N'2014-8-14 18:12:53',1,N'基础模组',N'S03M04',N'/Manager/Module/ShanliTech/T_FundsRecordCunDang/Manager.aspx?CMD=Edit&IDX=7',1,N'127.0.0.1',N'修改经费使用存档单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 437,N'admin',1,N'2014-8-14 18:17:50',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 438,N'admin',1,N'2014-8-15 14:20:41',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 439,0,N'2014-8-15 16:06:33',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 14:20:41),从(127.0.0.1)IP登陆在本系统.在线时间:105.14分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 440,N'admin',1,N'2014-8-15 16:06:34',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=4851&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 441,N'admin',1,N'2014-8-15 16:06:34',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=4851&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 442,0,N'2014-8-15 16:10:17',0,N'/Manager/Login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 16:06:34),从(127.0.0.1)IP登陆在本系统.在线时间:0.31分.')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 443,0,N'2014-8-15 16:10:21',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 16:06:34),从(127.0.0.1)IP登陆在本系统.在线时间:0.31分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 444,N'admin',1,N'2014-8-15 16:10:22',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=7414&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 445,N'admin',1,N'2014-8-15 16:10:22',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=7414&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 446,N'admin',1,N'2014-8-15 16:12:22',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 447,N'admin',1,N'2014-8-15 16:12:22',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 448,N'admin',1,N'2014-8-15 16:14:26',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 449,N'admin',1,N'2014-8-15 16:14:26',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 450,0,N'2014-8-15 16:14:34',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 16:10:22),从(127.0.0.1)IP登陆在本系统.在线时间:2.18分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 451,N'admin',1,N'2014-8-15 16:14:35',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5371&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 452,N'admin',1,N'2014-8-15 16:14:35',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5371&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 453,N'admin',1,N'2014-8-15 16:16:39',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改核销申请审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 454,N'admin',1,N'2014-8-15 16:17:55',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改核销申请审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 455,N'admin',1,N'2014-8-15 16:28:40',1,N'基础模组',N'S05M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改核销申请批准单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 456,N'admin',1,N'2014-8-15 16:29:48',1,N'基础模组',N'S05M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改核销申请批准单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 457,N'admin',1,N'2014-8-15 16:31:25',1,N'基础模组',N'S05M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改核销申请批准单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 458,N'admin',1,N'2014-8-15 17:04:13',1,N'基础模组',N'S05M04',N'/Manager/Module/ShanliTech/T_VerificationRecordCunDang/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改核销存档单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 459,N'admin',1,N'2014-8-15 17:09:06',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 460,0,N'2014-8-15 17:13:04',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 16:14:35),从(127.0.0.1)IP登陆在本系统.在线时间:54.63分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 461,N'admin',1,N'2014-8-15 17:13:05',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=2612&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 462,N'admin',1,N'2014-8-15 17:13:05',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=2612&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 463,N'admin',1,N'2014-8-15 17:17:37',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 464,N'admin',1,N'2014-8-15 17:17:37',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 465,N'admin',1,N'2014-8-15 17:17:38',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 466,N'admin',1,N'2014-8-15 17:17:38',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 467,0,N'2014-8-15 17:17:44',0,N'/Manager/login.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 17:13:05),从(127.0.0.1)IP登陆在本系统.在线时间:3.32分.')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 468,0,N'2014-8-15 17:17:47',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 17:13:05),从(127.0.0.1)IP登陆在本系统.在线时间:3.32分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 469,N'admin',1,N'2014-8-15 17:17:48',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=2822&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 470,N'admin',1,N'2014-8-15 17:17:48',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=2822&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 471,N'admin',1,N'2014-8-15 17:18:22',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 472,N'admin',1,N'2014-8-15 17:24:45',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 473,N'admin',1,N'2014-8-15 17:27:11',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 474,N'admin',1,N'2014-8-15 17:30:24',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 475,N'admin',1,N'2014-8-15 17:33:04',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 476,N'admin',1,N'2014-8-15 17:33:04',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 477,0,N'2014-8-15 17:33:17',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 17:17:48),从(127.0.0.1)IP登陆在本系统.在线时间:14.19分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 478,N'admin',1,N'2014-8-15 17:33:18',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5577&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 479,N'admin',1,N'2014-8-15 17:33:18',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=5577&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 480,N'admin',1,N'2014-8-15 17:38:46',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 481,N'admin',1,N'2014-8-15 17:47:42',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Manager.aspx?CMD=Edit&IDX=8',1,N'127.0.0.1',N'修改核销申请审核单成功!(ID:8)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 482,N'admin',1,N'2014-8-15 17:48:00',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 483,N'admin',1,N'2014-8-15 17:48:00',0,N'/Manager/default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 484,0,N'2014-8-15 17:48:03',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'您的用户名(admin)已经于(2014-8-15 17:33:18),从(127.0.0.1)IP登陆在本系统.在线时间:14.50分.')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 485,N'admin',1,N'2014-8-15 17:48:04',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6727&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'强制帐号admin下线成功！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 486,N'admin',1,N'2014-8-15 17:48:04',0,N'/Manager/Login.aspx?CMD=OutOnline&OPCode=6727&U_LoginName=admin&U_Password=1&SessionID=admin',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 487,N'admin',1,N'2014-8-15 17:48:13',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 488,N'admin',1,N'2014-8-15 17:50:24',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 489,N'admin',1,N'2014-8-15 17:50:24',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Default.aspx',2,N'127.0.0.1',N'您与系统的连接已经超时，请重新登陆！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 490,N'admin',1,N'2014-8-15 18:08:43',0,N'/Manager/LoginOut.aspx',2,N'127.0.0.1',N'用户退出')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 491,N'admin',1,N'2014-8-19 10:26:26',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 492,N'admin',1,N'2014-8-19 14:42:42',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 493,N'admin',1,N'2014-8-19 16:56:06',0,N'/Manager/Login.aspx?ReturnUrl=%2fManager%2fdefault.aspx',2,N'127.0.0.1',N'欢迎您admin，成功登入。您的IP为：127.0.0.1！')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 494,N'admin',1,N'2014-8-19 16:57:31',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=Edit&IDX=5',1,N'127.0.0.1',N'修改核销申请单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 495,N'admin',1,N'2014-8-19 16:58:06',1,N'基础模组',N'S05M02',N'/Manager/Module/ShanliTech/T_VerificationRecordShenHe/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请审核单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 496,N'admin',1,N'2014-8-19 16:58:16',1,N'基础模组',N'S05M03',N'/Manager/Module/ShanliTech/T_VerificationRecordPiZhun/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销申请批准单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 497,N'admin',1,N'2014-8-19 16:58:26',1,N'基础模组',N'S05M04',N'/Manager/Module/ShanliTech/T_VerificationRecordCunDang/Manager.aspx?CMD=Edit&IDX=9',1,N'127.0.0.1',N'修改核销存档单成功!(ID:9)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 498,N'admin',1,N'2014-8-19 17:37:47',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 499,N'admin',1,N'2014-8-19 17:38:08',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=Edit&IDX=6',1,N'127.0.0.1',N'修改入库表单成功!(ID:6)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 500,N'admin',1,N'2014-8-19 17:44:44',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加出库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 501,N'admin',1,N'2014-8-19 17:53:08',1,N'基础模组',N'S05M01',N'/Manager/Module/ShanliTech/T_VerificationRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加核销申请单成功!(ID:10)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 502,N'admin',1,N'2014-8-19 18:02:34',1,N'基础模组',N'S03M05',N'/Manager/Module/ShanliTech/T_StorageRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加入库表单成功!(ID:7)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 503,N'admin',1,N'2014-8-19 18:03:14',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=1',1,N'127.0.0.1',N'修改出库表单成功!(ID:1)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 504,N'admin',1,N'2014-8-19 18:03:33',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改出库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 505,N'admin',1,N'2014-8-19 18:03:40',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=3',1,N'127.0.0.1',N'修改出库表单成功!(ID:3)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 506,N'admin',1,N'2014-8-19 18:03:48',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加出库表单成功!(ID:4)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 507,N'admin',1,N'2014-8-19 18:05:56',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加出库表单成功!(ID:5)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 508,N'admin',1,N'2014-8-19 18:06:01',1,N'基础模组',N'S03M06',N'/Manager/Module/ShanliTech/T_OutboundRecord/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改出库表单成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 509,N'admin',1,N'2014-8-19 18:12:32',1,N'基础模组',N'S03M08',N'/Manager/Module/ShanliTech/T_Stock/Manager.aspx?CMD=New',1,N'127.0.0.1',N'增加库存成功!(ID:2)')
INSERT [sys_Event] ([EventID],[E_U_LoginName],[E_UserID],[E_DateTime],[E_ApplicationID],[E_A_AppName],[E_M_PageCode],[E_From],[E_Type],[E_IP],[E_Record]) VALUES ( 510,N'admin',1,N'2014-8-19 18:12:46',1,N'基础模组',N'S03M08',N'/Manager/Module/ShanliTech/T_Stock/Manager.aspx?CMD=Edit&IDX=2',1,N'127.0.0.1',N'修改库存成功!(ID:2)')

SET IDENTITY_INSERT [sys_Event] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Field]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Field]

CREATE TABLE [sys_Field] (
[FieldID] [int]  IDENTITY (1, 1)  NOT NULL,
[F_Key] [varchar]  (50) NULL,
[F_CName] [nvarchar]  (50) NULL,
[F_Remark] [nvarchar]  (200) NULL)

ALTER TABLE [sys_Field] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Field] PRIMARY KEY  NONCLUSTERED ( [FieldID] )
SET IDENTITY_INSERT [sys_Field] ON

INSERT [sys_Field] ([FieldID],[F_Key],[F_CName],[F_Remark]) VALUES ( 2,N'Title',N'职称',N'用户职称列表')

SET IDENTITY_INSERT [sys_Field] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_FieldValue]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_FieldValue]

CREATE TABLE [sys_FieldValue] (
[ValueID] [int]  IDENTITY (1, 1)  NOT NULL,
[V_F_Key] [varchar]  (50) NULL,
[V_Text] [nvarchar]  (100) NULL,
[V_Code] [varchar]  (100) NULL,
[V_ShowOrder] [int]  NOT NULL DEFAULT (0))

ALTER TABLE [sys_FieldValue] WITH NOCHECK ADD  CONSTRAINT [PK_sys_FieldValue] PRIMARY KEY  NONCLUSTERED ( [ValueID] )
SET IDENTITY_INSERT [sys_FieldValue] ON

INSERT [sys_FieldValue] ([ValueID],[V_F_Key],[V_Text],[V_ShowOrder]) VALUES ( 5,N'title',N'普通员工',5)
INSERT [sys_FieldValue] ([ValueID],[V_F_Key],[V_Text],[V_ShowOrder]) VALUES ( 16,N'Title',N'职业员工',3)
INSERT [sys_FieldValue] ([ValueID],[V_F_Key],[V_Text],[V_ShowOrder]) VALUES ( 17,N'Title',N'高级程序员',2)
INSERT [sys_FieldValue] ([ValueID],[V_F_Key],[V_Text],[V_ShowOrder]) VALUES ( 18,N'Title',N'试用期员工',4)
INSERT [sys_FieldValue] ([ValueID],[V_F_Key],[V_Text],[V_ShowOrder]) VALUES ( 19,N'Title',N'经理员工',1)

SET IDENTITY_INSERT [sys_FieldValue] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Group]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Group]

CREATE TABLE [sys_Group] (
[GroupID] [int]  IDENTITY (1, 1)  NOT NULL,
[G_CName] [nvarchar]  (50) NULL,
[G_ParentID] [int]  NOT NULL DEFAULT (0),
[G_ShowOrder] [int]  NOT NULL DEFAULT (0),
[G_Level] [int]  NULL,
[G_ChildCount] [int]  NULL,
[G_Delete] [tinyint]  NULL)

ALTER TABLE [sys_Group] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Group] PRIMARY KEY  NONCLUSTERED ( [GroupID] )
SET IDENTITY_INSERT [sys_Group] ON


SET IDENTITY_INSERT [sys_Group] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Module]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Module]

CREATE TABLE [sys_Module] (
[ModuleID] [int]  IDENTITY (1, 1)  NOT NULL,
[M_ApplicationID] [int]  NOT NULL,
[M_ParentID] [int]  NOT NULL,
[M_PageCode] [varchar]  (6) NOT NULL,
[M_CName] [nvarchar]  (50) NULL,
[M_Directory] [nvarchar]  (255) NULL,
[M_OrderLevel] [varchar]  (4) NULL,
[M_IsSystem] [tinyint]  NULL,
[M_Close] [tinyint]  NULL,
[M_Icon] [varchar]  (255) NULL)

ALTER TABLE [sys_Module] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Module] PRIMARY KEY  NONCLUSTERED ( [M_ApplicationID],[M_PageCode] )
SET IDENTITY_INSERT [sys_Module] ON

INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close]) VALUES ( 1,1,0,N'S00',N'系统应用',N'0000',1,0)
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 2,1,1,N'S00M00',N'应用列表管理',N'Module/FrameWork/SystemApp/AppManager/list.aspx',N'0001',1,0,N'~/manager/images/icon/applist.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 4,1,1,N'S00M01',N'部门资料管理',N'Module/FrameWork/SystemApp/GroupManager/Frame.aspx',N'0003',1,0,N'~/manager/images/icon/grouplist.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 5,1,1,N'S00M02',N'角色资料管理',N'Module/FrameWork/SystemApp/RoleManager/RoleList.aspx',N'0004',1,0,N'~/manager/images/icon/rule.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 6,1,1,N'S00M03',N'用户资料管理',N'Module/FrameWork/SystemApp/UserManager/default.aspx',N'0005',1,0,N'~/manager/images/icon/user.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 7,1,1,N'S00M04',N'应用字段设定',N'Module/FrameWork/SystemApp/FieldManager/default.aspx',N'0006',1,0,N'~/manager/images/icon/FieldManager.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 8,1,1,N'S00M05',N'事件日志管理',N'Module/FrameWork/SystemApp/EventManager/default.aspx',N'0007',1,0,N'~/manager/images/icon/log.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 9,1,1,N'S00M06',N'在线用户列表',N'Module/FrameWork/SystemApp/OnlineUserManager/default.aspx',N'0008',1,0,N'~/manager/images/icon/online.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 26,1,1,N'S00M07',N'应用模块管理',N'Module/FrameWork/SystemApp/ModuleManager/list.aspx',N'0002',1,0,N'~/manager/images/icon/module.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close]) VALUES ( 27,1,0,N'S01',N'系统维护',N'0100',1,0)
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 28,1,27,N'S01M00',N'系统运行状态',N'Module/FrameWork/SystemMaintenance/SystemState/default.aspx',N'0101',1,0,N'~/manager/images/icon/status.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 29,1,27,N'S01M01',N'系统出错日志',N'Module/FrameWork/SystemMaintenance/SystemErrorLog/default.aspx',N'0102',1,0,N'~/manager/images/icon/bug.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 30,1,27,N'S01M02',N'系统环境配置',N'Module/FrameWork/SystemMaintenance/SystemConfig/default.aspx',N'0103',1,0,N'~/manager/images/icon/config.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 31,2,0,N'S02',N'类别管理应用',N'0000',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 32,2,31,N'S02M01',N'经费类别',N'Module/ShanliTech/T_ClassDic/Default.aspx',N'0001',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 33,2,31,N'S02M02',N'科目类别',N'Module/ShanliTech/T_SubjectDic/Default.aspx',N'0002',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 34,2,31,N'S02M03',N'项目类别',N'Module/ShanliTech/T_ProjectDic/Default.aspx',N'0003',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 35,2,0,N'S03',N'经费管理应用',N'0200',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 37,2,35,N'S03M01',N'经费使用申请单',N'Module/ShanliTech/T_FundsRecord/Default.aspx',N'0203',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 44,2,35,N'S03M02',N'经费使用待审核单',N'Module/ShanliTech/T_FundsRecordShenHe/Default.aspx',N'0204',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 45,2,35,N'S03M03',N'经费使用待批准单',N'Module/ShanliTech/T_FundsRecordPiZhun/Default.aspx',N'0205',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 46,2,35,N'S03M04',N'经费使用待存档单',N'Module/ShanliTech/T_FundsRecordCunDang/Default.aspx',N'0206',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 47,2,35,N'S03M05',N'经费使用存档单列表',N'Module/ShanliTech/T_FundsRecordFinish/Default.aspx',N'0207',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 52,2,0,N'S04',N'项目预算应用',N'0100',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 36,2,52,N'S04M01',N'项目预算管理',N'Module/ShanliTech/T_ProjectBudget/Default.aspx',N'0201',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 38,2,52,N'S04M02',N'预算支出明细',N'Module/ShanliTech/T_BudgetDetail/Default.aspx',N'0202',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 53,2,0,N'S05',N'核销申请应用',N'0300',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 39,2,53,N'S05M01',N'核销申请单',N'Module/ShanliTech/T_VerificationRecord/Default.aspx',N'0208',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 48,2,53,N'S05M02',N'核销申请待审核单',N'Module/ShanliTech/T_VerificationRecordShenHe/Default.aspx',N'0209',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 49,2,53,N'S05M03',N'核销申请待批准单',N'Module/ShanliTech/T_VerificationRecordPiZhun/Default.aspx',N'0210',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 50,2,53,N'S05M04',N'核销申请待存档单',N'Module/ShanliTech/T_VerificationRecordCunDang/Default.aspx',N'0211',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 51,2,53,N'S05M05',N'核销申请存档单列表',N'Module/ShanliTech/T_VerificationRecordFinish/Default.aspx',N'0212',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 54,2,0,N'S06',N'仓库管理应用',N'0400',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 40,2,54,N'S06M01',N'入库表单',N'Module/ShanliTech/T_StorageRecord/Default.aspx',N'0201',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 41,2,54,N'S06M02',N'出库表单',N'Module/ShanliTech/T_OutboundRecord/Default.aspx',N'0204',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 42,2,54,N'S06M03',N'出入库日志',N'Module/ShanliTech/T_StockLog/Default.aspx',N'0207',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 43,2,54,N'S06M04',N'库存管理',N'Module/ShanliTech/T_Stock/Default.aspx',N'0208',0,0,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 55,2,54,N'S06M05',N'入库待批准表单',N'Module/ShanliTech/T_StorageRecordPiZhun/Default.aspx',N'0202',0,1,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 56,2,54,N'S06M06',N'入库存档表单',N'Module/ShanliTech/T_StorageRecordFinish/Default.aspx',N'0203',0,1,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 57,2,54,N'S06M07',N'出库待批准表单',N'Module/ShanliTech/T_OutboundRecordPiZhun/Default.aspx',N'0205',0,1,N'~/manager/images/icon/default.gif')
INSERT [sys_Module] ([ModuleID],[M_ApplicationID],[M_ParentID],[M_PageCode],[M_CName],[M_Directory],[M_OrderLevel],[M_IsSystem],[M_Close],[M_Icon]) VALUES ( 58,2,54,N'S06M08',N'出库存档表单',N'Module/ShanliTech/T_OutboundRecordFinish/Default.aspx',N'0206',0,1,N'~/manager/images/icon/default.gif')

SET IDENTITY_INSERT [sys_Module] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_ModuleExtPermission]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_ModuleExtPermission]

CREATE TABLE [sys_ModuleExtPermission] (
[ExtPermissionID] [int]  IDENTITY (1, 1)  NOT NULL,
[ModuleID] [int]  NOT NULL,
[PermissionName] [nvarchar]  (100) NOT NULL,
[PermissionValue] [int]  NOT NULL)

ALTER TABLE [sys_ModuleExtPermission] WITH NOCHECK ADD  CONSTRAINT [PK_sys_ModuleExtPermission] PRIMARY KEY  NONCLUSTERED ( [ModuleID],[PermissionValue] )
SET IDENTITY_INSERT [sys_ModuleExtPermission] ON


SET IDENTITY_INSERT [sys_ModuleExtPermission] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Online]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Online]

CREATE TABLE [sys_Online] (
[OnlineID] [int]  IDENTITY (1, 1)  NOT NULL,
[O_SessionID] [varchar]  (24) NOT NULL,
[O_UserName] [nvarchar]  (20) NOT NULL,
[O_Ip] [varchar]  (15) NOT NULL,
[O_LoginTime] [datetime]  NOT NULL,
[O_LastTime] [datetime]  NOT NULL,
[O_LastUrl] [nvarchar]  (500) NOT NULL)

ALTER TABLE [sys_Online] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Online] PRIMARY KEY  NONCLUSTERED ( [O_SessionID] )
SET IDENTITY_INSERT [sys_Online] ON

INSERT [sys_Online] ([OnlineID],[O_SessionID],[O_UserName],[O_Ip],[O_LoginTime],[O_LastTime],[O_LastUrl]) VALUES ( 65,N'eyzrs555zeyxk545wnimvhjo',N'admin',N'127.0.0.1',N'2014-8-19 16:56:06',N'2014-8-19 18:12:47',N'/Manager/Module/ShanliTech/T_Stock/Default.aspx')

SET IDENTITY_INSERT [sys_Online] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_RoleApplication]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_RoleApplication]

CREATE TABLE [sys_RoleApplication] (
[A_RoleID] [int]  NOT NULL,
[A_ApplicationID] [int]  NOT NULL)

ALTER TABLE [sys_RoleApplication] WITH NOCHECK ADD  CONSTRAINT [PK_sys_RoleApplication] PRIMARY KEY  NONCLUSTERED ( [A_RoleID],[A_ApplicationID] )
INSERT [sys_RoleApplication] ([A_RoleID],[A_ApplicationID]) VALUES ( 1,1)
if exists (select * from sysobjects where id = OBJECT_ID('[sys_RolePermission]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_RolePermission]

CREATE TABLE [sys_RolePermission] (
[PermissionID] [int]  IDENTITY (1, 1)  NOT NULL,
[P_RoleID] [int]  NOT NULL,
[P_ApplicationID] [int]  NOT NULL,
[P_PageCode] [varchar]  (20) NOT NULL,
[P_Value] [int]  NULL)

ALTER TABLE [sys_RolePermission] WITH NOCHECK ADD  CONSTRAINT [PK_sys_RolePermission] PRIMARY KEY  NONCLUSTERED ( [P_RoleID],[P_ApplicationID],[P_PageCode] )
SET IDENTITY_INSERT [sys_RolePermission] ON


SET IDENTITY_INSERT [sys_RolePermission] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_Roles]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_Roles]

CREATE TABLE [sys_Roles] (
[RoleID] [int]  IDENTITY (1, 1)  NOT NULL,
[R_UserID] [int]  NOT NULL,
[R_RoleName] [nvarchar]  (50) NOT NULL,
[R_Description] [nvarchar]  (255) NULL)

ALTER TABLE [sys_Roles] WITH NOCHECK ADD  CONSTRAINT [PK_sys_Roles] PRIMARY KEY  NONCLUSTERED ( [RoleID] )
SET IDENTITY_INSERT [sys_Roles] ON

INSERT [sys_Roles] ([RoleID],[R_UserID],[R_RoleName],[R_Description]) VALUES ( 1,1,N'系统管理员',N'管理用户角色')
INSERT [sys_Roles] ([RoleID],[R_UserID],[R_RoleName],[R_Description]) VALUES ( 2,1,N'项目组长',N'项目预算时需要指定项目组长。')
INSERT [sys_Roles] ([RoleID],[R_UserID],[R_RoleName],[R_Description]) VALUES ( 3,1,N'承办人',N'项目预算指定承办人')

SET IDENTITY_INSERT [sys_Roles] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_SystemInfo]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_SystemInfo]

CREATE TABLE [sys_SystemInfo] (
[SystemID] [int]  IDENTITY (1, 1)  NOT NULL,
[S_Name] [nvarchar]  (50) NULL,
[S_Version] [nvarchar]  (50) NULL,
[S_SystemConfigData] [image]  NULL,
[S_Licensed] [varchar]  (50) NULL)

ALTER TABLE [sys_SystemInfo] WITH NOCHECK ADD  CONSTRAINT [PK_sys_SystemInfo] PRIMARY KEY  NONCLUSTERED ( [SystemID] )
SET IDENTITY_INSERT [sys_SystemInfo] ON

INSERT [sys_SystemInfo] ([SystemID],[S_Name],[S_Version],[S_SystemConfigData]) VALUES ( 1,N'ASP.NET权限管理系统(FrameWork)',N'1.0.8',System.Byte[])

SET IDENTITY_INSERT [sys_SystemInfo] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_User]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_User]

CREATE TABLE [sys_User] (
[UserID] [int]  IDENTITY (1, 1)  NOT NULL,
[U_LoginName] [nvarchar]  (20) NOT NULL,
[U_Password] [varchar]  (32) NOT NULL,
[U_CName] [nvarchar]  (20) NULL,
[U_EName] [varchar]  (50) NULL,
[U_GroupID] [int]  NOT NULL,
[U_Email] [varchar]  (100) NULL,
[U_Type] [tinyint]  NOT NULL DEFAULT (1),
[U_Status] [tinyint]  NOT NULL DEFAULT (1),
[U_Licence] [varchar]  (30) NULL,
[U_Mac] [varchar]  (50) NULL,
[U_Remark] [nvarchar]  (200) NULL,
[U_IDCard] [varchar]  (30) NULL,
[U_Sex] [tinyint]  NULL,
[U_BirthDay] [datetime]  NULL,
[U_MobileNo] [varchar]  (15) NULL,
[U_UserNO] [varchar]  (20) NULL,
[U_WorkStartDate] [datetime]  NULL,
[U_WorkEndDate] [datetime]  NULL,
[U_CompanyMail] [varchar]  (255) NULL,
[U_Title] [int]  NULL,
[U_Extension] [varchar]  (10) NULL,
[U_HomeTel] [varchar]  (20) NULL,
[U_PhotoUrl] [nvarchar]  (255) NULL,
[U_DateTime] [datetime]  NULL,
[U_LastIP] [varchar]  (15) NULL,
[U_LastDateTime] [datetime]  NULL,
[U_ExtendField] [ntext]  NULL,
[SignPicture] [varchar]  (200) NULL,
[SignPassword] [varchar]  (50) NULL)

ALTER TABLE [sys_User] WITH NOCHECK ADD  CONSTRAINT [PK_sys_User] PRIMARY KEY  NONCLUSTERED ( [UserID] )
SET IDENTITY_INSERT [sys_User] ON

INSERT [sys_User] ([UserID],[U_LoginName],[U_Password],[U_CName],[U_GroupID],[U_Type],[U_Status],[U_Sex],[U_BirthDay],[U_WorkStartDate],[U_WorkEndDate],[U_Title],[U_DateTime],[U_LastIP],[U_LastDateTime],[U_ExtendField]) VALUES ( 1,N'admin',N'C4CA4238A0B923820DCC509A6F75849B',N'管理员',0,0,0,0,N'2007-6-23 0:00:00',N'2007-6-23 0:00:00',N'2007-6-23 15:32:19',17,N'2007-6-23 15:32:19',N'127.0.0.1',N'2014-8-19 6:12:47',N'1,10')
INSERT [sys_User] ([UserID],[U_LoginName],[U_Password],[U_GroupID],[U_Type],[U_Status],[U_Sex],[U_Title],[U_DateTime],[U_LastIP],[U_LastDateTime],[SignPassword]) VALUES ( 2,N'test1',N'C4CA4238A0B923820DCC509A6F75849B',0,1,0,0,0,N'2014-7-30 10:55:35',N'127.0.0.1',N'2014-7-30 10:56:08',N'C4CA4238A0B923820DCC509A6F75849B')
INSERT [sys_User] ([UserID],[U_LoginName],[U_Password],[U_GroupID],[U_Type],[U_Status],[U_Sex],[U_Title],[U_DateTime],[U_LastIP],[U_LastDateTime],[SignPassword]) VALUES ( 3,N'test2',N'C4CA4238A0B923820DCC509A6F75849B',0,1,0,0,0,N'2014-7-30 10:55:50',N'127.0.0.1',N'2014-7-30 10:55:50',N'C4CA4238A0B923820DCC509A6F75849B')

SET IDENTITY_INSERT [sys_User] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[sys_UserRoles]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [sys_UserRoles]

CREATE TABLE [sys_UserRoles] (
[R_UserID] [int]  NOT NULL,
[R_RoleID] [int]  NOT NULL)

ALTER TABLE [sys_UserRoles] WITH NOCHECK ADD  CONSTRAINT [PK_sys_UserRoles] PRIMARY KEY  NONCLUSTERED ( [R_UserID],[R_RoleID] )
INSERT [sys_UserRoles] ([R_UserID],[R_RoleID]) VALUES ( 2,1)
INSERT [sys_UserRoles] ([R_UserID],[R_RoleID]) VALUES ( 2,2)
INSERT [sys_UserRoles] ([R_UserID],[R_RoleID]) VALUES ( 3,1)
INSERT [sys_UserRoles] ([R_UserID],[R_RoleID]) VALUES ( 3,3)
if exists (select * from sysobjects where id = OBJECT_ID('[T_BudgetDetail]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_BudgetDetail]

CREATE TABLE [T_BudgetDetail] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ProjID] [int]  NULL,
[EquipmentName] [nvarchar]  (50) NULL,
[BudgetRevenue] [float]  NULL,
[Measurement] [nvarchar]  (50) NULL,
[BudgetPrice] [float]  NULL,
[BudgetNumber] [int]  NULL,
[BudgetExpenditure] [float]  NULL,
[BalanceAmount] [float]  NULL,
[Supplier] [nvarchar]  (50) NULL,
[Remark] [nvarchar]  (50) NULL,
[Sort] [int]  NULL)

ALTER TABLE [T_BudgetDetail] WITH NOCHECK ADD  CONSTRAINT [PK_T_BudgetDetail] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_BudgetDetail] ON

INSERT [T_BudgetDetail] ([ID],[ProjID],[EquipmentName],[BudgetRevenue],[Measurement],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Supplier],[Remark],[Sort]) VALUES ( 1,3,N'器材名称',210,N'个',12,52,54,77,N'石家庄',N'善理科技',0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[EquipmentName],[BudgetRevenue],[Measurement],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Supplier],[Remark],[Sort]) VALUES ( 2,1,N'电饭锅',0,N'个',0,0,0,0,N'山东',N'山东',0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[BudgetRevenue],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Sort]) VALUES ( 3,1,0,0,0,0,0,0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[BudgetRevenue],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Sort]) VALUES ( 4,4,0,0,0,0,0,0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[BudgetRevenue],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Sort]) VALUES ( 5,4,0,0,0,0,0,0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[BudgetRevenue],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Sort]) VALUES ( 6,6,0,0,0,0,0,0)
INSERT [T_BudgetDetail] ([ID],[ProjID],[EquipmentName],[BudgetRevenue],[Measurement],[BudgetPrice],[BudgetNumber],[BudgetExpenditure],[BalanceAmount],[Supplier],[Remark],[Sort]) VALUES ( 7,7,N'检查器材',0,N'个',12,5,60,34,N'石家庄电信',N'必须买',0)

SET IDENTITY_INSERT [T_BudgetDetail] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_ClassDic]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_ClassDic]

CREATE TABLE [T_ClassDic] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ClassNO] [varchar]  (50) NOT NULL,
[ClassName] [nvarchar]  (50) NULL,
[ParentClassNO] [varchar]  (50) NULL,
[State] [int]  NULL,
[CreateTime] [datetime]  NULL,
[UpdateTime] [datetime]  NULL,
[Sort] [int]  NULL)

ALTER TABLE [T_ClassDic] WITH NOCHECK ADD  CONSTRAINT [PK_T_ClassDic] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_ClassDic] ON

INSERT [T_ClassDic] ([ID],[ClassNO],[ClassName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 1,N'类别编号2',N'后勤经费',0,N'2014-7-29 16:45:44',N'2014-7-30 10:44:03',0)
INSERT [T_ClassDic] ([ID],[ClassNO],[ClassName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 2,N'类别编号',N'装备经费',0,N'2014-7-29 16:46:04',N'2014-8-6 11:11:44',0)
INSERT [T_ClassDic] ([ID],[ClassName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 3,N'科研经费',9,N'2014-7-29 17:15:07',N'2014-7-29 17:15:07',0)
INSERT [T_ClassDic] ([ID],[ClassNO],[ClassName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 4,N'JIANCHABIANHAO',N'检查类别名称',0,N'2014-8-7 9:24:51',N'2014-8-7 9:24:51',0)

SET IDENTITY_INSERT [T_ClassDic] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_FundsRecord]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_FundsRecord]

CREATE TABLE [T_FundsRecord] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ProjID] [int]  NULL,
[BalanceAmount] [float]  NULL,
[UseRemark] [nvarchar]  (50) NULL,
[AdvanceAmount] [float]  NULL,
[Applicant] [int]  NULL,
[Checker] [int]  NULL,
[Approver] [int]  NULL,
[TransferState] [int]  NULL,
[State] [int]  NULL,
[AppricationTime] [datetime]  NULL,
[CheckTime] [datetime]  NULL,
[ApprovalTime] [datetime]  NULL,
[IntegrityCheckCode] [varchar]  (50) NULL,
[ShenHeState] [nvarchar]  (500) NULL,
[PiZhunState] [nvarchar]  (500) NULL,
[CunDangState] [nvarchar]  (500) NULL,
[note] [nvarchar]  (500) NULL)

ALTER TABLE [T_FundsRecord] WITH NOCHECK ADD  CONSTRAINT [PK_T_FundsRecord] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_FundsRecord] ON

INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime]) VALUES ( 1,3,0,N'dt',0,1,1,1,2,0,N'2014-8-1 10:46:08',N'2014-8-1 11:52:59',N'2014-8-6 15:31:41')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime]) VALUES ( 2,2,12,N'一在啥地方',55,1,1,1,2,0,N'2014-8-1 10:45:55',N'2014-8-1 11:52:19',N'2014-8-6 15:17:38')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime],[PiZhunState]) VALUES ( 3,3,0,N'的',0,1,1,1,3,0,N'2014-8-1 15:19:54',N'2014-8-1 15:22:09',N'2014-8-14 18:12:45',N'dsf')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime]) VALUES ( 4,2,12,N'的',0,1,1,1,2,1,N'2014-8-1 15:23:17',N'2014-8-1 15:28:46',N'2014-8-6 15:56:59')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime]) VALUES ( 5,1,12,N'水电费',0,1,1,1,0,0,N'2014-8-1 15:23:25',N'2014-8-1 15:31:18',N'2014-8-6 15:45:29')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ShenHeState]) VALUES ( 6,3,0,N'水电费',0,1,1,0,1,0,N'2014-8-1 15:31:30',N'2014-8-14 17:50:08',N'sf')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime],[PiZhunState]) VALUES ( 7,2,12,N'买钢笔',2,1,1,1,3,1,N'2014-8-6 15:32:19',N'2014-8-6 15:34:52',N'2014-8-14 18:12:53',N'sdf')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime],[ShenHeState]) VALUES ( 8,2,12,N'才',0,1,1,1,0,0,N'2014-8-6 14:59:47',N'2014-8-14 16:15:06',N'2014-8-6 15:35:36',N'd')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime]) VALUES ( 9,1,12,0,1,1,0,1,9,N'2014-8-6 14:56:58',N'2014-8-6 15:02:29')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[UseRemark],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ShenHeState]) VALUES ( 10,7,60,N'买检查器材',10,1,1,0,0,0,N'2014-8-14 14:49:46',N'2014-8-14 17:22:45',N'dxfdf')
INSERT [T_FundsRecord] ([ID],[ProjID],[BalanceAmount],[AdvanceAmount],[Applicant],[Checker],[Approver],[TransferState],[State],[AppricationTime],[CheckTime],[ApprovalTime],[ShenHeState],[PiZhunState],[CunDangState]) VALUES ( 11,7,60,4,1,1,1,1,1,N'2014-8-14 15:35:23',N'2014-8-14 16:04:08',N'2014-8-14 18:08:31',N'sd',N'sdf',N'dfg')

SET IDENTITY_INSERT [T_FundsRecord] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_OutboundRecord]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_OutboundRecord]

CREATE TABLE [T_OutboundRecord] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ProjectNO] [varchar]  (50) NULL,
[EquipmentName] [nvarchar]  (50) NULL,
[Model] [varchar]  (50) NULL,
[OutboundNumber] [int]  NULL,
[BalanceNumber] [int]  NULL,
[OutboundTime] [datetime]  NULL,
[Applicant] [int]  NULL,
[Approver] [int]  NULL,
[IntegrityCheckCode] [varchar]  (50) NULL,
[Remark] [nvarchar]  (50) NULL,
[CodeNO] [varchar]  (50) NULL)

ALTER TABLE [T_OutboundRecord] WITH NOCHECK ADD  CONSTRAINT [PK_T_OutboundRecord] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_OutboundRecord] ON

INSERT [T_OutboundRecord] ([ID],[ProjectNO],[EquipmentName],[Model],[OutboundNumber],[BalanceNumber],[OutboundTime],[Applicant],[Approver],[Remark],[CodeNO]) VALUES ( 1,N'2',N'5',N'74',0,0,N'2014-8-19 18:03:14',3,2,N'5',N'7')
INSERT [T_OutboundRecord] ([ID],[ProjectNO],[EquipmentName],[Model],[OutboundNumber],[BalanceNumber],[OutboundTime],[Applicant],[Approver],[Remark],[CodeNO]) VALUES ( 2,N'2',N'山东',N'山东',0,0,N'2014-8-19 18:06:01',3,3,N'山东山东',N'山东')
INSERT [T_OutboundRecord] ([ID],[ProjectNO],[OutboundNumber],[BalanceNumber],[OutboundTime],[Applicant],[Approver]) VALUES ( 3,N'4',3,3,N'2014-8-19 18:03:40',0,0)
INSERT [T_OutboundRecord] ([ID],[ProjectNO],[OutboundNumber],[BalanceNumber],[OutboundTime],[Applicant],[Approver]) VALUES ( 4,N'2',0,0,N'2014-8-19 18:03:48',0,0)
INSERT [T_OutboundRecord] ([ID],[ProjectNO],[OutboundNumber],[BalanceNumber],[OutboundTime],[Applicant],[Approver]) VALUES ( 5,N'4',0,0,N'2014-8-19 18:05:56',0,0)

SET IDENTITY_INSERT [T_OutboundRecord] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_ProjectBudget]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_ProjectBudget]

CREATE TABLE [T_ProjectBudget] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ProjectNO] [varchar]  (50) NULL,
[SubjectNO] [varchar]  (50) NULL,
[ClassNO] [varchar]  (50) NULL,
[AnnualNO] [varchar]  (50) NULL,
[BudgetRevenue] [float]  NULL,
[BudgetExpenditure] [float]  NULL,
[BalanceAmount] [float]  NULL,
[Leader] [int]  NULL,
[Undertaker] [int]  NULL,
[State] [int]  NULL,
[CreateTime] [datetime]  NULL,
[UpdateTime] [datetime]  NULL,
[Sort] [int]  NULL,
[DepartmentID] [int]  NULL)

ALTER TABLE [T_ProjectBudget] WITH NOCHECK ADD  CONSTRAINT [PK_T_ProjectBudget] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_ProjectBudget] ON

INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[AnnualNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 1,N'2',N'2',N'1',N'20130402',12,22,12,1,1,0,N'2014-7-30 14:55:27',N'2014-7-30 15:28:17',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[AnnualNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 2,N'2',N'2',N'2',N'20130405',1,1,12,3,3,0,N'2014-7-30 15:32:34',N'2014-7-30 15:33:26',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[AnnualNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 3,N'1',N'1',N'1',N'的',232,0,0,2,3,0,N'2014-7-30 15:33:42',N'2014-8-6 11:12:26',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 4,N'1',N'1',N'1',0,0,0,0,0,0,N'2014-8-6 11:32:49',N'2014-8-6 11:32:49',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 5,N'1',N'1',N'2',0,0,0,3,3,0,N'2014-8-6 11:50:57',N'2014-8-6 14:21:03',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 6,N'2',N'1',N'1',0,0,-1222,3,2,0,N'2014-8-6 11:51:26',N'2014-8-6 11:51:26',0,0)
INSERT [T_ProjectBudget] ([ID],[ProjectNO],[SubjectNO],[ClassNO],[AnnualNO],[BudgetRevenue],[BudgetExpenditure],[BalanceAmount],[Leader],[Undertaker],[State],[CreateTime],[UpdateTime],[Sort],[DepartmentID]) VALUES ( 7,N'4',N'4',N'4',N'20140807',60,60,60,2,3,0,N'2014-8-7 9:31:02',N'2014-8-11 18:13:33',0,0)

SET IDENTITY_INSERT [T_ProjectBudget] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_ProjectDic]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_ProjectDic]

CREATE TABLE [T_ProjectDic] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[ProjectNO] [varchar]  (50) NOT NULL,
[ProjectName] [nvarchar]  (50) NULL,
[SubjectNO] [varchar]  (50) NULL,
[ClassNO] [varchar]  (50) NULL,
[State] [int]  NULL,
[CreateTime] [datetime]  NULL,
[UpdateTime] [datetime]  NULL)

ALTER TABLE [T_ProjectDic] WITH NOCHECK ADD  CONSTRAINT [PK_T_ProjectDic] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_ProjectDic] ON

INSERT [T_ProjectDic] ([ID],[ProjectNO],[ProjectName],[State],[CreateTime],[UpdateTime]) VALUES ( 1,N'项目编号1',N'项目名称1',0,N'2014-7-29 18:16:07',N'2014-7-29 18:16:07')
INSERT [T_ProjectDic] ([ID],[ProjectNO],[ProjectName],[State],[CreateTime],[UpdateTime]) VALUES ( 2,N'项目编号2',N'项目名称2',0,N'2014-7-29 18:16:39',N'2014-8-6 11:12:13')
INSERT [T_ProjectDic] ([ID],[ProjectNO],[ProjectName],[State],[CreateTime],[UpdateTime]) VALUES ( 3,N'项目编号3',N'项目名称3',9,N'2014-7-29 18:16:50',N'2014-7-29 18:16:50')
INSERT [T_ProjectDic] ([ID],[ProjectNO],[ProjectName],[State],[CreateTime],[UpdateTime]) VALUES ( 4,N'XIANGmUBIANHAO',N'项目检查名称',0,N'2014-8-7 9:25:32',N'2014-8-7 9:25:32')

SET IDENTITY_INSERT [T_ProjectDic] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_Stock]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_Stock]

CREATE TABLE [T_Stock] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[EquipmentName] [nvarchar]  (50) NULL,
[Model] [varchar]  (50) NULL,
[StockNumber] [int]  NULL,
[CodeNO] [varchar]  (50) NULL)

ALTER TABLE [T_Stock] WITH NOCHECK ADD  CONSTRAINT [PK_T_Stock] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_Stock] ON

INSERT [T_Stock] ([ID],[EquipmentName],[Model],[StockNumber],[CodeNO]) VALUES ( 1,N'地方',N'水电费',0,N'山东')
INSERT [T_Stock] ([ID],[StockNumber]) VALUES ( 2,4)

SET IDENTITY_INSERT [T_Stock] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_StockLog]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_StockLog]

CREATE TABLE [T_StockLog] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[CodeNO] [varchar]  (50) NULL,
[DealType] [int]  NULL,
[Number] [int]  NULL,
[Handler] [int]  NULL,
[StorID] [int]  NULL,
[OutbID] [int]  NULL,
[LogTime] [datetime]  NULL)

ALTER TABLE [T_StockLog] WITH NOCHECK ADD  CONSTRAINT [PK_T_StockLog] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_StockLog] ON

INSERT [T_StockLog] ([ID],[CodeNO],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 1,N'等等',1,2,1,3,0,N'2014-8-4 18:02:42')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 2,1,0,1,0,0,N'2014-8-4 18:03:18')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 3,1,0,1,5,0,N'2014-8-4 18:07:07')
INSERT [T_StockLog] ([ID],[CodeNO],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 4,N'山东',11,0,1,2,0,N'2014-8-5 11:53:15')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 5,1,0,1,6,0,N'2014-8-19 17:37:47')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 6,11,0,1,3,0,N'2014-8-19 17:44:44')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 7,1,0,1,7,0,N'2014-8-19 18:02:34')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 8,11,0,1,4,0,N'2014-8-19 18:03:48')
INSERT [T_StockLog] ([ID],[DealType],[Number],[Handler],[StorID],[OutbID],[LogTime]) VALUES ( 9,11,0,1,5,0,N'2014-8-19 18:05:56')

SET IDENTITY_INSERT [T_StockLog] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_StorageRecord]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_StorageRecord]

CREATE TABLE [T_StorageRecord] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[VeriID] [int]  NULL,
[ProjectNO] [varchar]  (50) NULL,
[EquipmentName] [nvarchar]  (50) NULL,
[Model] [varchar]  (50) NULL,
[StorageNumber] [int]  NULL,
[UnitPrice] [float]  NULL,
[StorageTime] [datetime]  NULL,
[Applicant] [int]  NULL,
[Approver] [int]  NULL,
[PayAmount] [float]  NULL,
[IntegrityCheckCode] [varchar]  (50) NULL,
[Remark] [nvarchar]  (50) NULL,
[CodeNO] [varchar]  (50) NULL)

ALTER TABLE [T_StorageRecord] WITH NOCHECK ADD  CONSTRAINT [PK_T_StorageRecord] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_StorageRecord] ON

INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount]) VALUES ( 1,2,N'2',0,0,N'2014-8-4 17:50:25',1,1,0)
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[EquipmentName],[Model],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount],[IntegrityCheckCode],[Remark],[CodeNO]) VALUES ( 2,2,N'2',N'钢笔',N'2',2,33,N'2014-8-4 17:50:17',1,1,0,N'的',N'的',N'的')
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[EquipmentName],[Model],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount],[Remark],[CodeNO]) VALUES ( 3,2,N'2',N'钢笔',N'2',2,2,N'2014-8-4 18:02:34',1,1,0,N'的',N'等等')
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount]) VALUES ( 4,2,N'2',0,0,N'2014-8-4 18:03:02',1,1,0)
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount]) VALUES ( 5,2,N'2',0,0,N'2014-8-4 18:07:07',1,1,0)
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount]) VALUES ( 6,4,N'1',0,0,N'2014-8-19 17:38:08',1,1,52)
INSERT [T_StorageRecord] ([ID],[VeriID],[ProjectNO],[StorageNumber],[UnitPrice],[StorageTime],[Applicant],[Approver],[PayAmount]) VALUES ( 7,4,N'1',0,0,N'2014-8-19 18:02:34',1,1,52)

SET IDENTITY_INSERT [T_StorageRecord] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_SubjectDic]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_SubjectDic]

CREATE TABLE [T_SubjectDic] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[SubjectNO] [varchar]  (50) NOT NULL,
[SubjectName] [nvarchar]  (50) NULL,
[ClassNO] [varchar]  (50) NULL,
[State] [int]  NULL,
[CreateTime] [datetime]  NULL,
[UpdateTime] [datetime]  NULL,
[Sort] [int]  NULL)

ALTER TABLE [T_SubjectDic] WITH NOCHECK ADD  CONSTRAINT [PK_T_SubjectDic] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_SubjectDic] ON

INSERT [T_SubjectDic] ([ID],[SubjectNO],[SubjectName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 1,N'科目编号1',N'科目名称1',0,N'2014-7-29 17:55:27',N'2014-7-29 17:55:27',0)
INSERT [T_SubjectDic] ([ID],[SubjectNO],[SubjectName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 2,N'科目编号2',N'科目名称2',0,N'2014-7-29 18:01:06',N'2014-8-6 11:12:03',0)
INSERT [T_SubjectDic] ([ID],[SubjectNO],[SubjectName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 3,N'科目编号3',N'科目名称3',9,N'2014-7-29 18:01:17',N'2014-7-29 18:01:17',0)
INSERT [T_SubjectDic] ([ID],[SubjectNO],[SubjectName],[State],[CreateTime],[UpdateTime],[Sort]) VALUES ( 4,N'KEMUJIANCHA',N'科目检查名称',0,N'2014-8-7 9:25:13',N'2014-8-7 9:25:13',0)

SET IDENTITY_INSERT [T_SubjectDic] OFF
if exists (select * from sysobjects where id = OBJECT_ID('[T_VerificationRecord]') and OBJECTPROPERTY(id, 'IsUserTable') = 1) 
DROP TABLE [T_VerificationRecord]

CREATE TABLE [T_VerificationRecord] (
[ID] [int]  IDENTITY (1, 1)  NOT NULL,
[FundID] [int]  NULL,
[ProjID] [int]  NULL,
[InvoiceFolder] [varchar]  (100) NULL,
[ContractFolder] [varchar]  (100) NULL,
[Undertaker] [int]  NULL,
[Checker] [int]  NULL,
[Approver] [bigint]  NULL,
[TransferState] [int]  NULL,
[State] [int]  NULL,
[CreateTime] [datetime]  NULL,
[CheckTime] [datetime]  NULL,
[ApprovalTime] [datetime]  NULL,
[PayAmount] [float]  NULL,
[IntegrityCheckCode] [varchar]  (50) NULL,
[ShenHeNote] [nvarchar]  (500) NULL,
[PiZhunNote] [nvarchar]  (500) NULL,
[CunDangNote] [nvarchar]  (500) NULL)

ALTER TABLE [T_VerificationRecord] WITH NOCHECK ADD  CONSTRAINT [PK_T_VerificationRecord] PRIMARY KEY  NONCLUSTERED ( [ID] )
SET IDENTITY_INSERT [T_VerificationRecord] ON

INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[CheckTime],[ApprovalTime],[PayAmount]) VALUES ( 1,1,2,N'/Down/20140803120554/Koala.jpg',N'/Down/20140803120554/Penguins.jpg',1,1,1,2,9,N'2014-8-3 15:04:09',N'2014-8-4 17:47:29',N'2014-8-6 17:35:33',2)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[PayAmount]) VALUES ( 2,2,2,N'/Down/20140803120533/Desert.jpg',N'/Down/20140803120533/Koala.jpg',1,1,1,2,9,N'2014-8-3 15:04:05',0)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[ApprovalTime],[PayAmount],[ShenHeNote],[PiZhunNote]) VALUES ( 3,3,1,N'/Down/20140802180358/ea38a892bee4cae05707cd127e4d8',1,1,1,3,1,N'2014-8-3 15:04:01',N'2014-8-15 16:31:25',0,N'sdf',N'55')
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[PayAmount]) VALUES ( 4,3,1,N'/Down/20140803120251/Penguins.jpg',N'/Down/20140803120027/Tulips.jpg',1,1,1,2,1,N'2014-8-3 15:03:54',52)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[CheckTime],[PayAmount]) VALUES ( 5,1,2,N'/Down/2014080616/jiaonan.jpg',N'/Down/20140806162243/huangdao.jpg',1,1,0,0,0,N'2014-8-19 16:57:31',N'2014-8-6 17:12:34',0)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[PayAmount]) VALUES ( 6,5,1,1,0,0,0,9,N'2014-8-6 16:14:03',0)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[CheckTime],[ApprovalTime],[PayAmount],[PiZhunNote]) VALUES ( 8,3,1,N'/Down/2014080617/ea38a892bee4cae05707cd127e4d8ec8.png',N'/Down/20140806171248/ea38a892bee4cae05707cd127e4d8ec8.png',1,1,1,1,0,N'2014-8-6 17:12:48',N'2014-8-15 17:47:42',N'2014-8-15 16:28:40',0,N'sdf')
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[InvoiceFolder],[ContractFolder],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[CheckTime],[ApprovalTime],[PayAmount]) VALUES ( 9,4,1,N'/Down/2014081517/jiaonan.jpg',N'/Down/20140815173024/zlm.gif',1,1,1,3,0,N'2014-8-15 17:48:13',N'2014-8-19 16:58:06',N'2014-8-19 16:58:16',34)
INSERT [T_VerificationRecord] ([ID],[FundID],[ProjID],[Undertaker],[Checker],[Approver],[TransferState],[State],[CreateTime],[PayAmount]) VALUES ( 10,0,0,1,0,0,0,0,N'2014-8-19 17:53:08',0)

SET IDENTITY_INSERT [T_VerificationRecord] OFF
