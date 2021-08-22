using System;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class EmployeeMVC
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNo { get; set; }
        [Required]
        public Nullable<System.DateTime> JoiningDate { get; set; }
        [Required]
        public string Skills { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+API $", ErrorMessage = "Only Image files allowed.")]
        public string Photo { get; set; }
    }
}