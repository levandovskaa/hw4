using HW4.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;

namespace HW4.Test
{
    class SelectTest
    {
        private IWebDriver _driver;
        [OneTimeSetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [TestCase]
        public void TestTwo()
        {
            SelectPage page = new SelectPage(_driver).SelectOptions(new int[] { 0, 1 }).ClickFirstSelected();
            string firstValue = page.dropdown.AllSelectedOptions[0].GetAttribute("value");
            Assert.IsTrue(page.AllSelectedElement.Text.Contains(firstValue), "Shows first selected state");
        }   
        [TestCase]
        public void TestThree()
        {
            SelectPage page = new SelectPage(_driver).SelectOptions(new int[] { 2, 1, 3 }).ClickFirstSelected();
            string firstValue = page.dropdown.AllSelectedOptions[2].GetAttribute("value");
            Assert.IsTrue(page.AllSelectedElement.Text.Contains(firstValue), "Shows first selected state");
        }        
        [TestCase]
        public void TestAllSelectedForTwo()
        {
            SelectPage page = new SelectPage(_driver).SelectOptions(new int[] { 3, 0 }).ClickAllSelected();
            bool intersects = page.GetSelectedArray().Intersect(page.AllSelectedElement.Text.Split(" ")).Any();
            Assert.IsTrue(intersects);
        }       
        [TestCase]
        public void TestAllSelectedForFour()
        {
            SelectPage page = new SelectPage(_driver).SelectOptions(new int[] { 2, 1, 3, 0 }).ClickAllSelected();
            bool intersects = page.GetSelectedArray().Intersect(page.AllSelectedElement.Text.Split(" ")).Any();
            Assert.IsTrue(intersects);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
