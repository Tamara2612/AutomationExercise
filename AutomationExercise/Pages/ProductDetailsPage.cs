using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Pages
{
    class ProductDetailsPage
    {
        readonly IWebDriver _driver;
        public By page = By.ClassName("product-details");
        public By addBtn = By.ClassName("cart");
        public By productName = By.XPath("//*[@class='product-information']//h2");
        public By viewCart = By.XPath("//*[@id='cartModal']//a");
        public ProductDetailsPage(IWebDriver driver)
        {
            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(page));
        }
    }
}
