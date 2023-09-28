using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BombaDeCombustivel
{
    public class BombaDeCombustivel
    {
        //Atributos privados. Assim não podem ser acessados fora da classe
        private string tipoCombustivel;
        private double valorLitro;
        private double quantidadeCombustivel;

        //Definindo as propriedades para acessar os atribuitos
        public string TipoCombustivel { get { return tipoCombustivel; }}                //Propriedade somente leitura
        public double ValorLitro { get { return valorLitro; } }                         //Propriedade somente leitura
        public double QuantidadeCombustivel { get { return quantidadeCombustivel; } }   //Propriedade somente leitura

        //Construtor da Classe
        public BombaDeCombustivel(string tipoCombustivel, double valorLitro, double quantidadeCombustivel)
        {
            //Como as propriedades não possuem SET, devemos passar os valores diretamente para os atributos
            this.tipoCombustivel = tipoCombustivel;
            this.valorLitro = valorLitro;
            this.quantidadeCombustivel = quantidadeCombustivel;
        }

        //Métodos
        public double AbastecerPorValor(double valor)
        {            
            double litrosAbastecidos = valor / valorLitro;
            if (litrosAbastecidos <= quantidadeCombustivel)
            {
                quantidadeCombustivel -= litrosAbastecidos;
                return litrosAbastecidos;
            }
            else
            {
                return 0;
            }
        }

        public double AbastecerPorLitro(double litros)
        {
            double valorAPagar = litros * valorLitro;
            if (litros <= quantidadeCombustivel)
            {
                quantidadeCombustivel -= litros;
                return valorAPagar;
            }
            else
            {
                return 0;
            }           
        }

        public void AlterarValor(double novoValor)
        {            
                valorLitro = novoValor;
        }

        public void AlterarCombustivel(string novoTipo)
        {            
                tipoCombustivel = novoTipo;           
        }

        public void AlterarQuantidadeCombustivel(double novaQuantidade)
        {            
                quantidadeCombustivel = novaQuantidade;            
        }

        public void DadosBomba()
        {
            Console.WriteLine("\n**************************************");
            Console.WriteLine($"Combustível: {tipoCombustivel.ToUpper()}");
            Console.WriteLine($"Valor do litro: {valorLitro:c2}");
            Console.WriteLine($"Quantidade Disponível: {quantidadeCombustivel:n2}");
            Console.WriteLine("**************************************\n");
        }
    }
}
