-- Prerequisites

* .NET Core 3.1 (https://dotnet.microsoft.com/download/dotnet-core/3.1)
* Telerik (https://www.telerik.com/products/aspnet-ajax/download.aspx--.aspx)

-- Configuration
- You have to run the you must run the database script DBScript.sql, that will create the Database, the tables and insert the Person Types registries. 
- Open the solution (CodeTestSGCISSolution.sln) in Visual Studio 2019, open the Nuget Package Manager, then you have to check if you have a Package Source with the name nuget.telerik.com, if you dont have It, yo have to clic in the settings button, after that clic in the button with the plus icon and change the Name and the Source with the next information:
	Name: nuget.telerik.com
	Source: https://nuget.telerik.com/nuget
 You will be requested with the credentials that you use to login in the Telerik web page.
- If you have assigned a Commercial Telerik license you have to Uninstall the package Telerick.UI.for.AspNet.Core.Trial from the project CodeTestSGCIS.WebTelerik and then install the Package Telerick.UI.for.AspNet.Core
- You need to open the appsettings.json in the CodeTestSGCIS.Api Project, then you should change the connection string to connect to yur database.
- You should run the CodeTestSGCIS.Api Project and copy the URL API, where it is runing.
- You need to open the appsettings.json in the CodeTestSGCIS.WebTelerik Project, then you should change Api Url with the information of the previous step.
- You should run the CodeTestSGCIS.WebTelerik