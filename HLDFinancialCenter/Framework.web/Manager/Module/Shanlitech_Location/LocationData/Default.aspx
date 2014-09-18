<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Default.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.LocationData.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
         HeadOPTxt="定位数据表列表" HeadTitleTxt="定位数据表">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="New" ButtonUrl="Manager.aspx?CMD=New"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="定位数据表" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="定位数据表列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated" >
                <Columns>
                    <asp:TemplateField SortExpression="ID" HeaderText="序号"> 
                        <ItemTemplate>
                        <a href="Manager.aspx?IDX=<%#Eval("ID")%>&CMD=List"><%# (this.AspNetPager1.CurrentPageIndex - 1) * this.AspNetPager1.PageSize + Container.DataItemIndex + 1%></a>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="应用程序唯一标识" SortExpression="appID" DataField="appID" />
                    <asp:BoundField HeaderText="用户唯一标识" SortExpression="userID" DataField="userID" />
                    <asp:BoundField HeaderText="定位类型：
/* 0x01:GPS定位类型
0x02:基站定位类型
0x04:百度定位类型
0x08:百度 & 基站定位类型
0x10:GPS & 基站定位类型 */" SortExpression="type" DataField="type" />
                    <asp:BoundField HeaderText="运营商：
/* 0x01:移动
0x02:电信
0x04:联通 */" SortExpression="operator_mobile" DataField="operator_mobile" />
                    <asp:BoundField HeaderText="坐标系" SortExpression="coordination" DataField="coordination" />
                    <asp:BoundField HeaderText="纬度" SortExpression="lat" DataField="lat" />
                    <asp:BoundField HeaderText="经度" SortExpression="lng" DataField="lng" />
                    <asp:BoundField HeaderText="地址" SortExpression="address" DataField="address" />
                    <asp:BoundField HeaderText="定位时间,注意：如果位置不发生变化定位时间是一样的" SortExpression="locate_time" DataField="locate_time" />
                    <asp:BoundField HeaderText="错误码,暂时仅百度定位时此字段有值，其它暂时保留" SortExpression="error_code" DataField="error_code" />
                    <asp:BoundField HeaderText="错误码描述信息" SortExpression="code_description" DataField="code_description" />
                    <asp:BoundField HeaderText="数据创建时间，区别于定位时间" SortExpression="create_time" DataField="create_time" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <asp:Button ID="Button2" Visible="false" CssClass="button_bak" runat="server" Text="删除" OnClientClick="return deleteop();" OnClick="Button2_Click" />
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        应用程序唯一标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="appID_Input" title="请输入应用程序唯一标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        用户唯一标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="userID_Input" title="请输入用户唯一标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        定位类型：
/* 0x01:GPS定位类型
0x02:基站定位类型
0x04:百度定位类型
0x08:百度 & 基站定位类型
0x10:GPS & 基站定位类型 */</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="type_Input" title="请输入定位类型：
/* 0x01:GPS定位类型
0x02:基站定位类型
0x04:百度定位类型
0x08:百度 & 基站定位类型
0x10:GPS & 基站定位类型 */~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        运营商：
/* 0x01:移动
0x02:电信
0x04:联通 */</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="operator_mobile_Input" title="请输入运营商：
/* 0x01:移动
0x02:电信
0x04:联通 */~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        坐标系</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="coordination_Input" title="请输入坐标系~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        纬度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="lat_Input" title="请输入纬度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        经度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="lng_Input" title="请输入经度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="address_Input" title="请输入地址~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        定位时间,注意：如果位置不发生变化定位时间是一样的</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="locate_time_Input" title="请输入定位时间,注意：如果位置不发生变化定位时间是一样的~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        错误码,暂时仅百度定位时此字段有值，其它暂时保留</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="error_code_Input" title="请输入错误码,暂时仅百度定位时此字段有值，其它暂时保留~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        错误码描述信息</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="code_description_Input" title="请输入错误码描述信息~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td class="table_body">
                        数据创建时间，区别于定位时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="create_time_Input" title="请输入数据创建时间，区别于定位时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        </td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

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
