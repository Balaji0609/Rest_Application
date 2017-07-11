<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPageForm.aspx.cs" Inherits="wesiteApp.AdminPageForm" %>
<%@ Register TagPrefix="Headerz" TagName="WelcomeTag" Src="~/HeaderControlPage.ascx" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Twonk Computer Store Admin Page</title>
     <link rel="Stylesheet" type="text/css" href ="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table2" runat="server" Width="100%" Height="65px">
            <asp:TableRow>
                <asp:TableCell ColumnSpan="2" HorizontalAlign="Center">
                    <Headerz:WelcomeTag ID="WelcomeTag" runat="server" />
                </asp:TableCell>
            </asp:TableRow>         
        </asp:Table>
<asp:Table ID="Table1" runat="server" Width ="100%" Height="464px">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="hdrLabel" runat="server" Text="Add Computer Part To Catalogue" Font-Bold="true"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="PartName" Text="Part Name: " runat="server"></asp:Label>
                                <asp:TextBox ID="txtPartName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="addPartValidation" ControlToValidate="txtPartName"
                                    ValidationGroup="addPartDetails" ErrorMessage="*" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="PartPrice" Text="Part Price: " runat="server"></asp:Label>
                                <asp:TextBox ID="txtPartPrice" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="addPartValidation2" ControlToValidate="txtPartPrice"
                                    ValidationGroup="addPartDetails" ErrorMessage="*" runat="server" ForeColor="Red"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPartPrice"
                                    ErrorMessage="Please Enter Numbers" ForeColor="Red" ValidationExpression="^[0-9]*\.?[0-9]+$"
                                    ValidationGroup="addPartDetails"></asp:RegularExpressionValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btnAddPart" runat="server" Text="Add Part" OnClick="btnClick_AddPartToCatalog"
                                    CausesValidation="true" ValidationGroup="addPartDetails" />
                            </asp:TableCell>                           
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="Label1" runat="server" Text="List of All Parts" Font-Bold="true"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:ListBox ID="ListOfNewParts" runat="server" Enabled="true" Height="150"></asp:ListBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Button ID="btnViewPartDetails" runat="server" Text="View Part Details" OnClick="btnClick_ViewPartDetails" />
                            </asp:TableCell>
                        </asp:TableRow>
                            <asp:TableRow>
                            <asp:TableCell>
                                <asp:Textbox ID="Label2" runat="server" Visible="false"></asp:Textbox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblPartName" runat="server"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblPartPrice" runat="server"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblErrorMessage" runat="server" Visible="false" ForeColor="Blue"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>    
    </div>
    </form>
</body>
</html>
