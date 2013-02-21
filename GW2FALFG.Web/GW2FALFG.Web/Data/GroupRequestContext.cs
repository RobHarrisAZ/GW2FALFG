using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GW2FALFG.Web.Models;

namespace GW2FALFG.Web.Data
{
    public class GroupRequestContext : DbContext
    {
        public DbSet<Language> Languages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<GroupRequest> GroupRequests { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CharacterClass> CharacterClasses { get; set; }
        public GroupRequestContext(string connString)
            : base(connString)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }
    }
}