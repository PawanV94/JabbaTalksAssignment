using FlightTest.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FlightTest.Extensions
{
    public static class Waits
    {
        /// <summary>
        /// Waits for the webelement to be clickable and ignores exceptions
        /// </summary>
        ///
        public static void ConditionalWait(this IWebElement element)
        {
            try
            {
                DefaultWait<IWebDriver> ConditionalWait = new DefaultWait<IWebDriver>(DriverContext.Driver);
                ConditionalWait.Timeout = TimeSpan.FromSeconds(10);
                ConditionalWait.PollingInterval = TimeSpan.FromMilliseconds(250);
                ConditionalWait.IgnoreExceptionTypes(typeof(TargetInvocationException));
                ConditionalWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                ConditionalWait.IgnoreExceptionTypes(typeof(InvalidOperationException));
                element = ConditionalWait.Until(ExpectedConditions.ElementToBeClickable(element));
            }

            catch (Exception e)
            {
                Console.Write("Error: " + e.ToString());
            }
        }

    }
}
