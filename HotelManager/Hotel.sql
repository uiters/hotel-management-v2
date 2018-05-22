create database HotelManagement
GO
use HotelManagement
GO
create table STAFFTYPE
(
ID int primary key identity,
Name nvarchar(100)not null default N'No Name'
)
go
create table STAFF
(
UserName nvarchar(100) primary key,
DisplayName nvarchar(100) not null default N'No Name',
PassWord nvarchar(100) not null,
IDStaffType int foreign key references StaffType(ID) not null,
IDCard nvarchar(100) not null unique,
DateOfBirth Date not null,
Sex nvarchar(100) not null,
Address nvarchar(200) not null,
PhoneNumber int not null,
StartDay Date not null
)
go
create table CUSTOMERTYPE
(
ID int primary key identity,
Name nvarchar(100)not null default N'No Name'
)
GO
create table CUSTOMER
(
ID int PRIMARY KEY IDENTITY,
IDCard NVARCHAR(100) UNIQUE NOT NULL,
IDCustomerType int foreign key references CustomerType(ID) NOT null,
Name nvarchar(100) not null default N'No Name',
DateOfBirth Date not null,
Address nvarchar(200) not null,
PhoneNumber int not null,
Sex nvarchar(100) not null,
Nationality nvarchar(100) not null
)
go
create table STATUSROOM
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name'
)
go
create table ROOMTYPE
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name',
Price int not null,
LimitPerson int not null
)
go
create table ROOM
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name',
IDRoomType int foreign key references RoomType(ID) not null,
IDStatusRoom int foreign key references StatusRoom(ID) not null
)
GO
create table BOOKROOM
(
ID int primary key identity,
IDCustomer int foreign key references Customer(ID) not null,
IDRoomType int foreign key references RoomType(ID) not null,
DateBookRoom smalldatetime not null,
DateCheckIn date not null,
DateCheckOut date not null
)
GO
create table RECEIVEROOM
(
ID int primary key identity,
IDBookRoom int foreign key references BookRoom(ID)NOT null,
IDRoom int foreign key references Room(ID) not null
)
go
create table RECEIVEROOMDETAILS
(
IDReceiveRoom int foreign key references ReceiveRoom(ID) not null,
IDCustomerOther int foreign key references Customer(id) not null,
constraint PK_ReceiveRoomDetails primary key (IDReceiveRoom,IDCustomerOther)
)
go
create table SERVICETYPE
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name'
)
go
create table SERVICE
(
ID int primary key identity,
Name nvarchar(200) not null default N'No Name',
IDServiceType int foreign key references ServiceType(ID) not null,
Price int not null
)
GO
create table STATUSBILL
(
ID int primary key identity,
Name nvarchar(100) not null default N'No Name'
)
go
create table BILL
(
ID int primary key identity,
IDReceiveRoom int foreign key references ReceiveRoom(ID) not null,
StaffSetUp nvarchar(100) foreign key references Staff(UserName) not null,
DateOfCreate smalldatetime default getdate(),
RoomPrice int not null default 0,
ServicePrice int not null default 0,
TotalPrice int not null default 0,
Discount int not null default 0,
IDStatusBill int foreign key references StatusBill(ID) not null default 1
)
go
create table BILLDETAILS
(
IDBill int foreign key references Bill(ID) not null,
IDService int foreign key references Service(ID) not null,
Count int not null,
TotalPrice int not null default 0
constraint PK_BillInfo primary key(IDService,IDBill)
)
GO
create table PARAMETER
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
--------------------------------------------------------------

--Staff type
--------------------------------------------------------------

CREATE PROC USP_LoadFullStaffType
AS
begin
SELECT * FROM dbo.StaffType
end
go
--------------------------------------------------------------

--Staff 
--------------------------------------------------------------
CREATE PROC USP_SearchStaff
@string NVARCHAR(100), @int int
AS
BEGIN
	SELECT @string = '%' + [dbo].[ConvertString](@string) + '%'
	DECLARE @table TABLE( username NVARCHAR(100))
	IF(@int < 1)
	begin
		INSERT INTO @table SELECT username FROM staff 
		WHERE username LIKE @string OR [dbo].[ConvertString](DisplayName) LIKE @string
		OR  idcard LIKE @string
	END
	ELSE
    BEGIN
		INSERT INTO @table SELECT username FROM staff 
		WHERE username LIKE @string OR [dbo].[ConvertString](DisplayName) LIKE @string
		OR  idcard LIKE @string OR cast(PhoneNumber AS NVARCHAR(100)) LIKE @string
	END
	SELECT Staff.UserName, DisplayName, Name, IDCard, DateOfBirth, Sex, PhoneNumber, StartDay, Address, IDStaffType
    FROM dbo.Staff INNER JOIN  @table ON [@table].username = STAFF.UserName INNER JOIN dbo.StaffType ON StaffType.ID = Staff.IDStaffType
