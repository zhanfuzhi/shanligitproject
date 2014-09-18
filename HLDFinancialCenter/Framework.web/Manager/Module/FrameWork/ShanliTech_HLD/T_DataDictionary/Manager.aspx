<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="True" CodeBehind="Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadTitleTxt="数据字典管理" HeadOPTxt="数据字典资料" HeadHelpTxt="<a href='../../../../Helper/HelperFrame.aspx?Key=S02M04' target='_blank'>帮助</a>" HeadTitleIcon="dictionary.gif">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加数据字典">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        名称<asp:Label ID="lblName" runat="server" CssClass="nofifyask" >*</asp:Label>
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="Name_Input" title="请输入名称~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="Name_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        编码<asp:Label ID="Label1" runat="server" CssClass="nofifyask" >*</asp:Label>
                    </td>
                    <td class="table_none">
                        <asp:TextBox ID="Code_Input" title="请输入编码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <asp:Label ID="Code_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        上级节点
                    </td>
                    <td class="table_none">
                        <asp:Label ID="parent_Disp" runat="server"></asp:Label>
                    </td>
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
