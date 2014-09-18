<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="AddByPointTemplate.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Device.AddByPointTemplate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<%--<FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="功能检定点模板列表">--%>
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
                    <asp:TemplateField HeaderText="设备功能模板">
                        <ItemTemplate>
                            <%#ShanliTech_HLD_Business.ToolMethods.GetFunctionNameByFunctionTemplateID(Convert.ToInt32(Eval("FunctionID")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="设备功能编码" SortExpression="FunctionCode" DataField="FunctionCode" />
                    <asp:TemplateField HeaderText="量程" SortExpression="TestRange">
                        <ItemTemplate>
                            <%#Eval("TestRange")%><%#Eval("Unit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="标准值" SortExpression="StandardValue" DataField="StandardValue" />
                    <asp:TemplateField HeaderText="最大允许误差" SortExpression="ValuePerMissibleErrorName">
                        <ItemTemplate>
                            <%#Eval("MissibleErrorSymbol")%><%#Eval("ValuePerMissibleErrorName")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField HeaderText="轻击位移允许值" SortExpression="ChangePerMissibleError" DataField="ChangePerMissibleError" />
                    <asp:BoundField HeaderText="回程误差" SortExpression="H_PerMissibleError" DataField="H_PerMissibleError" />
                </Columns>
            </asp:GridView>
            </div>
           <%-- 
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>--%>
            <div style="float:right;margin-top:10px;text-align:center;padding-right:10px;">
                <asp:Button ID="Button1" CssClass="button_bak" runat="server" Text="取消" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="button_bak" runat="server" Text="完成" OnClick="Button2_Click" />
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

