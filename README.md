## Banco de dados

CREATE TABLE `no_more_alone_db`.`user` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(100) NOT NULL,
  `Matricula` INT NOT NULL,
  `Telefone` VARCHAR(45) NULL,
  `Semestre` INT NULL,
  `Curso` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `no_more_alone_db`.`carona` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Data` DATETIME NOT NULL,
  `PontoPartida` VARCHAR(100) NOT NULL,
  `PontoChegada` VARCHAR(100) NOT NULL,
  `QuantidadePessoas` INT NOT NULL,
  `Tipo` ENUM('CARRO', 'BUSAO') NOT NULL,
  `Dono` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `Dono_idx` (`Dono` ASC) VISIBLE,
  CONSTRAINT `Dono`
    FOREIGN KEY (`Dono`)
    REFERENCES `no_more_alone_db`.`user` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE `no_more_alone_db`.`avaliacao_carona` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Comentario` VARCHAR(250) NULL,
  `estrela` INT NOT NULL,
  `IdCarona` INT NOT NULL,
  `IdUsuario` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `Id_idx` (`IdCarona` ASC) VISIBLE,
  INDEX `IdUsuario_idx` (`IdUsuario` ASC) VISIBLE,
  CONSTRAINT `IdCarona`
    FOREIGN KEY (`IdCarona`)
    REFERENCES `no_more_alone_db`.`carona` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `IdUsuario`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `no_more_alone_db`.`user` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE `no_more_alone_db`.`endereco` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Rua` VARCHAR(150) NOT NULL,
  `Bairro` VARCHAR(50) NOT NULL,
  `CEP` INT NOT NULL,
  `Numero` INT NULL,
  `Cidade` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `no_more_alone_db`.`carona_user` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IdUsuario` INT NOT NULL,
  `IdCarona` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `IdCarona_idx` (`IdCarona` ASC) VISIBLE,
  INDEX `IdUsuario_idx` (`IdUsuario` ASC) VISIBLE,
  CONSTRAINT `IdCarona`
    FOREIGN KEY (`IdCarona`)
    REFERENCES `no_more_alone_db`.`carona` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `IdUsuario`
    FOREIGN KEY (`IdUsuario`)
    REFERENCES `no_more_alone_db`.`user` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);


ALTER TABLE `no_more_alone_db`.`user` 
ADD COLUMN `IdEndereco` INT NULL AFTER `Curso`,
ADD INDEX `IdEndereco_idx` (`IdEndereco` ASC) VISIBLE;
;
ALTER TABLE `no_more_alone_db`.`user` 
ADD CONSTRAINT `IdEndereco`
  FOREIGN KEY (`IdEndereco`)
  REFERENCES `no_more_alone_db`.`endereco` (`Id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
