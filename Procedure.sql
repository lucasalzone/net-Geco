create procedure AddCorso
	@idCorso int,
	@nome varchar(20),
	@dataInizio date,
	@dataFine date,
	@descrizione nvarchar(200)
as
	set IMPLICIT_TRANSACTIONS ON;
	if @idCorso is null
		begin
			print 'prova';
			throw 56565, 'Codice corso non trovato',3;
			ROLLBACK TRANSACTION;
		end
	else
		begin
			INSERT INTO funzioniAssociate(codiceRuolo,codiceFunzione) VALUES(@codiceruolo,@codicefunzione);
			COMMIT TRANSACTION;
		end
go

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