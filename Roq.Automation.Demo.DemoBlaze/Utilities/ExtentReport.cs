using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Roq.Automation.Demo.DemoBlaze.Utilities
{
    public class ExtentReport
    {
        public static ExtentReports? _extentReports;
        public static ExtentTest? _feature;
        public static ExtentTest? _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory; // Directory of the project
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults"); // replacing particular path with TestResults - folder created earlier, generate report in that folder

        public static void ExtentReportInit()  //public static void ExtentReportInit(Hooks.AppInfo appInfo, string gridUrl)
        {
            // Configure and start HTML reporter
            var htmlReporter = new ExtentHtmlReporter(testResultPath); // testResultPath - object = path for report - Object = ExtentHtmlReporter 
            htmlReporter.Config.ReportName = "Desktop Automation Status Report"; // values for the report can be seen here
            htmlReporter.Config.DocumentTitle = "Desktop Automation Status Report";
            htmlReporter.Config.Theme = Theme.Standard; // which colour 
            htmlReporter.Start(); // start particular object 

            // Initialize ExtentReports and attach the HTML reporter
            _extentReports = new ExtentReports(); // ExtentReports = object 
            _extentReports.AttachReporter(htmlReporter); // attaching the reporter 
            _extentReports.AddSystemInfo("Application", "Word"); // configurations - hard coded at the minute (TestRunSettings here? maybe)
        }

        // Method to flush and close ExtentReports
        public static void ExtentReportTearDown()
        {
            _extentReports.Flush(); // Method (), Flush - all logs getting flushed into HTML report
        }

        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(testResultPath, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}

