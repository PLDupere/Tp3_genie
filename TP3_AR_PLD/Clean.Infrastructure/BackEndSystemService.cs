using Clean.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Clean.Infrastructure
{
    public class BackEndSystemService : IBackEndSystemService
    {
        public async Task SendRequestToBackEnd(Request request, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(request, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);

        }
    }
}
