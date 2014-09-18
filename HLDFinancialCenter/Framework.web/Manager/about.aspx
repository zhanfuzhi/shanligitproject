<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="FrameWork.web.about" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="43" bgcolor="#ffffff" colspan="2">
                <b><font size="2" color="#999999" face="Verdana, Arial, Helvetica, sans-serif">
                    <asp:Label ID="SystemName" runat="server"></asp:Label></font></b>
            </td>
        </tr>
        <tr>
            <td height="1" bgcolor="#000000" colspan="2">
            </td>
        </tr>
        <tr>
            <td height="120" colspan="2">
                <table border="0" cellpadding="0" cellspacing="10" width="100%">
                    <tr>
                        <td width="50%" valign="top">
                            </font><font color="#cccccc"><font color="#000000" face="Verdana, Arial, Helvetica, sans-serif"
                                size="2"><b>版权所有</b><br />
                                石家庄市善理科技有限公司<br />
                                联系电话：0311-89163280<br />
                                <br />
                                <b>授权情况：</b><asp:Label ID="Licensed_Txt" runat="server"></asp:Label>
                            </font></font>
                        </td>
                        <td width="50%" valign="top">
                            <font color="#000000"><font face="Verdana, Arial, Helvetica, sans-serif" size="2"><b>
                                团队成员：</b>
                                <br />
                                <br />
                               戎檄，张彦滨，周建利，郭博浩<br />
                                </font>
                                <br />
                                <br />
                                <div style="text-align: right;">
                                    <input type="button" value="确 定" onclick="window.top.hidePopWin();" name="button"
                                        class="button_bak">&nbsp;&nbsp;</div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
