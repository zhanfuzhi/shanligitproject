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
using Microsoft.Office.Interop.Word;
using System.IO;
using ShanliTech_HLD_Business.OfficWord;
using ShanliTech.LogLib;
using FrameWork.WebControls;

namespace FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect
{
    public partial class Doc_Online : System.Web.UI.Page
    {
        public string updatefilname, realname;
        public string forname, forfile, number;

        protected int DeviceDetectID = 0;
        string CMD = (string)Common.sink("CMD", MethodType.Get, 10, 0, DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");
            this.Btn_Create.Attributes.Add("onclick", "javascript:CloseWord();");
            
            DeviceDetectID = Convert.ToInt32(Request.QueryString["DeviceDetectID"].ToString());

            if (!Page.IsPostBack)
            {
                
                if (!string.IsNullOrEmpty(CMD))
                {
                    if (CMD.StartsWith("View"))
                    {
                        string title = string.Empty;
                        if ("ViewRecord".Equals(CMD))
                            title = "查看记录文档";
                        else
                            title = "查看证书";
                        HeadMenuWebControls1.HeadOPTxt = title;
                        HeadMenuWebControls1.HeadTitleTxt = title;

                        HeadMenuWebControls1.HeadHelpTxt = "帮助";
                        Operation_Table.Visible = false;
                        //Button1.Visible = false;
                        string ReportPath = Request.Params["DetectRecordPath"];
                        if (!string.IsNullOrEmpty(ReportPath))
                            forname = ReportPath;
                    }
                    else if (CMD.StartsWith("Update"))
                    {
                        string title = "修改证书";
                        HeadMenuWebControls1.HeadOPTxt = title;
                        HeadMenuWebControls1.HeadTitleTxt = title;

                        HeadMenuWebControls1.HeadHelpTxt = "帮助";
                        Operation_Table.Visible = false;
                        AddSaveUpdateButton();

                        string ReportPath = Request.Params["DetectRecordPath"];
                        if (!string.IsNullOrEmpty(ReportPath))
                            forname = ReportPath;
                    }
                }
                else
                {
                    Operation_Table.Visible = true;
                    ToolMethods.InitDropDownDocTemplate(Doc_DropDown);  //初始化证书模板DropDown
                }

            }
            AddBackButton();
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
        private void AddSaveUpdateButton()
        {
            HeadMenuButtonItem bi = new HeadMenuButtonItem();
            bi.ButtonPopedom = PopedomType.Edit;
            bi.ButtonName = "提交保存修改";
            bi.ButtonIcon = "disk.png";
            bi.ButtonUrlType = UrlType.JavaScript;
            bi.ButtonUrl = "javascript:BackToDefaultPage();";
            HeadMenuWebControls1.ButtonList.Add(bi);
        }
        
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "alert1", "<script language=javascript>alert('提交成功！');BackToDefaultPage();</script>");
        //    //Page.ClientScript.RegisterStartupScript(this.GetType(), "closeocx", "<script language=javascript>CloseWord();</script>");
        //    //EventMessage.MessageBox(1, "提示", "提交成功！", Icon_Type.OK, Common.GetHomeBaseUrl("Default.aspx"));
        //}
        protected void Button2_Click(object sender, EventArgs e)
        {
            string code = Doc_DropDown.SelectedValue;
            if (string.IsNullOrEmpty(code) || "0".Equals(code))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>alert('请选择证书类型！');</script>");
                return;
            }
            Random g = new Random();
            string rad = g.Next(10000).ToString();
            number = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";

            forfile = number + DeviceDetectID + ".doc";

            string fullfile = Server.MapPath("~/") + "\\CertifyDocs\\" + forfile;
            int _c = 0;
            AbsOfficeWord aow = AbsOfficeWord.GetInstance(DeviceDetectID);
            try
            {
                switch (code)
                {
                    case "CERTIFICATE_VERIFICATION":
                        _c = aow.CreateVerifyDoc(fullfile);
                        break;
                    case "CERTIFICATE_NOTICE":
                        _c = aow.CreateNoticeDoc(fullfile);
                        break;
                    case "CERTIFICATE_TEST":
                        _c = aow.CreateTestDoc(fullfile);
                        break;
                    case "CERTIFICATE_REGULATE":
                        _c = aow.CreateRegulateDoc(fullfile);
                        break;
                }

                if (_c > 0)
                {
                    OfficeWordApis owa = OfficeWordApis.Instance();
                    owa.InsertPic(fullfile, "Verifier_SignPicture", Server.MapPath("~/Manager/Public/SignPictures/") + UserData.GetUserDate.SignPicture, 40.0f, 18.0f);

                    int r = UpdateDatabase();
                    if (r > 0)
                    {
                        forname = forfile;
                    }
                }
            }
            catch (Exception ex)
            {
                AppLogger.Instance.Log.Error("出具证书异常", ex);
            }
            finally
            {
                aow.KillWordProcess();
            }

        }

