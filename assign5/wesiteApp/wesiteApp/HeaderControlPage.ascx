<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderControlPage.ascx.cs" Inherits="wesiteApp.HeaderControlPage" %>
<div>
    <asp:Table runat="server" Width="100%" Height="184px">
        <asp:TableRow>
            <asp:TableCell HorizontalAlign="Right">
                <img alt="" src="/sales.jpg"/>
            </asp:TableCell>
            <asp:TableCell HorizontalAlign="Center">
                <asp:Table runat="server">
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:Label ID="Label1" runat="server">Welcome&nbsp;</asp:Label>
                            <asp:Label runat="server" ID="emailLabel" ForeColor="Brown"></asp:Label>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Right">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="logoutButton_Click" Text="Logout"></asp:LinkButton>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</div>
