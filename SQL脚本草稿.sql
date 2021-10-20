

初始化压差
DECLARE @I INT 
SET @I=1
WHILE @I<=20 BEGIN
	INSERT INTO NanJingZB_YaCha(MyIndex,YcValue)
	VALUES(@I,0)
	set @I=@I+1
END

SELECT * FROM NanJingZB_YaCha

USE LuoLiuAssigner
GO
CREATE TABLE RealData_GroovesAB
(
GrooveNo	Smallint,
Amin	Decimal(19,6),
Amax	Decimal(19,6),
Bmin	Decimal(19,6),
Bmax	Decimal(19,6),
AQty	Smallint,
BQty	Smallint
)
初始化容量
DECLARE @I INT 
SET @I=1
WHILE @I<=9 BEGIN
	INSERT INTO RealData_GroovesAB(GrooveNo)
	VALUES(@I)
	set @I=@I+1
END