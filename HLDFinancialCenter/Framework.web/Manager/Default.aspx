<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="FrameWork.web._Default" %>

<html>
<head>
    <link rel="stylesheet" href="css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="images/Icon.ico" type="image/x-icon" />
    <script type="text/javascript" src="inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="inc/FineMessBox/js/subModal.js"></script>

    <title><%=FrameName %></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .navPoint
        {
            font-family: Webdings;
            font-size: 9pt;
            color: white;
            cursor: pointer;
        }
        p
        {
            font-size: 9pt;
        }
        .font_size
        {
            font-family: "Verdana" , "Arial" , "Helvetica" , "sans-serif";
            font-size: 12px;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
        }
        .bottom_background
        {
            background-image: url(images/Menu/buttom_b.gif);
            background-repeat: repeat-x;
        }
        #tip
        {
            position: absolute;
            right: 0px;
            bottom: 0px;
            height: 100px;
            width: 180px;
            border: 1px solid #CCCCCC;
            background-color: #eeeeee;
            padding: 1px;
            overflow-y: scroll;
            overflow: hidden;
            display: none;
            font-size: 12px;
            z-index: 10;
        }
        #crossBorderAlarmTip
        {
            position: absolute;
            right: 0px;
            bottom: 100px;
            height: 150px;
            width: 180px;
            overflow-y: scroll;
            border: 1px solid #CCCCCC;
            background-color: #eeeeee;
            padding: 1px;
            overflow: hidden;
            display: none;
            font-size: 12px;
            z-index: 10;
        }
        #tip p
        {
            padding: 6px;
        }
        #crossBorderAlarmTip p
        {
            padding: 6px;
        }
        #tip h1
        {
            font-size: 14px;
            height: 25px;
            line-height: 25px;
            background-color: #0066CC;
            color: #FFFFFF;
            padding: 0px 3px 0px 3px;
        }
        #crossBorderAlarmTip h1
        {
            font-size: 14px;
            height: 25px;
            line-height: 25px;
            background-color: #0066CC;
            color: #FFFFFF;
            padding: 0px 3px 0px 3px;
        }
        #tip h1 a
        {
            float: right;
            text-decoration: none;
            color: #FFFFFF;
        }
        #crossBorderAlarmTip h1 a
        {
            float: right;
            text-decoration: none;
            color: #FFFFFF;
        }
        .style1
        {
            width: 450px;
        }
