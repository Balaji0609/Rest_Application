using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace webservice1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string creditcardvalidation(string Cnum)
        {
            //the credit card number must be atleast of length else it should return an invalid card.
            if (Cnum.Length < 13)
            {
                string str = "Invalid Card Number";
                return str;
            }
            else
            {
                // This regex is used for finding out whether the given card is a VISA card.
                if (Regex.IsMatch(Cnum, "(^4[0-9]{12}(?:[0-9]{3})?$)"))
                {
                    return "Visa Card";
                }
                // This regex is used for finding out whether the given card is a MASTER card.
                if (Regex.IsMatch(Cnum, "(^5[1-5][0-9]{14}$)"))
                {
                    return "Master card";
                }
                // This regex is used for finding out whether the given card is a AMERICAN EXPRESS card.
                if (Regex.IsMatch(Cnum, "(^3[47][0-9]{13}$)"))
                {
                    return "American Express";
                }
                // This regex is used for finding out whether the given card is a DINERS card.
                if (Regex.IsMatch(Cnum, "(^3(?:0[0-5]|[68][0-9])[0-9]{11}$)"))
                {
                    return "Diners Club";
                }
                // This regex is used for finding out whether the given card is a DISCOVER card.
                if (Regex.IsMatch(Cnum, " ^6(?:011|5[0-9]{2})[0-9]{12}$"))
                {
                    return "Discover card";
                }
                // This regex is used for finding out whether the given card is a JCB card.
                if (Regex.IsMatch(Cnum, @"^(?:2131|1800|35\d{3})\d{11}$"))
                {
                    return "JCB card";
                }
                else
                {
                    return "Invalid Card Number";
                }

            }

        }


    }
}
