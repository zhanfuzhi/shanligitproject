<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssembleCmd_SaveUpdate.aspx.cs"  MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate.AssembleCmd_SaveUpdate" %>

<asp:Content id="Content1" ContentPlaceHolderID="PageBody" runat="server">
<style type="text/css">
.table_text
{
   background-color:#cadee8;
   font-size:9pt;
   padding:0px 5px 0px 5px;
   width:18%;
   height:30px;
}
.table_data
{
   background-color:#e9f2f7;
   font-size:9pt;
   padding:0px 5px 0px 5px;
   width:10%;
   height:30px;
}
</style>
        <table style="width:100%;" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_text">设备型号</td>
                    <td class="table_data">
                     
                        <asp:TextBox ID="DeviceModel_Input" title="请输入设备型号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DeviceModel_Disp" runat="server"></asp:Label></td>
                    <td class="table_text">指令名称</td>
                    <td class="table_data">
                     
                        <asp:TextBox ID="CommandName_Input" title="请输入指令名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CommandName_Disp" runat="server"></asp:Label></td>
                    <td class="table_text" >指令类型</td>
                    <td class="table_data" >
                        <asp:DropDownList ID="CmdType_DropDown" runat="server"  AutoPostBack="true"
                            onselectedindexchanged="CmdType_DropDown_SelectedIndexChanged" >
                            
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="table_text">指令标识</td>
                    <td class="table_data">
                        <asp:DropDownList ID="CommandIdentity_DropDown" runat="server" >
                            
                        </asp:DropDownList>
                        <asp:Label ID="CommandIdentity_Disp" runat="server"></asp:Label></td>
                    <td class="table_text">指令码</td>
                    <td class="table_data">
                     
                        <asp:TextBox ID="CommandCode_Input" title="请输入指令码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CommandCode_Disp" runat="server"></asp:Label></td>
                    <td align="right" colspan="2">
                        <asp:Button ID="Button2" runat="server" CssClass="button_bak" Text="保存" 
                            onclick="Button2_Click"/>
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="新增" 
                            onclick="Button1_Click"/>
                    </td>
                </tr>
            </table>
            <div style="width:100%;overflow:auto;height:325px;">
                <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" >
                    <Columns>
                        <asp:TemplateField HeaderText="序号"> 
                            <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Wrap="True" />  
                            <HeaderStyle Wrap="False" />    
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="指令名称" DataField="CommandName" />
                        <asp:BoundField HeaderText="指令标识" DataField="CommandIdentity" />
                        <asp:BoundField HeaderText="指令码" DataField="CommandCode" />
                        <asp:TemplateField HeaderText="操作"> 
                            <ItemTemplate>
                                操作
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Button ID="Button4" CssClass="button_bak" runat="server" Text="返回" OnClick="Button4_Click" />
            <asp:Button ID="Button3" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button3_Click" />
 
 
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
