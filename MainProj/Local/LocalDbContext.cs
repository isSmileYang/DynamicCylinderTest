using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MainProj.Local
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]  
    public class LocalDbContext:DbContext
    {
        
        public virtual DbSet<Test> TestInfos { get; set; }
        
        public virtual DbSet<Dynamic_Cylinder> Dynamic_Cylinders { get; set; }
        
        public virtual DbSet<Alarm> Alarms { get; set; }
      
        public LocalDbContext(): base("name=DBModel")
        {
            //数据库初始化
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<LocalDbContext, MainProj.Local.Configuration>());
            //Database.SetInitializer<LocalDbContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        } 
    }
}
