using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using AllClass;

namespace Giova{
	public interface IGeCo{
		List<Corso> ListaCorsi();
        List<Lezione> ListaLezioni(Corso c);
		List<Corso> Search(string s, bool scelta, List<Corso> lista);
		void AggiungiCorso(Corso c);
		void ModificaCorso(Corso c,bool scelta,string s);
		void Iscrizione(int idcorso,string matricolastudente);
		void ModificaLezione(Corso c,Lezione l,bool scelta,string s);
		void AggiungiLezione(Corso c, Lezione l);
		//List<Lezione> SearchLezioni(string s, bool scelta,Corso c,List<Lezione> lista);
	}

	public class GeCo: IGeCo{
		private List<Corso> _corsi = new List<Corso>();
		private List<Studente> _studenti = new List<Studente>();

		private SqlConnection DataConnection() {
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
			builder.DataSource = @"(localdb)\MSSQLLocalDB";
			builder.InitialCatalog = "GeCorsi";
			return new SqlConnection(builder.ConnectionString);
		}

		public void AggiungiCorso(Corso c){
            //Procedura($"exec AddCorso ");
		}

		public List<Corso> ListaCorsi(){
			return _corsi;
		}
		public List<Corso> Search(string s, bool scelta, List<Corso> lista) {
			if(scelta){
				return SearchByNome(lista, s);
			}else{
				return SearchByDescrizione(lista,s);
			}
		}
		private List<Corso> SearchByNome(List<Corso> lista, string NomeDaCercare) {
			List < Corso > trovati = new List<Corso>();
			foreach(Corso c in lista){
				if(c.Nome==NomeDaCercare){
				trovati.Add(c);
				}
			}return trovati;
		}
		private List<Corso> SearchByDescrizione(List<Corso> lista, string DescrizioneDaCercare) {
			List<Corso> trovati = new List<Corso>();
			foreach (Corso c in lista) {
				if (c.Descrizione.Contains(DescrizioneDaCercare)) {
					trovati.Add(c);
				}
			}return trovati;
		}

		public List<Lezione> ListaLezioni(Corso c) {
			List<Lezione> trovati = null;
			SqlConnection connection = DataConnection();
			try {
				connection.Open();
				string sql = $"select idLezione,nome, durata, descrizione from Lezioni;');";
				SqlCommand cmd = new SqlCommand(sql, connection);
				SqlDataReader reader = cmd.ExecuteReader();
				trovati = new List<Lezione>();
				while (reader.Read()) // int id,string nome,string descrizione, int durata
					trovati.Add(new Lezione(reader.GetInt16(0), reader.GetString(1), reader.GetString(2),reader.GetInt32(3)));
				reader.Close();
				cmd.Dispose();				
				return trovati;
			}catch(Exception e){
				throw e;
			}finally{
				connection.Dispose();
			}
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

		private void ModDescrizioneLez(Corso c, Lezione l, string desc) {
			SqlConnection connection = DataConnection();
			try {
				connection.Open();
				string sql = $"select nome, durata, descrizione from Lezioni where nome = '{l.Nome}' and descrizione = {l.Descrizione};');";
				SqlCommand cmd = new SqlCommand(sql, connection);
				sql = $"update Lezione set descrizione = {desc} where nome = '{l.Nome}';";
				cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}

		private void ModDurataLez(Corso c, Lezione l, int ore) {
			SqlConnection connection = DataConnection();
			try {
				connection.Open();
				string sql = $"select nome, durata, descrizione from Lezioni where nome = '{l.Nome}' and durata = {l.Durata};');";
				SqlCommand cmd = new SqlCommand(sql, connection);								
				sql = $"update Lezione set durata = {ore} where nome = '{l.Nome}';";
				cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
		}

		public void ModificaLezione(Corso c, Lezione l, bool scelta, string s) {
			//Se è true significa che vuole modificare la descrizione
			if (scelta) {
				ModDescrizioneLez(c,l,s);
			} else { //Se è false significa che vuole modificare la durata
				try{
					int num = int.Parse(s);
					ModDurataLez(c, l, num);
				} catch(FormatException e){
					throw e;
				}
			}
		}

		public void AggiungiLezione(Corso c, Lezione l) {
			SqlConnection connection = DataConnection();
			try {
				connection.Open();
				string sql = $"insert into Lezioni (nome, durata, descrizione) values ('{l.Nome}', {l.Durata}, '{l.Descrizione}');";
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}catch(Exception e){ 
				throw e;
			}finally{
				connection.Dispose();
			}
			c.AddLezione(l);
		}

        public void Procedura(string sql){
            SqlConnection connection = DataConnection();
			try {
				connection.Open();				
				SqlCommand cmd = new SqlCommand(sql, connection);
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			} catch (Exception e) {
				throw e;
			} finally {
				connection.Dispose();
			}
        }
    }
}
