﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisaoDoConteudo
{
	class Program
	{
		static void Main(string[] args)
		{
			//Digitar uma horario (substring ou não) e avaliar todos os possiveis problemas que poderá acontecer com ela
			string HorarioInicial, HorarioFinal;
			int HoraInicial, MinutoInicial, SegundoInicial;
			int HoraFinal, MinutoFinal, SegundoFinal;
			int HoraTotal, MinutoTotal, SegundoTotal, HorarioTotal;

			Console.WriteLine("Programa para saber quantas vezes o sinal muda de cor no mesmo dia\n");
			while (true) //Loop infinito para receber o horario inicial e os possiveis erros que poderão acontecer
			{           //Caso dê erro, voltará para pedir o horário novamente
				while (true) //Loop infinito para o try catch, caso o usuário digite uma letra
				{
					Console.WriteLine("Digite o horário INICIAL o no formato HH:MM:SS (separe por dois pontos)");
					HorarioInicial = Console.ReadLine();
					try //Tenta realizar essas conversões
					{
						HoraInicial = Convert.ToInt32(HorarioInicial.Substring(0, 2));
						MinutoInicial = Convert.ToInt32(HorarioInicial.Substring(3, 2));
						SegundoInicial = Convert.ToInt32(HorarioInicial.Substring(6, 2));
					}
					catch //Caso dê erro nas conversões, aparecerá uma mensagem e forçará a repetição do while
					{
						Console.WriteLine("Digite um horário válido");
						continue; //Força a repetição do while
					}
					break; //Só vem para o break se ocorrer tudo certo no try
				}

				if (HorarioInicial.Length != 8) //Se os caracteres digitados forem diferentes de 8
				{
					Console.WriteLine("Digite uma hora válida");
					continue; //Força repetição do primeiro while (o while de fora)
				}
				else if (HoraInicial < 0 || MinutoInicial < 0 || SegundoInicial < 0) //Se a hora, minuto ou segundo inicial for menor que zero,
				{                                                                   //Dará erro por não existir horario abaixo de zero
					Console.WriteLine("Digite um horário válido");
					continue;
				}
				else if (HoraInicial > 23 || MinutoInicial > 59 || SegundoInicial > 59) //Se a hora for maior que 23, minuto ou segundo maior que 59
				{                                                                      //Dará erro por não existir horas acima de 23 ou minuto/segundo acima de 59
					Console.WriteLine("Digite um horário válido");
					continue;
				}
				else //Caso o if e else if dê falso, significa que não há nada de errado na hora informada
				{
					break; //Quebra o while para poder continuar o código e receber o horário final
				}
			}

			while (true) //Loop infinito para receber o horario final e os possiveis erros que poderão acontecer
			{            //Caso dê erro, voltará para pedir o horário novamente

				while (true) //Loop infinito para o try catch, caso o usuário digite uma letra
				{
					Console.WriteLine("Digite o horário FINAL no formato HH:MM:SS (separe por dois pontos)");
					HorarioFinal = Console.ReadLine();
					try //Tenta realizar essas conversões
					{
						HoraFinal = Convert.ToInt32(HorarioFinal.Substring(0, 2));
						MinutoFinal = Convert.ToInt32(HorarioFinal.Substring(3, 2));
						SegundoFinal = Convert.ToInt32(HorarioFinal.Substring(6, 2));
					}
					catch //Caso dê erro nas conversões, aparecerá uma mensagem e forçará a repetição do while
					{
						Console.WriteLine("Digita um horário válido ae bicho");
						continue; //Força a repetição do while
					}
					break; //Só vem para o break se ocorrer tudo certo no try
				}

				if (HorarioFinal.Length != 8) //Se os caracteres digitados forem diferentes de 8
				{
					Console.WriteLine("Digite uma hora válida");
					continue; //Força repetição do primeiro while (o while de fora)
				}

				else if (HoraFinal < 0 || MinutoFinal < 0 || SegundoFinal < 0) //Mesma lógica do horario inicial
				{
					Console.WriteLine("Digite uma horario válida");
					continue;
				}
				else if (HoraFinal > 23 || MinutoFinal > 59 || SegundoFinal > 59) //Mesma lógica do horario inicial
				{
					Console.WriteLine("Digite um horário válido");
					continue;
				}
				else
				{
					if (HoraInicial > HoraFinal) //Se a hora inicial for maior que a final, a variação deria negativo, ou seja, daria errado
					{
						Console.WriteLine("Digite uma horario do mesmo dia");
						break;
					}
					else
					{
						HoraTotal = (HoraFinal - HoraInicial) * 3600; //Variação e Conversão de horas para segundos
						MinutoTotal = (MinutoFinal - MinutoInicial) * 60; //Variação e Conversão de minutos para segundos
						SegundoTotal = (SegundoFinal - SegundoInicial); //Variação de segundos
						HorarioTotal = (HoraTotal + MinutoTotal + SegundoTotal) / 40; //Soma tudo e divide por 40 para saber quantas vezes o sinal muda de cor

						Console.WriteLine("A quantidade de vezes que mudou foi {0} vezes", HorarioTotal); //Output que sairá para o usuário
						break; //Termina o código
					}
				}
			}
		}
	}
}
