-- Adicionando o Fornecedor
INSERT INTO dbo.Fornecedor 
VALUES ('NetCoders', GETDATE());

SELECT * FROM dbo.Fornecedor;

-- Adicionando uma compra
INSERT INTO dbo.Compra
VALUES (1, GETDATE());

SELECT * FROM Compra;
