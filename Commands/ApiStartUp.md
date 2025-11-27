Inside Desired Directory Create SLN
    dotnet new sln -n SlnNameHere

Create THe API Project in its own Folder 
    dotnet new webapi -n ProjectNameHere.API -o FolderNameHere

Add the APi Project to the SLN 
    dotnet sln add ProjectNameHere.api/ProjectNameHere.Api.Csproj

Add WeatherForecast Controller for Tests 
    dotnet new controller -n WeatherForecastController -o ProjectNameHere.Api/Controllers

Run Local Test
    dotnet run --project ApiTestRecall.Api

Swagger will live at 
    http://localhost:5000/swagger