<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="Doc_Online.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.Doc_Online" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceDetectHelp.aspx#p5'>帮助</a>"
         HeadOPTxt="在线出具证书" HeadTitleTxt="在线出具证书">
    </FrameWorkWebControls:HeadMenuWebControls>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <%--<tr>
                <td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    在线证书管理</td>
            </tr>--%>
            <tr>
                <td valign="top" style="text-align: center">
                    <table height="26" cellspacing="0" cellpadding="0" width="100%" border="0" >
                        <tr>
                            <td>
                                <div style="text-align:center;width:100%;margin-bottom:10px;">
                                    <span  runat="server" id="Operation_Table">
                                        <asp:DropDownList ID="Doc_DropDown" runat="server" Width="115px">
                                            
                                        </asp:DropDownList>
                                        <asp:Button ID="Btn_Create" runat="server" Text="生成证书并保存" OnClick="Button2_Click" OnClientClick="javascript:CloseWord();"/>
                                        <%--<input type="button" value="证书预览" onclick="javascript:Check_Null();" style="width: 100px;" id="Button3"/>--%>
                                        
                                    </span>
                                    <%--<asp:Button ID="Button1" runat="server" Text="提交保存" OnClick="Button1_Click" />--%>
                                </div>
                                </td>
                        </tr>
                    </table>
                    <table cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
                        <tr bgcolor="#f3f8fe">
                            <td align="center" style="height: 8px">
                                <object id="FramerControl1" codebase="dsoframer.ocx" height="400px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
                                    <param name="_ExtentX" value="16960">
                                    <param name="_ExtentY" value="13600">
                                    <param name="BorderColor" value="-2147483632">
                                    <param name="BackColor" value="-2147483643">
                                    <param name="ForeColor" value="-2147483640">
                                    <param name="TitlebarColor" value="-2147483635">
                                    <param name="TitlebarTextColor" value="-2147483634">
                                    <param name="BorderStyle" value="1">
                                    <param name="Titlebar" value="0">
                                    <param name="Toolbars" value="1">
                                    <param name="Menubar" value="1">
                                </object>
                            </td>
                        </tr>
                    </table>
                    <%--<table cellspacing="0" cellpadding="0" width="100%" border="0">
                        <tr>
                            <td>
                            
                            </td>
                            
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td height="22" background="../images/show_02.gif">
                </td>
            </tr>
        </table>

<script type="text/javascript" src="../../../js/Serial/jquery-1.6.1.min.js"></script>
<script type="text/javascript">
var varFramerControl=document.getElementById("FramerControl1"); //document.all.FramerControl1
window.onload=Check_Null;
var isOpen=false;//是否已打开Word，用于Close释放


function CloseWord(){
    if(isOpen){
        varFramerControl.Close();
        isOpen=false;
    }
    
}
function Check_Null(){
    var filename='<%=forname %>';
    if('' != filename && filename.length > 0){
        var serverpath=window.location.host;
        var num=Math.random();
//	    document.all.FramerControl1.Open("http://"+serverpath+"/CertifyDocs/"+filename+"?tmp="+num+"", true);
        varFramerControl.Open("http://"+serverpath+"/CertifyDocs/"+filename+"?tmp="+num+"", true);
	    isOpen=true;
	}
}
//保存到服务器
function SaveToWeb(){
    
	varFramerControl.SetTrackRevisions(0);
    var serverpath=window.location.host; 
    varFramerControl.HttpInit();
    varFramerControl.HttpAddPostString("RecordID","200601022");
    varFramerControl.HttpAddPostString("UserID","李局长");
    varFramerControl.HttpAddPostCurrFile("FileData", "bbb.doc");

    varFramerControl.HttpPost("http://"+serverpath+"/Manager/inc/Doc_Online_Save.aspx?CMD=Detect&file=<%=forfile %>&number=<%=number %>&forname=<%=forname %>");
} 

//------提交保存 按钮检验
//$('#').click(function(){
//    var slt = $('#').val();
//    if(!isOpen){
//        alert('请先根据证书模板出具证书！');
//        return false;
//    }
//    else if(slt=='0'){
//        alert("请先选择证书模板！");
//        return false;    
//    }
//    
//    SaveToWeb();
//    return true;
//});
function BackToDefaultPage(){
    CloseWord();
    window.location.href="http://"+window.location.host+"/Manager/Module/ShanliTech_HLD/DeviceDetect/Default.aspx";
    window.close();
}
</script>
</asp:Content>
