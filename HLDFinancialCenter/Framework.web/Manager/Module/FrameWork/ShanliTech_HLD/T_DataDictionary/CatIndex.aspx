<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CatIndex.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary.CatIndex" %>

<html>
<head id="Head1">
    <title>无标题页</title>
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
    <table width='100%' cellpadding="0" cellspacing="0" border="0">
        <tr>
            <td class="table_title">
                <img src="../../../images/TreeIcon/refurbish.gif" border="0" align="absMiddle" onclick="javascript:window.location.reload();"
                    title="刷新" style="cursor: pointer">&nbsp;<a href="javascript:disp_all();">展开/收起</a>
            </td>
        </tr>
    </table>

    <script language="javascript">
        var TreeImgdir = "../../../images/TreeIcon/";
    </script>

    <script src="../../../js/Tree.js" type="text/javascript"></script>

    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="100%" bgcolor="#ffffff" valign="top" style="padding-left: 5px">
                <asp:Literal ID="ShowScript" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
    </table>

    <script language="javascript">
        var close_id = 1
        function disp_all() {
            var d_i;
            if (close_id == 1) {
                close_id = 0
                dim_src = Fold_id.split(",");
                for (d_i = 1; d_i < dim_src.length; d_i = d_i + 2) {
                    if (dim_src[d_i] != '') {
                        clickOnNode(dim_src[d_i]);
                    }
                }
            }
            else {
                clickOnNode(0);
                close_id = 1
            }
            clickOnNode(0);
        }
        disp_all();
    </script>

    </form>
</body>
</html>
