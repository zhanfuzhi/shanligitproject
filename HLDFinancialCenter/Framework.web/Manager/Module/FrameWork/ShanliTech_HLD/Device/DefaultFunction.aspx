<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="DefaultFunction.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device.DefaultFunction"
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
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceFunctionHelp.aspx'>帮助</a>"
         HeadOPTxt="设备功能列表" HeadTitleTxt="设备功能">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="设备功能" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="设备功能列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="ManagerFunction.aspx?IDX=<%#Eval("ID")%>&CMD=List&DeviceID=<%#Eval("DeviceID") %>"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="功能代码" SortExpression="FunctionCode" DataField="FunctionCode" />--%>
                    <asp:BoundField HeaderText="功能名称" DataField="FunctionName" />
                    <asp:BoundField HeaderText="测量范围" DataField="TestRange" />
                    <asp:BoundField HeaderText="测量不确定度" DataField="AccuracyLevel" />
                    <asp:BoundField HeaderText="溯源有效期" DataField="SourceValidDate" />
                    
                    <asp:TemplateField HeaderText="设备编号">
                        <ItemTemplate>
                            <%# ShanliTech_HLD_Business.ToolMethods.GetDeviceNumByDeviceID(Convert.ToInt32(Eval("DeviceID"))) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="顺序调整">
                        <ItemTemplate>
                            <a href="?CMD=Up&FunctionID=<%#Eval("ID") %>&DeviceID=<%=DeviceID %>">上移</a>
                            <a href="?CMD=Down&FunctionID=<%#Eval("ID") %>&DeviceID=<%=DeviceID %>">下移</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作" ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <%--<a href="javascript:AlertPermitErrorWindow(<%#Eval("ID") %>)">量程误差数据</a>--%>
                            <%# PermitErrorLinkString(Eval("ID"),Eval("DeviceID"))%>
                            <a href="DefaultPoint.aspx?FunctionID=<%#Eval("ID") %>">查看功能检定点</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
            <%--<asp:Button ID="Button3" Visible="false" CssClass="button_bak" runat="server" Text="新增"  OnClick="Button3_Click" />--%>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <%--<tr>
                    <td class="table_body">
                        测量不确定度（最大允许误差/准确度等级）</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AccuracyLevel_Input" title="请输入测量不确定度（最大允许误差/准确度等级）~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <tr>
                    <td class="table_body td_txt">
                        功能名称</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="FunctionName_Input" title="请输入功能名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                    <td class="table_body td_txt">
                        功能代码</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="FunctionCode_Input" title="请输入功能代码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td class="table_body td_txt">
                        检定规程名称</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectBasisName_Input" title="请输入检定规程名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                    <td class="table_body td_txt">
                        规程代码 </td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectBasisCode_Input" title="请输入规程代码 ~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
               <%-- <tr>
                    <td class="table_body">
                        测量范围</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestRange_Input" title="请输入测量范围~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <%--<tr>
                    <td class="table_body td_txt">
                        设备编号</td>
                    <td class="table_none td_input" colspan="3">
                        <asp:DropDownList ID="DeviceID_DropDown" runat="server" ></asp:DropDownList>
                        <%--<asp:TextBox ID="DeviceID_Input" title="请输入设备编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%><%--
                        </td>
                 </tr>--%>
                 <tr>
                    <td class="table_body td_txt">
                        溯源有效期</td>
                    <td class="table_none td_input"  colspan="3">
                        <%--<span style="margin-right:5px;">起</span><asp:TextBox ID="SourceValidDate_Start_Input"  onfocus="javascript:calendar();"  runat="server" ></asp:TextBox>
                        <span style="margin-right:5px;">止</span><asp:TextBox ID="SourceValidDate_End_Input"  onfocus="javascript:calendar();"  runat="server" ></asp:TextBox>
                        <a href="javascript:ClearTime();">清空</a>--%>
                        <asp:TextBox ID="SourceValidDate_Input" title="请输入溯源有效期~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
<script type="text/javascript" src="../../../js/date/date.js"></script>
<script type="text/javascript" src="../../../js/date/datetime.js"></script>
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
//function ClearTime(){

//}
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
    function AlertPermitErrorWindow(funcid){
        showPopWin('量程误差数据','PermitError_CalculateArgs.aspx?CMD=New&FunctionID='+funcid+'&'+rand(100000000),780, 425, AlertMessageBox,true);
    }
    </script>

</asp:Content>
