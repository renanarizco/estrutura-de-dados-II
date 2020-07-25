#include <iostream>

using namespace std;

struct arvore 
{
	struct arvore *esquerda; //Sub-arvore esquerda
	int dado; //Raiz
	struct arvore *direita; //Sub-arvore direita
};

arvore *ARVORE;

//M�todo respons�vel pela inser��o de um novo n� recebido por par�metro
arvore *arvore_b(arvore *arvore_atual, arvore *sub_arvore, int valor_no)
{
	//Se est� vazia, n�o existe sub-�rvore
	if (sub_arvore == NULL)
	{
		//Inser��o do n�
		try
		{
			//Criar n� com o valor informado
			sub_arvore = new arvore();
			sub_arvore->dado = valor_no;
			sub_arvore->direita = NULL;
			sub_arvore->esquerda = NULL;

			//N�o existem n�s na �rvore, a Arvore atual est� vazia
			if (arvore_atual == NULL)
			{
				cout << "A raiz foi adicionada!" << endl;
				system("pause>null");
				return sub_arvore;
			}

			//J� existe no minimo a RAIZ
			if (valor_no < arvore_atual->dado)
			{
				arvore_atual->esquerda = sub_arvore;
				cout << "Elemento adicionado � esquerda de " << arvore_atual->dado << endl;
			}
			else
			{
				arvore_atual->direita = sub_arvore;
				cout << "Elemento adicionado � direita de " << arvore_atual->dado << endl;
			}

			system("pause>null");
			return sub_arvore;
		}
		catch (...) //Identifica todas exceptions (erros)
		{
			cout << "Erro ao utilizar a �rvore" << endl;
			system("pause>null");
			exit(0); //Sa�da com erro
		}

	}

	//Proceder com a navega��o (esquerda ou direita)
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

	//Inser��o de um novo n�
	//Considerando regras da ABB
	if (ARVORE == NULL)
		ARVORE = arvore_b(ARVORE, ARVORE, novo_no);
	else
		arvore_b(ARVORE, ARVORE, novo_no);

}

//M�todo de busca em ABB
//* Pr�-ordem: Raiz-Esquerda-Direita
//* Em-Ordem: Esquerda-Raiz-Direita
//* P�s-Ordem: Esquerda-Direita-Raiz
//Por-N�vel


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