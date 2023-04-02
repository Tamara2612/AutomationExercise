using System;
using AutomationExercise.Helpers;
using AutomationExercise.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationExercise.Steps
{
    [Binding]
    public class ContactUsSteps : Base      
    {
        Utilities ut = new Utilities(Driver);
        HeaderPage hp = new HeaderPage(Driver);
   
        [Given(@"user opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            ut.ClickonElement(hp.contactLink);
        }
        
        [When(@"user enters all required fields")]
        public void WhenUserEntersAllRequiredFields()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.EnterTextinElement(cup.name, TestConstants.FirstName + " " + TestConstants.LastName);
            ut.EnterTextinElement(cup.email, TestConstants.Username);
            ut.EnterTextinElement(cup.subject, TestConstants.Subject);
            ut.EnterTextinElement(cup.message, TestConstants.Message);
        }
        
        [When(@"submits contact us form")]
        public void WhenSubmitsContactUsForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            //ut.ClickonElement(cup.submit);
            Driver.FindElement(cup.form).Submit();
        }
        
        [When(@"confirms the prompt message")]
        public void WhenConfirmsThePromptMessage()
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.Accept();
        }
        
        [Then(@"user will receive '(.*)' message")]
        public void ThenUserWillReceiveYourDetailsHaveBeenSubmittedSuccessfully_Message(string successMessage)
        {
            Assert.True(ut.TextPresentinElement(successMessage), "User's message was NOT succesfully sent via contact us form ");
            
        }
    }
}
