using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
	public static class DriverManager
	{
		public static WebDriver? WebDriver { get; set; }

		public static void StartDriver(string browserName)
		{
			switch (browserName)
			{
				case "Edge":
					WebDriver = new EdgeDriver();
					EdgeOptions edgeOptions = new EdgeOptions();
					edgeOptions.AddArgument("--start-maximized");
					break;
				case "Chrome":
					WebDriver = new ChromeDriver();
					ChromeOptions options = new ChromeOptions();
					options.AddArgument("--start-maximized");
					break;
					//Added new default & added Chrome as a case
				default:
					throw new Exception("This browser is not supported");
			}

			//maximise window
			/*WebDriver.Manage().Window.Maximize();

			WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);*/
		}
	}
}