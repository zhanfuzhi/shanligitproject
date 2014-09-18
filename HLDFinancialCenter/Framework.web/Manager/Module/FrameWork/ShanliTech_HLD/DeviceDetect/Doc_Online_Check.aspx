<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True" CodeBehind="Doc_Online_Check.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.Doc_Online_Check" %>

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
                                
                               <asp:Button OnClick="Button2_Click" Text="核验通过并签名" id="Button2" runat="server" />
                                <asp:Button OnClick="Button3_Click" Text="核验不通过并签名" id="Button3" runat="server" />
                                <input id="Button8" type="button" value="关　闭" onclick="CloseWord();window.close()" />
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
window.onload = function(){
    var num=Math.random();
    var serverpath=window.location.host;
	document.all.FramerControl1.Open("http://"+serverpath+"/CertifyDocs/<%=ReportPath%>", true);
	
	isOpen=true;
}

function CloseWord(){
    if(isOpen)
        document.all.FramerControl1.Close();
    
}
//保存到服务器
function SaveToWeb(){
//          showwait();	
	document.all.FramerControl1.SetTrackRevisions(0);
    var serverpath=window.location.host; 
   document.all.FramerControl1.HttpInit();
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","李局长");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "bbb.doc");
                                       
    document.all.FramerControl1.HttpPost("http://"+serverpath+"/Manager/Module/ShanliTech_HLD/DeviceDetect/Doc_Online_Save.aspx?file=<%=ReportPath %>&number=<%=number %>");
} 

//电子签名身份认证
function SignValidate(){
    //控件宽
    var aw = 420;
    //控件高
    var ah = 320;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    mytop=screen.availHeight-500;
    myleft=200;
    window.open("SignValidate.aspx?Number=<%=number %>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

//签入电子签名，并走后续流程
function OpenSealToWeb(signfile){
   var serverpath=window.location.host;
   var file = "http://"+serverpath+"/Manager/Public/SignPictures/"+signfile;
   document.all.FramerControl1.DownloadFile(file,"D:\\"+signfile);
   document.all.FramerControl1.SetFieldValue("Sign","","");
   document.all.FramerControl1.InSertFile("D:\\"+signfile,8);
   CloseWord();
   document.getElementById("ocx").style.display="none";
   var btn='<%=btnId %>';
   if(btn=='2')
        showPopWin('核验通过并提交批准','SubmitReport.aspx?CMD=Check&DetectID=<%=DetectID %>&UserID=<%=userid %>&rand'+rand(100000000),400, 300, AlertMessageBox,true);
   else if(btn=='3')
        showPopWin('核验不通过原因说明','NoPass.aspx?CMD=Check&DetectID=<%=DetectID %>&UserID=<%=userid %>&rand'+rand(100000000),400, 300, AlertMessageBox,true);
}	

//打印相关
function print(){
   document.all.FramerControl1.PrintOut();
}
function printview(){
    document.all.FramerControl1.PrintPreview();
}
function printviewexit(){
    document.all.FramerControl1.PrintPreviewExit();
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
</script>
</asp:Content>
