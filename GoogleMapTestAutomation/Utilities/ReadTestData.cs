using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration.Attributes;

namespace GoogleMapTestAutomation.Utilities
{   
    //This class contains the methods related to test data csv operations
    public class ReadTestData
    {
        public List<AddressProperties> ReadCsvData()
        {
            using (var streamReader = new StreamReader(Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "TestData/AddressList.csv"))
            {
                using (var csvRecords = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    var records = csvRecords.GetRecords<AddressProperties>().ToList();
                    return records;
                }
            }
        }

        public class AddressProperties
        {
            [Name("address")]
            public string Address { get; set; }

            [Name("coordinates")]
            public string Coordinates { get; set; }
        }
    }
}
    

