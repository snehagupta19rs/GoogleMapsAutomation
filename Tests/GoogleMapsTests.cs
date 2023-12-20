using GoogleMapTestAutomation.Assertions;
using GoogleMapTestAutomation.Helper;
using GoogleMapTestAutomation.Utilities;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using GoogleMapTestAutomation.Report;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports;
using static GoogleMapTestAutomation.Utilities.ReadTestData;

namespace GoogleMapTestAutomation.Tests
{
    public class GoogleMapsTests
    {
        private IWebDriver driver;
        private DriverBase _driver;
        ConfigSettings config;
        string configSettingPath = Directory.GetParent(@"../../../").FullName +
            Path.DirectorySeparatorChar + "Configurations/configSettings.json";

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            _driver = new DriverBase();
            ExtentTestManager.CreateParentTest(GetType().Name);
        }

        [SetUp]
        public void Setup()
        {
            ExtentTestManager.CreateTest(TestContext.CurrentContext.Test.Name);
            config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingPath);
            IConfigurationRoot configurationRoot = builder.Build();
            configurationRoot.Bind(config);
            driver = _driver.Initiate(config.BrowserType);
            _driver.OpenPage(driver, config.BaseUrl);
            Thread.Sleep(2000);
        }

        [Test]
        public void ValidateSingleAddressSearchInGoogleMap()
        {
            GoogleMapsHelper googleMapsHelper = new GoogleMapsHelper(driver);
            ValidateSearch validateSearch = new ValidateSearch();
            ReadTestDataHelper readTestDataHelper = new ReadTestDataHelper();

            googleMapsHelper.SearchAddressInGoogleMaps(0);

            var actualAddress = googleMapsHelper.GetAddressOfMarkedLocation(0);
            var actualCoordinates = googleMapsHelper.GetCoordinatesOfMarkedLocation();
            var expectedCoordinates = readTestDataHelper.GetExpectedCoordinatesFromCsv(0);
            var expectedAddress = readTestDataHelper.GetExpectedAddressFromCsv(0);

            Assert.IsTrue(validateSearch.ValidateCoordinates(expectedCoordinates, actualCoordinates), $"The actual coordinates '{actualCoordinates}' doesn't match with expected '{expectedCoordinates}'");
            ReportLog.Pass($"Expected coordinates '{expectedCoordinates}' matches the actual coordinates '{actualCoordinates}'");
            
            Assert.IsTrue(validateSearch.ValidateAddress(expectedAddress, actualAddress), $"The actual address {actualAddress} doesn't match with expected '{expectedAddress}'");
            ReportLog.Pass($"Expected address '{expectedAddress}' matches the actual address '{actualAddress}'");
        }

        [Test]
        public void ValidateMultipleAddressSearchInGoogleMap()
        {
            GoogleMapsHelper googleMapsHelper = new GoogleMapsHelper(driver);
            ValidateSearch validateSearch = new ValidateSearch();
            ReadTestDataHelper readTestDataHelper = new ReadTestDataHelper();
            int addressCount = 4;

            List<AddressProperties> actualAddresses = googleMapsHelper.SearchMultipleAddressInGoogle(addressCount);
            List<AddressProperties> expectedAddresses = readTestDataHelper.GetExpectedAddresses(addressCount);

            Assert.IsTrue(validateSearch.ValidateAddressList(expectedAddresses, actualAddresses), "The actual address list doesn't match with expected address list");
            ReportLog.Pass($"Expected addresses and coordinates matches the actual addresses and coordinates");
        }

        [Test]
        public void ValidateMessageForInvalidAddressInGoogleMap()
        {
            GoogleMapsHelper googleMapsHelper = new GoogleMapsHelper(driver);
            ValidateSearch validateSearch = new ValidateSearch();

            googleMapsHelper.SearchAddressInGoogleMaps(4);
            
            var actualInvalidAddressMessage = googleMapsHelper.GetInvalidAddressMessage();

            Assert.IsTrue(validateSearch.ValidateMessage(actualInvalidAddressMessage,"can't find" ), $"The message '{actualInvalidAddressMessage}' for invalid address search is not correct");
            ReportLog.Pass($"Invalid address message is validated");
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;
                var errorMessage = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                        ? ""
                        : string.Format("<pre>{0}<pre>", TestContext.CurrentContext.Result.Message);

                var stackStrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                        ? ""
                        : string.Format("<pre>{0}<pre>", TestContext.CurrentContext.Result.StackTrace);


                switch (status)
                {
                    case TestStatus.Failed:
                        ReportLog.Fail("Test Failed");
                        ReportLog.Fail(errorMessage);
                        ReportLog.Fail(stackStrace);
                        ReportLog.Fail("Screenshot", CaptureScreenshot(TestContext.CurrentContext.Test.Name));
                        break;

                    case TestStatus.Passed:
                        ReportLog.Pass("Test Passed");
                        break;

                    case TestStatus.Skipped:
                        ReportLog.Skip("Test Skipped");
                        break;

                    default:
                        break;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e);
            }

            finally
            {
                driver.Quit();
                driver.Dispose();
            }
        }

        [OneTimeTearDown]
        public void GlobalTearDown()
        {
            ExtentService.GetExtent().Flush();
        }

        public Media CaptureScreenshot(string name) 
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }
    }
}
