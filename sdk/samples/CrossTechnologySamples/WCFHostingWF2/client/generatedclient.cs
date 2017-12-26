﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://Microsoft.ServiceModel.Samples", ClrNamespace="Microsoft.ServiceModel.Samples")]

namespace Microsoft.ServiceModel.Samples
{
    using System.Runtime.Serialization;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class WorkflowAborted : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string MessageField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="Microsoft.ServiceModel.Samples.IEchoable")]
    public interface IEchoable
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IEchoable/Echo", ReplyAction="http://Microsoft.ServiceModel.Samples/IEchoable/EchoResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(Microsoft.ServiceModel.Samples.WorkflowAborted), Action="http://Microsoft.ServiceModel.Samples/IEchoable/EchoWorkflowAbortedFault", Name="WorkflowAborted")]
        string Echo(string theString);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface IEchoableChannel : Microsoft.ServiceModel.Samples.IEchoable, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class EchoableClient : System.ServiceModel.ClientBase<Microsoft.ServiceModel.Samples.IEchoable>, Microsoft.ServiceModel.Samples.IEchoable
    {
        
        public EchoableClient()
        {
        }
        
        public EchoableClient(string endpointConfigurationName) : 
                base(endpointConfigurationName)
        {
        }
        
        public EchoableClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EchoableClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress)
        {
        }
        
        public EchoableClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public string Echo(string theString)
        {
            return base.Channel.Echo(theString);
        }
    }
}

