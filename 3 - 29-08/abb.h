#include <iostream>

using namespace std;

struct arvore 
{
	struct arvore *esquerda; //Sub-arvore esquerda
	int dado; //Raiz
	struct arvore *direita; //Sub-arvore direita
};

arvore *ARVORE;

//Método responsável pela inserção de um novo nó recebido por parâmetro
arvore *arvore_b(arvore *arvore_atual, arvore *sub_arvore, int valor_no)
{
	//Se está vazia, não existe sub-árvore
	if (sub_arvore == NULL)
	{
		//Inserção do nó
		try
		{
			//Criar nó com o valor informado
			sub_arvore = new arvore();
			sub_arvore->dado = valor_no;
			sub_arvore->direita = NULL;
			sub_arvore->esquerda = NULL;

			//Não existem nós na árvore, a Arvore atual está vazia
			if (arvore_atual == NULL)
			{
				cout << "A raiz foi adicionada!" << endl;
				system("pause>null");
				return sub_arvore;
			}

			//Já existe no minimo a RAIZ
			if (valor_no < arvore_atual->dado)
			{
				arvore_atual->esquerda = sub_arvore;
				cout << "Elemento adicionado à esquerda de " << arvore_atual->dado << endl;
			}
			else
			{
				arvore_atual->direita = sub_arvore;
				cout << "Elemento adicionado à direita de " << arvore_atual->dado << endl;
			}

			system("pause>null");
			return sub_arvore;
		}
		catch (...) //Identifica todas exceptions (erros)
		{
			cout << "Erro ao utilizar a árvore" << endl;
			system("pause>null");
			exit(0); //Saída com erro
		}

	}

	//Proceder com a navegação (esquerda ou direita)
	if (valor_no < sub_arvore->dado)
		arvore_b(sub_arvore, sub_arvore->esquerda, valor_no);
	else
		arvore_b(sub_arvore, sub_arvore->direita, valor_no);

}

//Inserir
void inserir()
{
	int novo_no;
	cout << "Informe o valor: " << endl;
	cin >> novo_no;

	//Inserção de um novo nó
	//Considerando regras da ABB
	if (ARVORE == NULL)
		ARVORE = arvore_b(ARVORE, ARVORE, novo_no);
	else
		arvore_b(ARVORE, ARVORE, novo_no);

}

//Método de busca em ABB
//* Pré-ordem: Raiz-Esquerda-Direita
//* Em-Ordem: Esquerda-Raiz-Direita
//* Pós-Ordem: Esquerda-Direita-Raiz
//Por-Nível


//E-R-D
void busca_emordem(arvore* arv)
{
	if (arv != NULL)
	{
		busca_emordem(arv->esquerda);
		cout << arv->dado << " ";
		busca_emordem(arv->direita);
	}
}

//R-E-D
void busca_preordem(arvore* arv)
{
	if (arv != NULL)
	{
		cout << arv->dado << " ";
		busca_preordem(arv->esquerda);
		busca_preordem(arv->direita);
	}
}

//E-D-R
void busca_posordem(arvore* arv)
{
	if (arv != NULL)
	{
		busca_posordem(arv->esquerda);
		busca_posordem(arv->direita);
		cout << arv->dado << " ";
	}
}