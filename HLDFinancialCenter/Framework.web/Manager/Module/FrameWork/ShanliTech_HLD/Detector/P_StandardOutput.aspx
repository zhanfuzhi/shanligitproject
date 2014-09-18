<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P_StandardOutput.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.P_StandardOutput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
    <base target="_self" />
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css">
    <link rel="stylesheet" href="../../../Css/Table/default/css.css" type="text/css">
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
    <style type="text/css">
    .BigRedFont
    {
    	font-weight:bold;
    	font-size:18px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div >&nbsp;</div>
    
    <div>
    <fieldset>
    <legend>标准设备输出等待</legend>
        <table style="width: 100%;">
            <tr>
                <td align="center" style="background-color: #cadee8; " class="style1">
                    请将标准设备输出值调至<asp:Label ID="Label2" runat="server" CssClass="BigRedFont" ></asp:Label>
                </td>
            </tr>
            <tr align="center" style="background-color: #cadee8; " class="style1">
                <td>
                    <span style="color:Gray;font-size:8;">完成操作后请点击下面的&nbsp;<span style="font-weight:bold;">[确定]</span>&nbsp;按钮，已跟进流程。</span>
                </td>
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
