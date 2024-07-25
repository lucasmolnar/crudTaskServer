CREATE SCHEMA dbtarefa ;
CREATE TABLE dbtarefa.tarefa (
  codigo INT NOT NULL AUTO_INCREMENT,
  nome VARCHAR(45) NULL,
  descricao LONGTEXT NULL,
  concluida TINYINT NULL,
  PRIMARY KEY (codigo));
INSERT INTO dbtarefa.tarefa (nome, descricao, concluida) VALUES ('teste', 'teste', '0');
INSERT INTO dbtarefa.tarefa (nome, descricao, concluida) VALUES ('teste2', 'teste2', '1');