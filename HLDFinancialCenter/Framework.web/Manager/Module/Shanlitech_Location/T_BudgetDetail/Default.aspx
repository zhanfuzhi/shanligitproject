<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_BudgetDetail.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="预算明细列表" HeadTitleTxt="预算明细">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="预算明细" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="预算明细列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="所属项目" SortExpression="ProjID" DataField="ProjID" />
                    <asp:BoundField HeaderText="器材名称" SortExpression="EquipmentName" DataField="EquipmentName" />
                    <asp:BoundField HeaderText="预算收入" SortExpression="BudgetRevenue" DataField="BudgetRevenue" />
                    <asp:BoundField HeaderText="计量单位" SortExpression="Measurement" DataField="Measurement" />
                    <asp:BoundField HeaderText="预算单价" SortExpression="BudgetPrice" DataField="BudgetPrice" />
                    <asp:BoundField HeaderText="预算数量" SortExpression="BudgetNumber" DataField="BudgetNumber" />
                    <asp:BoundField HeaderText="预算支出" SortExpression="BudgetExpenditure" DataField="BudgetExpenditure" />
                    <asp:BoundField HeaderText="经费余额" SortExpression="BalanceAmount" DataField="BalanceAmount" />
                    <asp:BoundField HeaderText="供货单位" SortExpression="Supplier" DataField="Supplier" />
                    <asp:BoundField HeaderText="备注" SortExpression="Remark" DataField="Remark" />
                    <asp:BoundField HeaderText="递增排序" SortExpression="Sort" DataField="Sort" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        所属项目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjID_Input" title="请输入所属项目~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        器材名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="EquipmentName_Input" title="请输入器材名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        预算收入</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetRevenue_Input" title="请输入预算收入~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        计量单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Measurement_Input" title="请输入计量单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        预算单价</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetPrice_Input" title="请输入预算单价~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        预算数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BudgetNumber_Input" title="请输入预算数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                </tr>
                <tr>
                    <td class="table_body">
                        供货单位</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Supplier_Input" title="请输入供货单位~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入备注~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        递增排序</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sort_Input" title="请输入递增排序~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
