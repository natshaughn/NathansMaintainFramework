using Microsoft.AspNetCore.Http;
using OpenQA.Selenium;
using Roq.Automation.Demo.DemoBlaze.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Pages
{
	public static class Home
	{
		public static string url => new("https://www.demoblaze.com/index.html");

		public static By Contact => By.XPath("//*[@id='navbarExample']/ul/li[2]/a");
		public static By LogIn => By.Id("login2");
		public static By AboutUs => By.XPath("/html/body/nav/div[1]/ul/li[3]/a"); // Same as Contact so changed it to three [3]
		public static By Cart => By.XPath("//*[@id='cartur']");
		public static By SignUp => By.XPath("//a[@data-target='#signInModal']");
        public static By ProductCards => By.XPath("//h4[@class='card-title']/a");
        public static By NameOfProduct(string productName) => By.XPath($"//a[text()='{productName}']");
        public static By NameOfCategory(string cateogryName) => By.XPath($"//a[text()='{cateogryName}']");

        // Added xpaths above and methods below in here 
        public static void NavigateToRandomProductPage()
        {
            List<IWebElement> cards = DriverManager.WebDriver.FindElements(ProductCards).ToList();
            IWebElement card = cards[new Random().Next(0, cards.Count)];
            card.Click();
        }

        public static void NavigateToProductPage(string productName)
        {
            DriverManager.WebDriver.FindElement(NameOfProduct(productName)).Click();
        }

        public static string IsCategoryAvailable(string categoryName)
        {
            return DriverManager.WebDriver.FindElement(NameOfCategory(categoryName)).Text;
        }
    }
}
