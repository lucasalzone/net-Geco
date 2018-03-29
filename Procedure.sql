create procedure AddCorso
	@nome varchar(20),
	@dataInizio date,
	@dataFine date,
	@descrizione nvarchar(200)
as
	set IMPLICIT_TRANSACTIONS ON;
	if @nome is null
		begin
			print 'Errore: non puoi inserire un corso con lo stesso nome';
			throw 56565, 'Non puoi inserire un corso con lo stesso nome',3;
			ROLLBACK TRANSACTION;
		end
	else
		begin
			INSERT INTO Corsi(nome,dataInizio,dataFine,descrizione) VALUES(@nome,@dataInizio,@dataFine,@descrizione);
			COMMIT TRANSACTION;
		end
go

create procedure Iscrizione
	@IdCorso int,
	@IdMatricola varchar(20)
as
	INSERT INTO Iscrizioni(fkCorso, fkstudente) VALUES (@IdCorso,@IdMatricola);
go

create procedure ListaLezioni
	
as
	
go

create procedure ModCorso
	
as
	
go

create procedure ModLezione
	
as
	
go

create procedure AddLezione
@CorsoNome varchar(20),
@LezioneNome varchar(20),
@LezioneDurata int,
@LezioneDescrizione nvarchar(200)
as
	set IMPLICIT_TRANSACTIONS ON;
	begin try
		declare @IdCorso int;
		set @IdCorso = (select top 1 Corsi.idCorso from Corsi where @CorsoNome = Corsi.nome);
		if @IdCorso is null or @@ERROR >0
			begin
				rollback transaction;
			end;
		insert into Lezioni(nome, durata, descrizione, fkCorso) values (@LezioneNome, @LezioneDurata, '@LezioneDescrizione', @IdCorso);
		commit transaction;
	end try
	begin catch
		 SELECT   
        ERROR_NUMBER() AS ErrorNumber,  
        ERROR_MESSAGE() AS ErrorMessage;  
	end catch;
go

INSERT into Corsi(nome,dataInizio, dataFine, descrizione) values ('corso1', '01/01/1990', '02/01/1990', 'descrizione1');
exec AddLezione 'corso1', 'leione1',10,'descrizione1'
go

create procedure SearchGen

as
	
go