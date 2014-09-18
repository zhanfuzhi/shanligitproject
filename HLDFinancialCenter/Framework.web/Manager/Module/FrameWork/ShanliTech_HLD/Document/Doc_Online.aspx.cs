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

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.Document
{
    public partial class Doc_Online : System.Web.UI.Page
    {
        public string updatefilname, realname;
        public string forname, forfile, number;
        public int verid; //检定证书内部编号ID，z主要用于与模板文件关联。
        int DeviceDetectID = 0;
        public ShanliTech_HLD_Business.UserRole ur = ShanliTech_HLD_Business.ToolMethods.GetCurrentUserRole();
        protected CertificateEntity certificate;
        int cate;   //设备类型：电气/压力，主要用于数据数组的初始化工作

        public static readonly string FUNC_DCV = "FUNC_CODE_DCV";
        public static readonly string FUNC_DCI = "FUNC_CODE_DCI";
        public static readonly string FUNC_ACV = "FUNC_CODE_ACV";
        public static readonly string FUNC_ACI = "FUNC_CODE_ACI";
        public static readonly string FUNC_OHM = "FUNC_CODE_OHM";

        protected string basic = string.Empty;
        protected string standardlist = string.Empty;

        protected string election = string.Empty;
        protected string pressure = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            //SelectTemplate_Button.Attributes.Add("onclick", "javascript:alert('gege');");
            this.Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");
            //if (!Page.IsPostBack)
            //{
                ToolMethods.InitDropDownDocTemplate(Doc_DropDown);  //初始化证书模板DropDown
                
                DeviceDetectID = Convert.ToInt32(Request.QueryString["DeviceDetectID"].ToString());
                forfile = DateTime.Now.ToFileTime() + "" + DeviceDetectID + ".doc";

                verid = ToolMethods.GetDictionaryIDByCode("CERTIFICATE_VERIFICATION");  //检定证书内部编号ID，

                certificate = ToolMethods.ObtainCertificateByDetectID(DeviceDetectID);
                cate = BusinessFacadeShanliTech_HLD_Business.DeviceDisp(certificate.StandardDeviceID).DeviceCategoryID;
                InitDataArrayByCate();
                InitDataStandard();
                InitDataBasic();

            //}
                if (!Page.IsPostBack)
                {
                    Random g = new Random();
                    string rad = g.Next(10000).ToString();
                     number = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
                    //Number.Text = number;
                }
        }

        //根据功能分别统计列表List
        private void InitDataArrayByCate()
        {
            //电气设备
            if (cate == ToolMethods.GetDictionaryIDByCode("DEVICE_CATE_E"))
            {
                election = "{";
                string dcv = "\"dcv\":[";
                string dci = "\"dci\":[";
                string acv = "\"acv\":[";
                string aci = "\"aci\":[";
                string ohm = "\"ohm\":[";
                List<ElectrictRecordEntity> lst = certificate.E_RecordList;
                foreach (ElectrictRecordEntity item in lst)
                {
                    if (FUNC_DCV.Equals(item.FunctionCode))
                    {
                        dcv += item.ToJsonStr()+",";
                    }
                    else if (FUNC_DCI.Equals(item.FunctionCode))
                    {
                        dci += item.ToJsonStr() + ",";
                    }
                    else if (FUNC_OHM.Equals(item.FunctionCode))
                        ohm += item.ToJsonStr() + ",";
                    else if (FUNC_ACV.Equals(item.FunctionCode))
                        acv += item.ToJsonStr() + ",";
                    else if (FUNC_ACI.Equals(item.FunctionCode))
                        aci += item.ToJsonStr() + ",";
                }
                dcv = RemoveLastStr(dcv)+"]";
                dci = RemoveLastStr(dci) + "]";
                ohm = RemoveLastStr(ohm) + "]";
                acv = RemoveLastStr(acv) + "]";
                aci = RemoveLastStr(aci) + "]";
                election += dcv + "," + dci + "," + ohm + "," + acv + "," + aci + "}";
            }
            //压力设备
            else if (cate == ToolMethods.GetDictionaryIDByCode("DEVICE_CATE_P"))
            {
                pressure="{\"pressure\":[";
                List<PressureRecordEntity> lst = certificate.P_RecordList;
                foreach (PressureRecordEntity item in lst)
                {
                    pressure += item.ToJsonStr() + ",";
                }
                pressure = RemoveLastStr(pressure);
                pressure += "]}";
            }
        }

        //初始化本次检定时使用的主要标准器具转换为而为数组
        private void InitDataStandard()
        {
            standardlist = "{\"standard\":[";
            List<StandardMeasurementEntity> lst = certificate.StandardList;
            foreach (StandardMeasurementEntity item in lst)
            {
                standardlist += item.ToJsonStr() + ",";
            }
            standardlist = RemoveLastStr(standardlist)+"]}";

        }
        //技术规范（代号、名称）
        private void InitDataBasic()
        {
            basic = "{\"basic\":[";
            List<BasicEntity> lst = certificate.BasicList;
            foreach (BasicEntity item in lst)
            {
                basic += "\""+item.ToString()+"\",";
            }
            basic = RemoveLastStr(basic) + "]}";
        }
        //
        private static string RemoveLastStr(string str)
        {
            int last = str.LastIndexOf(",");
            int len = str.Length;
            if (last == len - 1)
            {
                str = str.Substring(0, last);
            }
            return str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }
    }
}