end
GO
CREATE PROC USP_LoadFullStaff
AS
BEGIN
	SELECT UserName, DisplayName, Name, IDCard,
			DateOfBirth, Sex, PhoneNumber, StartDay, Address, IDStaffType
    FROM dbo.Staff INNER JOIN dbo.StaffType ON StaffType.ID = Staff.IDStaffType
END
GO
CREATE PROC USP_InsertStaff
@user NVARCHAR(100), @name NVARCHAR(100), @pass NVARCHAR(100),
@idStaffType INT,@idCard NVARCHAR(100), @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay date
AS
BEGIN
	DECLARE @count INT =0
	SELECT @count = COUNT(*) FROM dbo.Staff WHERE UserName = @user OR IDCard = @idCard
	IF(@count >0) RETURN
	INSERT INTO dbo.Staff(UserName, DisplayName, PassWord, IDStaffType, IDCard, DateOfBirth, Sex, Address, PhoneNumber, StartDay)
	VALUES (@user, @name, @pass, @idStaffType,@idCard, @dateOfBirth, @sex, @address, @phoneNumber, @startDay)
END
GO
CREATE PROC USP_UpdateStaff
@user NVARCHAR(100), @name NVARCHAR(100),@idStaffType INT,
@idCard NVARCHAR(100), @dateOfBirth DATE, @sex NVARCHAR(100),
@address NVARCHAR(200), @phoneNumber INT, @startDay DATE
AS
BEGIN
	DECLARE @count INT = 0
	SELECT @count=COUNT(*) FROM staff
	WHERE IDCard = @idCard AND UserName != @user
	IF(@count = 0)
	UPDATE dbo.STAFF
	SET
    displayname = @name, idstafftype = @idstafftype,
	idcard= @idCard, DateOfBirth = @dateOfBirth, sex = @sex,
	Address = @address, PhoneNumber = @phoneNumber, StartDay = @startDay
	WHERE UserName = @user
END
go
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
---------------------------

--------------------------------------------------------------

--Service Type
--------------------------------------------------------------
CREATE PROC USP_SearchServiceType
@string NVARCHAR(100), @int INT
AS
BEGIN
	DECLARE @table table( id int)
	SELECT @string ='%' + [dbo].[ConvertString](@string) + '%'
	INSERT INTO @table SELECT id FROM ServiceType WHERE [dbo].[ConvertString](name) LIKE @string OR id = @int
	SELECT dbo.SERVICETYPE.ID, Name FROM @table INNER JOIN servicetype ON  SERVICETYPE.ID = [@table].id
END
go
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
CREATE PROC USP_LoadFullServiceType
AS
SELECT * FROM ServiceType
GO

--------------------------------------------------------------

--Service
--------------------------------------------------------------
GO
CREATE PROC USP_SearchService
@string NVARCHAR(100), @int int
AS
BEGIN
		DECLARE @table TABLE
		(
			id INT
		)
		SELECT @string = '%' + [dbo].[ConvertString](@string) + '%'
		INSERT INTO @table
			SELECT id FROM dbo.SERVICE WHERE [dbo].[ConvertString](name) like @string OR id = @int
		SELECT Service.ID, Service.Name, Price, ServiceType.Name AS [nameServiceType], IDServiceType
		FROM @table INNER JOIN dbo.SERVICE ON SERVICE.ID = [@table].id INNER JOIN dbo.ServiceType ON ServiceType.ID = Service.IDServiceType
END
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
CREATE PROC USP_LoadFullService
AS
SELECT Service.ID, Service.Name, Price, ServiceType.Name AS [nameServiceType], IDServiceType
FROM dbo.Service INNER JOIN dbo.ServiceType ON ServiceType.ID = Service.IDServiceType
GO
--------------------------------------------------------------

