using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Xml;
using System.Net;
namespace webservice4
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // The below function is used for checking whether the given password does satisfy the given condition.
        public string passcheck(string pass)
        {
            if (Regex.IsMatch(pass, @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"))
            {
                return "okay";
            }
            else
            {
                return "not okay";
            }
        }

        // The below function is used for obtaining the zipcode.
        public string GetInfoByZip(string zip)
        {
            try
            {
                ServiceReference1.USZipSoapClient zipcode = new ServiceReference1.USZipSoapClient();
                XmlNode nodexmlval = zipcode.GetInfoByZIP(zip);
                string cityinxml = nodexmlval.SelectSingleNode("//CITY").LastChild.Value;
                string stateinxml = nodexmlval.SelectSingleNode("//STATE").LastChild.Value;
                return cityinxml + ", " + stateinxml;
            }
            catch (Exception)
            {
                return "Error getting information";
            }
        }
    }
}
