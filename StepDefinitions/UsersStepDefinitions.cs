using ReqresApiTesting.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace ReqresApiTesting.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions : GeneralStepDefinitions
    {
        private string baseUrl = "https://reqres.in/api";
        private readonly ScenarioContext scenarioContext;

        public UsersStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
           ScenarioContext = scenarioContext;
        }

        UserServices UserServices => new UserServices(specFlowOutputHelper, scenarioContext);

        public ScenarioContext ScenarioContext { get; }

        [Given(@"I send api call using HTTP client")]
        public async Task GivenISendApiCallUsingHTTPClient()
        {
           
            response = await UserServices.GetAllUsers();
            responseBody = await response.Content.ReadAsStringAsync();
            ScenarioContext.Set<HttpResponseMessage>(response, "response");


        }

        [When(@"I send GET request to the /users endpoint")]
        public void WhenISendGETRequestToTheUsersEndpoint()
        {
           response.EnsureSuccessStatusCode();
           
        }

        [Then(@"The response contains ""([^""]*)""")]
        public void ThenTheResponseContains(string content)
        {
            Assert.Contains(content, responseBody);
        }


        [Then(@"The response code is HTTP (.*) success")]
        public async Task ThenTheResponseCodeIsHTTPSuccess(int code)
        {
           // Assert.True(await response.IsSuccessStatusCode());
           response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }




    }
}
