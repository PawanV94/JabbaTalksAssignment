using FlightTest.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTest.Locators
{
    public class TempEmail: BasePage
    {
        [FindsBy(How = How.XPath, Using = "(.//a[text()='Sign in'])[1]")]
        public IWebElement BtnSignin { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@type='email']")]
        public IWebElement InpEmail { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@type='password']")]
        public IWebElement InpPassword { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@value='Next']")]
        public IWebElement BtnNext { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@type='submit']")]
        public IWebElement BtnSubmit { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search']")]
        public IWebElement InpSearchEmail { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='idBtn_Back']")]
        public IWebElement BtnNoSignedIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Other')]")]
        public IWebElement BtnOther { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@data-automationid='splitbuttonprimary'])[2]")]
        public IWebElement BtnSearchIcon { get; set; }

        public IWebElement EmailRow(string s)
        {
            return DriverContext.Driver.FindElement(By.XPath("//span[@title='"+s+"']"));
        }
    }


}
