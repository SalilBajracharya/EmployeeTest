Employee Web Api Notes:
1. Please run the SQL script for Employee Table.
2. Change the server name in Connection strings in app.config file and web.config file respectively.
3. API Testing Methods:

Get all employee :
GET
https://localhost:44323/api/employeesapi/

Get specific Employee via id :
GET
https://localhost:44323/api/employeesapi/[input id] 

Add new Employee:
POST
https://localhost:44323/api/employeesapi/
{
    "Name": "John Doe",
    "Address": "test address",
    "PhoneNo": "1232412312",
    "JoiningDate": "2021-08-10T00:00:00",
    "Skills": "test skills",
    "Photo": "test.jpg"
}
//Id is auto increment

Delete specific Employee:
DELETE
https://localhost:44323/api/employeesapi/[input id] 

Update specific Employee:
PUT
https://localhost:44323/api/employeesapi/[input id]
Body :
{
    "Id":"1019"
    "Name": "John Doe",
    "Address": "test address",
    "PhoneNo": "1232412312",
    "JoiningDate": "2021-08-10T00:00:00",
    "Skills": "test skills",
    "Photo": "test.jpg"
}