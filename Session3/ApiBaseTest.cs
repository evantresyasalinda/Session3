using RestSharp;
using Session3.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace Session3
{
    [TestClass]
    public class ApiBaseTest
    {
        public RestClient RestClient { get; set; }

        public UserJsonModel PetDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }

        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}