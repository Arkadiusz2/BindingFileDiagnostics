using BindingFile.Diagnostics.Rules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace BindingFile.Diagnostics.Engine
{
    public class CircularReferenceWatcher<T>
        where T : struct
    {
        private Stack<T> _stack = new Stack<T>();

        public CircularReferenceWatcher()
        {
        }

        public void Add(T item)
        {
            if (_stack.Contains(item))
            {
                StringBuilder stackInfo = new StringBuilder();
                stackInfo.AppendLine("Circualr refernce exception.");
                stackInfo.AppendFormat("Configuration section: {0}", item.ToString());
                stackInfo.AppendLine();


                while (_stack.Count > 0)
                {
                    T rs = _stack.Pop();

                    string indicator = (item.Equals(rs)) ? "[circular!] " : "";

                    stackInfo.AppendFormat(" is referenced by {0}configuaration section: {1}", indicator, rs.ToString());
                    stackInfo.AppendLine();
                }

                throw new Exception(stackInfo.ToString());
            }

            _stack.Push(item);
        }
    }

    public struct ReferenceSection
    {
        public string AssemblyName;
        public string ClassName;

        public override bool Equals(object obj)
        {
            return obj is ReferenceSection && this == (ReferenceSection)obj;
        }

        public override int GetHashCode()
        {
            return this.AssemblyName.GetHashCode() ^ this.ClassName.GetHashCode();
        }

        public static bool operator ==(ReferenceSection rs1, ReferenceSection rs2)
        {
            return rs1.AssemblyName == rs2.AssemblyName && rs1.ClassName == rs2.ClassName;
        }

        public static bool operator !=(ReferenceSection rs1, ReferenceSection rs2)
        {
            return !(rs1 == rs2);
        }

        public override string ToString()
        {
            return string.Format("Assembly '{0}' and Class '{1}'", this.AssemblyName, this.ClassName);
        }
    }

    public class ConfigurationLoader : IConfigurationLoader
    {
        private XmlDocument _configuration;
        public string Environment { get; set; }

        public ConfigurationLoader(string filePath, string environment)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            XmlDocument configuration = new XmlDocument();
            configuration.PreserveWhitespace = true;
            configuration.Load(filePath);

            Initialize(configuration, environment);

        }

        public ConfigurationLoader(XmlDocument configuration, string environment)
        {
            Initialize(configuration, environment);
        }

        private void Initialize(XmlDocument configuration, string environment)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            _configuration = configuration;
            this.Environment = environment;
        }

        public Stream LoadConfiguration(IBindingRule bindingRule)
        {
            if (!bindingRule.IsConfigurable)
            {
                return null;
            }

            Stream configurationStream = this.LoadConfiguration(bindingRule.GetType());
            if (configurationStream == null)
            {
                throw new Exception("Cannot load configuration for rule");
            }

            return configurationStream;
        }
        
        private Stream LoadConfiguration(Type bindingRuleType)
        {
            XmlNode ruleConfigurationNode = LoadConfiguration(bindingRuleType.Assembly.FullName, bindingRuleType.FullName);

            Stream outputStream = null;
            if (ruleConfigurationNode != null)
            {
                outputStream = new MemoryStream();

                XmlWriterSettings writerSettings = new XmlWriterSettings();
                writerSettings.OmitXmlDeclaration = true;
                writerSettings.CloseOutput = false;
                writerSettings.Indent = false;

                using (XmlWriter writer = XmlWriter.Create(outputStream, writerSettings))
                {
                    ruleConfigurationNode.WriteTo(writer);
                    writer.Flush();
                }
                
                outputStream.Seek(0, SeekOrigin.Begin);
            }

            return outputStream;
        }

        protected XmlNode LoadConfiguration(string assemblyName, string ruleClass)
        {

            XmlNode ruleConfigurationNode = null;
            CircularReferenceWatcher<ReferenceSection> circularReferenceWatcher = new CircularReferenceWatcher<ReferenceSection>();

            while (true)
            {
                circularReferenceWatcher.Add(new ReferenceSection() { AssemblyName = assemblyName, ClassName = ruleClass });

                // Try environment specific rule
                string xpath = string.Format("Assembly[@Name=\"{0}\"]/Class[@Name=\"{1}\"]/Configuration[@Environment=\"{2}\"]", assemblyName, ruleClass, this.Environment);
                ruleConfigurationNode = _configuration.DocumentElement.SelectSingleNode(xpath);

                // Try generic rule without environment specified
                if (ruleConfigurationNode == null)
                {
                    xpath = string.Format("Assembly[@Name=\"{0}\"]/Class[@Name=\"{1}\"]/Configuration[not(@Environment)]", assemblyName, ruleClass);
                    ruleConfigurationNode = _configuration.DocumentElement.SelectSingleNode(xpath);
                }

                if (ruleConfigurationNode != null)
                {
                    // Make reference to other rule
                    XmlAttribute assemblyRefAttribute = ruleConfigurationNode.Attributes["AssemblyRef"];
                    XmlAttribute classRefAttribute = ruleConfigurationNode.Attributes["ClassRef"];

                    if (assemblyRefAttribute != null || classRefAttribute != null)
                    {
                        // Validate assemblyRef and classRef attributes
                        if (assemblyRefAttribute == null)
                        {
                            throw new NullReferenceException("AssemblyRef");
                        }
                        if (classRefAttribute == null)
                        {
                            throw new NullReferenceException("ClassRef");
                        }

                        assemblyName = assemblyRefAttribute.Value;
                        ruleClass = classRefAttribute.Value;
                        continue;
                    }
                }
                break;
            }
            return ruleConfigurationNode;
        }
    }
}

