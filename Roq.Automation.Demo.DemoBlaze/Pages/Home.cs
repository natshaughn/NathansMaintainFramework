using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Home
	{
		public static string url => new("https://www.demoblaze.com/index.html");

		public static By Contact => By.XPath("//*[@id='navbarExample']/ul/li[2]/a");
		public static By LogIn => By.Id("login2");
		public static By AboutUs => By.XPath("/html/body/nav/div[1]/ul/li[2]/a");
		public static By Cart => By.XPath("//*[@id='cartur']");
		public static By SignUp => By.XPath("//a[@data-target='#signInModal']");

		// added
		public static By LogOut => By.Id("logout2");
	}
}
