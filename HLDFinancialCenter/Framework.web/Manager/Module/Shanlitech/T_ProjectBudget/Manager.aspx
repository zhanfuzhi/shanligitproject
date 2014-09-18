<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectBudget.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="项目预算">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="项目预算" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加项目预算">
        <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
               <tr>
                    <td class="table_body">
                        经费类别</td>
                    <td class="table_none">
                     
                        <asp:DropDownList ID="ClassNO_Input" title="请选择经费类别！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>    
                        <font style="color:Red;">*</font>                
                        <asp:Label ID="ClassNO_Disp" runat="server"></asp:Label></td>
                </tr>
                   <tr>
                    <td class="table_body">
                        预算科目</td>
                    <td class="table_none">
                     
                      <asp:DropDownList ID="SubjectNO_Input" title="请选择预算科目！" runat="server" CssClass="text_input"
                            Width="120px">   
                            </asp:DropDownList>    
                            <font style="color:Red;">*</font>                      
                        <asp:Label ID="SubjectNO_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                      <asp:DropDownList ID="ProjectNO_Input" title="请选择预算项目！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>
                             <font style="color:Red;">*</font>               
                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label>
                        </td>
                </tr>

   <tr>
                    <td class="table_body">
                        项目组长</td>
                    <td class="table_none">
                        <asp:DropDownList ID="Leader_Input" title="请选择项目组长！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>   
                        <font style="color:Red;">*</font>                 
                        <asp:Label ID="Leader_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        指定承办人</td>
                    <td class="table_none">
                        <asp:DropDownList ID="Undertaker_Input" title="请选择指定承办人！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>                    
                    <font style="color:Red;">*</font>
                        <asp:Label ID="Undertaker_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        年度编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AnnualNO_Input" title="请输入年度编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="AnnualNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算收入</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetRevenue_Input" title="请输入预算收入~float" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="BudgetRevenue_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算支出</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetExpenditure_Input" title="请输入预算支出~float" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="BudgetExpenditure_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr runat="server" id="tr_BalanceAmount">
                    <td class="table_body">
                        经费余额</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="BalanceAmount_Input" title="请输入经费余额~float" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="BalanceAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" OnClientClick="return ValidateData();" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">
    function ValidateData(){
         if (document.getElementById('<%= ClassNO_Input.ClientID %>').value.length == 0) {
                alert('提示：请选择经费类别！');
                document.getElementById('<%= ClassNO_Input.ClientID %>').focus();
                return false;} 
          if (document.getElementById('<%= SubjectNO_Input.ClientID %>').value.length == 0) {
                alert('提示：请选择预算科目！');
                document.getElementById('<%= SubjectNO_Input.ClientID %>').focus();
                return false;} 
          if (document.getElementById('<%= ProjectNO_Input.ClientID %>').value.length == 0) {
                alert('提示：请选择预算项目！');
                document.getElementById('<%= ProjectNO_Input.ClientID %>').focus();
                return false;} 
           if (document.getElementById('<%= Leader_Input.ClientID %>').value.length == 0) {
                alert('提示：请选择项目组长！');
                document.getElementById('<%= Leader_Input.ClientID %>').focus();
                return false;} 
           if (document.getElementById('<%= Undertaker_Input.ClientID %>').value.length == 0) {
                alert('提示：请选择指定承办人！');
                document.getElementById('<%= Undertaker_Input.ClientID %>').focus();
                return false;} 
           if (document.getElementById('<%= BudgetRevenue_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
                document.getElementById('<%= BudgetRevenue_Input.ClientID %>').value<0){
                alert('提示：请填写正确的预算收入！');
                document.getElementById('<%= BudgetRevenue_Input.ClientID %>').focus();
                return false;} 
           if (document.getElementById('<%= BudgetExpenditure_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
                document.getElementById('<%= BudgetExpenditure_Input.ClientID %>').value<0) {
                alert('提示：请填写正确的预算支出！');
                document.getElementById('<%= BudgetExpenditure_Input.ClientID %>').focus();
                return false;} 
            return true;}
    </script>
</asp:Content>
