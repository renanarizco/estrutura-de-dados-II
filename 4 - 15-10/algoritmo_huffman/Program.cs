using System; //importação de biblioteca
using System.Collections.Generic; //importação de biblioteca
using System.Linq; //importação de biblioteca
using System.Text; //importação de biblioteca
using System.Threading.Tasks; //importação de biblioteca


//IComparable: tem a função de fornecer um método de comparação de 2 ou mais objetos

//Linq/Lambda: função que permite criar consultas em árvores de expressão
//São muito úteis para consultas do tipo Linq, necessitando especificar
//os parâmetros de entrada do lado esquerdo do operador lambda =>, e o bloco de instruções do outro lado
namespace algoritmo_huffman
{

    class No : IComparable<No> //cria classe
    {
        public string simbolo; //cria variavel
        public int frequencia; //cria variavel
        public No esquerda; //cria variavel
        public No direita; //cria variavel
        public No pai; //cria variavel

        public No(String valor_no, int freq) //construtor
        {
            simbolo = valor_no; //simbolo pega valor de valor_no
            frequencia = freq; //frequencia pega valor de freq
        }

        //Ao implementar Icomparable, deve-se criar o método CompareTo
        public int CompareTo(No no) //criação do metodo CompareTo
        {
            return this.frequencia.CompareTo(no.frequencia); //pra usar icomparable, precisa-se retornar
        }

        public override string ToString() //metodo pra transformar simbolo em string
        {
           return simbolo; //retorna simbolo
        }

    }


    class Program //cria classe program
    {

        static string palavra; //criação de variavel
        static List<No> tabelaFreq = new List<No>(); //cria a lista de tabela de frequencia
        static List<No> Arvore = new List<No>(); //cria a lista arvore
        static StringBuilder palavraComprimida = new StringBuilder(); //cria string com mais recursos
        static Dictionary<string, string> tabelaHuffman = new Dictionary<string, string>(); //cria o dicionario

        static void Main(string[] args)
        {
            Console.WriteLine("Digite uma palavra: "); //imprime na tela
            palavra = Console.ReadLine().ToLower(); //le o input e faz virar lowcase

            //Agrupar por símbolo e realizar contagem
            //Adicionar na tabela de frequência
            tabelaFreq = palavra.GroupBy(simb => simb).Select((simb) => new No(simb.Key.ToString(), simb.Count())).ToList<No>(); //Adicionar na tabela de frequência


            //rotina para criação da arvore bottom up recursivamente
            while (tabelaFreq.Count() > 1)
            {
                tabelaFreq.Sort(); //ordenar tabela de frequência

                var par_nos = tabelaFreq.Take<No>(2).ToList<No>(); //pega os dois primeiros nós pra fazer a proxima parte da arvore

                
                if (par_nos.Count() == 2) //valida se foram coletados 2 nós
                {
                    var no_pai = new No(par_nos[0].simbolo + par_nos[1].simbolo, par_nos[0].frequencia + par_nos[1].frequencia); //a no_pai recebe os dois primeiros da tabela de frequencia

                    no_pai.esquerda = par_nos[0]; //no da esquerda vira o nó 0 do par_nos
                    no_pai.direita = par_nos[1]; //no da direita vira o nó 1 do par_nos

                    //par_nos[0].pai = no_pai; //o nó pai vai para o par_nos0.pai
                    //par_nos[1].pai = no_pai; //o nó pai vai para o par_nos1.pai
                    par_nos[0].pai = par_nos[1].pai = no_pai;

                    //associa os novos nos na arvore
                    Arvore.Add(par_nos[0]);
                    Arvore.Add(par_nos[1]);
                    
                    //adiciona novo no na tabela de freq
                    tabelaFreq.Add(no_pai);

                    //remove o range dos dois primeiros da tabela de freq
                    tabelaFreq.RemoveRange(0, 2);

                }
            }

            //percorrer arvore para codificar palavra
            //percorrer a partir do nó folha para a raiz (necessario inverter o codigo encontrado)

            //para cada nó na arvore faça alguma coisa
            foreach (No no in Arvore)
            {
                No pai_atual = null; //pai_atual vira nulo
                var no_atual = no; //no_atual recebe o valor do no
                pai_atual = no_atual.pai; //pai_atual recebe no_atual.pai

                do //repetição
                {
                    //compara dois objetos
                    if (No.ReferenceEquals(no_atual, pai_atual.direita))
                    {
                        palavraComprimida.Append('1');	//a direita recebe referencia 0
                    }
                    else
                    {
                        palavraComprimida.Append('0'); //esquerda recebe 1
                    }

                    //atualizar a localização na arvore
                    no_atual = no_atual.pai;
                    pai_atual = no_atual.pai;

                } while (pai_atual != null);//percorre da folha ate a raiz


                //inverter para armazenar com a ordem correta
                var resultado = palavraComprimida.ToString().Reverse();

                foreach (var ch in resultado)
                {
                    palavraComprimida.Append(ch); 
                }

                palavraComprimida.Remove(0, resultado.Count());
               


                //incluir no dicionario cada codigo de huffman encontrado
                //Apresentar a palavra codificada
                
                tabelaHuffman.Add(no.simbolo, palavraComprimida.ToString()); //adiciona na tabela huffman o simbolo atual

                palavraComprimida.Clear(); //limpa a palavraComprimida
            }

            foreach (char c in palavra) //repete ate acabar
            {
                Console.Write(tabelaHuffman[c.ToString()]); //escreve na tela o codigo huffman 
            }

            Console.ReadLine();
            //TESTAR COM AS PALAVRAS:
            //TESTE
            //SISTEMAS
            //SEMESTRE
            //ALGORITMO
        }

    }
    
}
