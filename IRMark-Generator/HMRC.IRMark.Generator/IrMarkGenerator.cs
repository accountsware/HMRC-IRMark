using System;
using System.IO;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using System.Xml;

namespace HMRC.IRMark.Generator
{
    /// <summary>
    /// IRMark generation guide: https://www.gov.uk/government/publications/hmrc-irmark-for-gateway-protocol-services
    /// </summary>
    public class IrMarkGenerator : IIrMarkGenerator
    {
        /// <summary>
        /// Generate the IRMark from xml text
        /// </summary>
        /// <param name="xml">Xml text</param>
        /// <returns>IRMark</returns>
        public async Task<string> Generate(string xml)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            return await Generate(xmlDocument);
        }

        /// <summary>
        /// Generate the IRMark from XmlDocument object
        /// </summary>
        /// <param name="xmlDocument">XmlDocument object</param>
        /// <returns>IRMark</returns>
        public async Task<string> Generate(XmlDocument xmlDocument)
        {
            var result = "";
            var c14N = new XmlDsigC14NTransform();
            c14N.LoadInput(xmlDocument);

            using (MemoryStream stream = (MemoryStream)c14N.GetOutput())
            {
                var msBytes = stream.ToArray();

                var sha1 = SHA1.Create();
                var hashBytes = sha1.ComputeHash(msBytes);

                result = Convert.ToBase64String(hashBytes);
            }

            return result;
        }

        /// <summary>
        /// Generate the IRMark from xml file path
        /// </summary>
        /// <param name="xmlPath">Path to xml file</param>
        /// <returns>IRMark</returns>
        public async Task<string> GenerateFromFile(string xmlPath)
        {
            var xml = await File.ReadAllTextAsync(xmlPath);

            return await Generate(xml);
        }
    }
}
