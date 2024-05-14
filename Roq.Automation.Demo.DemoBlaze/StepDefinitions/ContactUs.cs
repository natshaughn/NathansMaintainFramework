using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        [Given(@"I open the contact us menu"), When(@"I open the contact us menu")]
        public void GivenIOpenTheContactUsMenu()
        {
            // Changed from Cart to Contact
            DriverManager.WebDriver.FindElement(Pages.Home.Contact).Click();
        }

        // Added above 
        /*[When(@"I open the contact us menu")]
		public void WhenIOpenTheContactUsMenu()
		{
			// Changed from Cart to Contact
			DriverManager.WebDriver.FindElement(Pages.Home.Contact).Click();
		}*/

        [When(@"I complete the contact us form")]
        public void WhenICompleteTheContactUsForm()
        {
            // Added .message 
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).SendKeys("FakeEmail@roq.co.uk");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).SendKeys("FakeEmail@roq.co.uk");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).SendKeys("Blah");
            DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Click();
        }

        // Complete the form above so this does the test below
/*        [Then(@"the contact us menu is displayed")]
		public void ThenTheContactUsMenuIsDisplayed()
		{
           
            *//*WebDriverWait wait = new WebDriverWait(DriverManager.WebDriver, TimeSpan.FromSeconds(10));
            IWebElement emailElement = wait.Until(ExpectedConditions.ElementIsVisible(Pages.Popups.ContactUs.Email));*/

           /* bool emailDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).Displayed;
			bool nameDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).Displayed;
			bool messageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).Displayed;
			bool sendMessageDisplayed = DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Displayed;*/

            /*// Added assertions
            Assert.IsTrue(emailDisplayed, "Email field not displayed");
            Assert.IsTrue(nameDisplayed, "Name field not displayed");
            Assert.IsTrue(messageDisplayed, "Message field not displayed");
            Assert.IsTrue(sendMessageDisplayed, "Send Message Button is not displayed");*//*          
            Assert.That(DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Email).Displayed, Is.True, "Email field not displayed");
            Assert.That(DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Name).Displayed, Is.True, "Name field not displayed");
            Assert.That(DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.Message).Displayed, Is.True, "Message field not displayed");
            Assert.That(DriverManager.WebDriver.FindElement(Pages.Popups.ContactUs.SendMessage).Displayed, Is.True, "Send Message Button is not displayed");          
        }*/

        [Then(@"the contact us form is submitted")]
		public void ThenTheContactUsFormIsSubmitted()
		{
            /*Assert.IsTrue(Alerts.IsAlertPresent(), "Alert is not showing after submitting the Contact Us form");*/
            Assert.That(Alerts.IsAlertPresent(), Is.True, "Alert is not showing after submitting the Contact Us form");

            // Added this:
            DriverManager.WebDriver.SwitchTo().Alert().Accept();
        }
	}
}
