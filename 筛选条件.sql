SELECT DISTINCT TrainNo,运营状态,车次,出发站,终点站,途经沪宁O站,途经沪宁D站,出发时间,到达时间,历时
FROM dbo.TrainTicket 
WHERE SUBSTRING(车次,1,1) ='G'OR SUBSTRING(车次,1,1) ='D'