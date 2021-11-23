CREATE PROCEDURE DeleteEmpleado
	@EmpleadoId INT
	AS
BEGIN

  DECLARE @PersonaId INT
  SELECT @PersonaId = PersonaId FROM Empleado WHERE EmpleadoId = @EmpleadoId

  DELETE Beneficiario WHERE EmpleadoId = @EmpleadoId
  DELETE Empleado WHERE EmpleadoId = @EmpleadoId
  DELETE Persona WHERE PersonaId = @PersonaId
	
END


--EXEC DeleteEmpleado 2


