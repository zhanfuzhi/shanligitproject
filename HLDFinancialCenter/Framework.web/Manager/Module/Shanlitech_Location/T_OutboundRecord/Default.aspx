<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_OutboundRecord.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="出库表单列表" HeadTitleTxt="出库表单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="出库表单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="出库表单列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="项目名称" SortExpression="ProjectNO" DataField="ProjectNO" />
                    <asp:BoundField HeaderText="器材名称" SortExpression="EquipmentName" DataField="EquipmentName" />
                    <asp:BoundField HeaderText="型号" SortExpression="Model" DataField="Model" />
                    <asp:BoundField HeaderText="数量" SortExpression="OutboundNumber" DataField="OutboundNumber" />
                    <asp:BoundField HeaderText="结余" SortExpression="BalanceNumber" DataField="BalanceNumber" />
                    <asp:BoundField HeaderText="领取时间" SortExpression="OutboundTime" DataField="OutboundTime" />
                    <asp:BoundField HeaderText="申请人" SortExpression="Applicant" DataField="Applicant" />
                    <asp:BoundField HeaderText="批准人" SortExpression="Approver" DataField="Approver" />
                    <asp:BoundField HeaderText="信息完整性校验码" SortExpression="IntegrityCheckCode" DataField="IntegrityCheckCode" />
                    <asp:BoundField HeaderText="Remark" SortExpression="Remark" DataField="Remark" />
                    <asp:BoundField HeaderText="库存资产编码号" SortExpression="CodeNO" DataField="CodeNO" />
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
                        项目名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入项目名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                        型号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Model_Input" title="请输入型号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OutboundNumber_Input" title="请输入数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        结余</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BalanceNumber_Input" title="请输入结余~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        领取时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OutboundTime_Input" title="请输入领取时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Applicant_Input" title="请输入申请人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Approver_Input" title="请输入批准人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        信息完整性校验码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="IntegrityCheckCode_Input" title="请输入信息完整性校验码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        Remark</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入Remark~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        库存资产编码号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CodeNO_Input" title="请输入库存资产编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
