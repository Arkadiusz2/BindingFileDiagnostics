using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BindingFile.Diagnostics.Rules;

using BindingFile;
using System.Xml;
using BindingFile.Diagnostics.Rules.Lib;

namespace BindingFile.Diagnostics.Rules.Generic
{
    [RuleTargets(RuleTargetsEnum.SendPort | RuleTargetsEnum.DistributionList)]    
    public class ValidateErrorReportFilters : RuleTemplate
    {
        public ValidateErrorReportFilters()
            : base("Validate error report filters")
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
            Filter filter;
            string text;
            if (filterExpression.Length > 0 && Filter.TryParse(filterExpression, out filter))
            {                
                foreach (string receivePortName in filter.ErrorReport_ReceivePortNames)
                {
                    ReceivePort receivePort = bindingInfo.ReceivePortCollection.Find(x => x.Name == receivePortName);
                    if (receivePort == null)
                    {
                        text = string.Format("Filter expression refers to ErrorReport.ReceivePortName: '{0}', but the receive port does not exist", receivePortName);
                        messages.Add(new Message(text));
                    }
                    else if (receivePort.RouteFailedMessage == false)
                    {
                        text = string.Format("Filter expression refers to ErrorReport.ReceivePortname: '{0}', but routing for failed messages is not enabled on the receive port.", receivePortName);
                        messages.Add(new Message(text));
                    }
                }

                foreach (string sendPortName in filter.ErrorReport_SendPortNames)
                {
                    SendPort sendPort = bindingInfo.SendPortCollection.Find(x => x.Name == sendPortName);
                    if (sendPort == null)
                    {
                        text = string.Format("Filter expression refers to ErrorReport.SendPortName: '{0}', but the send port does not exist", sendPortName);
                        messages.Add(new Message(text));
                    }
                    else if (sendPort.RouteFailedMessage == false)
                    {
                        text = string.Format("Filter expression refers to ErrorReport.SendPortName: '{0}', but routing for failed messages is not enabled on the send port.", sendPortName);
                        messages.Add(new Message(text));
                    }
                }
            }
        }
    }
}
