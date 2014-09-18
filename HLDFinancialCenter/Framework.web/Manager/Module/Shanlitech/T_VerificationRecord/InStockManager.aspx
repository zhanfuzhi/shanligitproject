<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="InStockManager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecord.InStockManager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="入库表单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="入库表单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加入库表单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr style="display:none;">
                    <td class="table_body">
                        所属核销</td>
                    <td class="table_none">
                        <asp:Label ID="VeriID_Disp" runat="server" ></asp:Label>
                        <asp:HiddenField ID="VeriID_Hidden" runat="server" />
                        <asp:HiddenField ID="VeritypeID_Hidden" runat="server" />
                        <asp:HiddenField ID="PayAmount_Hidden" runat="server" />
                        <asp:HiddenField ID="Applicant_Hidden" runat="server" />
                        <asp:HiddenField ID="Approver_Hidden" runat="server" />
                        <input id="SelectCase" type="button" value="选择已有核销单" onclick="javascript:selectProjectBudget();" runat="server" />                    
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
                                         
                        <asp:Label ID="StorageTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>

               <tr>
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        实际支出</td>
                    <td class="table_none">
                     
                        <asp:Label ID="PayAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入Remark~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Remark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        库存资产编码号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CodeNO_Input" title="请输入库存资产编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CodeNO_Disp" runat="server"></asp:Label></td>
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
    showPopWin('已有核销单列表', '../ProjectBudgetRadio/SelectT_VerificationRecord.aspx',700, 450, ReloadPage, true, true);
    }
function ReloadPage(id,text,balance,proid,applicant,applicantname,approver,approvername){
   //审核单
   document.getElementById("<%=VeriID_Hidden.ClientID %>").value=id;
   document.getElementById("<%=VeriID_Disp.ClientID %>").innerText=text;
   //项目id
    document.getElementById("<%=VeritypeID_Hidden.ClientID %>").value=proid;
   //实际支付金额
    document.getElementById("<%=PayAmount_Hidden.ClientID %>").value=balance;
    
       document.getElementById("<%=PayAmount_Disp.ClientID %>").innerText=balance;
     //申请人 批准人
            document.getElementById("<%=Applicant_Hidden.ClientID %>").value=applicant;
   document.getElementById("<%=Applicant_Disp.ClientID %>").innerText=applicantname;
   
   document.getElementById("<%=Approver_Hidden.ClientID %>").value=approver;
   document.getElementById("<%=Approver_Disp.ClientID %>").innerText=approvername;
     
}


  function ValidateData(){
            if (document.getElementById('<%= StorageNumber_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= StorageNumber_Input.ClientID %>').value<0) {
            alert('提示：请填写正确的数量！');
            document.getElementById('<%= StorageNumber_Input.ClientID %>').focus();
            return false;} 
               if (document.getElementById('<%= UnitPrice_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= UnitPrice_Input.ClientID %>').value<0) {
            alert('提示：请填写正确的单价！');
            document.getElementById('<%= UnitPrice_Input.ClientID %>').focus();
            return false;}
       return true;
       }
       
    </script>
</asp:Content>
