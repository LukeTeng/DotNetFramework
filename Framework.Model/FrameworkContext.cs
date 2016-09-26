using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Framework.Model
{
    public class FrameworkContext : DbContext, IContext
    {
        public FrameworkContext()
            : base("Name=FrameworkContext")
        {
            //this.Configuration.LazyLoadingEnabled = false; 
            //Database.SetInitializer<FrameworkContext>(new CreateDatabaseIfNotExists<FrameworkContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remove plural name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Student> Students { get; set; }
        public IDbSet<ClassInSchool> Classes { get; set; }


        /// <summary>
        /// change the common fields here including createdtime and modifiedtime
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            var changedEntries = ChangeTracker.Entries().Where(x => x.Entity is ICommonFields
                    && (x.State == System.Data.Entity.EntityState.Added || x.State == System.Data.Entity.EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                ICommonFields entity = entry.Entity as ICommonFields;
                if (entity != null)
                {
                    DateTime now = DateTime.UtcNow;

                    if (entry.State == System.Data.Entity.EntityState.Added)
                    {
                        entity.CreatedDate = now;
                    }
                    else
                    {
                        base.Entry(entity).Property(x => x.CreatedDate).IsModified = false;
                    }

                    entity.UpdatedDate = now;

                }
            }

            return base.SaveChanges();
        }

    }
}
