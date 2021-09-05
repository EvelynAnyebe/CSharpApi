using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpApi.Data
{
    public class WomenTechstersDBContext :DbContext
    {
        public WomenTechstersDBContext(DbContextOptions<WomenTechstersDBContext> options): base(options)
        {

        }

        public DbSet<Customer> customer { get; set; }
    }
}
