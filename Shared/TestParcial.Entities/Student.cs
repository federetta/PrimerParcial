using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;


namespace TestParcial.Entities
{
    /// <summary>
    /// Represents a row of Category data.
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class Student
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string City { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int CountryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Gender { get; set; }
    }
}
