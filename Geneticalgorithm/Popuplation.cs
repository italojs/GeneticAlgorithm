using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Geneticalgorithm
{
    public class Population
    {

        private Individual[] _individuals;
        private int _populationLenth;

        public int PopulationLenth => _populationLenth;
        public Individual[] Individuals => _individuals;


        //cria uma população com indivíduos aleatória
        public Population(int numGenes, int populationLenth)
        {
            _populationLenth = populationLenth;
            _individuals = new Individual[populationLenth];
            for (int i = 0; i < _individuals.Length; i++)
            {
               //comentar isso aqui
                Thread.Sleep(30);
                _individuals[i] = new Individual(numGenes);
            }
        }

        //cria uma população com indivíduos sem valor, será composto posteriormente
        public Population(int populationLenth)
        {
            _populationLenth = populationLenth;
            _individuals = new Individual[populationLenth];
            for (int i = 0; i < _individuals.Length; i++)
            {
                _individuals[i] = null;
            }
        }

        //coloca um indivíduo em uma certa posição da população
        public void SetIndividuo(Individual individual, int posicao)
        {
            _individuals[posicao] = individual;
        }

        //coloca um indivíduo na próxima posição disponível da população
        public void SetIndividuo(Individual individuo)
        {
            for (int i = 0; i < _individuals.Length; i++)
            {
                if (_individuals[i] == null)
                {
                    _individuals[i] = individuo;
                    return;
                }
            }
        }

        //verifoca se algum indivíduo da população possui a resultado final
        public bool MathFinalResult(string finalResult)
        {
            for (int j = 0; j < _individuals.Length; j++)
            {
                if (_individuals[j].Genes == finalResult)
                    return true;   
            }
            return false;
        }

        //ordena a população pelo valor de aptidão de cada indivíduo, do maior valor para o menor, assim se eu quiser obter o melhor indivíduo desta população, acesso a posição 0 do array de indivíduos
        public void SortPopulation()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < _individuals.Length - 1; i++)
                {
                    if (_individuals[i].Aptitude < _individuals[i + 1].Aptitude)
                    {
                        Individual temp = _individuals[i];
                        _individuals[i] = _individuals[i + 1];
                        _individuals[i + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        //número de indivíduos existentes na população
        public int GetIndividualsQuantity()
        {
            int num = 0;
            for (int i = 0; i < _individuals.Length; i++)
            {
                if (_individuals[i] != null)
                {
                    num++;
                }
            }
            return num;
        }

        public Individual GetIndivdualAt(int position)
        {
            return _individuals[position];
        }

        public Individual GetBestIndividual()
        {
            SortPopulation();
            return _individuals[0];
        }
    }
}
