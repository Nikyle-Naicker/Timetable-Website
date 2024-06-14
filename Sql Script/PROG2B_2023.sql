create database Prog2B_2023;

create table Student(
Email nvarchar(200) primary key,
Password nvarchar(300));

create table Module(
ModuleID int Identity primary key,
ModuleCode nvarchar(10),
ModuleName nvarchar(100),
Credits int,
ClassHours int,
Username nvarchar(200) references Student(Email));

create table Semester(
SemesterID int IDENTITY primary key,
StartDate Date,
NumWeeks int,
Username nvarchar(200) references Student(Email));

create table Timetable(
WeekID int Identity primary key,
Username nvarchar(200) references Student(Email),
Week int,
SelfStudy int);


select * from Student;
select * from Module;
select * from Semester;
select * from Timetable;

truncate table Student;

drop table Student;
drop table Module;
drop table Semester;
drop table TimeTable;