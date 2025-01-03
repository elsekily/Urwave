# Urwave Application Setup

## Running the App

To run the application directly, I have published a release that you can download from the following link:

[Download Urwave V1.0.0 Release](https://github.com/elsekily/Urwave/archive/refs/tags/V1.0.0.zip)

### Steps to Run the Application:

1. **Download the Release**:
   - Download the release zip file from the link above.

2. **Update the Database Connection**:
   - Before running the program, you **must** update the database connection string in `appsettings.json` to match your environment.
     - Open the `appsettings.json` file located in the root of the project.
     - Modify the `ConnectionStrings` section with your SQL Server connection string.

3. **Automatic Database Migration**:
   - The API will automatically connect to your SQL Server service to perform database migrations and populate the database upon the first run.

4. **No Need to Install .NET Runtime**:
   - There's no need to install the .NET runtime on your system because it is included with the published release. Simply download and run the application.
    
