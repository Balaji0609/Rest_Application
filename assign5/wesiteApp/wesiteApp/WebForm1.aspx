<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="wesiteApp.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Table ID="Table1" runat="server" Width ="100%">
                                    <asp:TableRow>
                                                    <asp:TableCell>                           
                                                        <br>
                                                    </asp:TableCell>                           
                        </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>                           
                                                         <br>
                                                    </asp:TableCell>                           
                        </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell>                           
                                                         <br>
                                                    </asp:TableCell>                           
                        </asp:TableRow>
                        <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                            <asp:TableCell HorizontalAlign="Center" VerticalAlign="Middle">
        <asp:Label runat="server" Width="100%">Thanks for Shopping with us, You will be recieveing the product in the next 10 buisness days</asp:Label>
   </asp:TableCell>
                                                           
                        </asp:TableRow>
                                    <asp:TableRow HorizontalAlign="Center" VerticalAlign="Middle">
                                        <asp:TableCell>                           

             <asp:Button ID="BackBtn" runat="server" Text="BackToLogin" OnClick="BackBtn_Func"/>
                                        </asp:TableCell>                           
                        </asp:TableRow>

            </asp:Table>
    </div>
    </form>
</body>
</html>
