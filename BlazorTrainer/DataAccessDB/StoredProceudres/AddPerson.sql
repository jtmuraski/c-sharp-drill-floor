CREATE PROCEDURE [dbo].[AddPerson]
@FirstName NVARCHAR(50),
@LastName NVARCHAR(50),
@Birth Date
AS
BEGIN
	INSERT INTO People (FirstName, LastName, DateOfBirth)
	VALUES (@FirstName, @LastName, @Birth)
END
