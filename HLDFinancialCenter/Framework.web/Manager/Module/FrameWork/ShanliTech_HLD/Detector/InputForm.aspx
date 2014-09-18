<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InputForm.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.InputForm" %>

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
            <legend>设备环境数据</legend>
            <table style="width: 100%;">
                <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        温度
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="°C"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="TextBox1" Display="Dynamic" ErrorMessage="请输入一个有效温度" 
                            ValidationExpression="^[+-]?([1-9][0-9]*|0)(\.[0-9]+)?%?$"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        湿度
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Text="%RH"></asp:Label>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="TextBox2" Display="Dynamic" ErrorMessage="请输入一个有效的湿度" 
                            ValidationExpression="^[+-]?([1-9][0-9]*|0)(\.[0-9]+)?$"></asp:RegularExpressionValidator>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        检定地点
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        环境备注
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox3" runat="server" Height="46px" TextMode="MultiLine" 
                            Width="100%"></asp:TextBox>
                        
                    </td>
                    </tr>
                     <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        检定备注
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox4" runat="server" Height="46px" TextMode="MultiLine" 
                            Width="100%"></asp:TextBox>
                        
                    </td>
                    </tr>
                    <tr>
                       <td colspan = "2" align="center" style="background-color: #e9f2f7; width:30%;">
                           <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
                    </td>
                    
                    </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
