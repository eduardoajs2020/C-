USE [ExemploDB]
GO

-- Criação da tabela
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NULL,
	[Sobrenome] [varchar](255) NULL,
	[Email] [varchar](255) NULL,
	[AceitaComunicados] [bit] NULL,
	[DataCadastro] [datetime2](7) NULL
) ON [PRIMARY]

SELECT [Id]
      ,[Nome]
      ,[Sobrenome]
      ,[Email]
      ,[AceitaComunicados]
      ,[DataCadastro]
	  ,GETDATE() as [DataAtual]
  FROM [dbo].[Clientes]
  --WHERE Id between 50 and 60
  where Nome = 'Ken'

  INSERT INTO Clientes VALUES ('Ken','Sánchez','email@email.com',0,'Jan  7 2009 12:00AM')



  BEGIN TRAN

  UPDATE Clientes 
  SET Nome = 'Ed' 
	, AceitaComunicados = 1
  WHERE id = 54


  DELETE Clientes
  WHERE Id = 157



DROP TABLE IF EXISTS dbo.Produtos

CREATE TABLE Produtos (
	Id int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nome varchar(255) NOT NULL,
	Cor varchar(50) NULL,
	Preco decimal(13, 2) NOT NULL,
	Tamanho varchar(5) NULL,
	Genero char(1) NULL
)

INSERT INTO Produtos VALUES ('Mountain Bike Socks, M','Branco','9.50','M','U')




SELECT [Id]
      ,[Nome]
      ,[Cor]
      ,[Preco]
      ,[Tamanho]
      ,[Genero]
  FROM [dbo].[Produtos]

 ALTER TABLE produtos
 ADD DataCadastro DATETIME2

 
 ALTER TABLE produtos
 DROP COLUMN DataCadastro 

 SELECT [Id]
       ,[Nome]
       ,[Cor]
       ,[Preco]
       ,[Tamanho]
       ,[Genero]
	   , GETDATE() AS DataCadastro 
 FROM PRODUTOS

 SELECT * FROM PRODUTOS

 SELECT Tamanho
 , COUNT(*) Quantidade
 FROM PRODUTOS
 WHERE Tamanho <> ''
 GROUP BY Tamanho
 ORDER BY Quantidade DESC

 ALTER TABLE produtos
 DROP COLUMN DataCadastro 


 CREATE TABLE Enderecos (
	Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
	IdCliente int NULL,
	Rua varchar(255) NULL,
	Bairro varchar(255) NULL,
	Cidade varchar(255) NULL,
	Estado char(2) NULL,

	--CONSTRAINT FK_Enderecos_Clientes FOREIGN KEY (IdCliente)
	--REFERENCES Clientes(Id)
)

DROP TABLE Enderecos

CREATE TABLE Enderecos (
    Id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    IdCliente INT,
    Logradouro VARCHAR(255),
    Numero INT,
    Bairro VARCHAR(255),
    Cidade VARCHAR(255),
    Estado VARCHAR(2),
    CONSTRAINT FK_Enderecos_Clientes FOREIGN KEY (IdCliente)
    REFERENCES clientes(id)
);

 SELECT * FROM Enderecos

 INSERT INTO Enderecos VALUES (4,'Rua Teste', 'Bairro teste', 'Cidade teste', 'SP')

 select * from clientes where Id = 4
 select * from Enderecos where IdCliente = 4

 SELECT Clientes.Nome
	  , Clientes.Sobrenome
	  , Clientes.Email
	  , Enderecos.Rua
	  , Enderecos.Bairro
	  , Enderecos.Cidade
	  , Enderecos.Estado
 FROM 
	CLIENTES

 INNER JOIN Enderecos ON Clientes.Id = Enderecos.IdCliente
 WHERE Clientes.Id = 4

 ALTER TABLE Enderecos
 ADD Rua varchar(255) NULL

  ROLLBACK




