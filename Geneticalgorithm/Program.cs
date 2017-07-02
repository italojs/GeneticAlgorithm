using System;

namespace Geneticalgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define a solução
            Algorithm.FinalResult = "Ola Mundo";
            //Define os caracteres existentes
            Algorithm.Characters = "!,.:;?áÁãÃâÂõÕôÔóÓéêÉÊíQWERTYUIOPASDFGHJKLÇZXCVBNMqwertyuiopasdfghjklçzxcvbnm1234567890 ";
            //taxa de crossover de 60%
            Algorithm.CrossoverRate = 0.6;
            //taxa de mutação de 3%
            Algorithm.MutationRate = 0.3;
            //elitismo
            bool eltism = true;
            //tamanho da população
            int PopulationLenth = 100;
            //numero máximo de gerações
            long MaxGenerations = 1000;


            //cria a primeira população aleatérioa
            Population Population = new Population(Algorithm.FinalResult.Length, PopulationLenth);

            bool mathFinalResult = false;
            int generations = 0;

            Console.WriteLine("Iniciando... Aptidao da solucao: " + Algorithm.FinalResult.Length);

            //loop até o critério de parada
            while (!mathFinalResult && generations < MaxGenerations)
            {
                generations++;

                //cria nova Population
                Population = Algorithm.NewGeneration(Population, eltism);

                Console.WriteLine("Geracao " + generations + " | Aptidao: " + Population.GetIndivdualAt(0).Aptitude + " | Melhor: " + Population.GetIndivdualAt(0).Genes);

                //verifica se tem a solucao
                mathFinalResult = Population.MathFinalResult(Algorithm.FinalResult);
            }

            if (generations == MaxGenerations)
            {
                Console.WriteLine("Numero Maximo de Geracoes | " + Population.GetIndivdualAt(0).Genes + " " + Population.GetIndivdualAt(0).Aptitude);
            }

            if (mathFinalResult)
            {
                Console.WriteLine("Encontrado resultado na geracao " + generations + " | " + Population.GetIndivdualAt(0).Genes + " (Aptidao: " + Population.GetIndivdualAt(0).Aptitude + ")");
            }

            Console.ReadKey();
        }
    }
    
}