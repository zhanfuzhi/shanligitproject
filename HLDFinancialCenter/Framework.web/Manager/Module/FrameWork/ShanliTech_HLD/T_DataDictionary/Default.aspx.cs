/********************************************************************************
     File:																
            Default.aspx.cs                         
     Description:
            数据字典列表
     Author:									
            DDBuildTools
            http://FrameWork.supesoft.com
     Finish DateTime:
            2010-6-1 18:01:11
     History:
*********************************************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;
using ShanliTech_HLD_Business.Components;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary
{
    public partial class Default : System.Web.UI.Page
    {
        int DictionaryID; 
        protected void Page_Load(object sender, EventArgs e)
        { 
            DictionaryID = (int)Common.sink("ID", MethodType.Get, 255, 0, DataType.Int);



            if (!Page.IsPostBack)
            {
                OnStart();
                ButtonBind();
            }
        }

        private void ButtonBind()
        {
            try
            {

                int parent = 0;
                if (DictionaryID != 0)
                { 
                    T_DataDictionaryEntity dataDictionary = new T_DataDictionaryEntity();
                    dataDictionary = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(DictionaryID);
                    parent = dataDictionary.parent;
                }
                if (parent == 0)
                {
                    HeadMenuButtonItem bi0 = new HeadMenuButtonItem();
                    bi0.ButtonPopedom = PopedomType.New;
                    bi0.ButtonName = "字典";
                    bi0.ButtonUrl = string.Format("Manager.aspx?CMD=New&IDX={0}", DictionaryID);
                    HeadMenuWebControls1.ButtonList.Add(bi0);
                }

                if (DictionaryID != 0)
                {
                    HeadMenuButtonItem bi2 = new HeadMenuButtonItem();
                    bi2.ButtonPopedom = PopedomType.Edit;
                    bi2.ButtonName = "字典";
                    bi2.ButtonUrl = string.Format("Manager.aspx?CMD=Edit&IDX={0}", DictionaryID);
                    HeadMenuWebControls1.ButtonList.Add(bi2);

                   
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("获取数据字典出错"+ex.Message);
            }

          
        }

        private void OnStart()
        {
            try
            {
                int recordCount = 0;
                QueryParam dataDictionaryParam = new QueryParam();
                dataDictionaryParam.Where = "where parent=" + DictionaryID;
                List<T_DataDictionaryEntity> lst = new List<T_DataDictionaryEntity>();
                lst = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryList(dataDictionaryParam, out recordCount);
 
                if (DictionaryID == 0)
                    CatNameTxt.Text = "数据字典";
                else
                {
                    T_DataDictionaryEntity td=BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryDisp(DictionaryID);
                    CatNameTxt.Text = td.Name;
                    Code_Disp.Text = td.Code;
                }

                SubGroup.DataSource = lst;
                SubGroup.DataBind();

                CatListTitle.Text = string.Format("<a href='Default.aspx'>数据字典</a>{0}", GetGroupTitle(DictionaryID));
            }
            catch (Exception ex)
            {

                Console.WriteLine("获取数据字典出错" + ex.Message);
            }
           
        }

        /// <summary>
        /// 获取数据字典路径
        /// </summary>
        /// <param name="GroupID">数据字典ID</param>
        /// <returns></returns>
        public string GetGroupTitle(int dictionaryId)
        {
            try
            {
                int recordCount = 0;
                QueryParam dataDictionaryParam= new QueryParam();
                dataDictionaryParam.Where = "where id=" + dictionaryId;
                List<T_DataDictionaryEntity> lst = new List<T_DataDictionaryEntity>();
                lst = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryList(dataDictionaryParam, out recordCount);
              
                if (lst.Count > 0)
                {
                    foreach (T_DataDictionaryEntity item in lst)
                    {
                        return GetGroupTitle(Convert.ToInt32(item.parent.ToString())) + ">" + string.Format("<a href='Default.aspx?ID={0}'>{1}</a>", item.ID, item.Name);
                    }
                }
            }
            catch (Exception ex)
            {


                Console.WriteLine("获取数据字典出错" + ex.Message);
            }

            return "";
        }
    }
}
