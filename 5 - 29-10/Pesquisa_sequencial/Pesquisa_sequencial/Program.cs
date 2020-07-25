using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesquisa_sequencial
{
    class Program
    {
        static void Main(string[] args)
        {
            int x;

            Console.WriteLine("Digite o valor procurado: ");
            x = int.Parse(Console.ReadLine());


            //metodo pesquisa sequencial
            //pesquisar um elemento x em um vetor V de tamanho t
        }

        static void pesquisa_sequencial(int x)
        {
            const int t = 10;
            int[] v = new int[t] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            int i = 0;

            while ((i < t) && (x != v[i]))
                i++;

            if (i == t)
                Console.WriteLine("Valor não encontrado");
            else
                Console.WriteLine("Valor encontrado na posição " + i);

            Console.ReadKey();

        }
    }

   
}
