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


CREATE TABLE IF NOT EXISTS `recordatorios` (
  `idrecordatorios` INT auto_increment,
  `notitas_id` INT NOT NULL,
  `fecha_recordatorio` DATETIME NULL,
  PRIMARY KEY (`idrecordatorios`),
  INDEX `fk_recordatorios_notitas1_idx` (`notitas_id` ASC) VISIBLE,
  CONSTRAINT `fk_recordatorios_notitas1`
    FOREIGN KEY (`notitas_id`)
    REFERENCES `NotasTareas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `archivos` (
  `idarchivos` INT auto_increment,
  `notitas_id` INT NOT NULL,
  `url` TEXT NOT NULL,
  `ruta` TEXT NULL,
  `descripcion` TEXT NULL,
  `tipo` INT NOT NULL DEFAULT 0,
  PRIMARY KEY (`idarchivos`),
  INDEX `fk_archivos_notitas_idx` (`notitas_id` ASC) VISIBLE,
  UNIQUE INDEX `notitas_idnotitas_UNIQUE` (`notitas_id` ASC) VISIBLE,
  CONSTRAINT `fk_archivos_notitas`
    FOREIGN KEY (`notitas_id`)
    REFERENCES `NotasTareas` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


INSERT INTO NotasTareas (titulo, contenido, estatus, tipo, fecha, fechaModi, fechaCum)
VALUES ("Hola", "Nota", 1, 2, "2022-01-10", "2022-01-9", "2022-01-12");
INSERT INTO NotasTareas (titulo, contenido, estatus, tipo, fecha, fechaModi, fechaCum)
VALUES ("Hola2", "Nota2", 2, 3, "2000-08-11", "2021-03-03", "1998-03-12");

insert into Recordatorios (notitas_id, fecha_recordatorio)
values (1, "2021-01-9");
insert into Recordatorios (notitas_id, fecha_recordatorio)
values (2, "2021-03-12");

select * from recordatorios;
select * from notastareas;

#Delete from recordatorios where idrecordatorios=1;