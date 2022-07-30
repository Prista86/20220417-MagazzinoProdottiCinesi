using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// oggetti statici e dinamici   -->  ?
// ereditarietà                 --> OK
// Add List                     --> OK
// polimorfismo                 --> OK Spacco
// interfacce                   -->  ?
// abstract                     -->  ok Prodotto Abstract
// Altro?                       -->  ?



namespace _20220417_MagazzinoProdottiCinesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string scelta = "";
            Magazzino magazzino = new Magazzino();
            
            while (scelta != "F")
            {
                Console.Clear();
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("A) Vedere i prodotti in giacenza");
                Console.WriteLine("B) Inserire un prodotto");
                Console.WriteLine("C) Inserire uno stock prodotti");
                Console.WriteLine("D) Eliminare un prodotto in giacenza");
                //Console.WriteLine("E) Cosa fai se sei arrabbiato?");
                Console.WriteLine("F) Uscire");

                scelta = Console.ReadLine();
                if (scelta == "A")
                {
                    magazzino.VisualizzaProdotto();
                }
                else if (scelta == "B")
                {
                    magazzino.AggiungiProdotto();
                }
                else if (scelta == "C")
                {
                    magazzino.AggiungiStock();
                }
                else if (scelta == "D")
                {
                    magazzino.EliminaProdotto();
                }
                else if (scelta == "E")
                {
                    {
                        bool haElementi = magazzino.prodottoInserito.Any();
                        if (haElementi)
                        {
                            for (int i = 0; i < magazzino.prodottoInserito.Count; i++)
                            {
                                magazzino.prodottoInserito[i].Prodotto.SpaccaProdotto(magazzino);
                            }
                            Console.ReadKey();

                        }
                        else
                        {
                            Console.WriteLine("Non ci sono prodotti da spaccare");
                            Console.ReadKey();
                        }

                    }



                }

            }






        }
    }
}
