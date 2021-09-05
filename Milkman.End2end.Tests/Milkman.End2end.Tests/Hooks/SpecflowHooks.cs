using Microsoft.Extensions.Configuration;
using Milkman.End2end.Tests.Factories;
using Milkman.End2end.Tests.Helpers;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace Milkman.End2end.Tests.Hooks
{
    [Binding]
    public sealed class SpecflowHooks
    {
        private readonly ScenarioContext _scenarioContext;


        public SpecflowHooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            var path = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var fileName = Path.GetFullPath(Path.Combine(path ?? throw new InvalidOperationException(
                                                                 $"Path does not exist"), @"..\..\..\"));

            var configuration = new ConfigurationBuilder()
                                  .SetBasePath(fileName)
                                  .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot configurationRoot = configuration.Build();

            var configurationHelper = new ConfigurationHelper(configurationRoot);

            var driver = new BrowserFactory(configurationHelper).GetWebDriver();

            _scenarioContext.ScenarioContainer.RegisterInstanceAs(configurationRoot);
            _scenarioContext.ScenarioContainer.RegisterInstanceAs(driver);

            driver.Navigate().GoToUrl(configurationHelper.BaseUrl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(configurationHelper.ElementTimeout);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(configurationHelper.PageLoadTimeout);
        }



        [AfterScenario]
        public void AfterScenario()
        {
            _scenarioContext.ScenarioContainer.Resolve<IConfigurationRoot>();
            var driver = _scenarioContext.ScenarioContainer.Resolve<IWebDriver>();

            driver?.Quit();
            driver?.Dispose();

        }
    }
}
