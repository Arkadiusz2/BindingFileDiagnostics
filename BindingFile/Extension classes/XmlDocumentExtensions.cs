using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile
{
    public static class XmlDocumentExtensions
    {
        public static bool TryLoadXml(string xml, out XmlDocument xmlDocument)
        {
            Exception exception;
            return TryLoadXml(xml, out xmlDocument, out exception);
        }

        public static bool TryLoadXml(string xml, out XmlDocument xmlDocument, out Exception exception)
        {
            exception = null;
            xmlDocument = new XmlDocument();
            try
            {
                xmlDocument.LoadXml(xml);
                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                return false;
            }
        }
    }
}
