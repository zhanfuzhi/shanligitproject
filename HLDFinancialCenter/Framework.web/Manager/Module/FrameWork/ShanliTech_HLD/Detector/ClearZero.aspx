<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClearZero.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.ClearZero" %>

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
    <div >&nbsp;</div>
    <div>
    <fieldset>
        <legend>系统提示</legend>
    <table style="width: 100%;">
            <tr>
                
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label1" runat="server" Text="Label">本步骤将对设备进行<span style="text-decoration:underline;color:#0000FF">清零</span>操作：</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label2" runat="server" Text="Label">&nbsp;&nbsp;&nbsp;<span style="color:#A31515;">自动设备：</span>会发送清零指令。</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label3" runat="server" Text="Label">&nbsp;&nbsp;&nbsp;<span style="color:#A31515;">手动设备：</span>请手动清零。</asp:Label>
                </td>
            </tr>
            <tr>
                <td style="background-color: #cadee8; " class="style1">
                    <div style="width:40%;float:left;">&nbsp;</div><asp:Label ID="Label4" runat="server" Text="Label"><span style="color:#FF0000;">*</span><span style="color:#3c3c3c;font-style:italic;"> 请准备完毕后点击下面[确定]按钮！</span></asp:Label>
                <span id="LeaveTime" style="font-size:20px;color:Red;font-style:italic;"></td>
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
<script type="text/javascript">
var interval='<%=Interval %>';

var delay=100;
    var seconds=interval/1000-1;
    var millseconds=1000-delay;
    
if(parseInt(interval)>0){
    
    setTimeout('timeout()',delay);
    
}else{
    setTimeout('window.close()',1000);
}

function timeout(){
        if(millseconds>=delay){
            millseconds-=delay;
        }else{
            if(seconds>0){
                seconds-=1;
                millseconds=1000-delay;
            }else{
                window.close();
            }
        }
        document.getElementById('LeaveTime').innerHTML=seconds+' <span style="font-size:35px;color:black;">秒</span> '+millseconds;
        setTimeout('timeout()',delay);

    }
</script>
</html>
