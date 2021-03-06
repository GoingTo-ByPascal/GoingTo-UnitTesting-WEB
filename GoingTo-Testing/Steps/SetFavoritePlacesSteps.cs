﻿using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class SetFavoritePlacesSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestRequest favouriteRequest;
        IRestResponse response;
        IRestResponse favouriteResponse;

        private ScenarioContext _scenarioContext;

        public SetFavoritePlacesSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"A List of places")]
        public void GivenAListOfPlaces()
        {
            client = new RestClient("https://goingto-api.azurewebsites.net/api");
            request = new RestRequest("/cities/{cityId}/places", Method.GET, DataFormat.Json);
            request.AddUrlSegment("cityId", 1);
        }
        
        [When(@"I select (.*)")]
        public void WhenISelectPlace(int locatableId)
        {
            response = client.Execute(request);
            favouriteRequest = new RestRequest("/Users/1/Locatables/{locatableId}",Method.POST,DataFormat.Json);
            favouriteRequest.AddUrlSegment("locatableId", locatableId);
            favouriteResponse = client.Execute(favouriteRequest);
        } 
        
        [Then(@"the result should  be  (.*)")]
        public void ThenTheResultShouldBe(int status)
        {
            int statusCode = (int)favouriteResponse.StatusCode;
            Assert.AreEqual(status, statusCode, "Status code is not 200");
        }
    }
}
