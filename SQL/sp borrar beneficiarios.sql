CREATE PROCEDURE DeleteBeneficiario
	@BeneficiarioId INT
	AS
BEGIN

  DECLARE @PersonaId INT
  SELECT @PersonaId = PersonaId FROM Beneficiario WHERE BeneficiarioId = @BeneficiarioId

  DELETE Beneficiario WHERE BeneficiarioId = @BeneficiarioId
  DELETE Persona WHERE PersonaId = @PersonaId
	
END


--EXEC DeleteBeneficiario 2


select * from Persona
select * from Empleado
select * from Beneficiario
