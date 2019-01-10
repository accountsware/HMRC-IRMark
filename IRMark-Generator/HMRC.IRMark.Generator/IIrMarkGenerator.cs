using System.Threading.Tasks;
using System.Xml;

namespace HMRC.IRMark.Generator
{
    public interface IIrMarkGenerator
    {
        Task<string> Generate(string xml);

        Task<string> Generate(XmlDocument xmlDocument);

        Task<string> GenerateFromFile(string xmlPath);
    }
}