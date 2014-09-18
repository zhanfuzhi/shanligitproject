<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="SelectProjectBudget.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord.SelectProjectBudget"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="项目预算列表" HeadTitleTxt="项目预算">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="false" ButtonName="项目预算" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="项目预算列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="经费类别" SortExpression="ClassNO">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetClassNameByID(Convert.ToInt32(Eval("ClassNO").ToString()))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="科目类别" SortExpression="SubjectNO">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetSubjectNameByID(Convert.ToInt32(Eval("SubjectNO")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="项目类别" SortExpression="ProjectNO">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetProjectNameByID(Convert.ToInt32(Eval("ProjectNO")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="年度编号" SortExpression="AnnualNO" DataField="AnnualNO" />
                    
                      <asp:TemplateField HeaderText="项目组长" SortExpression="Leader">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetUserNameByID((int)Eval("Leader"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                      <asp:TemplateField HeaderText="指定承办人" SortExpression="Undertaker">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetUserNameByID((int)Eval("Undertaker"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="预算支出" SortExpression="BudgetExpenditure" DataField="BudgetExpenditure" />
                    <asp:BoundField HeaderText="经费余额" SortExpression="BalanceAmount" DataField="BalanceAmount" />                    
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" CssClass="button_bak" runat="server" Text="选择" OnClick="Button2_Click" OnClientClick="return checkValidate()" />
            
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                  <tr>
                    <td class="table_body">
                        经费类别</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ClassNO_Input" title="请选择经费类别！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>    
                    </td>                
                 </tr>
                   <tr>
                    <td class="table_body">
                        预算科目</td>
                    <td class="table_none">
                      <asp:DropDownList ID="SubjectNO_Input" title="请选择预算科目！" runat="server" CssClass="text_input"
                            Width="120px">   
                      </asp:DropDownList>      
                    </td>                    
                </tr>
                <tr>
                    <td class="table_body">
                        预算项目</td>
                    <td class="table_none">
                      <asp:DropDownList ID="ProjectNO_Input" title="请选择预算项目！" runat="server" CssClass="text_input"
                            Width="120px">
                      </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        年度编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AnnualNO_Input" title="请输入所属年度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
              <%--  <tr>
                    <td class="table_body">
                        预算收入</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetRevenue_Input" title="请输入预算收入~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        预算支出</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetExpenditure_Input" title="请输入预算支出~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        经费余额</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BalanceAmount_Input" title="请输入经费余额~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <tr>
                    <td class="table_body">
                        项目组长</td>
                    <td class="table_none">
                        <asp:DropDownList ID="Leader_Input" title="请选择项目组长！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>  
                    </td>                  
                </tr>

                <tr>
                    <td class="table_body">
                        指定承办人</td>
                    <td class="table_none">
                        <asp:DropDownList ID="Undertaker_Input" title="请选择指定承办人！" runat="server" CssClass="text_input"
                            Width="120px">
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
function checkValidate(){
    var elms = document.getElementsByName("radio");
    var isSelected = false;
    for(var i=0;i<elms.length;i++){
        if(elms[i].checked){
            isSelected=true;
            break;
        }
    }
    
    if(!isSelected){
        var cf = confirm("请选择预算项目！");
        if(cf)return false;
    }
    return true;
    
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
