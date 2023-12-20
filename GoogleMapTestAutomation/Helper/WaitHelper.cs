using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace GoogleMapTestAutomation.Helper
{   
    //This class contains all the wrapper methods for wait
    public class WaitHelper
    {
        IWebDriver driver;
        public WaitHelper(IWebDriver _driver) 
        { 
            driver = _driver;
        }

        public void WaitForSeconds(int time)
        { 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        }

        public void WaitForMinutes(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(time);
        }

        public void WaitForElementInSeconds(string path, int time)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
        }

        public void WaitForAddressPageLoad(int time, int index)
        {
            ReadTestDataHelper readTestData = new ReadTestDataHelper();
            var expectedHeader = readTestData.GetExpectedAddressFromCsv(index);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.TagName("h1"),expectedHeader.Split(" ")[0]));
        }

        //Not recommended
        public void WaitForStaticTime(int time)
        {
            Thread.Sleep(time * 1000);
        }
    }
}
