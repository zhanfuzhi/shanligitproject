<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" CodeBehind="AddByFunctionTemplate.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Device.AddByFunctionTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <%--<FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="设备功能模板列表">--%>
         <div style="border:solid 1px #999999;margin-top:3px;padding:3px;width:100%;height:375px;overflow:auto;">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="功能代码" SortExpression="FunctionCode" DataField="FunctionCode" />--%>
                    <asp:BoundField HeaderText="功能名称" SortExpression="FunctionName" DataField="FunctionName" />
                    <asp:BoundField HeaderText="测量范围" SortExpression="TestRange" DataField="TestRange" />
                    <asp:BoundField HeaderText="测量不确定度" SortExpression="AccuracyLevel" DataField="AccuracyLevel" />
                    <asp:BoundField HeaderText="溯源有效期" SortExpression="SourceValidDate" DataField="SourceValidDate" />
                </Columns>
            </asp:GridView>
            </div>
        <%--</FrameWorkWebControls:TabOptionItem>
        
    </FrameWorkWebControls:TabOptionWebControls>--%>
            <div style="float:right;margin-top:10px;text-align:center;padding-right:10px;">
            <asp:Button ID="Button1" CssClass="button_bak" runat="server" Text="取消" OnClick="Button1_Click" />
            <asp:Button ID="Button2" CssClass="button_bak" runat="server" Text="下一步" OnClick="Button2_Click" />
            <asp:Button ID="Button3" CssClass="button_bak" runat="server" Text="完成" OnClick="Button3_Click" />
            </div>
            
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
-->
</script>
</asp:Content>