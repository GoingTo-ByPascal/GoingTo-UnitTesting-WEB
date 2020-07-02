using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class CountryCitiesSteps
    {

        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;

        public CountryCitiesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have use the Get verb filtering  by country")]
        public void GivenIHaveUseTheGetVerbFilteringByCountry()
        {
            client = new RestClient("https://goingto.azurewebsites.net/api");
            request = new RestRequest("/countries/{countryid}/cities", Method.GET, DataFormat.Json);
            request.AddUrlSegment("countryId", 1);
        }
        
        [When(@"I press the search buttom")]
        public void WhenIPressTheSearchButtom()
        {
            response = client.Execute(request);
        }
        
        [Then(@"the result code should be (.*) on the desktop")]
        public void ThenTheResultCodeShouldBeOnTheDesktop(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200 causa");
        }
    }
}
