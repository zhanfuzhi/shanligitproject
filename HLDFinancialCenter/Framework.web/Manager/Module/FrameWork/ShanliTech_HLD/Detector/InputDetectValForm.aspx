<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputDetectValForm.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.InputDetectValForm" %>

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
    <div>&nbsp;</div>
    <div>
    <fieldset>
            <legend>设备示值数据</legend>
            <table style="width: 100%;">
                <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        标准设备
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        被检设备
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                     <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        检定功能
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        量程范围
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        标准值
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    </td>
                    </tr>
                <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        被检设备示值
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="请输入一个有效的数值" 
                            ValidationExpression="^[+-]?([1-9][0-9]*|0)(\.[0-9]+)?$"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
                    <tr>
                       <td colspan = "2" align="center" style="background-color: #e9f2f7; width:30%;">
                           <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click"  />
                    </td>
                    
                    </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
