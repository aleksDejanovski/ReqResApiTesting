using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Infrastructure;

namespace ReqresApiTesting.StepDefinitions
{
    [Binding]
    public class GeneralStepDefinitions
    {
        protected HttpClient httpClient;

        protected HttpResponseMessage response;
        protected string responseBody;
        public ISpecFlowOutputHelper specFlowOutputHelper;
        protected ScenarioContext _scenarioContext;

        public GeneralStepDefinitions(ISpecFlowOutputHelper specFlowOutputHelper, ScenarioContext scenarioContext)
        {
             httpClient = new HttpClient();
            this.specFlowOutputHelper = specFlowOutputHelper;
            _scenarioContext = scenarioContext;

            
        }
    
    }
}
