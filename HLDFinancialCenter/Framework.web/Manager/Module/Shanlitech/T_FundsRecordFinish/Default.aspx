<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecordFinish.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>


    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="经费使用存档单列表" HeadTitleTxt="经费使用存档单单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="false" ButtonName="经费使用存档单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="经费使用存档单列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" 
                OnRowCreated="GridView1_RowCreated" onrowcommand="GridView1_RowCommand" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="预算项目" SortExpression="ProjID">
                        <ItemTemplate>
                        <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(Shanlitech_Location.BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp((int)Eval("ProjID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="经费余额" SortExpression="BalanceAmount" DataField="BalanceAmount" />
                    <asp:BoundField HeaderText="支出金额" SortExpression="AdvanceAmount" DataField="AdvanceAmount" />
                    <asp:TemplateField HeaderText="批准人" SortExpression="Approver">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetUserNameByID((int)Eval("Approver"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="批准时间" SortExpression="ApprovalTime" DataField="ApprovalTime" />
                  <%--    <asp:TemplateField HeaderText="其它操作">
                        <ItemTemplate>
                           <asp:LinkButton ID="LinkButton1" runat="server" CommandName="ChexiaoCunDang" CommandArgument='<%# Eval("ID") %>'
                                OnClientClick='javascript:return confirm("确定要撤销存档吗？");' Text="撤销存档">
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                  </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" style="display:none;" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                     
                        <asp:Label ID="ProjID_Disp" runat="server" ></asp:Label>
                        <asp:HiddenField ID="ProjID_Hidden" runat="server" />
                        <input id="SelectCase" type="button" value="选择已有项目" onclick="javascript:selectProjectBudget();" runat="server" />
                    
                        </td>
                </tr>
             
                <tr>
                    <td class="table_body">
                        申请用途</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UseRemark_Input" title="请输入申请用途~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        支出金额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AdvanceAmount_Input" title="请输入支出金额~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                       <asp:DropDownList ID="Applicant_Input" title="请选择申请人！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>                     
                        </td>
                </tr>
               
                <tr style="display:none;">
                    <td class="table_body">
                        状态</td>
                    <td class="table_none">
                     <asp:DropDownList ID="State_Input" title="请选择状态！" runat="server" CssClass="text_input"
                            Width="120px">
                             <asp:ListItem Text="所有状态" Value=""></asp:ListItem>
                             <asp:ListItem Text="流转状态" Value="0"></asp:ListItem>
                             <asp:ListItem Text="存档状态" Value="1"></asp:ListItem>
                             <asp:ListItem Text="删除" Value="9"></asp:ListItem>
                     </asp:DropDownList>  
                    
                        </td>
                </tr>
              
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
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


<!--

function SelectAll()
{
   var e=document.getElementsByTagName("input");
   var IsTrue;
   if(document.getElementById("CheckboxAll").value=="0")
　 {
　　 IsTrue=true;
　　 document.getElementById("CheckboxAll").value="1"
　 }
　 else
　 {
　　IsTrue=false;
　　document.getElementById("CheckboxAll").value="0"
　　}
　　
　for(var i=0;i<e.length;i++)
　{
　　if (e[i].type=="checkbox")
　　{
　　   e[i].checked=IsTrue;
　　}
　}
}
function deleteop()
{
    var checkok = false;
    var e=document.getElementsByTagName("input");
    for(var i=0;i<e.length;i++)
　  {
　     if (e[i].type=="checkbox")
　　     {
　　         if (e[i].checked==true)
　　         {
　　             checkok = true;
　　             break;　　             
　　         }
　　     }  
　  }
　  if (checkok) 
        return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
    else
    {
        
        alert("请选择要删除的记录!");
        return false;
    }
}
// -->
    </script>

</asp:Content>
