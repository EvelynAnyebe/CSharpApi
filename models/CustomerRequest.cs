using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpApi.models
{
    public class CustomerRequest
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string CustomerPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
