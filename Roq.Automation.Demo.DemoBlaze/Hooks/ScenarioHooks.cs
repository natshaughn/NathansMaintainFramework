using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Hooks
{
	[Binding]
	public class ScenarioHooks
	{
		[BeforeScenario]
		public static void BeforeScenario()
		{
			DriverManager.StartDriver("Firefox");
		}

		[AfterScenario]
		public static void AfterScenario(ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError != null)
			{
				string path = $@"{Path.GetTempPath()}\Automation\Output\";
				Directory.CreateDirectory(path);
				string fileName = $"Screenshot_{scenarioContext.ScenarioInfo.Title}.Png";
				string filePath = Path.Combine(path, fileName);
				((ITakesScreenshot)DriverManager.WebDriver).GetScreenshot().SaveAsFile(filePath, ScreenshotImageFormat.Png);
			}

			DriverManager.WebDriver.Close();
		}
	}
}