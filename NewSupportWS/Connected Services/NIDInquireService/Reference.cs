﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewSupportWS.NIDInquireService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NIDInquireRequest", Namespace="http://schemas.datacontract.org/2004/07/Presentation.NIDInquire")]
    [System.SerializableAttribute()]
    public partial class NIDInquireRequest : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationalIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NationalId {
            get {
                return this.NationalIdField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalIdField, value) != true)) {
                    this.NationalIdField = value;
                    this.RaisePropertyChanged("NationalId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NIDInquireResponse", Namespace="http://schemas.datacontract.org/2004/07/Presentation.NIDInquire")]
    [System.SerializableAttribute()]
    public partial class NIDInquireResponse : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private NewSupportWS.NIDInquireService.NIDInquireResult ResultField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ResponseCodeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResponseMessageField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public NewSupportWS.NIDInquireService.NIDInquireResult Result {
            get {
                return this.ResultField;
            }
            set {
                if ((object.ReferenceEquals(this.ResultField, value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public int ResponseCode {
            get {
                return this.ResponseCodeField;
            }
            set {
                if ((this.ResponseCodeField.Equals(value) != true)) {
                    this.ResponseCodeField = value;
                    this.RaisePropertyChanged("ResponseCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string ResponseMessage {
            get {
                return this.ResponseMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ResponseMessageField, value) != true)) {
                    this.ResponseMessageField = value;
                    this.RaisePropertyChanged("ResponseMessage");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NIDInquireResult", Namespace="http://schemas.datacontract.org/2004/07/Presentation.NIDInquire")]
    [System.SerializableAttribute()]
    public partial class NIDInquireResult : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FullNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FamilyNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string InsuranceNumberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NationalIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MotherNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GovernorateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ZoneField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SectorField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GenderField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FullName {
            get {
                return this.FullNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FullNameField, value) != true)) {
                    this.FullNameField = value;
                    this.RaisePropertyChanged("FullName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=1)]
        public string FamilyName {
            get {
                return this.FamilyNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FamilyNameField, value) != true)) {
                    this.FamilyNameField = value;
                    this.RaisePropertyChanged("FamilyName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public string InsuranceNumber {
            get {
                return this.InsuranceNumberField;
            }
            set {
                if ((object.ReferenceEquals(this.InsuranceNumberField, value) != true)) {
                    this.InsuranceNumberField = value;
                    this.RaisePropertyChanged("InsuranceNumber");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public string NationalId {
            get {
                return this.NationalIdField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalIdField, value) != true)) {
                    this.NationalIdField = value;
                    this.RaisePropertyChanged("NationalId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public string MotherName {
            get {
                return this.MotherNameField;
            }
            set {
                if ((object.ReferenceEquals(this.MotherNameField, value) != true)) {
                    this.MotherNameField = value;
                    this.RaisePropertyChanged("MotherName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public string Governorate {
            get {
                return this.GovernorateField;
            }
            set {
                if ((object.ReferenceEquals(this.GovernorateField, value) != true)) {
                    this.GovernorateField = value;
                    this.RaisePropertyChanged("Governorate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=6)]
        public string Zone {
            get {
                return this.ZoneField;
            }
            set {
                if ((object.ReferenceEquals(this.ZoneField, value) != true)) {
                    this.ZoneField = value;
                    this.RaisePropertyChanged("Zone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=7)]
        public string Sector {
            get {
                return this.SectorField;
            }
            set {
                if ((object.ReferenceEquals(this.SectorField, value) != true)) {
                    this.SectorField = value;
                    this.RaisePropertyChanged("Sector");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=8)]
        public string Gender {
            get {
                return this.GenderField;
            }
            set {
                if ((object.ReferenceEquals(this.GenderField, value) != true)) {
                    this.GenderField = value;
                    this.RaisePropertyChanged("Gender");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NIDInquireService.INIDInquireService")]
    public interface INIDInquireService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INIDInquireService/NIDInquire", ReplyAction="http://tempuri.org/INIDInquireService/NIDInquireResponse")]
        NewSupportWS.NIDInquireService.NIDInquireResponse NIDInquire(NewSupportWS.NIDInquireService.NIDInquireRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INIDInquireService/NIDInquire", ReplyAction="http://tempuri.org/INIDInquireService/NIDInquireResponse")]
        System.Threading.Tasks.Task<NewSupportWS.NIDInquireService.NIDInquireResponse> NIDInquireAsync(NewSupportWS.NIDInquireService.NIDInquireRequest request);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INIDInquireServiceChannel : NewSupportWS.NIDInquireService.INIDInquireService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NIDInquireServiceClient : System.ServiceModel.ClientBase<NewSupportWS.NIDInquireService.INIDInquireService>, NewSupportWS.NIDInquireService.INIDInquireService {
        
        public NIDInquireServiceClient() {
        }
        
        public NIDInquireServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NIDInquireServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NIDInquireServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NIDInquireServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public NewSupportWS.NIDInquireService.NIDInquireResponse NIDInquire(NewSupportWS.NIDInquireService.NIDInquireRequest request) {
            return base.Channel.NIDInquire(request);
        }
        
        public System.Threading.Tasks.Task<NewSupportWS.NIDInquireService.NIDInquireResponse> NIDInquireAsync(NewSupportWS.NIDInquireService.NIDInquireRequest request) {
            return base.Channel.NIDInquireAsync(request);
        }
    }
}
