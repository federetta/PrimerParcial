using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TestParcial.Entities;


namespace TestParcial.Services.Contracts
{
    /// <summary>
    /// Response message wrapper class for All
    /// </summary>
    [DataContract]
    public partial class AllResponse
    {
        [DataMember]
        public List<Student> Result { get; set; }
    }

    
}

