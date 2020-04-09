using OpenQA.Selenium;

namespace PeekCloppenburg_tests
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        IWebElement loginEmail;
        IWebElement loginPassword;

        public void SignIn(string email, string password)
        {
            loginEmail = Driver.FindElement(By.Id("email-login"));
            loginPassword = Driver.FindElement(By.Id("password-login"));

            loginEmail.Click();
            loginEmail.SendKeys(email);
            loginPassword.Click();
            loginPassword.SendKeys(password + Keys.Enter);
        }
    }
}