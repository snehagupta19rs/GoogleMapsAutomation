﻿using AventStack.ExtentReports;
using System.Runtime.CompilerServices;

namespace GoogleMapTestAutomation.Report
{
    //This class contains the code to create parent test and child test nodes in extent report
    public class ExtentTestManager
    {
        [ThreadStatic]
        private static ExtentTest parentTest;

        [ThreadStatic]
        private static ExtentTest childTest;

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateParentTest(string testName, string description = null)
        { 
            parentTest = ExtentService.GetExtent().CreateTest(testName, description);
            return parentTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest CreateTest(string testName, string description = null)
        { 
            childTest = parentTest.CreateNode(testName, description);
            return childTest;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ExtentTest GetTest()
        { 
            return childTest;
        }
    }
}
