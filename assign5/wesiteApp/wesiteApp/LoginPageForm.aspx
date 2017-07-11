<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPageForm.aspx.cs" Inherits="wesiteApp.LoginPageForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twonk Computer Store</title>
    <link rel="Stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Center">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/sales.jpg" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow ID="TableRow1" runat="server">
                            <asp:TableCell ID="TableCell1" runat="server">
                                <asp:Label runat="server" ID="errorLabel" ForeColor="Red"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow2" runat="server">
                            <asp:TableCell ID="TableCell3" runat="server" Height="80px" VerticalAlign="Bottom"
                                HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server">Email: </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell5" runat="server" Height="80px" VerticalAlign="Bottom"
                                HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="emailTextBox"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow3" runat="server">
                            <asp:TableCell ID="TableCell6" runat="server" HorizontalAlign="Right">
                                <asp:Label ID="Label2" runat="server">Password: </asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ID="TableCell7" runat="server" HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow4" runat="server">
                            <asp:TableCell ID="TableCell8" runat="server">&nbsp;</asp:TableCell>
                            <asp:TableCell ID="TableCell9" runat="server" HorizontalAlign="Left">
                                <asp:Button runat="server" ID="loginButton" OnClick="loginButton_Click" Text="  Login  " />&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button runat="server" ID="Button1" OnClick="RegisterButton_Click" Text="Register" />                            
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="TableRow5" runat="server">
                            <asp:TableCell ID="TableCell10" runat="server">&nbsp;</asp:TableCell>
                            <asp:TableCell ID="TableCell11" runat="server">
                                <p style =" color:crimson">!!New users must register before logging in!!</p>
                                </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        
    </div>
    </form>
</body>
</html>