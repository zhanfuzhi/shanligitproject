using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ShanliTech_HLD_Business.Components;
using ShanliTech_HLD_Business;
using FrameWork.Components;
using System.Collections.Generic;
using ShanliTech_HLD_Business.CustomComponents;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class Doc_Online_Approve : System.Web.UI.Page
    {
        public string updatefilname, realname;
        public string forname, forfile, number;
        public int verid; //检定证书内部编号ID，z主要用于与模板文件关联。

        protected int DetectID = (Int32)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        protected int CheckerID = (Int32)Common.sink("CheckerID", MethodType.Get, 10, 0, DataType.Int);
        protected string ReportPath = (string)Common.sink("ReportPath", MethodType.Get, 200, 1, DataType.Str);
        protected int userid = 0, btnId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID).ApproverID;
            //this.Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");
            Button10.Attributes.Add("onclick", "javascript: SignValidate();");
            Button4.Attributes.Add("onclick", "javascript: SignValidate();");
            if (!Page.IsPostBack)
            {
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            btnId = 1;
        }
        protected void Button10_Click(object sender, EventArgs e)
        {
            btnId = 10;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            btnId = 4;
        }
    }
}
