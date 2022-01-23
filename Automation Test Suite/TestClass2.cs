using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Automation_Test_Suite
{
    [TestFixture]
    [Parallelizable]
    public class TestClass2 : Common_lib
    {
        [Test]
        [Repeat(5)]
        public void Test_case_2()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-contact"))).Click();
            Adding_mandatory_fields("Test User", "email@mail.com", "Test Message");
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("form-actions"))).FindElement(By.TagName("a")).Click();

            // Validating successfull submission message
            Assert.AreEqual(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/div/strong"))).Text, "Thanks Test User", "FAIL: Success message is not available");

        }
    }
}
