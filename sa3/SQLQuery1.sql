--criação do banco de dados
	CREATE DATABASE TesteSegurancaBE7;

--colocar o banco de dados em uso
USE	TesteSegurancaBE7;

--criação de uma tabela para armazenar usuários/ quando usa VARCHAR() tem q indicar o tamanho / Separar colunas por vírgula / 
-- USA O PRIMARY KEY para indicar que Id é a chave primaria / Usa o IDENTITY para autoincrementar - gera o id automaticamente
-- Usa o NOT NULL para não permitir campos nulos / A propriedade UNIQUE não deixa fazer dois cadastros com o mesmo email
CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Senha VARCHAR(50) NOT NULL
);

--consulta a todos os dados da tabela criada
SELECT * FROM Usuarios;

--cadastrar um usuario no banco de dados
INSERT INTO Usuarios VALUES ('email@email.com', 1234)
INSERT INTO Usuarios VALUES ('carla@email.com', 'senha123')

--hasheando dado em uma consulta utilizando algoritmo MD2 
-- tem q fazer o select campo por campo/ dessa forma a coluna com a senha Hach vem sem nome
--HASHBYTES(TIPO DE CRIPTOGRAFIA, CAMPO A HASHEAR) esse comando recebe dois parametros
SELECT Id, Email, HASHBYTES('MD2',Senha) FROM Usuarios;

--filtrar um usuario por id usa o WHERE
SELECT Id, Email, HASHBYTES('MD2',Senha) FROM Usuarios WHERE Id = 2;

--usa o AS para dar um apelido para coluna com a senha hasheada
SELECT Id, Email, HASHBYTES('MD2',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 2;

-- hasheando dado em uma consulta utilizando algoritmo MD4
SELECT Id, Email, HASHBYTES('MD4',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;

-- hasheando dado em uma consulta utilizando algoritmo MD5
SELECT Id, Email, HASHBYTES('MD5',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;

-- hasheando dado em uma consulta utilizando algoritmo SHA
SELECT Id, Email, HASHBYTES('SHA',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;

-- hasheando dado em uma consulta utilizando algoritmo SHA1
SELECT Id, Email, HASHBYTES('SHA1',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;

-- hasheando dado em uma consulta utilizando algoritmo SHA2_256
SELECT Id, Email, HASHBYTES('SHA2_256',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;

-- hasheando dado em uma consulta utilizando algoritmo SHA2_512
SELECT Id, Email, HASHBYTES('SHA2_512',Senha) AS 'Senha Hash'  FROM Usuarios WHERE Id = 1;