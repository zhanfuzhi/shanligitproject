<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="PermitError_CalculateArgs.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate.PermitError_CalculateArgs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
<style type="text/css">
.table_text
{
   background-color:#cadee8;
   font-size:9pt;
   padding:0px 5px 0px 5px;
   width:9%;
   height:30px;
}
.table_data
{
   background-color:#e9f2f7;
   font-size:9pt;
   padding:0px 5px 0px 5px;
   width:12%;
   height:30px;
}
</style>
    <div style="border:solid 1px #999999;margin-top:3px;padding:3px;width:100%;height:405px;">
       <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center" style="margin-bottom:10px;">
            
            <tr>
                <td class="table_text" style="width:8%;">
                    满度/量程单位
                </td>
                <td class="table_data" style="width:7%;">
                    <asp:TextBox ID="Unit_Input" runat="server" CssClass="tex_input" title="请输入量程及满度的单位~50:"></asp:TextBox>
                    <asp:Label ID="Unit_Disp" runat="server"></asp:Label>
                </td>
                
                <td class="table_text" style="width:7%;">
                    满度
                </td>
                <td class="table_data">
                    <asp:TextBox ID="RangeFull_Input" runat="server" CssClass="tex_input" title="请输入满度~float:"></asp:TextBox>
                </td>
                <td class="table_text"style="width:10%;">
                    量程
                </td>
                <td class="table_data">
                    <asp:TextBox ID="Range_Input" runat="server" CssClass="tex_input" title="请输入量程~float:"></asp:TextBox>
                </td>
                <td class="table_text" style="width:8%;white-space:nowrap">
                    量程切换指令
                </td>
                <td class="table_data"style="width:12%;">
                    <asp:TextBox ID="RangeCode_Input" runat="server"  CssClass="tex_input"  title="请输入量程切换指令~50:"></asp:TextBox>
                </td>
                <td class="table_text" id="FreqStart_Text_TD" runat="server" style="width:8%;">
                    频率起
                </td>
                <td class="table_data" id="FreqStart_Input_TD" runat="server" style="width:15%;">
                    <asp:TextBox ID="FrequencyStart_Input" runat="server" CssClass="tex_input" style="width:40%" title="请输入频率起点值~float:"></asp:TextBox>&nbsp;
                    <asp:DropDownList ID="FreqStartUnit_DropDown" runat="server" Width="50%"  title="请选择频率起点单位~50:">
                        <asp:ListItem Value="Hz" Selected="True">Hz</asp:ListItem>
                        <asp:ListItem Value="KHz">KHz</asp:ListItem>
                        <asp:ListItem Value="MHz">MHz</asp:ListItem>
                        
                    </asp:DropDownList>
                </td>
                <td align="center">
                    <asp:Button ID="Button2" runat="server" class="button_bak" Text="新增" onclick="Button2_Click" />
                    
                </td>
             
            </tr>
            <tr>
                <td class="table_text" style="width:8%;">
                    分辨力单位
                </td>
                <td class="table_data" style="width:7%;">
                    <asp:TextBox ID="MinUnit_Input" runat="server"  CssClass="tex_input"  title="请输入分辨力单位~50:"></asp:TextBox>
                    <asp:Label ID="MinUnit_Disp" runat="server"></asp:Label>
                </td>
                <td class="table_text" style="width:7%;">
                    分辨力
                </td>
                <td class="table_data">
                    <asp:TextBox ID="MinGraduation_Input" runat="server"  CssClass="tex_input"  title="请输入分辨力值~float:"></asp:TextBox>
                    <asp:Label ID="MinGraduation_Disp" runat="server"></asp:Label>
                </td>
                <td class="table_text" style="width:10%;">
                    测量值系数
                </td>
                <td class="table_data" style="white-space:nowrap;">
                    <asp:TextBox ID="Ratio0_Input" runat="server" CssClass="tex_input" width="75%" title="请输入测量值系数~float:"></asp:TextBox>&nbsp;%
                </td>
                <td class="table_text">
                    <asp:Label ID="ArgText_Label" runat="server"></asp:Label>
                </td>
                <td id="ConstValue_TD" runat="server" class="table_data">
                    <asp:TextBox ID="ConstValue_Input" runat="server"  CssClass="tex_input" width="50%" title="请输入常数值~float:"></asp:TextBox>
                    <asp:TextBox ID="ConstValueUnit_Input" runat="server"  CssClass="tex_input" width="40%" title="请输入常数值单位~50:"></asp:TextBox>
                </td>
                <td id="Ratio1_TD" runat="server" class="table_data" style="white-space:nowrap;">
                    <asp:TextBox ID="Ratio1_Input" runat="server"  CssClass="tex_input" width="75%" title="请输入量程值系数~float:"></asp:TextBox>&nbsp;%
                </td>
                <td id="Precision_TD" runat="server" class="table_data">
                    <asp:TextBox ID="PrecisionCount_Input" runat="server"  CssClass="tex_input"   title="请输入字数~int:"></asp:TextBox>
                </td>
                <td class="table_text" id="FreqEnd_Text_TD" runat="server" style="width:8%;">
                    频率止
                </td>
                <td class="table_data" id="FreqEnd_Input_TD" runat="server" style="width:15%;">
                    <asp:TextBox ID="FrequencyEnd_Input" runat="server"  CssClass="tex_input" Width="40%" title="请输入频率终点值~float:"></asp:TextBox>&nbsp;
                    <asp:DropDownList ID="FreqEndUnit_DropDown" runat="server" Width="50%" title="请选择频率终点单位~50:">
                        <asp:ListItem Value="Hz" Selected="True">Hz</asp:ListItem>
                        <asp:ListItem Value="KHz">KHz</asp:ListItem>
                        <asp:ListItem Value="MHz">MHz</asp:ListItem>
                        
                    </asp:DropDownList>
                </td>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" class="button_bak" Text="保存" onclick="Button1_Click" />                  
                </td>
            </tr>
            <tr id="FreqInput_TR" runat="server">
                
                
            <%--</tr>
            <tr>--%>
                
                
            </tr>
        </table>
        <fieldset>
            <legend>误差计算参数列表</legend>
            <div style="overflow:auto;height:310px;width:100%;">
                <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated" >
                    <Columns>
                        <asp:TemplateField HeaderText="序号"> 
                            <ItemTemplate>
                            <%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%>
                            </ItemTemplate>
                            <ItemStyle Wrap="True" />  
                            <HeaderStyle Wrap="False" />    
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="功能" DataField="FunctionCode" />
                        <asp:TemplateField HeaderText="量程"> 
                            <ItemTemplate>
                                <%#Eval("RangeEndOriginal")%><%#Eval("RangeUnitOriginal")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="满刻度值"> 
                            <ItemTemplate>
                                <%#Eval("RangeFull")%><%#Eval("RangeUnitOriginal")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField HeaderText="频率"> 
                            <ItemTemplate>
                                <%#Eval("FrequencyStart")%> — <%#Eval("FrequencyEnd")%><%#Eval("FrequencyUnit")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="1年"> 
                            <ItemTemplate>
                                ±（0.005%+3）
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="分辨力"> 
                            <ItemTemplate>
                                <%# Eval("MinimumGraduation")%><%#Eval("RangeUnit")%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="操作"> 
                            <ItemTemplate>
                                <a href="?CMD=Edit&IDX=<%#Eval("ID") %>&FunctionID=<%=FunctionID %>">修改</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <%--<asp:BoundField HeaderText="计算系数" SortExpression="Ratio0" DataField="Ratio0" />
                        <asp:BoundField HeaderText="分辨力" SortExpression="MinimumGraduation" DataField="MinimumGraduation" />
                        <asp:BoundField HeaderText="设备编号" SortExpression="DeviceNum" DataField="DeviceNum" />
                        <asp:BoundField HeaderText="设备型号" SortExpression="DeviceModel" DataField="DeviceModel" />
                        <asp:BoundField HeaderText="量程" SortExpression="RangeEnd" DataField="RangeEnd" />
                        <asp:BoundField HeaderText="满刻度值" SortExpression="RangeFull" DataField="RangeFull" />
                        <asp:BoundField HeaderText="量程单位" SortExpression="RangeUnit" DataField="RangeUnit" />
                        <asp:BoundField HeaderText="频率的起点" SortExpression="FrequencyStart" DataField="FrequencyStart" />
                        <asp:BoundField HeaderText="频率的终点" SortExpression="FrequencyEnd" DataField="FrequencyEnd" />
                        <asp:BoundField HeaderText="频率单位，以标准单位为准，即Hz" SortExpression="FrequencyUnit" DataField="FrequencyUnit" />--%>
                        
                        <%--<asp:BoundField HeaderText="计算系数" SortExpression="Ratio1" DataField="Ratio1" />
                        <asp:BoundField HeaderText="计算常数" SortExpression="ConstValue" DataField="ConstValue" />--%>
                        
                        <%--<asp:BoundField HeaderText="字数" SortExpression="PrecisionCount" DataField="PrecisionCount" />--%>
                    </Columns>
                </asp:GridView>
                <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
                </FrameWorkWebControls:AspNetPager>
                <asp:Button ID="Button3" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button3_Click" />
            </div>
        </fieldset>
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
