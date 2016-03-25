using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;
using VHS.Core;
using VHS.Data;

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
    }
}
