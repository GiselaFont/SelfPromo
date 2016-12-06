namespace Selfie4.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication2.Data;
    public class DataModel : DbContext
    {
        // Your context has been configured to use a 'ModelData' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Selfie4.Data.ModelData' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelData' 
        // connection string in the application configuration file.
        public DataModel()
            : base("name=ModelData")
        {
            Database.SetInitializer<DataModel>(
               new DropCreateDatabaseIfModelChanges<DataModel>()
            );
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Jobhighlight> Jobhighlight { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}