--Room
--------------------------------------------------------------
CREATE PROC USP_SearchRoom
@string NVARCHAR(100), @int INT
AS
BEGIN
	SELECT @string = '%' + [dbo].[convertString](@string) + '%'
	SELECT Room.ID, Room.Name,RoomType.Name AS [nameRoomType], Price, LimitPerson,
	StatusRoom.Name AS [nameStatusRoom], IDRoomType, IDStatusRoom
	FROM dbo.Room INNER JOIN dbo.RoomType ON roomtype.id = room.IDRoomType INNER JOIN dbo.StatusRoom ON statusroom.id = room.IDStatusRoom
	WHERE dbo.ConvertString(dbo.Room.name) LIKE @string OR dbo.Room.id = @int
END
go
CREATE PROC USP_LoadFullRoom
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
--------------------------------------------------------------

--Room Type
--------------------------------------------------------------
CREATE PROC USP_SearchRoomType
@string NVARCHAR(100), @int INT
AS
BEGIN
	SELECT @string = '%' + [dbo].[convertstring](@string) + '%'
	SELECT * FROM dbo.ROOMTYPE
	WHERE [dbo].[convertstring](name) LIKE @string OR id = @int
end
go
CREATE PROC USP_LoadFullRoomType
AS
SELECT * FROM dbo.RoomType
GO
CREATE PROC USP_UpdateRoomType
@id INT, @name NVARCHAR(100), @price int, @limitPerson int
AS
	UPDATE RoomType
	SET
    name = @name, Price = @price, LimitPerson = @limitPerson
	WHERE id =@id
go
--------------------------------------------------------------

--Status Room
--------------------------------------------------------------
CREATE PROC USP_LoadFullStatusRoom
AS
SELECT * FROM dbo.StatusRoom
GO
--------------------------------------------------------------
--parameter
--------------------------------------------------------------
CREATE PROC USP_SearchParameter
@string NVARCHAR(200)
AS
BEGIN
	SELECT @string = '%' + [dbo].[convertstring](@string) + '%'
	SELECT * FROM dbo.PARAMETER
	WHERE [dbo].[convertstring](name) like @string
END
GO
CREATE PROC USP_LoadFullParameter
AS
SELECT * FROM dbo.PARAMETER
GO
CREATE PROC USP_UpdateParameter
@name NVARCHAR(200), @value float, @describe NVARCHAR(200)
AS
BEGIN
UPDATE dbo.PARAMETER
	SET
	Value = @value,
	Describe = @describe
	WHERE name = @name
END
go
--------------------------------------------------------------
--Customer
--------------------------------------------------------------
GO
CREATE PROC USP_SearchCustomer
@string NVARCHAR(100), @int INT
AS
BEGIN
	SELECT @string = '%' + [dbo].[ConvertString](@string) +'%'
	DECLARE @table TABLE(id INT)
	IF(@int>0)
	BEGIN
		INSERT INTO @table
		SELECT id FROM dbo.CUSTOMER
		WHERE id = @int OR [dbo].[ConvertString](name) LIKE @string OR idcard LIKE @string OR CAST(PhoneNumber AS NVARCHAR(100)) LIKE @string
	END
	ELSE
    BEGIN
		INSERT INTO @table 
		SELECT id FROM customer
		WHERE [dbo].[ConvertString](name) LIKE @string OR idcard LIKE @string
	END
    SELECT CUSTOMER.ID, Customer.Name, IDCard, CustomerType.Name as [NameCustomerType], Sex, DateOfBirth, PhoneNumber, Address, Nationality, IDCustomerType 
	FROM dbo.Customer INNER JOIN @table ON [@table].id = CUSTOMER.ID INNER JOIN dbo.CustomerType ON CustomerType.ID = Customer.IDCustomerType
END
go
CREATE PROC USP_LoadFullCustomer
AS
SELECT CUSTOMER.ID, Customer.Name, IDCard, CustomerType.Name as [NameCustomerType], Sex, DateOfBirth, PhoneNumber, Address, Nationality, IDCustomerType 
FROM dbo.Customer INNER JOIN dbo.CustomerType ON CustomerType.ID = Customer.IDCustomerType
GO
CREATE PROC USP_InsertCustomer
@customerName NVARCHAR(100), @idCustomerType int, @idCard NVARCHAR(100),
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
@id INT, @customerName NVARCHAR(100), @idCustomerType int, @idCardNow NVARCHAR(100), @address NVARCHAR(200),
@dateOfBirth date, @phoneNumber int, @sex NVARCHAR(100), @nationality NVARCHAR(100), @idCardPre NVARCHAR(100)
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
			WHERE ID = @id
		END
	END
	ELSE
	BEGIN
		UPDATE dbo.Customer 
			SET 
			Name =@customerName, IDCustomerType = @idCustomerType,Address = @address,
			DateOfBirth =@dateOfBirth, PhoneNumber =@phoneNumber,
			Nationality = @nationality, Sex = @sex
			WHERE ID = @id
	end
