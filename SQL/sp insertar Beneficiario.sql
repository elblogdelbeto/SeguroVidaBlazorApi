CREATE PROCEDURE InsertBeneficiario
	@BeneficiarioId INT,
	@EmpleadoId INT,
	@Nombre NVARCHAR(MAX),
    @Apellidos NVARCHAR(MAX),
    @FechaNacimiento DATETIME,  
    @CURP NVARCHAR(MAX),
    @SSN NVARCHAR(MAX),
	@Telefono NVARCHAR(MAX),
    @Nacionalidad NVARCHAR(MAX),
	@PorcentajeParticipacion INT
	AS
BEGIN

	IF @BeneficiarioId > 0
	BEGIN
		DECLARE @PersonaId INT
		SELECT @PersonaId = PersonaId FROM Beneficiario WHERE BeneficiarioId = @BeneficiarioId

		UPDATE Persona SET Nombre = @Nombre, Apellidos = @Apellidos, FechaNacimiento = @FechaNacimiento, CURP = @CURP, SSN = @SSN, Telefono = @Telefono, Nacionalidad = @Nacionalidad
			WHERE PersonaId = @PersonaId	
		UPDATE Beneficiario SET PorcentajeParticipacion =  @PorcentajeParticipacion
			WHERE @PorcentajeParticipacion = @PorcentajeParticipacion
	END
	ELSE
	BEGIN
		INSERT INTO Persona (Nombre, Apellidos, FechaNacimiento, CURP, SSN, Telefono, Nacionalidad)
		VALUES (@Nombre, @Apellidos, @FechaNacimiento, @CURP, @SSN, @Telefono, @Nacionalidad)

		INSERT INTO Beneficiario(PorcentajeParticipacion, PersonaId, EmpleadoId)
		VALUES (@PorcentajeParticipacion, SCOPE_IDENTITY(), @EmpleadoId)
	END
END


EXEC InsertBeneficiario
NULL,
3,
'fghfgh',
'najeergtra',
'1986-01-05',
'NADA8reg60915',
'65er463GDSG',
'45354663456',
'Mexicana',
40


select * from Persona
select * from Empleado
select * from Beneficiario


