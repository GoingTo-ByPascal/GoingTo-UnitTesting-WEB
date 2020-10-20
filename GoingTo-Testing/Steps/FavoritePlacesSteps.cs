using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
  [Binding]
  class FavoritePlacesSteps
  {
    private RestClient client;
    private RestRequest request;
    IRestResponse response;

    private ScenarioContext _scenarioContext;

    public FavoritePlacesSteps(ScenarioContext scenarioContext)
    {
      _scenarioContext = scenarioContext;
    }

    [Given(@"A List of historic places")]
    public void GivenAListOfHistoricPlaces()
    {
      client = new RestClient("https://goingto.azurewebsites.net/api");
      request = new RestRequest("/cities/{cityid}/places", Method.GET, DataFormat.Json);
      request.AddUrlSegment("cityId", 1);
    }

    [When(@"I select {one}")]
    public void WhenISelectOne()
    {
      response = client.Execute(request);
    }

    [Then(@"the result code should be (.*)")]
    public void ThenTheResultCodeshouldBe(int status)
    {
      int statusCode = (int) response.StatusCode;
      Assert.AreEqual(status, statusCode, "Status code is not 200 causa");
    }

    [Given(@" A place that is show")]
    public void GivenAPlaceThatIsShow()
    {
      client = new RestClient("https://goingto.azurewebsites.net/api");
      request = new RestRequest("/cities/{cityid}/places", Method.GET, DataFormat.Json);
      request.AddUrlSegment("cityId", 1);
    }

    [When(@"Select a { place }")]
    public void WhenISelectAPlace()
    {
      response = client.Execute(request);
    }
  }
}

