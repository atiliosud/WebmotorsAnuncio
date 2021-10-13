# Gerenciador Anuncios

## Iniciando

Altere a variavel configuration > appSettings > ConnectionString 
do arquivo WebmotorsAnuncio/Web.config
para a sua string de conexão

a base de dado deve conter o script:

```sql
create database teste_webmotors
go --apenas MSSQL
create table teste_webmotors..tb_AnuncioWebmotors(
ID INT identity not null, marca varchar (45) not
null, modelo varchar (45) not null, versao
varchar (45) not null, ano INT not null,
quilometragem INT not null, observacao text not
null
)

```

