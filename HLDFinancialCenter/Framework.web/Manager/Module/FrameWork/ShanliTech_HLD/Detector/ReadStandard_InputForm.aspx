<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadStandard_InputForm.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.ReadStandard_InputForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
    <base target="_self" />
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css">
    <link rel="stylesheet" href="../../../Css/Table/default/css.css" type="text/css">
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="70%" border="0" cellspacing="1" cellpadding="3" align="center">
            <tr>
                <td style="width:30%;">标准设备示值</td>
                <td><asp:TextBox ID="Standard_Input" runat="server" ></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:right;">
                    <asp:Button ID="Button1" runat="server" 
                        Text="确定" onclick="Button1_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
