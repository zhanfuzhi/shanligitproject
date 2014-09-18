<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" CodeBehind="Doc_Online_Check.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DetectCheck.Doc_Online_Check" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="在线核验证书" HeadTitleTxt="在线核验证书">
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
                                <%
                                    if (!"ViewDoc".Equals(CMD))
                                    { 
                                        %>
                               <input type="button" value="核验通过并签名" id="Button2"  />
                                <input type="button" Value="核验驳回" id="Button3"  />
                                <%} %>
                                </div>
                                </td>
                        </tr>
                    </table>
                    <table id="ocx" cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
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

<script type="text/javascript" src="../../../inc/FineMessBox/js/common.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/subModal.js"></script>
<script type="text/javascript">
var isOpen=false;//是否已打开Word，用于Close释放
var btnid='0';
window.onload = function(){
    var num=Math.random();
    var serverpath=window.location.host;
	document.all.FramerControl1.Open("http://"+serverpath+"/CertifyDocs/<%=ReportPath%>", true);
	
	isOpen=true;
}

function CloseWord(){
    if(isOpen){
        document.all.FramerControl1.Close();
        isOpen=false;
    }
    
}
function HideWord(){
    $('#ocx').hide(10);
}
function ShowWord(){
    $('#ocx').show(10);
}
$('#Button2').click(function(){
    HideWord();
    CloseWord();
    SignValidate();
});
//驳回
$('#Button3').click(function(){
    HideWord();
    showPopWin('核验驳回原因说明','../../../inc/NoPass.aspx?CMD=Check&DetectID=<%=DetectID %>&UserID=<%=userid %>&rand'+rand(100000000),400, 300, AlertMessageBox,true);
});

//电子签名身份认证
function SignValidate(){
    
    showPopWin('电子签名密码','../../../inc/SignValidate.aspx?Operate=Check&file=<%=ReportPath %>&Number=<%=number %>&rand'+rand(100000000),400, 300, AlertMessageBox,true);
}

//签入电子签名
function SubmitReportToNext(){
   
   showPopWin('核验通过','../../../inc/SubmitReport.aspx?CMD=Check&file=<%=ReportPath %>&DetectID=<%=DetectID %>&UserID=<%=userid %>&rand'+rand(100000000),400, 300, AlertMessageBox,true);
   
   
}	

//------------------------------------------分割线--------------------------------------

rnd.today=new Date(); 
    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        alert(Messages);
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
     function reload()
    {
        var pre = window.location.href;
        if(pre.indexOf('?')>0)
            pre=pre+"&";
        else
            pre=pre+"?";    
        window.location.href = pre+rand(1000000);
    }
    function HideAndBackToDefault(show){
       hidePopWin(show);
       window.location.href='http://'+window.location.host + "/Manager/Module/ShanliTech_HLD/DetectCheck/DefaultCheck.aspx";
       window.close();
    }
    function BackToDefaultPage(){
        CloseWord();
        window.location.href="http://"+window.location.host+"/Manager/Module/ShanliTech_HLD/DetectCheck/DefaultCheck.aspx";
        window.close();
    }
</script>
</asp:Content>
