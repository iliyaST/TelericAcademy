--01.Write a SQL query to find the names and salaries of the employees that take the minimal salary in the company.
--Use a nested SELECT statement.

SELECT 
	FirstName + ' ' + LastName AS [Empleyee Name],
	Salary
	FROM Employees
	WHERE Salary = (SELECT MIN(Salary) FROM Employees)

--02.Write a SQL query to find the names and salaries of the employees 
--that have a salary that is up to 10% higher than the minimal salary for the company.
	SELECT 
		FirstName + ' ' + LastName AS [Empleyee Name], Salary
	FROM Employees
	WHERE Salary <= (SELECT MIN(Salary)*1.1 
	FROM Employees)


--03.Write a SQL query to find the full name, salary and department of the employees that take the minimal salary in their department.
--Use a nested SELECT statement.
SELECT
	e.FirstName + ' ' + e.LastName AS [Full Name],e.Salary,DepartmentID
	FROM Employees e
	WHERE e.Salary = 
		(SELECT MIN(Salary) FROM Employees e2
			WHERE e.DepartmentID = e2.DepartmentID)
		ORDER BY DepartmentID

--04.Write a SQL query to find the average salary in the department #1.
SELECT
	AVG(e.Salary) AS [Average Salary]
	FROM Employees e
	WHERE DepartmentID = 1

--05.Write a SQL query to find the average salary in the "Sales" department.
SELECT 
	AVG(Salary)
	FROM Employees
	JOIN Departments
	ON Employees.DepartmentID = Departments.DepartmentID
	WHERE Departments.Name = 'Sales'	

SELECT AVG(e.Salary) as [AverageSalary], d.Name as [DepartmentName]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID AND d.Name = 'Sales'
GROUP BY d.Name

--06.Write a SQL query to find the number of employees in the "Sales" department.
SELECT
	Count(e.DepartmentID)
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'


--07.Write a SQL query to find the number of all employees that have manager.
SELECT 
	COUNT(EmployeeID)
	FROM Employees
	WHERE ManagerID IS NOT NULL

--08.Write a SQL query to find the number of all employees that have no manager.
SELECT 
	COUNT(EmployeeID)
	FROM Employees
	WHERE ManagerID IS NULL

--09.Write a SQL query to find all departments and the average salary for each of them.
SELECT AVG(Salary)
FROM Employees E
GROUP BY DepartmentID

--10.Write a SQL query to find the count of all employees in each department and for each town.
SELECT t.Name AS [Town], 
	   d.Name AS [Department],
	   COUNT(e.EmployeeID) AS [Employees Count]
	FROM Employees e, Addresses a, Towns t, Departments d
	WHERE e.AddressID = a.AddressID AND 
		  a.TownID = t.TownID AND 
		  e.DepartmentID = d.DepartmentID
	GROUP BY t.Name, d.Name
	ORDER BY t.Name, d.Name


SELECT 
	COUNT(*) AS [EMP COUNT],d.Name,t.Name
	FROM (Employees e
	JOIN Departments d
	ON d.DepartmentID = e.DepartmentID
	JOIN Addresses a
	ON e.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID)
	GROUP BY d.Name,t.Name
	HAVING COUNT(*) > 5

--11.Write a SQL query to find all managers that have exactly 5 employees. 
--Display their first name and last name.

SELECT COUNT(e.EmployeeID) AS [Emp Count],e2.EmployeeID,e2.FirstName
	FROM Employees e
	JOIN Employees e2
	ON e.ManagerID = e2.EmployeeID
	GROUP BY e2.EmployeeID, e2.FirstName
	HAVING COUNT(e.EmployeeID) = 5

SELECT
	e.EmployeeID, e.FirstName AS [Employee First Name], 
	 m.ManagerID, m.FirstName AS [Manager First Name]
	FROM Employees e
	JOIN Employees m
	ON e.ManagerID = m.EmployeeID
	ORDER BY m.FirstName

--12.Write a SQL query to find all employees along with their managers. For employees that do not have manager display the value "(no manager)".

SELECT
	e.EmployeeID, e.FirstName AS [E FirstName], ISNULL(m.FirstName, '(no manager)')
	FROM Employees e
	LEFT JOIN Employees m
		ON e.ManagerID = m.EmployeeID

--13.Write a SQL query to find the names of all employees whose last name is exactly 5 characters long. Use the built-in LEN(str) function.

SELECT
	FirstName, LastName
	FROM Employees
	WHERE LEN(LastName) = 5


--14.Write a SQL query to display the current date and time in the following format "day.month.year hour:minutes:seconds:milliseconds".
SELECT FORMAT(GetDate(), 'dd-mm-yyyy hh-mm-ss')

