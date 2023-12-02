# Tachograph.Services
Tachograph Services
1.	Purpose 
The purpose of this document is to describe a technical task part that developed by Yousef Ashmawy.

2.	Project Parts  
This project contains four major parts as below:
1.	Solution folder Core that contains: 
a.	Domain : A class library project will host enterprise wide entities, db context etc.
b.	Infrastructure : A class library project responsible for external infrastructure communications and all interfaces in one place
c.	Application : A class library project responsible of all services business logic
 
2.	Solution folder Services that contain:
  a.	Worker service that will be responsible of reading files Json files that contains drivers’ data and store it in database.
3.	Solution folder Simulator that contains:
  a.	Desktop application working as simulator to generate Json files contains drivers’ data.
4.	Solution folder UnitTests that contain:
  a.	UnitTests working as Unit Test for web api
5.	Solution folder Web that contains:
  a.	Wab Api project that have all api that will be requested from front app
6.	Solution folder open in VS Code:
  a.	Front app calling web apis to view listed required. 
 

3.	Task Details 

-	Data Simulation with Sample Data by Desktop application working as simulator.
-	Worker service that will be responsible of reading files Json files that contain drivers’ data and store it in PostgreSQL database.
-	PostgreSQL database views that will view lists as data from TachographRecord table.
-	Web Api presents all data required from front to view lists.
-	Web APP presents all data in lists.
