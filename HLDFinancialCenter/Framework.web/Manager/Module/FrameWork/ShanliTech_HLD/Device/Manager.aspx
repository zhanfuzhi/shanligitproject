<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="True" CodeBehind="Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadTitleTxt="设备" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceManagerHelp.aspx#p5'>帮助</a>">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="设备" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加设备">
            <font color="red">带“*”字段为必填项。</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        设备编号
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="DeviceNum_Input" title="请输入设备编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="DeviceNum_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        器具名称
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="DeviceName_Input" title="请输入器具名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="DeviceName_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        型号/规格
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="DeviceModel_Input" title="请输入型号/规格~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <a id="DeviceModel_A" runat="server" href="javascript:showPopWin('从已有型号列表选择','AssembleDeviceModelSelectList.aspx?rand'+rand(100000000),500, 420, AssembleDeviceModelSelected,true);">
                            从已有型号列表选择</a>
                        <asp:Label ID="DeviceModel_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        制造厂
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="DeviceFactory_Input" title="请输入制造厂~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="DeviceFactory_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <!--指令-->
                <tr>
                    <td class="table_body">
                        测量标准证书号
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="CertifcateNumPart_Input" title="请输入测量标准证书号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="CertifcateNumPart_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备类别&nbsp;<font color="red">*</font>
                    </td>
                    <td class="table_none">
                        <asp:DropDownList ID="DeviceCategory_DropDown" runat="server" OnSelectedIndexChanged="DeviceCategory_DropDown_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:Label ID="DeviceCategoryID_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="E_PermitType_TR" runat="server">
                    <td class="table_body">
                        设备检定点误差计算方式
                    </td>
                    <td class="table_none">
                        <asp:RadioButton ID="Permit_Default" runat="server" GroupName="CalPermitType" Text="按照检定点计算"
                            BackColor="#C3C3C3" Width="150" Checked="true" />
                        <asp:RadioButton ID="Permit_Range" runat="server" GroupName="CalPermitType" Text="按照满度（量程）计算"
                            BackColor="#C3C3C3" Width="150" />
                        <asp:RadioButton ID="Permit_Precision" runat="server" GroupName="CalPermitType" Text="按照设定字数计算"
                            BackColor="#C3C3C3" Width="150" />
                        <asp:Label ID="E_PermitType_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="DetectType_TR">
                    <td class="table_body">
                        检测方式&nbsp;<font color="red">*</font>
                    </td>
                    <td class="table_none">
                        <asp:DropDownList ID="DetectType_DropDown" runat="server" OnSelectedIndexChanged="DetectType_DropDown_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:Label ID="DetectType_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--<tr runat="server" id="CmdClose_TR">
                    <td class="table_body">
                        关闭（断开）设备指令</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CmdClose_Input" title="请输入关闭（断开）设备~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CmdClose_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr runat="server" id="CmdClear_TR">
                    <td class="table_body">
                        设备清除指令</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CmdClear_Input" title="请输入设备清除指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CmdClear_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr runat="server" id="CmdOpen_TR">
                    <td class="table_body">
                        打开设备指令</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CmdOpen_Input" title="请输入打开设备指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CmdOpen_Disp" runat="server"></asp:Label></td>
                </tr>--%>
                <tr runat="server" id="CmdReset_TR">
                    <td class="table_body">
                        复位指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="CmdReset_Input" title="请输入复位指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="CmdReset_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="CmdZero_TR">
                    <td class="table_body">
                        清零指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="CmdZero_Input" title="请输入清零指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="CmdZero_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="CmdRead_TR">
                    <td class="table_body">
                        读指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="CmdRead_Input" title="请输入读指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="CmdRead_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="CmdSTBY_TR">
                    <td class="table_body">
                        停止输出指令
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="CmdSTBY_Input" title="请输入停止输出指令~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="CmdSTBY_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="SetCmdPerfix_TR">
                    <td class="table_body">
                        指令前缀
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SetCmdPerfix_Input" title="请输入指令前缀~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SetCmdPerfix_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="SetCmdSuffix_TR">
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
                        连接方式&nbsp;<font color="red">*</font>
                    </td>
                    <td class="table_none">
                        <asp:DropDownList ID="ConnectType_DropDown" runat="server" OnSelectedIndexChanged="ConnectType_DropDown_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:Label ID="ConnectType_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="BoardNumber_TR" runat="server">
                    <td class="table_body">
                        主板号
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="BoardNumber_Input" title="请输入主板号~2147483648:int" runat="server"
                            CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="BoardNumber_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="PrimaryAddress_TR" runat="server">
                    <td class="table_body">
                        主地址
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="PrimaryAddress_Input" title="请输入主地址~10:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="PrimaryAddress_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="SecondaryAddress_TR" runat="server">
                    <td class="table_body">
                        第二地址
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="SecondaryAddress_Input" title="请输入第二地址~10:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="SecondaryAddress_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="RS232_Conn_TR" runat="server">
                    <td class="table_body">
                        RS232连接参数
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="RS232_Conn_Input" title="请输入RS232连接参数~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="RS232_Conn_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        k 值，用于计算设备的不确定度
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="kvalue_Input" title="请输入k 值，用于计算设备的不确定度~float" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="kvalue_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        k 的显示名称
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="kname_Input" title="请输入k 的显示名称 如： k=2,k= 3/k= 根号2 等~50:" runat="server"
                            CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="kname_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="Sleep_TR" runat="server">
                    <td class="table_body">
                        回读延时
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="Sleep_Input" title="请输入回读延时~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="Sleep_Disp" runat="server"></asp:Label>
                        （单位：ms）
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        精确度等级
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="AccuracyLevel_Input" title="请输入精确度等级~float" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="AccuracyLevel_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="ScaleValue_TR" runat="server">
                    <td class="table_body">
                        分度值
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="ScaleValue_Input" title="请输入分度值~float" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="ScaleValue_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="ScaleUnit_TR" runat="server">
                    <td class="table_body">
                        分度值单位
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="ScaleUnit_Input" title="请输入分度值单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="ScaleUnit_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备量程
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="RangeValue_Input" title="请输入设备量程~float" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="RangeValue_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备量程单位
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="RangeUnit_Input" title="请输入设备量程单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="RangeUnit_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="DetectMedium_TR" runat="server">
                    <td class="table_body">
                        检定用工作介质
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="DetectMedium_Input" title="请输入检定用工作介质~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="DetectMedium_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="RoundLen_TR" runat="server">
                    <td class="table_body">
                        保留小数个数（向上取整）
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="RoundLen_Input" title="请输入保留小数个数（向上取整）~int:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="RoundLen_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <%--<tr>
                    <td class="table_body">
                        排列序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OrderId_Input" title="请输入排列序号~int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="OrderId_Disp" runat="server"></asp:Label></td>
                </tr>   --%>
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
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
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
    var CmdJson='';
    function AssembleDeviceModelSelected()
    {
       if(CmdJson==undefined||CmdJson=='')return;
       var json=$.parseJSON(CmdJson);
       $("#<%=DeviceModel_Input.ClientID %>").val(json.DeviceModel);
       
       $("#<%=CmdReset_Input.ClientID %>").val(json.CmdReset);
       $("#<%=CmdZero_Input.ClientID %>").val(json.CmdZero);
       $("#<%=CmdRead_Input.ClientID %>").val(json.CmdRead);
       $("#<%=CmdSTBY_Input.ClientID %>").val(json.CmdSTBY);
       $("#<%=SetCmdPerfix_Input.ClientID %>").val(json.SetCmdPerfix);
       $("#<%=SetCmdSuffix_Input.ClientID %>").val(json.SetCmdSuffix);
    }
    </script>

</asp:Content>
