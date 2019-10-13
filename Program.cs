using System;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace xml2json
{
    class Program
    {
        static void Main(string[] args)
        {
            var path2XmlFile = args[0];
            var doc = new XmlDocument();
            doc.Load(File.OpenRead(path2XmlFile));
            var json = JsonConvert.SerializeXmlNode(doc);
            var fileName = Path.GetFullPath(args[0]).Replace("xml", "json");
            File.WriteAllText(fileName, json);
        }
    }
}