--15.Write a SQL statement to create a table Users. Users should have username, password, full name and last login time.
--Choose appropriate data types for the table fields. Define a primary key column with a primary key constraint.
--Define the primary key column as identity to facilitate inserting records.
--Define unique constraint to avoid repeating usernames.
--Define a check constraint to ensure the password is at least 5 characters long.

CREATE TABLE Users
	(
	UserID int IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	Username nvarchar(20) NOT NULL UNIQUE,
	Password nvarchar(20) NOT NULL CHECK (LEN(Password) >= 5),
	Login_time date default(CONVERT(nvarchar(20),getdate(),13)) 
	)

--16.Write a SQL statement to create a view that displays the users from the Users table that have been in the system today.
--Test if the view works correctly.

CREATE VIEW MyView1
AS
SELECT * FROM Users
WHERE DATEPART(dd,Login_time) = DATEPART(dd,getdate())
AND DATEPART(mm,Login_time) = DATEPART(mm,getdate()) 
AND DATEPART(YYYY,Login_time) = DATEPART(YYYY,getdate())

--17.Write a SQL statement to create a table Groups. Groups should have unique name (use unique constraint).
--Define primary key and identity column.

CREATE TABLE Groups
	(
	Id int IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(20) NOT NULL UNIQUE, 
	)

