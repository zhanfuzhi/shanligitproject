﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionTest.aspx.cs" Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Detector.SessionTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=FrameName %></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 80px">
    
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="放入" /><br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="读出" />
    
    </div>
    </form>
</body>
</html>
