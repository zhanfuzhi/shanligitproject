<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_StorageRecordPiZhun.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link href="../../../inc/FineMessBox/css/subModal.css" rel="stylesheet" type="text/css" />
    <script src="../../../inc/FineMessBox/js/common.js" type="text/javascript"></script>
    <script src="../../../inc/FineMessBox/js/subModal.js" type="text/javascript"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="待批准入库单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="待批准入库单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加待批准入库单">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr >
                    <td class="table_body">
                        库存种类</td>
                    <td class="table_none">
                        <asp:HiddenField ID="StockID_Hidden" runat="server" />
                        <asp:HiddenField ID="EquipmentName_Hidden" runat="server" />
                        <asp:HiddenField ID="Model_Hidden" runat="server" />
                        <asp:HiddenField ID="CodeNO_Hidden" runat="server" />
                        <asp:Label ID="StockName_Disp" runat="server"></asp:Label>
                        <input id="SelectCase" style="display:none;" type="button" value="选择已有库存" onclick="javascript:selectStock();" runat="server" />                    
                        </td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        器材名称</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="EquipmentName_Input" title="请输入器材名称~50:" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="EquipmentName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        型号</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="Model_Input" title="请输入型号~50:" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="Model_Disp" runat="server"></asp:Label></td>
                </tr>
                     <tr>
                    <td class="table_body">
                        项目名称</td>
                    <td class="table_none">
                     

                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        数量</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="StorageNumber_Input" title="请输入数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="StorageNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        单价</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="UnitPrice_Input" title="请输入单价~float" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="UnitPrice_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        入库时间</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="StorageTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>

               <tr style="display:none;">
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                                         
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        实际支出</td>
                    <td class="table_none">
                     
                        <asp:Label ID="PayAmount_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="Remark_Input" title="请输入Remark~50:" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="Remark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        库存资产编码号</td>
                    <td class="table_none">
                     
                        <%--<asp:TextBox ID="CodeNO_Input" title="请输入库存资产编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>--%>
                    
                        <asp:Label ID="CodeNO_Disp" runat="server"></asp:Label></td>
                </tr>
                      
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="批准" OnClick="Button1_Click"/>
                        <%--<input id="Reset1" class="button_bak" type="reset" value="重填" />--%>
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">
  function selectStock(){
    showPopWin('已有库存列表', '../ProjectBudgetRadio/SelectStock.aspx',700, 450, ReloadPage, true, true);
    }
    function ReloadPage(id,EquipmentName,Model,CodeNO){
       document.getElementById("<%=StockName_Disp.ClientID %>").innerText="器材名称："+EquipmentName
       +"；型号："+Model+"；资产编码："+CodeNO;
       //库存id
       document.getElementById("<%=StockID_Hidden.ClientID %>").value=id;
       //器材名称
        document.getElementById("<%=EquipmentName_Hidden.ClientID %>").value=EquipmentName;
        document.getElementById("<%=EquipmentName_Disp.ClientID %>").innerText=EquipmentName;
       //型号
        document.getElementById("<%=Model_Hidden.ClientID %>").value=Model;
        document.getElementById("<%=Model_Disp.ClientID %>").innerText=Model;
        //编码号
        document.getElementById("<%=CodeNO_Hidden.ClientID %>").value=id;
        document.getElementById("<%=CodeNO_Disp.ClientID %>").innerText=id;
    }

       
    </script>
</asp:Content>
