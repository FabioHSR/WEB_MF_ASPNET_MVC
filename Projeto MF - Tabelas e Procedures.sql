--CREATE DATABASE WEBMF2

CREATE TABLE Funcionarios(
	Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nome varchar(max) NOT NULL,
	Setor varchar(max) NOT NULL,
	Usuario varchar(20) NOT NULL,
	Senha varchar(10) NOT NULL,
	StatusAtividade varchar(max) DEFAULT 'ATIVO'
	CONSTRAINT AK_Usuario UNIQUE(Usuario)  
)

CREATE TABLE Clientes(
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Fantasia varchar (max) NOT NULL,
    Representante int NOT NULL,
    Envio varchar(max) NULL, 
    Obs varchar(max) NULL,
	StatusAtividade varchar(max) DEFAULT 'ATIVO'
	FOREIGN KEY (Representante) REFERENCES Funcionarios(Id)
)

CREATE TABLE Unidades(
    Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Unidade varchar(max) NOT NULL,
    Obs varchar(max) NULL,
    Envio varchar(max) NULL,
    ClienteId int NOT NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(Id)
)

CREATE TABLE Projetos(
    [Id] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [NomeProjeto] varchar(max) NOT NULL,
    [BoxFoto] varchar(max) NOT NULL,
    [Espessura] varchar(max) NOT NULL,
    [Tecnologia] varchar(max) NOT NULL,
    [Adesivo] varchar(max) NOT NULL,
    [Furo] varchar(max) NOT NULL,
    [Termo] varchar(max) NOT NULL,
    [ProjTermo] varchar(max) NULL,
    [Imagem] varbinary(max) NOT NULL,
    [TarjaMag] varchar(max) NOT NULL,
    [Obs] varchar(max) NULL,
    [ClienteID] int NOT NULL,
    [UnidadeID] int NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(Id),
    FOREIGN KEY (UnidadeId) REFERENCES Unidades(Id)
)


CREATE TABLE OS(
	[Id] int IDENTITY(1001,1) NOT NULL PRIMARY KEY,
	[Status] varchar(max) NOT NULL,
	[ClienteId] int NOT NULL,
	[Orientacao] varchar(max) NULL,
	[Termo] varchar(max) NULL,
	[Obs] varchar(max) NULL,
	[Multi] varchar(max) NULL,
	[OsTipo] varchar(max) NOT NULL,
	[Inicio] datetime NULL,
	[Fim] datetime NULL,
	[Foto] int NULL,
	[Link] int NULL,
	[Impressao] int NULL,
	[Laminacao] int NULL,
	[Corte] int NULL,
	[Ordenacao] int NULL,
	[Ribbon] varchar(max) NULL,
	[Overlay] varchar(max) NULL,
	[TermoOp] int NULL,
	[ConfOP] int NULL,
	[TotalProduzido] int NULL,
	[Emails] varchar(max) NULL,
    FOREIGN KEY (ClienteID) REFERENCES Clientes(Id),
    FOREIGN KEY (Foto)      REFERENCES Funcionarios(Id),
    FOREIGN KEY (Link)      REFERENCES Funcionarios(Id),
    FOREIGN KEY (Impressao) REFERENCES Funcionarios(Id),
    FOREIGN KEY (Laminacao) REFERENCES Funcionarios(Id),
    FOREIGN KEY (Corte)     REFERENCES Funcionarios(Id),
    FOREIGN KEY (Ordenacao) REFERENCES Funcionarios(Id),
    FOREIGN KEY (TermoOp)   REFERENCES Funcionarios(Id)
)

CREATE TABLE ProjetosOS(
	[OsId] int NOT NULL,
	[ProjetoId] int NOT NULL,
	PRIMARY KEY (OsId,ProjetoId),
	FOREIGN KEY (OsId)      REFERENCES OS(Id),
	FOREIGN KEY (ProjetoId) REFERENCES Projetos(Id)
)




---------------------------------------------------------------------------
-- Criação de Procedures
GO
CREATE PROCEDURE sp_InsertProjetoOS
@OsId int,
@ProjetoId int
as
begin
	INSERT INTO ProjetosOS (OsId,ProjetoId) values (@OsId,@ProjetoId)
end

GO
CREATE PROCEDURE sp_DeleteProjetoOS
@OsId int
as
begin
	DELETE FROM ProjetosOS WHERE OsId=@OsId
end
GO
create procedure spListagem(@tabela varchar(max), @ordem varchar(max))
    as
        begin			
            exec('select * from ' + @tabela + ' order by ' + @ordem)
    end
GO

create procedure spDelete(@id int, @tabela varchar(max))
    as
        begin
            exec('delete from ' + @tabela + ' where id=' + @id)
        end
GO

create procedure spLogin
@user varchar(max),
@senha varchar(max)
as
begin
	SELECT * FROM Funcionarios WHERE usuario = @user and Senha = @senha
end
go

