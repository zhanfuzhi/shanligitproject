<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecordFinish.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="核销存档单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="核销存档单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加核销存档单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        所属经费申请单</td>
                    <td class="table_none">
                     
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <asp:HiddenField ID="Protype_Hidden" runat="server" /><!-- 所属项目id -->
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        发票联</td>
                    <td class="table_none"> 
                     <asp:FileUpload ID="InvoiceFolder_Upload" runat="server" onchange="changefapiao(this)" />
                     <asp:Label ID="InvoiceFolder_Disp" runat="server"></asp:Label>
                        <asp:Image ID="imag_Fapiao" runat="server" Width="200" Height="100" />
                     </td>
                </tr>

                <tr>
                    <td class="table_body">
                        合同协议</td>
                    <td class="table_none">
                      <asp:FileUpload ID="ContractFolder_Upload" runat="server" onchange="changehetong(this)" />
                   
                        <asp:Image ID="ContractFolder_Image" runat="server" Width="200" Height="100" />
                       <asp:Label ID="ContractFolder_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        实际支出</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="PayAmount_Input" title="请输入实际支出~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="PayAmount_Disp" runat="server"></asp:Label></td>
                </tr>
                          <tr runat="server" id="tr_Undertaker">
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                        <asp:Label ID="Undertaker_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr_CreateTime">
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                        <asp:Label ID="CreateTime_Disp" runat="server"></asp:Label></td>
                </tr>  
                 <tr runat="server" id="tr">
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                        <asp:Label ID="Check_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr2">
                    <td class="table_body">
                        审核时间</td>
                    <td class="table_none">
                        <asp:Label ID="CheckTime_Disp" runat="server"></asp:Label></td>
                </tr>  
                 <tr runat="server" id="tr1">
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>
                  <tr runat="server" id="tr3">
                    <td class="table_body">
                        批准时间</td>
                    <td class="table_none">
                        <asp:Label ID="ApproverTime_Disp" runat="server"></asp:Label></td>
                </tr>   
                 <tr runat="server" id="tr_ShenHeNote">
                    <td class="table_body">
                        审核备注</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="ShenHeNote_Disp" runat="server"></asp:Label></td>
                </tr>
                 <tr runat="server" id="tr_PiZhunNote">
                    <td class="table_body">
                        批准备注</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="PiZhunNote_Disp" runat="server"></asp:Label></td>
                </tr>
                                <tr runat="server" id="tr_CunDangNote">
                    <td class="table_body">
                        存档备注</td>
                    <td class="table_none">
                                        
                        <asp:Label ID="CunDangNote_Disp" runat="server"></asp:Label></td>
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
       <script language="javascript" type="text/javascript">
        function selectProjectBudget(){
         showPopWin('已有预算项目列表', '../ProjectBudgetRadio/SelectProjectBudget.aspx',700, 450, ReloadPage, true, true);
        }
        
        function ReloadPage(id,text,balance,proid){
           document.getElementById("<%=ProjID_Hidden.ClientID %>").value=id;
           document.getElementById("<%=ProjID_Disp.ClientID %>").innerText=text;  
           document.getElementById("<%=Protype_Hidden.ClientID %>").value=proid;
        }
        
    function changefapiao(thisobj)
    {
         var all=thisobj.value.split("\\");
         var name=all[all.length-1];
    }
    
     function changehetong(thisobj)
    {
         var all=thisobj.value.split("\\");
         var name=all[all.length-1];
         document.getElementById("<%=ContractFolder_Disp.ClientID %>").innerText=name;
    }
    
    </script>
    
</asp:Content>
