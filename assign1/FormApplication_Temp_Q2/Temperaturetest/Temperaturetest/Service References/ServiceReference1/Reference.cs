﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Temperaturetest.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FtoC", ReplyAction="http://tempuri.org/IService1/FtoCResponse")]
        double FtoC(double f);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/FtoC", ReplyAction="http://tempuri.org/IService1/FtoCResponse")]
        System.Threading.Tasks.Task<double> FtoCAsync(double f);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CtoF", ReplyAction="http://tempuri.org/IService1/CtoFResponse")]
        double CtoF(double c);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/CtoF", ReplyAction="http://tempuri.org/IService1/CtoFResponse")]
        System.Threading.Tasks.Task<double> CtoFAsync(double c);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Temperaturetest.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Temperaturetest.ServiceReference1.IService1>, Temperaturetest.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public double FtoC(double f) {
            return base.Channel.FtoC(f);
        }
        
        public System.Threading.Tasks.Task<double> FtoCAsync(double f) {
            return base.Channel.FtoCAsync(f);
        }
        
        public double CtoF(double c) {
            return base.Channel.CtoF(c);
        }
        
        public System.Threading.Tasks.Task<double> CtoFAsync(double c) {
            return base.Channel.CtoFAsync(c);
        }
    }
}
