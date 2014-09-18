<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.MobileBaseStation.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="移动运营商基站数据">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="移动运营商基站数据" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加移动运营商基站数据">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        区域标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="lac_Input" title="请输入区域标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lac_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        基站标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="cid_Input" title="请输入基站标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="cid_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        国家标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="mcc_Input" title="请输入国家标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="mcc_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        运营商标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="mnc_Input" title="请输入运营商标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="mnc_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        信号强度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="signalStrength_Input" title="请输入信号强度~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="signalStrength_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        与定位数据的外键关联</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="locationDataID_Input" title="请输入与定位数据的外键关联~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="locationDataID_Disp" runat="server"></asp:Label></td>
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
