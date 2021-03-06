CREATE PROCEDURE planetas_del @Id INT
AS
BEGIN
	DELETE FROM Planetas WHERE Id = @Id

	SELECT 'Planeta Excluido com Sucesso!' AS msgSucesso
END
EXEC planetas_del 16

GO

ALTER PROCEDURE clientes_del @Id INT
AS
BEGIN
	DELETE FROM Clientes WHERE Id = @Id
	DELETE FROM ViagensClientes WHERE IdClientes = @Id

	SELECT 'Cliente Excluido com Sucesso!' AS msgSucesso
END

GO

ALTER PROCEDURE transportes_del @Id INT
AS
BEGIN
	DELETE FROM Transportes WHERE Id = @Id
	DELETE FROM ViagensClientes WHERE IdTransporte = @Id

	SELECT 'Transporte Excluido com Sucesso!' AS msgSucesso
END


GO

ALTER PROCEDURE viagem_del @Id INT
AS
BEGIN
	DELETE FROM ViagensDisponiveis WHERE Id = @Id
	DELETE FROM ViagensClientes WHERE IdViagensDisp = @Id

	SELECT 'Transporte Excluido com Sucesso!' AS msgSucesso
END


GO

CREATE PROCEDURE bo_del @Id INT
AS
BEGIN
	DELETE FROM Transportes WHERE Id = @Id
	DELETE FROM ViagensClientes WHERE IdViagensDisp = @Id

	SELECT 'Transporte Excluido com Sucesso!' AS msgSucesso
END

select * from clientes