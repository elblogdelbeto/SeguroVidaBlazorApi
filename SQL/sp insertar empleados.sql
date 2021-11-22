ALTER PROCEDURE InsertEmpleado
	@EmpleadoId INT,
	@Nombre NVARCHAR(MAX),
    @Apellidos NVARCHAR(MAX),
    @FechaNacimiento DATETIME,  
    @CURP NVARCHAR(MAX),
    @SSN NVARCHAR(MAX),
	@Telefono NVARCHAR(MAX),
    @Nacionalidad NVARCHAR(MAX),
	@NumeroEmpleado INT
	AS
BEGIN

	IF @EmpleadoId > 0
	BEGIN
		DECLARE @PersonaId INT
		SELECT @PersonaId = PersonaId FROM Empleado WHERE EmpleadoId = @EmpleadoId

		UPDATE Persona SET Nombre = @Nombre, Apellidos = @Apellidos, FechaNacimiento = @FechaNacimiento, CURP = @CURP, SSN = @SSN, Telefono = @Telefono, Nacionalidad = @Nacionalidad
			WHERE PersonaId = @PersonaId	
		UPDATE Empleado SET NumeroEmpleado =  @NumeroEmpleado
			WHERE EmpleadoId = @EmpleadoId
	END
	ELSE
	BEGIN
		INSERT INTO Persona (Nombre, Apellidos, FechaNacimiento, CURP, SSN, Telefono, Nacionalidad)
		VALUES (@Nombre, @Apellidos, @FechaNacimiento, @CURP, @SSN, @Telefono, @Nacionalidad)

		INSERT INTO Empleado (NumeroEmpleado, PersonaId)
		VALUES (@NumeroEmpleado, SCOPE_IDENTITY())
	END
END


EXEC InsertEmpleado 
NULL,
'aaaaaa',
'najeergtra',
'1986-01-05',
'NADA8reg60915',
'65er463GDSG',
'45354663456',
'Mexicana',
123

exec sp_executesql N'EXEC InsertEmpleado @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7',N'@p0 nvarchar(4000),@p1 nvarchar(4000),@p2 nvarchar(4000),@p3 nvarchar(4000),@p4 nvarchar(4000),@p5 nvarchar(4000),@p6 nvarchar(4000),@p7 nvarchar(4000)',@p0=N'string',@p1=N'string',@p2=N'11/11/1990',@p3=N'string',@p4=N'string',@p5=N'567567',@p6=N'string',@p7=N'4'



select * from Persona
select * from Empleado


