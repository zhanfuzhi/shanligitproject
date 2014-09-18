<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectBudget.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="项目预算">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="项目预算" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加项目预算">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        项目编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入项目编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
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
                        所属年度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AnnualNO_Input" title="请输入所属年度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="AnnualNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算收入</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetRevenue_Input" title="请输入预算收入~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BudgetRevenue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算支出</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetExpenditure_Input" title="请输入预算支出~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BudgetExpenditure_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        经费余额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BalanceAmount_Input" title="请输入经费余额~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BalanceAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        项目组长</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Leader_Input" title="请输入项目组长~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Leader_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        指定承办人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Undertaker_Input" title="请输入指定承办人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Undertaker_Disp" runat="server"></asp:Label></td>
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
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateTime_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CreateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        更新时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpdateTime_Input" title="请输入更新时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpdateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        递增排序</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sort_Input" title="请输入递增排序~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Sort_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        所在部门</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DepartmentID_Input" title="请输入所在部门~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DepartmentID_Disp" runat="server"></asp:Label></td>
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
