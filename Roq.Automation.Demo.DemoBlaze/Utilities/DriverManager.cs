using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
	public static class DriverManager
	{
		public static WebDriver? WebDriver { get; set; }

		public static void GoTo(string url)
		{
            WebDriver.Url = url;
		}

		public static void StartDriver(string browserName)
		{
			switch (browserName)
			{
				case "Edge":
					WebDriver = new EdgeDriver();
					EdgeOptions edgeOptions = new();
					break;
				case "Chrome":
					WebDriver = new ChromeDriver();
					ChromeOptions options = new();
					break;
				default:
					throw new Exception("This browser is not supported");
			}

			WebDriver.Manage().Window.Maximize();

            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
		}
	}
}
