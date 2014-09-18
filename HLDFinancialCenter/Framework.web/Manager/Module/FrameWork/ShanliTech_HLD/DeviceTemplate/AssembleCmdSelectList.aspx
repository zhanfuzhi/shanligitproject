<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssembleCmdSelectList.aspx.cs"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.DeviceTemplate.AssembleCmdSelectList"
    MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <div style="border: solid 1px #999999; margin-top: 3px; padding: 3px; width: 99%;text-align:center;">
        <asp:CheckBox ID="ShowAll_CheckBox" Text="仅显示当前设备型号/规格下的指令集" 
            AutoPostBack="true" runat="server" Checked="true" 
            oncheckedchanged="ShowAll_CheckBox_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="添加" CssClass="button_bak" 
            onclick="Button2_Click"/>
        <div style="overflow: auto;width: 100%;height:350px;margin:5px 0px 5px 0px;">
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
                    <asp:BoundField HeaderText="名称" DataField="CommandName" />
                    <asp:BoundField HeaderText="标识" DataField="CommandIdentity" />
                    <asp:BoundField HeaderText="指令码" DataField="CommandCode" />
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
        </div>
        <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button_bak"
            onclick="Button1_Click"/>
    </div>
</asp:Content>
