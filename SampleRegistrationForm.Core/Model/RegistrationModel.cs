using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleRegistrationForm.Core.Model
{
    public class RegistrationModel
    {
        //user model
        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserQualification { get; set; }
        public string? UserGender { get; set; }
        public long PhoneNo { get; set; }
        public string? UserAddress { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? RetypePassword { get; set; }
    }
}
