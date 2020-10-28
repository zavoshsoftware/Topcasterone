using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Models
{
   public class DatabaseContext:DbContext
    {
        static DatabaseContext()
        {
           System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
        }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TextType> TextTypes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<TextTypeItem> TextTypeItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ContactUsForm> ContactUsForms { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
   }
}
