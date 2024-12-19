# FanCode

Technology and Versions used

Backend

- ASP.NET Core Web API - 8.0

Frontend

- Angular - 18
- Package Manager Npm - 10.8.2
- Node.js - 20.17.0

Angular project setup

To set up Angular 18, npm 10.8.2, and Node.js 20.17.0, follow the steps below:

1. Install Node.js 20.17.0 if it's not already installed. This will include npm (Node Package Manager).

 https://nodejs.org/en/download/package-manager/current

2. Once instllation is done, check the node version and npm version.
3. To check version, open cmd and type following commands

node -v      # Should show v20.17.0

npm -v       # Should show npm 10.8.2 or close

4. Install Angular CLI globally to manage Angular project.

npm install -g @angular/cli@18

This command will install Angular CLI version 18.

5. Verify Angular CLI Installation Check that the Angular CLI is installed correctly by running.

ng version

This will show the installed Angular version, along with other relevant package versions.

Run the Backend (.NET Core) Project:

1. Click on "Build" in the top menu of Visual Studio.
2. Once the build is successful, press F5 or click the green "Start Debugging" button at the top.
3. Visual Studio will compile and start the application.

Run the Frontend (Angular) Project:

1. Open a terminal or command prompt in your project directory.
2. Run the following command
   
ng serve OR ng serve --o (The --o flag will automatically open your default browser to the application URL)

3. The project will start and be accessible at http://localhost:, where is the port assigned by the development server.
