using Session3.DataModels;
using Session3.Helpers;
using Session3.Resources;
using Session3.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Net;



namespace Session3
{
    [TestClass]
    public class DemoTest : ApiBaseTest
    {
        private static List<UserJsonModel> PetCleanUpList = new List<UserJsonModel>();

        [TestInitialize]
        public async Task TestInit()
        {
            PetDetails = await UserHelper.AddNewPet(RestClient);

        }

        [TestMethod]
        public async Task GetPetById()
        {

            //Arrange
            var demoGetRequest = new RestRequest(Endpoints.GetByPetID(PetDetails.Id));
            PetCleanUpList.Add(PetDetails);

            //Act
            var demoResponse = await RestClient.ExecuteGetAsync<UserJsonModel>(demoGetRequest);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, demoResponse.StatusCode, "Failed due to wrong status code.");
            Assert.AreEqual(PetDetails.Name, demoResponse.Data.Name, "Name did not match.");
            Assert.AreEqual(PetDetails.Status, demoResponse.Data.Status, "Status did not match.");
            Assert.AreEqual(PetDetails.PhotoUrls[0], demoResponse.Data.PhotoUrls[0], "PhotoUrls did not match.");
            Assert.AreEqual(PetDetails.Category.Id, demoResponse.Data.Category.Id, "Category ID did not match.");
            Assert.AreEqual(PetDetails.Category.Name, demoResponse.Data.Category.Name, "Category Name did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Id, demoResponse.Data.Tags[0].Id, "Tags ID did not match.");
            Assert.AreEqual(PetDetails.Tags[0].Name, demoResponse.Data.Tags[0].Name, "Tags Name did not match.");
        }
        [TestCleanup]
        public async Task TestCleanUp()
        {
            foreach (var data in PetCleanUpList)
            {
                var deleteUserRequest = new RestRequest(Endpoints.GetByPetID(data.Id));
                var deleteUserResponse = await RestClient.DeleteAsync(deleteUserRequest);
            }
        }
    }
}
