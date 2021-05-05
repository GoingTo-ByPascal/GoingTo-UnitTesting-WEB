using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class CityPlacesSteps
    {

        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;

        public CityPlacesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I search for places by city")]
        public void GivenISearchForPlacesByCity()
        {
            client = new RestClient("https://goingto-api.azurewebsites.net/api");
            request = new RestRequest("/cities/{cityid}/places", Method.GET, DataFormat.Json);
            request.AddUrlSegment("cityId", 1);
        }
        
        [When(@"I interact with the search")]
        public void WhenIInteractWithTheSearch()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the result code should be (.*)")]
        public void ThenTheResultCodeShouldBe(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200 causa");
        }
    }
}
