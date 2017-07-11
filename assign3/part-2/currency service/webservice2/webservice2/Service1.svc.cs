using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Net;

namespace webservice2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string CurrencyConvert(double value, string fromCurrency, string toCurrency)
        {

            //Grab your values and build your Web Request to the API
            string api = String.Format("https://www.google.com/finance/converter?a={0}&from={1}&to={2}&meta={3}", value, fromCurrency, toCurrency, Guid.NewGuid().ToString());

            //Make your Web Request and grab the results
            var req = WebRequest.Create(api);

            //Get the Response
            var strmreader = new StreamReader(req.GetResponse().GetResponseStream(), System.Text.Encoding.ASCII);

            //this line obtains the value from the service.
            var convertedval = Regex.Matches(strmreader.ReadToEnd(), "<span class=\"?bld\"?>([^<]+)</span>")[0].Groups[1].Value;
            return convertedval;
        }


    }
}
