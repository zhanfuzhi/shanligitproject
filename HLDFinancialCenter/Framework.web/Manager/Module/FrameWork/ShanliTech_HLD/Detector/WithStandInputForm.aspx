<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WithStandInputForm.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.WithStandInputForm" %>

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
    <div >
        <fieldset>
                <legend>倒计时</legend>
                <table style="width: 100%;">
                    <tr>
                        <td id="DelayTime_Div" align="center" style="background-color: #cadee8; ">
                            <span style="font-size:35px;color:Black;font-family:Sans-Serif;">倒计时剩余：</span><span id="LeaveTime" style="font-size:40px;color:Red;font-style:italic;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="background-color: #e9f2f7; width: 70%;">
                            <span style="color:Gray;font-size:12px;">建议计时结束前不要操作，请耐心等待！</span>
                        </td>
                    </tr>
                </table>
        </fieldset>
    </div>
    <div>
    <fieldset>
            <legend>耐压3分钟检查</legend>
            <table style="width: 100%;">
   
                    <tr>
                        <td style="background-color: #cadee8; width:30%;">
                            耐压3分钟检查结果
                        </td>
                        <td style="background-color: #e9f2f7; width:70%;">
                            <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" 
                                GroupName="outward" Text="合格" />
                            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="outward" 
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

<script type="text/javascript">
var interval='<%=Interval %>';

var delay=100;
var seconds=interval/1000-1;
var millseconds=1000-delay;

if(parseInt(interval)>0){
    setTimeout('timeout()',delay);
}
else{
    document.getElementById("DelayTime_Div").innerHTML='<span style="font-size:40px;color:Black;font-family:Sans-Serif;">倒计时结束</span>';
}


function timeout(){
    if(millseconds>delay){
        millseconds-=delay;
    }else{
        if(seconds>0){
            seconds-=1;
            millseconds=1000-delay;
        }else{
            document.getElementById("DelayTime_Div").innerHTML='<span style="font-size:40px;color:Black;font-family:Sans-Serif;">倒计时结束</span>';
			return;
        }
    }
    document.getElementById('LeaveTime').innerHTML=seconds+' <span style="font-size:35px;color:black;">秒</span> '+millseconds;
    setTimeout('timeout()',delay);

}
</script>
</html>
