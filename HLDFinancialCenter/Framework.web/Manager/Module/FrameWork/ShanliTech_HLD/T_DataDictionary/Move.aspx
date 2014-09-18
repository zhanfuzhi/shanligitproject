<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Move.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary.Move" %>

<html>
<head>
    <title>移动部门</title>

    <script language="javascript">
        var TreeImgdir = "../../../images/TreeIcon/";
    </script>

    <script src="../../../js/MoveTree.js" type="text/javascript"></script>

    <base target="_self">
    </base>
    <style>
        .FolderStyle
        {
            color: #000000;
            text-decoration: none;
        }
    </style>
    <link href="../../../Css/Site_Css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../../Css/Table/<%=TableSink%>/Css.css" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <table width='100%' cellpadding="0" cellspacing="0" border="0" bgcolor="#6b82a5">
        <tr>
            <td class="table_title">
                移动数据字典
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" bgcolor="#ffffff" valign="top" style="padding-left: 5px">
                <asp:Literal ID="ShowScript" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
    </table>

    <script language="javascript">
        function xNowMove(xName, xId) {
            if (xId != null) {
                if (confirm("将此数据字典类型移动到【" + xName + "】字典下 ?\n\n确定吗？")) {
                    window.returnValue = "Move.aspx?CMD=Move&DictionaryID=<%=DictionaryID %>&ToDictionaryID=" + xId;
                    window.close();
                }
            }
        }
    </script>

    </form>
</body>
</html>
