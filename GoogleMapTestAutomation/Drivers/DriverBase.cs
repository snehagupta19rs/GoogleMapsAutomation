using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using GoogleMapTestAutomation.Report;

public class DriverBase
{
    private IWebDriver driver;

    //Initialises and initiate the browse
    public IWebDriver Initiate(string browser)
    {
        switch (browser.ToLowerInvariant())
        {
            case "chrome":
                var chromeOptions = new ChromeOptions();
                //chromeOptions.AddArguments("--headless");
                chromeOptions.AddArguments("--whitelisted-ips=''");
                driver = new ChromeDriver(chromeOptions);
                MaximizeBrowser(driver);
                WaitForDefinedTime(driver, TimeSpan.FromSeconds(5));
                ReportLog.Pass("Chrome initialized successfully");
                break;
            
            case "firefox":
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(Directory.GetCurrentDirectory(), "geckodriver.exe");
                service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
                driver = new FirefoxDriver(service);
                MaximizeBrowser(driver);
                WaitForDefinedTime(driver, TimeSpan.FromSeconds(5));
                ReportLog.Pass("Firefox initialized successfully");
                break;
            
            case "edge":
                driver = new EdgeDriver();
                ReportLog.Pass("Edge initialized successfully");
                break;

            default:
                throw new ArgumentException($"Browser is not valid{browser}");
        }

        return driver;
    }

    //Maximize browser window
    private void MaximizeBrowser(IWebDriver driver)
    { 
        driver.Manage().Window.Maximize();
    }

    //Implicit wait
    public void WaitForDefinedTime(IWebDriver driver,TimeSpan timeout) 
    { 
        driver.Manage().Timeouts().ImplicitWait = timeout;
    }

    //Launch URL
    public void OpenPage(IWebDriver driver,string url)
    {
        driver.Navigate().GoToUrl(url);
    }
}

    
