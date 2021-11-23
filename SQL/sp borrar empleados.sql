ALTER PROCEDURE DeleteEmpleado
	@EmpleadoId INT
	AS
BEGIN

  DECLARE @PersonaId INT
  SELECT @PersonaId = PersonaId FROM Empleado WHERE EmpleadoId = @EmpleadoId

  DELETE Beneficiario WHERE EmpleadoId = @EmpleadoId
  DELETE Empleado WHERE EmpleadoId = @EmpleadoId
  DELETE Persona WHERE PersonaId = @PersonaId
	
END

exec sp_executesql N'EXEC DeleteEmpleado @p0',N'@p0 int',@p0=1007
--EXEC DeleteEmpleado 2


select * from Persona
select * from Empleado
select * from Beneficiario


