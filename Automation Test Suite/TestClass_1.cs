using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Automation_Test_Suite
{
    [TestFixture]
    [Parallelizable]
    public class TestClass_1 : Common_lib
    {
        [Test]
        public void Test_case_1()
        {
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-contact"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("form-actions"))).FindElement(By.TagName("a")).Click();

            //Validating error 
            Assert.IsTrue(Verify_elemnt("forename-err"), "FAIL: Firstname error not available");
            Assert.IsTrue(Verify_elemnt("email-err"), "FAIL: Email error not available");
            Assert.IsTrue(Verify_elemnt("message-err"), "FAIL: Message error not available");

            // Populating madatory fields
            Adding_mandatory_fields("Test User", "email@mail.com", "Test Message");

            //Validating error are gone
            Assert.IsFalse(Verify_elemnt("forename-err"), "FAIL: Firstname error");
            Assert.IsFalse(Verify_elemnt("email-err"), "FAIL: Email error");
            Assert.IsFalse(Verify_elemnt("message-err"), "FAIL: Message error");
        }

    }


}
