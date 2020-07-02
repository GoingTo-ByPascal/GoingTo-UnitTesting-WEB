using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class LocatableSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;

        public LocatableSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I search for a locatable with the GET verb")]
        public void GivenISearchForALocatableWithTheGETVerb()
        {
            request = new RestRequest("/locatables", Method.GET, DataFormat.Json);
            client = new RestClient("https://goingto.azurewebsites.net/api");
        }
        
        [When(@"I execute the request")]
        public void WhenIExecuteTheRequest()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200 causa");
        }
    }
}
