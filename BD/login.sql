create database inicio
use inicio

create table usuarios
(
users varchar(25), 
passwords varchar(25),
nivel varchar(25)
)

create proc _iniciosesion
@users varchar(25), 
@passwords varchar(25)
as
select *from usuarios where
users=@users and passwords=@passwords
go

create table crud
(
id varchar(35),
nombre varchar(35),
apellido varchar(35),
telefono varchar(35)
)

insert into crud values('R10', 'Rodrigo', 'Gutiérrez', '5442-7933')
