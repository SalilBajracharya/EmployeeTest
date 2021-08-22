using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employees.Models
{
    public class ApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string Skills { get; set; }
        public string Photo { get; set; }
        public int responseCode { get; set; }
        public string responseMessage { get; set; }
    }
}