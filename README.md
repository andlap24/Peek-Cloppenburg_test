## Description
Stack: C#, .NetCore, Selenium WebDriver.

`NuGet` packages I'm using:

- [Selenium.WebDriver][nuget-selenium-webdriver]
- [Selenium.WebDriver.ChromeDriver][nuget-selenium-chromedriver]
- `Chrome` needs to be installed*

#### Clone the git repo
```
$ git clone git@github.com:andlap24/Peek-Cloppenburg_test.git
```

#### Install Visual Studio and .NET Core

- (1) [Install Visual Studio](https://www.visualstudio.com/en-us/visual-studio-homepage-vs.aspx)
- (2) [.NET Core](https://www.microsoft.com/net/download/core)
- (3) Start Visual Studio.
- (4) On the menu bar, choose File, Open, Project/Solution.  
      Navigate to the csharp.webdriver project folder and open it

#### Install NUnit Templates for Visual Studio 
-  Go to Tools > Extensions and Update
-  Select > Online
-  Search for "[NUnit Templates for Visual Studio](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnitTemplatesforVisualStudio)"

#### Install Nuget package
-  Right-click on your project and click “Manage NuGet Packages”.
-  Search for "Microsoft.Extensions.Configuration.UserSecrets" and install it
-  Search for "System.Diagnostics.Contracts" and install it
-  Search for "[NUnit](https://www.nuget.org/packages/NUnit/)" Framework and install it

#### Install Selenium
Currently, there is no official support for .NET Core, But there is a Nuget package which provides .NET Core support for those of us who can’t wait, please visit [CoreCompat.Selenium.WebDriver](https://www.nuget.org/packages/CoreCompat.Selenium.WebDriver/2.54.0-beta002)  to learn more about it.
