<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_Stock.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="库存">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="库存" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加库存">
        <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        器材名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="EquipmentName_Input" title="请输入器材名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="EquipmentName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        型号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Model_Input" title="请输入型号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="Model_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        库存量</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="StockNumber_Input" title="请输入库存量~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="StockNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        编码号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CodeNO_Input" title="请输入编码号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="CodeNO_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" OnClientClick="return ValidateData();" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">
      function ValidateData(){
             if (document.getElementById('<%= EquipmentName_Input.ClientID %>').value.length == 0) {
            alert('提示：请填写器材名称！');
            document.getElementById('<%= EquipmentName_Input.ClientID %>').focus();
            return false;} 
                if (document.getElementById('<%= Model_Input.ClientID %>').value.length == 0) {
            alert('提示：请填写型号！');
            document.getElementById('<%= Model_Input.ClientID %>').focus();
            return false;}
         
            if (document.getElementById('<%= StockNumber_Input.ClientID %>').value.replace(/[ ]/g,"").length == 0||
            document.getElementById('<%= StockNumber_Input.ClientID %>').value<0) {
            alert('提示：请填写正确的库存量！');
            document.getElementById('<%= StockNumber_Input.ClientID %>').focus();
            return false;} 
              if (document.getElementById('<%= CodeNO_Input.ClientID %>').value.length == 0) {
            alert('提示：请填写编码号！');
            document.getElementById('<%= CodeNO_Input.ClientID %>').focus();
            return false;}
       return true;
       }
    </script>
</asp:Content>
