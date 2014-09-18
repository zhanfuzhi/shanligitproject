<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="FrameWork.web.Module.ShanliTech_HLD.Detector._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>串口通讯调试页</title>
    
</head>
<%--<body>
    
    <form id="form1" runat="server">
    
    <div>
       
        <input type="button" onclick="javascript:EnablePortList();" value="获取串口" />
        <select id="Serial_Select">
            <option value="0">选择串口</option>
        </select>
        <input type="button" onclick="javascript:fnOpenPorts();" value="打开" />
       <input type="button" onclick="javascript:fnClosePorts();" value="关闭" />
        <input type="text" id="Send_Input" />
        <input type="button" onclick="javascript:fnSendData();" value="发送数据"/>
        <input type="button" onclick="javascript:fnRcvData();" value="读取数据"/>
    </div>
    <div>
        <textarea cols="100" rows="10" id="RCV_Data">
        </textarea>
    </div>    
    
    </form>
    <object id="activex" classid="clsid:A721CAA4-D3DC-4014-A5D4-2B2009B218D4">
    </object>
    
<script type="text/javascript" src="../../js/Serial/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="../../js/Serial/SerialPort.js"></script>
</body>--%>
<body>
    
    <form id="form2" runat="server">
    
    <div style="margin:10px;"> 
       
        <table>
            <tr><td style="text-align:right;">Board：</td>
                <td><input type="text" id="Board_Input" /></td>
                <td rowspan="3">
                    <div style="margin-bottom:10px;"><input type="button" onclick="javascript:fnOpen();" value="打开" /></div>
                    <div><input type="button" onclick="javascript:fnClose();" value="关闭" /></div>
                </td>
            </tr>
            <tr><td style="text-align:right;">PrimaryAddress：</td>
                <td><input type="text" id="PrimaryAddr_Input" /></td>
            </tr>
            <tr><td style="text-align:right;">SecondaryAddress：</td>
                <td><input type="text" id="SecondaryAddr_Input" /></td>
            </tr>
            <tr><td colspan="2"><input style="width:98%;" type="text" id="SndData" /></td>
                <td><input type="button" onclick="javascript:fnWrite();" value="发送指令"/>
                <input type="button" onclick="javascript:fnRead();" value="读取数据"/></td>
            </tr>
        </table>
        
        
        
        
        
        </div>
        <div style="margin:10px;">
        
         </div>
    <div style="margin:10px;">
        <textarea cols="100" rows="10" id="RcvData"></textarea>
    </div>    
    
    </form>
    <object id="activex" classid="clsid:A721CAA4-D3DC-4014-A5D4-2B2009B218D4">
    </object>
    
<script type="text/javascript" src="../../js/Serial/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="../../js/Serial/NISerial.js"></script>
    <script type="text/javascript">
        var actx = document.getElementById("activex");
    actx.Debug=true;   //调试模式
    //---操控一个
    function fnOpen(){
        var board=document.getElementById("Board_Input").value;
        var primary=document.getElementById("PrimaryAddr_Input").value;
        var secondary=document.getElementById("SecondaryAddr_Input").value;
        if(secondary==undefined||secondary=="")
            secondary="0";
       
        actx.Open(board,primary);
    }
    function fnClose(){
        var primary=document.getElementById("PrimaryAddr_Input").value;
        actx.Close(primary);
    }
    function fnWrite(){
        var primary=document.getElementById("PrimaryAddr_Input").value;
        var txt_value=document.getElementById("SndData").value;
        if(txt_value==undefined||txt_value==""){
            alert("输入发送指令值");
            return;
        }
        actx.WriteToPort(primary,txt_value);
    }
    function fnRead(){
        var primary=document.getElementById("PrimaryAddr_Input").value;
        var rcv = actx.ReadFromPort(primary);
        document.getElementById("RcvData").innerHTML+=rcv;
    }
    function fnSendAndWrite(){
        fnWrite();
        var rcv = fnRead();
        document.getElementById("RcvData").innerHTML+=rcv;
    }
    //----操控一个结束
    </script>
</body>
</html>
