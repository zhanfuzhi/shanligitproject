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
using System.Collections.Generic;
using System.Reflection;

using FrameWork;
using FrameWork.Components;
using FrameWork.WebControls;
using ShanliTech_HLD_Business.Components;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary
{
    public partial class CatIndex : System.Web.UI.Page
    {
        public string TableSink = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            TableSink = Common.TableSink;
            OutJs();
        }

        private void OutJs()
        {
            try
            {
                int recordCount = 0;
                List<T_DataDictionaryEntity> lst = new List<T_DataDictionaryEntity>();
                QueryParam dataDictionaryParam = new QueryParam();
                dataDictionaryParam.OrderType = 0;

                lst = BusinessFacadeShanliTech_HLD_Business.T_DataDictionaryList(dataDictionaryParam, out recordCount);
                string strLink = "";
                int intCount = 0;
                StringBuilder strSB = new StringBuilder();

                strSB.Append("<script language='JavaScript'>\n");
                strSB.Append("Fold_id='';\n");
                strSB.Append("treeRoot = gFld(\"mainbody\", \"Êý¾Ý×Öµä\", \"Default.aspx\");\n");

                foreach (T_DataDictionaryEntity item in lst)
                {
                    intCount = intCount + 1;
                    strLink = "Default.aspx?ID=" + item.ID.ToString();
                    List<T_DataDictionaryEntity> _childCount = new List<T_DataDictionaryEntity>();
                    _childCount = lst.FindAll(r => r.parent == item.ID);
                    if (item.parent == 0)
                    {
                        if (_childCount.Count == 0)
                        {

                            strSB.AppendFormat("insDoc(treeRoot,gLnk(\"mainbody\",\"{0}\",\"{1}\"))\n", Common.ReplaceJs(item.Name), strLink);
                        }
                        else
                        {
                            strSB.AppendFormat("N{0}=insFld(treeRoot,gFld(\"mainbody\",\"{1}\",\"{2}\"))\n", item.ID, Common.ReplaceJs(item.Name), strLink);
                        }
                    }
                    else
                    {
                        if (_childCount.Count == 0)
                        {
                            strSB.AppendFormat("insDoc(N{0},gLnk(\"mainbody\",\"{1}\",\"{2}\"))\n", item.parent, Common.ReplaceJs(item.Name), strLink);
                        }
                        else
                        {
                            strSB.AppendFormat("N{0}=insFld(N{1},gFld(\"mainbody\",\"{2}\",\"{3}\"))\n", item.ID, item.parent, Common.ReplaceJs(item.Name), strLink);
                        }
                    }

                }

                strSB.Append("	initializeDocument();\n");
                strSB.Append("</script>\n");
                ShowScript.Text = strSB.ToString();

            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