END
go
--------------------------------------------------------------
--Customer Type
--------------------------------------------------------------

CREATE PROC USP_LoadFullCustomerType
AS
SELECT * FROM dbo.CustomerType
GO
--------------------------------------------------------------
--Function
--------------------------------------------------------------
CREATE FUNCTION [dbo].[ConvertString] ( @strInput NVARCHAR(4000) ) RETURNS NVARCHAR(4000) AS BEGIN IF @strInput IS NULL RETURN @strInput IF @strInput = '' RETURN @strInput DECLARE @RT NVARCHAR(4000) DECLARE @SIGN_CHARS NCHAR(136) DECLARE @UNSIGN_CHARS NCHAR (136) SET @SIGN_CHARS = N'ăâđêôơưàảãạáằẳẵặắầẩẫậấèẻẽẹéềểễệế ìỉĩịíòỏõọóồổỗộốờởỡợớùủũụúừửữựứỳỷỹỵý ĂÂĐÊÔƠƯÀẢÃẠÁẰẲẴẶẮẦẨẪẬẤÈẺẼẸÉỀỂỄỆẾÌỈĨỊÍ ÒỎÕỌÓỒỔỖỘỐỜỞỠỢỚÙỦŨỤÚỪỬỮỰỨỲỶỸỴÝ' +NCHAR(272)+ NCHAR(208) SET @UNSIGN_CHARS = N'aadeoouaaaaaaaaaaaaaaaeeeeeeeeee iiiiiooooooooooooooouuuuuuuuuuyyyyy AADEOOUAAAAAAAAAAAAAAAEEEEEEEEEEIIIII OOOOOOOOOOOOOOOUUUUUUUUUUYYYYYDD' DECLARE @COUNTER int DECLARE @COUNTER1 int SET @COUNTER = 1 WHILE (@COUNTER <=LEN(@strInput)) BEGIN SET @COUNTER1 = 1 WHILE (@COUNTER1 <=LEN(@SIGN_CHARS)+1) BEGIN IF UNICODE(SUBSTRING(@SIGN_CHARS, @COUNTER1,1)) = UNICODE(SUBSTRING(@strInput,@COUNTER ,1) ) BEGIN IF @COUNTER=1 SET @strInput = SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)-1) ELSE SET @strInput = SUBSTRING(@strInput, 1, @COUNTER-1) +SUBSTRING(@UNSIGN_CHARS, @COUNTER1,1) + SUBSTRING(@strInput, @COUNTER+1,LEN(@strInput)- @COUNTER) BREAK END SET @COUNTER1 = @COUNTER1 +1 END SET @COUNTER = @COUNTER +1 END SET @strInput = replace(@strInput,' ','-') RETURN @strInput END
go
INSERT INTO dbo.STAFFTYPE(name) VALUES( N'Quản lí')
INSERT INTO stafftype(name) VALUEs(N'Lễ Tân')
INSERT INTO stafftype(name) VALUEs (N'Khác')
GO
INSERT INTO statusroom(Name) VALUEs (N'Trống')
INSERT INTO statusroom(Name) VALUES( N'Có người')
INSERT INTO statusroom(Name) VALUES( N'Đang Sửa Chữa')
INSERT INTO statusroom(Name) VALUES( N'Khác')
GO
INSERT INTO customertype(Name) VALUES( N'Vip')
INSERT INTO customertype(Name) VALUES( N'Thường')
INSERT INTO customertype(Name) VALUES (N'Vãng Lai')
INSERT INTO customertype(Name) VALUES( N'Khác')
GO
INSERT INTO STAFF
(
    UserName,
    DisplayName,
    PassWord,
    IDStaffType,
    IDCard,
    DateOfBirth,
    Sex,
    Address,
    PhoneNumber,
    StartDay
)
VALUES
(   N'meomeo',       -- UserName - nvarchar(100)
    N'4 Chân',       -- DisplayName - nvarchar(100)
    N'e10adc3949ba59abbe56e057f20f883e',       -- PassWord - nvarchar(100)
    1,         -- IDStaffType - int
    N'M123456',       -- IDCard - nvarchar(100)
    GETDATE(), -- DateOfBirth - date
    N'Nam',       -- Sex - nvarchar(100)
    N'Trên Núi',       -- Address - nvarchar(200)
    047258369,         -- PhoneNumber - int
    GETDATE()  -- StartDay - date
    )

