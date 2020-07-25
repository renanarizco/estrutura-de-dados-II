using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodificacaoBubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            bolha();
        }

        static void bolha()
        {
            List<int> elementos = new List<int>();
            int contElementos = 0;

            bool opcao = true;


            while(opcao)
            {
                Console.Clear();
                Console.WriteLine("Informe um número: ");
                elementos.Add(int.Parse(Console.ReadLine()));
                contElementos++;

                Console.WriteLine("Deseja inserir outro numero? [s/n]");
                opcao = Console.ReadLine() == "s" ? true : false; 
            }

            int temp = 0;

            //Ordenação Bubble Sort
            for (int i = 0; i < elementos.Count; i++)
            {
                for (int ord = 0; ord < elementos.Count - 1; ord++)
                {
                    if (elementos[ord] > elementos[ord + 1])
                    {
                        temp = elementos[ord + 1];
                        elementos[ord + 1] = elementos[ord];
                        elementos[ord] = temp;
                    }
                }
            }

            //Apresentar valores ordenados
            for (int i = 0; i < elementos.Count; i++)
            {
                Console.WriteLine(elementos[i].ToString());
            }
            Console.ReadKey();
        }
    }
}
