using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FieldEdge.Challenge.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public double Balance { get; set; }
        public string PhoneNumber { get; set; }
    }
}
