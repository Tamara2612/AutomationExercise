using System;
using AutomationExercise.Helpers;
using AutomationExercise.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationExercise.Steps
{
    [Binding]
    public class AuthenticationSteps : Base
    {

        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);

        [Given(@"User opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            ut.ClickonElement(hp.loginLink);
        }
        
        [Given(@"user enters correct credentials")]
        public void GivenUserEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextinElement(ap.loginEmail, TestConstants.Username);
            ut.EnterTextinElement(ap.loginPassword, TestConstants.Password);
        }
        
        [When(@"user submits login form")]
        public void WhenUserSubmitsLoginForm()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickonElement(ap.loginBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Assert.True(ut.ElementisDisplayed(hp.deleteAcc),"User is NOT logged in");
        }

        [Given(@"enters '(.*)'name and valid email address")]
        public void GivenEntersNameAndValidEmailAddress(string name)
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextinElement(ap.name, name);
            ut.EnterTextinElement(ap.signupEmail, ut.GenerateRandomEmail());
        }

        [Given(@"user clicks on SignUp button")]
        public void GivenUserClicksOnSignUpButton()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickonElement(ap.signupBtn);
        }
        

        [When(@"user fills in all required fields")]
        public void WhenUserFillsInAllRequiredFields()
        {
            SignupPage sp = new SignupPage(Driver);
            ut.EnterTextinElement(sp.password,TestConstants.Password);
            ut.EnterTextinElement(sp.firstName, TestConstants.FirstName);
            ut.EnterTextinElement(sp.firstName, TestConstants.LastName);
            ut.EnterTextinElement(sp.address, TestConstants.Address);
            ut.DropdownSelect(sp.country, TestConstants.Country);
            ut.EnterTextinElement(sp.state, TestConstants.State);
            ut.EnterTextinElement(sp.city, TestConstants.City);
            ut.EnterTextinElement(sp.zipcode, TestConstants.Zipcode);
            ut.EnterTextinElement(sp.mobile, TestConstants.Phone);
        }

        [When(@"submits the signup form")]
        public void WhenSubmitsTheSignupForm()
        {
            SignupPage sp = new SignupPage(Driver);
            Driver.FindElement(sp.form).Submit();
        }

        [Then(@"user will get '(.*)' success message")]
        public void ThenUserWillGetSuccessMessage(string message)
        {
            AccountCreatedPage acp = new AccountCreatedPage(Driver);
            Assert.True(ut.TextPresentinElement(message),"User did NOT get expected success message");
            ut.ClickonElement(acp.continueBtn);
        }

    }
}
