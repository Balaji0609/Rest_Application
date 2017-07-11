using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;

namespace wesiteApp.App_Code
{
    /// <summary>
    /// Summary description for XMLFunctions
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class XMLFunctions : System.Web.Services.WebService
    {
        public XMLFunctions()
        {

            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }

        [WebMethod]
        public string GetPassword(string email)
        {
            XmlTextReader reader = null;
            try
            {
                string path = Server.MapPath("App_Data/User.xml");
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (reader["email"] == email)
                    {
                        return reader["password"];
                    }
                }
            }
            catch (Exception)
            {
                return string.Empty;
            }
            finally
            {
                reader.Close();
            }
            return string.Empty;
        }

        [WebMethod]
        public bool AddUser(string email, string password)
        {
            try
            {
                string path = Server.MapPath("App_Data/User.xml");
                XmlDocument source = new XmlDocument();
                source.Load(path);
                XmlElement node = source.CreateElement("user");
                node.SetAttribute("email", email);
                node.SetAttribute("password", password);
                source.DocumentElement.AppendChild(node);
                source.Save(path);
            }
            catch (Exception ex)
            {
                HelperService utilityservice = new HelperService();
                utilityservice.Log(ex.Message);
                return false;
            }
            return true;
        }

        [WebMethod]
        public List<Computer> GetParts()
        {
            List<Computer> PartClc = new List<Computer>();
            Computer Parts = null;
            XmlTextReader reader = null;
            try
            {
                string path = Server.MapPath("App_Data/CParts.xml");
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (reader.AttributeCount == 2)
                    {
                        Parts = new Computer(reader["title"], "$" + reader["price"]);
                        PartClc.Add(Parts);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                reader.Close();
            }
            return PartClc;
        }

        [WebMethod]
        public int GetNumberOfUsers()
        {
            int returnCount = 0;
            XmlTextReader reader = null;
            try
            {
                string path = Server.MapPath("App_Data/User.xml");
                reader = new XmlTextReader(path);
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    if (reader.HasAttributes)
                    {
                        returnCount++;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                reader.Close();
            }
            return (returnCount - 1);
        }
        [WebMethod]
        public bool addPartsToCatalog(Computer userPart)
        {
            try
            {

                string path = Server.MapPath("App_Data/CParts.xml");
                XmlDocument PartXML = new XmlDocument();
                PartXML.Load(path);
                XmlElement newPart = PartXML.CreateElement("Parts");
                newPart.SetAttribute("title", userPart.PartName);
                newPart.SetAttribute("price", userPart.price);
                PartXML.DocumentElement.AppendChild(newPart);
                PartXML.Save(path);


            }
            catch (Exception ex)
            {
                HelperService utilityservice = new HelperService();
                utilityservice.Log(ex.Message);
                return false;
            }

            return true;

        }

        [WebMethod]
        public List<string> GetPartDetails(string PartName)
        {
            XmlTextReader readPart = null;
            List<string> PricePart = new List<string>();
            //String element;
            try
            {
                string path = Server.MapPath("App_Data/CParts.xml");
                readPart = new XmlTextReader(path);
                readPart.WhitespaceHandling = WhitespaceHandling.None;
                while (readPart.Read())
                {
                    if (readPart["title"] == PartName)
                    {
                        PricePart.Add(readPart["price"]);
                    }
                }
            }
            catch (Exception)
            {
                return null;
            }

            finally
            {
                readPart.Close();
            }
            return PricePart;
        }
      
    }
}
