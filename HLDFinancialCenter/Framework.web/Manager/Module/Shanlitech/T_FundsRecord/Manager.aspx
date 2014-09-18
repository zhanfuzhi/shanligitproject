<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="经费使用申请单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费使用申请单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加经费使用申请单">
        <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                        <asp:Label ID="ProjID_Disp" runat="server" ></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />
                        <font style="color:Red;">*</font>
                   </td>
                </tr>

                <tr>
                    <td class="table_body">
                        经费余额</td>
                    <td class="table_none">
                                      
                        <asp:Label ID="BalanceAmount_Disp" runat="server"></asp:Label></td>
                         <asp:HiddenField ID="BalanceAmount_Hidden" runat="server" />
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
                    <font style="color:Red;">*</font>
                        <asp:Label ID="AdvanceAmount_Disp" runat="server"></asp:Label></td>
                </tr>
             <%--   <tr runat="server" id="tr_Applicant">
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>--%>

                  <tr runat="server" id="tr_Checker">
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Checker_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr_Approver">
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>
                
                 <tr runat="server" id="tr_TransferState">
                    <td class="table_body">
                        申请状态</td>
                    <td class="table_none">
                                         
                    <asp:Label ID="TransferState_Disp" runat="server"></asp:Label></td>
                </tr>
                 <tr runat="server" id="tr_ShenHeState">
                    <td class="table_body">
                        审核备注</td>
                    <td class="table_none">
                                         
                    <asp:Label ID="ShenHeState_Disp" runat="server"></asp:Label></td>
                </tr>
                 <tr runat="server" id="tr_PiZhunState">
                    <td class="table_body">
                        批准备注</td>
                    <td class="table_none">
                                         
                    <asp:Label ID="PiZhunState_Disp" runat="server"></asp:Label></td>
                </tr>
                 <tr runat="server" id="tr_CunDangState">
                    <td class="table_body">
                        存档备注</td>
                    <td class="table_none">
                                         
                    <asp:Label ID="CunDangState_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_AppricationTime">
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="AppricationTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" OnClientClick="return ValidateData();"/>
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="重填" 
                            onclick="Button2_Click" />
                        <asp:Button ID="Button3" runat="server" CssClass="button_bak" Text="提交申请" 
                            onclick="Button3_Click" />
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
   document.getElementById("<%=BalanceAmount_Disp.ClientID %>").innerText=balance;
   document.getElementById("<%=BalanceAmount_Hidden.ClientID %>").value=balance;
}

  function ValidateData(){
       if (document.getElementById('<%= ProjID_Hidden.ClientID %>').value == "0") {
            alert('提示：请选择预算项目！');
            document.getElementById('<%= SelectCase.ClientID %>').focus();
            return false;} 
       if (document.getElementById('<%= AdvanceAmount_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= AdvanceAmount_Input.ClientID %>').value<0) {
            alert('提示：请填写正确的支出金额！');
            document.getElementById('<%= AdvanceAmount_Input.ClientID %>').focus();
            return false;} 
   return true;
   }
    </script>
</asp:Content>
