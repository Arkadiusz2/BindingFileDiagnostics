using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

using BindingFile;
using System.Xml;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.SendPort | RuleTargetsEnum.DistributionList)]    
    public class FilterMustBeValid : RuleTemplate
    {
        public FilterMustBeValid()
            : base("Filter must be valid")
        {
        }

        protected override void Validate(object item, List<Message> messages)
        {
            SendPort sendPort = item as SendPort;
            if (sendPort != null)
            {
                ValidateFilterExpression(sendPort.Filter, sendPort.Application.BindingInfo, messages);
                return;
            }

            DistributionList sendPortGroup = item as DistributionList;
            if (sendPortGroup != null)
            {
                ValidateFilterExpression(sendPortGroup.Filter, sendPortGroup.Application.BindingInfo, messages);
                return;
            }

            throw new Exception(string.Format("Unhandled item type '{0}'", item.GetType().ToString()));
        }

        private void ValidateFilterExpression(string filterExpression, BindingInfo bindingInfo, List<Message> messages)
        {            
            if (filterExpression.Length > 0)
            {
                Filter filter;
                if (!Filter.TryParse(filterExpression, out filter))
                {
                    string text = "Filter expression is not a valid xml. BizTalk will ignore it when binding file is imported.";
                    messages.Add(new Message(text));
                }
                
                // Check if receive ports exist
                foreach (string receivePortName in filter.BTS_ReceivePortNames)
                {
                    if (!bindingInfo.ReceivePortCollection.Exists(x => x.Name == receivePortName))
                    {
                        string text2 = string.Format("Filter expression refers to BTS.ReceivePortName: '{0}' of not defined Receive Port", receivePortName);
                        messages.Add(new Message(text2));
                    }
                }
            }
        }
    }
}
