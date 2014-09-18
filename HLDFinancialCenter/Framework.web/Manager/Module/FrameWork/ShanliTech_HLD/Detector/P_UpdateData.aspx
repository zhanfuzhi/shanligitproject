<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="P_UpdateData.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.P_UpdateData" %>

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
    .table_txt2
    {
    	text-align:left;
    	background-color:#CADEE8;
    	width:40px;
    	padding:5px;
    	font-size:9pt;
    }
    .table_none
    {
    	background-color:#E9F2F7;
    	width:50%;
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
                    <td class="table_txt" colspan="2">标准值</td>
                    <td class="table_none"><asp:Label runat="server" ID="Standard_Disp"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_txt" rowspan="2">被检表轻敲后示值</td>
                    <td class="table_txt2">升压</td>
                    <td class="table_none"><asp:TextBox runat="server" ID="UpValue_Input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table_txt2">降压</td>
                    <td class="table_none"><asp:TextBox runat="server" ID="DownValue_Input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table_txt" rowspan="2">轻敲指针变动量</td>
                    <td class="table_txt2">升压</td>
                    <td class="table_none"><asp:TextBox runat="server" ID="UpChange_Input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table_txt2">降压</td>
                    <td class="table_none"><asp:TextBox runat="server" ID="DownChange_Input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="3" class="table_center">
                        <asp:Button runat="server" ID="Btn_Submit" Text="确定"  Width="80" onclick="Btn_Submit_Click"
                            />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
