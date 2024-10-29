using ReqresApiTesting.StepDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
    }
}
