using OpenQA.Selenium;
namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
    public static class RandomSelector
    {
        private static readonly Random random = new();

        public static IWebElement SelectRandomElement(List<IWebElement> elements)
        {
            int index = random.Next(elements.Count);
            return elements[index];
        }
    }
}
