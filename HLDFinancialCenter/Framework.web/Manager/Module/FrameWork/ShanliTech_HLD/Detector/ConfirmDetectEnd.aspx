<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfirmDetectEnd.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.ConfirmDetectEnd" %>

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
     <fieldset>
        <legend>检点结束确认</legend>
         <table style="width: 100%;">
            <tr>
                <td style="background-color: #cadee8; " align="center">
                   
                    您确定要结束本次检定吗？</td>
            </tr>
             <tr>
                <td style="background-color: #cadee8; " align="center">
                   
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="继续检定" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="结束检定" />
                   
                </td>
            </tr>
         </table>
     </fieldset>
    </div>
    </form>
</body>
</html>
