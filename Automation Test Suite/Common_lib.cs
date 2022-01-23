using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Automation_Test_Suite
{
    public class Common_lib : SetupClass
    {
        public bool Verify_elemnt(string elementName)
        {

            try
            {
                bool isElementDisplayed = driver.FindElement(By.Id(elementName)).Displayed;
                return true;
            }
            catch
            {
                return false;
            }
        }


        public void Adding_mandatory_fields(string firstname, string email, string message)
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("forename"))).SendKeys(firstname);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("email"))).SendKeys(email);
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("message"))).SendKeys(message);
        }

        public void Adding_products_to_cart(int x, string element_id)
        {
            for (int i = 0; i < x; i++)
            {
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(element_id))).FindElement(By.ClassName("btn")).Click();
            }

        }
    }
}
