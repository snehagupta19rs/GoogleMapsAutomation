using GoogleMapTestAutomation.Helper;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GoogleMapTestAutomation.Pages
{   
    //This class contains all the webelements and related methods to interact with them on GoogleMapsPage
     public class GoogleMapsPage 
     {

        IWebDriver _driver;
        WaitHelper waitHelper;
        public GoogleMapsPage(IWebDriver driver) 
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "searchboxinput")]
        public IWebElement txtBoxGoogleMap;

        [FindsBy(How = How.Id, Using = "searchbox-searchbutton")]
        public IWebElement searchButton;

        public void SearchAddressInGoogleMaps(string address)
        {
            waitHelper = new WaitHelper(_driver);
            waitHelper.WaitForElementInSeconds("//*[@id='searchboxinput']",1);
            if (txtBoxGoogleMap != null)
            {
                txtBoxGoogleMap.Clear();
                txtBoxGoogleMap.SendKeys(address);
            }

            waitHelper.WaitForElementInSeconds("//*[@id='searchbox-searchbutton']", 1);
            if (searchButton != null) 
            { 
                searchButton.Click();
            }
        }

    }
}
