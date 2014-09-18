<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    AutoEventWireup="True" CodeBehind="Default.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.T_DataDictionary.Default"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />

    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>

    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadOPTxt="数据字典列表" HeadTitleTxt="数据字典管理" 
        HeadTitleIcon="dictionary.gif">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="数据字典列表">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr class="table_title">
                    <td colspan="2">
                        <asp:Label ID="CatListTitle" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        名称
                    </td>
                    <td class="table_none">
                        <asp:Label ID="CatNameTxt" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="table_body">
                        编码
                    </td>
                    <td class="table_none">
                        <asp:Label ID="Code_Disp" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="table_title">
                        子节点
                    </td>
                </tr>
                <tr class="table_body">
                    <td>
                        字典名称
                    </td>
                    <td>
                        类型
                    </td>
                </tr>
                <asp:Repeater ID="SubGroup" runat="server" EnableViewState="False">
                    <ItemTemplate>
                        <tr class="table_none">
                            <td width="50%">
                                <%# Eval("Name") %>
                            </td>
                            <td width="50%">
                                <%# Eval("Type") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
<script type ="text/javascript">
    function AlertMessageBox(file_name) {
        if (file_name != undefined)
            window.location.href = file_name;
    }
    function sMove(a) {
        var file_name = window.showModalDialog("Move.aspx?DictionaryID=" + a, '', "dialogHeight=215px;dialogWidth=255px;help=no")
        if (file_name != undefined) {
            window.location.href = file_name
        }
        //showPopWin("移动数据字典", "Move.aspx?DictionaryID=" + a, 215, 255, AlertMessageBox, true, true)
    }
</script>
    <script language="javascript" type="text/javascript">
<!--

        
        function SelectAll() {
            var e = document.getElementsByTagName("input");
            var IsTrue;
            if (document.getElementById("CheckboxAll").value == "0") {
                IsTrue = true;
                document.getElementById("CheckboxAll").value = "1"
            }
            else {
                IsTrue = false;
                document.getElementById("CheckboxAll").value = "0"
            }
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    e[i].checked = IsTrue;
                }
            }
        }
        function deleteop() {
            var checkok = false;
            var e = document.getElementsByTagName("input");
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    if (e[i].checked == true) {
                        checkok = true;
                        break;
                    }
                }
            }
            if (checkok)
                return confirm('删除后不可恢复,确认要批量删除选中记录吗？');
            else {

                alert("请选择要删除的记录!");
                return false;
            }
        }

// -->
    </script>

</asp:Content>
