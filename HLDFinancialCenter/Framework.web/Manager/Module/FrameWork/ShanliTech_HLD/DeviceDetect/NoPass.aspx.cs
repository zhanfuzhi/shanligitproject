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

using FrameWork.Components;
using FrameWork.WebControls;
using FrameWork;
using ShanliTech_HLD_Business.Components;

namespace ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect
{
    public partial class NoPass : System.Web.UI.Page
    {
        Int32 DetectID = (Int32)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        Int32 UserID = (Int32)Common.sink("UserID", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        string RoleStr = (string)Common.sink("Role", MethodType.Get, 10, 0, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            sys_UserTable usr = BusinessFacade.sys_UserDisp(UserID);
            switch (CMD)
            {
                case "Check":
                    IDCard.Text = "核验员";
                    IDCard_Txt.Text = usr.U_CName;
                    
                    Note_Txt.Visible = false;
                    OPTime.Visible = false;
                    break;
                case "Approve":
                    IDCard.Text = "批准人";
                    IDCard_Txt.Text = usr.U_CName;
                    
                    Note_Txt.Visible = false;
                    OPTime.Visible = false;
                    break;
                case "List":
                    ReportApprovalRecordEntity rar = ToolMethods.GetReportByDetectID(DetectID);
                    if("R_Check".Equals(RoleStr))
                        IDCard.Text = "核验员";
                    else if("R_Approve".Equals(RoleStr))
                        IDCard.Text = "批准人";
                    IDCard_Txt.Text = BusinessFacade.sys_UserDisp(rar.Opuser).U_CName;
                    OPTime.Text = rar.OpTime != null ? "（"+((DateTime)rar.OpTime).ToString("yyyy-MM-dd HH:mm")+"）" : "";

                    Note_Txt.Text = "["+rar.Opreation+"]"+rar.Note;
                    Note_Input.Visible = false;
                    Buttons.Visible = false;
                    break;
                default:
                    EventMessage.MessageBox(2, "不存在操作字符串!", "不存在操作字符串!", Icon_Type.Error, Common.GetHomeBaseUrl("Default.aspx"));
                    break;
            }
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (UserData.GetUserDate.UserID == UserID)
            {
                string Note_Value = ((string)Common.sink(Note_Input.UniqueID, MethodType.Post, 200, 0, DataType.Str)).Trim();

                DeviceDetectEntity ddt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID);
                ddt.DataTable_Action_ = DataTable_Action.Update;

                ReportApprovalRecordEntity rar = new ReportApprovalRecordEntity();
                rar.DataTable_Action_ = DataTable_Action.Insert;
                rar.DeviceDetectID = DetectID;
                rar.Note = Note_Value;

                string UserName=UserData.GetUserDate.U_CName;
                if ("Check".Equals(CMD))
                {
                    rar.Opreation = "核验驳回";
                    ddt.Verifier = UserName;
                    ddt.VerifierID = UserID;
                    ddt.VerifyFlag = 2; //不通过
                    ddt.VerifyTime = DateTime.Now;
                }
                else if ("Approve".Equals(CMD))
                {
                    rar.Opreation = "批准驳回";
                    ddt.Approver = UserName;
                    ddt.ApproverID = UserID;
                    ddt.ApproveFlag = 2;// 不通过
                    ddt.ApproveTime = DateTime.Now;
                }
                rar.OpTime = DateTime.Now;
                rar.Opuser = UserID;
                int rInt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(ddt);

                if(rInt>0)
                    BusinessFacadeShanliTech_HLD_Business.ReportApprovalRecordInsertUpdateDelete(rar);
                string titleMessage = string.Empty;
                if (rInt > 0)
                    titleMessage = "操作完成！";
                else
                    titleMessage = "操作失败！";
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='" + titleMessage + "';window.parent.hidePopWin(true);</script>");

            }
        }

    }
}
