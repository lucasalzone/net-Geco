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

/*
create procedure ListaLezioni
	@NomeCorso varchar(20)
as
	set IMPLICIT_TRANSACTIONS ON;
	declare @idCorso int;
	set @idCorso = (SELECT idCorso FROM Corsi WHERE nome = @NomeCorso);
	if @idCorso is null
		begin
			print 'Errore: Non esiste quel Corso';
			throw 56567, 'Non esiste quel Corso',2;
			ROLLBACK TRANSACTION;
		end
	else
		begin
			SELECT Lezioni.nome,Lezioni.durata,Lezioni.durata,Lezioni.descrizione FROM Lezioni WHERE Lezioni.fkCorso = @idCorso;
			COMMIT TRANSACTION;
		end
go*/
create procedure ListaLezioni
	@nomeCorso varchar(20)
as
	set implicit_transactions on;
	declare @idCorso int;
	set @idCorso = (select idCorso from Corsi c where c.nome = @nomeCorso)
	if @idCorso is null
		begin
			print '@idCorso non trovato!!';
			throw 50001, '404 not found', 8;
			rollback transaction;
		end
	else
		SELECT l.idLezione, l.nome, l.durata, l.descrizione from Lezioni as l inner join Corsi as c on l.fkCorso = c.idCorso where l.fkCorso = @idCorso;
		commit transaction;
go

create procedure ModCorso
	
as
	
go

--Non funziona
create procedure ModDescrizioneLez
	@NomeCorso varchar(20),
	@NomeLezione varchar(20),
	@Descrizione nvarchar(200)
as
	set IMPLICIT_TRANSACTIONS ON;
	declare @idCorso int;
	set @idCorso = (SELECT idCorso FROM Corsi WHERE Corsi.nome = @NomeCorso);
	if @idCorso is null
		begin
			print 'Modifica della descrizione annullata';
			throw 56568, 'Non esiste quel Corso',4;
			ROLLBACK TRANSACTION;
		end
	else
		begin
			declare @idLezione int;
			set @idLezione = (SELECT idLezione FROM Lezioni WHERE Lezioni.nome = @NomeLezione);
			if @idLezione is null
				begin
					print 'Errore: Non esiste quella lezione';
					throw 65689,'Non esiste quella lezione',5;
				end
			else
				begin
					update Lezioni set descrizione = @Descrizione WHERE idLezione = @idLezione;
					COMMIT TRANSACTION;
				end
		end
go

create procedure ModDurataLez
	@NomeCorso varchar(20),
	@NomeLezione varchar(20),
	@Durata int
as
	set IMPLICIT_TRANSACTIONS ON;
	declare @idCorso int;
	set @idCorso = (SELECT idCorso FROM Corsi WHERE Corsi.nome = @NomeCorso);
	if @idCorso is null
		begin
			print 'Modifica della durata annullata';
			throw 56568, 'Non esiste quel Corso',4;
			ROLLBACK TRANSACTION;
		end
	else
		begin
			declare @idLezione int;
			set @idLezione = (SELECT idLezione FROM Lezioni WHERE Lezioni.nome = @NomeLezione AND Lezioni.fkCorso = @idCorso);
			if @idLezione is null
				begin
					print 'Errore: Non esiste questa lezione';
					throw 56570, 'Non esiste questa lezione',7;
					ROLLBACK TRANSACTION;
				end
			else
				begin
					update Lezione set durata = @Durata WHERE idLezione = @idLezione;
					COMMIT TRANSACTION;
				end
		end
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
		insert into Lezioni(nome, durata, descrizione, fkCorso) values (@LezioneNome, @LezioneDurata, @LezioneDescrizione, @IdCorso);
		commit transaction;
	end try
	begin catch
		 SELECT   
        ERROR_NUMBER() AS ErrorNumber,  
        ERROR_MESSAGE() AS ErrorMessage;  
	end catch;
go

create procedure SearchGen
	
as
	
go