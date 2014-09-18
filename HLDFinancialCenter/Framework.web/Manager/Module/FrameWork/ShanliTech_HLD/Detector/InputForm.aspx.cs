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
using ShanliTech_HLD_Business;
using FrameWork.Components;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Detector
{
    public partial class InputForm : PopPage
    {
        DetectManager _myDetectManager = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onClick", " window.returnValue = 'Detector.aspx';window.close();");
            if (!Page.IsPostBack)
            {
                InitDropDown();
            }
        }

        private void InitDropDown()
        {
            int gp_pid = 0;
            sys_GroupTable gp = BusinessFacade.sys_GroupDisp(UserData.GetUserDate.U_GroupID);
            //当前不为检测站，就取得当前单位父节点
            if (gp.Type != 2)
            {
                gp = BusinessFacade.sys_GroupDisp(gp.G_ParentID);

            }
            gp_pid = gp.GroupID;

            QueryParam qp = new QueryParam();
            qp.Where = "Where G_ParentID = " + gp_pid + " And Type = 1";
            int _Count = 0;
            ArrayList gplst = BusinessFacade.sys_GroupList(qp, out _Count);

            ListItem empty = new ListItem("请选择检定地点", "0");
            DropDownList1.Items.Add(empty);

            if (_Count > 0)
            {
                ListItem li = null;
                foreach (sys_GroupTable item in gplst)
                {
                    li = new ListItem(item.G_CName, item.GroupID.ToString());
                    DropDownList1.Items.Add(li);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["DetectManager"] != null)
            {
                _myDetectManager = (DetectManager)Session["DetectManager"];
            }
            if (_myDetectManager != null) 
            {
                _myDetectManager.DeviceDetectResult.EnvironmentNote = TextBox3.Text;
                if (string.IsNullOrEmpty(TextBox2.Text))
                {
                    _myDetectManager.DeviceDetectResult.Humidity = 0;
                }
                else
                {
                    _myDetectManager.DeviceDetectResult.Humidity = Convert.ToDouble(TextBox2.Text);
                }
                _myDetectManager.DeviceDetectResult.HumidityUnit = "%RH";
                if (string.IsNullOrEmpty(TextBox1.Text))
                { _myDetectManager.DeviceDetectResult.Temperature = 0; }
                else
                {
                    _myDetectManager.DeviceDetectResult.Temperature = Convert.ToDouble(TextBox1.Text);
                }
                _myDetectManager.DeviceDetectResult.TemperatureUnit = "°C";
                string location = BusinessFacade.sys_GroupDisp(Convert.ToInt32(DropDownList1.SelectedValue)).Address;
                _myDetectManager.DeviceDetectResult.DetectLocation = location;
                _myDetectManager.DeviceDetectResult.DetectNote = TextBox4.Text;
            }
            Page.ClientScript.RegisterStartupScript(this.GetType(), "input_form", "<script>window.returnValue = 'Detector.aspx';window.close();</script>");
            
        }
    }
}
