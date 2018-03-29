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

drop procedure AddCorso

create procedure Iscrizione
	@IdCorso int,
	@IdMatricola varchar(20)
as
	INSERT INTO Iscrizioni(fkCorso, fkstudente) VALUES (@IdCorso,@IdMatricola);
go

create procedure ListaCorsi
	
as
	SELECT
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
	
as
	
go

create procedure SearchGen

as
	
go