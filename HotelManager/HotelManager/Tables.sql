create database HotelManagement
go
use HotelManagement
go
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
Surcharge int not null default 0,
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