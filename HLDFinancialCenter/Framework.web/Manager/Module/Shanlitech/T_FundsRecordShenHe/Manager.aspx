<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecordShenHe.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="经费使用待审核单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费使用待审核单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加经费使用待审核单">
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
              <%--  <tr runat="server" id="tr_Applicant">
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Checker_Disp" runat="server"></asp:Label></td>
                </tr>--%>

                  <tr runat="server" id="tr_Applicant">
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>
                 <tr runat="server" id="tr_TransferState">
                    <td class="table_body">
                        流转状态</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="TransferState_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr_CheckTimeTime">
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="AppricationTime_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="tr1">
                    <td class="table_body">
                        是否通过</td>
                    <td class="table_none">
                        <asp:RadioButtonList ID="CheckState_Input" runat="server"  CssClass="text_input" RepeatDirection="Horizontal">
                        <asp:ListItem Text="审核通过" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="审核不通过" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                        
                        <asp:Label ID="CheckState_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr>
                    <td class="table_body">
                        审核原因</td>
                    <td class="table_none">
                    <asp:TextBox ID="ShenHeState_Input" title="请输入审核原因~500:" runat="server"></asp:TextBox>                    
                        <asp:Label ID="ShenHeState_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="重填" 
                            onclick="Button2_Click" />
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
