<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignValidate.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceDetect.SignValidate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>电子签名使用认证</title>
</head>
<body bgcolor="#e3f1fe">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <table align="center" bgcolor="#999999" border="0" cellpadding="4" cellspacing="1"
                                                style="width: 407px">
                                                <tr>
                                                    <td bgcolor="#efefef" class="cpx12hei" height="17" width="50%" valign="top">
                                                        <table border="0" cellpadding="4" cellspacing="0" style="width: 100%; height: 100%">
                                                            <tr>
                                                                <td style="width: 40%;text-align:right;">
                                                                    我的电子签名</td>
                                                            
                                                                <td style="width: 60%">
                                                                    <asp:Image ID="SignPicture_Image" border=0 runat="server" style="cursor:pointer"/>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 40%;text-align:right;">
                                                                    输入使用密码</td>
                                                            
                                                                <td style="width: 60%">
                                                                    <asp:TextBox ID="Password" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="height: 22px" colspan="2">
                                                                    <asp:Button ID="Button1" runat="server" Text="确 定" OnClick="Button1_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
