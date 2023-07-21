# WeatherApp
A weather data fetching application with in-built geolocation using third party services.

# Description
The application first sends a request to a third party service, finding out your geographical coordinates and passes them through to another third party service, which returns the closest available weather information to the location.

# Features
* Retrieves the user IP adress and geographical coordinates.
* Retrieves the closest available weather data.
* Saves them to a database and a in-memory storage.
* Allows for retrieval of already queried data from in-memory storage if the query is made within an hour of the first one.

# Dependencies
.NET Core SDK installed

# Instructions
* Clone the repository.
```
git clone https://github.com/Pugijsons/WeatherApp.git
```
* Build the application, no API keys neccesary.
```
dotnet build
```
* Run the application. By default, it runs on http://localhost:5141/.
```
dotnet run
```

# Contributing
If you find a bug or have ideas for improvemement, feel free to open an issue or a pull request, or contact me on Discord @pugijs.

# Author
Developed by Harijs Pugačs.

# Screenshots
![image](https://github.com/Pugijsons/WeatherApp/assets/98178230/8e6bc390-9c18-4db1-95f9-d7d83c0688b7)
