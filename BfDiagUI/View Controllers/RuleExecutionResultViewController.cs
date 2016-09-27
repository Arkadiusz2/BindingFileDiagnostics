using BfDiagUI.API;
using BindingFile;
using BindingFile.Diagnostics.Engine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BfDiagUI
{
    public class RuleExecutionResultViewController : BaseViewController<DataGridView, List<RuleExecutionEventArgs>>
    {
        public RuleExecutionResultViewController(DataGridView control)
            : base(control)
        {
        }

        public ImageList ImageList {get; set; }

        public override void Bind()
        {
            if (this.ImageList == null)
            {
                throw new InvalidOperationException("ImageList property is required");
            }

            int lineCount = 0;

            this.Control.Rows.Clear();

            foreach (RuleExecutionEventArgs e in this.DataSource)
            {
                if (!e.Success)
                {
                    string objectType;
                    string objectName;
                    string address;
                    int lineNumber = 0;

                    // Primary or secondary transport
                    TransportInfo transportInfo = e.Item as TransportInfo;
                    if (transportInfo != null)
                    {
                        objectType = (transportInfo.IsPrimary ? "Primary" : "Secondary") + " Transport of Send Port";
                        objectName = transportInfo.SendPort.Name;

                        if (transportInfo.SendPort.ElementInfo != null && transportInfo.SendPort.ElementInfo.HasLineInfo)
                        {
                            lineNumber = transportInfo.SendPort.ElementInfo.LineNumber;
                        }

                        if (transportInfo.SendPort.IsStatic)
                        {
                            address = transportInfo.Address;
                        }
                        else
                        {
                            address = "Dynamic";
                        }
                    }
                    else
                    {
                        // Receive location
                        ReceiveLocation receiveLocation = e.Item as ReceiveLocation;
                        if (receiveLocation != null)
                        {
                            objectType = "Receive Location";
                            objectName = receiveLocation.Name;
                            address = receiveLocation.Address;

                            if (receiveLocation.ElementInfo != null && receiveLocation.ElementInfo.HasLineInfo)
                            {
                                lineNumber = receiveLocation.ElementInfo.LineNumber;
                            }
                        }
                        else
                        {
                            // Orchestration
                            ServiceRef orchestration = e.Item as ServiceRef;
                            if (orchestration != null)
                            {
                                objectType = "Orchestration";
                                objectName = orchestration.Name;
                                address = "";

                                if (orchestration.ElementInfo != null && orchestration.ElementInfo.HasLineInfo)
                                {
                                    lineNumber = orchestration.ElementInfo.LineNumber;
                                }
                            }
                            else
                            {
                                SendPort sendPort = e.Item as SendPort;
                                if (sendPort != null)
                                {
                                    objectType = "Send Port";
                                    objectName = sendPort.Name;
                                    address = sendPort.PrimaryTransport.Address;
                                    if (sendPort.ElementInfo != null && sendPort.ElementInfo.HasLineInfo)
                                    {
                                        lineNumber = sendPort.ElementInfo.LineNumber;
                                    }
                                }
                                else
                                {
                                    DistributionList sendPortGroup = e.Item as DistributionList;
                                    if (sendPortGroup != null)
                                    {
                                        objectType = "Send Port Group";
                                        objectName = sendPortGroup.Name;
                                        address = "";

                                        if (sendPortGroup.ElementInfo != null && sendPortGroup.ElementInfo.HasLineInfo)
                                        {
                                            lineNumber = sendPortGroup.ElementInfo.LineNumber;
                                        }
                                    }
                                    else
                                    {
                                        ReceivePort receivePort = e.Item as ReceivePort;
                                        if (receivePort != null)
                                        {
                                            objectType = "Receive Port";
                                            objectName = receivePort.Name;
                                            address = "";

                                            if (receivePort.ElementInfo != null && receivePort.ElementInfo.HasLineInfo)
                                            {
                                                lineNumber = receivePort.ElementInfo.LineNumber;
                                            }
                                        }
                                        else
                                        {
                                            ModuleRef moduleRef = e.Item as ModuleRef;

                                            if (moduleRef != null)
                                            {
                                                objectType = "Module Ref";
                                                objectName = moduleRef.Name;
                                                address = "";
                                            }
                                            else
                                            {
                                                objectType = e.Item.GetType().ToString();
                                                objectName = "Write some code to handle this!";
                                                address = "";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (e.Exception != null)
                    {
                        Image image = this.ImageList.Images[ImageKeyName(BindingFile.Diagnostics.Rules.MessageTypeEnum.Error)];
                        lineCount++;
                        this.Control.Rows.Add(image, lineCount, "Exception", objectType, objectName, e.Exception.ToString(), e.BindingRule.Name, lineNumber != 0 ? lineNumber.ToString() : "");
                    }
                    else
                    {
                        foreach (BindingFile.Diagnostics.Rules.Message message in e.Messages)
                        {
                            Image image = this.ImageList.Images[ImageKeyName(message.Type)];
                            lineCount++;
                            this.Control.Rows.Add(image, lineCount, message.Type.ToString(), objectType, objectName, message.Text, e.BindingRule.Name, lineNumber != 0 ? lineNumber.ToString() : "");
                        }
                    }
                }
            }
        }

        public string ImageKeyName(BindingFile.Diagnostics.Rules.MessageTypeEnum messageType)
        {
            switch (messageType)
            {
                case BindingFile.Diagnostics.Rules.MessageTypeEnum.Warning:
                    return "Warning"; 

                case BindingFile.Diagnostics.Rules.MessageTypeEnum.Error:
                    return "Error";

                case BindingFile.Diagnostics.Rules.MessageTypeEnum.Information:
                    return "Information";
            }
            return "";
        }
    }

}
