using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace HW4.Page
{
    class SelectPage
    {
        private IWebDriver _driver;
        public IWebElement dropdownElement => _driver.FindElement(By.Id("multi-select"));
        public SelectElement dropdown => new SelectElement(dropdownElement);
        public IWebElement FirstSelectedBtn => _driver.FindElement(By.Id("printMe"));
        public IWebElement AllSelectedBtn => _driver.FindElement(By.Id("printAll"));
        public IWebElement AllSelectedElement => _driver.FindElement(By.ClassName("getall-selected"));
        public SelectPage(IWebDriver driver) { _driver = driver; }

        public SelectPage SelectOptions(int[] ids)
        {
            dropdown.DeselectAll();
            Actions actions = new Actions(_driver);
            actions.KeyDown(Keys.Control);
            foreach (int id in ids)
            {
                if (id < dropdown.Options.Count - 1)
                    actions.Click(dropdown.Options[id]);
            }
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
            return this;
        }

        public SelectPage ClickFirstSelected()
        {
            FirstSelectedBtn.Click();
            return this;
        }
        public SelectPage ClickAllSelected()
        {
            AllSelectedBtn.Click();
            return this;
        }

        public string[] GetSelectedArray()
        {
            return dropdown.AllSelectedOptions.Select(option => option.Text).ToArray();
        }

    }
}
