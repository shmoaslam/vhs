using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VHS.Services;
using VHS.Repository;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PropertyDetailTest()
        {
            try
            {
                PropertyService service = new PropertyService();
                var detail = service.GetPropertyDisplayModel(24);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [TestMethod]
        public void PropertyListAdminTest()
        {
            try
            {
                ManagePropertyService service = new ManagePropertyService(new PropertyService(), new ManageRmService(), new UnitOfWork());
                var detail = service.GetPropertyForManage(0);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
