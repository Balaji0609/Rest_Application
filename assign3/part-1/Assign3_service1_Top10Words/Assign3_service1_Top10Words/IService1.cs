using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Net;
using System.Text.RegularExpressions;
using System.ServiceModel.Web;
using System.Text;

namespace Assign3_service1_Top10Words
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string[] Top10WordsService(string url);

        [OperationContract]
        string readdatafromurl(string url);

        [OperationContract]
        string[] topwordsindesc(string text);

        // TODO: Add your service operations here
    }
}