--18.Write a SQL statement to add a column GroupID to the table Users.
--Fill some data in this new column and as well in the `Groups table.
--Write a SQL statement to add a foreign key constraint between tables Users and Groups tables.\

ALTER TABLE Users
ADD GroupID int FOREIGN KEY (GroupID) REFERENCES Groups(Id);

SELECT u.Username,u.GroupID,g.Name,g.Id
	FROM Users u
	JOIN Groups g
	ON GroupID = Id

--19.Write SQL statements to insert several records in the Users and Groups tables.

INSERT INTO Users (Username,Password,GroupID)
VALUES ('Flash', 'Azsumburz',1)
INSERT INTO Users (Username,Password,GroupID)
VALUES ('Iron-man','Azsumsmart',5)
INSERT INTO Users (Username,Password,GroupID)
VALUES ('Hulk', 'hulksmash',8)

INSERT INTO Groups (Name)
VALUES ('Aliens')
INSERT INTO Groups (Name)
VALUES ('Hulkbusters')
INSERT INTO Groups (Name)
VALUES ('Geniuses')

--20.Write SQL statements to update some of the records in the Users and Groups tables.
UPDATE Users
SET Username = 'Superman'
WHERE Username = 'asfa'

UPDATE Groups
SET Name = 'Super-marios'
WHERE Name = 'Aliens'

--21.Write SQL statements to delete some of the records from the Users and Groups tables.
DELETE FROM Users
WHERE Username = 'Pesho'

--22.Write SQL statements to insert in the Users table the names of all employees from the Employees table.
--Combine the first and last names as a full name.
--For username use the first letter of the first name + the last name (in lowercase).
--Use the same for the password, and NULL for last login time.

INSERT INTO Users (Username,Password)
SELECT 
LEFT(FirstName, 1) + LastName,
LEFT(FirstName, 1) + LastName
FROM Employees
WHERE LEN(LastName) > 4

--23.TESTING

CREATE TABLE UsersTEST
	(
	UserID int IDENTITY(1,1) PRIMARY KEY CLUSTERED,
	Username nvarchar(20) NOT NULL UNIQUE,
	Password nvarchar(20) NOT NULL CHECK (LEN(Password) >= 5),
	Login_time date default(CONVERT(nvarchar(20),getdate(),13)),
	FullName nvarchar(40)
	)

INSERT INTO UsersTEST(Username,Password,[FullName])
SELECT 
LEFT(FirstName, 1) + LastName,
LEFT(FirstName, 1) + LastName,
FirstName + LastName
FROM Employees
WHERE LEN(LastName) > 4

--23.Write a SQL statement that changes the password to NULL for all users that have not been in the system since 10.03.2010.
UPDATE UsersTEST
	SET FullName = 'NULL'
	WHERE Login_time < CONVERT(date,'10-3-2010')

SELECT *
	FROM UsersTEST
	WHERE Username = 'Test2'

--24.Write a SQL statement that deletes all users without passwords (NULL password).
DELETE FROM UsersTEST
WHERE FullName = 'NULL'

--25.Write a SQL query to display the average employee salary by department and job title.
SELECT d.Name AS [Department],
		e.JobTitle,
	   AVG(e.Salary) AS [Employees Salary]
	FROM Employees e,Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle
	ORDER BY d.Name, e.JobTitle

SELECT 
	FirstName,
	Salary
	FROM Employees
	WHERE DepartmentID = 1 AND JobTitle = 'Design Engineer'


--26.Write a SQL query to display the minimal employee salary by department and job title along with the name of some of the employees that take it.
SELECT
	d.Name,
	e.JobTitle,
	Count(Salary) AS [MinSalary]
	FROM Employees e, Departments d
	WHERE e.DepartmentID = d.DepartmentID
	GROUP BY d.Name, e.JobTitle

	SELECT ROUND(MIN(e.Salary), 2) AS [MinSalary], 
        d.Name AS [Department],
        e.JobTitle, 
        MIN(CONCAT(e.FirstName, ' ', e.LastName)) AS [First Employee by Name],
        MAX(CONCAT(e.FirstName, ' ', e.LastName)) AS [Last Employee by Name]
    FROM Employees e 
    JOIN Departments d
        ON e.DepartmentID = d.DepartmentID
    GROUP BY d.Name, e.JobTitle

	SELECT MIN(e.Salary), d.Name, e.JobTitle, e.FirstName + ' ' + e.LastName as [FullName]
FROM Employees e, Departments d
WHERE e.DepartmentID = d.DepartmentID
GROUP BY  e.JobTitle, d.Name, e.FirstName, e.LastName
ORDER BY AVG(e.Salary) DESC

	SELECT 
		MIN(Name),
		MAX(name)
		FROM Towns

	SELECT
		Name
		FROM Towns
		ORDER BY Name

--27.Write a SQL query to display the town where maximal number of employees work.

SELECT TOP 1 COUNT(e2.EmployeeID),t2.Name
	FROM Employees e2,Towns t2,Addresses a2
	WHERE e2.AddressID = a2.AddressID AND 
	t2.TownID = a2.TownID
	GROUP BY t2.Name
	ORDER BY COUNT(e2.EmployeeID) DESC
	
SELECT
	FirstName,
	Name
	FROM Employees e, Addresses a, Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID	AND Name = 'Bellevue'

--28.Write a SQL query to display the number of managers from each town

SELECT
	COUNT(DISTINCT e2.FirstName),t.Name	
	FROM Employees e1
	JOIN Employees e2
	ON e1.ManagerID = e2.EmployeeID
	JOIN Addresses a
	ON e2.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	GROUP BY t.Name

SELECT
	e1.FirstName,e1.ManagerID,e2.FirstName,e2.EmployeeID,t.Name	
	FROM Employees e1
	JOIN Employees e2
	ON e1.ManagerID = e2.EmployeeID
	JOIN Addresses a
	ON e2.AddressID = a.AddressID
	JOIN Towns t
	ON a.TownID = t.TownID
	ORDER BY t.Name


--------------------------------------------------------------------------------------------------------------	
SELECT
	e1.FirstName,e1.ManagerID,e2.FirstName,e2.EmployeeID,t.Name	
	FROM Employees e1, Employees e2, Addresses a, Towns t
	WHERE e1.ManagerID = e2.EmployeeID AND e2.AddressID = a.AddressID AND a.TownID = t.TownID
	ORDER BY t.Name


SELECT
	COUNT(e.ManagerID),t.Name
	FROM Employees e,Addresses a,Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID
	GROUP BY t.Name

SELECT COUNT(*) AS [Number of Managers], t.Name
FROM Employees e
 JOIN Employees m
 ON e.ManagerID=m.EmployeeID
 JOIN Addresses a
 ON e.AddressID = a.AddressID
 JOIN Towns t
 ON a.TownID = t.TownID
 Group BY t.Name
 ORDER BY COUNT(*) DESC

SELECT
	e.ManagerID, t.Name
	FROM Employees e,Addresses a,Towns t
	WHERE e.AddressID = a.AddressID AND a.TownID = t.TownID AND ManagerID IS NOT NULL
	

--29.Write a SQL to create table WorkHours to store work reports for each employee (employee id, date, task, hours, comments).
--Don't forget to define identity, primary key and appropriate foreign key.
--Issue few SQL statements to insert, update and delete of some data in the table.
--Define a table WorkHoursLogs to track all changes in the WorkHours table with triggers.
--For each change keep the old record data, the new record data and the command (insert / update / delete).

CREATE TABLE WorkHours
(
	Id int PRIMARY KEY IDENTITY(1,1),
	EmployeeID int FOREIGN KEY REFERENCES Employees(EmployeeID),
	[Date] date default(CONVERT(nvarchar(20),getdate(),13)),
	Task nvarchar(50) NOT NULL,
	[Hours] int NOT NULL,	
	Comments nvarchar(200) 
)

CREATE TABLE WorkHoursLog
(
	Id int PRIMARY KEY IDENTITY(1,1),
	EmployeeID int FOREIGN KEY REFERENCES Employees(EmployeeID),
	[Date] date default(CONVERT(nvarchar(20),getdate(),13)),
	Task nvarchar(50) NOT NULL,
	[Hours] int NOT NULL,	
	Comments nvarchar(200),
	[Action] varchar(10) NOT NULL,
)
GO

ALTER TRIGGER usp_GetEmployees ON WorkHours
AFTER UPDATE
AS
BEGIN
	INSERT INTO WorkHoursLog(EmployeeID,[Date],Task,[Hours],Comments,[Action])
	SELECT EmployeeID,[Date],Task,[Hours],Comments,'UPDATE' FROM DELETED
	INSERT INTO WorkHoursLog(EmployeeID,[Date],Task,[Hours],Comments,[Action])
	SELECT EmployeeID,[Date],Task,[Hours],Comments,'UPDATE' FROM INSERTED
END

UPDATE WorkHours
SET [Hours] = 15
WHERE Id = 1

UPDATE WorkHours
SET [Hours] = [Hours] - 5
go

ALTER TRIGGER usp_GetEmployees ON WorkHours
AFTER INSERT
AS
BEGIN
	INSERT INTO WorkHoursLog(EmployeeID, [Date], Task, [Hours], Comments, [Action])
		SELECT EmployeeID, [Date], Task, [Hours], Comments, 'INSERT' FROM INSERTED
END


DECLARE @Hours int
DECLARE @Task nvarchar(20)
DECLARE	@EmployeeID int
DECLARE	@Comments nvarchar(40)

SET @Hours = 4
SET @Task = 'Programming'
SET	@EmployeeID = 1
SET @Comments = 'Something'

INSERT INTO WorkHours (EmployeeID, Task, [Hours], Comments)
VALUES (@EmployeeID,@Task, @Hours + 100, @Comments)


DECLARE @Hours1 int
DECLARE @Task1 nvarchar(20)
DECLARE	@EmployeeID1 int
DECLARE	@Comments1 nvarchar(40)
DECLARE @count int;
SET @count = 4;

WHILE(@count > 1)
BEGIN
SET @Hours1 = 4 + @count
SET @Task1 = 'Programming' + CONVERT(NVARCHAR, @count)
SET	@EmployeeID1 = 1 + @count
SET @Comments1 = 'Something' + CONVERT(NVARCHAR, @count)
INSERT INTO WorkHours (EmployeeID, Task, [Hours], Comments)
VALUES (@EmployeeID1,@Task1, @Hours1 + 100, @Comments1)
SET @count = @count - 1
END

------------------------DELETE
GO

ALTER TRIGGER usp_GetEmployees ON WorkHours
AFTER DELETE
AS
BEGIN
	INSERT INTO WorkHoursLog(EmployeeID, [Date], Task, [Hours], Comments, [Action])
		SELECT EmployeeID, [Date], Task, [Hours], Comments, 'DELETED' FROM DELETED
END

DELETE FROM WorkHours
	WHERE Id = 3

--30.Start a database transaction, delete all employees from the 'Sales' department along with all dependent records from the pother tables.
--At the end rollback the transaction

BEGIN TRAN

ALTER TABLE Departments
	DROP CONSTRAINT FK_Departments_Employees

	DELETE FROM Employees
	SELECT d.Name
	FROM Employees e
	JOIN Departments d
	ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'

ROLLBACK TRAN

--31.Start a database transaction and drop the table EmployeesProjects.
--Now how you could restore back the lost table data?

BEGIN TRAN
DROP TABLE UsersTEST
ROLLBACK TRAN
GO

--32.Find how to use temporary tables in SQL Server.
--Using temporary tables backup all records from EmployeesProjects and restore them back after dropping and re-creating the table.

--CREATE FUNCTION ufn_BackupRestore()
--RETURNS TABLE
--AS
--RETURN(
--SELECT *
--FROM EmployeesProjects
--)
--GO

--BEGIN TRAN

--SELECT * INTO #Temp_EmployeesProjects
--FROM ufn_BackupRestore();

--SELECT * FROM #Temp_EmployeesProjects

--ROLLBACK TRAN

BEGIN TRAN

SELECT * INTO #Temp_EmployeesProjects
FROM ufn_BackupRestore();

DROP TABLE  EmployeesProjects

SELECT * INTO EmployeesProjects
FROM #Temp_EmployeesProjects

ROLLBACK TRAN
