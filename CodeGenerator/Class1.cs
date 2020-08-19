using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeGenerator
{
    public class BloggingContext : DbContext
    {
        public DbSet<SALPGroup> SALPGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FHNCUG2;Initial Catalog=CodeGeneratorTest;Integrated Security=True");
        }
    }

    public class SALPGroup
    {
        public string OrganizationName { get; set; }
        public string Level1Category { get; set; }
        public string Level2Category { get; set; }
        public string PSUConnectPage { get; set; }
        public string Description { get; set; }
        [Key]
        public int IDKey { get; set; }
    }

}
