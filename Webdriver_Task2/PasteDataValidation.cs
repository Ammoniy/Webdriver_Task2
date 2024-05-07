using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pasteabin;

namespace Webdriver_Task2
{
    public class Tests
    {

        #region data

        IWebDriver driver;
        readonly string paste = @"git config --global user.name  ""New Sheriff in Town""
git reset $(git commit-tree HEAD^{tree} -m ""Legacy code"")
git push origin master --force";
        readonly string title = "how to gain dominance among developers";
        readonly string format = "Bash";
        readonly string expiration = "10 Minutes";

        #endregion


        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            HomePage hp = new HomePage(driver);
            driver.Url = "https://pastebin.com";
            hp.Paste(paste_text: paste,
            format_text: format,
            exp_text: expiration,
            title_text: title);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        

        [Test]
        public void Paste_Creation_Validate_Title_Test()
        {
            string actualPaste = driver.FindElement(By.ClassName("info-top")).Text;
            Assert.AreEqual(title, actualPaste);
        }

        [Test]
        public void Paste_Creation_Validate_Paste_Test()
        {
            string actualPaste = driver.FindElement(By.ClassName("bash")).Text;
            Assert.AreEqual(paste, actualPaste);
        }

        [Test]
        public void Paste_Creation_Validate_Format_Test()
        {
            string actualPaste = driver.FindElement(By.ClassName("left")).Text;
            Assert.IsTrue(actualPaste.Contains(format));
        }


        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}