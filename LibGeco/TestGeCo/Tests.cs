using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AllClass;

namespace Giova.IGeCoTest {
	[TestClass]
	public class IGeCoTest {
		[TestMethod]
		public void ListaCorsiTest() {
            IGeCo ig = new GeCo();
			Assert.IsInstanceOfType(ig.ListaCorsi(), typeof(List<Corso>));
		}
		[TestMethod]
		public void SearchTest(){
			IGeCo ig = new GeCo();
			Corso DaCercare = new Corso("nome", DateTime.Now, DateTime.Now,"descrizione giovanni");
			Assert.IsFalse(ig.ListaCorsi().Count!=0);
			ig.ListaCorsi().Add(DaCercare);
			Assert.IsTrue(ig.ListaCorsi().Count ==1);
			List<Corso> trovati_nome = ig.Search("nome",true,ig.ListaCorsi());
			Assert.IsTrue(trovati_nome.Count == 1);
			List<Corso> trovati_descrizione = ig.Search("giovanni", false, ig.ListaCorsi());
			Assert.IsTrue(trovati_descrizione.Count == 1);
		}
        [TestMethod]
        public void AggiungiCorso(){
            IGeCo ig = new GeCo();
            ig.AggiungiCorso(new Corso("Java", new DateTime(2018,02,12),new DateTime(2018,04,12), "Facciamo tanto java"));
            Assert.IsTrue(ig.ListaCorsi().Count != 0);
        }
        [TestMethod]
        public void ListaLezioni(){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void AggiungiLezione(){
             GeCo ig = new GeCo();
			 Corso c = new Corso("Java",new DateTime(2018,02,12),new DateTime(2018,04,12),"Facciamo tanto java");
			 ig.AggiungiCorso(c);
			 int lunghezza_prima = -2;
			 lunghezza_prima = ig.Conta($"select count(*) from Lezioni");
			 Lezione LezioneProva = new Lezione(1,"boh","prova");
			 int lunghezza_dopo = -2;
			 ig.AggiungiLezione(c,LezioneProva);
			 lunghezza_dopo = ig.Conta($"select count(*) from Lezioni");
			 Assert.IsTrue(lunghezza_prima != lunghezza_dopo);
        }
        [TestMethod]
        public void ModificaLezione(){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void Iscrizione(){
             GeCo ig = new GeCo();
             
			 ig.Iscrizione(1,"abc");
            int numero = 0;
            numero = ig.Conta($"SELECT COUNT(*) FROM Iscrizioni");
            Assert.IsTrue(numero >= 1);
        }
        [TestMethod]
        public void ModificaCorso(){
             Assert.IsTrue(false);
        }
	}
}