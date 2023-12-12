TODO:

If you are using an ApiKey supplied from the server add the following to your appsettings.json file in wwwroot:
```
{
  "ArcGISApiKey": "YourAPIKey"
} 
```
Otherwise, you can delete the appsettings.json file in wwwroot and remove the following line from the program.cs file
```
builder.Services.AddSingleton<IConfiguration>(_ => builder.Configuration);
```
