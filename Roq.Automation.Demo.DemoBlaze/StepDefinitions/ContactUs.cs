using Roq.Automation.Demo.DemoBlaze.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.StepDefinitions
{
	[Binding]
	public class ContactUs
	{
		[When(@"I open the contact us menu")]
		public void WhenIOpenTheContactUsMenu()
		{
			DriverManager.WebDriver.FindElement(Pages.Home.Cart).Click();
		}

		[Given(@"I open the contact us menu")]
		public void GivenIOpenTheContactUsMenu()
		{
			DriverManager.WebDriver.FindElement(Pages.Home.Cart).Click();
		}

		[Then(@"the contact us menu is displayed")]
		public void ThenTheContactUsMenuIsDisplayed()
		{
			bool emailDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).Displayed;
			bool nameDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).Displayed;
			bool messageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).Displayed;
			bool sendMessageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Displayed;
		}

		[When(@"I complete the contact us form")]
		public void WhenICompleteTheContactUsForm()
		{
			DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).SendKeys("FakeEmail@roq.co.uk");
			DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).SendKeys("FakeEmail@roq.co.uk");
			DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).SendKeys("Blah");
			DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Click();
		}

		[Then(@"the contact us form is submitted")]
		public void ThenTheContactUsFormIsSubmitted()
		{
			Assert.IsTrue(Alerts.IsAlertPresent());
		}
	}
}
