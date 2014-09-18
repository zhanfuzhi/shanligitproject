<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ClassDic.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="经费类别">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="经费类别" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加经费类别">
        <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

 <tr>
                    <td class="table_body">
                        类别编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassNO_Input" title="请输入类别编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="ClassNO_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        类别名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassName_Input" title="请输入类别名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="ClassName_Disp" runat="server"></asp:Label></td>
                </tr>
                              
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" OnClientClick="return ValidateData();"/>
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script language="javascript" type="text/javascript">
       function ValidateData(){
       if (document.getElementById('<%= ClassNO_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加类别编号！');
            document.getElementById('<%= ClassNO_Input.ClientID %>').focus();
            return false;} 
       if (document.getElementById('<%= ClassName_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加类别名称！');
            document.getElementById('<%= ClassName_Input.ClientID %>').focus();
            return false;}
       return true;
   }
    </script>
</asp:Content>
