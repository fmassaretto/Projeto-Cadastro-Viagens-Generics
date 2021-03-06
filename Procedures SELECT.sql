USE [ViagensInterplanetarias]
GO
/****** Object:  StoredProcedure [dbo].[clientesPorNome_sps]    Script Date: 2017-04-10 5:36:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[clientesPorNome_sps] @NOME VARCHAR(200)
AS
BEGIN
	SELECT Id, Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes WHERE Nome = @Nome
END

GO

ALTER PROCEDURE [dbo].[clientesTodos_sps]
AS
BEGIN
	SELECT Id, Nome, Especie, Documento, Cor, QtdBracos, QtdPernas, QtdCabeca, Respira FROM Clientes
END

GO

ALTER PROCEDURE [dbo].[planetasTodos_sps]
AS
BEGIN
	SELECT Id, Nome, Descricao, PossuiOxigenio FROM Planetas
END

GO
ALTER PROCEDURE [dbo].[planetasPorNome_sps] @NOME VARCHAR(200)
AS
BEGIN
	SELECT Id, Nome, Descricao, PossuiOxigenio FROM Planetas WHERE Nome = @Nome
END

ALTER PROCEDURE viagensDispTodos_sps
AS
BEGIN
	SELECT Id, PlanetaOrigem, PlanetaDestino, Valor, Tempo FROM ViagensDisponiveis
END
GO

CREATE PROCEDURE viagensDispPorNome_sps @Nome VARCHAR(200)
AS
BEGIN
	SELECT Id, PlanetaOrigem, PlanetaDestino, Valor, Tempo FROM ViagensDisponiveis 
		WHERE PlanetaOrigem = @Nome OR PlanetaDestino = @Nome
END

GO

ALTER PROCEDURE viagemClientePorId_sps @Id INT
AS
BEGIN
	SELECT c.Id, c.Nome, c.Documento, c.Respira, vc.Id AS CodigoReserva, vd.PlanetaOrigem, vd.PlanetaDestino, vd.Valor, vd.Tempo, t.Nome, t.Terreno FROM Clientes c
	INNER JOIN ViagensClientes vc ON c.Id = vc.IdClientes
	INNER JOIN ViagensDisponiveis vd ON vc.IdViagensDisp = vd.Id
	INNER JOIN Transportes t ON vc.IdTransporte = t.Id
	WHERE c.Id = @Id
END

GO

ALTER PROCEDURE viagemClienteTodos_sps
AS
BEGIN
	SELECT c.Id, c.Nome, c.Documento, c.Respira, vc.Id AS CodigoReserva, vd.PlanetaOrigem, vd.PlanetaDestino, vd.Valor, vd.Tempo, t.Nome, t.Terreno FROM Clientes c
	INNER JOIN ViagensClientes vc ON c.Id = vc.IdClientes
	INNER JOIN ViagensDisponiveis vd ON vc.IdViagensDisp = vd.Id
	INNER JOIN Transportes t ON vc.IdTransporte = t.Id
END

GO

ALTER PROCEDURE transporteTodos_sps
AS
BEGIN
	SELECT Id, Nome, Terreno FROM Transportes
END

GO

ALTER PROCEDURE transportePorNome_sps @Nome VARCHAR(50)
AS
BEGIN
	SELECT Id, Nome, Terreno FROM Transportes WHERE Nome = @Nome
END

select * from ViagensClientes
select * from ViagensDisponiveis
select * from Clientes

