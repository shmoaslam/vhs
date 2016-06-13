using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using VHS.Core;
using VHS.Data;
using System.Data.SqlClient;

namespace VHS.Repository
{
    public class UnitOfWork
    {
        #region Private member variables...

        private VHSDbContext _context = null;
        private GenericRepository<UserLogin> _loginRepository;
        private GenericRepository<UserProfile> _userProfileRepository;
        private GenericRepository<UserType> _userTypeRepository;
        private GenericRepository<Contact> _contactRepository;
        private GenericRepository<Document> _documentRepository;
        private GenericRepository<Image> _imageRepository;
        private GenericRepository<Property> _propertyRepository;
        private GenericRepository<PropertyAddress> _propertyAddressRepository;
        private GenericRepository<PropertyCategory> _propertyCategoryRepository;
        private GenericRepository<PropertyImageMapping> _propImageMapRepository;
        private GenericRepository<PropertyListedBy> _propListedByRepository;
        private GenericRepository<PropertyRMMapping> _propRMMapRepository;
        private GenericRepository<TravelPreferences> _travelPrefRepository;
        private GenericRepository<UserTravelPrefMapping> _userTravelPrefRepository;
        private GenericRepository<MailLink> _mailLinkRepository;
        private GenericRepository<Amenities> _aminitiesRepository;
        private GenericRepository<BathRooms> _bathRoomsRepository;
        private GenericRepository<EntertainmentElectronics> _enterElecRepository;
        private GenericRepository<General> _generalRepository;
        private GenericRepository<Kitchen> _kitchenRepository;
        private GenericRepository<OutdoorFacilities> _outdoorFacilitiesRepository;
        private GenericRepository<Parking> _parkingRepository;
        private GenericRepository<PropertyAdditionalInfo> _propertyAdditionalRepository;
        private GenericRepository<PropertyAmenitiesMap> _propAmenitiesRepository;
        private GenericRepository<PropertyBathRoomsMap> _propBathRoomRepository;
        private GenericRepository<PropertyCoverPhotoMap> _propCoverPhotoRepository;
        private GenericRepository<PropertyEnterElecMap> _propEnterElecRepository;
        private GenericRepository<PropertyGallaryMap> _propertyGalaryRepository;
        private GenericRepository<PropertyGeneralMap> _propGeneralRepository;
        private GenericRepository<PropertyKitchenMap> _propKitchenRepository;
        private GenericRepository<PropertyOutdoorMap> _propOutdoorRepository;
        private GenericRepository<PropertyParkingMap> _propParkingRepository;
        private GenericRepository<PropertyBlackOutDay> _propBlackOutDayRepository;
        private GenericRepository<PropertySleepingMap> _propSleepRepository;
        private GenericRepository<SleepingArrangement> _sleepArrangeRepository;
        private GenericRepository<PropertyTravelAmbassadorMap> _propTravelAmbessRepository;
        private GenericRepository<PropertyTravelBeatsMap> _propTravelBeatsRepository;
        private GenericRepository<PropertyFixedPrice> _propFixedPriceRepository;
        private GenericRepository<PropertyVraiblePrice> _propVariablePriceRepository;
        private GenericRepository<PropertyWeekendPrice> _propertyWeekendPriceRepository;
        private GenericRepository<BookingRequest> _bookingRequestRepository;
        private GenericRepository<Newsletter> _newsletterRepository;
        private GenericRepository<ResetPasswordToken> _resetPasswordToken;
        private GenericRepository<PropertyBooking> _propertyBooking;
        #endregion

