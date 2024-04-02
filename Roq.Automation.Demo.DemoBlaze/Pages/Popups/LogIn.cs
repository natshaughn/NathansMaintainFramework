using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class LogIn
	{
		public static By Username => By.Id("loginusername");
		public static By Password => By.Id("loginpassword");
		public static By LogInButton => By.XPath("//button[text()='Log in']");
	}
}
