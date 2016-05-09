using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VHS.Services;

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
    }
}
