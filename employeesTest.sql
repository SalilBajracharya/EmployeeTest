Create Database EmployeesTest

Create table Employee
(
	Id int Identity(1,1) Primary Key,
	Name nvarchar(max),
	Address nvarchar(max),
	PhoneNo nvarchar(max),
	JoiningDate DateTime,
	Skills nvarchar(max),
	Photo nvarchar(max)
)

	Select * from Employee

	Insert into Employee values
	('John Doe','United States of Americe', '9841254785', '2021-03-25', 'Hunting, Cooking', '~/Photo/johnDoe.jpg'),
	('Jane Doe','Africa', '1234567890', '2020-04-25', 'Cooking, Public Speaking', '~/Photo/janeDoe.jpg')
