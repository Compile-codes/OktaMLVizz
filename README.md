# Okta SSO for ASP.NET Core (MLVizz)

This project demonstrates how to integrate **Okta Single Sign-On (SSO)** with an ASP.NET Core Web API using **OpenID Connect** and **Cookie Authentication**.

---

Developed by Joel Antony

---

## Setup

### 1. Clone the repository

git clone https://github.com/Compile-codes/OktaMLVizz.git

cd OktaMLVizz

2. Configure Okta

   Kindly refer the documentation inside MLVizz sharepoint.

3. Create a .env file

   Create a .env file in the root folder with your Okta values:

   OKTA_DOMAIN=https://domain.okta.com

   OKTA_CLIENT_ID=your-client-id

   OKTA_CLIENT_SECRET=your-client-secret

   OKTA_CALLBACK_PATH=/signin-oidc

4. Run the project

   dotnet restore

   dotnet run

By default, the app runs on http://localhost:5144.

Usage

GET http://localhost:5144/auth/login

Redirects the user to Okta for authentication. After successful login, the user is redirected to /auth/success.
