using OpenQA.Selenium;

namespace Roq.Automation.Demo.DemoBlaze.Pages.Popups
{
	public static class PlaceOrder
	{
		public static By Name => By.Id("name");
		public static By Country => By.Id("country");
		public static By City => By.Id("city");
		public static By CreditCard => By.Id("card");
		public static By Month => By.Id("month");
		public static By Year => By.Id("year");
		public static By Purchase => By.XPath("//button[text()='Purchase']");
	}
}
