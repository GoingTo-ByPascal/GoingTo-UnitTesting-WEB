using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace GoingTo_Testing.Steps
{
    [Binding]
    public class BuscarTachaSteps
    {
        private RestClient client;
        private RestRequest request;
        IRestResponse response;

        private ScenarioContext _scenarioContext;
        public BuscarTachaSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"El administrador proporcionó un (.*) existente")]
        public void GivenElAdministradorProporcionoUnExistente(int id)
        {
            client = new RestClient("https://JNEAPI.com/api");
            request = new RestRequest("/tachas/{tachaId}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("Id", id);
        }
        
        [Given(@"El administrador proporcionó un (.*) inexistente")]
        public void GivenElAdministradorProporcionoUnInexistente(int id)
        {
            client = new RestClient("https://JNEAPI.com/api");
            request = new RestRequest("/tachas/{tachaId}", Method.GET, DataFormat.Json);
            request.AddUrlSegment("Id", id);
        }
        
        [Given(@"El adminsitrador solicita las tachas")]
        public void GivenElAdminsitradorSolicitaLasTachas()
        {
            client = new RestClient("https://JNEAPI.com/api");
            request = new RestRequest("/tachas", Method.GET, DataFormat.Json);
        }
        
        [When(@"El administrador hace la solicitud para conseguir la tacha")]
        public void WhenElAdministradorHaceLaSolicitudParaConseguirLaTacha()
        {
            response = client.Execute(request);
        }
        
        [When(@"El administrador hace la solicitud para conseguir todas las tachas")]
        public void WhenElAdministradorHaceLaSolicitudParaConseguirTodasLasTachas()
        {
            response = client.Execute(request);
        }
        
        [Then(@"El codigo de respuesta del sistema es (.*)")]
        public void ThenElCodigoDeRespuestaDelSistemaEs(int status)
        {
            int statusCode = (int)response.StatusCode;
            Assert.AreEqual(status, statusCode, "El codigo de status no es 200");
        }
        
        [Then(@"Envia el mensaje ""(.*)""")]
        public void ThenEnviaElMensaje(string mensaje)
        {
            string descripcion = (string)response.StatusDescription;
            Assert.AreEqual(mensaje, descripcion, "No es correcto");
        }
    }
}
