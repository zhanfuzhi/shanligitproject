<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="FrameWork.web.right"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadOPTxt="查看信息" HeadTitleTxt="系统信息">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="系统信息">
                <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                    <tr>
                        <td class="table_body">
                            系统名称</td>
                        <td class="table_none">
                            <asp:Label ID="SystemName" runat="server"></asp:Label></td>
                    </tr>
<%--                    <tr>
                        <td class="table_body">
                            检定机构总数（单位：个）</td>
                        <td class="table_none">
                            <asp:Label ID="DeptCount" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="table_body">
                            实验室总数（单位：个）</td>
                        <td class="table_none">
                            <asp:Label ID="LabCount" runat="server"></asp:Label>
                            </td>
                    </tr>  
                    <tr>
                        <td class="table_body">
                            标准设备总数（单位：个）</td>
                        <td class="table_none">
                            <asp:Label ID="StandardDeviceCount" runat="server"></asp:Label>
                            </td>
                    </tr>  
                    <tr>
                        <td class="table_body">
                            已检定次数（单位：次）</td>
                        <td class="table_none">
                            <asp:Label ID="DetectCount" runat="server"></asp:Label>
                            </td>
                    </tr> --%>                   
		</table>
        </FrameWorkWebControls:TabOptionItem>
        
    </FrameWorkWebControls:TabOptionWebControls>

</asp:Content>
