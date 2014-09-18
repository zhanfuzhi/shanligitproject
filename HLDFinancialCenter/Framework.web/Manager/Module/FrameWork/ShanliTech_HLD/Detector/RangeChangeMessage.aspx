<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RangeChangeMessage.aspx.cs"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.RangeChangeMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=FrameName %></title>
    <base target="_self" />
    <style type="text/css">
        .style1
        {
            width: 30%;
        }
        .fontStyle
        {
        	font-size:14px;
        	color:#A31515;
        }
    </style>
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css">
    <link rel="stylesheet" href="../../../Css/Table/default/css.css" type="text/css">
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div >&nbsp;</div>
    
    <div>
    <fieldset>
    <legend>系统提示</legend>
        <table style="width: 100%;">
            <tr>
                <td  align="center" style="background-color: #cadee8; " class="style1">
                    <asp:Label ID="Func_Disp" runat="server" CssClass="fontStyle"></asp:Label>
                </td>
            </tr>
             <tr>
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label3" runat="server" Text="Label">&nbsp;&nbsp;&nbsp;<span style="color:#A31515;">自动设备：</span>会发送切换量程指令。</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label4" runat="server" Text="Label">&nbsp;&nbsp;&nbsp;<span style="color:#A31515;">手动设备：</span>请手动切换量程。</asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" style="background-color: #cadee8; " class="style1"><span style="color:#FF0000;">*</span><span style="color:#3c3c3c;font-style:italic;">准备完毕后请点击下面[确定]按钮！</span>
                </span></td>
            </tr>

            <tr>
                <td align="center" style="background-color: #e9f2f7; width: 70%;">
                    <asp:Button ID="Button1" runat="server" Text="确定" />
                </td>
            </tr>
        </table>
        </fieldset>
    </div>
    </form>
</body>

</html>
