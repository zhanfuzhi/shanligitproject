<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_OutboundRecordPiZhun.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="出库批准单">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="出库批准单" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加出库批准单">
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
                <tr>
                    <td class="table_body">
                        项目名称</td>
                    <td class="table_none">
                        <asp:DropDownList ID="ProjectNO_Input" title="请选择项目！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>

                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
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
                        数量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OutboundNumber_Input" title="请输入数量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="OutboundNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        结余</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="BalanceNumber_Input" title="请输入结余~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="BalanceNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        领取时间</td>
                    <td class="table_none">
                        <asp:Label ID="OutboundTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr >
                    <td class="table_body">
                        申请人</td>
                    <td class="table_none">
                        <asp:DropDownList ID="Applicant_Input" title="请选择申请人！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>   
                        <asp:Label ID="Applicant_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;" runat="server" id="tr_Approver">
                    <td class="table_body">
                        批准人</td>
                    <td class="table_none">
                      <%-- <asp:DropDownList ID="Approver_Input" title="请选择批准人！" runat="server" CssClass="text_input"
                            Width="120px">
                        </asp:DropDownList>     --%>                  
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                </tr>

              

                <tr>
                    <td class="table_body">
                        备注</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Remark_Input" title="请输入备注~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Remark_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr style="display:none;">
                    <td class="table_body">
                        库存资产编码号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CodeNO_Input" title="请输入库存资产编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CodeNO_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="批准" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">

    </script>
</asp:Content>
