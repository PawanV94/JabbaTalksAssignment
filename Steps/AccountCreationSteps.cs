using FlightTest.Base;
using FlightTest.Extensions;
using FlightTest.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FlightTest.Steps
{
    [Binding]
    public class AccountCreationSteps: BaseStep
    {
        [Given(@"I navigate to ""(.*)"" signup page")]
        public void GivenINavigateToSignupPage(string p0)
        {
            NavigateSite(p0);
        }

        [When(@"I click on language dropdown")]
        public void WhenIClickOnLanguageDropdown()
        {
            CurrentPage = GetInstance<SignUp>();
            CurrentPage.As<SignUp>().DDlChooseLanguage.Click();
        }

        [Then(@"I verify available languages ""(.*)"" from the dropdown")]
        public void ThenIVerifyAvailableLanguagesFromTheDropdown(string p0)
        {
            CurrentPage.As<SignUp>().ValidateDDL(p0);
        }

        [When(@"I provide my full name ""(.*)""")]
        public void WhenIProvideMyFullName(string p0)
        {
            CurrentPage.As<SignUp>().InpFullName.SendKeys(p0);
        }

        [When(@"I provide my organization name ""(.*)""")]
        public void WhenIProvideMyOrganizationName(string p0)
        {
            CurrentPage.As<SignUp>().InpOrgName.SendKeys(p0);
        }

        [When(@"I provide my email ""(.*)""")]
        public void WhenIProvideMyEmail(string p0)
        {
            CurrentPage.As<SignUp>().InpEmail.SendKeys(p0);
        }

        [When(@"I agree to terms and conditons")]
        public void WhenIAgreeToTermsAndConditons()
        {
            CurrentPage.As<SignUp>().ChkTermsandConditions.Click();
        }

        [When(@"I click on get started button")]
        public void WhenIClickOnGetStartedButton()
        {
            CurrentPage.As<SignUp>().BtnGetStarted.ConditionalWait();
            CurrentPage.As<SignUp>().BtnGetStarted.Click();
        }

        [Then(@"I verify a welcome email has been sent message is displayed")]
        public void ThenIVerifyAWelcomeEmailHasBeenSentMessageIsDisplayed()
        {
            if (CurrentPage.As<SignUp>().TxtWelcomeEmail.Displayed)
                Console.Write("Welcome email is sent to user's email id");
            else
                Console.Write("Failed to validate the presence of welcome email message");
        }

    }
}
