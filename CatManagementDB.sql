CREATE DATABASE CatManagementDB

USE CatManagementDB

CREATE TABLE Accounts 
(
AccountID int primary key,
Username varchar(20) not null,
Password varchar(20) not null,
Fullname varchar(20),
RoleID int check(RoleID = 1 OR RoleID = 2), --(1 = Manager, 0 = Customer)
)

CREATE TABLE Services
(
ServiceID int primary key,
ServiceName nvarchar(50) not null,
ServicePrice int check(ServicePrice >= 0),
)

CREATE TABLE Cats
(
CatID int primary key,
AccountID int foreign key references Accounts(AccountID) on DELETE cascade,
Breed varchar(30) not null,
Color varchar(10) not null,
Sex varchar(10) check (Sex like 'MEOW' OR Sex like 'FEMEOW'),
)

CREATE TABLE RegisteredServices
(
RegisteredID int primary key,
AccountID int foreign key references Accounts(AccountID) on DELETE cascade,
CatID int foreign key references Cats(CatID) on DELETE cascade,
ServiceID int foreign key references Services(ServiceID) on DELETE cascade,
Date date,
Status int check(Status = 0 OR Status = 1), --(0 = Not Done, 1 = Done)
)