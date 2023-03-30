using System.ComponentModel;
using System.Drawing;

namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static int quantidadeOperacoesRealizadas = 0;
        static int opcao = 0, tabuada;
        static double resultadoNovo = 0;
        static string[] descricoesOperadores = new string[100];
        static double numero1, numero2, resultado;
        
        static void Main(string[] args)
        {
            while (opcao != 7)
            {
                Menu();
                
                switch (opcao)
                {
                    case 1:
                        OperacaoAdicao();
                        break;

                    case 2:
                        OperacaoSubtracao();
                        break;

                    case 3:
                        OperacaoDivisao();
                        break;

                    case 4:
                        OperacaoMultiplicacao();
                        break;

                    case 5:
                        CalculoTabuada();
                        break;

                    case 6:
                        OperacoesRealizadas();
                        break;

                    case 7:
                        Console.WriteLine("\nSaindo da calculadora...");
                        break;

                    default:
                        Console.WriteLine("\nOpção inválida! Clique qualquer tecla para tentar novamente.");
                        Console.ReadKey();
                        break;
                }

                quantidadeOperacoesRealizadas++;
            }

            Console.ReadKey();
        }

        static void OperacoesRealizadas()
        {
            Console.Clear();
            Console.WriteLine("- Operações realizadas - \n");

            if (quantidadeOperacoesRealizadas == 0)
            {
                Console.WriteLine("Não existe nenhuma operação realizada!");
            }
            else
            {
                for (int i = 0; i < descricoesOperadores.Length; i++)
                {
                    if (descricoesOperadores[i] != null)
                    {
                        Console.WriteLine($"{descricoesOperadores[i]}");
                    }
                }
            }
            VolteParaCalculadora();
        }
        static void CalculoTabuada()
        {
            MensagemTabuada();

            Console.WriteLine($"\n- Tabuada do {tabuada} -\n");

            for (int i = 0; i <= 10; i++)
            {
                int resultadoMultiplicacao = tabuada * i;

                if (resultadoMultiplicacao % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine($"{tabuada} x {i} = {resultadoMultiplicacao}");
                }
                else if (resultadoMultiplicacao % 2 == 1)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{tabuada} x {i} = {resultadoMultiplicacao}");
                }

                descricoesOperadores[quantidadeOperacoesRealizadas] = $"Tabuada do {tabuada}";
            }

            VolteParaCalculadora();
        }
        static void OperacaoMultiplicacao()
        {
            MensagemValores();
            CalculoMultiplicacao();
        }
        static void OperacaoDivisao()
        {
            MensagemValores();
            CalculoDivisao();
        }
        static void OperacaoSubtracao()
        {
            MensagemValores();
            CalculoSubtracao();
        }
        static void OperacaoAdicao()
        {
            MensagemValores();
            CalculoAdicao();
        }
        static void CalculoMultiplicacao()
        {
            resultado = numero1 * numero2;

            resultadoNovo = Math.Round(resultado, 2);

            Console.WriteLine($"\nO resultado é: {resultadoNovo}");

            descricoesOperadores[quantidadeOperacoesRealizadas] = $"{numero1} x {numero2} = {resultadoNovo}";
            VolteParaCalculadora();
        }
        static void CalculoDivisao()
        {
            if (numero1 == 0 || numero2 == 0)
            {
                Console.WriteLine("\nNão pode utilizar o número 0 na divisão! Tente novamente.");
                Console.ReadKey();
            }
            else
            {
                resultado = numero1 / numero2;

                resultadoNovo = Math.Round(resultado, 2);

                Console.WriteLine($"\nO resultado é: {resultadoNovo}");

                descricoesOperadores[quantidadeOperacoesRealizadas] = $"{numero1} / {numero2} = {resultadoNovo}";
                VolteParaCalculadora();
            }
        }
        static void CalculoSubtracao()
        {
            if (numero1 < numero2)
            {
                resultado = numero2 - numero1;

                resultadoNovo = Math.Round(resultado, 2);

                Console.WriteLine($"\nO resultado é: {resultadoNovo}");

                descricoesOperadores[quantidadeOperacoesRealizadas] = $"{numero1} - {numero2} = {resultadoNovo}";
                VolteParaCalculadora();
            }
            else
            {
                resultado = numero1 - numero2;

                resultadoNovo = Math.Round(resultado, 2);

                Console.WriteLine($"\nO resultado é: {resultadoNovo}");

                descricoesOperadores[quantidadeOperacoesRealizadas] = $"{numero1} - {numero2} = {resultadoNovo}";

                VolteParaCalculadora();
            }
        }
        static void CalculoAdicao()
        {
            double resultado = numero1 + numero2;
            resultadoNovo = Math.Round(resultado, 2);

            Console.WriteLine($"\nO resultado é: {resultadoNovo}");

            descricoesOperadores[quantidadeOperacoesRealizadas] = $"{numero1} + {numero2} = {resultadoNovo}";

            VolteParaCalculadora();
        }
        static void VolteParaCalculadora()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        static int MensagemTabuada()
        {
            Console.Clear();

            Console.WriteLine("Informe um um número para gerar a tabuada: ");
            tabuada = Convert.ToInt32(Console.ReadLine());
            return tabuada;
        }
        static void MensagemValores()
        {
            Console.Clear();
            Console.WriteLine("Informe o primeiro número: ");
             numero1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Informe o segundo número: ");
             numero2 = double.Parse(Console.ReadLine());
        }
        static int Menu()
        {
            Console.Clear();
            Console.WriteLine("- Calculadora 2023 - \n");

            Console.WriteLine("==== Operações matemática ====");
            Console.WriteLine("1- Adição \n2- Subtração \n3- Divisão \n4- Multiplicação");
            Console.WriteLine("5- Gerar uma tabuada \n6- Ver operações feitas \n7- Sair");
            Console.Write("\nInforme a opção desejada => ");
            opcao = Convert.ToInt32(Console.ReadLine());

            return opcao;
        }
    }
}