        //更新数据库数据,修改记录状态
        private int UpdateDatabase()
        {

            try
            {
                DeviceDetectEntity detect = BusinessFacadeShanliTech_HLD_Business.DeviceDetectDisp(DeviceDetectID);
                detect.ReportPath = forfile;
                detect.ReportType = ToolMethods.GetDictionaryIDByCode(Doc_DropDown.SelectedValue);
                detect.VerifierID = 0;
                detect.Verifier = string.Empty;
                detect.VerifyFlag = 0;

                detect.ApproveFlag = 0;
                detect.Approver = string.Empty;
                detect.ApproverID = 0;

                detect.Status = (int)DetectStatus.RecordDocument;   //生成检定证书
                detect.DataTable_Action_ = DataTable_Action.Update;
                return BusinessFacadeShanliTech_HLD_Business.DeviceDetectInsertUpdateDelete(detect);
            }
            catch (Exception)
            {

                return -3;
            }

        }

        #region 暂时无用
        
        
        //#region 封面
        ///// <summary>
        ///// 封面
        ///// </summary>
        //private void ObtainCover()
        //{
        //    owm.NewLine();
        //    owm.NewLine();
        //    SetTitle("海军计量测试中心");
        //    SetLargeTitle(Doc_DropDown.SelectedItem.Text);
            
        //    //owm.InsertHeaderView("证书编号：" + certificate.SerierNo + "		第2页，共3页");
        //    owm.InsertDefault("证书编号：" + ReverseSpaceToText(20, certificate.SerierNo) + "第 1 页，共 页");

        //    owm.InsertDashLine("--------------------------------------------------------------------------------------------------------");
        //    owm.InsertDefault("用户单位："+certificate.Customer);
        //    owm.NewLine();
        //    owm.InsertDefault("地    址："+certificate.CustomerAddr);
        //    owm.NewLine();
        //    owm.InsertDefault("器具名称：" + ReverseSpaceToText(12, certificate.DeviceName) + "制造厂："+certificate.DeviceFactory);
        //    owm.NewLine();
        //    owm.InsertDefault("型    号：" + ReverseSpaceToText(12, certificate.DeviceModel) + "编  号："+certificate.DeviceNum);
        //    owm.InsertDashLine("--------------------------------------------------------------------------------------------------------");
        //    owm.InsertDefault("检定结论："+certificate.Verification);

        //    owm.InsertDashLine("--------------------------------------------------------------------------------------------------------");
        //    owm.InsertDefault("检定员：" + ReverseSpaceToText(13, certificate.Verifier) + "检定日期：" + (certificate.VerifyTime == null ? "" : ((DateTime)certificate.VerifyTime).ToString()));
        //    owm.NewLine();
        //    owm.InsertDefault("审核员：");
        //    owm.InsertBookmarkAtCurrent("Checker_SignPicture");
        //    owm.InsertDefault(ReverseSpaceToText(13, "") + "有效日期：  " + (certificate.DueToTime == null ? "" : ((DateTime)certificate.DueToTime).ToString()));
        //    owm.NewLine();
        //    owm.InsertDefault("批准人：");
        //    owm.InsertBookmarkAtCurrent("Approver_SignPicture");
        //    owm.InsertDefault(ReverseSpaceToText(13, "") + "发证单位： （指定专用章）");
        //    owm.InsertDashLine("--------------------------------------------------------------------------------------------------------");
        //    owm.InsertDefault("本机构地址："+certificate.DeptAddr);
        //    owm.NewLine();
        //    owm.InsertDefault("通信地址：" + ReverseSpaceToText(12, certificate.DeptPostAddr) + "邮政编码：" + certificate.DeptPostCode);
        //    owm.NewLine();
        //    owm.InsertDefault("联系电话：" + ReverseSpaceToText(12, certificate.DeptPhone) + "传    真：" + certificate.DeptFax);
            
        //    //owm.NewLine();
        //    //owm.InsertDefault("证书编号：");
        //    owm.AddPage();

        //    owm.NewLine();
        //    owm.InsertDefault("本单位是海军授权的计量技术机构");
        //    owm.NewLine();
        //    owm.InsertDefault("计量技术机构资质证书编号：" + certificate.DeptCertificateNum);

        //    owm.NewLine();
        //    owm.InsertDefault("使用的测量标准中主要测量设备：",15);
        //    owm.NewLine();
        //    owm.InsertStandardTable(certificate.StandardList);

        //    owm.NewLine();
        //    owm.InsertDefault("检定所依据的技术文件（编号、名称）：", 15); owm.NewLine();
        //    foreach(BasicEntity item in certificate.BasicList)
        //    {
        //        owm.InsertDefault(item.BasicCode + "  " + item.BasicName);
        //        owm.NewLine();
        //    }

