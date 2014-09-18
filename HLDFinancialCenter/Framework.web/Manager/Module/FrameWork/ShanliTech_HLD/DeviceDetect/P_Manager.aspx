<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="P_Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect.P_Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="压力设备检定记录">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="压力设备检定记录" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看压力设备检定记录">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        检定记录编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceDetectID_Input" title="请输入检定记录编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DeviceDetectID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        设备功能编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceFunctionID_Input" title="请输入设备功能编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DeviceFunctionID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Unit_Input" title="请输入单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Unit_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        标标压力</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StandardValue_Input" title="请输入标标压力~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="StandardValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        升压读数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpValue_Input" title="请输入升压读数~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        降压读数</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DownValue_Input" title="请输入降压读数~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DownValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        允许误差</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ValuePerMissibleError_Input" title="请输入允许误差~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ValuePerMissibleError_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ValueResult_Input" title="请输入结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ValueResult_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        升压变动量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpChange_Input" title="请输入升压变动量~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpChange_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        降压变动量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DownChange_Input" title="请输入降压变动量~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DownChange_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        允许误差</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ChangePerMissibleError_Input" title="请输入允许误差~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ChangePerMissibleError_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        测量值（回程误差）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="HysteresisErrorValue_Input" title="请输入测量值（回程误差）~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="HysteresisErrorValue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        允许值</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="H_PerMissibleError_Input" title="请输入允许值~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="H_PerMissibleError_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="H_Result_Input" title="请输入结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="H_Result_Disp" runat="server"></asp:Label></td>
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
