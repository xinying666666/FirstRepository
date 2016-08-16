using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarManager.Data
{
    public class CarDbContext : DbContext, IDbContext
    {
        static CarDbContext()
        {
            //如果数据库不存在第一次运行哟啊创建数据库
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarDbContext>());
        }

        public CarDbContext() : base("carDatabase")
        {
            
        }
        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
          return  this.Database.ExecuteSqlCommand(sql,parameters);
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//取表创建表的时候的配置
            //modelBuilder.Conventions.Add(new car());//老方法将配置类加进来
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<CarManager.Core.Domain.Car> Cars { get; set; }
    }
}
