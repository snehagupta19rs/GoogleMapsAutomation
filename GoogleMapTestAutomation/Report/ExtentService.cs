using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using GoogleMapTestAutomation.Utilities;

namespace GoogleMapTestAutomation.Report
{
    //This class contains the code to create the extent report
    public class ExtentService
    {
        public static ExtentReports extent;

        public static ExtentReports GetExtent()
        {
            if (extent == null)
            {
                extent = new ExtentReports();
                string reportDir = Path.Combine(GetProjectData.GetProjectRootDirectory(), "ExecutionReports");
                if(!Directory.Exists(reportDir))
                    Directory.CreateDirectory(reportDir);
                var reporter = new ExtentSparkReporter(reportDir+"/index.html");
                reporter.Config.DocumentTitle = "Google Maps Automation";
                reporter.Config.ReportName = "Execution Report";
                reporter.Config.Theme = Theme.Standard;
                extent.AttachReporter(reporter);
            }
            return extent;
        }

        
    }
}
