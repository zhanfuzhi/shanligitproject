<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecordFinish.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="经费使用存档单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费使用存档单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加经费使用存档单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                        <asp:Label ID="ProjID_Disp" runat="server" ></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" visible="false" />
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
                     
                    
                        <asp:Label ID="UseRemark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        支出金额</td>
                    <td class="table_none">
                     
                    
                        <asp:Label ID="AdvanceAmount_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_Applicant">
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>
               <tr runat="server" id="tr_AppricationTime">
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="AppricationTime_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr2">
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Checker_Disp" runat="server"></asp:Label></td>
                </tr>
               <tr runat="server" id="tr3">
                    <td class="table_body">
                        审核时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="CheckerTime_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr4">
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>
               <tr runat="server" id="tr5">
                    <td class="table_body">
                        批准时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="ApprovalTime_Disp" runat="server"></asp:Label></td>
                </tr>
                <%-- <tr runat="server" id="tr_TransferState">
                    <td class="table_body">
                        流转状态</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="TransferState_Disp" runat="server"></asp:Label></td>
                </tr>
           
                <tr runat="server" id="tr1">
                    <td class="table_body">
                        批准状态</td>
                    <td class="table_none">
                        <asp:DropDownList runat="server" ID="PiZhunState_Input" CssClass="text_input">
                         <asp:ListItem Text="撤回批准" Value="0"></asp:ListItem>
                         <asp:ListItem Text="批准" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:Label ID="PiZhunState_Disp" runat="server"></asp:Label></td>
                </tr>--%>
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">
    function selectProjectBudget(){
    showPopWin('已有预算项目列表', 'SelectProjectBudget.aspx',700, 450, ReloadPage, true, true);
    }
function ReloadPage(id,text,balance,proid){
   document.getElementById("<%=ProjID_Hidden.ClientID %>").value=id;
   document.getElementById("<%=ProjID_Disp.ClientID %>").innerText=text;
   document.getElementById("<%=BalanceAmount_Disp.ClientID %>").innerText=balance;
   document.getElementById("<%=BalanceAmount_Hidden.ClientID %>").value=balance;
   
   
}
    </script>
</asp:Content>
