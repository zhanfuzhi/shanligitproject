<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_VerificationRecord.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="核销申请单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="核销申请单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加核销申请单">
         <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        所属经费申请单</td>
                    <td class="table_none">
                     
                        <asp:Label ID="ProjID_Disp" runat="server"></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <asp:HiddenField ID="Protype_Hidden" runat="server" /><!-- 所属项目id -->
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />
                        <font style="color:Red;">*</font>
                    </td>
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
                        <asp:Button ID="Button1" runat="server"  Text="添加资产入库单" OnClick="Button1_Click" OnClientClick="return ValidateData();" />
                    </td>
                </tr>
            </table>
            <h6>资产库列表如下：</h6>
             <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="InStockManager.aspx?IDX=<%#Eval("ID")%>&CMD=List&VerID=<%#Eval("VeriID")%>"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
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
        
        
        function showInStock(){
         showPopWin('填写入库资产单', '../ProjectBudgetRadio/SelectProjectBudget.aspx',700, 450, ReInStockPage, true, true);
        }
        
        function ReInStockPage(id,text,balance,proid){
           document.getElementById("<%=ProjID_Hidden.ClientID %>").value=id;
           document.getElementById("<%=ProjID_Disp.ClientID %>").innerText=text;  
           document.getElementById("<%=Protype_Hidden.ClientID %>").value=proid;
        }
        
        
    
      function ValidateData(){
       if (document.getElementById('<%= ProjID_Hidden.ClientID %>').value == "0") {
            alert('提示：请选择所属经费申请单！');
            document.getElementById('<%= SelectCase.ClientID %>').focus();
            return false;} 
       return true;
       }
   
    </script>
    
</asp:Content>
