# NSS-Nordic-Suggestion-System
# Description
This is a WebApp that is created in partnership with Nordic Doors. The goal was to make a system where suggestions related to improving production was easier to outline and implement. 
Nordic Door Suggestion System makes it easier to submit, administrate and show statistical data related to suggestions. The application contains two different userprivilegies, which means that the regular employee and leaders have access to relevant tools related to their role.

The web- application is developed with use of C#, MVC, ASP.net Core, EntityFramework, JAVASCRIPT, HTML, CSS and MariaDB/SQL- langauge.
In the development we concluded with that it is easier to use Entity Framework and Migrations instead of a database containing physical tables. It makes it easier to implement the web- application because we dont have an underlying database with tables. The reason to why is because the Entity Framework enables developers to work with the database through .NET objects. That contributes to less code and a more efficient web- application. 

Notice
--
When running the file it is important that the mariaDB server is started, and is activly running in the background. There is also needed to be created a database named 'nssdb'. 

To start mariaDB server:
MacOS--
brew services start mariadb;

Windows--
services mariadb start;

## Running the project and installations
Step by step to run the web- application:
- Download some form of IDE(VisualStudio, VisualCode ect.).
- Check if the required NuGet- packages and frameworks is installed.
- Download mariaDB server and client.
- Start the mariaDB server.
- Create a database named 'nssdb'.

When all of the instructions above is completed, then open the IDE Terminal.
In the terminal you have to write the commands as follows;

Hot Reload
- dotnet build;
- dotnet watch;

or

For normal run, locate the startbutton in the toolbar and press it.

Then the program is running.

## Use of Web- application
The first page you will encounter when starting the web- application is the login page. 

User for initial user with administrative properties;

    - Username: Admin
    - Password: Root123
    
When you have logged in you will encounter the navigational page for the site. From this site you have the possibility to navigate to all pages, including the admin navigational menu.

