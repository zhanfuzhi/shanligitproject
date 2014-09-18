<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReadDetect_InputForm.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.ReadDetect_InputForm" %>

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
            <legend>被检设备示值录入</legend>
            <table style="width: 100%;">
                <tr>
                    <td style="background-color: #cadee8; width:30%;">标准值</td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:Label ID="Standard_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #cadee8; width:30%;">轻敲后示值</td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="Value_Input" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="Value_Input" Display="Dynamic" ErrorMessage="请按正确数据格式输入 轻敲后示值" 
                            ValidationExpression="^[-+]?\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #cadee8; width:30%;">轻敲指针变动量</td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="Change_Input" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                            ControlToValidate="Change_Input" Display="Dynamic" ErrorMessage="请按正确数据格式输入 轻敲指针变动量" 
                            ValidationExpression="^[-+]?\d+(\.\d+)?$"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"  style="background-color: #e9f2f7; width:30%;" align="center">
                        <asp:Button ID="Button1" runat="server" 
                            Text="确定" onclick="Button1_Click"/></td>
                </tr>
            </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
