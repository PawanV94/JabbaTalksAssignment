using FlightTest.Base;
using FlightTest.Helpers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace FlightTest
{
    [Binding]
    public sealed class Hooks
    {
        [BeforeTestRun]
        public static void TestStart()
        {
            Console.WriteLine("**************************************************************");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!Test initiated!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("**************************************************************");
        }

        [BeforeFeature]
        public static void FeatureStart()
        {
            ReportingHelpers.CreateFeature(FeatureContext.Current.FeatureInfo.Title, FeatureContext.Current.FeatureInfo.Description);
            InitializeDriver();
        }

        [BeforeScenario]
        public static void ScenarioStart()
        {
            ReportingHelpers.CreateChildTest(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterStep]
        public static void StepStop()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.TestError == null)
            {
                ReportingHelpers.CreateChildTest("Pass " + stepType + " - " + ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                ReportingHelpers.CreateChildTest("Fail "+ stepType + " - '" + ScenarioContext.Current.StepContext.StepInfo.Text + "' - " + ScenarioContext.Current.TestError.Message);
            }
            //Pending Status
            if (TestResult.ToString() == "StepDefinitionPending")
            {
                ReportingHelpers.CreateChildTest("Skip "+ stepType + " - " + ScenarioStepContext.Current.StepInfo.Text);

            }
        }

        [AfterFeature]
        public static void FeatureStop()
        {
            DriverContext.Driver.Quit();
            Console.WriteLine("**********Terminated driver session**********");
        }

        [AfterTestRun]
        public static void TestStop()
        {
            DriverContext.Driver.Quit();
            Console.WriteLine("**********Terminated driver session**********");
        }

        /// <summary>
        /// Initialize Selenium Driver
        /// </summary>
        public static void InitializeDriver()
        {
            try
            {
                //Open Browser
                OpenBrowser();
                Console.Write("~~~~~Initialized Driver~~~~~");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Choose Driver based on Grid value
        /// </summary>
        public static void OpenBrowser(PlatformType platform = PlatformType.Windows, BrowserType browserType = BrowserType.Chrome)
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();

            LocalDriver(browserType);
        }

        /// <summary>
        /// Initialize Local WebDriver
        /// </summary>
        private static void LocalDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;

                case BrowserType.Firefox:
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;

                case BrowserType.Chrome:
                    ChromeOptions chromeOptions = new ChromeOptions();
                    chromeOptions.AddArguments("--start-maximized");
                    chromeOptions.AddArguments("--no-sandbox");
                    chromeOptions.AddArguments("--disable-dev-shm-usage");
                    chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");

                    DriverContext.Driver = new ChromeDriver(chromeOptions);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}

