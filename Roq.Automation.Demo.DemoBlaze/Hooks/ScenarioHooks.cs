using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Hooks
{
	[Binding]
	public class ScenarioHooks : ExtentReport 
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportInit();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportTearDown(); 
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) 
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
		public static void BeforeScenario(ScenarioContext scenarioContext)
		{
			DriverManager.StartDriver("Edge"); //Changed from "Firefox" because it's not implemented in Driver Manager class
            DriverManager.GoTo("https://www.demoblaze.com/index.html");
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var driver = DriverManager.WebDriver;

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text; 

            if (scenarioContext.TestError == null) 
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            // When scenario fails 
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build()); 
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(AddScreenshot(driver, scenarioContext)).Build());
                }
            }
        }

        [AfterScenario]
		public static void AfterScenario(/*ScenarioContext scenarioContext*/)
		{
            /*if (scenarioContext.TestError != null)
			{
				string path = $@"{Path.GetTempPath()}\Automation\Output\";
				Directory.CreateDirectory(path);
				string fileName = $"Screenshot_{scenarioContext.ScenarioInfo.Title}.Png";
				string filePath = Path.Combine(path, fileName);
				((ITakesScreenshot)DriverManager.WebDriver).GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
			}
*/
            DriverManager.WebDriver.Close();
		}
	}
}