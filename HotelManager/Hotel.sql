create database Hotel
use Hotel
create table StaffType
(
ID int primary key identity,
Name nvarchar(100)not null default N'No Name'
)
go
create table Staff
(
UserName nvarchar(100) primary key,
DisplayName nvarchar(100) not null default N'No Name',
PassWord nvarchar(100) not null,
IDStaffType int foreign key references StaffType(ID) not null,
DateOfBirth Date not null,
Sex nvarchar(100) not null,
Address nvarchar(200) not null,
PhoneNumber int not null,
StartDay Date not null
)
go
create table CustomerType
(
ID int primary key identity,
Name nvarchar(100)not null default N'No Name'
)
go
create table Customer
(
IDCard int primary key,
IDCustomerType int foreign key references CustomerType(ID) not null,
Name nvarchar(100) not null default N'No Name',
DateOfBirth Date not null,
Address nvarchar(200) not null,
PhoneNumber int not null,
Sex nvarchar(100) not null,
Nationality nvarchar(100) not null
)
go
create table StatusRoom
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name'
)
go
create table RoomType
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name',
Price int not null,
LimitPerson int not null
)
go
create table Room
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name',
IDRoomType int foreign key references RoomType(ID) not null,
IDStatusRoom int foreign key references StatusRoom(ID) not null
)
go
create table BookRoom
(
ID int primary key identity,
IDCustomer int foreign key references Customer(IDCard) not null,
IDRoomType int foreign key references RoomType(ID) not null,
DateCheckIn date not null,
DateCheckOut date not null
)
create table ReceiveRoom
(
ID int foreign key references BookRoom(ID) not null,
IDRoom int foreign key references Room(ID) not null,
Amount int not null
primary key (ID)
)
go
create table ReceiveRoomDetails
(
IDReceiveRoom int foreign key references ReceiveRoom(ID) not null,
IDCustomerOther int foreign key references Customer(IDCard) not null,
primary key (IDReceiveRoom,IDCustomerOther)
)
go
create table ServiceType
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name'
)
go
create table Service
(
ID int primary key identity,
Name nvarchar(200) not null default N'No Name',
IDServiceType int foreign key references ServiceType(ID) not null,
Price int not null
)
go
create table Bill
(
ID int foreign key references ReceiveRoom(ID) not null,
StaffSetUp nvarchar(100) foreign key references Staff(UserName) not null,
DateOfCreate smalldatetime default getdate(),
TotalPrice int not null,
Discount int not null default 0,
Status nvarchar(100)  not null default N'Unpaid'
primary key(ID)
)
go
create table BillInfo
(
IDService int foreign key references Service(ID) not null,
IDBill int foreign key references Bill(ID) not null,
Count int not null
constraint PK_BillInfo primary key(IDService,IDBill)
)
go
create table Surcharge
(
Name nvarchar(200) not null default N'No Name',
Value float not null,
Describe nvarchar(200)
)
go


-------------------------------------------------------------


create proc USP_Login
@userName nvarchar(100),@passWord nvarchar(100)
as
Select * from Staff where UserName=@userName and PassWord=@passWord
GO
-------------------------
--Staff type
-------------------------
CREATE PROC USP_InsertStaffType
@name NVARCHAR(100)
AS
INSERT	dbo.StaffType(Name) VALUES(@name)
GO
CREATE PROC USP_UpdateStaffType
@id INT, @name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.StaffType
	SET
    name = @name
	WHERE ID = @id
