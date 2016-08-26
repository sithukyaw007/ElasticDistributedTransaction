using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.DbContexts
{
    public class ContextA : DbContext
    {
        public DbSet<AModel> ATable { get; set; }
    }

    public class AModel
    {
        public int Id { get; set; }
        public string BValue1 { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}