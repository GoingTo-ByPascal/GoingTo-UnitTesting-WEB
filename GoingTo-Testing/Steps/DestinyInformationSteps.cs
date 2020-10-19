using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps

{
    class DestinyInformationSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;

        public DestinyInformationSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I search for places by city")]
        public void GivenIsearchforinformationbyplaces()
        {
            client = new RestClient("https://goingto.azurewebsites.net/api");
            request = new RestRequest("/locatables/{locatableid}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("locatableId", 1);
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
