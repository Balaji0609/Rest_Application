using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WordFilter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        // this function is the main fucntion which is published and which is called to do the necessary function.
        public string WordfilterService(string input)
        {

            string inputmod = removethestopwords(input);
            return inputmod;
        }

        // this function is used to remove the tags in the given string so that the string can be processed furtehr.
        public static string removethetagsinthestring(string input)
        {

            int temparrindex = 0;
            bool flag = false;
            if (input != null)
            {
                char[] temparr = new char[input.Length];

                foreach (char ch in input)
                {
                    if (ch == '<')
                    {
                        flag = true;
                        continue;
                    }

                    if (ch == '>')
                    {
                        flag = false;
                        continue;
                    }

                    if (flag == false)
                    {
                        temparr[temparrindex] = ch;
                        temparrindex++;
                    }
                }
                string ret = new string(temparr, 0, temparrindex);
                return ret;
            }
            else
            {
                return null;
            }


        }

        // This function is used for removing the stop words from the string that is given.
        string removethestopwords(string s)
        {
            string output = "";

            // first remove the tags by calling the above function then we processed further for removing the stop words.
            output = removethetagsinthestring(s);

            // replace function takes in two parameters and replaces the one with another.
            if (output != null)
            {
                output = output.Replace(" a ", " ").Replace(" an ", " ").Replace(" in ", " ").Replace(" on ", " ").Replace(" the ", " ").Replace(" is ", " ").Replace(" are ", " ").Replace(" am ", " ");

                return output;
            }
            else
            {
                return null;
            }

        }
    }
}
