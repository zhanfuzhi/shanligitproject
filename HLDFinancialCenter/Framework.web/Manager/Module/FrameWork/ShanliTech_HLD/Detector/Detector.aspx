<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" CodeBehind="Detector.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.Detector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
    <style type="text/css">
        .DataSection
        {
            width: 100%;
            height: 400px;
            border: solid 1px #CCCCCC;
            overflow: auto;
        }
    </style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DetectorHelp.aspx'>帮助</a>"
        HeadOPTxt="设备检定" HeadTitleTxt="设备检定" 
         />
    <table width="99%" style="text-align: center;">
        <tr>
            <td style="text-align: center;">
                <fieldset>
                    <legend>控制区</legend>
                    <table style="width: 100%;text-align:center;">
                        <tr>
                            <td style="background-color: #cadee8; width:8%; ">
                                标准设备
                            </td>
                            <td style="background-color: #e9f2f7; width:28%;text-align:left;">
                                <asp:DropDownList ID="StandardDevice_DropDown" runat="server"  Width="98%"
                                    AutoPostBack="True" 
                                    onselectedindexchanged="StandardDevice_DropDown_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:15%;" align="center" rowspan="2">
                                <asp:ImageButton ID="ImageButton2" runat="server"
                                    ImageUrl="~/Manager/images/btnQR.png" onclick="ImageButton2_Click" />
                            </td>
                            <td style="background-color: #e9f2f7; width:10%; " rowspan="2">
                                <asp:RadioButton ID="Rbtn_Auto" runat="server" GroupName="worktype" 
                                    oncheckedchanged="Rbtn_Auto_CheckedChanged" Text="自动" 
                                    AutoPostBack="True" /><br />
                                <asp:RadioButton ID="Rbtn_Manual" runat="server" GroupName="worktype" 
                                    oncheckedchanged="Rbtn_Manual_CheckedChanged" Text="手动" 
                                    AutoPostBack="True" />
                            </td>
                            <td style="text-align: center; width:8%;" rowspan="2">
                                <asp:ImageButton ID="ibtn_start" runat="server"  AlternateText="开始检测"
                                    ImageUrl="~/Manager/images/PageIcon/btnstart.png" onclick="ibtn_start_Click" />
                            </td>
                            <td style="text-align: center; width:8%;" rowspan="2">
                                <asp:ImageButton ID="Ibtn_Pause" runat="server" AlternateText="暂停检测"
                                    ImageUrl="~/Manager/images/PageIcon/Pause.png" onclick="Ibtn_Pause_Click" />
                            </td>
                            <td style="text-align: center; width:8%; " rowspan="2">
                                <asp:ImageButton ID="ibtn_Stop" runat="server" AlternateText="停止检测"
                                    ImageUrl="~/Manager/images/PageIcon/stop.png" onclick="ibtn_Stop_Click" />
                            </td>
                            <td style="text-align: center; width:15%;" rowspan="2">
                                <asp:ImageButton ID="ImageButton1" runat="server" AlternateText="结束检定"
                                    ImageUrl="~/Manager/images/btnEnd.png" onclick="ImageButton1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="background-color: #cadee8;width:8%;">
                                被检设备
                            </td>
                            <td style="background-color: #e9f2f7; width:28%;text-align:left;">
                                <asp:DropDownList ID="DetectDevice_DropDown" runat="server" Width="98%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <fieldset>
                    <legend>功能</legend>
                    <table cellpadding = "0" cellspacing = "0" width = "100%">
                    <tr>
                    <td style =" width:20px;" align="left"><img alt ="开始" src="../../../Images/PageIcon/be.png" /></td>
                    <asp:Repeater ID="Repeater_funtion" runat="server">
                        <HeaderTemplate></HeaderTemplate>
                        <ItemTemplate>
                        <td align="center" style=" background-image:url(../../../Images/PageIcon/line.png); background-repeat:repeat-x;"><a href='<%# GetProgressBarImgNavUrl(DataBinder.Eval(Container.DataItem, "ID").ToString(),DataBinder.Eval(Container.DataItem, "Type").ToString())%>'> <img  style=" border:none;" alt ='<%# DataBinder.Eval(Container.DataItem, "Text")%>' src ='<%# GetProgressBarImg(DataBinder.Eval(Container.DataItem, "State").ToString(),DataBinder.Eval(Container.DataItem, "Type").ToString())%>' /></a></td>
                        </ItemTemplate>
                        <FooterTemplate></FooterTemplate>
                    </asp:Repeater>
                    <td style =" width:20px;" align="right"><img alt ="结束" src="../../../Images/PageIcon/be.png" /></td>
                    </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>检定点列表</legend>
                    <div class="DataSection">
                        <asp:GridView ID="GridView1" runat="server"  Visible="false"  AutoGenerateColumns="False"
                            onrowcreated="GridView1_RowCreated" >
                            <Columns>
                                <%--<asp:TemplateField HeaderText="设备功能名称">
                                    <ItemTemplate>
                                        <%#ShanliTech_HLD_Business.ToolMethods.GetFunctionNameByFunctionID(Convert.ToInt32(Eval("DeviceFunctionID")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="设备功能代码" SortExpression="FunctionCode" DataField="FunctionCode" />
                                <asp:TemplateField HeaderText="量程" SortExpression="TestRange">
                                    <ItemTemplate>
                                        <%#Eval("TestRange")%><%#Eval("Unit")%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="标准压力">
                                    <ItemTemplate>
                                        <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRound(Convert.ToDouble(Eval("StandardValue")),2)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="升压"  DataField="UpValue" />
                                <asp:BoundField HeaderText="降压" DataField="DownValue" />
                                <asp:TemplateField HeaderText="允许误差>
                                    <ItemTemplate>
                                        <%#Eval("MissibleErrorSymbol")%><%#Eval("ValuePerMissibleError")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="结论" DataField="ValueResult" />
                                <asp:BoundField HeaderText="升压" DataField="UpChange" />
                                <asp:BoundField HeaderText="降压" DataField="DownChange" />
                                <asp:BoundField HeaderText="允许值" DataField="ChangePerMissibleError" />
                                <asp:BoundField HeaderText="结论"  DataField="ChangeResult" />
                                <asp:BoundField HeaderText="测量值" DataField="HysteresisErrorValue" />
                                <asp:BoundField HeaderText="允许值" DataField="H_PerMissibleError" />
                                <asp:BoundField HeaderText="结论" DataField="H_Result" />
                                
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href="javascript:P_UpdateData(<%#Eval("ID") %>);">修改</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="GridView2" runat="server"  Visible="false" OnRowCreated="GridView2_RowCreated">
                            <Columns>
                                <asp:TemplateField HeaderText="量程">
                                    <ItemTemplate>
                                        <%#Eval("TestRange")%><%#Eval("Unit")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="标准值">
                                    <ItemTemplate>
                                        <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRoundFix(Convert.ToDouble(Eval("StandardValue")), Convert.ToInt32(Eval("RoundLen")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                 <asp:TemplateField HeaderText="实际值">
                                    <ItemTemplate>
                                        <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRoundFix(Convert.ToDouble(Eval("TestedValue")), Convert.ToInt32(Eval("RoundLen")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="最大允许误差">
                                    <ItemTemplate>
                                        <%#Eval("MissibleErrorSymbol")%><%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTML(Convert.ToDouble(Eval("ValuePerMissibleError")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="实际误差">
                                    <ItemTemplate>
                                        <%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTMLAndSign(Convert.ToDouble(Eval("TestedPerissibleError")))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="结论">
                                    <ItemTemplate>
                                        <%#Eval("ValueResult")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <a href="javascript:E_UpdateData(<%#Eval("ID") %>);">修改</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </fieldset>
            </td>
        </tr>
    </table>
    <object id="activex" classid="clsid:517F788B-D56A-4fb6-A062-1D6013F8E97D" style="display:none;" codebase="../../../../ActiveX.cab">
    </object>
    
<script type="text/javascript" src="../../../inc/FineMessBox/js/common.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/subModal.js"></script>
    <script language="JavaScript" type="text/javascript">
    //---
    function E_UpdateData(detectid){
        if(detectid>0){
            var urlStr='E_UpdateData.aspx?IDX='+detectid+'&rand'+rand(100000000);
            showPopWin('检定数据修改',urlStr,600, 180, AlertMessageBox,true);
        }else{
            alert('此记录未被检测或持久化，不提供修改操作！');
        }
    }
    function P_UpdateData(detectid){
        if(detectid>0){
            var urlStr='P_UpdateData.aspx?IDX='+detectid+'&rand'+rand(100000000);
            showPopWin('检定数据修改',urlStr,600, 240, AlertMessageBox,true);
        }else{
            alert('此记录未被检测或持久化，不提供修改操作！');
        }
    }
    //---
//+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++    
    rnd.today=new Date(); 
    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        alert(Messages);
        setTimeout("fromreload()",100)
        //window.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
     function reload()
    {
       setTimeout("fromreload()",3000);
    }
    function fromreload()
    {
        var pre ="Detector.aspx";// window.location.href;
//        if(pre.indexOf('?')>0)
//            pre=pre+"&";
//        else
//            pre=pre+"?";
        window.location.href = pre;//+rand(1000000);
    }
    function fnRead(){
        var actx = document.getElementById("activex");
        //alert("返回值："+actx.DetectDevice.ReadData());
        window.location.href="ReadDataHandle.aspx?CMD=VAL&VAL="+actx.DetectDevice.ReadData('');
    }
    function testreaddatacmd()
    {
        var actx = document.getElementById("activex");
        if (actx != null){actx.InitDetectDevice("R|COM3|001|9600|8|1|0|0x0");}
        if (actx != null){actx.DetectDevice.Open();};
        var rcvData=actx.DetectDevice.ReadDataCMD('OUT?');
        alert(rcvData);
    }
    </script>
    
</asp:Content>
