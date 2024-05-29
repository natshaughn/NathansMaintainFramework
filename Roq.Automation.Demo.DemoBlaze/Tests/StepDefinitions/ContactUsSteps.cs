using Roq.Automation.Demo.DemoBlaze.Pages;
using Roq.Automation.Demo.DemoBlaze.Pages.Popups;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Tests.StepDefinitions
{
    [Binding]
    public class ContactUsSteps
    {
        [Given(@"I open the contact us menu"), When(@"I open the contact us menu")]
        public void GivenIOpenTheContactUsMenu()
        {
            Home.Contact.Click();
        }


        [When(@"I complete the contact us form")]
        public void WhenICompleteTheContactUsForm()
        {
            ContactUs.FillOutContactForm();
        }

        [Then(@"the contact us form is submitted")]
        public void ThenTheContactUsFormIsSubmitted()
        {
            Assert.That(Alerts.IsAlertPresent(), Is.True, "Alert is not showing after submitting the Contact Us form");
            DriverManager.WebDriver.SwitchTo().Alert().Accept();
        }
    }
}