</style>
</head>
<body scroll="no"  leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
        <tr>
            <td width="100%" height="50" colspan="3" style="border-bottom: 1px solid #000000">
                <table height="49" border="0" cellspacing="0" cellpadding="0" width="100%" class="font_size"
                    style="background-image: url(images/top_b.gif);">
                    <tr>
                        <td class="style1">
                            <%--<asp:Image ID="LogImage" runat="server" Height="49" ImageUrl="images/Page_Title.png" />--%>
                        </td>
                        <td align="right" style="padding-right: 10px;">
                            <table style="float: right; color: White; width:400px;">
                                <tr>
                                    <td align="right">
                                        客服电话:400 889 8961
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="right" valign="middle">
                                    <span  style="float: right; color: White;">
                                        <img style="display: block; float: left; width: 16px; height: 16px;"
                                            border="0" src="images/menu/Client.gif" alt="" />
                                        &nbsp;&nbsp;欢迎&nbsp;<span id="userName"><% =UserCName%></span>&nbsp;登录， <span>今天是 </span>
                                        <script language="JavaScript" type="text/javascript">
                                        {
                                            var enabled = 0;
                                            today = new Date();
                                            if (today.getDay() == 0) day = "星期日"

                                            if (today.getDay() == 1) day = "星期一"

                                            if (today.getDay() == 2) day = "星期二"

                                            if (today.getDay() == 3) day = "星期三"

                                            if (today.getDay() == 4) day = "星期四"

                                            if (today.getDay() == 5) day = "星期五"

                                            if (today.getDay() == 6) day = "星期六"
                                            date = (today.getYear()) + "年" + (today.getMonth() + 1) + "月" + today.getDate() + "日" + " " + day;
                                            document.write(date);
                                        }
                                        </script>
                                    </span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%
    switch (MenuStyle)
    {
        case 0:
        %>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="198" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 198; z-index: 2"
                    scrolling="auto" frameborder="0" src="left.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="关闭/打开左栏" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right"  class="middleCss">
                            <img border="0" src="images/Menu/close.gif" id="menuimg" alt="隐藏左栏" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="mainFrame" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
        case 1:
            
        %>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="115" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 100%; z-index: 2"
                    scrolling="no" frameborder="0" src="Menu1.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="关闭/打开左栏" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right" class="middleCss">
                            <img border="0" src="images/Menu/close.gif" id="menuimg" alt="隐藏左栏" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="Iframe" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
            case 2:
        %>
        <tr>
            <td height="51px">
               <iframe name="MainTop" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="no" frameborder="0" src="Menu2.aspx"></iframe>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <iframe id="Iframe" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
            case 3:
        %>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="198" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 198; z-index: 2"
                    scrolling="auto" frameborder="0" src="Menu3.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="关闭/打开左栏" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right"  class="middleCss">
                            <img border="0" src="images/Menu/close.gif" id="menuimg" alt="隐藏左栏" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" /></td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="Iframe1" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>       
        <%
            break;
        }
        %>
        <tr>
            <td colspan="3" height="20"  class="bottom_background">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="20">
                    <tr>
                        <td class="down_text">
                            Powered By <a href="http://www.shanlitech.com/" target="_blank"><font color="#ffffff">
                                ShanliTech</font></a>
                        </td>
                            <td align="right" width="320" bgcolor="#000000">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript:showPopWin('About','about.aspx',510, 170, null,false)">&nbsp;<img src="images/info.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">版本信息</font></td>
                                    <td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript:showPopWin('登陆日志','MyLogin.aspx',550, 370, null,true,true)">&nbsp;<img src="images/log.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">登陆日志</font></td>
                                    <%--<td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript:showPopWin('个人设定','UserSet.aspx?rand'+rand(100000000),400, 345, AlertMessageBox,true)">&nbsp;<img src="images/userset.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">个人设定</font></td>--%>
                                    <td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript: window.mainFrame.location.href='right.aspx'">&nbsp;<img src="images/house.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">回到首页</font></td>
                                    <td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript: window.top.location.href = 'LoginOut.aspx'">&nbsp;<img src="images/logout.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">退出系统</font></td>
                                   <%-- <td style="cursor:pointer;border-left:1px solid #FFFFFF;" onclick="javascript:window.open('http://framework.supesoft.com/help/');">&nbsp;<img src="images/help.gif" style="margin-bottom: -3px">&nbsp;<font color="#FFFFFF">帮助手册</font></td>--%>
                                </tr>
                            </table>
                            
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>

<script language="JavaScript" type="text/javascript">

var DispClose = true;

function CloseEvent()
{
    if (DispClose)
    {
        return "是否离开当前页面?";
    }
}
　window.onbeforeunload=CloseEvent;
　
　
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
        window.location.href = location.href+"?"+rand(1000000);
    }
    
var var_frmTitle = document.getElementById("frmTitle");
var var_menuimg  = document.getElementById("menuimg");

function switchSysBar(){

 	if (var_frmTitle.style.display=="none") {
		var_frmTitle.style.display=""
		var_menuimg.src="images/Menu/close.gif";
		var_menuimg.alt="隐藏左栏"
		}
	else {
		var_frmTitle.style.display="none"
		var_menuimg.src="images/Menu/open.gif";
		var_menuimg.alt="开启左栏"
	 }
	 
	 

}

 function menuonmouseover(){
 		if (var_frmTitle.style.display=="none") {
 		var_menuimg.src="images/Menu/open_on.gif";
 		}
 		else{
 		var_menuimg.src="images/Menu/close_on.gif";
 		}
 }
 function menuonmouseout(){
 		if (var_frmTitle.style.display=="none") {
 		var_menuimg.src="images/Menu/open.gif";
 		}
 		else{
 		var_menuimg.src="images/Menu/close.gif";
 		}
 }
     if(top!=self)
    {
        top.location.href = "default.aspx";
    }
   
</script>

