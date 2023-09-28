using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaDeCombustivel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            BombaDeCombustivel bomba = new BombaDeCombustivel("Gasolina", 5.00, 100);

            while (true)
            {
                Console.WriteLine(@"
░█▀▀█ █░░█ ▀▀█▀▀ █▀▀█ 　 ▒█▀▀█ █▀▀█ █▀▀ ▀▀█▀▀ █▀▀█ 
▒█▄▄█ █░░█ ░░█░░ █░░█ 　 ▒█▄▄█ █░░█ ▀▀█ ░░█░░ █░░█ 
▒█░▒█ ░▀▀▀ ░░▀░░ ▀▀▀▀ 　 ▒█░░░ ▀▀▀▀ ▀▀▀ ░░▀░░ ▀▀▀▀"); //Gerado em: https://fsymbols.com/pt/geradores/ 
                bomba.DadosBomba(); //Imprime os dados da bomba de combustivel
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Abastecer por valor");
                Console.WriteLine("2. Abastecer por litro");
                Console.WriteLine("3. Alterar valor do litro");
                Console.WriteLine("4. Alterar tipo de combustível");
                Console.WriteLine("5. Alterar quantidade de combustível");
                Console.WriteLine("0. Sair");
                
                Console.Write("\nOpção escolhida: ");
                int escolha = int.Parse(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Informe o valor a ser abastecido: ");
                        double valorAbastecido = double.Parse(Console.ReadLine());
                        if (valorAbastecido > 0)
                        {
                            double litrosAbastecidos = bomba.AbastecerPorValor(valorAbastecido);

                            if (litrosAbastecidos != 0)
                            {
                                Console.WriteLine($"\nForam abastecidos {litrosAbastecidos:n2} litros.\nQuantidade de combustível restante: {bomba.QuantidadeCombustivel:n2} litros");
                            }
                            else
                            {
                                Console.WriteLine("\nQuantidade de combustível insuficiente.");                                
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nValor inválido. O valor deve ser maior que zero.");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.Write("Informe a quantidade em litros de combustível: ");
                        double litrosParaAbastecer = double.Parse(Console.ReadLine());
                        if (litrosParaAbastecer > 0)
                        {
                            double valorAPagar = bomba.AbastecerPorLitro(litrosParaAbastecer);

                            if (valorAPagar != 0)
                            {
                                Console.WriteLine($"\nValor a pagar: {valorAPagar:c2}.\nQuantidade de combustível restante: {bomba.QuantidadeCombustivel:n2} litros");
                            }
                            else
                            {
                                Console.WriteLine("\nQuantidade de combustível insuficiente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nQuantidade inválida. A quantidade deve ser maior que zero.");
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.Write("Informe o novo valor do litro: ");
                        double novoValorLitro = double.Parse(Console.ReadLine());
                        if (novoValorLitro > 0)
                        {
                            bomba.AlterarValor(novoValorLitro);
                            Console.WriteLine($"\nValor do litro alterado para: {novoValorLitro:c2}");
                        }
                        else
                        {
                            Console.WriteLine("\nValor inválido. O valor do litro deve ser maior que zero.");
                        }                                                
                        break;
                    case 4:
                        Console.Clear();
                        Console.Write("Informe o novo tipo de combustível: ");
                        string novoTipoCombustivel = Console.ReadLine();
                        if (!string.IsNullOrEmpty(novoTipoCombustivel)) //Verifica se a string é vazia ou nula
                        {
                            bomba.AlterarCombustivel(novoTipoCombustivel);
                            Console.WriteLine($"\nTipo de combustível alterado para: {novoTipoCombustivel.ToUpper()}");
                        }
                        else
                        {
                            Console.WriteLine("\nTipo de combustível inválido. Informe um tipo válido.");
                        }                     
                        break;
                    case 5:
                        Console.Clear();
                        Console.Write("Informe a nova quantidade de combustível: ");
                        double novaQuantidadeCombustivel = double.Parse(Console.ReadLine());
                        if (novaQuantidadeCombustivel > 0)
                        {
                            bomba.AlterarQuantidadeCombustivel(novaQuantidadeCombustivel);
                            Console.WriteLine($"\nQuantidade de combustível alterada para: {novaQuantidadeCombustivel:n2} litros");
                        }
                        else
                        {
                            Console.WriteLine("\nQuantidade inválida. A quantidade de combustível deve ser maior que zero.");
                        }                        
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("\n\nPressione qualquer tecla para realizar outra operação...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
