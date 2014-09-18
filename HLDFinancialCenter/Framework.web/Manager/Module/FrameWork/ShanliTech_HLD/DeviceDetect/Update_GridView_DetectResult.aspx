<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_GridView_DetectResult.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.Update_GridView_DetectResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
    
</head>
<body style="background-color:#FFFFFF;">
    <form id="form1" runat="server">
    <div style="border:solid 1px #c3c3c3;width:98%;margin:10px 0px 10px 0px;padding:3px;text-align:center;">
        <div style="background-color:#e9f2f7;width:100%;">
            <asp:RadioButton ID="Btn_Result_OK" runat="server" GroupName="Btn_Result" Text="合格"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="Btn_Result_NO" runat="server" GroupName="Btn_Result" Text="不合格"/>
        </div>
        <div style="margin:5px 0px 5px 0px;">
            <asp:Button ID="Button1" runat="server" Text="确  定" Width="60" 
                onclick="Button1_Click" />&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="取  消" Width="60" 
                onclick="Button2_Click"/>
        </div>
    </div>
    </form>
</body>

</html>
