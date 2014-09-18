<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="E_Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect.E_Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="电气设备检定记录">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="电气设备检定记录" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看电气设备检定记录">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                
                <tr>
                    <td class="table_body">
                        功能编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceFunctionID_Input" title="请输入功能编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DeviceFunctionID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        最大允许误差</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="MaxPerMissibleError_Input" title="请输入最大允许误差~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="MaxPerMissibleError_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        检测结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Result_Input" title="请输入检测结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Result_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        标准值</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StandardValue_Input" title="请输入标准值~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="StandardValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        测试允许误差</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestedPerissibleError_Input" title="请输入测试允许误差~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="TestedPerissibleError_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        测试实际值</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestedValue_Input" title="请输入测试实际值~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="TestedValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        量程</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestRange_Input" title="请输入量程~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="TestRange_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        量程单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Unit_Input" title="请输入量程单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Unit_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        功能代码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FunctionCode_Input" title="请输入功能代码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="FunctionCode_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Frequency</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Frequency_Input" title="请输入Frequency~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Frequency_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        FrequencyUnit</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FrequencyUnit_Input" title="请输入FrequencyUnit~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="FrequencyUnit_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