END
GO
ALTER PROC USP_DeleteStaffType
@id INT
AS
BEGIN
		CREATE TABLE #temp(idBill INT, idStaff NVARCHAR(100))
		INSERT INTO #temp(idBill, idStaff)
		SELECT Bill.ID AS idBill, Bill.StaffSetUp AS idStaff
		FROM 
			Bill INNER JOIN Staff ON Bill.StaffSetUp = Staff.UserName
			INNER JOIN StaffType ON StaffType.ID = Staff.IDStaffType
		WHERE
			StaffType.ID = @id
		DELETE FROM dbo.BillInfo
		WHERE IDBill IN (SELECT idbill FROM #temp)
		DELETE FROM dbo.Bill
		WHERE ID IN (SELECT idbill FROM #temp)
		DELETE FROM dbo.ReceiveRoomDetails
		WHERE IDReceiveRoom IN (SELECT idbill FROM #temp)
		DELETE FROM dbo.ReceiveRoom
		WHERE ID IN (SELECT idbill FROM #temp)
		DELETE FROM dbo.BookRoom
		WHERE ID IN (SELECT idbill FROM #temp)
		DELETE FROM dbo.Staff
		WHERE UserName IN (SELECT DISTINCT(idStaff) FROM #temp)
		DELETE FROM dbo.StaffType
		WHERE ID = @id
		DROP TABLE #temp
END
-------------------------
--Staff 
-------------------------
GO
CREATE PROC USP_InsertStaff
@user NVARCHAR(100), @name NVARCHAR(100), @pass NVARCHAR(100),
@idStaffType INT, @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay date
AS
BEGIN
	INSERT INTO dbo.Staff(UserName, DisplayName, PassWord, IDStaffType, DateOfBirth, Sex, Address, PhoneNumber, StartDay)
	VALUES (@user, @name, @pass, @idStaffType, @dateOfBirth, @sex, @address, @phoneNumber, @startDay)
END
go
create PROC USP_UpdateStaff
@user NVARCHAR(100), @name NVARCHAR(100),
@idStaffType INT, @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay DATE
AS
BEGIN
	UPDATE dbo.Staff	
	SET
	DisplayName = @name, IDStaffType = @idStaffType,
	DateOfBirth = @dateOfBirth, sex = @sex,
	Address = @address, PhoneNumber = @phoneNumber, StartDay = @startDay
	WHERE UserName = @user
END
GO
CREATE PROC USP_UpdatePassword
@user NVARCHAR(100), @pass NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.Staff
	SET
    password = @pass
	WHERE username=@user
END
GO
CREATE PROC USP_DeleteStaff
@username NVARCHAR(100)
AS
BEGIN
	DECLARE @temp TABLE
	(
		id int
	)
	INSERT INTO @temp 
		SELECT id 
		FROM dbo.Bill INNER JOIN dbo.Staff ON Staff.UserName = Bill.StaffSetUp 
		WHERE UserName = @username
	DELETE FROM dbo.BillInfo
	WHERE IDBill IN (SELECT * FROM @temp)
	DELETE FROM dbo.Bill
	WHERE ID IN (SELECT * FROM @temp)
	DELETE FROM dbo.ReceiveRoomDetails
	WHERE IDReceiveRoom IN (SELECT * FROM @temp)
	DELETE FROM dbo.ReceiveRoom
	WHERE ID IN (SELECT * FROM @temp)
	DELETE FROM dbo.BookRoom
	WHERE ID IN (SELECT * FROM @temp)
	DELETE FROM dbo.Staff
	WHERE UserName = @username
	DELETE @temp
END
GO
-------------------------
--Service Type
-------------------------

CREATE PROC USP_InsertServiceType
@name NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.ServiceType(name)
	VALUES(@name)
END
GO
CREATE PROC USP_UpdateServiceType
@id INT, @name NVARCHAR
AS
BEGIN
	UPDATE dbo.ServiceType
	SET
    name = @name
	WHERE id =@id
END
-------------------------
--Service
-------------------------
GO
CREATE PROC USP_InsertService
@name NVARCHAR(200), @idServiceType INT, @price int
AS
BEGIN
	INSERT INTO dbo.Service(Name,IDServiceType,Price)
	VALUES(@name, @idServiceType, @price)
END
GO
create proc USP_UpdateService
@id int, @name nvarchar(200), @idServiceType int, @price int
as
begin
	update service
	set
	name = @name,
	idservicetype = @idservicetype,
	price = @price
	where id = @id
END
go
-------------------------
--Status Room
-------------------------
CREATE PROC USP_InsertStatusRoom
@name NVARCHAR(100)
AS
INSERT INTO statusroom(name) VALUES(@name)
GO
CREATE proc USP_UpdateStatusRoom
@id INT, @name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.StatusRoom
	SET
	name = @name
	WHERE
	id = @id
END
GO   

-------------------------
--Surcharge
-------------------------
CREATE PROC USP_InsertSurcharge
@name NVARCHAR(200), @value FLOAT, @describe NVARCHAR(200)
AS
INSERT INTO surcharge(name, Value, Describe) VALUES(@name, @value, @describe)
GO
CREATE PROC USP_UpdateSurcharge
@name NVARCHAR(200), @value float, @describe NVARCHAR(200)
AS
BEGIN
UPDATE dbo.Surcharge
	SET
	Value = @value,
	Describe = @describe
	WHERE name = @name
END
GO


