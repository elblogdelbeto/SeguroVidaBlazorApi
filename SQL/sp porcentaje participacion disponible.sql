ALTER PROCEDURE PorcentajeParicipacionMaximoDisponible
	@EmpleadoId INT
	AS
BEGIN
	DECLARE @PorcentajeAcumulado INT

	IF @EmpleadoId > 0
	BEGIN		
		SELECT @PorcentajeAcumulado = SUM(PorcentajeParticipacion) FROM Beneficiario WHERE EmpleadoId = @EmpleadoId	
		SELECT 100 - @PorcentajeAcumulado
	END
	ELSE
	BEGIN
		SELECT 0
	END
END


--EXEC PorcentajeParicipacionMaximoDisponible 1029


exec sp_executesql N'EXEC PorcentajeParicipacionMaximoDisponible @p0',N'@p0 int',@p0=1029
exec sp_executesql N'EXEC PorcentajeParicipacionMaximoDisponible @p0',N'@p0 int',@p0=1029

