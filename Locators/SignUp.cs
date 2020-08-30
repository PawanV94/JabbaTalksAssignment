using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightTest.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace FlightTest.Locators
{
    class SignUp: BasePage
    {
        [FindsBy(How = How.XPath, Using = "//input[@id='name']")]
        public  IWebElement InpFullName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='orgName']")]
        public IWebElement InpOrgName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='singUpEmail']")]
        public IWebElement InpEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@class='ui-checkbox']/child::span[contains(text(),'I agree to the')]")]
        public IWebElement ChkTermsandConditions { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group custom-form-group']/child::button[contains(@type, 'submit')]")]
        public IWebElement BtnGetStarted { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@placeholder='Choose Language']//span[@class='btn btn-default form-control ui-select-toggle']")]
        public IWebElement DDlChooseLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@role='option']")]
        public IList<IWebElement> DDlLanguages { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='alert alert-danger alert-custom']/child::span")]
        public IWebElement TxtWelcomeEmail { get; set; }

        public void ValidateDDL(string s)
        {
            string[] options = s.Split('|');

            foreach(IWebElement element in DDlLanguages)
            {
                for (int i=0; i < options.Length; i++)
                {
                    if(element.Text.Equals(options[i]))
                    {
                        Console.Write("Dropdown value " + options[i] + " exists");
                    }
                }
            }
        }
    }

   
}
