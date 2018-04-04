using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AllClass;

namespace Giova{
	public interface IGeCo{
		List<Corso> ListaCorsi();
        List<Lezione> ListaLezioni(Corso corso);
        List<Corso> SearchByName(string s);
		List<Corso> Search(string s);
		void AggiungiCorso(Corso c);
		void ModificaCorso(Corso c,bool scelta,string s);
		void Iscrizione(int idcorso,string matricolastudente);
		void ModificaLezione(string nomecorso,string nomelezione,bool scelta,string s);
		void AggiungiLezione(Corso c, Lezione l);
	}

	public class GeCo: IGeCo{
		private List<Corso> _corsi = new List<Corso>();
		private List<Studente> _studenti = new List<Studente>();

		public void AggiungiCorso(Corso c){
            Procedura($"exec AddCorso '{c.Nome}','{c.DataInizio.ToString("dd/MM/yyyy")}','{c.DataFine.ToString("dd/MM/yyyy")}','{c.Descrizione}';");
		}

		public List<Corso> ListaCorsi(){
			return Reader<List<Corso>>(TakeCorsi,$"SELECT nome,dataInizio,dataFine,descrizione FROM Corsi;");
		}

        public List<Lezione> ListaLezioni(Corso c) {
            return Reader<List<Lezione>>(TakeLezioni, $"exec ListaLezioni '{c.Nome}';");
	    }

        public List<Corso> SearchByName(string s) {
            throw new NotImplementedException();
        }

		public List<Corso> Search(string s) {
            return null;
		}

        public void ModificaCorso(Corso c,bool scelta,string s) {
            throw new NotImplementedException();
        }

		public void Iscrizione(int idcorso,string matricolastudente) {
			SqlConnection connection = DataConnection();
			try {
				connection.Open();
				string sql = $"exec Iscrizione {idcorso},'{matricolastudente}'";
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}

		private void ModDescrizioneLez(string nomecorso, string nomelezione,string desc) {
               Procedura($"exec ModDescrizioneLez '{nomecorso}','{nomelezione}','{desc}'");
		}

		private void ModDurataLez(string nomecorso, string nomelezione,int durata) {
            Procedura($"exec ModDurataLez '{nomecorso}','{nomelezione}',{durata}");
		}

		public void ModificaLezione(string nomecorso, string nomelezione, bool scelta, string s) {
			//Se è true significa che vuole modificare la descrizione
			if (scelta) {
				ModDescrizioneLez(nomecorso,nomelezione,s);
			} else { //Se è false significa che vuole modificare la durata
				try{
					int num = int.Parse(s);
					ModDurataLez(nomecorso, nomelezione, num);
				} catch(FormatException e){
					throw e;
				}
			}
		}

		public void AggiungiLezione(Corso c, Lezione l) {
			Procedura($"exec AddLezione '{c.Nome}', '{l.Nome}', {l.Durata}, '{l.Descrizione}'");
		}
    }
}
