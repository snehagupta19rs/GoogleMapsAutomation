using GoogleMapTestAutomation.Pages;
using GoogleMapTestAutomation.Report;
using OpenQA.Selenium;
using static GoogleMapTestAutomation.Utilities.ReadTestData;

namespace GoogleMapTestAutomation.Helper
{
    //This class contains all the the helper methods required to perform actions on the Pages.
    public class GoogleMapsHelper
    {
        private IWebDriver driver;
        ReadTestDataHelper readTestData;
        GoogleMapsSearchPage googleMapsSearchPage;
        public GoogleMapsHelper(IWebDriver _driver) 
        {
            driver = _driver;
        }
        //Search the given address from test data csv in google maps. 
        public void SearchAddressInGoogleMaps(int index)
        {
            GoogleMapsPage googleMapsPage = new GoogleMapsPage(driver);
            readTestData = new ReadTestDataHelper();
            var address = readTestData.GetExpectedAddressFromCsv(index);
            googleMapsPage.SearchAddressInGoogleMaps(address);
            ReportLog.Pass($"Address {address} searched on google maps");
        }

        //Fetch the coordinates from searched location page on google maps.
        public string GetCoordinatesOfMarkedLocation()
        {
            googleMapsSearchPage = new GoogleMapsSearchPage(driver);
            var coordinates = googleMapsSearchPage.GetCoordinates();
            ReportLog.Pass($"Coordinates {coordinates} fetched");
            return coordinates;
        }

        //Fetch the address from searched location page on google maps
        public string GetAddressOfMarkedLocation(int index) 
        {
            googleMapsSearchPage = new GoogleMapsSearchPage(driver);
            var addressText = googleMapsSearchPage.GetAddressFromSearchPage(index);
            ReportLog.Pass($"Address {addressText} fetched");
            return addressText;
        }

        //Search multiple addresses and coordinates
        public List<AddressProperties> SearchMultipleAddressInGoogle(int addressCount)
        {
            List<AddressProperties> addresses = new List<AddressProperties>();
            for(int index = 0; index < addressCount; index++) 
            {
                AddressProperties address = new AddressProperties();
                SearchAddressInGoogleMaps(index);
                address.Address = GetAddressOfMarkedLocation(index); 
                address.Coordinates = GetCoordinatesOfMarkedLocation();
                addresses.Add(address);
            }
            return  addresses;
        }

        public string GetInvalidAddressMessage()
        {
            googleMapsSearchPage = new GoogleMapsSearchPage(driver);
            string message = googleMapsSearchPage.GetInvalidAddressText();
            return message;
        }
    }


}

    

