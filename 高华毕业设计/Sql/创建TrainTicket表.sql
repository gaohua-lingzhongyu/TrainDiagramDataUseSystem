CREATE TABLE TrainTicket
(
TrainNo VARCHAR(12) NOT NULL ,
运营状态 VARCHAR(max) DEFAULT '运营' CHECK(运营状态 IN('预定','列车停运' )),
车次 VARCHAR(max)CHECK(SUBSTRING('车次',1,1)LIKE'[A-Z]'),
起点站 NCHAR(3),
终点站 NCHAR(3),
途经起点站 NCHAR(3),
途经终点站 NCHAR(3),
出发时间 DATETIME,
到达时间 DATETIME,
历时 DATETIME,
查询时间 DATETIME NOT NULL PRIMARY KEY(TrainNo,查询时间),
其他 VARCHAR(MAX),
软卧一等卧 VARCHAR(MAX),
软座 VARCHAR(MAX),
动卧 VARCHAR(MAX),
硬卧二等卧 VARCHAR(MAX),
硬座 VARCHAR(MAX),
二等座 VARCHAR(MAX),
一等座 VARCHAR(MAX),
[商务座/特等座] VARCHAR(MAX),
高级软卧 VARCHAR(MAX)
)