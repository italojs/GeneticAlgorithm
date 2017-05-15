using System;
using System.Collections.Generic;
using System.Text;

namespace Geneticalgorithm
{
    public class Algorithm
    {

        public static string FinalResult { get; set; }
        public static string Characters { get; set; }
        public static double CrossoverRate { get; set; }
        public static double MutationRate { get; set; }

        public static Population NewGeneration(Population population, bool elitism)
        {
            Random r = new Random();
            //nova população do mesmo tamanho da antiga
            Population newPopulation = new Population(population.PopulationLenth);

            //se tiver elitismo, mantém o melhor indivíduo da geração atual
            if (elitism)
            {
                newPopulation.SetIndividuo(population.GetIndivdualAt(0));
            }

            //insere novos indivíduos na nova população, até atingir o tamanho máximo
            while (newPopulation.GetIndividualsQuantity() < newPopulation.PopulationLenth)
            {
                //seleciona os 2 pais por torneio
                Individual[] fathers = GetTwoBestIndividual(population);

                Individual[] child = new Individual[2];

                //verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
                if (r.NextDouble() <= CrossoverRate)
                {
                    child = Crossover(fathers[1], fathers[0]);
                }
                else
                {
                    child[0] = new Individual(fathers[0].Genes);
                    child[1] = new Individual(fathers[1].Genes);
                }

                //adiciona os filhos na nova geração
                newPopulation.SetIndividuo(child[0]);
                newPopulation.SetIndividuo(child[1]);
            }

            //ordena a nova população
            newPopulation.SortPopulation();
            return newPopulation;
        }

        public static Individual[] Crossover(Individual individuo1, Individual individuo2)
        {
            Random r = new Random();

            //sorteia o ponto de corte
            int pontoCorte1 = r.Next((individuo1.Genes.Length / 2) - 2) + 1;
            int pontoCorte2 = r.Next((individuo1.Genes.Length / 2) - 2) + individuo1.Genes.Length / 2;

            Individual[] filhos = new Individual[2];

            //pega os genes dos pais
            string genePai1 = individuo1.Genes;
            string genePai2 = individuo2.Genes;

            string geneFilho1;
            string geneFilho2;

            //realiza o corte, 
            geneFilho1 = genePai1.Substring(0, pontoCorte1);
            geneFilho1 += genePai2.Substring(pontoCorte1, pontoCorte2);
            geneFilho1 += genePai1.Substring(4, 9);

            geneFilho2 = genePai2.Substring(0, pontoCorte1);
            geneFilho2 += genePai1.Substring(pontoCorte1, pontoCorte2);
            geneFilho2 += genePai2.Substring(pontoCorte2, genePai2.Length);

            //cria o novo indivíduo com os genes dos pais
            filhos[0] = new Individual(geneFilho1);
            filhos[1] = new Individual(geneFilho2);

            return filhos;
        }

        public static Individual[] GetTwoBestIndividual(Population Population)
        {
            Random r = new Random();
            Population PopulationIntermediaria = new Population(3);

            //seleciona 3 indivíduos aleatóriamente na população
            PopulationIntermediaria.SetIndividuo(Population.GetIndivdualAt(r.Next(Population.PopulationLenth)));
            PopulationIntermediaria.SetIndividuo(Population.GetIndivdualAt(r.Next(Population.PopulationLenth)));
            PopulationIntermediaria.SetIndividuo(Population.GetIndivdualAt(r.Next(Population.PopulationLenth)));

            //ordena a população
            PopulationIntermediaria.SortPopulation();

            Individual[] pais = new Individual[2];

            //seleciona os 2 melhores deste população
            pais[0] = PopulationIntermediaria.GetIndivdualAt(0);
            pais[1] = PopulationIntermediaria.GetIndivdualAt(1);

            return pais;
        }

    }
}
