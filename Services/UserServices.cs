using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReqresApiTesting.StepDefinitions;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace ReqresApiTesting.Services
{
    public class UserServices : GeneralStepDefinitions
    {
        private readonly string baseUrl = "https://reqres.in/api";

      

        public UserServices(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext) : base(specFlowOutputHelper, scenarioContext)
        {
        }

        public async Task <HttpResponseMessage> GetAllUsers()
        {
            return await httpClient.GetAsync($"{baseUrl}/users");
        }

        public async Task<HttpResponseMessage> GetSpecificUser(string id)
        {
            return await httpClient.GetAsync($"{baseUrl}/users/{id}");
        }

        public async Task<HttpResponseMessage> CreateUser (JObject body)
        {
            var requestUrl = $"{baseUrl}/register";
            string jsonString = body.ToString();
            HttpContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(requestUrl, content);
            return response;

          
        }
    }
}
