<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_ProjectDic.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="预算项目">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="预算项目" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加预算项目">
         <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        项目编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectNO_Input" title="请输入项目编号~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                     <font style="color:Red;">*</font>
                        <asp:Label ID="ProjectNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        项目名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ProjectName_Input" title="请输入ProjectName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                     <font style="color:Red;">*</font>
                        <asp:Label ID="ProjectName_Disp" runat="server"></asp:Label></td>
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
       if (document.getElementById('<%= ProjectNO_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加项目编号！');
            document.getElementById('<%= ProjectNO_Input.ClientID %>').focus();
            return false;} 
       if (document.getElementById('<%= ProjectName_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加项目名称！');
            document.getElementById('<%= ProjectName_Input.ClientID %>').focus();
            return false;}
       return true;
   }
    </script>
</asp:Content>
