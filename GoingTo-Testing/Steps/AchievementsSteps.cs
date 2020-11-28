using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Feature
{
    [Binding]
    public class AchievementsSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;
        private ScenarioContext _scenarioContext;

        public AchievementsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I search for systems's achievements")]
        public void GivenISearchForSystemsSAchievements()
        {
            request = new RestRequest("/achievements", Method.GET, DataFormat.Json);
            client = new RestClient("https://api-goingto.azurewebsites.net/api");
        }
        [When(@"I interact with the system")]
        public void WhenIInteractWithTheSystem()
        {
            response = client.Execute(request);
        }

            [Then(@"the result of the operation should be (.*)")]
            public void ThenTheResultOfTheOperationShouldBe(int status)
            {
                int statusCode = (int)response.StatusCode;
                Assert.AreEqual(status, statusCode, "Status code is not 200");
            }
        }
    } 

