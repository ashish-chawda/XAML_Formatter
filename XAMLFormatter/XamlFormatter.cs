using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace XAMLFormatter
{
    public static class XamlFormatter
    {
        public static bool FormatXaml(string inputFilePath, string outputFilePath)
        {
            bool isFormattingSuccess = false;
            try
            {
                XDocument doc = XDocument.Load(inputFilePath, LoadOptions.PreserveWhitespace);

                XDocument document = XDocument.Parse(doc.ToString());

                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true
                ,
                    IndentChars = " "
                ,
                    NewLineChars = "\r\n"
                ,
                    NewLineHandling = NewLineHandling.Entitize

                   ,
                    NewLineOnAttributes = true
                    ,
                    OmitXmlDeclaration = true,
                    WriteEndDocumentOnClose = true
                };

                using (XmlWriter writer = XmlWriter.Create(outputFilePath, settings))
                {
                    document.Save(writer);
                }
                isFormattingSuccess = true;
            }
            catch (Exception ex)
            {
                return isFormattingSuccess;
                //log the exception in .log file
            }
            return isFormattingSuccess;
        }
    }
}
