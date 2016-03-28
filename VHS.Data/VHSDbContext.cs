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
        public DbSet<MailLink> MailLinks { get; set; }

        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<BathRooms> BathRooms { get; set; }
        public DbSet<EntertainmentElectronics> EntertainmentElectronics { get; set; }
        public DbSet<General> Generals { get; set; }
        public DbSet<Kitchen> Kitchens { get; set; }
        public DbSet<OutdoorFacilities> OutdoorFacilities { get; set; }
        public DbSet<Parking> Parking { get; set; }
        public DbSet<PropertyAdditionalInfo> PropertyAdditionalInfo { get; set; }
        public DbSet<PropertyAmenitiesMap> PropertyAmenitiesMap { get; set; }
        public DbSet<PropertyBathRoomsMap> PropertyBathRoomsMap { get; set; }
        public DbSet<PropertyCoverPhotoMap> PropertyCoverPhotoMap { get; set; }
        public DbSet<PropertyEnterElecMap> PropertyEnterElecMap { get; set; }
        public DbSet<PropertyGallaryMap> PropertyGallaryMap { get; set; }
        public DbSet<PropertyGeneralMap> PropertyGeneralMap { get; set; }
        public DbSet<PropertyKitchenMap> PropertyKitchenMap { get; set; }
        public DbSet<PropertyOutdoorMap> PropertyOutdoorMap { get; set; }
        public DbSet<PropertyPrice> PropertyPrice { get; set; }
        public DbSet<PropertyParkingMap> PropertyParkingMap { get; set; }
        public DbSet<PropertySleepingMap> PropertySleepingMap { get; set; }
        public DbSet<SleepingArrangement> SleepingArrangement { get; set; }
        public DbSet<PropertyTravelAmbassadorMap> PropertyTravelAmbassadorMap { get; set; }
        public DbSet<PropertyTravelBeatsMap> PropertyTravelBeatsMap { get; set; }

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
            modelBuilder.Entity<MailLink>().ToTable("MailLink");
            modelBuilder.Entity<Amenities>().ToTable("Amenities");
            modelBuilder.Entity<BathRooms>().ToTable("BathRooms");
            modelBuilder.Entity<EntertainmentElectronics>().ToTable("EntertainmentElectronics");
            modelBuilder.Entity<General>().ToTable("General");
            modelBuilder.Entity<Kitchen>().ToTable("Kitchen");
            modelBuilder.Entity<OutdoorFacilities>().ToTable("OutdoorFacilities");
            modelBuilder.Entity<Parking>().ToTable("Parking");
            modelBuilder.Entity<PropertyAdditionalInfo>().ToTable("PropertyAdditionalInfo");
            modelBuilder.Entity<PropertyAmenitiesMap>().ToTable("PropertyAmenitiesMap");
            modelBuilder.Entity<PropertyBathRoomsMap>().ToTable("PropertyBathRoomsMap");
            modelBuilder.Entity<PropertyCoverPhotoMap>().ToTable("PropertyCoverPhotoMap");
            modelBuilder.Entity<PropertyGallaryMap>().ToTable("PropertyGallaryMap");
            modelBuilder.Entity<PropertyEnterElecMap>().ToTable("PropertyEnterElecMap");
            modelBuilder.Entity<PropertyGeneralMap>().ToTable("PropertyGeneralMap");
            modelBuilder.Entity<PropertyKitchenMap>().ToTable("PropertyKitchenMap");
            modelBuilder.Entity<PropertyOutdoorMap>().ToTable("PropertyOutdoorMap");
            modelBuilder.Entity<PropertyParkingMap>().ToTable("PropertyParkingMap");
            modelBuilder.Entity<PropertyPrice>().ToTable("PropertyPrice");
            modelBuilder.Entity<SleepingArrangement>().ToTable("SleepingArrangement");
            modelBuilder.Entity<PropertySleepingMap>().ToTable("PropertySleepingMap");
            modelBuilder.Entity<PropertyTravelAmbassadorMap>().ToTable("PropertyTravelAmbassadorMap");
            modelBuilder.Entity<PropertyTravelBeatsMap>().ToTable("PropertyTravelBeatsMap");

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
