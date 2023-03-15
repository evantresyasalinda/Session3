using Session3.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Session3.Tests.TestData;
using Session3.Resources;


namespace Session3.Helpers
{
    /// <summary>
    /// Demo class containing all methods for users
    /// </summary>
    public class UserHelper
    {
        /// <summary>
        /// Send POST request to add new user
        /// </summary>
        ///

        public static async Task<UserJsonModel> AddNewPet(RestClient client)
        {
            var newPetData = GeneratePet.demoPet();
            var postRequest = new RestRequest(Endpoints.PostPet());

            //Send Post Request to add new user
            postRequest.AddJsonBody(newPetData);
            var postResponse = await client.ExecutePostAsync<UserJsonModel>(postRequest);

            var createdPetData = newPetData;
            return createdPetData;
        }
    }
}
