using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using System.Threading;
using System.IO;


namespace CivicRecBot
{
    public class CivicRecBot
    {
        public static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://sandbox-secure.rec1.com/account/login");
            try 
            {
                CivicRecBot bot = new CivicRecBot();
                string[] signIn = bot.SignInInformation();


                IWebElement email = driver.FindElement(By.Id("login-username"));
                email.SendKeys(signIn[0]);
                //email.SendKeys("john.velasco@cityofmhk.com"); //could change for a variable, or user input in personal window

                driver.FindElement(By.ClassName("login-continue")).Click();

                Thread.Sleep(1000);
                IWebElement password = driver.FindElement(By.Id("login-password"));
                password.SendKeys(signIn[1]);
                //password.SendKeys("dog"); //could change for a variable, or user input in personal window
            }
            catch (Exception e)
            {
                driver.Close();
                driver.Quit();
                Environment.Exit(0);
                Thread.Sleep(5000);
                throw new Exception("" + e);
            }
            Thread.Sleep(10000);
            driver.Close();
            driver.Quit();
            Environment.Exit(0);
        }

        public string[] SignInInformation()
        {
            try
            {
                string [] signIn = new string[2]; 
                using (StreamReader sr = new StreamReader("C:/Users/johnv/source/personal project repos/CivicRecBot/CivicRecBot/Data/login.txt"))
                {
                    string username = sr.ReadLine().Trim();
                    signIn[0] = username;
                    string password = sr.ReadLine().Trim();
                    signIn[1] = password; 
                    return signIn;
                }
            }
            catch (Exception e)
            {
                throw new Exception("\n\nFile could not be read - " + e);
            }
        }



    }
}
