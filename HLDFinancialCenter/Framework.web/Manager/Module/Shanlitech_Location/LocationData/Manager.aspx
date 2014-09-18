<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.LocationData.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="定位数据表">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="定位数据表" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加定位数据表">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        应用程序唯一标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="appID_Input" title="请输入应用程序唯一标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="appID_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        用户唯一标识</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="userID_Input" title="请输入用户唯一标识~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="userID_Disp" runat="server"></asp:Label></td>
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
                    
                        <asp:Label ID="type_Disp" runat="server"></asp:Label></td>
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
                    
                        <asp:Label ID="operator_mobile_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        坐标系</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="coordination_Input" title="请输入坐标系~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="coordination_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        纬度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="lat_Input" title="请输入纬度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lat_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        经度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="lng_Input" title="请输入经度~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="lng_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="address_Input" title="请输入地址~100:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="address_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        定位时间,注意：如果位置不发生变化定位时间是一样的</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="locate_time_Input" title="请输入定位时间,注意：如果位置不发生变化定位时间是一样的~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="locate_time_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        错误码,暂时仅百度定位时此字段有值，其它暂时保留</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="error_code_Input" title="请输入错误码,暂时仅百度定位时此字段有值，其它暂时保留~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="error_code_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        错误码描述信息</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="code_description_Input" title="请输入错误码描述信息~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="code_description_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        数据创建时间，区别于定位时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="create_time_Input" title="请输入数据创建时间，区别于定位时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="create_time_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
