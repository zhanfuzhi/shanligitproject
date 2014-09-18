<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="经费使用申请单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费使用申请单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加经费使用申请单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjID_Input" title="请输入预算项目~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label></td>
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
                        申请用途</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UseRemark_Input" title="请输入申请用途~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UseRemark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        支出金额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AdvanceAmount_Input" title="请输入支出金额~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="AdvanceAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Applicant_Input" title="请输入申请人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Checker_Input" title="请输入审核人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Checker_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Approver_Input" title="请输入批准人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        流转状态（0为申请状态，1为审核状态，2为批准状态）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TransferState_Input" title="请输入流转状态（0为申请状态，1为审核状态，2为批准状态）~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="TransferState_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        状态（0为流转状态，1为存档状态，9为删除）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="State_Input" title="请输入状态（0为流转状态，1为存档状态，9为删除）~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="State_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AppricationTime_Input" title="请输入申请时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="AppricationTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        审核时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CheckTime_Input" title="请输入审核时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CheckTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        批准时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ApprovalTime_Input" title="请输入批准时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ApprovalTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        信息完整性校验码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IntegrityCheckCode_Input" title="请输入信息完整性校验码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="IntegrityCheckCode_Disp" runat="server"></asp:Label></td>
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
