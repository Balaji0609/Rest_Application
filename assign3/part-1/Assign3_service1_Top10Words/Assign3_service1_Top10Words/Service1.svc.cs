using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Services;


namespace Assign3_service1_Top10Words
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] Top10WordsService(string inputurl)
        {

            WebClient cl = new WebClient();
            // first we read the url and extract the data.
            string webdata = readdatafromurl(inputurl);
            // then we remove the tags from the given url.
            string contentoftheweb = extractthecontent(webdata);
            // Then we perform the splitingwordsfromcontent tempvar.e the counts and return the top10words.
            string[] decndingorderwords = topwordsindesc(contentoftheweb);

            return decndingorderwords;
        }

        public string readdatafromurl(string url)
        {
            System.IO.Stream iostr = null;
            System.IO.StreamReader streamreader = null;
            try
            {
                // first we try and request the url.
                HttpWebRequest requst = (HttpWebRequest)WebRequest.Create(url);
                // then we use the agents and other things to access the url.
                requst.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:6.0a2) Gecko/20110613 Firefox/6.0a2";
                requst.Referer = "http:google.com";
                // we record the response from the url.
                System.Net.WebResponse respns = requst.GetResponse();
                iostr = respns.GetResponseStream();
                // then we open a stream reader.
                streamreader = new System.IO.StreamReader(iostr);
                // we read all the contents of the url from the stream to a string.
                string getcontent = streamreader.ReadToEnd();
                //then we return the obtained contents from the url.
                return getcontent;
            }
            catch
            {
                // if there is failure in the request of the url.
                return string.Empty;
            }
        }

        // this function is used inorder to extract the contents from the url given.
        static string extractthecontent(string inputcontent)
        {
            // these scripts are used for extracting the contents from the url.
            Regex script1 = new Regex(@"<script[^>]*>[\s\S]*?</script>");
            Regex script2 = new Regex(@"<script[^>]*>[\s\S]*?</script>");

            // using the above regex scripts extracting the words i.e removing the unwanted things from the url contents.
            string remvd1 = script1.Replace(inputcontent, "");
            string remvd2 = script2.Replace(remvd1, "");
            string htmlcontent = Regex.Replace(remvd2, @"<[^>]+>|&nbsp;", "").Trim();
            string remvd3 = Regex.Replace(htmlcontent, @"\s{2,}", " ");
            string content = remvd3.Replace('+', ' ');

            return content;
        }

        // this function is used to find the countertemp of all the splitingwordsfromcontent from the content that as been extracted and return the top 10 splitingwordsfromcontent in the descending order.
        public string[] topwordsindesc(string text)
        {
            // intializing the necessary variables.
            int updatedcount = 0;
            int countertemp = 1;
            int tempvar = 0;

            string[] temp = { };
            string wordsfromthecontent = null;
            string[] splitingwordsfromcontent = text.Split(' ');
            string Tmp;

            // Dictionary is used inorder to track the words in the given url.
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            // we are first splitting the words i.e getting all the words from the contents and placing the same into the dictionary.
            for (int i = 0; i < splitingwordsfromcontent.Length;i++)
            {
                Tmp = splitingwordsfromcontent[i];

                wordsfromthecontent = Tmp.ToLower();

                if (dictionary.ContainsKey(wordsfromthecontent))
                {
                    dictionary.TryGetValue(wordsfromthecontent, out updatedcount);
                    updatedcount = updatedcount + 1;
                    dictionary[wordsfromthecontent] = updatedcount;

                }
                else
                {
                    dictionary.Add(wordsfromthecontent, countertemp);
                }

            }

            temp = new string[dictionary.Count];

            // then we order the created dictionary in a descnding order.
            var dataset = from keyval in dictionary.Keys
                        orderby dictionary[keyval] descending
                        select keyval;
            
            // then we add the dictionary words and its number of time repeat and convert it into a string and palce in a array.
            foreach (string keyval in dataset)
            {
                string tp;
                tp = keyval + " " + dictionary[keyval];
                temp[tempvar] = tp;

                tempvar++;

            }

            return temp;
        }

    }
}
