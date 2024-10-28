CREATE PROCEDURE [dbo].[UpdatePerson]
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Birth Date,
	@Id int	
AS
	UPDATE People SET
	FirstName = @FirstName,
	LastName = @LastName,
	DateOfBirth = @Birth
	WHERE Id = @Id
RETURN 0
