# PetManagementServices

This is .net core web api services which provides Pet Management Web Services facility. It has different entities like PetOwner, Pet.

Entities:

 -PetOwner
 -Pet
 
RelationShip: 

PetOwner can have mamy Pets i.e. One to Many

Instruction:
 -To create database , change connection string in appSetting.json file , in below connection provide database name
 "DevConnection": "Data Source= ---------;Initial Catalog=PetDB;Integrated Security=True;"
- In Package-Management-Console type "Add-Migration InitialCreate" to create migration for database using entity framework when first time before run your project.
- In Package-Management-Console type "update-database" to create database in SQL Server Db.
- Once database created , create entities like, Group, station and connectors from PostMan

Technolgies Used:

- .net core web api version-3.1 
-  Entity framework version-3.1 
-  SQL Server -2016 Express edition (You can use any version)
-  VS2019 community edition (You can use any version)
-  Postman
-  Swagger

