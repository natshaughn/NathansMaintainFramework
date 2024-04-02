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
					break;
				default:
					WebDriver = new ChromeDriver();
					break;
			}

			WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
			WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
		}
	}
}