<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_FundsRecord.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="经费使用申请单列表" HeadTitleTxt="经费使用申请单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费使用申请单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="经费使用申请单列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="预算项目" SortExpression="ProjID" DataField="ProjID" />
                    <asp:BoundField HeaderText="经费余额" SortExpression="BalanceAmount" DataField="BalanceAmount" />
                    <asp:BoundField HeaderText="申请用途" SortExpression="UseRemark" DataField="UseRemark" />
                    <asp:BoundField HeaderText="支出金额" SortExpression="AdvanceAmount" DataField="AdvanceAmount" />
                    <asp:BoundField HeaderText="申请人" SortExpression="Applicant" DataField="Applicant" />
                    <asp:BoundField HeaderText="审核人" SortExpression="Checker" DataField="Checker" />
                    <asp:BoundField HeaderText="批准人" SortExpression="Approver" DataField="Approver" />
                    <asp:BoundField HeaderText="流转状态（0为申请状态，1为审核状态，2为批准状态）" SortExpression="TransferState" DataField="TransferState" />
                    <asp:BoundField HeaderText="状态（0为流转状态，1为存档状态，9为删除）" SortExpression="State" DataField="State" />
                    <asp:BoundField HeaderText="申请时间" SortExpression="AppricationTime" DataField="AppricationTime" />
                    <asp:BoundField HeaderText="审核时间" SortExpression="CheckTime" DataField="CheckTime" />
                    <asp:BoundField HeaderText="批准时间" SortExpression="ApprovalTime" DataField="ApprovalTime" />
                    <asp:BoundField HeaderText="信息完整性校验码" SortExpression="IntegrityCheckCode" DataField="IntegrityCheckCode" />
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
                        预算项目</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjID_Input" title="请输入预算项目~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                     
                        <asp:TextBox ID="Applicant_Input" title="请输入申请人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        审核人</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Checker_Input" title="请输入审核人~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
                        流转状态（0为申请状态，1为审核状态，2为批准状态）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TransferState_Input" title="请输入流转状态（0为申请状态，1为审核状态，2为批准状态）~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        状态（0为流转状态，1为存档状态，9为删除）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="State_Input" title="请输入状态（0为流转状态，1为存档状态，9为删除）~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        申请时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AppricationTime_Input" title="请输入申请时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        审核时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CheckTime_Input" title="请输入审核时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        批准时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ApprovalTime_Input" title="请输入批准时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
