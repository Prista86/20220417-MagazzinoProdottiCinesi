using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220417_MagazzinoProdottiCinesi
{
    public abstract class Prodotto
    {
        public string Nome { get; set; }

        public int Prezzo { get; set; }
        public int qt { get; set; }

        public virtual void SpaccaProdotto(Magazzino magazzino)
        {
            Console.WriteLine("Ho spaccato il prodotto " + this.Nome);
        }

    }

    public class Magazzino
    {
        public List<ProdottoInserito> prodottoInserito = new List<ProdottoInserito>();
        public int qt { get; set; }
        public class ProdottoInserito
        {
            private Prodotto prodotto;
            public Prodotto Prodotto
            {
                get
                {
                    return prodotto;                    
                }
                set
                {                   
                    prodotto = value;
                    //int qta = this.Quantita ;
                    NumeroInserimenti.Inserimenti++; ;
                }
            }
            public int Quantita;           
        }
        
        public void VisualizzaProdotto()
        {
            bool haElementi = this.prodottoInserito.Any();
            if (haElementi)
            {
                Console.WriteLine();
                for (int i = 0; i < this.prodottoInserito.Count; i++)
                {
                    Console.WriteLine($"ID: {i} , Nome Prodotto: {this.prodottoInserito[i].Prodotto.Nome} Quantita': {this.prodottoInserito[i].Quantita}  Costo: {this.prodottoInserito[i].Prodotto.Prezzo}");
                }
                Console.WriteLine($"In totale sono stati fatti {NumeroInserimenti.Inserimenti} inserimenti");
                Console.WriteLine("'Invio'");
                this.qt = 0;
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Non ci sono prodotti inseriti.");
                this.qt = 1;
                Console.ReadKey();
            }
        }

        public void AggiungiProdotto()
        {
            Console.WriteLine("Che prodotto vuoi inserire? 'Inserire la lettera corrispondente.'");
            Console.WriteLine("A) - Articoli per la casa");
            Console.WriteLine("B) - Articoli per l'auto");
            string scelta = Console.ReadLine();
            if (scelta == "A")
            {
                ArtCasa artcasa = new ArtCasa();
                Console.WriteLine("Inserisi nome prodotto");
                artcasa.Nome = Console.ReadLine();
                Console.WriteLine("Inserisi il costo");
                artcasa.Prezzo = int.Parse(Console.ReadLine());
                Console.WriteLine("In quale stanza viene utilizzato?");
                artcasa.StanzaUtilizzo = Console.ReadLine();
                ProdottoInserito prodIns = new ProdottoInserito();
                prodIns.Prodotto = artcasa;
                Console.WriteLine("Inserisi la quantità");
                prodIns.Quantita = int.Parse(Console.ReadLine());
                this.prodottoInserito.Add(prodIns);

            }
            else if (scelta == "B")
            {
                ArtAuto artAuto = new ArtAuto();
                Console.WriteLine("Inserisi nome prodotto");
                artAuto.Nome = Console.ReadLine();
                Console.WriteLine("Inserisi il costo");
                artAuto.Prezzo = int.Parse(Console.ReadLine());
                Console.WriteLine("Quale parte dell'auto ripara?");
                artAuto.CosaRipara = Console.ReadLine();
                ProdottoInserito prodIns = new ProdottoInserito();
                prodIns.Prodotto = artAuto;
                Console.WriteLine("Inserisi la quantità");
                prodIns.Quantita = int.Parse(Console.ReadLine());
                this.prodottoInserito.Add(prodIns);
            }
        }
        public void AggiungiStock()
        {
            ArtCasa artcasa1 = new ArtCasa();
            artcasa1.Nome = "Sapone";
            artcasa1.Prezzo = 3;
            artcasa1.StanzaUtilizzo = "Salotto";
            ProdottoInserito prodIns1 = new ProdottoInserito();
            prodIns1.Prodotto = artcasa1;
            prodIns1.Quantita = 50;
            this.prodottoInserito.Add(prodIns1);

            ArtCasa artcasa2 = new ArtCasa();
            artcasa2.Nome = "Forchetta";
            artcasa2.Prezzo = 1;
            artcasa2.StanzaUtilizzo = "Cantina";
            ProdottoInserito prodIns2 = new ProdottoInserito();
            prodIns2.Prodotto = artcasa2;
            prodIns2.Quantita = 10;
            this.prodottoInserito.Add(prodIns2);

            ArtAuto artAuto1 = new ArtAuto();
            artAuto1.Nome = "Cacciavite";
            artAuto1.Prezzo = 15;
            artAuto1.CosaRipara = "Pneumatici";
            ProdottoInserito prodIns3 = new ProdottoInserito();
            prodIns3.Prodotto = artAuto1;
            prodIns3.Quantita = 20;
            this.prodottoInserito.Add(prodIns3);

            ArtAuto artAuto2 = new ArtAuto();
            artAuto2.Nome = "Martello";
            artAuto2.Prezzo = 20;
            artAuto2.CosaRipara = "Parabrezza";
            ProdottoInserito prodIns4 = new ProdottoInserito();
            prodIns4.Prodotto = artAuto2;
            prodIns4.Quantita = 30;
            this.prodottoInserito.Add(prodIns4);
        }
        public void EliminaProdotto()
        {
            VisualizzaProdotto();
            if (this.qt == 1)
            {

            }
            else
            {
                Console.WriteLine("Inserisci il numero ID del prodotto che vuoi eliminare");
                int sceltaNum = int.Parse(Console.ReadLine());
                Console.WriteLine("Inserisci la quantità di pezzi che vuoi portare via");
                int qtaElim = int.Parse(Console.ReadLine());
                if (this.prodottoInserito[sceltaNum].Quantita < qtaElim)
                {
                    Console.WriteLine("Mi dispiace non puoi prenderne, non ce ne sono abbastanza.");
                }
                else
                {
                    this.prodottoInserito[sceltaNum].Quantita -= qtaElim;
                }
                Console.WriteLine($"ID: {sceltaNum} , Nome Prodotto: {this.prodottoInserito[sceltaNum].Prodotto.Nome} Quantita': {this.prodottoInserito[sceltaNum].Quantita}  Costo: {this.prodottoInserito[sceltaNum].Prodotto.Prezzo}");
                Console.ReadKey();
            }



        }
    }
    public class ArtCasa : Prodotto
    {
        public string StanzaUtilizzo { get; set; }

        public override void SpaccaProdotto(Magazzino magazzino)
        {
            base.SpaccaProdotto(magazzino);
            Console.WriteLine("Lanciandolo contro la casa");
            //Console.ReadKey();

        }
    }
    public class ArtAuto : Prodotto
    {
        public string CosaRipara { get; set; }

        public override void SpaccaProdotto(Magazzino magazzino)
        {
            base.SpaccaProdotto(magazzino);
            Console.WriteLine("Lanciandolo contro l'auto");
            //Console.WriteLine();

        }
    }
    public class NumeroInserimenti
    {
        public static int Inserimenti { get; set; }

    }



}


