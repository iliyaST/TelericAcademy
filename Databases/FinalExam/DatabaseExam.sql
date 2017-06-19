USE SuperheroesUniverse

--1.List all superheroes in Earth

 SELECT s.Id,s.Name
 FROM Superheroes s
 JOIN PlanetSuperheroes ps
 ON ps.Superhero_Id = s.Id
 JOIN Planets p
 ON p.Id = ps.Planet_Id
 WHERE p.Name = 'Earth'
 
--2.List all superheroes with their powers and powerTypes

 SELECT s.Name AS Superhero,p.Name + '('+ pt.Name + ')' AS Power FROM Superheroes s
 JOIN PowerSuperheroes ps
 ON ps.Superhero_Id = s.Id
 JOIN Powers p
 ON p.Id = ps.Power_Id
 JOIN PowerTypes pt
 ON pt.Id = p.PowerTypeId

--3.List the top 5 planets, sorted by count of superheroes with alignment 'Good', then by Planet Name

 SELECT p.Name AS Planet,COUNT(DISTINCT s.Id) AS Protectors
 FROM Superheroes s
 JOIN Alignments a
 ON a.Id = s.Alignment_Id
 JOIN PlanetSuperheroes ps
 ON ps.Superhero_Id = s.Id
 JOIN Planets p
 ON p.Id = ps.Planet_Id
 WHERE a.Name = 'Good'
 GROUP BY p.Name
 ORDER BY COUNT(DISTINCT s.Id) DESC,p.Name
 
--4.Create a stored procedure to edit superheroes Bio, by provided Superhero's Id and the new bio
CREATE PROC usp_UpdateSuperheroBio
@superHeroId int,
@bioText nvarchar(200)
AS
UPDATE Superheroes
SET Bio = @bioText
WHERE Id = @superHeroId

EXEC usp_UpdateSuperheroBio 1,'I am genious'

--5.Create a stored prodecure, that gives full information about a superhero, by provided Superhero's Id

ALTER PROC usp_GetSuperheroInfo
@superHeroId int
AS
SELECT s.Id,s.Name,s.SecretIdentity,a.Name AS Aligment,s.Bio,pl.Name AS Planet,p.Name AS [Power] FROM Superheroes s
JOIN PowerSuperheroes ps
ON ps.Superhero_Id = s.Id
JOIN Powers p
ON p.Id = ps.Power_Id
JOIN PlanetSuperheroes pls
ON pls.Superhero_Id = s.Id
JOIN Planets pl
ON pl.Id = pls.Planet_Id
JOIN Alignments a
ON a.Id = s.Alignment_Id
WHERE s.Id = @superHeroId

EXEC usp_GetSuperheroInfo 10

--6.Create a stored procedure that prints the number of heroes with Good, 
--Evil and Neutral alignment for each Planet
---

ALTER PROC usp_GetPlanetsWithHeroesCount
AS
SELECT p.Name,COUNT(*) AS [Evil Heroes],
(SELECT COUNT(*) AS [Evil Heroes] FROM Superheroes s
JOIN PlanetSuperheroes ps
ON ps.Superhero_Id = s.Id
JOIN Planets pl
ON pl.Id = ps.Planet_Id
JOIN Alignments a
ON a.Id = s.Alignment_Id
WHERE a.Name = 'Good' AND pl.Name = p.Name
GROUP BY pl.Name)
 AS [Good Heroes] 
FROM Superheroes s
JOIN PlanetSuperheroes ps
ON ps.Superhero_Id = s.Id
JOIN Planets p
ON p.Id = ps.Planet_Id
JOIN Alignments a
ON a.Id = s.Alignment_Id
WHERE a.Name = 'Evil'
GROUP BY p.Name
--7.Create a stored procedure for creating a Superhero, with provided name, secret identity, 
--bio, alignment, a planet and 3 powers (with their types)
--Powers, power types, planet and alignement should be reused, if they are already in the database

ALTER PROC ups_CheckIfPowerExist 
@powerName nvarchar(20),
@powerType nvarchar(20)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM Powers
	WHERE Name = @powerName)
	BEGIN
		IF NOT EXISTS(SELECT * FROM PowerTypes
		WHERE Name = @powerType)
		BEGIN
			INSERT INTO PowerTypes(Name)
			VALUES(@powerType)
			INSERT INTO Powers(Name,[PowerTypeId])
			VALUES(@powerName,(SELECT PowerTypes.Id FROM PowerTypes WHERE PowerTypes.Name = @powerType))
		END
		ELSE
		BEGIN
			INSERT INTO Powers(Name,[PowerTypeId])
			VALUES(@powerName,(SELECT Id FROM PowerTypes WHERE Name = @powerType))
		END
	END
END
GO

ALTER PROC usp_CreateHero
@superHeroName nvarchar(20),
@sicretIdentity nvarchar(20),
@aligment nvarchar(20),
@bio nvarchar(200),
@planetName nvarchar(20),
@firstPower nvarchar(20),
@firstPowerType nvarchar(20),
@secondPower nvarchar(20),
@secondPowerType nvarchar(20),
@thirdPower nvarchar(20),
@thirdPowerType nvarchar(20)
AS

--CHECK IF ALigment exists
IF NOT EXISTS(SELECT * FROM Alignments
WHERE Name = @aligment)
BEGIN
	INSERT INTO Alignments(Name)
	VALUES(@aligment)	
	INSERT INTO Superheroes (Name,SecretIdentity,Alignment_Id,Bio)
	VALUES(@superHeroName,@sicretIdentity,(SELECT Id FROM Alignments WHERE Alignments.Name = @aligment),@bio)
END
ELSE
BEGIN
	INSERT INTO Superheroes (Name,SecretIdentity,Alignment_Id,Bio)
	VALUES(@superHeroName,@sicretIdentity,(SELECT Id FROM Alignments WHERE Alignments.Name = @aligment),@bio)
END

--CHECK If planet exists
IF NOT EXISTS(SELECT * FROM Planets
WHERE Name = @planetName)
BEGIN
	INSERT INTO Planets(Name)
	VALUES(@planetName)
END

--CHECK If Power and powertyeps exists
EXEC ups_CheckIfPowerExist @firstPower,@firstPowerType

EXEC ups_CheckIfPowerExist @secondPower,@secondPowerType

EXEC ups_CheckIfPowerExist @thirdPower,@thirdPowerType

EXEC usp_CreateHero 'Superman','Klark Cent','Superish',NULL,'Earth','Laser-eyes','suprieme','Armored Suit','God','Speed','flash'

GO
--8.Create a stored procedure that prints the number of powers by alignment of their superheroes

SELECT result.Aligment AS Aligment,COUNT(result.[Powers Count]) AS [Powers Count]
FROM 
(
SELECT a.Name AS Aligment,Power_Id AS [Powers Count] FROM Superheroes s
JOIN Alignments a
ON a.Id = s.Alignment_Id
JOIN PowerSuperheroes ps
ON ps.Superhero_Id = s.Id
GROUP BY a.Name,Power_Id
) result
GROUP BY result.Aligment




