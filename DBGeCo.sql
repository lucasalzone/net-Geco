create database GeCo;
use GeCo;
create table Corsi(
	idCorso int identity(1,1) not null primary key,
	nome varchar(20) not null,
	dataInizio date,
	dataFine date,
	descrizione nvarchar(200)
);

create table Studenti(
	matricola varchar(20) not null primary key,
	nome varchar(20),
	cognome varchar(20)
);

create table Lezioni(
	idLezione int identity(1,1) not null primary key,
	nome varchar(20) not null,
	durata int,
	descrizione nvarchar(200),
	fkCorso int foreign key references Corsi
);

create table Iscrizioni(
	idIscrizione int identity(1,1) not null primary key,
	fkCorso int foreign key references Corsi,
	fkStudente varchar(20) foreign key references Studenti
);

SELECT * FROM Corsi;
SELECT * FROM Lezioni;
SELECT * FROM Iscrizioni;
SELECT * FROM Studenti;