<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="ManagerFunction.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.Device.ManagerFunction"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server" HeadHelpTxt="<a target='_blank' href='../../../Help/HelperDocument/DeviceDetectApp-InfoSecurity/DeviceFunctionHelp.aspx#p5'>帮助</a>" HeadTitleTxt="设备功能">
        
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看/修改/增加设备功能">
            
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                 <tr>
                    <td class="table_body">
                        设备编号（Serials No.）</td>
                    <td class="table_none">
                        <%--<asp:DropDownList ID="DeviceID_DropDown" runat="server" ></asp:DropDownList>--%>
                        <%--<asp:TextBox ID="DeviceID_Input" Enabled="false" title="请输入设备编号~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    --%>
                        <asp:Label ID="DeviceID_Disp" runat="server"></asp:Label></td>
                </tr>
                
               

                <tr>
                    <td class="table_body">
                        功能名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FunctionName_Input" title="请输入功能名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="FunctionName_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        功能代码</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="FunctionCode_Input" title="请输入功能代码~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="FunctionCode_Disp" runat="server"></asp:Label></td>
                </tr>
                

                <tr>
                    <td class="table_body">
                        规程代码 </td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DetectBasisCode_Input" title="请输入规程代码 ~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectBasisCode_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        检定规程名称</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="DetectBasisName_Input" title="请输入检定规程名称~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectBasisName_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body">
                        测量范围</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="TestRange_Input" title="请输入测量范围~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="TestRange_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        测量不确定度</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="AccuracyLevel_Input" title="请输入测量不确定度（最大允许误差/准确度等级）~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="AccuracyLevel_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body">
                        溯源有效期</td>
                    <td class="table_none">
                        <asp:TextBox ID="SourceValidDate_Input" runat="server" ></asp:TextBox>
                        
                        <%--<asp:TextBox ID="SourceValidDate_Input"  onfocus="javascript:calendar();"  runat="server" ></asp:TextBox>--%>
                        <asp:Label ID="SourceValidDate_Disp" runat="server"></asp:Label>
                        
                        </td>
                </tr>   
                <%--<tr>
                    <td class="table_body">
                        排列序号</td>
                    <td class="table_none">
                     
                        <asp:TextBox ID="OrderID_Input" title="请输入排列序号~int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="OrderID_Disp" runat="server"></asp:Label></td>
                </tr>  --%>
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
    <script type="text/javascript" src="../../../js/Serial/jquery-1.6.1.min.js"></script>
    <script type="text/javascript" src="../../../js/date/datetime.js"></script>
    <script type="text/javascript">
    
    </script>
</asp:Content>
