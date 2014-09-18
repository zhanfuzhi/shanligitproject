<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ClassDic.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="T_ClassDic">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="T_ClassDic" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加T_ClassDic">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        类别名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassNO_Input" title="请输入类别名称~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ClassNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        类别名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassName_Input" title="请输入类别名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ClassName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        父类</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ParentClassNO_Input" title="请输入父类~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ParentClassNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        状态(0为正常，9为删除)</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="State_Input" title="请输入状态(0为正常，9为删除)~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="State_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        创建日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateTime_Input" title="请输入创建日期~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CreateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        更新日期</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpdateTime_Input" title="请输入更新日期~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpdateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Sort</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sort_Input" title="请输入Sort~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Sort_Disp" runat="server"></asp:Label></td>
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
