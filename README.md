Table of contents
=================


* [Status do Projeto](#project-status)
* [Funcionalidades](#funcionalidades)
* [Tecnologias](#tecnologias)
* [Scripts do Banco de Dados](#Banco-de-Dados)
* [Como Executar](#how-to-run)  


project status
==============

<h4> 
	✅ Versão 1.0.0 Conluída  ✅
	<br/> <br/>🚧 Versão 1.2.0 Em contrução  🚧
</h4>


funcionalidades
========

- [X] Login
- [X] Visualizar lista de Caronas
- [X] Ver detalhes de uma Carona
- [X] Cadastrar Carona
- [X] Realizar uma reserva de uma carona
- [X] Cancelar uma reserva
- [X] Validações
- [ ] Excluir uma carona
- [ ] Editar uma carona
- [ ] Cadastrar novo usuário


tecnologias
=====

Tecnologias utilizadas na construção do projeto
- [c#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [.Net](https://dotnet.microsoft.com/en-us/)
- [TypeScript](https://www.typescriptlang.org/)
- [Angular](https://angular.io/)
- [SQlite](https://www.sqlite.org/index.html)


Banco de Dados
=====

<h3>Scripts</h3>

<code>
CREATE TABLE `no_more_alone_db`.`user` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Nome` VARCHAR(100) NOT NULL,
  `Matricula` INT NOT NULL,
  `Telefone` VARCHAR(45) NULL,
  `Semestre` INT NULL,
  `Curso` VARCHAR(45) NULL,
  `Senha` VARCHAR(100) NULL,
  PRIMARY KEY (`Id`)
);
</code>
<br/> <br/>

<code>
CREATE TABLE `no_more_alone_db`.`carona` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Data` DATETIME NOT NULL,
  `PontoPartida` VARCHAR(100) NOT NULL,
  `PontoChegada` VARCHAR(100) NOT NULL,
  `QuantidadePessoas` INT NOT NULL,
  `Tipo` ENUM('CARRO', 'BUSAO') NOT NULL,
  `Preco` DECIMAL(19, 4) NULL,
  `Dono` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `Dono_idx` (`Dono` ASC) VISIBLE,
  CONSTRAINT `Dono`
    FOREIGN KEY (`Dono`)
    REFERENCES `no_more_alone_db`.`user` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);
</code>
<br/> <br/>

<code>
CREATE TABLE `no_more_alone_db`.`avaliacao_carona` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Comentario` VARCHAR(250) NULL,
  `Estrela` INT NOT NULL,
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
</code>
<br/> <br/>

<code>
CREATE TABLE `no_more_alone_db`.`endereco` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Rua` VARCHAR(150) NOT NULL,
  `Bairro` VARCHAR(50) NOT NULL,
  `CEP` INT NOT NULL,
  `Numero` INT NULL,
  `Cidade` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id`)
);
</code>
<br/> <br/>

<code>
CREATE TABLE `no_more_alone_db`.`carona_user` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `IdUsuario` INT NOT NULL,
  `IdCarona` INT NOT NULL,
  `DataReserva` DATETIME NOT NULL,
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
</code>
<br/> <br/>

<code>
ALTER TABLE `no_more_alone_db`.`user` 
ADD COLUMN `IdEndereco` INT NULL AFTER `Curso`,
ADD INDEX `IdEndereco_idx` (`IdEndereco` ASC) VISIBLE;
</code>
<br/> <br/>

<code>ALTER TABLE `no_more_alone_db`.`user` 
ADD CONSTRAINT `IdEndereco`
  FOREIGN KEY (`IdEndereco`)
  REFERENCES `no_more_alone_db`.`endereco` (`Id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
</code>
<br/> <br/>

<h3>Modelo entidade Relacionamento</h3>


<h3> Modelo Lógico</h3>

<strong>Userd</strong>(Id, Nome, Matricula, Telefone, Semestre, Curso, Senha, IdEndereco)
  <br/>IdEndereco References Endereco.Id

<strong>Caronad</strong>(Id, Data, PontoPartida, PontoChegada, QuantidadePessoas, Tipo, Preco, Dono)
  <br/>Dono References User.Id

<strong>Avaliacao_caronad</strong>(Id, Comentario, Estrela, IdCarona, IdUsuario)
  <br/>IdCarona References Carona.Id
  <br/>IdUsuario References User.Id

<strong>Enderecod</strong>(Id, Rua, Bairro, CEP, Numero, Cidade)

<strong>carona_user</strong>(Id, IdUsuario, IdCarona, DataReserva)
  <br/>IdCarona References Carona.Id
  <br/>IdUsuario References User.Id
