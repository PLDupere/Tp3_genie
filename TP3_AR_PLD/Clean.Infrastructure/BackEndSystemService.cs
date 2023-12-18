using Clean.Core.Entities;
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
        public async Task SendCalculVersementToBackEnd(CalculVersements calculVersements, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(calculVersements, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);
        }

        public async Task SendDemandeAideFinancieresToBackEnd(DemandeAideFinancieres demandeAideFinancieres, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(demandeAideFinancieres, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);
        }

        public async Task SendDossierEtudiantsToBackEnd(DossierEtudiants dossierEtudiants, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(dossierEtudiants, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);
        }

        public async Task SendEtudiantsToBackEnd(Etudiants etudiants, string directory)
        {
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("ns0", "http://EAISolution.Request");

            string xml = XmlTranfromHelper.Serialize(etudiants, namespaces);

            await File.WriteAllTextAsync(directory + "Request" + DateTime.Now.Ticks + ".xml", xml);
        }
    }
}
