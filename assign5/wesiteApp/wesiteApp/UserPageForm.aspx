<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPageForm.aspx.cs" Inherits="wesiteApp.UserPageForm" %>
<%@ Register TagPrefix="Headerz" TagName="WelcomeTag" Src="~/HeaderControlPage.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title> Part Catalog</title>
     <link rel="Stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:Table runat="server" Width="100%">
        <asp:TableRow>
            <asp:TableCell>
                <div>
        <asp:Table ID="Table4" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <Headerz:WelcomeTag ID="WelcomeTag" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Table ID="Table1" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label runat="server" ID="errorLabel" ForeColor="red"></asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true">Available Parts: (Name | Price)</asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:ListBox runat="server" ID="availablePartsListBox" Height="200"></asp:ListBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Button runat="server" ID="addToCartButton" Text="Add to Cart" OnClick="addToCartButton_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Table ID="Table2" runat="server" Width="100%">
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:Label ID="Label2" runat="server" Font-Bold="true">Your Cart</asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:ListBox runat="server" ID="yourCartListBox" Height="200" Width="400"></asp:ListBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Button runat="server" ID="removeFromCartButton" Text="Remove from Cart" OnClick="removeFromCartButton_Click" />
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <div>
                </div>
                <br />
                <br />
                <div>
                    <asp:Table ID="Table3" runat="server" Width =" 100%">
                        <asp:TableRow>
                            <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
                                <asp:Button runat="server" ID="proceedToCheckoutButton" Text="Proceed to Checkout"
                                    OnClick="proceedToCheckoutButton_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
                <br />
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
