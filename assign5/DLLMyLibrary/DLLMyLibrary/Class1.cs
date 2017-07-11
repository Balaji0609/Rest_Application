using System;
using System.Text.RegularExpressions;

namespace DLLMyLibrary
{
    public class Class1
    {
        public string ValidatePhone(string phone)
        {
            string phone_regex = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            try
            {
                if (!String.IsNullOrEmpty(phone))
                {
                    if (Regex.IsMatch(phone, phone_regex))
                        return "Valid US Phone Number";
                    else
                        return "Invalid US Phone Number";
                }
                else
                    return "Input Error";
            }
            catch
            {
                return "Input Error";
            }
        }

        // Validate Email Id

        public string ValidateEmail(string emailid)
        {
            string email_regex =
                @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
         + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
         + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
         + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

            try
            {
                if (!String.IsNullOrEmpty(emailid))
                {
                    if (Regex.IsMatch(emailid, email_regex))
                        return "Valid Email Id";
                    else
                        return "Invalid Email Id";
                }
                else
                    return "Input Error";
            }
            catch
            {
                return "Input Error";
            }
        }

        // Validate Zip

        public string ValidateZip(string zip)
        {
            string zip_regex = "(^[0-9]{5}$)|(^[0-9]{5}-[0-9]{4}$)";
            try
            {
                if (!String.IsNullOrEmpty(zip))
                {
                    if (Regex.IsMatch(zip, zip_regex))
                        return "Valid US Zip Code";
                    else
                        return "Invalid US Zip Code";
                }
                else
                    return "Input Error";
            }
            catch
            {
                return "Input Error";
            }
        }
    }
}
