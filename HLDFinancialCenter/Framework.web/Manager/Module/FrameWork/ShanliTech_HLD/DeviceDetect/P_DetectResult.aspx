<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="P_DetectResult.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect.P_DetectResult"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceDetectHelp.aspx?#p4'>帮助</a>"
         HeadOPTxt="压力设备检定记录列表" HeadTitleTxt="压力设备检定记录">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="压力设备检定记录" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="压力设备检定记录列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="检定记录编号" SortExpression="DeviceDetectID" DataField="DeviceDetectID" />--%>
                    <%--<asp:BoundField HeaderText="设备功能编号" SortExpression="DeviceFunctionID" DataField="DeviceFunctionID" />--%>
                    <%--<asp:BoundField HeaderText="单位" SortExpression="Unit" DataField="Unit" />--%>
                    <asp:TemplateField HeaderText="标准压力" SortExpression="StandardValue" >
                        <ItemTemplate>
                            <%#Eval("StandardValue")%>&nbsp;&nbsp;<%#Eval("Unit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <%--被检表轻敲后的示值--%>
                    <asp:BoundField HeaderText="升压读数" SortExpression="UpValue" DataField="UpValue" />
                    <asp:BoundField HeaderText="降压读数" SortExpression="DownValue" DataField="DownValue" />
                    <asp:TemplateField HeaderText="最大允许误差" SortExpression="ValuePerMissibleError">
                        <ItemTemplate>
                            <%#Eval("MissibleErrorSymbol")%><%#Eval("ValuePerMissibleError")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="结论" SortExpression="ValueResult" DataField="ValueResult" />
                    
                    <%--轻敲指针变动量--%>
                    <asp:BoundField HeaderText="升压变动量" SortExpression="UpChange" DataField="UpChange" />
                    <asp:BoundField HeaderText="降压变动量" SortExpression="DownChange" DataField="DownChange" />
                    <asp:BoundField HeaderText="允许值" SortExpression="ChangePerMissibleError" DataField="ChangePerMissibleError" />
                    <asp:BoundField HeaderText="结论" SortExpression="ChangeResult" DataField="ChangeResult" />
                    
                    <%--回程误差--%>
                    <asp:BoundField HeaderText="测量值（回程误差）" SortExpression="HysteresisErrorValue" DataField="HysteresisErrorValue" />
                    <asp:BoundField HeaderText="允许值" SortExpression="H_PerMissibleError" DataField="H_PerMissibleError" />
                    <asp:BoundField HeaderText="结论" SortExpression="H_Result" DataField="H_Result" />
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
                        检定记录编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceDetectID_Input" title="请输入检定记录编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <%--<tr>
                    <td class="table_body">
                        设备功能代码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DeviceFunctionID_Input" title="请输入设备功能代码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                --%>
                
                <tr>
                    <td class="table_body">
                        轻敲示值结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ValueResult_Input" title="请输入轻敲示值结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
               <tr>
                    <td class="table_body">
                        变动量结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ChangeResult_Input" title="请输入变动量结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        回程误差结论</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="H_Result_Input" title="请输入回程误差结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
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
