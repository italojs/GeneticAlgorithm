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

        public static Individual[] Crossover(Individual individual1, Individual individual2)
        {
            Random r = new Random();

            //sorteia o ponto de corte
            int Cutoff1 = r.Next((individual1.Genes.Length / 2) - 2) + 1;
            int Cutoff2 = r.Next((individual1.Genes.Length / 2) - 2) + individual1.Genes.Length / 2;

            Individual[] sons = new Individual[2];

            //pega os genes dos pais
            string fatherGene1 = individual1.Genes;
            string fatherGene2 = individual2.Genes;

            string SonGene1;
            string sonGene2;

            //realiza o corte, 

            //WARNNING
            //aqui nos temos o seguinte problema, no java nós temos subtring(onde começa, onde termina);
            //no c# nós temos substring(onde começa, mais quantas casas pra frente tu quer pegar);
            //isso esta influenciando a logica do algoritimo
            //ainda nao tive tempo de arrumar isso
            //solução simples e porca até agora Substring(Cutoff2, fatherGene1.Length - Cutoff2);
            SonGene1 = fatherGene1.Substring(0, Cutoff1);
            SonGene1 += fatherGene2.Substring(Cutoff1, Cutoff2);
            SonGene1 += fatherGene1.Substring(Cutoff2, fatherGene1.Length);

            sonGene2 = fatherGene2.Substring(0, Cutoff1);
            sonGene2 += fatherGene1.Substring(Cutoff1, Cutoff2);
            sonGene2 += fatherGene2.Substring(Cutoff2, fatherGene2.Length);

            //cria o novo indivíduo com os genes dos pais
            sons[0] = new Individual(SonGene1);
            sons[1] = new Individual(sonGene2);

            return sons;
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
