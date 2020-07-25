using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tempo_execucao
{
    class Program
    {
        static long tamanho = 1000;
        static List<int> elementos = new List<int>();

        static void dados()
        {
            elementos = new List<int>();
            for (int i = 0; i < tamanho; i++)
            {

                Random aleatorio = new Random();
                int numero = aleatorio.Next((Int32)i, (Int32)tamanho);
                elementos.Add(numero);
            }

        }

        //SELECT SORT
        static void metodoSelectSort()
        {
            int[] vetor = new int[tamanho];
            int cont = 0;

            while (cont < vetor.Length)
            {
                vetor[cont] = elementos[cont];
                cont++;
            }

            int i = 0;
            int temp_menor = 0;
            int temp_troca = 0;

            for (i = 0; i < vetor.Length; i++)
            {
                temp_menor = i;
                for (int elem = i + 1; elem < vetor.Length; elem++)
                {
                    if (vetor[elem] < vetor[temp_menor])
                        temp_menor = elem;

                }

                temp_troca = vetor[i];
                vetor[i] = vetor[temp_menor];
                vetor[temp_menor] = temp_troca;
            }

        }

        //BUBBLE SORT OTIMIZADO
        static void BubbleSortOtimizado()
        {

            List<int> container = new List<int>();
            bool otimizacao = false;

            foreach (var item in elementos)
            {
                container.Add(item);
            }

            int temp = 0;

            for (int i = 0; i < container.Count; i++)
            {
                otimizacao = false;

                for (int ord = 0; ord < container.Count - 1; ord++)
                {
                    if (container[ord] > container[ord + 1])
                    {
                        temp = container[ord + 1];
                        container[ord + 1] = container[ord];
                        container[ord] = temp;
                        otimizacao = true;
                    }
                }
                if (!otimizacao) break;
            }
        }

        //INSERTION SORT
        static void InsertionSort()
        {
            int[] elementos = new int[tamanho];
            for (int i = 1; i < elementos.Length; i++)
            {
                int temp;
                for (int elem = i; elem > 0 && elementos[elem] < elementos[elem - 1]; elem--)
                {
                    temp = elementos[elem - 1];
                    elementos[elem - 1] = elementos[elem];
                    elementos[elem] = temp;
                }
            }

        }

        //MERGE SORT
        static void MergeSort()
        {
            List<int> container_elementos = new List<int>();
            int contador_elementos = 0;

            foreach (var item in elementos)
            {
                container_elementos.Add(item);
                contador_elementos++;
            }
        }

        public static List<int> MergeSort(List<int> container_elementos)
        {
            if (container_elementos.Count < 2)
                return container_elementos;

            int metade = container_elementos.Count / 2;

            List<int> container_esquerda = new List<int>();
            List<int> container_direita = new List<int>();

            for (int x = 0; x < metade; x++)
                container_esquerda.Add(container_elementos[x]);

            for (int x = metade; x < container_elementos.Count; x++)
                container_direita.Add(container_elementos[x]);

            return Merge(MergeSort(container_esquerda), MergeSort(container_direita));
        }


        public static List<int> Merge(List<int> container_esquerda, List<int> container_direita)
        {
            List<int> container_ordenado = new List<int>();

            int temp_esq = 0, temp_dir = 0;

            while (temp_esq < container_esquerda.Count && temp_dir < container_direita.Count)
                if (container_esquerda[temp_esq] < container_direita[temp_dir])
                {
                    container_ordenado.Add(container_esquerda[temp_esq]);
                    temp_esq++;
                }
                else
                {
                    container_ordenado.Add(container_direita[temp_dir]);
                    temp_dir++;
                }

            while (temp_esq < container_esquerda.Count)
            {
                container_ordenado.Add(container_esquerda[temp_esq]);
                temp_esq++;
            }

            while (temp_dir < container_direita.Count)
            {
                container_ordenado.Add(container_direita[temp_dir]);
                temp_dir++;
            }

            return container_ordenado;
        }

        static void Main(string[] args)
        {
            Stopwatch tempo = new Stopwatch();
            tamanho = 1000;
            Console.WriteLine("BubbleSort");
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 5000;
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 10000;
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 50000;
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 100000;
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 300000;
            dados();
            tempo.Start();
            BubbleSortOtimizado();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            Console.WriteLine("");
            tamanho = 1000;
            Console.WriteLine("SelectSort");
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 5000;
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 10000;
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 50000;
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 100000;
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 300000;
            dados();
            tempo.Start();
            metodoSelectSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();



            Console.WriteLine("");
            tamanho = 1000;
            Console.WriteLine("InsertionSort");
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 5000;
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 10000;
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 50000;
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 100000;
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 300000;
            dados();
            tempo.Start();
            InsertionSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            Console.WriteLine("");
            Console.WriteLine("MergeSort");
            tamanho = 1000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 5000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 1000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 50000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 100000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            tamanho = 300000;
            dados();
            tempo.Start();
            MergeSort();
            tempo.Stop();
            Console.WriteLine("Tamanho " + tamanho + ": " + tempo.Elapsed.ToString("mm\\:ss\\:ff"));
            tempo.Reset();

            Console.ReadKey();
        }
    }
}
