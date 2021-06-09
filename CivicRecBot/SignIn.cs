using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivicRecBot
{
    public class SignIn 
    {
        public void Entry(IWebDriver driver)
        {
            driver.FindElement(By.Id("login-username"));
        }
    }
}
