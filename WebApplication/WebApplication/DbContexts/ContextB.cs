using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.DbContexts
{
    public class ContextB : DbContext
    {
        public DbSet<BModel> BTable { get; set; }
    }

    public class BModel
    {
        public int Id { get; set; }
        public string BValue1 { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}