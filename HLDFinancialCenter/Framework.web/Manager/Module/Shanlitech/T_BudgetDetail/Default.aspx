<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
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
                       <asp:TemplateField HeaderText="预算项目" SortExpression="ProjID">
                        <ItemTemplate>
                            <%# Shanlitech_Location.BusinessFacadeShanlitech_Location.GetProjectBudgetFormat(Shanlitech_Location.BusinessFacadeShanlitech_Location.T_ProjectBudgetDisp( Convert.ToInt32(Eval("ProjID").ToString())))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="器材名称" SortExpression="EquipmentName" DataField="EquipmentName" />
                    <asp:BoundField HeaderText="预算收入" SortExpression="BudgetRevenue" DataField="BudgetRevenue" />
                     <asp:TemplateField HeaderText="预算单价" SortExpression="BudgetPrice">
                        <ItemTemplate>
                            <%# Eval("BudgetPrice") +"/"+ Eval("Measurement")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="预算数量" SortExpression="BudgetNumber" DataField="BudgetNumber" />
                    <asp:BoundField HeaderText="预算支出" SortExpression="BudgetExpenditure" DataField="BudgetExpenditure" />
                </Columns>
            </asp:GridView>
              
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
           <FrameWorkWebControls:TabOptionItem ID="TabOptionItem3" runat="server" Tab_Name="批量导入预算明细">
                第一步：下载<a href="../../../Public/ZCYSMX.xlsx">支出预算明细模板</a>
                <asp:Panel runat="server" ID="panel1">
                    第二步：在下载的模板中按照规定格式填写
                </asp:Panel>
                <asp:Panel runat="server" ID="panelDiv">
                    第三步：将修改好的文件导入系统<asp:FileUpload ID="Filename" runat="server" />
                </asp:Panel>
                <asp:Panel runat="server" ID="panel2">
                    第四步：点击确定
                    <asp:Button ID="btnUpdateUserName" runat="server" Text="确定" OnClick="btnImportYSMX_Click" />
                </asp:Panel>
                <asp:Label ID="Literal" runat="server" Text="" ForeColor="Red"></asp:Label>
            </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        所属项目</td>
                    <td class="table_none">
                     
                    <asp:DropDownList ID="ProjID_Input" title="请选择所属项目！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>                     
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
