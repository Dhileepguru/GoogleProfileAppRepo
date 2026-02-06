# GOOGLE-INTEGRATED PROFILE APP - SETUP INSTRUCTIONS

1. GoogleProfileAppRepo

---

This project is an ASP.NET Core MVC application that integrates Google External Authentication and stores user profile data in a SQL Server database.

2. Prerequisites

---

1. Visual Studio 2022 (with ASP.NET and web development workload).

2. SQL Server & SSMS (SQL Server Management Studio)

3. Locate the file: 'script.sql' in the root folder.
4. Open SSMS and execute this script.

- Note: The script is generated with 'Schema and Data' options to ensure the 'dbo.ApplicationUsers' table and test records are created
  correctly.

- .NET 8.0 SDK (I had used Version 8.0 for long term support) before running a project check the packages are in the version 8.0

3. Project Dependencies

---

- Microsoft.AspNetCore.Authentication.Google
- Microsoft.EntityframeworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Core
- (Note: These will auto-restore upon building the solution)

4. User Secrets

---

- Client ID & Secret: For security, these were managed via USER SECRETS during development.

- NOTE ON REDIRECT URI:

Since the local port number might vary on your machine:

1. Run the project first to identify your local port.
2. Update the 'Authorized redirect URIs' in your Google Cloud Console to match:
   https://localhost:xxxx/signin-google

- Right Click on solution>Manage user secrets
  include Your ClientId , ClientSecret based on the sample Key "Authentication:Google:ClientId", "Authentication:Google:ClientSecret":

  {
  "Authentication:Google:ClientId": "778244144587-c46d5qfuuqk23f0f1q0g4i1sujjqj12a.apps.googleusercontent.com",
  "Authentication:Google:ClientSecret": "GOCSPX-\_o9rGfYw3Qd-rqo4-l4Noag8jXvB"
  }

  3.Connection String: Update 'DefaultConnection' as "con": "data source= Your local SQL Server instance" in appsettings.json

5. How to Run

---

- Open 'GoogleProfileApp.sln' in Visual Studio 2022.
- Clean and Build the solution (to restore NuGet packages).
- Press F5 to launch.

# NOTE(nuggets excluded)

Following assessment guidelines, the 'bin' and 'obj' folders have
been excluded from this ZIP file to keep the submission clean and
to exclude compiled artifacts.
