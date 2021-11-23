CREATE PROCEDURE InsertEmpleado
	@EmpleadoId INT,
	@Nombre NVARCHAR(MAX),
    @Apellidos NVARCHAR(MAX),
    @FechaNacimiento DATETIME,  
    @CURP NVARCHAR(MAX),
    @SSN NVARCHAR(MAX),
	@Telefono NVARCHAR(MAX),
    @Nacionalidad NVARCHAR(MAX),
	@NumeroEmpleado NVARCHAR(MAX)
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


--EXEC InsertEmpleado 
--NULL,
--'alberto',
--'najeergtra',
--'1986-01-05',
--'NADA8reg60915',
--'65er463GDSG',
--'45354663456',
--'Mexicana',
--'1234'

