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
using FrameWork.WebControls;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DetectApprove
{
    public partial class Doc_Online_Approve : System.Web.UI.Page
    {
        public string updatefilname, realname;
        public string forname, forfile, number;
        public int verid; //检定证书内部编号ID，z主要用于与模板文件关联。

        protected int DetectID = (Int32)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        protected int CheckerID = (Int32)Common.sink("CheckerID", MethodType.Get, 10, 0, DataType.Int);
        protected string ReportPath = (string)Common.sink("ReportPath", MethodType.Get, 200, 1, DataType.Str);
        protected string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        protected int userid = 0, btnId;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID).ApproverID;
            AddBackButton();
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(CMD) && CMD.StartsWith("View"))
                {
                    string title = string.Empty;
                    if ("ViewRecord".Equals(CMD))
                        title = "查看记录文档";
                    else
                        title = "查看证书";
                    HeadMenuWebControls1.HeadOPTxt = title;
                    HeadMenuWebControls1.HeadTitleTxt = title;
                }
            }
        }


        private void AddBackButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.List;
            bi.ButtonName = "设备检测";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = "javascript:BackToDefaultPage();";
            HeadMenuWebControls1.ButtonList.Add(bi);
        }
    }
}
