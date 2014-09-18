<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="DefaultApprove.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DeviceDetect.DefaultApprove"
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
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="设备检测列表" HeadTitleTxt="设备检测">
        <%--<FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="设备检测" />--%>
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="设备检测列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"> <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%> </a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="标准设备" SortExpression="StandardDeviceName" DataField="StandardDeviceName" />
                    <asp:BoundField HeaderText="被检设备" SortExpression="WillTestDeviceName" DataField="WillTestDeviceName" />
                    <asp:TemplateField HeaderText="证书类型" SortExpression="ReportType">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetDictionaryNameByID(Eval("ReportType").ToString()) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:BoundField HeaderText="检定员" SortExpression="DetectUserName" DataField="DetectUserName" />
                    <asp:BoundField HeaderText="检测地点" SortExpression="DetectLocation" DataField="DetectLocation" />
                    <asp:BoundField HeaderText="检定结论" SortExpression="DetectResult" DataField="DetectResult" />
                    <asp:BoundField HeaderText="检定日期" SortExpression="DetectDate" DataField="DetectDate" />
                    <asp:BoundField HeaderText="有效期至" SortExpression="ValidDate" DataField="ValidDate" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <%#GetOperateUrl(Convert.ToInt32(Eval("ID")), Convert.ToInt32(Eval("ApproverID")), Convert.ToInt32(Eval("ApproveFlag")), Eval("ReportPath").ToString())%>
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
                <tr>
                    <td class="table_body td_txt">
                        证书编号</td>
                    <td class="table_none td_input" >
                     
                        <asp:TextBox ID="CertificateNum_Input" title="请输入证书编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                    <%--<td class="table_body td_txt">
                        检定员</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectUser_Input" title="请输入检定员~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>--%>
                
                    <td class="table_body td_txt">
                        检定结论</td>
                    <td class="table_none td_input" >
                     
                        <asp:TextBox ID="DetectResult_Input" title="请输入检定结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body td_txt">
                        标准设备名称</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="StandardDeviceID_Input" title="请输入标准设备~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                
                    <td class="table_body td_txt">
                        被检设备名称</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="WillTestDeviceID_Input" title="请输入被检设备~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                
                
                <tr>
                    <td class="table_body td_txt">
                        检测地点</td>
                    <td class="table_none td_input" colspan="3">
                     
                        <asp:TextBox ID="DetectLocation_Input" title="请输入检测地点~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>        
                    <td class="table_body td_txt">
                        检定日期</td>
                    <td class="table_none td_input" colspan="3">
                        <span style="margin-right:5px;">起</span><asp:TextBox ID="DetectDate_Start_Input"  onfocus="javascript:calendar();"  runat="server" ></asp:TextBox>
                        <span style="margin-right:5px;">止</span><asp:TextBox ID="DetectDate_End_Input"  onfocus="javascript:calendar();"  runat="server" ></asp:TextBox>
                        <a href="javascript:ClearTime();">清空</a></td>
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
<script type="text/javascript" src="../../../js/date/date.js"></script>
<script type="text/javascript" src="../../../js/date/datetime.js"></script>
<script type="text/javascript" src="../../../js/Serial/jquery-1.6.1.min.js"></script>
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
function ClearTime(){
    $('#<%=DetectDate_Start_Input.ClientID %>').val('');
    $('#<%=DetectDate_End_Input.ClientID %>').val('');
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
