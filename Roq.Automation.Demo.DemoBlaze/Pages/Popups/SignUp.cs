using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class SignUp
	{
		public static By Username => By.Id("sign-username");
		public static By Password => By.Id("sign-password");
		public static By SignUpButton => By.XPath("//button[text()='Sign up']");
	}
}
