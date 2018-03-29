using System;
using System.Collections.Generic;

namespace AllClass {
	public class Lezione {
		private int _idLezione;
		private string _nome;
		private string _descrizione;
		private int _durata;
		private List<Studente> _presenti = new List<Studente>();

		public int IdLezione => _idLezione;
		public string Nome => _nome;
		public string Descrizione {
			get => _descrizione;
			set => this._descrizione = value;
		}
		public int Durata {
			get => _durata;
			set => this._durata = value;
		}
		public List<Studente> Presenti => _presenti;

		public Lezione(int id,string nome) {
			this._idLezione = id;
			this._nome = nome;
		}
		public Lezione(int id,string nome, string descrizione) {
			this._idLezione = id;
			this._nome = nome;
			this._descrizione = descrizione;
		}
		public Lezione(string nome,int durata, string descrizione){
			this._nome = nome;
			this._descrizione = descrizione;
			this._durata = durata;
		}

		public void AddPresenza(Studente s) => this._presenti.Add(s);

		public bool ControllaPresenza(Studente s){
			foreach(Studente st in this._presenti){ 
				if(st.Equals(s)){
					return true;
				}
			}return false;
		}
	}

	public class Studente {
		private string _matricola;
		private string _nome;
		private string _cognome;

		public string Matricola => _matricola;
		public string Nome => _nome;
		public string Cognome => _cognome;

		public Studente(string matricola) => this._matricola = matricola;

		public Studente(string matricola, string nome, string cognome) {
			this._matricola = matricola;
			this._nome = nome;
			this._cognome = cognome;
		}

		public override string ToString() => $"{this._matricola},{this._nome},{this._cognome}";

		public bool Equals(Studente s) {
			if (this._matricola == s.Matricola && this._nome == s.Nome && this._cognome == s.Cognome) {
				return true;
			} else {
				return false;
			}
		}
	}

	public class Corso {
		int _idCorso;
		string _nome;
		DateTime _DataInizio;
		DateTime _DataFine;
		string _descrizione;
		List<Studente> _studenti = new List<Studente>();
		List<Lezione> _lezioni = new List<Lezione>();

		public int IdCorso => _idCorso;
		public string Nome {
			get => _nome;
			set => this._nome = value;
		}
		public string Descrizione {
			get => _descrizione;
			set => this._descrizione = value;
		}
		public DateTime DataInizio => _DataInizio;
		public DateTime DataFine => _DataFine;
		public List<Studente> Studenti => _studenti;
		public List<Lezione> Lezioni => _lezioni;

		public Corso(int id,string nome) {
			this._idCorso = id;
			this._nome = nome;
		}
		public Corso(int id,string nome, DateTime dataInizio) {
			this._idCorso = id;
			this._nome = nome;
			this._DataInizio = dataInizio;
		}
		public Corso(int id,string nome, DateTime dataInizio, DateTime dataFine) {
			this._idCorso = id;
			this._nome = nome;
			this._DataInizio = dataInizio;
			this._DataFine = dataFine;
		}
		public Corso(string nome, DateTime dataInizio, DateTime dataFine, string descrizione) {
			this._nome = nome;
			this._DataInizio = dataInizio;
			this._DataFine = dataFine;
			this._descrizione = descrizione;
		}
		public Corso(int id,string nome,string descrizione) {
			this._idCorso = id;
			this._nome = nome;
			this._descrizione = descrizione;
		}

		public void Iscriviti(Studente s) => this._studenti.Add(s);
		public void AddLezione(Lezione l) => this._lezioni.Add(l);
		public void ModDurLez(Lezione l,int ore) => l.Durata = ore;
	}
}
