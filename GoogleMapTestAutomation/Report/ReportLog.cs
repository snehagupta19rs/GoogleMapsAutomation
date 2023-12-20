using AventStack.ExtentReports.Model;

namespace GoogleMapTestAutomation.Report
{
    //This class contains the code to log the messages at different steps in extent report
    public class ReportLog
    {
        public static void Pass(string message)
        {   
            ExtentTestManager.GetTest().Pass(message);
        }

        public static void Fail(string message, Media media = null) 
        {
            ExtentTestManager.GetTest().Fail(message, media);
        }

        public static void Skip(string message)
        {
            ExtentTestManager.GetTest().Skip(message);
        }
    }
}
