using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string Verification_Service(string xmlpath, string xsdpath);

        [OperationContract]
        string Transformation_Service(string xmlpath, string xslpath);

        // TODO: Add your service operations here
    }


   
}
