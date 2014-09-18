<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecordCunDang.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="核销待存档单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="核销待存档单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加核销待存档单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        所属经费申请单</td>
                    <td class="table_none">
                     
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <asp:HiddenField ID="Protype_Hidden" runat="server" /><!-- 所属项目id -->
                        <%--<input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />--%>
                    </td>
                </tr>
                 <tr>
                    <td class="table_body">
                        发票联</td>
                    <td class="table_none"> 
                     <asp:FileUpload ID="InvoiceFolder_Upload" runat="server" />
                     <asp:Label ID="InvoiceFolder_Disp" runat="server"></asp:Label>
                        <%--<asp:Image ID="imag_Fapiao" runat="server" Width="200" Height="100" />--%>
                     </td>
                </tr>

                <tr>
                    <td class="table_body">
                        合同协议</td>
                    <td class="table_none">
                      <asp:FileUpload ID="ContractFolder_Upload" runat="server"  />
                   
                        <%--<asp:Image ID="ContractFolder_Image" runat="server" Width="200" Height="100" />--%>
                       <asp:Label ID="ContractFolder_Disp" runat="server"></asp:Label>
                       </td>
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
                 
                  <tr>
                    <td class="table_body">
                        存档原因</td>
                    <td class="table_none">
                    <asp:TextBox ID="CunDangState_Input" title="请输入存档原因~500:" runat="server"></asp:TextBox>                    
                        <asp:Label ID="CunDangState_Disp" runat="server"></asp:Label></td>
                </tr>          
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="存档" OnClick="Button1_Click" OnClientClick="return ValidateData();" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
                                                <h6>资产库列表如下：</h6>
             <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="所属项目" SortExpression="ProjectNO">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetProjectNameByID(Convert.ToInt32(Eval("ProjectNO")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="器材名称" SortExpression="EquipmentName" DataField="EquipmentName" />
                    <asp:BoundField HeaderText="型号" SortExpression="Model" DataField="Model" />
                    <asp:BoundField HeaderText="入库时间" SortExpression="StorageTime" DataField="StorageTime" />
                     <asp:TemplateField HeaderText="申请人" SortExpression="Applicant">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetUserNameByID((int)Eval("Applicant"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="库存资产编码号" SortExpression="CodeNO" DataField="CodeNO" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
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
        
          function ValidateData(){
     
            if (document.getElementById('<%= InvoiceFolder_Upload.ClientID %>').value == "") {
            alert('提示：请上传发票联！');
            document.getElementById('<%= InvoiceFolder_Upload.ClientID %>').focus();
            return false;} 
            if (document.getElementById('<%= ContractFolder_Upload.ClientID %>').value == "") {
            alert('提示：请上传合同协议！');
            document.getElementById('<%= ContractFolder_Upload.ClientID %>').focus();
            return false;} 
         
       return true;
       }
       
    
    </script>
    
</asp:Content>