        public UnitOfWork()
        {
            _context = new VHSDbContext();

        }



        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for login repository.
        /// </summary>
        public GenericRepository<UserLogin> LoginRepository
        {
            get
            {
                if (this._loginRepository == null)
                    this._loginRepository = new GenericRepository<UserLogin>(_context);
                return _loginRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<UserProfile> UserProfileRepository
        {
            get
            {
                if (this._userProfileRepository == null)
                    this._userProfileRepository = new GenericRepository<UserProfile>(_context);
                return _userProfileRepository;
            }
        }


        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<UserType> UserTypeRepository
        {
            get
            {
                if (this._userTypeRepository == null)
                    this._userTypeRepository = new GenericRepository<UserType>(_context);
                return _userTypeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Contact> ContactRepository
        {
            get
            {
                if (this._contactRepository == null)
                    this._contactRepository = new GenericRepository<Contact>(_context);
                return _contactRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Document> DocumentRepository
        {
            get
            {
                if (this._documentRepository == null)
                    this._documentRepository = new GenericRepository<Document>(_context);
                return _documentRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Image> ImageRepository
        {
            get
            {
                if (this._imageRepository == null)
                    this._imageRepository = new GenericRepository<Image>(_context);
                return _imageRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Property> PropertyRepository
        {
            get
            {
                if (this._propertyRepository == null)
                    this._propertyRepository = new GenericRepository<Property>(_context);
                return _propertyRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyAddress> PropertyAddressRepository
        {
            get
            {
                if (this._propertyAddressRepository == null)
                    this._propertyAddressRepository = new GenericRepository<PropertyAddress>(_context);
                return _propertyAddressRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyCategory> PropertyCategoryRepository
        {
            get
            {
                if (this._propertyCategoryRepository == null)
                    this._propertyCategoryRepository = new GenericRepository<PropertyCategory>(_context);
                return _propertyCategoryRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyImageMapping> PropertyImageMapRepository
        {
            get
            {
                if (this._propImageMapRepository == null)
                    this._propImageMapRepository = new GenericRepository<PropertyImageMapping>(_context);
                return _propImageMapRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyListedBy> PropertyListedByRepository
        {
            get
            {
                if (this._propListedByRepository == null)
                    this._propListedByRepository = new GenericRepository<PropertyListedBy>(_context);
                return _propListedByRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyRMMapping> PropertyRMMapRepository
        {
            get
            {
                if (this._propRMMapRepository == null)
                    this._propRMMapRepository = new GenericRepository<PropertyRMMapping>(_context);
                return _propRMMapRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<TravelPreferences> TravelPreferencesRepository
        {
            get
            {
                if (this._travelPrefRepository == null)
                    this._travelPrefRepository = new GenericRepository<TravelPreferences>(_context);
                return _travelPrefRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<UserTravelPrefMapping> UserTravelPrefMapRepository
        {
            get
            {
                if (this._userTravelPrefRepository == null)
                    this._userTravelPrefRepository = new GenericRepository<UserTravelPrefMapping>(_context);
                return _userTravelPrefRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Amenities> AminitiesRepository
        {
            get
            {
                if (this._aminitiesRepository == null)
                    this._aminitiesRepository = new GenericRepository<Amenities>(_context);
                return _aminitiesRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<BathRooms> BathRoomsRepository
        {
            get
            {
                if (this._bathRoomsRepository == null)
                    this._bathRoomsRepository = new GenericRepository<BathRooms>(_context);
                return _bathRoomsRepository;
            }
        }
        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<EntertainmentElectronics> EntertinmentElecRepository
        {
            get
            {
                if (this._enterElecRepository == null)
                    this._enterElecRepository = new GenericRepository<EntertainmentElectronics>(_context);
                return _enterElecRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<General> GeneralRepository
        {
            get
            {
                if (this._generalRepository == null)
                    this._generalRepository = new GenericRepository<General>(_context);
                return _generalRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Kitchen> KitchenRepository
        {
            get
            {
                if (this._kitchenRepository == null)
                    this._kitchenRepository = new GenericRepository<Kitchen>(_context);
                return _kitchenRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<OutdoorFacilities> OutdoorFaciRepository
        {
            get
            {
                if (this._outdoorFacilitiesRepository == null)
                    this._outdoorFacilitiesRepository = new GenericRepository<OutdoorFacilities>(_context);
                return _outdoorFacilitiesRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<Parking> ParkingRepository
        {
            get
            {
                if (this._parkingRepository == null)
                    this._parkingRepository = new GenericRepository<Parking>(_context);
                return _parkingRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyAdditionalInfo> PropertyAdditionalRepository
        {
            get
            {
                if (this._propertyAdditionalRepository == null)
                    this._propertyAdditionalRepository = new GenericRepository<PropertyAdditionalInfo>(_context);
                return _propertyAdditionalRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyAmenitiesMap> PropertyAmenitiesRepository
        {
            get
            {
                if (this._propAmenitiesRepository == null)
                    this._propAmenitiesRepository = new GenericRepository<PropertyAmenitiesMap>(_context);
                return _propAmenitiesRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyBathRoomsMap> PropBathRoomRepository
        {
            get
            {
                if (this._propBathRoomRepository == null)
                    this._propBathRoomRepository = new GenericRepository<PropertyBathRoomsMap>(_context);
                return _propBathRoomRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyCoverPhotoMap> PropCoverPhotoRepository
        {
            get
            {
                if (this._propCoverPhotoRepository == null)
                    this._propCoverPhotoRepository = new GenericRepository<PropertyCoverPhotoMap>(_context);
                return _propCoverPhotoRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyEnterElecMap> PropEnterERepository
        {
            get
            {
                if (this._propEnterElecRepository == null)
                    this._propEnterElecRepository = new GenericRepository<PropertyEnterElecMap>(_context);
                return _propEnterElecRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyGallaryMap> PropertyGallaryRepository
        {
            get
            {
                if (this._propertyGalaryRepository == null)
                    this._propertyGalaryRepository = new GenericRepository<PropertyGallaryMap>(_context);
                return _propertyGalaryRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyGeneralMap> PropGeneralRepository
        {
            get
            {
                if (this._propGeneralRepository == null)
                    this._propGeneralRepository = new GenericRepository<PropertyGeneralMap>(_context);
                return _propGeneralRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyKitchenMap> PropKitchenRepository
        {
            get
            {
                if (this._propKitchenRepository == null)
                    this._propKitchenRepository = new GenericRepository<PropertyKitchenMap>(_context);
                return _propKitchenRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyOutdoorMap> PropOutdoorRepository
        {
            get
            {
                if (this._propOutdoorRepository == null)
                    this._propOutdoorRepository = new GenericRepository<PropertyOutdoorMap>(_context);
                return _propOutdoorRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyParkingMap> PropParkingRepository
        {
            get
            {
                if (this._propParkingRepository == null)
                    this._propParkingRepository = new GenericRepository<PropertyParkingMap>(_context);
                return _propParkingRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertyBlackOutDay> PropertyBlackOutDateRepository
        {
            get
            {
                if (this._propBlackOutDayRepository == null)
                    this._propBlackOutDayRepository = new GenericRepository<PropertyBlackOutDay>(_context);
                return _propBlackOutDayRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<PropertySleepingMap> PropSleepingRepository
        {
            get
            {
                if (this._propSleepRepository == null)
                    this._propSleepRepository = new GenericRepository<PropertySleepingMap>(_context);
                return _propSleepRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for user repository.
        /// </summary>
        public GenericRepository<SleepingArrangement> SleepingArrangementRepository
        {
            get
            {
                if (this._sleepArrangeRepository == null)
                    this._sleepArrangeRepository = new GenericRepository<SleepingArrangement>(_context);
                return _sleepArrangeRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Mail Link repository.
        /// </summary>
        public GenericRepository<MailLink> MailLinkRepository
        {
            get
            {
                if (this._mailLinkRepository == null)
                    this._mailLinkRepository = new GenericRepository<MailLink>(_context);
                return _mailLinkRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Mail Link repository.
        /// </summary>
        public GenericRepository<PropertyFixedPrice> PropFixedPriceRepository
        {
            get
            {
                if (this._propFixedPriceRepository == null)
                    this._propFixedPriceRepository = new GenericRepository<PropertyFixedPrice>(_context);
                return _propFixedPriceRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Mail Link repository.
        /// </summary>
        public GenericRepository<PropertyVraiblePrice> PropVariablePriceRepository
        {
            get
            {
                if (this._propVariablePriceRepository == null)
                    this._propVariablePriceRepository = new GenericRepository<PropertyVraiblePrice>(_context);
                return _propVariablePriceRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Mail Link repository.
        /// </summary>
        public GenericRepository<PropertyWeekendPrice> PropertyWeekendPriceRepository
        {
            get
            {
                if (this._propertyWeekendPriceRepository == null)
                    this._propertyWeekendPriceRepository = new GenericRepository<PropertyWeekendPrice>(_context);
                return _propertyWeekendPriceRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for BookingRequest repository.
        /// </summary>
        public GenericRepository<BookingRequest> BookingRequestRepository
        {
            get
            {
                if (this._bookingRequestRepository == null)
                    this._bookingRequestRepository = new GenericRepository<BookingRequest>(_context);
                return _bookingRequestRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for Newsletter repository.
        /// </summary>
        public GenericRepository<Newsletter> NewsletterRepository
        {
            get
            {
                if (this._newsletterRepository == null)
                    this._newsletterRepository = new GenericRepository<Newsletter>(_context);
                return _newsletterRepository;
            }
        }

        /// <summary>
        /// Get/Set Property for ResetPasswordToken repository.
        /// </summary>
        public GenericRepository<ResetPasswordToken> ResetPasswordTokenRepository
        {
            get
            {
                if (this._resetPasswordToken == null)
                    this._resetPasswordToken = new GenericRepository<ResetPasswordToken>(_context);
                return _resetPasswordToken;
            }
        }

        public GenericRepository<PropertyBooking> PropertyBookingRepository
        {
            get
            {
                if (this._propertyBooking == null)
                    this._propertyBooking = new GenericRepository<PropertyBooking>(_context);
                return _propertyBooking;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now,
                        eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Store Procedure

        public List<PropertyDisplayViewModel> GetProperties(string query, int region, int category)
        {
            return _context.Database.SqlQuery<PropertyDisplayViewModel>("exec GetListingProperty @regionId, @query, @category ", new SqlParameter("@regionId", region), new SqlParameter("@query", string.IsNullOrEmpty(query) ? string.Empty : query) , new SqlParameter("@category", category)).ToList();
        }
        
        public PropertyDetialModel GetPropertyDetails(int? id)
        {
            if (id == null) return null;
            return _context.Database.SqlQuery<PropertyDetialModel>(" Exec GetPropertyDetails @propid", new SqlParameter("@propid", id)).FirstOrDefault();
        }
        public List<PropertyListForAdmin> GetPropertyListForAdmin(int rmid)
        {
            return _context.Database.SqlQuery<PropertyListForAdmin>(" Exec GetPropertyListForAdmin @rmId", new SqlParameter("@rmId", rmid)).ToList();
        }

        public ManganeBookingViewModel GetBookingDetails(int bookingId)
        {
            return _context.Database.SqlQuery<ManganeBookingViewModel>(" Exec GetBookingDetail @bookingId", new SqlParameter("@bookingId", bookingId)).FirstOrDefault();
        }

        //Procedure to Check Property Availabilty:-
        public bool CheckAvailbilityProerty(int PropertyId, DateTime StartDate, DateTime EndDate)
        {
            var result = _context.Database.SqlQuery<bool>("CheckAvailbilityProperty @propertyId, @StartDate, @EndDate", new SqlParameter("propertyId", PropertyId), new SqlParameter("StartDate", StartDate), new SqlParameter("EndDate", EndDate)).FirstOrDefault();
            return result;
        }

        public List<PropertyDetialModel> GetPropertyWaitingForApproval()
        {
            return _context.Database.SqlQuery<PropertyDetialModel>("select Title, Id, name GalaryImage, categoryname + ', ' + city [Desc] from ( select Title, p.id Id,i.name , pc.categoryname , pa.city  , row_number() over (partition by Title order by name) as RowNbr   from property p  join PropertyImageMapping pim on p.Id = pim.propertyid  join Image i on pim.Imageid = i.imageid join PropertyCategory pc on pc.id = p.categoryid join PropertyAddress pa on pa.propertyid = p.id where p.isactive  = 1 and p.sendapprovedrequest = 1 and  p.isapproved = 0) a where RowNbr = 1").ToList();
        }
        #endregion


        #region Class need to be moved

        public class ManganeBookingViewModel
        {
            public int Id { get; set; }
            public string PropertyId { get; set; }
            public string BookingId { get; set; }
            public string Name { get; set; }
            public int LoginId { get; set; }
            public string Email { get; set; }
            public string ContactNumber { get; set; }
            public DateTime CheckIn { get; set; }
            public DateTime CheckOut { get; set; }
            public int Guests { get; set; }
            public bool IsCustomerIdAvailable { get; set; }

            public int AdultCount { get; set; }
            public int ChildCount { get; set; }
            public string UserComment { get; set; }

            public decimal QuotedPrice { get; set; }
            public decimal NegotiatePrice { get; set; }
            public decimal RecievedPayment { get; set; }

            public string RmComment { get; set; }


        }

        public class PropertyDisplayViewModel
        {
            public int Id { get; set; }
            public string CoverImage { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Bedroom { get; set; }
            public string Title { get; set; }
            public int GuestCount { get; set; }
            public string Rating { get; set; }
            public int RegionId { get; set; }
        }
        public class PropertyDetialModel : PropertyDisplayViewModel
        {
            public string GalaryImage { get; set; }
            public string Desc { get; set; }
            public string CheckIn { get; set; }
            public string CheckOut { get; set; }
            public string IsPetAllowed { get; set; }
            public string IsSmokingAllowed { get; set; }
            public string IsWheelchairAccessible { get; set; }
            public string IsFamilyKidFriendly { get; set; }
            public string IsDrinkingAllowed { get; set; }
            public int PersonPerRoom { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string General { get; set; }
            public string Parking { get; set; }
            public string Outdoor { get; set; }
            public string Bathroom { get; set; }
            public string Entertainment { get; set; }
            public string Sleeping { get; set; }
            public string Kitchen { get; set; }
            public int MaxGuestCount { get; set; }
            public decimal PricePerAdult { get; set; }
            public decimal PricePerChild { get; set; }
            public int CancellationPolicy { get; set; }
        }
        public class PropertyListForAdmin
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        #endregion
    }
}
