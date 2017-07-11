<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Initial_Page.aspx.cs" Inherits="wesiteApp.Initial_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p><div align="center"><b>Introduction</b></div><br>
<br>
<br>
This project we develop a complete service oriented web application with access control which involves several services for the purpose for the application to function. In this project I developed a computer sales shopping website which is completely service oriented and whose services are deployed in westrar server and also includes several features like session maintenance, caching, cookies, DLL classes access controls etc. Name of the Online store is &ldquo;Twonk Computer Sales&rdquo;.<br>
This Application a user to login to it, in case of admin user he/she is directed to their corresponding access page where they can add items to the catalogue. And in case of buyer he/she can purchase item via application, after logging in a session is maintained and the data is stored in the session. After a user adds item to the cart for purchasing he/she can click on checkout wherein they will be directed to the check in page, where they can add details of credit card etc and buy the items.</p>
<br><br>
<p><div align="center"><b>Pages involved in the application and their functionality: (GUI)</b></div><br>
<br>
<br>
<div align="center">This project consists of several pages in it namely:</div><br>
<br><br>
1) Login Page &ndash; This page is used for logging into the application, both the kind of user the admin and the application user must login to the application before he/she can either add items into the catalogue or he/she purchases an item from the store.<br>
2) Registration Page &ndash; Any user who is new to the store/site must register with the store before he/she can buy any product. This pages provides facility for a user to register with the application, remember that the password of that the user provides must follow certain conditions. A user can go back to the login page by clicking on the back to login button.<br>
3) User Page &ndash; In case of this page, it belongs to normal user who is willing to purchase items from the store via the application. This page includes a box that contains all the list of items available in the store which can be added to the cart or any item can be deleted from the cart as per the wish and they can proceed to the checkout.<br>
4) Admin Page &ndash; This page belongs to the super user or the admin user, they are provided with the password, and he/she can login to this page via that username and password, it is provided by the organization. Once he/she logs in they can add new items to the catalogue so that they can be displayed to the end user and so that it can be available for selling.<br>
5) Checkout Page &ndash; This page involves all the details of the products that the user wishes to purchase and the total costs of the purchases, and this page also asks for credit card information etc from the user for processing the purchase. <br>
6) The End page / Thank You page &ndash; This is the page that will be displayed once the purchase as been made and the user wishes to buy the items. A user can navigate back to the login page from this page by clicking on the back to login button present in this page. And can repeat the steps again for purchasing of other products.<br>
7) Initial_Page &ndash; This page consist of the description of the application, the tryit page and description of all the services that have been developed.<br>
<br>
<br>
<div align="center"><b>Services Used in the Application: (Service)</b></div><br>
<br>
<br><div align="center">Newly Created Services:</div><br>
<br>
<div align="center">There are two services that have been newly created which are mostly used for form validation and for the purpose of the XML processing:</div><br>
<br>
1) XMLFunctions: This service is present in the APP_Code folder in the project and which is used for the purpose of handling the Data of user login and that of the catalogue data. This services contains all the functions that is used for writing reading etc from the XML file.<br>
2) HelperService: This service consists of several validation methods which are very simple and used for validating several forms that are used in the application.<br>
<br>The remaining services are already developed and deployed in the webstrar server during the assignment &ndash; 3, they are:<br>
<br>
1) Encryption and Decryption Service: The purpose of this service is in order to encrypt and decrypt the password that is been given by the user while logging in for security purposes. This is done using a symmetric key. <br>
2) Credit Card Validation Service: The purpose of this service is in order to validate the card number that is given by the user and to select the type of card that the user as submitted. <br>
3) Password verification service: The purpose of this service is in order to validate the password given by the user with following constraints. <br>
4) Currency Convertor Service: The purpose of this service is in order to convert currency of one format to another. <br>
5) There are several other simple services which have been exclusively developed for this application and used they are:</p>

