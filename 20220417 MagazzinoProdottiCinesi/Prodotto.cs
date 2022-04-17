using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220417_MagazzinoProdottiCinesi
{
    public class Prodotto
    {
        public string Nome { get; set; }
        //public int quantita { get; set; }
        public int Prezzo { get; set; }

    }
    public class Magazzino
    {
        public List<ProdottoInserito> prodottoInserito = new List<ProdottoInserito>();

        public class ProdottoInserito
        {
            public Prodotto prodotto;
            public int Quantita;
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
                prodIns.prodotto = artcasa;
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
                prodIns.prodotto = artAuto;
                Console.WriteLine("Inserisi la quantità");
                prodIns.Quantita = int.Parse(Console.ReadLine());
                this.prodottoInserito.Add(prodIns);
            }            
        }




    }
    public class ArtCasa : Prodotto
    {
        public string StanzaUtilizzo { get; set; }
    }
    public class ArtAuto : Prodotto
    {
        public string CosaRipara { get; set; }
    }




}


