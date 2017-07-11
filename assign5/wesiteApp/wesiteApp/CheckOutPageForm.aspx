<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CheckOutPageForm.aspx.cs" Inherits="wesiteApp.CheckOutPageForm" %>
<%@ Register TagPrefix="Headerz" TagName="WelcomeTag" Src="~/HeaderControlPage.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
     <link rel="Stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <Headerz:WelcomeTag ID="WelcomeTag" runat="server" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="errorLabel" ForeColor="Red"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:Table ID="Table2" runat="server">
                                    <asp:TableRow>
                                        <asp:TableCell VerticalAlign="Top">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="true">Your Cart:</asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell>
                                            <asp:ListBox runat="server" ID="yourCartListBox" Height="200"></asp:ListBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left" VerticalAlign="Top">
                                <asp:Table ID="Table1" runat="server" Width="100%">
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                           <asp:Label ID="Label2" runat="server" Font-Bold="true">Payment:</asp:Label>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label3" runat="server">Total Amount: </asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="totalAmountTextBox" Enabled="false"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label4" runat="server">Name: </asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="nameTextBox"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label5" runat="server">Credit Card Number:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="creditCardTextBox" AutoPostBack="true" OnTextChanged="creditCardTextBox_TextChanged"></asp:TextBox>
                                            
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label6" runat="server">Expiry Date: (mm/dd/yyyy)</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="expiryDateTextBox"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label10" runat="server">Phone:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="phoneTextBox"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                    <asp:TableRow>
                                        <asp:TableCell HorizontalAlign="Right">
                                            <asp:Label ID="Label7" runat="server">Zip:</asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                            <asp:TextBox runat="server" ID="zipTextBox"></asp:TextBox>
                                        </asp:TableCell>
                                    </asp:TableRow>
                                </asp:Table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <div>
                        <br />
                        <br />
                    </div>
                    <asp:Table runat="server" Width="100%">
                        <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center">
                            <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
                                <asp:Button runat="server" ID="confirmButton" Text="Confirm"  OnClick="confirmButton_Click"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />
                    <br />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>
