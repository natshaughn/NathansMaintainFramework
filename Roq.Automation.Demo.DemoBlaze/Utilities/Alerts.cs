using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
