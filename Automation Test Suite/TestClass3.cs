using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test_Suite
{
    [TestFixture]
    [Parallelizable]
    public class TestClass3 : Common_lib
    {
        [Test]
        public void Test_case_3()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-shop"))).Click();
            Adding_products_to_cart(2, "product-6");
            Adding_products_to_cart(1, "product-4");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-cart"))).Click();
            var item_1_count = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[1]/td[text()=' Funny Cow']//following-sibling::td//input"))).GetAttribute("value");
            var item_2_count = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[2]/td[text()=' Fluffy Bunny']//following-sibling::td//input"))).GetAttribute("value");

            // verifying the items in the cart
            Assert.AreEqual(Int32.Parse(item_1_count), 2, "FAIL: Total Number of Funny Cow's in shopping cart are wrong");
            Assert.AreEqual(Int32.Parse(item_2_count), 1, "FAIL: Total of Fluffy Bunny's in shopping cart are wrong");
        }
    }
}
