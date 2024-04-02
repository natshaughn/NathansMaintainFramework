using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public class ContactUs
	{
		public static By Email => By.Id("recipient-email");
		public static By Name => By.Id("recipient-name");
		public static By Message => By.Id("message-text");
		public static By SendMessage => By.XPath("//button[text()='Send message']");
	}
}
