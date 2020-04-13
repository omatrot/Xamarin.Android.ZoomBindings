using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace GenerateZoomBindingsMetadata
{
    class Program
    {
        static void Main(string[] args)
        {
            using (XmlReader reader = XmlReader.Create(@"/Users/omatrot/Projects/ZoomBindings/ZoomUtils/obj/Debug/api.xml"))
            {
                using (FileStream fs = new FileStream(@"/Users/omatrot/Projects/ZoomBindings/ZoomUtils/Transforms/Metadata.xml", FileMode.Create))
                {
                    var settings = new XmlWriterSettings();
                    //settings.OmitXmlDeclaration = true;
                    settings.Indent = true;
                    //settings.NewLineOnAttributes = true;

                    using (XmlWriter writer = XmlWriter.Create(fs, settings))
                    {

                        //writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement("metadata");
                        foreach (XElement element in reader.ElementsNamed("package"))
                        {
                            // Grab the package name
                            string packageName = element.Attribute("name").Value;
                            // add this package to a remove node in Metadata.Xml
                            if (!packageName.StartsWith("us.zoom"))
                            {
                                writer.WriteStartElement("remove-node");
                                writer.WriteAttributeString("path", $@"/api/package[@name='{packageName}']");
                                writer.WriteEndElement();
                            }

                        }
                        writer.WriteEndElement();
                        writer.Flush();
                    }
                }
            }
        }
        
    }
}
