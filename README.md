# OktaMLVizz

Getting Started
Follow these steps to get your MLVizzOktaSSO application up and running.

1. Clone the Repository
   git clone https://github.com/Compile-codes/OktaMLVizz.git
   cd OktaMLVizz

2. Okta Application Setup
   You need to create a new Web Application in your Okta organization to integrate with this project by going through the following sharepoint document:
   https://simplyaicomau.sharepoint.com/sites/MLVizzGroupies/Shared%20Documents/Forms/AllItems.aspx?noAuthRedirect=1&id=%2Fsites%2FMLVizzGroupies%2FShared%20Documents%2FDocumentation%20and%20Instructions%2FMLVizz%20Okta%20Configuration%20%2Epdf&viewid=5e02334f%2D4c41%2D4249%2D8415%2Ddd57ada1d200&parent=%2Fsites%2FMLVizzGroupies%2FShared%20Documents%2FDocumentation%20and%20Instructions

3. Configure the Application
   Update the appsettings.json file with your Okta application details.

JSON

{
"Okta": {
"ClientId": "YOUR_OKTA_CLIENT_ID",
"ClientSecret": "YOUR_OKTA_CLIENT_SECRET",
"Authority": "https://YOUR_OKTA_DOMAIN/oauth2/default"
},
"Logging": {
"LogLevel": {
"Default": "Information",
"Microsoft.AspNetCore": "Warning"
}
},
"AllowedHosts": "\*"
}

[YOUR_OKTA_CLIENT_ID]: The Client ID from your Okta application.

[YOUR_OKTA_CLIENT_SECRET]: The Client Secret from your Okta application.

[YOUR_OKTA_DOMAIN]: Your Okta organization URL (e.g., integrator-12345678.okta.com).

Important: Never commit appsettings.json with sensitive production keys to version control. Use environment variables or a secrets manager for production deployments. For local development, appsettings.Development.json or .NET User Secrets are better alternatives.

4. Run the Application
   Navigate to the project directory in your terminal:

Bash

cd MLVizzOktaSSO
Run the application:

Bash

dotnet run
The application should start, and you will see messages indicating the URLs it's listening on (e.g., https://localhost:7157). Open your browser to the HTTPS URL.
