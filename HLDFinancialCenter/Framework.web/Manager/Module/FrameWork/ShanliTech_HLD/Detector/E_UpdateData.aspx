<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="E_UpdateData.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.E_UpdateData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
    <style type="text/css">
    .table_txt
    {
    	text-align:right;
    	background-color:#CADEE8;
    	width:40%;
    	padding:5px;
    	font-size:9pt;
    }
    .table_none
    {
    	background-color:#E9F2F7;
    	width:60%;
    	padding:5px;
    	font-size:9pt;
    }
    .table_center
    {
    	text-align:center;
    }
    </style>
</head>
<body style="background-color:#FFFFFF;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
            <legend>检定数据修改</legend>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
            
                <tr>
                    <td class="table_txt">标准值</td>
                    <td class="table_none"><asp:Label runat="server" ID="Standard_Disp"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_txt">标准设备回读值</td>
                    <td class="table_none"><asp:Label runat="server" ID="ValueStandard_Disp"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_txt">被检设备回读原值</td>
                    <td class="table_none"><asp:Label runat="server" ID="PreValue_Disp"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_txt">被检设备回读新值（不包含单位）</td>
                    <td class="table_none"><asp:TextBox runat="server" ID="NewValue_Input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" class="table_center">
                        <asp:Button runat="server" ID="Btn_Submit" Text="确定"  Width="80"
                            onclick="Btn_Submit_Click"/>
                    </td>
                </tr>
            </table>
        </fieldset>
    
    </div>
    </form>
</body>
</html>
