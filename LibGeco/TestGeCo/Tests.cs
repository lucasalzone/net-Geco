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
        public void AggiungiCorso(Corso c){
            Assert.IsTrue(false);
        }
        [TestMethod]
        public void ListaLezioni(Corso c){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void AggiungiLezione(Corso c){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void ModificaLezione(Corso c){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void Iscrizione(Corso c){
             Assert.IsTrue(false);
        }
        [TestMethod]
        public void ModificaCorso(Corso c){
             Assert.IsTrue(false);
        }
	}
}