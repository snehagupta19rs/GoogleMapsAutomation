using System.Collections.Generic;
using static GoogleMapTestAutomation.Utilities.ReadTestData;

namespace GoogleMapTestAutomation.Assertions
{
    //This class contains all the methods for comparision of expected and actual result from GoogleMapsTests class
    public class ValidateSearch
    {
        //Compares the expected and actual coordinates
        //Returns true if both matches else returns false
        public bool ValidateCoordinates(string expectedCoordinates, string actualCoordinates)
        {
            return (expectedCoordinates.Equals(actualCoordinates));
        }

        //Compares the expected and actual address
        //Returns true if both matches else returns false
        public bool ValidateAddress(string expectedAddress, string actualAddress)
        { 
            return expectedAddress.Contains(actualAddress);
        }

        //Compares the actual address and coordinate list with the expected list
        //Returns true if both matches else returns false
        public bool ValidateAddressList(List<AddressProperties> expectedAddresses, List<AddressProperties> actualAddresses)
        {
            string[] expectedAddressList = GetAddresses(expectedAddresses).ToArray();
            string[] actualAddressList = GetAddresses(actualAddresses).ToArray();
            string[] expectedCoordinatesList = GetCoordinates(expectedAddresses).ToArray();
            string[] actualCoordinatesList = GetCoordinates(actualAddresses).ToArray();
            bool value = true;
            for (int index = 0; index < expectedAddresses.Count; index++)
            {
               value = (expectedAddressList[index].Contains(actualAddressList[index])) &&
                    (expectedCoordinatesList[index] == actualCoordinatesList[index]);
            }
            return value;
        }

        public bool ValidateMessage(string expectedMessage, string actualMessage)
        {
            return expectedMessage.Contains(actualMessage);
        }

        private List<string> GetAddresses(List<AddressProperties> address)
        {
            List<string> values = new List<string>();
            foreach (var element in address)
            {
                values.Add(element.Address);   
            }
            return values;
        }

        private List<string> GetCoordinates(List<AddressProperties> address)
        {
            List<string> values = new List<string>();
            foreach (var element in address)
            {
                values.Add(element.Coordinates);
            }
            return values;
        }
    }
}
