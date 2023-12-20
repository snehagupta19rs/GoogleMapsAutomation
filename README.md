**GoogleMapsAutomation**

**ABOUT THE PROJECT**

This is a test automation project for GoogleMaps.This is NUnit test framework created in Selenium and C#. It uses Page Object Model design pattern.

**PROJECT FOLDER TREE STRUCTURE**

GoogleMapTestAutomation
¦   
+---Assertions
¦       ValidateSearch.cs 	--contains class having methods for expected and actual results validation   
¦                   
+---Configurations          --contains json to store data like browser name, base url etc.
¦       configSettings.json
¦       
+---Drivers                 --contains base code for driver and browser initialization
¦       DriverBase.cs
¦       
+---ExecutionReports        --auto generated folder with execution report after test execution
¦       index.html
¦       
+---Helper                   --contains classes with helper methods to create workflows
¦       GoogleMapsHelper.cs
¦       ReadTestDataHelper.cs
¦       WaitHelper.cs
¦       
+---Pages		                 --contains page objects and related interaction methods	
¦       GoogleMapsPage.cs
¦       GoogleMapsSearchPage.cs
¦       
+---Report                    --contains classes for extent report generation
¦       ExtentService.cs
¦       ExtentTestManager.cs
¦       ReportLog.cs
¦       
+---TestData                   --contains csv for test data
¦       AddressList.csv
¦       
+---Tests			                 --contains test class with Nunit style test cases
¦       GoogleMapsTests.cs
¦       
+---Utilities                  --contains classes for managing test data from appsettings.json;
        ConfigSettings.cs
        GetProjectData.cs
        ReadTestData.cs

**GETTING STARTED**

This project is build in VisualStudio 2022 Community addition.

Clone this project and run below command at cloned location to build the project.
**dotnet build GoogleMapTestAutomation.csproj **

Execute below command to execute the tests
**dotnet test GoogleMapTestAutomation.csproj -e browserName=chrome**
