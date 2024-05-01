using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;

namespace Pasteabin
{
    public class HomePage
    {
        private readonly IWebDriver driver;


        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void Paste(string paste_text, string format_text, string exp_text, string title_text)
        {
            // click on paste button
            driver.FindElement(By.XPath("//A[@class='header__btn']")).Click();
            // fill paste field
            driver.FindElement(By.XPath("//TEXTAREA[@id='postform-text']")).SendKeys(paste_text);
            // scroll
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0,700)");
            
            // chose formating
            var format_dropdown = driver.FindElement(By.XPath("//*[contains(@class, 'field-postform-format')]//span"));
            format_dropdown.Click();
            var format_dropdownOption = driver.FindElements(By.XPath("//li[@class='select2-results__option']"));
            format_dropdownOption.FirstOrDefault(x => x.Text.Equals(format_text)).Click();


            // chose expiration from dropdown
            var exp_dropdown = driver.FindElement(By.XPath("//*[contains(@class, 'field-postform-expiration')]//span"));
            exp_dropdown.Click();
            var exp_dropdownOption = driver.FindElements(By.XPath("//li[@class='select2-results__option']"));
            exp_dropdownOption.FirstOrDefault(x => x.Text.Equals(exp_text)).Click();
            
            // fill Paste Name / Title
            driver.FindElement(By.XPath("//INPUT[@id='postform-name']")).SendKeys(title_text);
            
            // create new paste
            driver.FindElement(By.XPath("//BUTTON[@type='submit'][text()='Create New Paste']")).Click();

        }
    }
}
