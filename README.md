## Steps to build and run this repository  
1. Download and Install Visual Studio Code (If you don't have already)  
2. Make sure .Net SDk 9.0 version is installed  
3. Clone this repository  
4. Open this folder UserRecordManager in Visual studio code  
5. Install SQLite Extension for VS Code (Look for the SQLite extension by alexcvzz)
6. Go to src folder  
7. Run the following commands to create a Database  
   • dotnet ef migrations add InitialCreate1    
   • dotnet ef database update  
8. Go back to UserRecordManager folder from Terminal    
9. Run the following command - dotnet run  
10. Open the application in Swagger with the following URL  
   • http://localhost:5037/swagger/index.html  

