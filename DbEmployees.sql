-- �������� ���� ������ DbEmployees
CREATE DATABASE DbEmployees;

USE DbEmployees;
--SELECT * FROM  Organizations;
--SELECT * FROM  Employees;

-- �������� ������� Organizations
CREATE TABLE Organizations (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Inn NVARCHAR(10) NOT NULL,
    LegalAdress NVARCHAR(50) NOT NULL,
    ActualAdress NVARCHAR(50) NOT NULL
);

-- �������� ������� Employees
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

-- ���������� ������� Organizations ���������� �������
INSERT INTO Organizations (Name, Inn, LegalAdress, ActualAdress)
VALUES 
    ('��������1', '1234567890', '����������� �����1', '����������� �����1'),
    ('��������2', '0987654321', '����������� �����2', '����������� �����2');

-- ���������� ������� Employees ���������� �������
INSERT INTO Employees (FirstName, SecondName, SeriesPassport, NumberPassport, BirthDate, OrganizationId)
VALUES 
    ('���1', '�������1', '1111', '123456', '1999-01-01 00:00:00.0000000', 1),
    ('���2', '�������2', '1111', '098765', '1995-05-15 00:00:00.0000000', 2);