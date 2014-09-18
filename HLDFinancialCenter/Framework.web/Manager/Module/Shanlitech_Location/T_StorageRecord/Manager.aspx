<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_StorageRecord.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="入库表单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="入库表单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加入库表单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        所属核销</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="VeriID_Input" title="请输入所属核销~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="VeriID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        所属项目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入所属项目~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
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
                        型号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Model_Input" title="请输入型号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Model_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StorageNumber_Input" title="请输入数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="StorageNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        单价</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UnitPrice_Input" title="请输入单价~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UnitPrice_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        入库时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StorageTime_Input" title="请输入入库时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="StorageTime_Disp" runat="server"></asp:Label></td>
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
                        批准人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Approver_Input" title="请输入批准人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        实际支出</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PayAmount_Input" title="请输入实际支出~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="PayAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        信息完整性校验码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IntegrityCheckCode_Input" title="请输入信息完整性校验码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="IntegrityCheckCode_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Remark</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入Remark~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Remark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        库存资产编码号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CodeNO_Input" title="请输入库存资产编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CodeNO_Disp" runat="server"></asp:Label></td>
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
