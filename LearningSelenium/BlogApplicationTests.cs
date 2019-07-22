using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using UnitTestProject1;

namespace LearningSelenium
{
    [TestClass]
    public class BlogApplicationTests
    {
        [TestMethod]
        public void should_sign_up_to_blog_application()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Manage().Window.Maximize();

                driver.Navigate().GoToUrl("https://selenium-blog.herokuapp.com/signup");

                var timeStamp = UnixTime.ConvertToUnixTimestamp(DateTime.Now);

                var usernameField = driver.FindElementById(id: "user_username");
                usernameField.SendKeys($"user{timeStamp}");

                var emailField = driver.FindElementById(id: "user_email");
                emailField.SendKeys($"email{timeStamp}@test.com");

                var passwordField = driver.FindElementById(id: "user_password");
                passwordField.SendKeys("password");

                var submitButton = driver.FindElementById(id: "submit");
                submitButton.Click();

                var banner = driver.FindElementById(id: "flash_success");

                var bannerText = banner.Text;

                bannerText.Should().Be($"Welcome to the alpha blog user{timeStamp}");


            }
        }
    }
}