GO
INSERT INTO PARAMETER
(
    Name,
    Value,
    Describe
)
VALUES
(   N'QĐ 1', -- Name - nvarchar(200)
    1.5, -- Value - float
    N'Meo Meo'  -- Describe - nvarchar(200)
    )
GO
INSERT INTO PARAMETER
(
    Name,
    Value,
    Describe
)
VALUES
(   N'QĐ 2', -- Name - nvarchar(200)
    1.5, -- Value - float
    N'Gâu Gâu'  -- Describe - nvarchar(200)
    )
go

insert into Roomtype(Name, Price, LimitPerson) values ( N'Vip 1', 120000, 1)
insert into Roomtype(Name, Price, LimitPerson) values ( N'Vip 2', 150000, 2)
insert into Roomtype(Name, Price, LimitPerson) values ( N'Vip 3', 200000, 3)
insert into Roomtype(Name, Price, LimitPerson) values ( N'Vip 4', 250000, 4)
insert into Roomtype(Name, Price, LimitPerson) values ( N'Vip 5', 300000, 5)
go
CREATE TABLE REPORT
(
	idRoomType INT FOREIGN KEY REFERENCES ROOMTYPE(id) NOT NULL,
	value INT NOT NULL DEFAULT 0,
	rate FLOAT NOT NULL DEFAULT 0,
	Month INT NOT NULL DEFAULT 1,
	Year INT NOT NULL DEFAULT 1990,
	constraint PK_Report PRIMARY KEY(idRoomType, Month, YEAR)
)
GO
-- lấy id , ngày , tháng trong bill
-- insert Report
-- tồn tại trong report thì update
-- không tồn tại thì insert

ALTER TRIGGER UTG_InsertReport
ON bill FOR INSERT
AS
BEGIN
	DECLARE @month INT = 0
	DECLARE @year INT = 0
	DECLARE @id INT = 0
	DECLARE @price INT = 0
	SELECT @id = dbo.ROOM.IDRoomType, @month = MONTH(Inserted.DateOfCreate), @year = YEAR(Inserted.DateOfCreate), @price = Inserted.TotalPrice
	FROM Inserted INNER JOIN dbo.RECEIVEROOM ON RECEIVEROOM.ID = Inserted.IDReceiveRoom 
		INNER JOIN dbo.ROOM ON ROOM.ID = RECEIVEROOM.IDRoom
	DECLARE @count INT = 0	
	SELECT @count = COUNT(*) FROM report WHERE month = @month AND year = @year and idRoomType = @id
	IF(@count>0)
	BEGIN
		UPDATE dbo.REPORT SET value = value + @price WHERE Year = @year AND Month = @month AND idRoomType = @id
	END
    ELSE
    BEGIN
		INSERT report(idRoomType, value, Month, Year) VALUES(@id, @price, @month, @year)
	end
END
GO
INSERT dbo.BILL
(
    IDReceiveRoom,
    StaffSetUp,
    DateOfCreate,
    RoomPrice,
    ServicePrice,
    TotalPrice,
    Discount,
    IDStatusBill
)
VALUES
(   5,                     -- IDReceiveRoom - int
    N'meomeo',                   -- StaffSetUp - nvarchar(100)
    '2018-05-22 11:18:39', -- DateOfCreate - smalldatetime
    111,                     -- RoomPrice - int
    111,                     -- ServicePrice - int
    333,                     -- TotalPrice - int
    0,                     -- Discount - int
    1                      -- IDStatusBill - int
    )

GO
-- tinh tong doanh thu
-- tinh ti le cho tung phong
CREATE TRIGGER UTG_UpdateRateReport
ON dbo.REPORT FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @month INT = 0
	DECLARE @year INT = 0
	DECLARE @sum INT = 0
	SELECT @month = MONTH, @year = YEAR FROM Inserted
	SELECT @sum = SUM(dbo.REPORT.value)
	FROM dbo.REPORT
	WHERE Month = @month AND Year = @year
	UPDATE dbo.REPORT
	SET
		rate = ROUND((value * 100.0 / @sum), 2)
	WHERE Month = @month AND Year = @year
END
GO
CREATE PROC USP_LoadFullReport
@month INT, @year int
AS
BEGIN
	SELECT name, value, rate FROM dbo.REPORT INNER JOIN dbo.ROOMTYPE ON ROOMTYPE.ID = REPORT.idRoomType
	WHERE Month = @month AND Year = @year
END
GO

