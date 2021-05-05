using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class DestinationDescriptionsSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;

        public DestinationDescriptionsSteps(ScenarioContext scenarioContext) 
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I'm looking for a description of a destination")]
        public void GivenIMLookingForADescriptionOfADestination()
        {
            client = new RestClient("https://api-goingto.azurewebsites.net/api");
            request = new RestRequest("/locatables/{locatableid}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("locatableid", 1);
        }
        
        [When(@"I  execute the request")]
        public void WhenIExecuteTheRequest()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the  result should be (.*)")]
        public void ThenTheResultShouldBe(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200");
        }
    }
}
