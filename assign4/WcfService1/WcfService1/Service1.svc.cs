using System;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static string error = "";

        public string Verification_Service(string xmlpath, string xsdpath)
        {

        // Create the XmlSchemaSet class.


        // Add the schema to the collection before performing validation


        //Converting the local path into a uri.
        //Uri xsduri = new Uri(@"C:\Users\twonk\Desktop\Persons.xsd");
        //string convrtd = xsduri.ToString();

            XmlSchemaSet sc = new XmlSchemaSet();
            sc.Add(null, xsdpath);

            // Define the validation settings.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc; // Association
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            // Create the XmlReader object.
            
            // Add the schema to the collection before performing validation


            //Converting the local path into a uri.
            //Uri xmluri = new Uri(@"C:\Users\twonk\Desktop\Persons.xml");
            //string convrtdxml = xmluri.ToString();

            XmlReader reader = XmlReader.Create(xmlpath, settings);


            // Parse the file. 

            while (reader.Read()) ; // will call event handler if invalid

            reader.Close();
            if (error == "")
            {
                return "success";
            }
            else
                return error;
        }
        // Display any validation errors.
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
           error += "Validation Error:" + e.Message;
        }

        public string Transformation_Service(string xmlpath,string xslpath)
        {
            string htmlfilestr = string.Empty;
            if(xmlpath == null || xslpath == null)
            {
                string ret = "Files Required Not Found";
                return ret;
            }

            // try
            // {
            //string res;
            //htmlfile = htmlfile + "\\Assign4.html";
            //TextWriter StreamWriterobj = null;
            //StreamReader Streamreaderobj = null;
            //StreamWriterobj = new StreamWriter(htmlfile);
            XPathDocument doc = new XPathDocument(xmlpath);
            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(xslpath);
            
            //StreamWriterobj.Close();
            


            

            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Append text to an existing file named "WriteLines.txt".
            //StreamWriter sb = new StreamWriter();
            using (TextWriter outputFile = new StreamWriter(mydocpath + @"\WriteLines.txt", true))
            {
                xt.Transform(doc, null, outputFile);
                //htmlfilestr = sb.ToString();
                //Streamreaderobj = new StreamReader(mydocpath + @"\WriteLines.txt", true);
                //while (Streamreaderobj.ReadLine() != null)
                //{
                //    htmlfilestr += Streamreaderobj.ReadLine();
                //}
                //Streamreaderobj.Close();
                //htmlfilestr = File.ReadAllText(htmlfile);
                // outputFile.WriteLine("Fourth Line");
                outputFile.Close();
             }
            using (TextReader readr = new StreamReader(mydocpath + @"\WriteLines.txt", true))
            {
                while (readr.ReadLine() != null)
                {
                    htmlfilestr += readr.ReadLine();
                }
                readr.Close();
            }

            return htmlfilestr;
            //}
           // catch (Exception ex)
           // {
                //StreamWriterobj.Close();
                //Streamreaderobj.Close();
            //    return ex.Message;
                //Console.WriteLine(ex.Message);
            //}
            //string x = Console.ReadLine();
        }
    }
}