        //    owm.NewLine();
        //    owm.InsertDefault("检定地点及其环境条件：",15);
        //    owm.NewLine();
        //    owm.InsertDefault("地点："+certificate.VerifyAddr);
        //    owm.NewLine();
        //    owm.InsertDefault("温度：" + ReverseSpaceToText(8, certificate.Temperature) + "相对湿度：" + ReverseSpaceToText(8, certificate.Humidity)+"其它："+certificate.NoteExt);
            
        //    owm.NewLine();
        //    owm.SetParagraphSpace -= 20;
        //    owm.InsertDefault("注：");
        //    owm.NewLine();
        //    owm.InsertDefault("1.本计量技术机构仅对加盖本机构检定专用章的完整证书负责；"); owm.NewLine();
        //    owm.InsertDefault("2.本证书的检定仅对所检定样品有效；"); owm.NewLine();
        //    owm.InsertDefault("3.证书未经本计量技术机构书面批准，不准部分复印。"); owm.NewLine();
        //    owm.SetParagraphSpace += 20;

        //    owm.DiffentFirstAndOthersHeader = true;
        //    owm.InsertPageHeaderNumber("证书编号：" + certificate.SerierNo + "                                               ", WdParagraphAlignment.wdAlignParagraphLeft);
            
        //}

        //private void SetTitle(string title)
        //{
        //    owm.SetParagraphSpace += 20;
        //    owm.InsertText(title, 18, WdColor.wdColorBlack, 1, WdParagraphAlignment.wdAlignParagraphCenter);
        //    owm.SetParagraphSpace -= 20;
        //}
        //private void SetLargeTitle(string title)
        //{
        //    owm.SetParagraphSpace += 25;
        //    owm.InsertText(title, 25, WdColor.wdColorBlack, 1, WdParagraphAlignment.wdAlignParagraphCenter);
        //    owm.SetParagraphSpace -= 25;
        //}
        //private string ReverseSpaceToText(int space, string text)
        //{
        //    string _r = text;
        //    if (space > 0)
        //    {
        //        if (!string.IsNullOrEmpty(text))
        //            space -= text.Length / 2;
        //        if (space > 0)
        //            for (int i = 0; i < space; i++)
        //                _r += "  ";
        //    }
        //    return _r;
        //}
        //#endregion

        //#region 检定证书
        //private void CreateVerification()
        //{
        //    string path = Server.MapPath("~/")+"Manager\\DocTemplates\\Bg_Border.doc";
        //    owm.CreateWord(path);
        //    //封面
        //    ObtainCover();

        //    owm.NewLine();
        //    string cate_code = ToolMethods.GetDictionaryCodeByID(cate);
        //    if ("DEVICE_CATE_P".Equals(cate_code))
        //    {
        //        InsertPressure(true);
        //    }
        //    else if ("DEVICE_CATE_E".Equals(cate_code))
        //    {
        //        InsertElectric(true);
        //    }
        //    else if ("DEVICE_CATE_AP".Equals(cate_code))
        //    {
        //        InsertAccratePressure(true);
        //    }
            
        //}
        //#endregion

        //#region 校准证书（测试报告）    没有检测结论
        //private void CreateRegulateOrTest()
        //{
        //    owm.CreateWord();
        //    //封面
        //    ObtainCover();

        //    owm.NewLine();
        //    string cate_code = ToolMethods.GetDictionaryCodeByID(cate);
        //    if ("DEVICE_CATE_P".Equals(cate_code))
        //    {
        //        InsertPressure(false);
        //    }
        //    else if ("DEVICE_CATE_E".Equals(cate_code))
        //    {
        //        InsertElectric(false);
        //    }
        //    else if ("DEVICE_CATE_AP".Equals(cate_code))
        //    {
        //        InsertElectric(false);
        //    }
        //}
        //#endregion

        //#region 检定结果通知书
        //private void CreateNotice()
        //{
        //    owm.CreateWord();
        //    //封面
        //    ObtainCover();

        //    owm.NewLine();
        //    owm.InsertDefault("检定结果/说明："); owm.NewLine();
        //    owm.InsertDefault("不合格项目及内容："); owm.NewLine();

        //}

        //#endregion
        

        //#region 压力

