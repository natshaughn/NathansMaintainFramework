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
        [Given(@"I open the contact us menu")]
        public void GivenIOpenTheContactUsMenu()
        {
            // Changed from Cart to Contact
            DriverManager.WebDriver.FindElement(Pages.Home.Contact).Click();
        }

        [When(@"I open the contact us menu")]
		public void WhenIOpenTheContactUsMenu()
		{
			// Changed from Cart to Contact
			DriverManager.WebDriver.FindElement(Pages.Home.Contact).Click();
		}

        [When(@"I complete the contact us form")]
        public void WhenICompleteTheContactUsForm()
        {
            // Added .message 
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).SendKeys("FakeEmail@roq.co.uk");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).SendKeys("FakeEmail@roq.co.uk");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).SendKeys("Blah");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Click();
        }

        [Then(@"the contact us menu is displayed")]
		public void ThenTheContactUsMenuIsDisplayed()
		{
			bool emailDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).Displayed;
			bool nameDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).Displayed;
			bool messageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).Displayed;
			bool sendMessageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Displayed;

            // Added assertions
            Assert.IsTrue(emailDisplayed, "Email field not displayed");
            Assert.IsTrue(nameDisplayed, "Name field not displayed");
            Assert.IsTrue(messageDisplayed, "Message field not displayed");
            Assert.IsTrue(sendMessageDisplayed, "Send Message Button is not displayed");
		}

		[Then(@"the contact us form is submitted")]
		public void ThenTheContactUsFormIsSubmitted()
		{
			Assert.IsTrue(Alerts.IsAlertPresent(), "Alert is not showing after submitting the Contact Us form");
            // Added this:
            DriverManager.WebDriver.SwitchTo().Alert().Accept();
        }
	}
}
