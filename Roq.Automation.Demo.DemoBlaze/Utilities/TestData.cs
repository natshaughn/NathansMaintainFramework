namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
	public static class TestData
	{
		public static Dictionary<string, object>? TestDataDictionary { get; set; }

		static TestData()
		{
			TestDataDictionary = new();
		}

		public static void TearDown()
		{
            TestDataDictionary.Clear();
        }
	}
}
