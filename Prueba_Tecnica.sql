create table employees (
documentId int primary key,
name varchar(50) not null,
currentPosition varchar(50) not null,
salary decimal not null,
departmentId int not null,
projectId int,
foreign key (projectId) references projects(id),
foreign key (departmentId) references departments(id)
);

create table departments (
id int primary key AUTO_INCREMENT,
name varchar(50) not null
);

create table projects (
id int primary key AUTO_INCREMENT,
name varchar(50) not null,
description varchar(100) not null
);

create table positionHistory (
id int primary key AUTO_INCREMENT, 
documentId int not null,
position varchar(50) not null,
startDate Datetime not null,
endDate datetime null
);
