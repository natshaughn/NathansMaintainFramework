using OpenQA.Selenium;

namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
	internal static class Alerts
	{
		public static bool IsAlertPresent()
		{
			try
            {
                DriverManager.WebDriver.SwitchTo().Alert();
				return true;
			}
			catch (NoAlertPresentException)
			{
				return false;
			}
		}
	}
}
