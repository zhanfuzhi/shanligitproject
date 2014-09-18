using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shanlitech_Location.Components;
using FrameWork;
using FrameWork.Components;
using System.Data;
using System.Data.SqlClient;
using Shanlitech_Location.Data;
using System.Configuration;
using ShanliTech.LogLib;
using System.Collections;

namespace Shanlitech_Location
{
    public partial class BusinessFacadeShanlitech_Location
    {

        public static DataSet ExecuteDataset(string sql)
        {
            DataSet ds = new DataSet();
            string connStr = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["DBType"].ToString()].ToString();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlDataAdapter cmd = new SqlDataAdapter(sql, con);
                cmd.Fill(ds);
                con.Close();
                return ds;
            }
        }
        

        /// <summary>
        /// 获取经费类别列表
        /// </summary>
        /// <returns></returns>
        public static List<T_ClassDicEntity> GetClassList()
        {
            List<T_ClassDicEntity> classlist = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where state={0}", (int)Status.Normal);
                int record = 0;
                classlist = BusinessFacadeShanlitech_Location.T_ClassDicList(qp, out record);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetClassList方法抛出异常：" + ex);
            }
            return classlist;
        }

        /// <summary>
        /// 获取科目类别列表
        /// </summary>
        /// <returns></returns>
        public static List<T_SubjectDicEntity> GetSubjectList()
        {
            List<T_SubjectDicEntity> subjectlist = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where state={0}", (int)Status.Normal);
                int record = 0;
                subjectlist = BusinessFacadeShanlitech_Location.T_SubjectDicList(qp, out record);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetSubjectList方法抛出异常：" + ex);
            }
            return subjectlist;
        }

        
        /// <summary>
        /// 获取项目类别列表
        /// </summary>
        /// <returns></returns>
        public static List<T_ProjectDicEntity> GetProjectList()
        {
            List<T_ProjectDicEntity> projectlist = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where =string.Format( "where state={0}",(int)Status.Normal);
                int record = 0;
                projectlist = BusinessFacadeShanlitech_Location.T_ProjectDicList(qp, out record);
            }
            catch (Exception ex )
            {
                AppLogger.Instance.Log.Error("GetProjectList方法抛出异常：" + ex);
            }
            return projectlist;         
        }

        /// <summary>
        /// 根据角色获取用户列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetUserListByRole(int role)
        {
            ArrayList lst = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where UserID in (select R_UserID from dbo.sys_UserRoles where R_RoleID ={0})",role);
                int Record = 0;
                lst = BusinessFacade.sys_UserList(qp, out Record);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetUserListByRole抛出异常:" + ex);
            }

            return lst;
        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        public static ArrayList GetUserList()
        {
            ArrayList lst = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = "where 1=1";
                int Record = 0;
                lst = BusinessFacade.sys_UserList(qp, out Record);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetUserList抛出异常:" + ex);
            }
         
            return lst;
        }

        /// <summary>
        /// 根据id获取经费类别名称
        /// </summary>
        /// <param name="classid">经费类别id</param>
        /// <returns>经费类别名称</returns>
        public static string  GetClassNameByID(int classid)
        {
            string classname = string.Empty;
            try
            {
                T_ClassDicEntity classentity = BusinessFacadeShanlitech_Location.T_ClassDicDisp(classid);
                if (classentity != null)
                {
                    classname = classentity.ClassName;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetClassNameByID抛出异常:" + ex);
            }
            return classname;
        }


       /// <summary>
       /// 根据subjectid获取预算科目名称
       /// </summary>
       /// <param name="subjectid">预算科目id</param>
       /// <returns>返回预算科目名称</returns>
        public static string GetSubjectNameByID(int subjectid)
        {
            string subjectname = string.Empty;
            try
            {
                T_SubjectDicEntity subjectitem = BusinessFacadeShanlitech_Location.T_SubjectDicDisp(subjectid);
                if (subjectitem != null)
                {
                    subjectname = subjectitem.SubjectName;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetSubjectNameByID抛出异常:" + ex);
            }
            return subjectname;
        }


        /// <summary>
        /// 根据projectid获取预算项目名称
        /// </summary>
        /// <param name="projectid">预算项目id</param>
        /// <returns>返回预算项目名称</returns>
        public static string GetProjectNameByID(int projectid)
        {
            string projectname = string.Empty;
            try
            {
                T_ProjectDicEntity projectitem = BusinessFacadeShanlitech_Location.T_ProjectDicDisp(projectid);
                if (projectitem != null)
                {
                    projectname = projectitem.ProjectName;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetProjectNameByID抛出异常:" + ex);
            }
            return projectname;
        }


        /// <summary>
        /// 根据userid获取用户名称
        /// </summary>
        /// <param name="userid">用户id</param>
        /// <returns>返回用户名称</returns>
        public static string GetUserNameByID(int userid)
        {
            string username = string.Empty;
            try
            {
                sys_UserTable sys_user = BusinessFacade.sys_UserDisp(userid);
                if (sys_user != null)
                {
                    username = sys_user.U_LoginName;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetUserNameByID方法跑出异常：" + ex);
            }
            return username;
        }

        /// <summary>
        /// 获得预算项目列表
        /// </summary>
        /// <returns></returns>
        public static List<T_ProjectBudgetEntity> GetProjectBudList()
        {
            List<T_ProjectBudgetEntity> projectbudlist = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where state={0}", (int)Status.Normal);
                int record = 0;
                projectbudlist = BusinessFacadeShanlitech_Location.T_ProjectBudgetList(qp, out record);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetProjectBudList抛出异常" + ex);
            }
            return projectbudlist;
        }
        /// <summary>
        /// 根据id获取年度编号
        /// </summary>
        /// <param name="projectbudid">项目预算id</param>
        /// <returns>项目语速年度编号</returns>
        public static string GetAnnualNOByID(int projectbudid)
        {
            string AnnualNo = string.Empty;
            try
            {
                T_ProjectBudgetEntity projectbud = BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp(projectbudid);
                if (projectbud != null)
                {
                    AnnualNo = projectbud.AnnualNO;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetAnnualNOByID抛出异常:" + ex);
            }
            return AnnualNo;
        }

        /// <summary>
        /// 获得项目显示格式
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string GetProjectBudgetFormat(T_ProjectBudgetEntity entity)
        {
            string projectformat = string.Empty;
            if (entity == null) { return projectformat; }
            try
            {
                projectformat = string.Format("{0},{1},{2},{3}", BusinessFacadeShanlitech_Location.GetClassNameByID(Convert.ToInt32(entity.ClassNO)),
                    BusinessFacadeShanlitech_Location.GetSubjectNameByID(Convert.ToInt32(entity.SubjectNO)),
                    BusinessFacadeShanlitech_Location.GetProjectNameByID(Convert.ToInt32(entity.ProjectNO)),
                    entity.AnnualNO);
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetProjectBudgetFormat抛出异常：" + ex);
            }
            return projectformat;
        }

        /// <summary>
        /// 根据状态返回状态名称
        /// </summary>
        /// <param name="state">状态</param>
        /// <returns>返回状态名称解释</returns>
        public static string GetTransferStateNameByState(int state)
        {
            switch (state)
            {
                case (int)TransferState.ShenQing:
                    return "申请状态";
                case (int)TransferState.ShenHe:
                    return "待审核状态";
                case (int)TransferState.PiZhun:
                    return "待批准状态";
                case (int)TransferState.CunDang:
                    return "待存档状态";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 通过类别名称获取ID
        /// </summary>
        /// <returns></returns>
        public static int GetIDByClassName(string name)
        {
            int id=0;
           List<T_ClassDicEntity> Entity = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where ClassName='{0}'", name);
                int record = 0;
                Entity = BusinessFacadeShanlitech_Location.T_ClassDicList(qp, out record);
                id = Entity[0].ID;
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetIDByClassName抛出异常" + ex);
            }
            return id;
        }

        /// <summary>
        /// 通过科目名称获取ID
        /// </summary>
        /// <returns></returns>
        public static int GetIDBySubjectName(string name)
        {
            int id = 0;
            List<T_SubjectDicEntity> Entity = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where SubjectName='{0}'", name);
                int record = 0;
                Entity = BusinessFacadeShanlitech_Location.T_SubjectDicList(qp, out record);
                id = Entity[0].ID;
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetIDBySubjectName抛出异常" + ex);
            }
            return id;
        }
        /// <summary>
        /// 通过项目名称获取ID
        /// </summary>
        /// <returns></returns>
        public static int GetIDByProjectName(string name)
        {
            int id = 0;
            List<T_ProjectDicEntity> Entity = null;
            try
            {
                QueryParam qp = new QueryParam();
                qp.Where = string.Format("where ProjectName='{0}'", name);
                int record = 0;
                Entity = BusinessFacadeShanlitech_Location.T_ProjectDicList(qp, out record);
                id = Entity[0].ID;
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetIDByProjectName抛出异常" + ex);
            }
            return id;
        }


        /// <summary>
        /// 根据库存id获取库存编码号
        /// </summary>
        /// <param name="projectid">库存id</param>
        /// <returns>库存编码号</returns>
        public static string GetCodeByStockid(string stockid)
        {
           
            string codeno = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(stockid))
                {
                    return null;
                }

                T_StockEntity entity = BusinessFacadeShanlitech_Location.T_StockDisp(Convert.ToInt32(stockid));
                if (entity != null)
                {
                    codeno = entity.CodeNO;
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("GetCodeByStockid抛出异常:" + ex);
            }
            return codeno;
        }

    }
}
