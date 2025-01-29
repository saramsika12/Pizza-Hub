using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHub.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Locality { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int PhoneNumber { get; set; }
    }
}
