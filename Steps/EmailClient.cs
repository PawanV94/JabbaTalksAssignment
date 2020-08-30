using FlightTest.Base;
using FlightTest.Extensions;
using FlightTest.Locators;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FlightTest.Steps
{
    [Binding]
    public class EmailClient: BaseStep
    {
        [Given(@"I navigate to ""(.*)"" email client")]
        public void GivenINavigateToEmailClient(string p0)
        {
            NavigateSite(p0);
        }

        [Given(@"I login as ""(.*)"" to email client")]
        public void GivenILoginAsToEmailClient(string p0)
        {
            CurrentPage.As<TempEmail>().BtnSignin.Click();
            CurrentPage.As<TempEmail>().InpEmail.ConditionalWait();
            CurrentPage.As<TempEmail>().InpEmail.SendKeys(p0);
            CurrentPage.As<TempEmail>().BtnNext.Click();
            CurrentPage.As<TempEmail>().InpPassword.ConditionalWait();
            CurrentPage.As<TempEmail>().InpPassword.SendKeys("Cucumber@123");
            CurrentPage.As<TempEmail>().BtnSubmit.Click();
            CurrentPage.As<TempEmail>().BtnNoSignedIn.ConditionalWait();
            CurrentPage.As<TempEmail>().BtnNoSignedIn.Click();
        }

        [Then(@"I verify welcome email from jabba talks email address ""(.*)""")]
        public void ThenIVerifyWelcomeEmailFromJabbaTalksEmailAddress(string p0)
        {
            CurrentPage.As<TempEmail>().InpSearchEmail.ConditionalWait();
            if (CurrentPage.As<TempEmail>().InpSearchEmail.Displayed)
                Console.Write("email client inbox page is displayed");
            else
                Console.Write("failed to login or element not found");

            CurrentPage.As<TempEmail>().InpSearchEmail.SendKeys(p0);
            CurrentPage.As<TempEmail>().BtnSearchIcon.Click();
            CurrentPage.As<TempEmail>().EmailRow(p0).ConditionalWait();
            if (CurrentPage.As<TempEmail>().EmailRow(p0).Displayed)
                Console.Write("Welcome email is received");
            else
                Console.Write("Failed to verify the presence of welcome email");
        }


    }
}
