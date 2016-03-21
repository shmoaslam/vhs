using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using VHS.Core;

namespace VHS.Data
{
    public class VHSDbContext : DbContext
    {
        public VHSDbContext() : base("name=ContextVHS")
        {
            Database.SetInitializer<VHSDbContext>(null);
       
        }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Document> Documents { get; set; }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Property> Propertys { get; set; }
        public DbSet<PropertyAddress> PropertyAddresss { get; set; }
        public DbSet<PropertyCategory> PropertyCategory { get; set; }
        public DbSet<PropertyListedBy> PropertyListedBys { get; set; }
        public DbSet<PropertyRMMapping> PropertyRMMappings { get; set; }
        public DbSet<PropertyImageMapping> PropertyImageMappings { get; set; }
        public DbSet<TravelPreferences> TravelPreferencess { get; set; }
        public DbSet<UserTravelPrefMapping> UserTravelPrefMappings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<UserProfile>().ToTable("UserProfile");
            modelBuilder.Entity<UserType>().ToTable("UserType");
            modelBuilder.Entity<Document>().ToTable("Documents");

            modelBuilder.Entity<Contact>().ToTable("Contact");
            modelBuilder.Entity<Image>().ToTable("Image");
            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<PropertyAddress>().ToTable("PropertyAddress");
            modelBuilder.Entity<PropertyCategory>().ToTable("PropertyCategory");
            modelBuilder.Entity<PropertyListedBy>().ToTable("PropertyListedBy");
            modelBuilder.Entity<PropertyRMMapping>().ToTable("PropertyRMMapping");
            modelBuilder.Entity<PropertyImageMapping>().ToTable("PropertyImageMapping");
            modelBuilder.Entity<TravelPreferences>().ToTable("TravelPreferences");
            modelBuilder.Entity<UserTravelPrefMapping>().ToTable("UserTravelPrefMapping");

            //one-to-many:-One Usertype have many user:-
            modelBuilder.Entity<UserLogin>().HasRequired<UserType>(s => s.UserType).WithMany(s => s.UserLogin).HasForeignKey(s => s.TypeId);
            modelBuilder.Entity<Document>().HasRequired<UserLogin>(s => s.UserLogin).WithMany(s => s.Document).HasForeignKey(s => s.LoginId);

            //one to one relationship:-
            // Configure ProfileId as PK for User profile
            modelBuilder.Entity<UserProfile>().HasKey(e => e.LoginId);
            // Configure LoginId as FK for User profile
            modelBuilder.Entity<UserLogin>().HasRequired(s => s.UserProfile).WithRequiredPrincipal(s => s.UserLogin);


        }

    }
}
