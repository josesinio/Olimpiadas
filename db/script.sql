-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema Olimpiadas
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema Olimpiadas
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Olimpiadas` DEFAULT CHARACTER SET utf8 ;
USE `Olimpiadas` ;

-- -----------------------------------------------------
-- Table `Olimpiadas`.`Persona`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Persona` (
  `nroDNI` INT NOT NULL,
  `nombre` VARCHAR(45) NULL,
  `apellido` VARCHAR(45) NULL,
  `nacimiento` VARCHAR(45) NULL,
  PRIMARY KEY (`nroDNI`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`FichaPaciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`FichaPaciente` (
  `id` VARCHAR(45) NOT NULL,
  `vacunas` INT NOT NULL,
  `enfermedades` VARCHAR(45) NULL,
  `alergias` VARCHAR(45) NULL,
  `tipoSangre` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`Paciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Paciente` (
  `nroDNI` INT NOT NULL,
  `fechaIngreso` VARCHAR(45) NULL,
  `nroafiliado` VARCHAR(45) NULL,
  `Persona_nroDNI` INT NOT NULL,
  `FichaPaciente_id` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`nroDNI`),
  INDEX `fk_Paciente_Persona1_idx` (`Persona_nroDNI` ASC) VISIBLE,
  INDEX `fk_Paciente_FichaPaciente1_idx` (`FichaPaciente_id` ASC) VISIBLE,
  CONSTRAINT `fk_Paciente_Persona1`
    FOREIGN KEY (`Persona_nroDNI`)
    REFERENCES `Olimpiadas`.`Persona` (`nroDNI`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Paciente_FichaPaciente1`
    FOREIGN KEY (`FichaPaciente_id`)
    REFERENCES `Olimpiadas`.`FichaPaciente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`PersonalMedico`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`PersonalMedico` (
  `matricula` VARCHAR(45) NOT NULL,
  `area` VARCHAR(45) NULL,
  `nombre` VARCHAR(45) NULL,
  `apellido` VARCHAR(45) NULL,
  `Paciente_Persona_dni` INT NULL,
  PRIMARY KEY (`matricula`),
  UNIQUE INDEX `Paciente_Persona_dni_UNIQUE` (`Paciente_Persona_dni` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`Atencion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Atencion` (
  `idAtencion` VARCHAR(45) NOT NULL,
  `matricula` INT NOT NULL,
  `idPaciente` VARCHAR(45) NULL,
  `descripcion` VARCHAR(45) NULL,
  `fecha` VARCHAR(45) NULL,
  `nroHabitacion` VARCHAR(45) NULL,
  `Paciente_nroDNI` INT NOT NULL,
  `PersonalMedico_matricula` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idAtencion`, `PersonalMedico_matricula`),
  UNIQUE INDEX `idPaciente_UNIQUE` (`idPaciente` ASC) VISIBLE,
  UNIQUE INDEX `matricula_UNIQUE` (`matricula` ASC) VISIBLE,
  INDEX `fk_Atencion_Paciente1_idx` (`Paciente_nroDNI` ASC) VISIBLE,
  INDEX `fk_Atencion_PersonalMedico1_idx` (`PersonalMedico_matricula` ASC) VISIBLE,
  CONSTRAINT `fk_Atencion_Paciente1`
    FOREIGN KEY (`Paciente_nroDNI`)
    REFERENCES `Olimpiadas`.`Paciente` (`nroDNI`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Atencion_PersonalMedico1`
    FOREIGN KEY (`PersonalMedico_matricula`)
    REFERENCES `Olimpiadas`.`PersonalMedico` (`matricula`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Usuario` (
  `idUsuario` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `contraseña` VARCHAR(45) NOT NULL,
  `idPersonal` VARCHAR(45) NOT NULL,
  `tipoUsuario` VARCHAR(45) NULL,
  `PersonalMedico_matricula` VARCHAR(45) NOT NULL,
  UNIQUE INDEX `idPersonal_UNIQUE` (`idPersonal` ASC) VISIBLE,
  PRIMARY KEY (`idUsuario`),
  INDEX `fk_Usuario_PersonalMedico1_idx` (`PersonalMedico_matricula` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_PersonalMedico1`
    FOREIGN KEY (`PersonalMedico_matricula`)
    REFERENCES `Olimpiadas`.`PersonalMedico` (`matricula`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`Personal`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Personal` (
  `idPersonal` INT NOT NULL,
  `usuario` VARCHAR(45) NULL,
  `nombre` VARCHAR(45) NULL,
  `apellido` VARCHAR(45) NULL,
  `area` VARCHAR(45) NULL,
  `Usuario_idUsuario` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idPersonal`),
  UNIQUE INDEX `area_UNIQUE` (`area` ASC) VISIBLE,
  INDEX `fk_Personal_Usuario1_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Personal_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `Olimpiadas`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Olimpiadas`.`Llamadas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Olimpiadas`.`Llamadas` (
  `idLlamadas` INT NOT NULL,
  `fechaHora` DATETIME NULL,
  `idAtencion` VARCHAR(45) NULL,
  `Atencion_idAtencion` VARCHAR(45) NOT NULL,
  `Atencion_PersonalMedico_matricula` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idLlamadas`),
  UNIQUE INDEX `idAtencion_UNIQUE` (`idAtencion` ASC) VISIBLE,
  INDEX `fk_Llamadas_Atencion1_idx` (`Atencion_idAtencion` ASC, `Atencion_PersonalMedico_matricula` ASC) VISIBLE,
  CONSTRAINT `fk_Llamadas_Atencion1`
    FOREIGN KEY (`Atencion_idAtencion` , `Atencion_PersonalMedico_matricula`)
    REFERENCES `Olimpiadas`.`Atencion` (`idAtencion` , `PersonalMedico_matricula`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
