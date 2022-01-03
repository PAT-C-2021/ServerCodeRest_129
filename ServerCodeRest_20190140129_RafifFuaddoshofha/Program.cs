using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using ServiceRest_2019140129_RafifFuaddoshofha;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;

namespace ServerCodeRest_20190140129_RafifFuaddoshofha
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost hostObj = null;
            Uri address = new Uri("http://localhost:8733/Design_Time_Addresses/ServiceRest_2019140129_RafifFuaddoshofha/Service1/");
            BasicHttpBinding bind = new BasicHttpBinding();
            try
            {
                hostObj = new ServiceHost(typeof(TI_UMY), address);
                //ALAMAT BASE ADDRESS
                hostObj.AddServiceEndpoint(typeof(ITI_UMY), bind, "");
                //ALAMAT ENDPOINT
                //wsdl
                ServiceMetadataBehavior smb = new
               ServiceMetadataBehavior(); //Service Runtime Player
                smb.HttpGetEnabled = true; //untuk mengaktifkan wsdl (dibuka saat development, tidak untuk dibuka)
                hostObj.Description.Behaviors.Add(smb);
                //mex
                Binding mexbind =
               MetadataExchangeBindings.CreateMexHttpBinding();
                hostObj.AddServiceEndpoint(typeof(IMetadataExchange),
                mexbind, "mex");
                hostObj.Open();
                Console.WriteLine("Server is ready!!!!");
                Console.ReadLine();
                hostObj.Close();
            }
            catch (Exception ex)
            {
                hostObj = null;
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}

