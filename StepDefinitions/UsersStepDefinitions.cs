using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReqresApiTesting.Models;
using ReqresApiTesting.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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

   

        [When(@"I send GET request to the /users endpoint")]
        public async Task WhenISendGETRequestToTheUsersEndpoint()
        {
            response = await UserServices.GetAllUsers();
            responseBody = await response.Content.ReadAsStringAsync();
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
            response.EnsureSuccessStatusCode();
           
        }

        [When(@"I send GET request to the /users/\{id} endpoint using ""([^""]*)"" as an id")]
        public async Task WhenISendGETRequestToTheUsersIdEndpointUsingAsAnId(string id)
        {
            response = await UserServices.GetSpecificUser(id);
            responseBody = await response.Content.ReadAsStringAsync();
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
        }

        [When(@"I Create a valid user with username ""([^""]*)"", email as ""([^""]*)"" and random password")]
        public async Task WhenICreateAValidUserWithUsernameEmailAsAndRandomPassword(string username, string email)
        {
            CreateUserModel data = new CreateUserModel();
            data.Username = username;
            data.Email = email;
            data.Password = "12";
            JObject body = JObject.FromObject(data);
            var response = await UserServices.CreateUser(body);
            ScenarioContext.Set<HttpResponseMessage>(response, "response");
            
            
        }


        [Then(@"The response contains ""([^""]*)""")]
        public async Task ThenTheResponseContains(string content)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var responseBody2 = await response.Content.ReadAsStringAsync();
            Assert.Contains(content, responseBody2);
        }


        [Then(@"The response code is HTTP (.*)")]
        public async Task ThenTheResponseCodeIsHTTPSuccess(int code)
        {
           var response = ScenarioContext.Get<HttpResponseMessage>("response");
            response.StatusCode.Should().Be((HttpStatusCode)code);
        }

        [Then(@"The property first_name has a value ""([^""]*)""")]
        public async Task ThenThePropertyHasAValue( string value)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<UserResponseModel>();
            json.data.first_name.Should().Be(value);
        }

        [Then(@"The property first_name does not contain value as ""([^""]*)""")]
        public async Task ThenThePropertyFirst_NameDoesNotContainValueAs(string name)
        {
            var response = ScenarioContext.Get<HttpResponseMessage>("response");
            var json = await response.Content.ReadFromJsonAsync<UserResponseModel>();
            json.data.first_name.Should().NotBe(name);
        }




    }
}
