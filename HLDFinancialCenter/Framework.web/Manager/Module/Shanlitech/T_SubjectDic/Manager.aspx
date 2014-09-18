<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="Shanlitech_Location.Web.Module.Shanlitech_Location.T_SubjectDic.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="预算科目">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="Default.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="预算科目" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加预算科目">
        <font style="color:Red;">带"*"的项为必填项</font>
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body">
                        科目编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SubjectNO_Input" title="请输入科目编号~50:!" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="SubjectNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        科目名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="SubjectName_Input" title="请输入科目名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    <font style="color:Red;">*</font>
                        <asp:Label ID="SubjectName_Disp" runat="server"></asp:Label></td>
                </tr>

               <%-- <tr>
                    <td class="table_body">
                        所属类别</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ClassNO_Input" title="请输入所属类别~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ClassNO_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        状态(0为正常，9为删除)</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="State_Input" title="请输入状态(0为正常，9为删除)~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="State_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        创建时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CreateTime_Input" title="请输入创建时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CreateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        更新时间</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="UpdateTime_Input" title="请输入更新时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="UpdateTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        Sort</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Sort_Input" title="请输入Sort~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Sort_Disp" runat="server"></asp:Label></td>
                </tr>--%>
                              
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
       if (document.getElementById('<%= SubjectNO_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加科目编号！');
            document.getElementById('<%= SubjectNO_Input.ClientID %>').focus();
            return false;} 
       if (document.getElementById('<%= SubjectName_Input.ClientID %>').value.length == 0) {
            alert('提示：请添加科目名称！');
            document.getElementById('<%= SubjectName_Input.ClientID %>').focus();
            return false;}
       return true;
   }
    </script>
</asp:Content>
