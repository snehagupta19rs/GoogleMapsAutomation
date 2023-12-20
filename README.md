**GoogleMapsAutomation**

**ABOUT THE PROJECT**

This is a test automation project for GoogleMaps.This is NUnit test framework created in Selenium and C#. It uses Page Object Model design pattern.

**PROJECT FOLDER TREE STRUCTURE**

GoogleMapTestAutomation
        Assertions
                ValidateSearch.cs 	--contains class having methods for expected and actual results validation  
        
        Configurations
        	configSettings.json      --contains json to store data like browser name, base url etc.
        
        Drivers 
                DriverBase.cs		--contains base code for driver and browser initialization
                
        ExecutionReports        
               index.html		--auto generated folder with execution report after test execution
               
        Helper                   
                GoogleMapsHelper.cs
              	ReadTestDataHelper.cs
              	WaitHelper.cs		--contains classes with helper methods to create workflows
               
        Pages
        	GoogleMapsPage.cs
           	GoogleMapsSearchPage.cs	--contains page objects and related interaction methods
            
        Report 
        	ExtentService.cs
               	ExtentTestManager.cs
               	ReportLog.cs		--contains classes for extent report generation
        TestData
        	AddressList.csv		--contains csv for test data
      
        Tests
                GoogleMapsTests.cs       --contains test class with Nunit style test cases
        Utilities   
        	ConfigSettings.cs	--contains classes for managing test data from appsettings.json
        	GetProjectData.cs
        	ReadTestData.cs	       	

**GETTING STARTED**

This project is build in VisualStudio 2022 Community addition.

Clone this project and run below command at cloned location to build the project.
**dotnet build GoogleMapTestAutomation.csproj **

Execute below command to execute the tests
**dotnet test GoogleMapTestAutomation.csproj -e browserName=chrome**
