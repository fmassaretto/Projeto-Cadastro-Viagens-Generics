USE [ViagensInterplanetarias]
GO
/****** Object:  StoredProcedure [dbo].[planetas_spi]    Script Date: 2017-04-10 6:12:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[planetas_spi] @Nome VARCHAR(50),
		@Descricao VARCHAR(500),
		@PossuiOxigenio BIT
AS
BEGIN
		INSERT INTO Planetas VALUES(@Nome, @Descricao, @PossuiOxigenio)

		SELECT 'Planeta Inserido com Sucesso' AS msgSucesso
END

CREATE PROCEDURE clientes_spi @Nome VARCHAR(200), 
	@Especie VARCHAR(100), 
	@Documento VARCHAR(100), 
	@Cor VARCHAR(100), 
	@QtdBracos INT, 
	@QtdPernas INT, 
	@QtdCabeca INT, 
	@Respira BIT
AS
BEGIN
	INSERT INTO Clientes VALUES(@Nome, @Especie, @Documento, @Cor, @QtdBracos, @QtdPernas, @QtdCabeca, @Respira)

	SELECT 'Cliente Inserido com Sucesso!' AS msgSucesso
END
EXEC clientes_spi 'Et', 'Varginha', 'fayf65', 'Verde', 2, 2, 1, 0


GO

ALTER PROCEDURE viagemCliente_spi @IdViagemDispo INT, 
	@IdCliente INT,
	@IdTransporte INT
AS
BEGIN
	INSERT INTO ViagensClientes VALUES(@IdViagemDispo, @IdCliente, @IdTransporte);

	SELECT c.Id AS Id, c.Nome AS NomeCliente, c.Documento AS Documento, c.Respira AS Respira, 
		vc.Id AS CodigoReserva, vd.PlanetaOrigem AS PlanetaOrigem, vd.PlanetaDestino AS PlanetaDestino, 
		vd.Valor AS Valor, vd.Tempo AS Tempo, t.Nome AS NomeTransporte, t.Terreno AS Terreno
	FROM Clientes c
	INNER JOIN ViagensClientes vc ON c.Id = vc.IdClientes
	INNER JOIN ViagensDisponiveis vd ON vc.IdViagensDisp = vd.Id
	INNER JOIN Transportes t ON vc.IdTransporte = t.Id
	WHERE vc.Id = SCOPE_IDENTITY()
	
	SELECT 'Reserva Realizada com sucesso!' AS msgSucesso
END
EXEC viagemCliente_spi 2, 3, 2


GO

ALTER PROCEDURE viagemDispo_spi @PlanetaOrigem VARCHAR(50), 
	@PlanetaDestino VARCHAR(50),
	@Valor INT,
	@Tempo INT
AS
BEGIN
	INSERT INTO ViagensDisponiveis VALUES(@PlanetaOrigem, @PlanetaDestino, @Valor, @Tempo)

	SELECT 'Viagem Inserida com sucesso!' AS msgSucesso
END


GO

CREATE PROCEDURE transportes_spi @Nome VARCHAR(50), 
	@Terreno VARCHAR(50)
AS
BEGIN
	INSERT INTO Transportes VALUES(@Nome, @Terreno)

	SELECT 'Transporte Inserido com sucesso!' AS msgSucesso
END


select * from ViagensClientes