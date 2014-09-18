<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceTemplate.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<link rel="stylesheet" href="../../../Css/Site_Css.css" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../../../inc/FineMessBox/css/subModal.css" />
    <link rel="shortcut icon" href="../../../images/icon.ico" type="image/x-icon" />
<style type="text/css">
.td_txt
{
    background-color:#cadee8;
    padding-left:5px;
    width:20%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt
}
.td_input
{
	background-color:#e9f2f7;
    padding-left:5px;
    width:30%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt
}
</style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceTemplateHelp.aspx'>帮助</a>"
         HeadOPTxt="设备模板列表" HeadTitleTxt="设备模板">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="设备模板" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="设备模板列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="设备类别">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDictionaryNameByID(Eval("DeviceCategoryID").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="名称" SortExpression="DeviceName" DataField="DeviceName" />
                    <asp:BoundField HeaderText="模板型号/规格" SortExpression="DeviceModel" DataField="DeviceModel" />
                    
                    <asp:BoundField HeaderText="制造厂" SortExpression="DeviceFactory" DataField="DeviceFactory" />
                    
                    <asp:TemplateField HeaderText="所属单位">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDeptNameByID(Convert.ToInt32(Eval("DeviceDepartmentID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="连接方式">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDictionaryNameByID(Eval("ConnectType").ToString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="精确度等级" SortExpression="AccuracyLevel" DataField="AccuracyLevel" />
                    <asp:TemplateField HeaderText="操作"  ItemStyle-HorizontalAlign="Left" ItemStyle-Wrap="false">
                        <ItemTemplate>
                            <a href="DefaultFunction.aspx?DeviceID=<%#Eval("ID")%>">查看功能模板</a>
                            <%#AssembleCmdLinkString(Eval("ID"), Eval("DeviceModel"))%>
                            <%#CreatePointLinkString(Eval("ID"))%>
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
                    
                    <td class="td_txt">
                        设备编号</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="DeviceNum_Input" title="请输入设备编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                    <td class="td_txt">
                        检定证书编号（部分4位）</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="CertifcateNumPart_Input" title="请输入检定证书编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>--%>
                <tr>
                    <td class="td_txt">
                        器具名称</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="DeviceName_Input" title="请输入器具名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                    <td class="td_txt">
                        型号/规格</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="DeviceModel_Input" title="请输入型号/规格~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="td_txt">
                        设备类别</td>
                    <td class="td_input">
                        <asp:DropDownList ID="DeviceCategory_DropDown" runat="server">
                        </asp:DropDownList>
                        </td>
                    <td class="td_txt">
                        精确度等级</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="AccuracyLevel_Input" title="请输入精确度等级~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="td_txt">
                        检测方式</td>
                    <td class="td_input">
                        <asp:DropDownList ID="DetectType_DropDown" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td class="td_txt">
                        连接方式</td>
                    <td class="td_input">
                        <asp:DropDownList ID="ConnectType_DropDown" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="td_txt">
                        所属单位</td>
                    <td class="td_input">
                        <asp:DropDownList ID="Group_DropDown" runat="server"></asp:DropDownList>
                        <%--<asp:TextBox ID="DeviceDepartmentID_Input" title="请输入所属单位编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
                        </td>
                    <td class="td_txt">
                        制造厂</td>
                    <td class="td_input">
                     
                        <asp:TextBox ID="DeviceFactory_Input" title="请输入制造厂~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
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
    function AssembleCmdPop(deviceId,deviceModel)
    {
        showPopWin('设备指令数据','AssembleCmd_SaveUpdate.aspx?DeviceID='+deviceId+'&DeviceModel='+deviceModel+'&rand'+rand(100000000),500, 420, AlertMessageBox,true);
    }
    </script>

</asp:Content>
