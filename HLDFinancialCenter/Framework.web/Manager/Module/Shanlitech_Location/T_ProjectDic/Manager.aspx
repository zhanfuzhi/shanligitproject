<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectDic.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="T_ProjectDic">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="T_ProjectDic" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加T_ProjectDic">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        项目编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入项目编号~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        ProjectName</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectName_Input" title="请输入ProjectName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjectName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        所属科目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SubjectNO_Input" title="请输入所属科目~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="SubjectNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        所属类别</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassNO_Input" title="请输入所属类别~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ClassNO_Disp" runat="server"></asp:Label></td>
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
                        CreateTime</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateTime_Input" title="请输入CreateTime~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CreateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        UpdateTime</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpdateTime_Input" title="请输入UpdateTime~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpdateTime_Disp" runat="server"></asp:Label></td>
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
