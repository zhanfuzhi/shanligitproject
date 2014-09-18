<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RangeSelectList.aspx.cs" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master"
    Inherits="FrameWork.web.Manager.Module.ShanliTech_HLD.Device.RangeSelectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <div style="border: solid 1px #999999; margin-top: 3px; padding: 3px; width: 99%;text-align:center;">
        <div style="overflow: auto;width: 100%;height:270px;margin-bottom:5px;">
            <asp:GridView ID="GridView1" runat="server" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:TemplateField HeaderText="序号"> 
                        <ItemTemplate>
                        <%#  Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle Wrap="True" />  
                        <HeaderStyle Wrap="False" />    
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="量程">
                        <ItemTemplate>
                            <%#Eval("RangeEndOriginal")%><%#Eval("RangeUnitOriginal")%>
                        </ItemTemplate>
                        
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="Button1" runat="server" Text="确定" CssClass="button_bak"
            onclick="Button1_Click"/>
    </div>
</asp:Content>
