
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationExercise.Pages
{
    class AuthenticationPage
    {
        readonly IWebDriver _driver;
        public By authPage = By.Id("form");
        public By loginEmail = By.CssSelector(".login-form [type='email']");
        public By loginPassword = By.CssSelector(".login-form [type='password']");
        public By loginBtn = By.CssSelector(".login-form [type='submit']");
        public By name = By.Name("name");
        public By signupEmail = By.CssSelector(".signup-form [type='email']");
        public By signupBtn = By.CssSelector(".signup-form [type='submit']");
        
        public AuthenticationPage(IWebDriver driver)
        {

            this._driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(authPage));

        }

    }
}
