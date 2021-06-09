using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;

namespace CivicRecBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://sandbox-secure.rec1.com/account/login");
            try 
            { 
                IWebElement email = driver.FindElement(By.Id("login-username"));
                email.SendKeys("john.velasco@cityofmhk.com");

                driver.FindElement(By.ClassName("login-continue")).Click();

                Thread.Sleep(1000);
                IWebElement password = driver.FindElement(By.Id("login-password"));
                password.SendKeys("dog");
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Quit();
                Environment.Exit(0);
                Thread.Sleep(5000);
                throw new Exception("" + e);
            }
            Thread.Sleep(3000);
            driver.Close();
            driver.Quit();
            Environment.Exit(0);
        }
    }
}
