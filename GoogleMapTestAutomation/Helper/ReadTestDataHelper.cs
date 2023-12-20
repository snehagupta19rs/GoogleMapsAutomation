using GoogleMapTestAutomation.Utilities;
using static GoogleMapTestAutomation.Utilities.ReadTestData;

namespace GoogleMapTestAutomation.Helper
{   //This class contains all the methods required to read test data from csv files under TestData folder.
    public class ReadTestDataHelper
    {
        ReadTestData? readTestData;
        public string GetExpectedCoordinatesFromCsv(int index)
        {
            readTestData = new ReadTestData();
            return readTestData.ReadCsvData().ElementAt(index).Coordinates;
        }

        public string GetExpectedAddressFromCsv(int index)
        {
            readTestData = new ReadTestData();
            return readTestData.ReadCsvData().ElementAt(index).Address;
        }

        public List<AddressProperties> GetExpectedAddresses(int count)
        { 
            List<AddressProperties> addresses = new List<AddressProperties>();
            
            for (int i = 0; i < count; i++) 
            {
                AddressProperties address = new AddressProperties();
                address.Address = GetExpectedAddressFromCsv(i);
                address.Coordinates = GetExpectedCoordinatesFromCsv(i);
                addresses.Add(address);
            }
            return addresses;
        }

    }
}
