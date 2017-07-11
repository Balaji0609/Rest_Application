﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wesiteApp.EncryptDecryptWebstrar {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EncryptDecryptWebstrar.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Encrypt", ReplyAction="http://tempuri.org/IService1/EncryptResponse")]
        string Encrypt(string plainText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Encrypt", ReplyAction="http://tempuri.org/IService1/EncryptResponse")]
        System.Threading.Tasks.Task<string> EncryptAsync(string plainText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Decrypt", ReplyAction="http://tempuri.org/IService1/DecryptResponse")]
        string Decrypt(string encryptedText);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Decrypt", ReplyAction="http://tempuri.org/IService1/DecryptResponse")]
        System.Threading.Tasks.Task<string> DecryptAsync(string encryptedText);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : wesiteApp.EncryptDecryptWebstrar.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<wesiteApp.EncryptDecryptWebstrar.IService1>, wesiteApp.EncryptDecryptWebstrar.IService1 {
        
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
        
        public string Encrypt(string plainText) {
            return base.Channel.Encrypt(plainText);
        }
        
        public System.Threading.Tasks.Task<string> EncryptAsync(string plainText) {
            return base.Channel.EncryptAsync(plainText);
        }
        
        public string Decrypt(string encryptedText) {
            return base.Channel.Decrypt(encryptedText);
        }
        
        public System.Threading.Tasks.Task<string> DecryptAsync(string encryptedText) {
            return base.Channel.DecryptAsync(encryptedText);
        }
    }
}