create procedure spProximoId(@tabela varchar(max))
	as
		begin			
			exec('select isnull(max(id) + 1 , 1 ) as MAIOR from ' + @tabela)
	end
GO

create procedure spConsulta(@id int, @tabela varchar(max))
	as
		begin			
			declare @sql varchar(max);
			set @sql = ' select * from ' + @tabela + ' where id = ' + cast(@id as varchar(max))
		exec (@sql)
	end
GO

create procedure spInsertClientes
@Id int,
@Fantasia varchar(max), 
@Representante int, 
@Envio varchar(max) = null, 
@Obs varchar(max) = null
as
begin 
 INSERT INTO Clientes (Fantasia,Representante,Envio,Obs) VALUES (@Fantasia,@Representante,@Envio,@Obs)
end
GO

create procedure spDeleteCliente @Id int
as
begin
	update clientes set StatusAtividade = 'INATIVO' where Id = @Id
end
GO

create procedure spListagemClientes
as
begin
	select * from clientes where StatusAtividade = 'ATIVO'
end
GO

create procedure spListagemFuncionarios
as
begin
	select * from Funcionarios where StatusAtividade = 'ATIVO'
end
GO

create procedure spUpdateClientes(@Id int, @Fantasia varchar(max)=NULL, @Representante int, @Envio varchar(max)=NULL, @Obs varchar(max)=NULL)
as
        begin
        UPDATE Clientes SET Fantasia=@Fantasia,Representante=@Representante,Envio=@Envio,Obs=@Obs WHERE Id = @Id
end


GO
create procedure spInsertOS(
@Id int, @Status varchar(max) = null, @OSTipo varchar(max) = null, @Orientacao varchar(max) = null, 
@Termo varchar(max) = null, @Ribbon varchar(max) = null, @Overlay varchar(max) = null, @ClienteId varchar(max) = null, 
@Multi varchar(max) = null, @Inicio datetime = null, @Fim datetime = null, @Foto int, @Link int, @Impressao int, @Laminacao int, @Corte int, 
@Ordenacao int, @TermoOp int, @ConfOP int, @Obs varchar(max) = null, @TotalProduzido int, @TotalSolicitado int, @Emails varchar(max) = null)   
as
        begin
            INSERT INTO OS (Status,OSTipo,Orientacao,Termo,Ribbon,Overlay,ClienteId,Multi,Inicio,Fim,Foto,Link,Impressao,Laminacao,Corte,Ordenacao,TermoOp,ConfOP,Obs,TotalProduzido,Emails) 
                 VALUES (@Status,@OSTipo,@Orientacao,@Termo,@Ribbon,@Overlay,@ClienteId,@Multi,@Inicio,@Fim,@Foto,@Link,@Impressao,@Laminacao,@Corte,@Ordenacao,@TermoOp,@ConfOP,@Obs,@TotalProduzido,@Emails)
        end
GO


create procedure spUpdateOS
@Id int, @Status varchar(max), @OSTipo varchar(max), @Orientacao varchar(max) = null,
@Termo varchar(max) = null, @Ribbon varchar(max) = null, @Overlay varchar(max) = null,
@ClienteId varchar(max) = null, @Multi varchar(max) = null, @Inicio datetime = null, @Fim datetime = null, @Foto int = null, 
@Link int = null, @Impressao int = null, @Laminacao int = null, @Corte int = null, 
@Ordenacao int = null, @TermoOp int = null, @ConfOP int = null, @Obs varchar(max) = null, 
@TotalProduzido int = null, @Emails varchar(max) = null
    as
        begin
            UPDATE OS SET Status=@Status,OSTipo=@OSTipo,Orientacao=@Orientacao,Termo=@Termo,Ribbon=@Ribbon,Overlay=@Overlay,ClienteId=@ClienteId,
                 Multi=@Multi,Inicio=@Inicio,Fim=@Fim,Foto=@Foto,Link=@Link,Impressao=@Impressao,Laminacao=@Laminacao,Corte=@Corte,Ordenacao=@Ordenacao,
				 TermoOp=@TermoOp,ConfOP=@ConfOP, Obs=@Obs,TotalProduzido=@TotalProduzido,Emails=@Emails WHERE Id = @Id
        end
GO

create procedure spListagemProjetosPorCliente(@ClienteId int)
    as 
        begin
            select * from Projetos WHERE ClienteId = @ClienteId
        end
GO

create procedure spInsertProjetos(@Id int, @NomeProjeto varchar(max)= null,@BoxFoto varchar(max)= null,
@Espessura varchar(max)= null,@Tecnologia varchar(max)= null,@Adesivo varchar(max)= null,
@Furo varchar(max)= null,@Termo varchar(max)= null,@ProjTermo varchar(max)= null,@Imagem varbinary(max)= null,
@TarjaMag varchar(max)= null,@Obs varchar(max)= null,@ClienteID int = null)
    as
        begin   
            INSERT INTO Projetos (NomeProjeto,BoxFoto,Espessura,Tecnologia,Adesivo,Furo,Termo,ProjTermo,Imagem,TarjaMag,Obs,ClienteID) 
            VALUES (@NomeProjeto,@BoxFoto,@Espessura,@Tecnologia,@Adesivo,@Furo,@Termo,@ProjTermo,@Imagem,@TarjaMag,@Obs,@ClienteID)
        end

