<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Waitting.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.Waitting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=Title %>，请等待</title>
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css">
    <link rel="stylesheet" href="../../../Css/Table/default/css.css" type="text/css">
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
</head>
<body>
    <form id="form1" runat="server">
    <div>&nbsp;</div>
    <div>
        <fieldset>
                <legend>倒计时</legend>
                <table style="width: 100%;">
                    <tr>
                        <td id="Show_Delay" align="center" style="background-color: #cadee8; ">
                            <span  style="font-size:35px;color:Black;font-family:Sans-Serif;">倒计时剩余：</span><span id="LeaveTime" style="font-size:40px;color:Red;font-style:italic;"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="background-color: #e9f2f7; width: 70%;">
                            <span style="color:Gray;font-size:8;">计时结束后此窗口会自动关闭，建议不要手动操作，请耐心等待！</span>
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
    document.getElementById("Show_Delay").innerHTML='<span  style="font-size:40px;color:Black;font-family:Sans-Serif;">倒计时已结束！</span>';
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
