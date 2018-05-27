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
go
create proc USP_RoomTypeInfo
@id int
as
begin
select * 
from RoomType
where ID=@id
end
go

