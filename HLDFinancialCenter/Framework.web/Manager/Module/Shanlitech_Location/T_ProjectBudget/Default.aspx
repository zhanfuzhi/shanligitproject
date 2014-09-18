<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectBudget.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="项目预算列表" HeadTitleTxt="项目预算">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="项目预算" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="项目预算列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="项目编号" SortExpression="ProjectNO" DataField="ProjectNO" />
                    <asp:BoundField HeaderText="所属科目" SortExpression="SubjectNO" DataField="SubjectNO" />
                    <asp:BoundField HeaderText="所属类别" SortExpression="ClassNO" DataField="ClassNO" />
                    <asp:BoundField HeaderText="所属年度" SortExpression="AnnualNO" DataField="AnnualNO" />
                    <asp:BoundField HeaderText="预算收入" SortExpression="BudgetRevenue" DataField="BudgetRevenue" />
                    <asp:BoundField HeaderText="预算支出" SortExpression="BudgetExpenditure" DataField="BudgetExpenditure" />
                    <asp:BoundField HeaderText="经费余额" SortExpression="BalanceAmount" DataField="BalanceAmount" />
                    <asp:BoundField HeaderText="项目组长" SortExpression="Leader" DataField="Leader" />
                    <asp:BoundField HeaderText="指定承办人" SortExpression="Undertaker" DataField="Undertaker" />
                    <asp:BoundField HeaderText="状态(0为正常，9为删除)" SortExpression="State" DataField="State" />
                    <asp:BoundField HeaderText="创建时间" SortExpression="CreateTime" DataField="CreateTime" />
                    <asp:BoundField HeaderText="更新时间" SortExpression="UpdateTime" DataField="UpdateTime" />
                    <asp:BoundField HeaderText="递增排序" SortExpression="Sort" DataField="Sort" />
                    <asp:BoundField HeaderText="所在部门" SortExpression="DepartmentID" DataField="DepartmentID" />
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
                        项目编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入项目编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        所属科目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SubjectNO_Input" title="请输入所属科目~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        所属类别</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassNO_Input" title="请输入所属类别~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        所属年度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AnnualNO_Input" title="请输入所属年度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                        项目组长</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Leader_Input" title="请输入项目组长~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        指定承办人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Undertaker_Input" title="请输入指定承办人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        状态(0为正常，9为删除)</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="State_Input" title="请输入状态(0为正常，9为删除)~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateTime_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        更新时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpdateTime_Input" title="请输入更新时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                    <td class="table_body">
                        所在部门</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DepartmentID_Input" title="请输入所在部门~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
