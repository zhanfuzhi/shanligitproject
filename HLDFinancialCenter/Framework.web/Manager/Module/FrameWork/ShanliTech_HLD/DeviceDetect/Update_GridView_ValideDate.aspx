<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_GridView_ValideDate.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.Update_GridView_ValideDate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
    
<link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <style type="text/css">
.td_txt
{
    background-color:#cadee8;
    padding-left:5px;
    width:20%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt;
    text-align:right;
}
.td_input
{
	background-color:#e9f2f7;
    padding-left:5px;
    width:30%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt
}
</style>
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
</head>
<body style="background-color:#FFFFFF;">
    <form id="form1" runat="server">
    <div style="width:98%;vertical-align:bottom;margin:10px 0px 0px 0px;">
     <fieldset>
        <legend>选择有效期</legend>
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
            <tr>
                <td colspan = "2" align ="left">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label></td>
            </tr>
             <tr>
                <td class="td_txt"><asp:RadioButton ID="RadioButton3" runat="server" Text="自定义有效期" 
                        GroupName="vd" /></td>
                <td class="td_input">
                    <asp:TextBox ID="ValidateDate_Input" runat="server" onfocus="javascript:calendar();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="td_txt">
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="一年有效期" GroupName="vd" /></td>
                <td class="td_input">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td class="td_txt">
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="半年有效期" GroupName="vd" /></td>
                <td class="td_input">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
            </tr>
           
           
        </table>
        <div style="text-align:center;">
                    <asp:Button ID="Button1" runat="server" Text="确  定" Width="60" 
                        onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="取  消" Width="60" 
                        onclick="Button2_Click"/>
                
        </div>
        </fieldset>
    </div>
    </form>
</body>

<script type="text/javascript" src="../../../inc/FineMessBox/js/common.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/subModal.js"></script>
<script type="text/javascript" src="../../../js/date/date.js"></script>
<script type="text/javascript" src="../../../js/date/datetime.js"></script>
<script type="text/javascript">
WebCalendar.format="yyyy/mm/dd";
</script>
</html>
