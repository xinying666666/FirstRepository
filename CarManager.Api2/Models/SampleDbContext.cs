using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarManager.Api2.Models
{
    public class SampleDbContext:DbContext
    {
        public SampleDbContext() : base("Sample") {

        }

        public DbSet<Book> Books { get; set; }   
    }


}