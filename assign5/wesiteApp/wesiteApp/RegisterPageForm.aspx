<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPageForm.aspx.cs" Inherits="wesiteApp.RegisterPageForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twonk Computer Store</title>
     <link rel="Stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell ID="TableCell5" runat="server" HorizontalAlign="Center">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/sales.jpg" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table runat="server" Width="100%">
            <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center">
                    <asp:Table runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label runat="server" ID="errorLabel" ForeColor="Red"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell Height="80px" VerticalAlign="Bottom" HorizontalAlign="Right">
                                <asp:Label ID="Label1" runat="server">Email ID:</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell Height="80px" VerticalAlign="Bottom" HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="emailTextBox"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label2" runat="server">Password:</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell HorizontalAlign="Right">
                                <asp:Label ID="Label3" runat="server">Confirm Password:</asp:Label>
                            </asp:TableCell>
                            <asp:TableCell HorizontalAlign="Left">
                                <asp:TextBox runat="server" ID="confirmPasswordTextBox" TextMode="Password"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ID="TableCell3" runat="server">&nbsp;</asp:TableCell>
                            <asp:TableCell>
                                <asp:Button runat="server" ID="registerButton" OnClick="registerButton_Click" Text="Register" />&nbsp;&nbsp;&nbsp;
                                 <asp:Button runat="server" ID="backbutton" OnClick="backbutton_Click" Text="BackToLogin" />
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Table ID="Table2" runat="server" Width="100%">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell2" runat="server" Style="font-size: 14px;" padding-top="80px"
                    HorizontalAlign="Center" Height="100px">
                    Password Constraints:<br>Must conatin 6 characters minimum.<br>Must have one capital letter and small letter.<br>Must contain atleast one digit and one special character.
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </div>
    </form>
</body>
</html>

