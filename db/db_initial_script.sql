create database Notitas;
USE Notitas;
DROP TABLE if exists notastareas;

create table NotasTareas( id int primary key auto_increment, 
titulo varchar(100)  default '', 
contenido text null,
estatus int null,
tipo int default 1,
fecha datetime default current_timestamp,
fechaModi datetime default current_timestamp,
fechaCum datetime null
);

select * from NotasTareas;
