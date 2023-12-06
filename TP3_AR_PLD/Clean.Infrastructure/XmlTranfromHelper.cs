using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Clean.Infrastructure
{
    class XmlTranfromHelper
    {
        public static string Serialize<T>(T toSerialize, XmlSerializerNamespaces namespaces)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(toSerialize.GetType());

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (var textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(xmlWriter, toSerialize, namespaces);
                    return textWriter.ToString();
                }
            }
        }
    }
}
