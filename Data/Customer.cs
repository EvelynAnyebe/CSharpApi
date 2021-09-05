﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpApi.Data
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CustomerPassword { get; set; }
        public string PhoneNumber { get; set; }
    }
}
