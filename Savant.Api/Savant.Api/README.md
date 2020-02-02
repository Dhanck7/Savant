## Run

### Run Locally

Install the .NET Core 3.1.1 Hosting bundle 
https://dotnet.microsoft.com/download/dotnet-core/thank-you/runtime-aspnetcore-3.1.1-windows-hosting-bundle-installer


``` cmd
dotnet restore
dotnet run -c Release
```

### Run with Docker 

Assuming everyone knows how to google.

You'll need to enable hyper-v and install the docker desktop tools for windows.

There's a dockerfile in the project, build the image and run the container.

## Developing 

Install the latest .NET core '3.1.*' SDK 

https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.101-windows-x86-installer

You'll need either Visual Studio 2019 or Visual Studio code 

### Database 

Todo.... 

Currently the api is configured for SQL server with database name Savant.Db (Windows auth)

See appsettings.json for the connection string 

