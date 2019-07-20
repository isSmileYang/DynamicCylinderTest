using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.Data.SQLite;
using System.Data.Entity;

namespace MainProj.Local
{
    public class LocalDbInitializer:SqliteCreateDatabaseIfNotExists<LocalDbContext>
    {
        public LocalDbInitializer(string connectionString, DbModelBuilder modelBuilder)
		: base(modelBuilder) 
        {
        }
        protected override void Seed(LocalDbContext context)
        {
            base.Seed(context);
        }
    }
}