        ////普遍压力
        //private void InsertPressure(bool result)
        //{
        //    owm.NewLine();
        //    owm.InsertDefault("检定结果/说明："); owm.NewLine();
        //    owm.InsertDefault("一、外观检查："); owm.NewLine();
        //    owm.InsertDefault("     "+certificate.CheckFacade+"。"); owm.NewLine();
        //    owm.InsertDefault("二、零位检查："); owm.NewLine();
        //    owm.InsertDefault("     " + certificate.CheckZero + "。"); owm.NewLine();
        //    owm.InsertDefault("三、示值误差、回程误差、轻敲位移检定数据"); owm.NewLine();
        //    //压力检测记录
        //    if (result)
        //        owm.InsertNormalPressureRecord(certificate.P_RecordList, certificate.CheckPointFloat, certificate.CheckPersistentPressure); 
        //    else
        //        owm.InsertNormalPressureNoticeOrRegulate(certificate.P_RecordList, certificate.CheckPointFloat, certificate.CheckPersistentPressure);
        //    owm.NewLine();

        //    //owm.InsertDefault("四、指针平稳性检查："); owm.NewLine();
        //    //owm.InsertDefault("     " + certificate.CheckPointFloat + "。"); owm.NewLine();
        //}
        ////精密压力
        //private void InsertAccratePressure(bool result)
        //{
        //    owm.NewLine();
        //    owm.InsertDefault("检定结果/说明："); owm.NewLine();
        //    owm.InsertDefault("一、外观检查："); owm.NewLine();
        //    owm.InsertDefault("     " + certificate.CheckFacade + "。"); owm.NewLine();
        //    owm.InsertDefault("二、零位检查："); owm.NewLine();
        //    owm.InsertDefault("     " + certificate.CheckZero + "。"); owm.NewLine();
        //    owm.InsertDefault("三、示值误差、回程误差、轻敲位移检定数据"); owm.NewLine();
        //    //电气检测记录
        //    if (result)
        //        owm.InsertAccuratePressureRecord(certificate.P_AccurateRecordList, certificate.CheckPointFloat, certificate.CheckPersistentPressure);
        //    else
        //        owm.InsertAccuratePressureNoticeOrRegulate(certificate.P_AccurateRecordList, certificate.CheckPointFloat, certificate.CheckPersistentPressure);
        //    owm.NewLine();

        //    //owm.InsertDefault("四、指针平稳性检查："); owm.NewLine();
        //    //owm.InsertDefault("     " + certificate.CheckPointFloat + "。"); owm.NewLine();
        //}
        //#endregion

        //#region 电气
        //private void InsertElectric(bool result)
        //{
        //    owm.InsertDefault("检定结果/说明："); owm.NewLine();
        //    owm.InsertDefault("一、外观及线路检查："+certificate.CheckFacade); owm.NewLine();
        //    owm.InsertDefault("二、基本误差检定："); owm.NewLine();

        //    List<ElectrictRecordEntity> funcs_Dcv=null;
        //    List<ElectrictRecordEntity> funcs_Dci = null;
        //    List<ElectrictRecordEntity> funcs_Acv = null;
        //    List<ElectrictRecordEntity> funcs_Aci = null;
        //    List<ElectrictRecordEntity> funcs_Ohm = null;
        //    if (certificate.E_RecordList != null)
        //    {
        //        funcs_Dcv = certificate.E_RecordList.FindAll((x) => { return "DCV".Equals(x.FunctionCode); });
        //        funcs_Dci = certificate.E_RecordList.FindAll((x) => { return "DCI".Equals(x.FunctionCode); });
        //        funcs_Acv = certificate.E_RecordList.FindAll((x) => { return "ACV".Equals(x.FunctionCode); });
        //        funcs_Aci = certificate.E_RecordList.FindAll((x) => { return "ACI".Equals(x.FunctionCode); });
        //        funcs_Ohm = certificate.E_RecordList.FindAll((x) => { return "OHM".Equals(x.FunctionCode); });
        //    }
        //    if (funcs_Dcv != null)
        //    {
        //        owm.InsertDefault("直流电压："); owm.NewLine();
        //        owm.InsertElectricRecordByFunc(funcs_Dcv, "DCV", false, result);
        //    }
        //    if (funcs_Dci != null)
        //    {
        //        owm.InsertDefault("直流电流："); owm.NewLine();
        //        owm.InsertElectricRecordByFunc(funcs_Dci, "DCI", false, result);
        //    }
        //    if (funcs_Ohm != null)
        //    {
        //        owm.InsertDefault("直流电阻："); owm.NewLine();
        //        owm.InsertElectricRecordByFunc(funcs_Ohm, "OHM", false, result);
        //    }
        //    if (funcs_Aci != null)
        //    {
        //        owm.InsertDefault("交流电压："); owm.NewLine();
        //        owm.InsertElectricRecordByFunc(funcs_Acv, "ACV", true, result);
        //    }
        //    if (funcs_Aci != null)
        //    {
        //        owm.InsertDefault("交流电流："); owm.NewLine();
        //        owm.InsertElectricRecordByFunc(funcs_Aci, "ACI", true, result);
        //    }
            
        //}
        //#endregion
        #endregion
    }
}
