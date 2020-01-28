USE[ConnectionDataBase];
Create table Passengers(Name varchar(20),Age int,Email varchar(20),Password varchar(20));
Insert into Passengers(Name,Age,Email,Password) Values ('nnn',2,'nnn@gmail.com','wwwww');
CREATE Procedure spPassengerAdd

    @Name   varchar(20),

	@Age int,

    @Email      varchar(20),

    @Password   varchar(20),

    @PassengerID int OUTPUT

AS

BEGIN

INSERT INTO Passengers(Name,Age,Email,Password)VALUES(@Name,@Age,@Email,@Password)

SELECT

    @PassengerID = @@Identity

END

Declare @Id int
execute spPassengerAdd @Name='rohini',@Age=21,@Email='rohini@gmail.com',@Password='adhav',@PassengerId=@Id Output
Print @Id