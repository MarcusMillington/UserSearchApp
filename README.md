# User Search App

This is an app with a search box. After 2 characters are entered an api will be called to lookup a list people with either a firstname or lastname that starts with the search text entered. The names of the matched people will be displayed below the search box. Any of the matched people can be selected and their full details will be added to the screen.

New people can be added to the system. To do this, click the 'New User +' button, to display the create user form. Fill in all the details and click 'Create'. The newly created user will now be available in the search.


## How It's Made

Tech used : React, .NET Core API, SQL Server Database


## To Run

### Clone
Clone the repo using Visual Studio

### Setup the database
The db schema is defined in project 'Database'. This schema can be published to a local SQL Server instance by:
- Create a db on your local server called 'UserSearch'
- Right click on the project and selecting ‘publish’
- The API should now connect to the db, but if the connection string needs to be updated it is located in API / appsettings.json under ConnectionString / ConnectionString

### Run the api

To Run the API in Visual Studio:
- right click on the 'API' project, select 'Set as Startup Project'
- Click run

### Run the app
- open a cmd line prompt
- navigate to the user search app project folder UserSearchApp\usersearchapp
- type npm install
- type npm run dev
