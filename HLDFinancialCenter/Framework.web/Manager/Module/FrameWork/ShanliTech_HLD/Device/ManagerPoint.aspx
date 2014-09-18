<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="True" CodeBehind="ManagerPoint.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device.ManagerPoint"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/FunctionPointHelp.aspx#p5'>帮助</a>"
        HeadTitleTxt="功能检定点">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加功能检定点">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        设备功能名称
                    </td>
                    <td class="table_none">
                        <%--<asp:DropDownList ID="FunctionID_DropDown" runat="server"></asp:DropDownList>--%>
                        <%--<asp:TextBox ID="FunctionID_Input" title="请输入设备功能编号~float" runat="server" CssClass="text_input" Enabled="false"></asp:TextBox>
                        --%><asp:Label ID="FunctionID_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        量程
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="TestRange_Input" title="请输入量程~float:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="TestRange_Disp" runat="server"></asp:Label>
                        <% if (ShanliTech_HLD_Business.ToolMethods.IsElectrict(DeviceID))
                           { %>
                        <a href="javascript:ShowPopWindow();"  id="RangeSelectList_Pop" runat="server">从现有量程值中选择</a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        标准值
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="StandardValue_Input" title="请输入标准值~float:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="StandardValue_Input"
                            Display="Dynamic" ErrorMessage="请输入一个有效数值型标准值" ValidationExpression="^[+-]?([1-9][0-9]*|0)(\.[0-9]+)?%?$"></asp:RegularExpressionValidator>
                        <asp:Label ID="StandardValue_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        单位
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="Unit_Input" title="请输入单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="Unit_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="FreqUnit_TR">
                    <td class="table_body">
                        频率单位
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="FrequencyUnit_Input" title="请输入频率单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="FrequencyUnit_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="FreqValue_TR">
                    <td class="table_body">
                        频率数值
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="Frequency_Input" title="请输入频率数值~float" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="Frequency_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="ChangePerMissibleError_TR">
                    <td class="table_body">
                        轻击位移允许值
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="ChangePerMissibleError_Input" title="请输入轻击位移允许值~float:" runat="server"
                            CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="ChangePerMissibleError_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="H_PerMissibleError_TR">
                    <td class="table_body">
                        回程误差
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="H_PerMissibleError_Input" title="请输入回程误差~float:" runat="server"
                            CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="H_PerMissibleError_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        切换功能指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SwichFuncCmdCode_Input" title="请输入切换功能指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SwichFuncCmdCode_Disp" runat="server"></asp:Label>
                        <% if (ShanliTech_HLD_Business.ToolMethods.IsElectrict(DeviceID))
                           { %>
                        <a href="javascript:ShowSetCmdPopWindow('SwitchFuncCmdCode');" id="SwitchFuncCmdCode_A" runat="server">选择</a>
                        <%} %>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        切换量程指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SwichRangeCmdCode_Input" title="请输入切换量程指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SwichRangeCmdCode_Disp" runat="server"></asp:Label>                        
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        切换精度指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SwichRESCmdCode_Input" title="请输入切换精度指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SwichRESCmdCode_Disp" runat="server"></asp:Label>
                        <% if (ShanliTech_HLD_Business.ToolMethods.IsElectrict(DeviceID))
                           { %>
                        <a href="javascript:ShowSetCmdPopWindow('SwitchRESCmdCode');" id="SwitchRESCmdCode_A" runat="server">选择</a>
                        <%} %>
                    </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        指令前缀
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SetCmdPerfix_Input" title="请输入指令前缀~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SetCmdPerfix_Disp" runat="server"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        指令后缀
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SetCmdSuffix_Input" title="请输入指令后缀~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SetCmdSuffix_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        最大允许误差
                    </td>
                    <td class="table_none">
                        <div id="ValuePerMissible_Div" runat="server">
                            <asp:DropDownList ID="MissibleErrorSymbol_DropDown" runat="server">
                                <asp:ListItem Value="±">±</asp:ListItem>
                                <asp:ListItem Value="+">+</asp:ListItem>
                                <asp:ListItem Value="-">-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="ValuePerMissibleErrorName_Input" title="请输入最大允许误差底数部分~float:" runat="server"
                                CssClass="text_input" Width="65"></asp:TextBox>
                            E
                            <asp:TextBox ID="ValuePerMissibleErrorName_Fraction_Input" title="请输入最大允许误差指数部分~int:"
                                runat="server" CssClass="text_input" Width="30"></asp:TextBox></div>
                        <asp:Label ID="ValuePerMissibleErrorName_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td class="table_body">
                        小数位精确度
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="RoundLen_Input" title="请输入小数位精确度~int:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="RoundLen_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        排列序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OrderID_Input" title="请输入排列序号~int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="OrderID_Disp" runat="server"></asp:Label></td>
                </tr>--%>
                <%----%>
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

    <script type="text/javascript" src="../../../js/Serial/jquery-1.6.1.min.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/common.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/subModal.js"></script>
<script language="javascript" type="text/javascript">
var funcId='<%=FunctionID %>';
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
        alert(Messages);
        setTimeout("reload()",100)
    }
     function reload()
    {
        var pre = window.location.href;
        if(pre.indexOf('?')>0)
            pre=pre+"&";
        else
            pre=pre+"?";    
        window.location.href = pre+rand(1000000);
    }
    var RangeValueAndUnit='';
    function SetValueRangeList(){
        if(RangeValueAndUnit == undefined || RangeValueAndUnit == '') return;
        var args=RangeValueAndUnit.split('|');
        
        $('#<%=TestRange_Input.ClientID %>').val(args[0]);
        $('#<%=Unit_Input.ClientID %>').val(args[1]);
        $('#<%=SwichRangeCmdCode_Input.ClientID %>').val(args[2]);
    }
    function ShowPopWindow(){
        
        showPopWin('从现有量程值中选择量程','RangeSelectList.aspx?FunctionID='+funcId+'&rand'+rand(100000000),200, 320, SetValueRangeList,true);
    }
    var FuncID='<%=FunctionCode %>';
    var CmdJson='';
    function ShowSetCmdPopWindow(CmdIdentity){
        showPopWin('选择指令码','AssembleCmdSelectList.aspx?DeviceID=<%=DeviceID %>&DeviceModel=<%=DeviceModel %>&CmdIdentity='+FuncID+"_"+CmdIdentity+'&rand'+rand(100000000),500, 420, SetCmdCode,true);
    }
    function SetCmdCode(){
        if(CmdJson==undefined||CmdJson=='')return;
        var json=$.parseJSON(CmdJson);
        if(json.SwitchFuncCmdCode != undefined)
            $("#<%=SwichFuncCmdCode_Input.ClientID %>").val(json.SwitchFuncCmdCode);
        if(json.SwitchRangeCmdCode != undefined)
            $("#<%=SwichRangeCmdCode_Input.ClientID %>").val(json.SwitchRangeCmdCode);
        if(json.SwitchRESCmdCode != undefined)
            $("#<%=SwichRESCmdCode_Input.ClientID %>").val(json.SwitchRESCmdCode);
    }
    </script>

</asp:Content>
