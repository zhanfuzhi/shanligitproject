<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="True"
    Codebehind="Manager.aspx.cs" Inherits="ShanliTech_HLD_Business.Web.Module.ShanliTech_HLD_Business.DetectApprove.Manager"
    Title="无标题页" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">

<style type="text/css">
.td_txt
{
    background-color:#cadee8;
    padding-left:5px;
    width:20%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt
}
.td_input
{
	background-color:#e9f2f7;
    padding-left:5px;
    width:30%;
    padding-right:5px;
    font-family:"Verdana", "Arial", "Helvetica", "sans-serif"; 
    HEIGHT: 30px;
    font-size:9pt
}
</style>
    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"  HeadTitleTxt="设备检测">
        <FrameWorkWebControls:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="DefaultApprove.aspx"
            ButtonUrlType="Href" ButtonVisible="True" ButtonName="设备检测" />
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem1" runat="server" Tab_Name="查看设备检测">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">

                <tr>
                    <td class="table_body td_txt">
                        证书编号</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="CertificateNum_Input" title="请输入证书编号~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="CertificateNum_Disp" runat="server"></asp:Label></td>
                
                    <td class="table_body td_txt">
                        证书类型</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="ReportType_Input" title="请输入证书类型~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ReportType_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body td_txt">
                        标准设备</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="StandardDeviceName_Input" title="请输入StandardDeviceName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="StandardDeviceName_Disp" runat="server"></asp:Label></td>
                
                    <td class="table_body td_txt">
                        被检设备</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="WillTestDeviceName_Input" title="请输入WillTestDeviceName~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="WillTestDeviceName_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body td_txt">
                        有效期至</td>
                    <td class="table_none td_input" colspan="3">
                     
                        <asp:TextBox ID="ValidDate_Input" title="请输入有效期至~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ValidDate_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body td_txt">
                        检定员</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectUserName_Input" title="请输入检定员~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectUserName_Disp" runat="server"></asp:Label></td>
                
                    <td class="table_body td_txt">
                        检定日期</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectDate_Input" title="请输入检定日期~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectDate_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body td_txt">
                        检定结论</td>
                    <td class="table_none td_input" colspan="3">
                     
                        <asp:TextBox ID="DetectResult_Input" title="请输入检定结论~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectResult_Disp" runat="server"></asp:Label></td>
                </tr>
                
                
                <tr>
                    <td class="table_body td_txt">
                        核验人</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="Verifier_Input" title="请输入核验人~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Verifier_Disp" runat="server"></asp:Label></td>
                
                    <td class="table_body td_txt">
                        核验结论</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="VerifyFlag_Input" title="请输入核验标志~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="VerifyFlag_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body td_txt">
                        核验时间</td>
                    <td class="table_none td_input" colspan="3">
                     
                        <asp:TextBox ID="VerifyTime_Input" title="请输入核验时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="VerifyTime_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body td_txt">
                        批准人</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="Approver_Input" title="请输入批准人~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Approver_Disp" runat="server"></asp:Label></td>
                
                    <td class="table_body td_txt">
                        批准结论</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="ApproveFlag_Input" title="请输入批准标志~2147483648:int" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ApproveFlag_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body td_txt">
                        批准时间</td>
                    <td class="table_none td_input" colspan="3">
                     
                        <asp:TextBox ID="ApproveTime_Input" title="请输入批准时间~datetime" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="ApproveTime_Disp" runat="server"></asp:Label></td>
                </tr>
                </table>
        </FrameWorkWebControls:TabOptionItem>    
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="设备检测其他">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body td_txt">
                        检测地点</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectLocation_Input" title="请输入检测地点~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectLocation_Disp" runat="server"></asp:Label></td>
                </tr>
                
                <tr>
                    <td class="table_body td_txt">
                        外观（及线路检查）</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="SurfaceCheck_Input" title="请输入SurfaceCheck~200:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="SurfaceCheck_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr runat="server" id="P_Properties" style="padding:0px;margin:0px;">
                    <td colspan="2" style="padding:0px;margin:0px;">
                        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                            <%-- 压力设备属性 --%>
                            <tr  runat="server" id="ZeroCheck_TR">
                                <td class="table_body td_txt">
                                    零位检查</td>
                                <td class="table_none td_input">
                                 
                                    <asp:TextBox ID="ZeroPointCheck_Input" title="请输入ZeroPointCheck~200:" runat="server" CssClass="text_input"></asp:TextBox>
                                
                                    <asp:Label ID="ZeroPointCheck_Disp" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td class="table_body td_txt">
                                    耐压3分钟检查</td>
                                <td class="table_none td_input">
                                 
                                    <asp:TextBox ID="WithstandCheck_Input" title="请输入WithstandCheck~200:" runat="server" CssClass="text_input"></asp:TextBox>
                                
                                    <asp:Label ID="WithstandCheck_Disp" runat="server"></asp:Label></td>
                            </tr>

                            <tr>
                                <td class="table_body td_txt">
                                    指针平稳性检查</td>
                                <td class="table_none td_input">
                                 
                                    <asp:TextBox ID="PointerSmoothCheck_Input" title="请输入PointerSmoothCheck~200:" runat="server" CssClass="text_input"></asp:TextBox>
                                
                                    <asp:Label ID="PointerSmoothCheck_Disp" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
                <tr>
                    <td class="table_body td_txt">
                        湿度</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="Humidity_Input" title="请输入湿度~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Humidity_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body td_txt">
                        温度</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="Temperature_Input" title="请输入温度~float" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="Temperature_Disp" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td class="table_body td_txt">
                        环境其它</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="EnvironmentNote_Input" title="请输入环境其它~50:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="EnvironmentNote_Disp" runat="server"></asp:Label></td>
                </tr>

                <tr>
                    <td class="table_body td_txt">
                        检定备注</td>
                    <td class="table_none td_input">
                     
                        <asp:TextBox ID="DetectNote_Input" title="请输入检定备注~300:" runat="server" CssClass="text_input"></asp:TextBox>
                    
                        <asp:Label ID="DetectNote_Disp" runat="server"></asp:Label></td>
                </tr>
                
                
                <tr id="ButtonOption" runat="server">
                    <td align="right" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="确定" OnClick="Button1_Click" />
                        <input id="Reset1" class="button_bak" type="reset" value="重填" />
                    </td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>
</asp:Content>
