<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Department_Device.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeptDeviceHelp.aspx'>帮助</a>"
         HeadOPTxt="检定设备列表" HeadTitleTxt="检定设备">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="检定设备" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="检定设备列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="部门名称" SortExpression="DepartmentID" DataField="DepartmentID" />
                    <asp:BoundField HeaderText="设备编号" SortExpression="DeviceID" DataField="DeviceID" />--%>
                    <asp:TemplateField SortExpression="DepartmentID" HeaderText="检定部门"> 
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDeptNameByID(Convert.ToInt32(Eval("DepartmentID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="实验室" SortExpression="Laboratory" DataField="Laboratory" />
                    <asp:TemplateField SortExpression="DeviceID" HeaderText="设备编号"> 
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDeviceNumByDeviceID(Convert.ToInt32(Eval("DeviceID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="设备名称" SortExpression="DeviceName" DataField="DeviceName" />
                    <%--<asp:BoundField HeaderText="设备类型" SortExpression="DeviceType" DataField="DeviceType" />--%>
                    <asp:TemplateField HeaderText="设备类型"> 
                        <ItemTemplate>
                             <%#ShanliTech_HLD_Business.ToolMethods.GetDictionaryNameByID(Eval("DeviceType").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="检定状态">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetStringByState(Convert.ToInt32(Eval("State")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="录入人姓名">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetUserNameByID(Convert.ToInt32(Eval("Inputter")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="录入时间" SortExpression="IntputTime" DataField="IntputTime" />
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
                        设备类型</td>
                    <td class="table_none">
                        <asp:DropDownList ID="DeviceType_DropDown" runat="server"></asp:DropDownList>
                        <%--<asp:TextBox ID="DeviceType_Input" title="请输入设备类型[标准设备,被检设备]~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body">
                        检测状态</td>
                    <td class="table_none">
                        <asp:DropDownList ID="DetectState_DropDown" runat="server">
                            <asp:ListItem Value="-1">请选择检测状态</asp:ListItem>
                            <asp:ListItem Value="0">待检测</asp:ListItem>
                            <asp:ListItem Value="1">检测完成</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备名称</td>
                    <td class="table_none">
                        <asp:TextBox ID="DeviceName_Input" title="请输入设备编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                        <%--<asp:TextBox ID="DeviceID_Input" title="请输入设备编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
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
