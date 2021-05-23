using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PhoneBookAPI.Core.Entities;

namespace PhoneBookAPI.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }


        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Optional
            //modelBuilder.Entity<Contact>().HasData(
            //new Contact
            //{
            //    Id = 1,
            //    FirstName = "vadim",
            //    LastName = "tomashevsky",
            //    City = "ashdod",
            //    Email = "vadimt2@gmail.com",
            //    PhoneNumber = "0506913544",
            //    StreetAddress = "Kohav hazafon",
            //    ZipCode = "7775005"
            //},
            // new Contact
            // {
            //     Id = 2,
            //     FirstName = "America",
            //     LastName = "H. Lang",
            //     City = "Weatherford",
            //     Email = "AmericaHLang@teleworm.us",
            //     PhoneNumber = "8176136979",
            //     StreetAddress = "860 Sardis Sta",
            //     ZipCode = "76086"
            // },
            // new Contact
            // {
            //     Id = 3,
            //     FirstName = "Stacy",
            //     LastName = "Cain",
            //     City = "Brookline",
            //     Email = "StacyJCain@armyspy.com",
            //     PhoneNumber = "6172775749",
            //     StreetAddress = "3152 Lynn Street",
            //     ZipCode = "02146"
            // },
            // new Contact
            // {
            //     Id = 4,
            //     FirstName = "Cora",
            //     LastName = "Page",
            //     City = "Patriot",
            //     Email = "CoraWPage@jourrapide.com",
            //     PhoneNumber = "8125948810",
            //     StreetAddress = "415 Neville Street",
            //     ZipCode = "47038"
            // }
            //    );
        }
    }
}