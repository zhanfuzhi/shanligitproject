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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class SubmitReport : System.Web.UI.Page
    {
        Int32 DetectID = (Int32)Common.sink("DetectID", MethodType.Get, 10, 0, DataType.Int);
        Int32 UserID = (Int32)Common.sink("UserID", MethodType.Get, 10, 0, DataType.Int);
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 1, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if("Check".Equals(CMD))
                    ToolMethods.InitDropDownUser(User_DropDown,UserRole.Approver);
                else if("Detect".Equals(CMD))
                    ToolMethods.InitDropDownUser(User_DropDown, UserRole.Checker);
                OnStart();
            }
        }

        private void OnStart()
        {
            

            switch (CMD)
            {
                case "Detect":
                    IDCard.Text = "核验员";
                    IDCard_Txt.Visible = false;
                    Note_Txt.Visible = false;
                    break;
                case "Check":
                    IDCard.Text = "批准人";
                    IDCard_Txt.Visible = false;
                    Note_Txt.Visible = false;
                    break;
                case "Approve":
                    User_List.Visible = false;
                    IDCard.Visible = false;
                    User_DropDown.Visible = false;
                    IDCard_Txt.Visible = false;
                    Note_Txt.Visible = false;
                    break;
                //case "List":
                //    ReportApprovalRecordEntity rar = ToolMethods.GetReportByDetectID(DetectID);
                //    UserRole ur = ToolMethods.GetUserRole(rar.Opuser);
                //    if (ur == UserRole.Checker)
                //        IDCard.Text = "核验员";
                //    else if (ur == UserRole.Approver)
                //        IDCard.Text = "批准人";
                //    IDCard_Txt.Text = usr.U_CName;
                //    OPTime.Text = rar.OpTime != null ? "（" + ((DateTime)rar.OpTime).ToLocalTime() + "）" : "";

                //    Note_Input.Visible = false;
                //    Buttons.Visible = false;
                //    break;
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
                int User_Select = 0;
                if (!"Approve".Equals(CMD))
                {
                    User_Select = Convert.ToInt32(User_DropDown.SelectedValue);
                    if (User_Select <= 0)
                    {
                        Common.MessBox("请选择" + IDCard.Text + "！");
                        return;
                    }
                }

                DeviceDetectEntity ddt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DetectID);
                ddt.DataTable_Action_ = DataTable_Action.Update;

                ReportApprovalRecordEntity rar = new ReportApprovalRecordEntity();
                rar.DataTable_Action_ = DataTable_Action.Insert;
                rar.DeviceDetectID = DetectID;
                rar.Note = Note_Value;

                string UserName = UserData.GetUserDate.U_CName;
                if ("Detect".Equals(CMD))
                {
                    rar.Opreation = "提交核验";
                    ddt.Verifier = User_DropDown.SelectedItem.Text;
                    ddt.VerifierID = User_Select;
                    ddt.VerifyFlag = 0; //未核验

                }
                else if ("Check".Equals(CMD))
                {
                    rar.Opreation = "核验通过并提交批准";
                    ddt.Verifier = UserName;
                    ddt.VerifierID = UserID;
                    ddt.VerifyFlag = 1; //通过
                    ddt.VerifyTime = DateTime.Now;
                    ddt.ApproverID=User_Select;
                    ddt.Approver = User_DropDown.SelectedItem.Text;
                    ddt.ApproveFlag = 0;
                    
                }
                else if ("Approve".Equals(CMD))
                {
                    rar.Opreation = "批准通过";
                    ddt.ApproveFlag = 1;//通过
                    ddt.ApproveTime = DateTime.Now;
                }
                rar.OpTime = DateTime.Now;
                rar.Opuser = UserID;
                int rInt = BusinessFacadeShanliTech_HLD_Business.ReportApprovalRecordInsertUpdateDelete(rar);
                if(rInt>0)
                    BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(ddt);
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
