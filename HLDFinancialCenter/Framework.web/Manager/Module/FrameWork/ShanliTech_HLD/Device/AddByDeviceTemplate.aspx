<%@ Page Language="C#" AutoEventWireup="True" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"  CodeBehind="AddByDeviceTemplate.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Device.AddByDeviceTemplate" %>


<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<style type="text/css">
.btn_right
{
	text-align:right;
}
</style><%--
<FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="设备列表">
        --%>
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
                </Columns>
            </asp:GridView>
            
            </div>
            <%--
        </FrameWorkWebControls:TabOptionItem>
</FrameWorkWebControls:TabOptionWebControls>--%>
            <div style="float:right;margin-top:10px;text-align:center;padding-right:10px;">
                <asp:Button ID="Button1" CssClass="button_bak" runat="server" Text="取消" OnClientClick="javascript:void(0);" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="button_bak" runat="server" Text="下一步" OnClientClick="javascript:void(0);" OnClick="Button2_Click" />
                <asp:Button ID="Button3" CssClass="button_bak" runat="server" Text="完成" OnClientClick="javascript:void(0);" OnClick="Button3_Click" />
            </div>
<script language="javascript" type="text/javascript">
<!--
function SelectRadio(value){
    
}
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
