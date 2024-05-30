USE Filmes

SELECT * FROM ElencoFilme
--Tabela responsável por representar um relacionamento do tipo muitos para muitos entre filmes e atores, ou seja, um ator pode trabalhar em muitos filmes, e filmes podem ter muitos atores.

SELECT * FROM Filmes
--Tabela responsável por armazenar informações dos filmes.

SELECT * FROM Atores
--Tabela responsável por armazenar informações dos atores.

SELECT * FROM FilmesGenero
--Tabela responsável por representar um relacionamento do tipo muitos para muitos entre filmes e gêneros, ou seja, um filme pode ter mais de um gênero, e um genêro pode fazer parte de muitos filmes.

SELECT * FROM Generos
--Tabela responsável por armazenar os gêneros dos filmes.


--1 - Buscar o nome e ano dos filmes
SELECT Nome
	 , Ano 
FROM Filmes

--2 - Buscar o nome e ano dos filmes, ordenados por ordem crescente pelo ano

SELECT Nome
	 , Ano
	 , duracao
FROM Filmes
ORDER BY Ano ASC

--3 - Buscar pelo filme de volta para o futuro, trazendo o nome, ano e a duração

SELECT Nome
	 , Ano
	 , duracao
FROM Filmes
WHERE Nome = 'de volta para o futuro'

--4 - Buscar os filmes lançados em 1997

SELECT Nome
	 , Ano
	 , duracao
FROM Filmes
WHERE Ano = 1997


--5 - Buscar os filmes lançados APÓS o ano 2000

SELECT Nome
	 , Ano
	 , duracao
FROM Filmes
WHERE Ano > 2000

--6 - Buscar os filmes com a duracao maior que 100 e menor que 150, ordenando pela duracao em ordem crescente

SELECT Nome
	 , Ano
	 , duracao
FROM Filmes
WHERE duracao > 100 and duracao < 150
ORDER BY duracao ASC

--7 - Buscar a quantidade de filmes lançadas no ano, agrupando por ano, ordenando pela duracao em ordem decrescente


SELECT Ano
, count(Duracao) As Quantidade

FROM Filmes
GROUP BY Ano
ORDER BY count(Duracao) desc

--8 - Buscar os Atores do gênero masculino, retornando o PrimeiroNome, UltimoNome

SELECT Id
	 , PrimeiroNome
	 , UltimoNome
	 , Genero
FROM Atores
WHERE Genero ='M'

--9 - Buscar os Atores do gênero feminino, retornando o PrimeiroNome, UltimoNome, e ordenando pelo PrimeiroNome

SELECT Id
	 , PrimeiroNome
	 , UltimoNome
	 , Genero
FROM Atores
WHERE Genero ='F'
ORDER BY PrimeiroNome

--10 - Buscar o nome do filme e o gênero


SELECT Filmes.Nome, Generos.Genero
FROM Filmes
INNER JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
INNER JOIN Generos ON FilmesGenero.IdGenero = Generos.Id;

--11 - Buscar o nome do filme e o gênero do tipo "Mistério"


SELECT Filmes.Nome
	,  Generos.Genero
FROM Filmes
RIGHT JOIN FilmesGenero ON Filmes.Id = FilmesGenero.IdFilme
LEFT JOIN Generos ON Generos.Id = FilmesGenero.IdGenero
WHERE Genero = 'Mistério'

--12 - Buscar o nome do filme e os atores, trazendo o PrimeiroNome, UltimoNome e seu Papel

SELECT Filmes.Nome
	 , Atores.PrimeiroNome
     , Atores.UltimoNome
     , ElencoFilme.Papel
FROM Filmes 
INNER JOIN Atores  ON Filmes.Id = Atores.Id
INNER JOIN ElencoFilme ON Atores.Id = ElencoFilme.Id;


