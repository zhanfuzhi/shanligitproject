﻿<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="SubmitReport.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.SubmitReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
		    <tr id="User_List" runat="server">
			    <td class="table_body">
			    <%-- 核验员/批准人 --%>
                    <asp:Label ID="IDCard" runat="server"></asp:Label></td>
			    <td class="table_none" >
                    <asp:DropDownList ID="User_DropDown" runat="server" ></asp:DropDownList>
                    <asp:Label ID="IDCard_Txt" runat="server"></asp:Label>
                    </td>
		    </tr>
            <tr>
                <td class="table_body">
                    操作说明</td>
                <td class="table_none">
                    <asp:TextBox ID="Note_Input" title="请输入操作说明~200:" runat="server" CssClass="text_input"></asp:TextBox>
                    <asp:Label ID="Note_Txt" runat="server"></asp:Label></td>
            </tr>
            <tr id="Buttons" runat="server">
                <td align="right" colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                    <input id="Reset1" class="button_bak" type="reset" value="重填" />
                </td>
            </tr>
            
		</table>
</asp:Content>