GO
Create procedure spUpdateProjetos(@NomeProjeto varchar(max)=NULL,@BoxFoto varchar(max)=NULL,@Espessura varchar(max)=NULL,@Tecnologia varchar(max)=NULL,@Adesivo varchar(max)=NULL,
@Furo varchar(max)=NULL,@Termo varchar(max)=NULL,@ProjTermo varchar(max)=NULL,@Imagem varbinary(max)=NULL,@TarjaMag varchar(max)=NULL,
@Obs varchar(max)=NULL,@ClienteID int=NULL, @Id int)
    as
        begin  
            UPDATE Projetos SET NomeProjeto=@NomeProjeto,BoxFoto=@BoxFoto,Espessura=@Espessura,Tecnologia=@Tecnologia,Adesivo=@Adesivo,
            Furo=@Furo,Termo=@Termo,ProjTermo=@ProjTermo,Imagem = @Imagem,Tarjamag=@TarjaMag,Obs=@Obs WHERE Id = @Id
        end

go
create procedure spDeleteProjetos(@Id int)
    as
        begin
           DELETE FROM Projetos WHERE Id = @Id
        end
GO

create procedure spProjetosDoCliente
@ClienteId int
as
begin
	select * from projetos where ClienteID = @ClienteId
end


go
create procedure spInsertFuncionarios
@id int = null,
@nome varchar(max),
@setor varchar(max),
@senha varchar(10),
@usuario varchar(10)
as
begin
	insert into funcionarios (Nome,Setor,Usuario,Senha) values (@nome, @setor, @usuario, @senha)
end
GO

Create procedure spUpdateFuncionarios
@id int = null,
@nome varchar(max),
@setor varchar(max),
@senha varchar(10),
@usuario varchar(10)
as
begin
	update funcionarios set Nome=@Nome,Setor=@Setor,Usuario=@Usuario,Senha=@Senha where Id = @Id
end
GO

Create procedure spDeleteFuncionarios
@id int = null
as
begin
	update funcionarios set StatusAtividade='INATIVO' where Id=@id
end
go

CREATE PROCEDURE spVerificaUsuario
@Usuario varchar(20)
as
begin
	select * from Funcionarios where Usuario = @Usuario
end
GO
 
alter PROCEDURE  spMelhoresClientes
@Tecnologia varchar(max) = null,
@Orientacao varchar(max)= null,
@OsTipo varchar(max) =null
AS
BEGIN
    select Os.ClienteId, sum(TotalProduzido) as TotalProduzido from OS 
	left join projetosOs on OS.Id = ProjetosOS.OsId 
	left join Projetos on ProjetoId = Projetos.Id
	where
	(Tecnologia = @Tecnologia or @Tecnologia IS null) AND
	(Orientacao = @Orientacao OR @Orientacao IS null) AND
	(OsTipo = @OsTipo OR @OsTipo IS null)
	GROUP BY Os.ClienteID
END


go
CREATE FUNCTION dbo.FiltroFuncionario(
@Id int = null,
@Nome varchar(max)= null,
@Setor varchar(max) =null)
RETURNS TABLE
AS
return select * from Funcionarios where
	(Id = @Id or @Id IS null) AND
	(Nome like '%'+@Nome+'%' OR @Nome IS null) AND
	(Setor = @Setor OR @Setor IS null)


---------------------------------------------------------------------------------------------
-- Trigger 
-- deleta ProjetosOs e Materiais relacionados com OS mãe
go
CREATE TRIGGER deleteProjectOS
ON OS
INSTEAD OF DELETE
AS
BEGIN
	 DELETE FROM ProjetosOS WHERE OsId IN(SELECT Id FROM DELETED);
	 DELETE FROM OS WHERE Id IN(SELECT ID FROM DELETED);
END

-- Para executar a trigger só deletar uma OS

---------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------
-- Cursor
create procedure spAtivaFuncionarios
as
begin
DECLARE db_cursor CURSOR FOR 
SELECT * 
FROM Funcionarios
WHERE StatusAtividade = 'INATIVO'
OPEN db_cursor  
FETCH NEXT FROM db_cursor 
WHILE @@FETCH_STATUS = 0  
BEGIN  
    UPDATE Funcionarios 
    SET StatusAtividade = 'ATIVO'
    WHERE CURRENT OF db_cursor
    FETCH NEXT FROM db_cursor
END 
CLOSE db_cursor  
DEALLOCATE db_cursor 
end


---------------------------------------------------------------------------------------------
--ALTERAÇÕES Q EU FIZ NO BANCO PRA FUNFAR

INSERT INTO Funcionarios VALUES ('MÁRCIO ROCHA','COMERCIAL','admin','1234')






