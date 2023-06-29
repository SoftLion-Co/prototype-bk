

# SoftLion-Back
This is a Back-end part of our SoftLion project.
Front-end part: 

## Table of Contents 

- [SoftLion-Back](#softlion-back)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
    - [Required to install](#required-to-install)
    - [Clone](#clone)
    - [Setup](#setup)
    - [How to run local](#how-to-run-local)
  - [Usage](#usage)
    - [How to work with swagger UI](#how-to-work-with-swagger-ui)
    - [How to work without swagger UI](#how-to-work-without-swagger-ui)
    - [How to run tests](#how-to-run-tests)
  - [Documentation](#documentation)
  - [Team]()
 
---

## Installation
### Required to install
* <a href="https://dotnet.microsoft.com/en-us/download/dotnet/6.0" target="_blank">ASP.NET Core Runtime 6.0.12</a>
* <a href="https://www.microsoft.com/en-us/sql-server/sql-server-downloads" target="_blank"> Microsoft SQL Server 2017</a>+

### Setup
  1. Change connection string  
   (Go to **appsettings.json** and write your server to connection string)
  2. Create local database  
   (Run migrtions and update your local database)


### How to run local 
 Run the Streetcode project than open your browser and enter https://localhost:7071/swagger/index.html url. If you had this page already opened, just reload it.

### How to connect to db locally
1. launch SQL Server management Studio
2. In the pop-up window:
    - enter **"localhost"** as the server name;
    - select **"windows authentication"** as authentication mechanism;
3. After the connection has been established, right-click on the server (the first line with the icon), on the left-hand side of the UI
4. In the the appeared window find and click on **"properties"**
5. In the properties section, select **"security"** page
6. Make sure that **"Server authentication"** radio-button is set to **"SQL Server and Windows Authentication mode"**
7. Click "Ok"
8. Then again, on the left-hand side of the UI find folder entitled **"Security"**, and expand it
9. In unrolled list of options find folder "Logins", and expand it
10. At this point, you should have **"sa"** as the last option.
    If for some reason you do not see it, please refer to https://stackoverflow.com/questions/35753254/why-login-without-rights-can-see-sa-login
11. Right-click on the "sa" item, select "properties"
12. Change password to the default system one - **"Admin@1234"**. Don't forget to confirm it afterwards
13. On the left-hand side select **"Status"** page, and set **"Login"** radio-button to **"Enabled"**
14. Click "Ok"

Now you can connect to your localhost instance with login (sa) and password (Admin@1234)!

**_NOTE:_** Here's the full walkthrough: https://www.youtube.com/watch?v=ANFnDqe4JBk&t=211s.

---

## Usage
### How to work with swagger UI
Run the Streetcode project than open your browser and enter https://localhost:5001/swagger/index.html url. If you had this page already opened, just reload it.

### How to run API without swagger UI
Run the Streetcode project in any other profile but "Local" and enter http://localhost:5000. Now, you are free to test API-endpoints with <a href="https://www.postman.com/" target="_blank">Postman</a> or any other tool.

### How to run tests

---

## Documentation
Learn more about our documentation <a href="" target="_blank">*here*</a>.

---

## Team

<div align="center">
</div>




