using OpenQA.Selenium;

namespace PeekCloppenburg_tests
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        public void SignIn()
        {
            var loginEmail = Driver.FindElement(By.Id("email-login"));
            var loginPassword = Driver.FindElement(By.Id("password-login"));

            loginEmail.Click();
            loginEmail.SendKeys("test@gmail.com");
            loginPassword.Click();
            loginPassword.SendKeys("123456789" + Keys.Enter);
        }
    }
}