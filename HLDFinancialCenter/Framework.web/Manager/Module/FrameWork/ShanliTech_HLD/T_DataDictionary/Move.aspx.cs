using System;
using System.Data;
using System.Configuration;
using System.Collections;
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
using System.Collections.Generic; 

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary
{
    public partial class Move : System.Web.UI.Page
    {
        //public string TableSink = Common.TableSink;
        //public int DictionaryID = (int)Common.sink("DictionaryID", MethodType.Get, 255, 1, DataType.Int);
        //int ToDictionaryID = (int)Common.sink("ToDictionaryID", MethodType.Get, 255, 0, DataType.Int);
        //string CMD = (string)Common.sink("CMD", MethodType.Get, 255, 0, DataType.Str);
        //T_DataDictionaryService _dataDictionaryService = null;
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    _dataDictionaryService = new T_DataDictionaryService();
        //    if (CMD == "Move")
        //    {
        //        FrameWorkPermission.CheckPermissionVoid(PopedomType.Edit);
        //        MoveCat();
        //    }
        //    else {
        //        OutJs();
        //    }
            
        //}
        //private void MoveCat()
        //{
        //    T_DataDictionaryEntity GT = BusinessFacadeShanliTech_XT_GAJ_ZDRY.T_DataDictionaryDisp(DictionaryID);
        //    T_DataDictionaryEntity GTTo = BusinessFacadeShanliTech_XT_GAJ_ZDRY.T_DataDictionaryDisp(ToDictionaryID);
        //    int G_ParentID =Convert .ToInt32 ( GT.parent);

        //    //更新移动分类父分类子分类数
        //    //BusinessFacadeShanliTech_XT_GAJ_ZDRY.Update_Table_Fileds("T_DataDictionary", string.Format("Type='{0}'", GTTo.Name), string.Format("ID={0}", DictionaryID));
        //    //更新移动分类
        //    GT.parent = ToDictionaryID;
        //    GT.Type = GTTo.Name;
        //    GT.DataTable_Action_ = DataTable_Action.Update;
        //    BusinessFacadeShanliTech_XT_GAJ_ZDRY.T_DataDictionaryInsertUpdateDelete(GT);

        //    EventMessage.MessageBox(1, "操作成功", string.Format("移动部门({0})成功!", GT.Name), Icon_Type.OK, Common.GetHomeBaseUrl(string.Format("Default.aspx?ID={0}", ToDictionaryID)), Common.BuildJs);


        //}

        //private void OutJs()
        //{
        //    List<ShanliTech.GPS.Entities.T_DataDictionary> l = new List<ShanliTech.GPS.Entities.T_DataDictionary>();
        //    l = _dataDictionaryService.GetAll();
        //    List<ShanliTech.GPS.Entities.T_DataDictionary> lst = new List<ShanliTech.GPS.Entities.T_DataDictionary>();
        //    foreach (ShanliTech.GPS.Entities.T_DataDictionary r in l )
        //    {
        //        if (r.ID != DictionaryID)
        //        {
        //            lst.Add(r);
        //        }
        //    }
        //    string strLink = "";
        //    int intCount = 0;
        //    StringBuilder strSB = new StringBuilder();

        //    strSB.Append("<script language='JavaScript'>\n");
        //    //strSB.Append("Fold_id='';\n");
        //    strSB.Append("treeRoot = gFld(\"mainbody\", \"数据字典\", \"\",\"0\")\n");

        //    foreach (ShanliTech.GPS.Entities.T_DataDictionary x in lst)
        //    {
        //        intCount = intCount + 1;
        //        strLink = x.ID.ToString();
        //        List<ShanliTech.GPS.Entities.T_DataDictionary> _childCount = new List<ShanliTech.GPS.Entities.T_DataDictionary>();
        //        _childCount = lst.FindAll(r => r.parent == x.ID);
        //        if (x.parent == 0)
        //        {
        //            if (_childCount.Count == 0)
        //            {

        //                strSB.AppendFormat("insDoc(treeRoot,gLnk(\"mainbody\",\"{0}\",\"\",\"{1}\"))\n", Common.ReplaceJs(x.Name), strLink);
        //            }
        //            else
        //            {
        //                strSB.AppendFormat("N{0}=insFld(treeRoot,gFld(\"mainbody\",\"{1}\",\"\",\"{2}\"))\n", x.ID, Common.ReplaceJs(x.Name), strLink);
        //            }
        //        }
        //        else
        //        {
        //            if (_childCount.Count == 0)
        //            {
        //                strSB.AppendFormat("insDoc(N{0},gLnk(\"mainbody\",\"{1}\",\"\",\"{2}\"))\n", x.parent, Common.ReplaceJs(x.Name), strLink);
        //            }
        //            else
        //            {
        //                strSB.AppendFormat("N{0}=insFld(N{1},gFld(\"mainbody\",\"{2}\",\"\",\"{3}\"))\n", x.ID, x.parent, Common.ReplaceJs(x.Name), strLink);
        //            }
        //        }

        //    }

        //    strSB.Append("	initializeDocument();\n");
        //    strSB.Append("</script>\n");
        //    ShowScript.Text = strSB.ToString();

        //}
    }
}
