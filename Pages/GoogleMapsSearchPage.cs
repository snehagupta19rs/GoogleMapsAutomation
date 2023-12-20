using GoogleMapTestAutomation.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GoogleMapTestAutomation.Pages
{
    //This class contains all the webelements and related methods to interact with them on GoogleMapsSearchPage
    public class GoogleMapsSearchPage 
    {
            IWebDriver _driver;
            WaitHelper waitHelper;
            public GoogleMapsSearchPage(IWebDriver driver) 
            {
                _driver = driver;   
                PageFactory.InitElements(_driver, this);
            }

            [FindsBy(How = How.XPath, Using = "(//div[@class='Io6YTe fontBodyMedium kR99db '])[1]")] 
            public IWebElement addressTxt;

            [FindsBy(How = How.TagName, Using = "h1")]
            public IWebElement addressHeader;

            [FindsBy(How = How.CssSelector, Using = "div.Q2vNVc")]
            public IWebElement invalidAddressTxt;

        public string GetAddressFromSearchPage(int index)
            {
                waitHelper = new WaitHelper(_driver);
                waitHelper.WaitForAddressPageLoad(5, index);
                waitHelper.WaitForElementInSeconds(("(//div[@class='Io6YTe fontBodyMedium kR99db '])[1]"), 4);
                return addressTxt.Text;
            }

            public string GetCoordinates()
            {
                waitHelper = new WaitHelper(_driver);
                waitHelper.WaitForElementInSeconds("//h1", 3);
                waitHelper.WaitForStaticTime(3);
                string url = _driver.Url.ToString();
                string[] getCoordinateValues = url.Split('@')[1].Split(',');
                string coordinates = string.Concat(getCoordinateValues[0]+ ", " + getCoordinateValues[1]);
                return coordinates;
            }

            public string GetInvalidAddressText()
            {
                waitHelper = new WaitHelper (_driver);
                waitHelper.WaitForElementInSeconds(("//div[@class='Q2vNVc']"), 3);
                return invalidAddressTxt.Text;
            }

    }
}

