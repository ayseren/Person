using Microsoft.EntityFrameworkCore;

namespace Person.Repository
{
    public class PersonContext : DbContext
    {
        public DbSet<Person.Entity.Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("Default");

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

            optionsBuilder.UseMySql(connectionString, serverVersion)
                .EnableDetailedErrors();
        }
    }
}

//yapılandırma verilerine doğrudan erişmek yerine,
//genellikle IConfiguration arayüzünü kullanmak daha tercih edilen bir yaklaşımdır.
//Bu sayede yapılandırma verilerine daha esnek bir şekilde erişebilir ve
//değişiklikleri daha kolay yönetebilirsiniz.

//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Pomelo.EntityFrameworkCore.MySql;

//namespace Person.Repository
//{
//    public class PersonContext : DbContext
//    {
//        // Burada Persons yazip yazmamanin bir onemi yok; Person da yazabilirdi.
//        // Persons, DbSet nesnesine erişim sağlamak için kullanılan bir özellik adı
//        // EntityFramework Person.Entity.Person yazan yerden dbdeki tablo adini buluyor.
//        // Eger farkli bir isim istersek:
//        //protected override void OnModelCreating(ModelBuilder modelBuilder)
//        //{
//        //    modelBuilder.Entity<Person.Entity.Person>().ToTable("People");
//        //}
//        // seklinde yazilabilir

//        public DbSet<Person.Entity.Person> Persons { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            var config = new ConfigurationBuilder()
//                .SetBasePath(Directory.GetCurrentDirectory())
//                .AddJsonFile("appsettings.json")
//                .Build();

//            string connectionString = config.GetConnectionString("Default");

//            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))).EnableDetailedErrors();
//        }
//    }
//}

