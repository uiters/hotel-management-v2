create database Hotel
GO
use Hotel
GO
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
IDStaffType int foreign key references StaffType(ID) ON DELETE CASCADE not null,
IDCard nvarchar(100) not null unique,
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
IDCustomerType int foreign key references CustomerType(ID) ON DELETE CASCADE not null,
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
IDRoomType int foreign key references RoomType(ID) ON DELETE CASCADE not null,
IDStatusRoom int foreign key references StatusRoom(ID) ON DELETE CASCADE not null
)
GO
create table BookRoom
(
ID int primary key identity,
IDCustomer int foreign key references Customer(IDCard) ON DELETE CASCADE not null,
IDRoomType int foreign key references RoomType(ID) ON DELETE CASCADE NOT null,
DateBookRoom smalldatetime not null,
DateCheckIn date not null,
DateCheckOut date not null
)
GO
create table ReceiveRoom
(
ID int primary key identity,
IDBookRoom int foreign key references BookRoom(ID) ON DELETE CASCADE NOT null,
IDRoom int foreign key references Room(ID) not null
)
go
create table ReceiveRoomDetails
(
IDReceiveRoom int foreign key references ReceiveRoom(ID) ON DELETE CASCADE not null,
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
IDServiceType int foreign key references ServiceType(ID)  ON DELETE CASCADE  not null,
Price int not null
)
go
create table Bill
(
ID int primary key identity,
IDReceiveRoom int foreign key references ReceiveRoom(ID) ON DELETE CASCADE not null,
StaffSetUp nvarchar(100) foreign key references Staff(UserName) ON DELETE CASCADE not null,
DateOfCreate smalldatetime default getdate(),
TotalPrice int not null,
Discount int not null default 0,
Status nvarchar(100)  not null default N'Unpaid'
)
go
create table BillDetails
(
IDService int foreign key references Service(ID) not null,
IDBill int foreign key references Bill(ID) not null,
Count int not null
constraint PK_BillDetails primary key(IDService,IDBill)
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
create proc USP_RoomTypeInfo
@id int
as
begin
select * 
from RoomType
where ID=@id
end
go
create proc USP_IsIdCardExists
@idCard int
as
begin
select *
from Customer
where IDCard=@idCard
end
go
create proc USP_InsertCustomer
@idCard int,@name nvarchar(100),@idCustomerType int, @dateOfBirth Date,@address nvarchar(200),@phoneNumber int,@sex nvarchar(100),@nationality nvarchar(100)
as
begin
	insert into Customer(IDCard,Name,IDCustomerType,DateOfBirth,Address,PhoneNumber,Sex,Nationality)
	values(@idCard,@name,@idCustomerType,@dateOfBirth,@address,@phoneNumber,@sex,@nationality)
end
go
create proc USP_GetCustomerTypeNameByIdCard
@idCard int
as
begin
	select B.Name
	from Customer A, CustomerType B
	where A.IDCustomerType=B.ID and A.IDCard=@idCard
end
go
create proc USP_InsertBookRoom
@idCustomer int,@idRoomType int,@datecheckin date,@datecheckout date,@datebookroom smalldatetime
as
begin
	insert into BookRoom (IDCustomer,IDRoomType,DateCheckIn,DateCheckOut,DateBookRoom)
	values(@idCustomer,@idRoomType,@datecheckin,@datecheckout,@datebookroom)
end
go
create proc USP_LoadBookRoomsByDate
@date Date
as
begin
	select A.ID[Mã đặt phòng], b.Name[Họ và tên],b.IDCard[CMND],C.Name[Loại phòng],A.DateCheckIn[Ngày nhận],A.DateCheckOut[Ngày trả]
	from BookRoom A,Customer B, RoomType C
	where a.IDRoomType=c.ID and A.IDCustomer=B.IDCard and A.DateBookRoom>=@date
	order by A.DateBookRoom desc
end
go
create proc USP_LoadStaffInforByUserName
@username nvarchar(100)
as
begin
	select *
	from Staff
	where UserName=@username
end
go
create proc USP_GetNameStaffTypeByUserName
@username nvarchar(100)
as
begin
	select B.*
	from Staff A, StaffType B
	where a.IDStaffType=B.ID and A.UserName=@username
end
go
create proc USP_UpdateAccount1
@username nvarchar(100),@displayname nvarchar(100)
as
begin
	update Staff
	set DisplayName=@displayname
	where UserName=@username
end
go
create proc USP_UpdateAccount2
@username nvarchar(100),@password nvarchar(100)
as
begin
	update Staff
	set PassWord=@password
	where UserName=@username
end
go
create proc USP_UpdateAccount3
@username nvarchar(100),@address nvarchar(100),@phonenumber int
as
begin
	update Staff
	set Address=@address,PhoneNumber=@phonenumber
	where UserName=@username
end
go
create proc USP_LoadEmptyRoom
@idRoomType int
as
begin
	declare @idStatusRoom int
	select @idStatusRoom=ID
	from StatusRoom
	where Name=N'Trống'
	select *
	from Room
	where IDStatusRoom=@idStatusRoom and IDRoomType=@idRoomType
end
go
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
CREATE PROC USP_DeleteStaffType
@id INT
AS
BEGIN
		DELETE FROM dbo.StaffType
		WHERE ID = @id
END
GO
CREATE PROC USP_LoadFullStaffType
AS
SELECT * FROM dbo.StaffType
-------------------------
--Staff 
-------------------------
GO
CREATE PROC USP_LoadFullStaff
AS
BEGIN
	SELECT UserName, DisplayName, IDStaffType, Name,IDCard,
			DateOfBirth, Sex,Address,PhoneNumber,StartDay
    FROM dbo.Staff INNER JOIN dbo.StaffType ON StaffType.ID = Staff.IDStaffType
END
GO
ALTER PROC USP_InsertStaff
@user NVARCHAR(100), @name NVARCHAR(100), @pass NVARCHAR(100),
@idStaffType INT,@idCard INT, @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay date
AS
BEGIN
	DECLARE @count INT =0
	SELECT @count = COUNT(*) FROM dbo.Staff WHERE UserName = @user OR IDCard = @idCard
	IF(@count >0) RETURN
	INSERT INTO dbo.Staff(UserName, DisplayName, PassWord, IDStaffType, IDCard, DateOfBirth, Sex, Address, PhoneNumber, StartDay)
	VALUES (@user, @name, @pass, @idStaffType,@idCard, @dateOfBirth, @sex, @address, @phoneNumber, @startDay)
END
go
ALTER PROC USP_UpdateStaff
@user NVARCHAR(100), @name NVARCHAR(100), @pass NVARCHAR(100),
@idStaffType INT, @idCard INT, @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay date
AS
BEGIN
	DECLARE @count INT =0
	SELECT @count=COUNT(*) FROM dbo.Staff WHERE IDCard = @idCard AND UserName != @user
	IF (@count >0) RETURN
	IF(@pass= '')
	BEGIN
		UPDATE dbo.Staff	
		SET
		DisplayName = @name, IDStaffType = @idStaffType,
		DateOfBirth = @dateOfBirth, sex = @sex, IDCard = @idCard,
		Address = @address, PhoneNumber = @phoneNumber, StartDay = @startDay
		WHERE UserName = @user
	end
	ELSE
	BEGIN
		UPDATE dbo.Staff	
		SET
		DisplayName = @name, IDStaffType = @idStaffType,
		DateOfBirth = @dateOfBirth, sex = @sex, IDCard = @idCard,
		Address = @address, PhoneNumber = @phoneNumber, StartDay = @startDay, PassWord = @pass
		WHERE UserName = @user
    end
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
	DELETE FROM dbo.Staff
	WHERE UserName = @username
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
@id INT, @name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.ServiceType
	SET
    name = @name
	WHERE id =@id
END
GO
CREATE PROC USP_DeleteServiceType
@id INT
AS
BEGIN
	DELETE FROM dbo.ServiceType
	WHERE id = @id
END
GO
CREATE PROC USP_LoadFullServiceType
AS
SELECT * FROM ServiceType
GO

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
GO
CREATE PROC USP_DeleteService
@id INT
AS
BEGIN
	DELETE FROM dbo.Service
	WHERE ID  = @id
END
GO
CREATE PROC USP_LoadFullService
AS
SELECT Service.ID, Service.Name, Price, ServiceType.Name AS [nameServiceType], IDServiceType
FROM dbo.Service INNER JOIN dbo.ServiceType ON ServiceType.ID = Service.IDServiceType
GO
------------------------
--Room
------------------------
ALTER PROC USP_LoadFullRoom
AS
SELECT Room.ID, Room.Name,RoomType.Name AS [nameRoomType], Price, LimitPerson,
StatusRoom.Name AS [nameStatusRoom], IDRoomType, IDStatusRoom
FROM dbo.Room INNER JOIN dbo.RoomType 
ON roomtype.id = room.IDRoomType
INNER JOIN dbo.StatusRoom ON statusroom.id = room.IDStatusRoom
GO
CREATE PROC USP_InsertRoom
@nameRoom NVARCHAR(100), @idRoomType INT, @idStatusRoom INT
AS
INSERT INTO dbo.Room(Name, IDRoomType, IDStatusRoom)
VALUES(@nameRoom, @idRoomType, @idStatusRoom)
GO
CREATE PROC USP_UpdateRoom
@id INT, @nameRoom NVARCHAR(100), @idRoomType INT, @idStatusRoom INT
AS
UPDATE dbo.Room
SET
	Name = @nameRoom, IDRoomType = @idRoomType, IDStatusRoom = @idStatusRoom
WHERE ID = @id
go
------------------------
--Room Type
------------------------
CREATE PROC USP_LoadFullRoomType
AS
SELECT * FROM dbo.RoomType
GO
CREATE PROC USP_InsertRoomType
@name NVARCHAR(100), @price int, @limitPerson int
AS
INSERT INTO RoomType(Name, Price, LimitPerson) VALUES(@name, @price, @limitPerson)
GO
CREATE PROC USP_UpdateRoomType
@id INT, @name NVARCHAR(100), @price int, @limitPerson int
AS
	UPDATE RoomType
	SET
    name = @name, Price = @price, LimitPerson = @limitPerson
	WHERE id =@id
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
CREATE PROC USP_DeleteStatusRoom
@id INT
AS
BEGIN
	DELETE FROM dbo.StatusRoom
	WHERE ID = @id
END
GO
CREATE PROC USP_LoadFullStatusRoom
AS
SELECT * FROM dbo.StatusRoom
GO
-------------------------
--Surcharge
-------------------------
GO
--CREATE PROC USP_InsertSurcharge
--@name NVARCHAR(200), @value FLOAT, @describe NVARCHAR(200)
--AS
--INSERT INTO surcharge(name, Value, Describe) VALUES(@name, @value, @describe)
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
--CREATE PROC USP_DeleteSurcharge
--@name NVARCHAR(200)
--AS
--BEGIN
--	DELETE FROM dbo.Surcharge
--	WHERE Name = @name
--END
GO
------------------------
--Customer
------------------------
CREATE PROC USP_LoadFullCustomer
AS
SELECT TOP(100) Customer.Name, IDCard, CustomerType.Name as [NameCustomerType], Sex, DateOfBirth, PhoneNumber, Address, Nationality, IDCustomerType 
FROM dbo.Customer INNER JOIN dbo.CustomerType ON CustomerType.ID = Customer.IDCustomerType
GO
CREATE PROC USP_InsertCustomer
@customerName NVARCHAR(100), @idCustomerType int, @idCard int,
@address NVARCHAR(200), @dateOfBirth date, @phoneNumber int,
@sex NVARCHAR(100), @nationality NVARCHAR(100)
AS
BEGIN
DECLARE @count INT =0
SELECT @count = COUNT(*) FROM customer WHERE IDCard = @idCard
IF(@count=0)
INSERT INTO dbo.Customer(IDCard,IDCustomerType, Name, DateOfBirth, Address, PhoneNumber, Sex, Nationality)
	VALUES(@idCard, @idCustomerType, @customerName, @dateOfBirth, @address, @phoneNumber, @sex, @nationality)
end
GO
CREATE PROC USP_UpdateCustomer
@customerName NVARCHAR(100), @idCustomerType int, @idCardNow int, @address NVARCHAR(200),
@dateOfBirth date, @phoneNumber int, @sex NVARCHAR(100), @nationality NVARCHAR(100),
@idCardPre int
AS
BEGIN
	IF(@idCardPre != @idCardNow)
	begin
		DECLARE @count INT=0
		SELECT @count=COUNT(*)
		FROM dbo.Customer
		WHERE IDCard = @idCardNow
		IF(@count=0)
		BEGIN
			UPDATE dbo.Customer 
			SET 
			Name =@customerName, IDCustomerType = @idCustomerType, IDCard =@idCardNow,
			Address = @address, DateOfBirth =@dateOfBirth, PhoneNumber =@phoneNumber,
			Nationality = @nationality, Sex = @sex
			WHERE IDCard = @idCardPre
		END
	END
	ELSE
	BEGIN
		UPDATE dbo.Customer 
			SET 
			Name =@customerName, IDCustomerType = @idCustomerType, IDCard =@idCardNow,
			Address = @address, DateOfBirth =@dateOfBirth, PhoneNumber =@phoneNumber,
			Nationality = @nationality, Sex = @sex
			WHERE IDCard = @idCardPre
	end
END
go
------------------------
--Customer Type
------------------------
CREATE PROC USP_LoadFullCustomerType
AS
SELECT * FROM dbo.CustomerType
GO
CREATE PROC USP_InsertCustomerType
@name NVARCHAR(100)
AS
INSERT INTO dbo.CustomerType(Name) VALUES(@name)
GO
CREATE PROC USP_UpdateCustomerType
@id int, @name NVARCHAR(100)
AS
BEGIN
	UPDATE dbo.CustomerType
	SET
    Name = @name
	WHERE id = @id
END
