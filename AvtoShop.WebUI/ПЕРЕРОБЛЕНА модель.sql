USE Master
GO
IF DB_ID('AvtoShop') IS NOT NULL
  DROP DATABASE AvtoShop;
 GO
 
 CREATE DATABASE AvtoShop collate Ukrainian_CI_AI
 GO
 USE AvtoShop;
 CREATE TABLE Brand
 (
   BrandId int identity primary key,
   BrandName nvarchar(64) not null
 )
 SET IDENTITY_INSERT Brand ON
 INSERT INTO Brand(BrandId,BrandName)
 VALUES
 (1,'Reno'),
 (2, 'Citroen') ,(3, 'BMV'),(4, 'Audi');
 SET IDENTITY_INSERT Brand OFF
 
 
 
CREATE TABLE ModelAvto
 (
   ModelAvtoId int identity primary key,
   BrandId int foreign key REFERENCES Brand(BrandId),
   ModelName nvarchar(64) not null
 )
 GO
 
 
SET IDENTITY_INSERT ModelAvto ON
 INSERT INTO ModelAvto(ModelAvtoId, BrandId,ModelName)
 VALUES
 (1,1, 'Reno1'),
 (2,1, 'Reno2'),
 (3,1, 'Reno3'),
 (4,1, 'Reno4'),
 (5,1, 'Reno5'),
 (6,2, 'Citroen1'),(7,2, 'Citroen2'),(8,2, 'Citroen3'),
 (9,3, 'BMV1'),(10,3, 'BMV2'),
 (11,4, 'Audi1');
 SET IDENTITY_INSERT ModelAvto OFF 
  
Create Table AutoBody
(
   AutoBodyId int identity primary key,
   AutoBodyName nvarchar(64) not null
)

SET IDENTITY_INSERT AutoBody ON
 INSERT INTO AutoBody(AutoBodyId,AutoBodyName)
 VALUES
 (1,'Седан'),
 (2, 'Купе') ,(3, 'Минивен'),(4, 'Универсал');
 SET IDENTITY_INSERT AutoBody OFF
 
 GO
 
 
 --fuel
 Create Table Fuel
(
   FuelId int identity primary key,
   FuelName nvarchar(32) not null
)

SET IDENTITY_INSERT Fuel ON
 INSERT INTO Fuel(FuelId,FuelName)
 VALUES
 (1,'Бензин'),
 (2, 'Дизель') ,(3, 'Бензин/газ'),(4, 'Гибрид');
 SET IDENTITY_INSERT Fuel OFF
 
 GO

Create Table KPP
(
   KPPId int identity primary key,
   KPPName nvarchar(32) not null
)

SET IDENTITY_INSERT KPP ON
 INSERT INTO KPP(KPPId,KPPName)
 VALUES
 (1,'Механика'),
 (2, 'Автомат') ,(3, 'вариатор');
 SET IDENTITY_INSERT KPP OFF
 
 GO

 Create Table DriveUnit
(
   DriveUnitId int identity primary key,
   DriveUnitName nvarchar(32) not null
)

SET IDENTITY_INSERT DriveUnit ON
 INSERT INTO DriveUnit(DriveUnitId,DriveUnitName)
 VALUES
 (1,'Передний'),
 (2, 'Задний') ,(3, 'Полный');
 SET IDENTITY_INSERT DriveUnit OFF
 
 GO

 Create Table Avto
(
   AvtoId int identity primary key,
   UserName nvarchar(256) not null,
   ModelAvtoId int foreign key REFERENCES ModelAvto(ModelAvtoId),
   AutoBodyId int foreign key REFERENCES AutoBody(AutoBodyId),
   YearAvto int not null check (YearAvto>=1930 and YearAvto<=Year(GetDate())),
   Price money not null default 0, 
   Engine int not null check (Engine>=500 and Engine<=7000),
   FuelId int foreign key REFERENCES Fuel(FuelId),
   KPPId int foreign key REFERENCES KPP(KPPId),
   DriveUnitId int foreign key REFERENCES DriveUnit(DriveUnitId),
   StateAvto nvarchar(1024) ,
   [Description] nvarchar(2048) not null ,
   Remark nvarchar(512)
)

Create Table Photo
(
   PhotoId int identity primary key,
   AvtoId int  foreign key REFERENCES Avto(AvtoId),
 
   PhotoPath nvarchar(512) not null
)


--•	Топливо
--•	КПП
--•	Привод
--•	Состояние
--•	Госномер
--•	IMEI
--•	Описание владельцем
--•	Примечания….
