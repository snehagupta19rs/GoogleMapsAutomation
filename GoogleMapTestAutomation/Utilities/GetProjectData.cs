using System;

namespace GoogleMapTestAutomation.Utilities
{
    //This class contains the methods to fetch and process the project data
    public class GetProjectData
    {
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
}
}
