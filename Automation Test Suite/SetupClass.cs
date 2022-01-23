using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using OpenQA.Selenium.Support.UI;

namespace Automation_Test_Suite
{
    [TestFixture]
    public class SetupClass
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;

        [SetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--window-size=1920,1080");
            chromeOptions.AddArguments("--start-maximized");
            chromeOptions.AddArguments("--headless");
            chromeOptions.AddArgument("no-sandbox");
            chromeOptions.AddArguments("--disable-gpu");
            chromeOptions.AddArguments("--disable-extensions");
            driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl("https://jupiter.cloud.planittesting.com");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        
        [TearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}
