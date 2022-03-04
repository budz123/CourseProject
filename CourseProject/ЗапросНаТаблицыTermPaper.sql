use TermPaper

create table Clients(
ClientsID int primary key identity(1,1) not null,
[Name] varchar(255) not null,
LastName varchar(255) not null,
DateOfBirth date not null,
Gender varchar(255) not null,
PhoneNumber varchar(255) not null,
Passport varchar(255) not null,

);
create table Rooms(
RoomsID int primary key identity(1,1) not null,
Number varchar(255) not null,
[Floor] int not null,
[Type] varchar(255) not null,
Capfcity int not null,
[Status] varchar(255) not null,
Price varchar(255) not null,
);

create table Reservations(
ReservationsID int primary key iDenTITy(1,1) not null,
CheckInDate date not null,
CheckOutDate date not null,
RoomID int  not null,

ReservationStatus varchar(255) not null,
typePayment varchar(255) not null,
ClientID int  not null,
foreign key (ClientID) references Clients(ClientsID),
foreign key (RoomID) references Rooms(RoomsID)
);
SELECT * FROM Clients
Select * from Rooms
SELECT * FROM Reservations

DROP TABLE Clients
DROP TABLE Rooms
DROP TABLE Reservations