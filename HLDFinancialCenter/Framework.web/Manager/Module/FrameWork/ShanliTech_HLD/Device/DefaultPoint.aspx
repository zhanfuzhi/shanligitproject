<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="DefaultPoint.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device.DefaultPoint"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
<style type="text/css">
.td_txt
{
	width:20%;
}
.td_input
{
	width:30%;
}
</style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/FunctionPointHelp.aspx'>帮助</a>"
         HeadOPTxt="功能检定点列表" HeadTitleTxt="功能检定点">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="功能检定点列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="ManagerPoint.aspx?IDX=<%#Eval("ID")%>&CMD=List&FunctionID=<%#Eval("FunctionID") %>"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="设备功能名称">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetFunctionNameByFunctionID(Convert.ToInt32(Eval("FunctionID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="设备功能代码" SortExpression="FunctionCode" DataField="FunctionCode" />--%>
                    <asp:TemplateField HeaderText="量程">
                        <ItemTemplate>
                            <%#Eval("TestRange")%><%#Eval("Unit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="标准值">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.NumberFormatUtils.ToSignAndRound(Convert.ToDouble(Eval("StandardValue")),2)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最大允许误差">
                        <ItemTemplate>
                            <%#Eval("MissibleErrorSymbol")%><%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTML(Convert.ToDouble(Eval("ValuePerMissibleErrorName")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="轻击位移允许值" DataField="ChangePerMissibleError" />
                    <asp:BoundField HeaderText="回程误差" DataField="H_PerMissibleError" />
                     <asp:TemplateField HeaderText="顺序调整">
                        <ItemTemplate>
                            <a href="?CMD=Up&PointID=<%#Eval("ID") %>&FunctionID=<%=FunctionID %>">上移</a>
                            <a href="?CMD=Down&PointID=<%#Eval("ID") %>&FunctionID=<%=FunctionID %>">下移</a>
                        </ItemTemplate>
                    </asp:TemplateField>
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
                        设备功能</td>
                    <td class="table_none">
                        <asp:DropDownList ID="FunctionID_DropDown" runat="server"></asp:DropDownList>
                        </td>
                </tr>--%>
                <%--<tr>
                    <td class="table_body">
                        设备功能编码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FunctionCode_Input" title="请输入设备功能编码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <tr>
                    <td class="table_body td_txt">
                        量程</td>
                    <td class="table_none td_input">
                        <asp:TextBox ID="TestRange_Input" title="请输入量程~float" runat="server" CssClass="text_input"></asp:TextBox>
                    </td>
                    <td class="table_body td_txt">
                        标准值</td>
                    <td class="table_none td_input">
                        <asp:TextBox ID="StandardValue_Input" title="请输入标准值~float" runat="server" CssClass="text_input"></asp:TextBox></td>
                </tr>
                <%--<tr>
                    <td class="table_body">
                        操作码</td>
                    <td class="table_none" colspan="3">
                        <asp:TextBox ID="CommandCode_Input" title="请输入操作码~50:" runat="server" CssClass="text_input"></asp:TextBox></td>
                </tr>--%>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

<script type="text/javascript" src="../../../inc/FineMessBox/js/common.js"></script>
<script type="text/javascript" src="../../../inc/FineMessBox/js/subModal.js"></script>
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

rnd.today=new Date(); 
    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
    function AlertMessageBox(Messages)
    {
        DispClose = false; 
        alert(Messages);
        setTimeout("reload()",100)
        //window.location.reload();
        //window.location.href = location.href+"?"+rand(1000000);
        
    }
     function reload()
    {
        var pre = window.location.href;
        if(pre.indexOf('?')>0)
            pre=pre+"&";
        else
            pre=pre+"?";    
        window.location.href = pre+rand(1000000);
    }
    </script>

</asp:Content>
