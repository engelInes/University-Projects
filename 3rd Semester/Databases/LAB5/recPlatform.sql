---l5
CREATE TABLE Ta(
	aid INT PRIMARY KEY,
	a2 INT UNIQUE,
	a3 INT
)

CREATE TABLE Tb(
	bid INT PRIMARY KEY,
	b2 INT
)

CREATE TABLE Tc(
	cid INT PRIMARY KEY,
	aid INT FOREIGN KEY REFERENCES Ta(aid),
	bid INT FOREIGN KEY REFERENCES Tb(bid)
)

INSERT INTO Ta (aid, a2, a3) VALUES
(1, 11, 21),
(2, 12, 22),
(3, 13, 23),
(4, 14, 24),
(5, 15, 25);

INSERT INTO Tb (bid, b2) VALUES
(1, 101),
(2, 102),
(3, 103),
(4, 104),
(5, 105);

INSERT INTO Tc (cid, aid, bid) VALUES
(101, 1, 1),
(102, 2, 2),
(103, 3, 3),
(104, 4, 4),
(105, 5, 5);
/* 
- clustered index automatically created for the aid column from Ta
- nonclustered index automatically created for the a2 column from Ta
- clustered index automatically created for the bid column from Tb
- clustered index automatically created for the cid column from Tc
*/

---clustered index scan-scan the entire table
SELECT * FROM Ta

---clustered index seek-return a specific subset of rows from a clustered index
SELECT *
FROM Ta
WHERE aid<152

---nonclustered index scan-scan the entire nonclustered index
SELECT a2
FROM Ta
ORDER BY a2

-- nonclustered index seek - return a specific subset of rows from a nonclustered index
SELECT a2
FROM Ta
WHERE a2 > 21 AND a2 < 23

-- key lookup - nonclustered index seek + key lookup - the data is found in a nonclustered index, but additional data is needed
SELECT a3, a2
FROM Ta
WHERE a2 = 24
---b Write a query on table Tb with a WHERE clause of the form WHERE b2 = value and analyze its execution plan. 
---Create a nonclustered index that can speed up the query. Examine the execution plan again.
SELECT *
FROM Tb
WHERE b2 > 103

DROP INDEX Tb_b2_index ON Tb
CREATE NONCLUSTERED INDEX Tb_b2_index ON Tb(b2)
GO
---c Create a view that joins at least 2 tables. Check whether existing indexes are helpful;
---if not, reassess existing indexes / examine the cardinality of the tables.
CREATE OR ALTER VIEW View1 AS
	SELECT A.aid, B.bid, C.cid
	FROM Tc C
	INNER JOIN Ta A ON A.aid = C.aid
	INNER JOIN Tb B ON B.bid = C.bid
	WHERE B.b2 > 100 AND A.a3 < 23

GO
SELECT *
FROM View1

DROP INDEX Ta_a3_index ON Ta
CREATE NONCLUSTERED INDEX Ta_a3_index ON Ta(a3)

DROP INDEX Tc_index ON Tc
CREATE NONCLUSTERED INDEX Tc_index ON Tc(aid, bid)

