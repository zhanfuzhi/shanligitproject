<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateDetectPoint.aspx.cs" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate.CreateDetectPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <div style="text-align:center;">
     <fieldset>
          <legend>选项</legend>
          <table width="100%" border ="0" cellpadding = "0" cellspacing = "0">
          <tr>
          <td>
                <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                    RepeatDirection="Horizontal">
                </asp:CheckBoxList></td>
          <td>
                <asp:RadioButton ID="RadioButton1" runat="server" Checked="True" GroupName="ca" 
                  Text="只生成选定功能" />
              <asp:RadioButton ID="RadioButton2" runat="server" GroupName="ca" 
                  Text="生成全部功能" /></td>
          <td >
              <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" /></td>
          <td >
              <asp:Button ID="Button2" runat="server" Text="生成" onclick="Button2_Click" /></td>
          <td >
              <asp:Button ID="Button4" runat="server" Text="删除" onclick="Button4_Click" /></td>
          <td >
              <asp:Button ID="Button3" runat="server" Text="保存" onclick="Button3_Click" /></td>
          <td >
              <asp:Button ID="Button5" runat="server" Text="清临时数据" onclick="Button5_Click"  /></td>
          </tr>
          <tr>
          <td colspan="2">
              &nbsp;&nbsp;
              起点：<asp:TextBox ID="TextBox1" runat="server" Width="40px">20</asp:TextBox>%
              &nbsp;&nbsp;间隔：<asp:TextBox ID="TextBox2" runat="server" Width="40px">20</asp:TextBox>%
               &nbsp;&nbsp;终点：<asp:TextBox ID="TextBox3" runat="server" Width="40px">80</asp:TextBox>%
               &nbsp;&nbsp;交流频率：<asp:TextBox ID="TextBox4" runat="server" Width="99px">50|Hz,1|kHz</asp:TextBox>
              &nbsp;&nbsp;直流正负：<asp:CheckBox ID="CheckBox1" runat="server" Checked="True" 
                  Text="生成正负点" />
          </td>
          <td  colspan = "5">
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
          </tr>
          </table>
     </fieldset>
     <fieldset>
          <legend>检定点列表</legend>
          <div style="border:solid 1px #999999;margin-top:3px;padding:3px;width:100%;height:375px;overflow:auto;">
            <asp:GridView ID="GridView1" runat="server" 
                   AutoGenerateColumns="False" onrowcreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="功能编码" SortExpression="FunctionCode" 
                        DataField="FunctionCode" />
                    <asp:TemplateField HeaderText="量程" SortExpression="TestRange">
                        <ItemTemplate>
                            <%#Eval("TestRange")%><%#Eval("Unit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="标准值" SortExpression="StandardValue" DataField="StandardValue" />
                    <asp:TemplateField HeaderText="频率">
                       <ItemTemplate>
                            <%#Eval("Frequency")%><%#Eval("FrequencyUnit")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最大允许误差" SortExpression="ValuePerMissibleErrorName">
                        <ItemTemplate>
                            <%#Eval("MissibleErrorSymbol")%><%#ShanliTech_HLD_Business.ToolMethods.GetFormatScienceHTML(Convert.ToDouble(Eval("ValuePerMissibleErrorName")))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
            </div>
     </fieldset>
       
    </div>

    <script language="javascript" type="text/javascript">
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
    </script>
</asp:Content>