<p>&bull; GetPartDetails &ndash; used for obtaining details of the part in the catalogue.<br>
&bull; AddPartToCatalogue &ndash; used for the purpose of adding part to the catalogue.<br>
&bull; LogMethod &ndash; This is used for the purpose of recording any error that may occur during running.<br>
&bull; AddUserToLogin &ndash; This method is used for the purpose of adding new users into the application.<br>
<br><br>
<div align="center"><b>
Files/Database Involved in the Application: (Database)</b></div><br>
<br><br>
Log.txt &ndash; This file consists of any error log that may have occurred during the runtime other than validation errors, user errors etc.<br>
CParts.xml &ndash; This is an xml file which is the catalogue, it contains all the information about the parts that is being sold via the application.<br>
User.xml &ndash; This file consists of names of all the users and their passwords who have registered with the application, the passwords are stored in encrypted format so it is very hard to decode them.<br>
</p>
<br><br>
    <div>
    
    <table>
  <tr>
    <th colspan="5">This page is deployed at: http://webstrar13.fulton.asu.edu/index.html</th>
  </tr>
          <tr>
    <th colspan="5">The Main Application is deployed at:http://webstrar13.fulton.asu.edu/ </th>
  </tr>
  <tr>
    <td colspan="5">The project is Developed by : Balaji Chandrasekaran(1208948451)</td>
  </tr>
          <tr>
    <td colspan="5">The Following Are The Services that have been used in the project:</td>
  </tr>
  <tr>
    <td>Provider name</td>
    <td>Service name,input &amp; ouput</td>
    <td>TryIt<br>Link</td>
    <td>Service Description</td>
    <td>Resources used to implement</td>
  </tr>
  <tr>
    <td>Balaji<br>Chandrasekaran</td>
    <td>Encryption and<br>decryption:<br>Input: String<br>Output: String</td>
    <td>http://webstrar13.fulton.asu.edu/page1/<br> TRYIT PAGE: http://webstrar13.fulton.asu.edu/page8/</td>
    <td>.The purpose of this service is in order to encrypt and decrypt the password that is been given by the user while logging in for security purposes. This is done using a symmetric key.</td>
    <td>Use library class and local<br>component to implement the,service</td>
  </tr>
  <tr>
    <td>BalajiChandrasekaran</td>
    <td>Currency Convertor<br>Input: double value to be converted.<br>string: curr from<br>string : curr to<br>output: the converted value.</td>
    <td>http://webstrar13.fulton.asu.edu/page0/<br> TRYIT PAGE: http://webstrar13.fulton.asu.edu/page7/</td>
    <td>The purpose of this service is inorder to convert currency of one format to another.</td>
    <td>Use library class and local component to implement the,service and https://www.google.com/finance/converter?a={0}&amp;from={1}&amp;to={2}&amp;meta={3} service link.</td>
  </tr>
  <tr>
    <td>BalajiChandrasekaran</td>
    <td>Password Verification Service.<br>Input : Password:string<br>output: Verfication result:string</td>
    <td>http://webstrar13.fulton.asu.edu/page2/<br>TRYIT PAGE:http://webstrar13.fulton.asu.edu/page9/</td>
    <td>The purpose of this service is in order to validate the password given by the user with following constraints.</td>
    <td>Use library class and local<br>component to implement the,service</td>
  </tr>
  <tr>
    <td>BalajiChandrasekaran</td>
    <td>Top10Words,Input,:- string “url”,<br>Output,:- An array of words containg top 10 string <br>which is printed as a string of,words</td>
    <td>http://webstrar13.fulton.asu.edu/page4/<br> TRYIT PAGE:http://webstrar13.fulton.asu.edu/page10/</td>
    <td>This service is used for the purpose of<br>extracting content from a webpage and to find the most repeated 10 words in that page.</td>
    <td>Use library class and local<br>component to implement the,service</td>
  </tr>
  <tr>
    <td>BalajiChandrasekaran</td>
    <td>Word Filter,Input :- A string,<br>Output: - A string without tags and stop words.</td>
    <td>http://webstrar13.fulton.asu.edu/page5/<br> TRYIT PAGE:http://webstrar13.fulton.asu.edu/page10/</td>
    <td>A service used for the purpose of removing stop words and tags.</td>
    <td>Use library class and local<br>component to implement the,service</td>
  </tr>
  <tr>
    <td>BalajiChandrasekaran</td>
    <td>Credit Card Validation.<br>Input :- Credit card num<br>Ouput :- Type of credit card</td>
    <td>http://webstrar13.fulton.asu.edu/page3/<br> TRYIT PAGE: http://webstrar13.fulton.asu.edu/page6/</td>
    <td>The purpose of this service is inorder to validate the card number that is given by the user and to select the type of card that the user as submitted.</td>
    <td>Use library class and local<br>component to implement the,service</td>
  </tr>
</table></div>
                    <asp:Table runat="server" Width="132%">
                        <asp:TableRow VerticalAlign="Middle" HorizontalAlign="Center">
                            <asp:TableCell VerticalAlign="Middle" HorizontalAlign="Center">
                                <asp:Button runat="server" ID="Gotobtn" Text="Application"  OnClick="Gotobtn_onclick"/>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
    </form>
</body>
</html>
