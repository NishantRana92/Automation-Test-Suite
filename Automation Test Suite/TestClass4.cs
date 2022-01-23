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
    public class TestClass4 : Common_lib
    {
        [Test]
        public void Test_case_4()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-shop"))).Click();
            Adding_products_to_cart(2, "product-2");
            Adding_products_to_cart(5, "product-4");
            Adding_products_to_cart(3, "product-7");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-cart"))).Click();

            var individual_price_stuffed_frog = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[1]/td[text()=' Stuffed Frog']//following-sibling::td[1]"))).Text;
            var individual_price_fluffy_bunny = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[2]/td[text()=' Fluffy Bunny']//following-sibling::td[1]"))).Text;
            var individual_price_valentine_bear = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[3]/td[text()=' Valentine Bear']//following-sibling::td[1]"))).Text;

            var stuffed_frog_quantity = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[1]/td[text()=' Stuffed Frog']//following-sibling::td[2]//input"))).GetAttribute("Value");
            var fluffy_bunny_quantity = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[2]/td[text()=' Fluffy Bunny']//following-sibling::td[2]//input"))).GetAttribute("Value");
            var valentine_bear_quantity = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[3]/td[text()=' Valentine Bear']//following-sibling::td[2]//input"))).GetAttribute("Value");

            // verifying the price of each product
            Assert.AreEqual(individual_price_stuffed_frog, "$10.99", "FAIL: Price mismatch");
            Assert.AreEqual(individual_price_fluffy_bunny, "$9.99", "FAIL: Price mismatch");
            Assert.AreEqual(individual_price_valentine_bear, "$14.99", "FAIL: Price mismatch");

            float sum_of_stuffed_frog_price = float.Parse(individual_price_stuffed_frog.Trim(new Char[] { '$' })) * Int32.Parse(stuffed_frog_quantity);
            float sum_of_fluffy_bunny_price = float.Parse(individual_price_fluffy_bunny.Trim(new Char[] { '$' })) * Int32.Parse(fluffy_bunny_quantity);
            float sum_of_valentine_bear_price = float.Parse(individual_price_valentine_bear.Trim(new Char[] { '$' })) * Int32.Parse(valentine_bear_quantity);

            // verifying each product's sub total
            Assert.AreEqual("$" + sum_of_stuffed_frog_price, "$21.98", "FAIL: Sub total price mismatch");
            Assert.AreEqual("$" + (sum_of_fluffy_bunny_price.ToString("0.00")), "$49.95", "FAIL: ");
            Assert.AreEqual("$" + sum_of_valentine_bear_price, "$44.97");

            float subtotal = sum_of_fluffy_bunny_price + sum_of_stuffed_frog_price + sum_of_valentine_bear_price;


            // verifying the total sum of all products in the cart
            Assert.AreEqual(subtotal.ToString("0.0"), "116.9", "FAIL");


        }
    }
}
