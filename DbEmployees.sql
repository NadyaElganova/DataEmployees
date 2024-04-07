-- Создание базы данных DbEmployees
CREATE DATABASE DbEmployees;

USE DbEmployees;
--SELECT * FROM  Organizations;
--SELECT * FROM  Employees;

-- Создание таблицы Organizations
CREATE TABLE Organizations (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Inn NVARCHAR(10) NOT NULL,
    LegalAdress NVARCHAR(50) NOT NULL,
    ActualAdress NVARCHAR(50) NOT NULL
);

-- Создание таблицы Employees
CREATE TABLE Employees (
    Id INT IDENTITY PRIMARY KEY,
    FirstName NVARCHAR(40) NOT NULL,
    SecondName NVARCHAR(50) NOT NULL,
    SeriesPassport NVARCHAR(4) NOT NULL,
    NumberPassport NVARCHAR(6) NOT NULL,
    BirthDate DATE NOT NULL,
    OrganizationId INT,
    FOREIGN KEY (OrganizationId) REFERENCES Organizations(Id)
);

-- Наполнение таблицы Organizations начальными данными
INSERT INTO Organizations (Name, Inn, LegalAdress, ActualAdress)
VALUES 
    ('Название1', '1234567890', 'Юридический адрес1', 'Фактический адрес1'),
    ('Название2', '0987654321', 'Юридический адрес2', 'Фактический адрес2');

-- Наполнение таблицы Employees начальными данными
INSERT INTO Employees (FirstName, SecondName, SeriesPassport, NumberPassport, BirthDate, OrganizationId)
VALUES 
    ('Имя1', 'Фамилия1', '1111', '123456', '1999-01-01 00:00:00.0000000', 1),
    ('Имя2', 'Фамилия2', '1111', '098765', '1995-05-15 00:00:00.0000000', 2);