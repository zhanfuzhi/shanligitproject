<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" CodeBehind="AssembleDeviceModelSelectList.aspx.cs"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate.AssembleDeviceModelSelectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <div style="border: solid 1px #999999; margin-top: 3px; padding: 3px; width: 99%;text-align:center;">
        <div style="overflow: auto;width: 100%;height:370px;margin:5px 0px 5px 0px;">
            <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%#  Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="型号/规格" DataField="DeviceModel" />
                    <asp:TemplateField HeaderText="操作"> 
                        <ItemTemplate>
                        <a href="AssembleCmd_SaveUpdate.aspx?DeviceModel=<%#Eval("DeviceModel") %>&BackUrl=AssembleDeviceModelSelectList.aspx">设备指令数据</a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button_bak"
            onclick="Button1_Click"/>
    </div>
</asp:Content>
