<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="E_DetectResult.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect.E_DetectResult"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceDetectHelp.aspx#p4'>帮助</a>"
         HeadOPTxt="电气设备检定记录列表" HeadTitleTxt="电气设备检定记录">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="电气设备检定记录" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="电气设备检定记录列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="设备检测记录" SortExpression="DeviceDetectID" DataField="DeviceDetectID" />--%>
                    <%--<asp:BoundField HeaderText="功能代码" SortExpression="FunctionCode" DataField="FunctionCode" />--%>
                    <asp:TemplateField HeaderText="量程" SortExpression="TestRange">
                        <ItemTemplate>
                            <%#Eval("TestRange")%><%#Eval("Unit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="频率" SortExpression="Frequency" >
                        <ItemTemplate>
                            <%#Eval("Frequency")%><%#Eval("FrequencyUnit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标准值" SortExpression="StandardValue">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRoundFix(Convert.ToDouble(Eval("StandardValue")), _RoundLen)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="测试实际值" SortExpression="TestedValue">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRoundFix(Convert.ToDouble(Eval("TestedValue")), _RoundLen)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最大允许误差" SortExpression="MaxPerMissibleError">
                        <ItemTemplate>
                            <%#Eval("MissibleErrorSymbol")%>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTML(Convert.ToDouble(Eval("MaxPerMissibleError")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="实际误差" SortExpression="TestedPerissibleError">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTML(Convert.ToDouble(Eval("TestedPerissibleError")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="检测结论" SortExpression="Result" DataField="Result" />
                    
                    
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <%--<tr>
                    <td class="table_body">
                        设备检测记录</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceDetectID_Input" title="请输入设备检测记录~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <tr>
                    <td class="table_body">
                        功能代码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FunctionCode_Input" title="请输入功能代码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        检测结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Result_Input" title="请输入检测结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        标准值</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StandardValue_Input" title="请输入标准值~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        量程</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestRange_Input" title="请输入量程~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
