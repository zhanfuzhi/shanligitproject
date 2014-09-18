<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutwardCheck.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.OutwardCheck" %>

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
            <legend>记录外观检查结果</legend>
            <table style="width: 100%;">
   
                    <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        外观检查
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                            GroupName="outward" Text="合格" />
                        <asp:RadioButton ID="RadioButton2" runat="server" GroupName="outward" 
                            Text="不合格" />
                        
                    </td>
                    </tr>
                     <tr>
                    <td style="background-color: #cadee8; width:30%;">
                        外观检查备注
                    </td>
                    <td style="background-color: #e9f2f7; width:70%;">
                        <asp:TextBox ID="TextBox4" runat="server" Height="46px" TextMode="MultiLine" 
                            Width="100%"></asp:TextBox>
                        
                    </td>
                    </tr>
                    <tr id="Zero_TR" runat="server">
                        <td style="background-color: #cadee8; width:30%;">
                            零位检查
                        </td>
                        <td style="background-color: #e9f2f7; width:70%;">
                            <asp:RadioButton ID="Radio_Zero_OK" runat="server" Checked="True" 
                                GroupName="Zero_Check" Text="合格" />
                            <asp:RadioButton ID="Radio_Zero_NO" runat="server" GroupName="Zero_Check" 
                                Text="不合格" />
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
