using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using EnzoBlogDeveloper.EndSystem.EntityFramework.Models;

namespace EnzoBlogDeveloper.EndSystem.EntityFramework
{
    public class EnzoBlogDeveloperContext : DbContext
    {
        /// <summary>
        /// Databse Connection
        /// </summary>
        public EnzoBlogDeveloperContext() : base("AzureDataConnection") { }

        /// <summary>
        /// DTO(s)
        /// </summary>
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<UserTokenCache> UserTokenCacheList { get; set; }

        /// <summary>
        /// Remove Pluralizing table names
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
