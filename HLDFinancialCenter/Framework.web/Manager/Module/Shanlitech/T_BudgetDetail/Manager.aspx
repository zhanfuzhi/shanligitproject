<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_BudgetDetail.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="预算明细">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="预算明细" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加预算明细">
         <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">                                            
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />
                         <font style="color:Red;">*</font>
                   </td>
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
                     <font style="color:Red;">*</font>
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
                     <font style="color:Red;">*</font>
                        <asp:Label ID="BudgetPrice_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetNumber_Input" title="请输入预算数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                     <font style="color:Red;">*</font>
                        <asp:Label ID="BudgetNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr runat="server" id="tr_BudgetExpenditure">
                    <td class="table_body">
                        预算支出</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="BudgetExpenditure_Input" title="请输入预算支出~float" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="BudgetExpenditure_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        预算余额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BalanceAmount_Input" title="请输入预算余额~float" runat="server" CssClass="text_input"></asp:TextBox>
                     <font style="color:Red;">*</font>
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
        function selectProjectBudget(){
        showPopWin('已有预算项目列表', '../ProjectBudgetRadio/SelectProjectBudget.aspx',700, 450, ReloadPage, true, true);
        }
        function ReloadPage(id,text,balance,proid){
           document.getElementById("<%=ProjID_Hidden.ClientID %>").value=id;
           document.getElementById("<%=ProjID_Disp.ClientID %>").innerText=text;  
        }
        
        function ValidateData(){
         if (document.getElementById('<%= ProjID_Hidden.ClientID %>').value == "0") {
            alert('提示：请选择预算项目！');
            document.getElementById('<%= ProjID_Hidden.ClientID %>').focus();
            return false;} 
          if (document.getElementById('<%= BudgetRevenue_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= BudgetRevenue_Input.ClientID %>').value<0){
            alert('提示：请填写正确的预算收入！');
            document.getElementById('<%= BudgetRevenue_Input.ClientID %>').focus();
            return false;} 
              if (document.getElementById('<%= BudgetPrice_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= BudgetPrice_Input.ClientID %>').value<0){
            alert('提示：请填写正确的预算单价！');
            document.getElementById('<%= BudgetPrice_Input.ClientID %>').focus();
            return false;} 
             if (document.getElementById('<%= BudgetNumber_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= BudgetNumber_Input.ClientID %>').value<0){
            alert('提示：请填写正确的预算数量！');
            document.getElementById('<%= BudgetNumber_Input.ClientID %>').focus();
            return false;} 
               if (document.getElementById('<%= BalanceAmount_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= BalanceAmount_Input.ClientID %>').value<0){
            alert('提示：请填写正确的预算余额！');
            document.getElementById('<%= BalanceAmount_Input.ClientID %>').focus();
            return false;} 
        return true;}
            
    </script>
</asp:Content>
