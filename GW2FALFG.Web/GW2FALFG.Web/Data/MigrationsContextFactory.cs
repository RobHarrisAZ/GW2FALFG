using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace GW2FALFG.Web.Data
{
    public class MigrationsContextFactory : IDbContextFactory<GroupRequestContext>
    {
        public GroupRequestContext Create()
        {
            return new GroupRequestContext("connectionStringName");
        }
    }
}