using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BindingFile;
using BindingFile.Extensions;
using BindingFile.Diagnostics.Rules;
using System.Xml;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.SendPort)]
    public class SendPortMultipleReferences : RuleTemplate
    {
        public SendPortMultipleReferences()
            : base("Send port multiple references")
        {
        }

        private bool IsFilterDefined(string filter)
        {
            if (filter.Length > 0)
            {
                XmlDocument filterXml = new XmlDocument();                
                try
                {
                    filterXml.LoadXml(filter);
                }
                catch
                {                    
                    // If filter is not a valid xml, then filter is not defined
                    // Additionally use BindingFile.Diagnostics.Rules.Generic.FilterMustBeValid rule to check if filter is a valid xml
                    return false;
                }
                return (filterXml.DocumentElement.Name == "Filter" && filterXml.DocumentElement.HasChildNodes);
            }

            return false;
        }

        protected override void Validate(object item, List<Message> messages)
        {
            SendPort sendPort = (SendPort)item;
            List<string> referencedBy = new List<string>();

            if (IsFilterDefined(sendPort.Filter))
            {
                referencedBy.Add("has a filter");
            }
            if (sendPort.BoundSendPortGroups().Any())
            {
                referencedBy.Add("is referenced by a send port group");
            }
            if (sendPort.BoundOrchestrations().Any())
            {
                referencedBy.Add("is referenced by an orchestration");
            }

            if (referencedBy.Count > 1)
            {
                string text = string.Format("Send port {0} at the same time.", string.Join(" and ", referencedBy.ToArray()));
                messages.Add(new Message(MessageTypeEnum.Warning, text));
            }
        }
    }
}
