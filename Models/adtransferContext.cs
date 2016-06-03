using System.Data.Entity;

namespace adtransfer
{
    public class adtransferContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<adtransfer.Models.adtransferContext>());

        public adtransferContext() : base("name=adtransferContext")
        {
        }

        public DbSet<Distribution> Distributions { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<BrandManager> BrandManagers { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Agency> Agencies { get; set; }

        public DbSet<Channel> Channels { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<System_User> System_Users { get; set; }
    }
}
