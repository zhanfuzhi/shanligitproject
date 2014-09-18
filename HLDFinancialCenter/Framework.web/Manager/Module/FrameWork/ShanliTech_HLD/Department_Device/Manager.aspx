<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Department_Device.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="检定设备" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeptDeviceHelp.aspx'>帮助</a>">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="检定设备" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加检定设备">
            &nbsp;<font color="red">带“*”字段为必填项。</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body">
                        检定部门</td>
                    <td class="table_none">
                        <%--<asp:DropDownList ID="Group_DropDown" runat="server"></asp:DropDownList>--%>
                        <%--<asp:TextBox ID="DepartmentID_Input" title="请输入部门编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
                        <asp:Label ID="DepartmentID_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        实验室</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Laboratory_Input" title="请输入实验室~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Laboratory_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备&nbsp;<font color="red">*</font></td>
                    <td class="table_none">
                        <asp:DropDownList ID="DeviceID_DropDown" runat="server"></asp:DropDownList>
                        <%--<asp:TextBox ID="DeviceID_Input" title="请输入设备编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
                        <asp:Label ID="DeviceID_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        设备类型&nbsp;<font color="red">*</font></td>
                    <td class="table_none">
                        <asp:DropDownList ID="DeviceType_DropDown" runat="server" AutoPostBack="true"
                            onselectedindexchanged="DeviceType_DropDown_SelectedIndexChanged"></asp:DropDownList>
                        
                        <asp:Label ID="DeviceType_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr runat="server" id="Verify_TR">
                    <td class="table_body">
                        检测类型&nbsp;<font color="red">*</font></td>
                    <td class="table_none">
                        <asp:DropDownList ID="VerifyType_DropDown" runat="server"></asp:DropDownList>
                        <asp:Label ID="VerifyType_Disp" runat="server"></asp:Label></td>
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
