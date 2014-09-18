<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="FrameWork.web.Module.FrameWork.GroupManager.New"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        HeadTitleTxt="部门资料管理" HeadOPTxt="新增部门">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="新增部门">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
            <tr runat="server">
                <td class="table_title" colspan="2">
                    <asp:Label ID="CatListTitle" runat="server"></asp:Label></td>
            </tr>
		<tr id="TopTr" runat="server">
			<td class="table_body">
                上级部门</td>
			<td class="table_none">
                <asp:Label ID="G_ParentID_Txt" runat="server"></asp:Label></td>
		</tr>
		 <tr  runat="server">
                <td class="table_body" style="height: 25px">
                    部门类型</td>
                <td class="table_none" style="height: 25px">
                    <asp:DropDownList ID="G_Type_DropDown" runat="server" >
                        <asp:ListItem Value="1">实验室</asp:ListItem>
                        <asp:ListItem Value="2">检测站</asp:ListItem>
                        <asp:ListItem Value="3">委托客户</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr runat="server">
                <td class="table_body" id="dept_lab" style="height: 25px">
                    部门名称</td>
                <td class="table_none" style="height: 25px">
                    <asp:TextBox ID="G_CName" title="请输入部门名称~50:!" runat="server" CssClass="text_input"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
            </tr>
            <tr>
                    <td class="table_body">
                        地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Address_Input" title="请输入地址~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Address_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        资质证书编号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="CertificateNumber_Input" title="请输入资质证书编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CertificateNumber_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        传真</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Fax_Input" title="请输入传真~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Fax_Disp" runat="server"></asp:Label></td>
                </tr>

                

                <tr>
                    <td class="table_body">
                        联系电话</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="Tel_Input" title="请输入联系电话~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Tel_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        通信地址</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="EmailAddress_Input" title="请输入通信地址~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="EmailAddress_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        邮政编码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="ZipCode_Input" title="请输入邮政编码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ZipCode_Disp" runat="server"></asp:Label></td>
                </tr>
		<tr id="SubmitTr" runat="server"><td colspan="2" align="right">
            <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click"  OnClientClick="javascript:return validate();" />
            <input id="Reset1" class="button_bak" type="reset" value="重填" />&nbsp;
		
		</td></tr>
		</table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script type="text/javascript" src="../../../../js/validate_common.js"></script>
    <script type="text/javascript" src="../../../../js/Serial/jquery-1.6.1.min.js"></script>
    <script type="text/javascript">
    
            var telphone='<%=Tel_Input.ClientID %>';
            var fax='<%=Fax_Input.ClientID %>';
            var postcode='<%=ZipCode_Input.ClientID %>';
        function validate(){
            if(ValidatePostCode(postcode)&&ValidateTelphone(telphone)&&ValidateFax(fax))
                return true;
            return false;
        }
//        $('#<%=G_Type_DropDown.ClientID %>').change(function(){
//            if($(this).val()=='1'){
//                $('#dept_lab').text('');
//            }
//        });
    </script>
</asp:Content>
