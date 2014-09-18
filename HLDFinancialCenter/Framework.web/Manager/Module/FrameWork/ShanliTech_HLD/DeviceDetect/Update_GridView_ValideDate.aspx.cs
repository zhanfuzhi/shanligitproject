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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class Update_GridView_ValideDate :PopPage
    {
        Int32 IDX = (Int32)Common.sink("IDX", MethodType.Get, 10, 0, DataType.Int);
        string DValidate = (string)Common.sink("Validate", MethodType.Get, 50, 0, DataType.Str);
        string Detectdate = (string)Common.sink("Detectdate", MethodType.Get, 50, 0, DataType.Str);
        DateTime Vdate;
        DateTime Ddate;
        protected void Page_Load(object sender, EventArgs e)
        {
           
                if (string.IsNullOrEmpty(DValidate))
                    DValidate = "";
                else
                {
                    DValidate = System.Web.HttpUtility.UrlDecode(DValidate);
                    if (DateTime.TryParse(DValidate, out Vdate))
                    {
                        DValidate = Vdate.ToShortDateString().ToString();
                    }
                }
                

                if (string.IsNullOrEmpty(Detectdate))
                    Detectdate = "";
                else
                {
                    Detectdate = System.Web.HttpUtility.UrlDecode(Detectdate);
                    if (DateTime.TryParse(Detectdate, out Ddate))
                    {
                        Detectdate = Ddate.ToString("yyyy年MM月dd日");
                    }
                }
            if (!Page.IsPostBack)
            {
                Label3.Text = "检定日期为："+ Detectdate;
                Label1.Text = GetValiDate(Ddate, 12).ToString("yyyy-MM-dd");
                Label2.Text = GetValiDate(Ddate, 6).ToString("yyyy-MM-dd");
                int len = ValiDateLen(Ddate, Vdate);
                if (len == 12) 
                { 
                    RadioButton1.Checked = true;
                    
                }
                else if (len == 6) 
                { 
                    RadioButton2.Checked = true;
                    
                }
                else 
                {
                    RadioButton3.Checked = true;
                    ValidateDate_Input.Text = DValidate.ToString();
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime vd = DateTime.MaxValue;
            if (RadioButton1.Checked == true) 
            {
                vd = GetValiDate(Ddate, 12);
            }
            else if (RadioButton2.Checked == true)
            {
                vd = GetValiDate(Ddate, 6);
            }
            else if (RadioButton3.Checked == true)
            {
                string valide = ValidateDate_Input.Text;
                if (!string.IsNullOrEmpty(valide) && DateTime.TryParse(valide, out vd))
                {
                    vd = DateTime.Parse(valide);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='有效期为空或格式不正确，修改失败！';window.parent.hidePopWin(false);</script>");
                    return;
                }
            }
            if (vd == DateTime.MaxValue) { Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='有效期无效，请检查。';window.parent.hidePopWin(false);</script>"); return; }
            SaveValiDate(vd);
        }

        private void SaveValiDate(DateTime vdate)
        {
            DateTime dt = vdate;
            DeviceDetectEntity dde = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(IDX);
            dde.DataTable_Action_ = DataTable_Action.Update;
            dde.ValidDate = dt;

            int rInt = BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(dde);
            string msg = string.Empty;
            if (rInt > 0)
                msg = "修改成功！";
            else
                msg = "修改失败！";
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal='" + msg + "';window.parent.hidePopWin(true);</script>");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.parent.hidePopWin(false);</script>");
        }

        private int ValiDateLen(DateTime detectdate, DateTime validate) 
        {
            DateTime tmpdate = validate.AddDays(1);
            int year1 = detectdate.Year;
            int year2 = tmpdate.Year;
            int month1 = detectdate.Month;
            int month2 = tmpdate.Month;
            int months=12*(year2-year1)+(month2-month1);
            return months;
        }

        private DateTime GetValiDate(DateTime ddate,int vmonth) 
        {
            DateTime _r = ddate.AddMonths(vmonth);
            _r = _r.AddDays(-1);
            return _r;
        }
    }
}
