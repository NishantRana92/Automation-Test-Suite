﻿using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using SeleniumExtras.WaitHelpers;
using System;

namespace Automation_Test_Suite
{
    [TestFixture]
    public class TestClass : Common_lib
    {
        [Test]
        public void Test_case_1()
        {
            
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-contact"))).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("form-actions"))).FindElement(By.TagName("a")).Click();

            //Validating error 
            Assert.IsTrue(Verify_elemnt("forename-err"), "FAIL: Forename error not available");
            Assert.IsTrue(Verify_elemnt("email-err"), "FAIL: Email error not available");
            Assert.IsTrue(Verify_elemnt("message-err"), "FAIL: Message error not available");

            // Populating madatory fields
            Adding_mandatory_fields("Test User", "email@mail.com", "Test Message");

            //Validating error are gone
            Assert.IsFalse(Verify_elemnt("forename-err"), "FAIL: Forname error");
            Assert.IsFalse(Verify_elemnt("email-err"), "FAIL: Email error");
            Assert.IsFalse(Verify_elemnt("message-err"), "FAIL: Message error");
        }


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

        [Test]
        public void Test_case_3()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-shop"))).Click();
            Adding_products_to_cart(2,"product-6");
            Adding_products_to_cart(1, "product-4");
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("nav-cart"))).Click();
            var item_1_count = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[1]/td[text()=' Funny Cow']//following-sibling::td//input"))).GetAttribute("value");
            var item_2_count = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[2]/div/form/table/tbody/tr[2]/td[text()=' Fluffy Bunny']//following-sibling::td//input"))).GetAttribute("value");
            
            // verifying the items in the cart
            Assert.AreEqual(Int32.Parse(item_1_count), 2, "FAIL: Total Number of Funny Cow's in shopping cart are wrong");
            Assert.AreEqual(Int32.Parse(item_2_count), 1, "FAIL: Total of Fluffy Bunny's in shopping cart are wrong");
        }

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
            
            float sum_of_stuffed_frog_price = float.Parse(individual_price_stuffed_frog.Trim(new Char[] {'$'})) * Int32.Parse(stuffed_frog_quantity);
            float sum_of_fluffy_bunny_price = float.Parse(individual_price_fluffy_bunny.Trim(new Char[] {'$'})) * Int32.Parse(fluffy_bunny_quantity);
            float sum_of_valentine_bear_price = float.Parse(individual_price_valentine_bear.Trim(new Char[] {'$'})) * Int32.Parse(valentine_bear_quantity);

            // verifying each product's sub total
            Assert.AreEqual("$"+sum_of_stuffed_frog_price, "$21.98", "FAIL: Sub total price mismatch");
            Assert.AreEqual("$"+(sum_of_fluffy_bunny_price.ToString("0.00")), "$49.95",  "FAIL: ");
            Assert.AreEqual("$"+sum_of_valentine_bear_price, "$44.97");

            float subtotal = sum_of_fluffy_bunny_price + sum_of_stuffed_frog_price + sum_of_valentine_bear_price;
            
            
            // verifying the total sum of all products in the cart
            Assert.AreEqual(subtotal.ToString("0.0"), "116.9", "FAIL");


        }
    }


}
