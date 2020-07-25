#include <iostream>
#include <locale>
#include "abb.h"
#include <Windows.h>
#include <conio.h>

using namespace std;

//Função para posicionamento de caracteres na tela
void gotoxy(int x, int y)
{
	COORD coord;
	HANDLE handle;
	handle = GetStdHandle(STD_OUTPUT_HANDLE);
	coord.X = x;
	coord.Y = y;
	SetConsoleCursorPosition(handle, coord);
}

void main()
{
	setlocale(LC_ALL, "Portuguese");
	
	

	char opc;

	do
	{
		int posicaoY = 9;
		system("cls");
		cout << "::Utilize a tecla (+) para selecionar a opção::" << endl;
		gotoxy(2, 3); cout << "[ ] Adicionar" << endl;
		gotoxy(2, 4); cout << "[ ] Adicionar multiplos" << endl;
		gotoxy(2, 5); cout << "[ ] Percorrer - Em-ordem" << endl;
		gotoxy(2, 6); cout << "[ ] Percorrer - Pré-ordem" << endl;
		gotoxy(2, 7); cout << "[ ] Percorrer - Pós-ordem" << endl;
		gotoxy(2, 8); cout << "[ ] Remover (inativo)" << endl;
		gotoxy(2, 9); cout << "[x]" << endl;

		do
		{
			opc = _getch();//Captura do valor da tecla pressionada

			if ((opc == '-') && (posicaoY < 9))
			{
				gotoxy(3, posicaoY); cout << " ";
				gotoxy(3, ++posicaoY); cout << "x";
			}

			if ((opc == '+') && (posicaoY > 3))
			{
				gotoxy(3, posicaoY); cout << " ";
				gotoxy(3, --posicaoY); cout << "x";
			}

			gotoxy(0, 10);

		} while (opc != 13);//ENTER


	switch (posicaoY)
	{
	case 3:
		//adicionar
		inserir();
		
		break;

	case 4:
		int n_add;
		cout << "Digite a quantidade de números para adicionar:" << endl;
		cin >> n_add;

		for (int i = 0; i < n_add; i++)
		{
			inserir();
			cout << endl;

		}
		break;
	case 5:
		//Percorrer - Em-ordem
		busca_emordem(ARVORE);
		system("pause>null");
		break;


	case 6:
		//Percorrer - Pré-Ordem
		busca_preordem(ARVORE);
		system("pause>null");
		break;


	case 7:
		//Percorrer - Pós-Ordem
		busca_posordem(ARVORE);
		system("pause>null");
		break;

	default: "Opção inválida";
		system("pause>null");
		break;
	}

	} while (opc != 9);







}