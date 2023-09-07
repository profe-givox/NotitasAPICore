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


#COMENTARIO DE PRUEBA POR QUE NO SE USAR ESTO


CREATE TABLE IF NOT EXISTS `recordatorios` (
  `idrecordatorios` INT NOT NULL,
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
  `idarchivos` INT NOT NULL,
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

select * from NotasTareas;
