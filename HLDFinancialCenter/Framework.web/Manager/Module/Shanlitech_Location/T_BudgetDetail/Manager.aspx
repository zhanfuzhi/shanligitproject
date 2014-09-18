<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_BudgetDetail.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="预算明细">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="预算明细" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加预算明细">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        所属项目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjID_Input" title="请输入所属项目~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        器材名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="EquipmentName_Input" title="请输入器材名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="EquipmentName_Disp" runat="server"></asp:Label></td>
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
                        计量单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Measurement_Input" title="请输入计量单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Measurement_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算单价</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetPrice_Input" title="请输入预算单价~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BudgetPrice_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetNumber_Input" title="请输入预算数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BudgetNumber_Disp" runat="server"></asp:Label></td>
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
                        供货单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Supplier_Input" title="请输入供货单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Supplier_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入备注~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Remark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        递增排序</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sort_Input" title="请输入递增排序~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
