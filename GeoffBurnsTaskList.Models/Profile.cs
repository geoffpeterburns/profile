using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GeoffBurnsTaskList.Models
{
    [DataContract]
    public class Profile
    {
        public Profile()
        {
            Dob = DateTime.Now.Date;
            Surname = string.Empty;
            UserName = string.Empty;
        }

        [Required]
        [DisplayName("Date Birth")]
        [DataType(DataType.Date)]
        [DataMember]
        public DateTime Dob { get; set; }

        [Required]
        [MinLength(2,ErrorMessage = "Enter a proper Surname")]
        [DataMember]
        public string Surname { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Enter a proper UserName")]
        [DataMember]
        public string UserName { get; set; }

    }
}