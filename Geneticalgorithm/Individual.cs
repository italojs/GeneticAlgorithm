using System;
using System.Collections.Generic;
using System.Text;

namespace Geneticalgorithm
{
    public class Individual
    {

        private string _genes;
        private int _aptitude = 0;
        Random _r = new Random();

        public string Genes => _genes;
        public int Aptitude => _aptitude;

        //gera um indivíduo aleatório
        public Individual(int numGenes)
        {
            _genes = "";

            GenerateRandomIndividual(numGenes, Algorithm.Characters);
            GernerateAptitude();
        }

        //cria um indivíduo com os genes definidos
        public Individual(string genes)
        {
            _genes = genes;

            DevelopMutation();
            GernerateAptitude();
        }

        public void GenerateRandomIndividual(int numGenes, string chars)
        {
            //Pega um caracter aleatorio dentro dos caracteres
            //permitido e joga sem sequencia para o _genes
            for (int i = 0; i < numGenes; i++)
                _genes += chars[(_r.Next(chars.Length))];
        }

        public void DevelopMutation()
        {
            //se for mutar, cria um gene aleatório
            if (_r.NextDouble() <= Algorithm.MutationRate)
            {
                string chars = Algorithm.Characters;
                string newGene = "";

                int randomNumber = _r.Next(_genes.Length);

                for (int i = 0; i < _genes.Length; i++)
                {
                    if (i == randomNumber)
                        newGene += chars[_r.Next(chars.Length)];
                    else
                        newGene += _genes[i];
                }

                _genes = newGene;
            }
        }

        //gera o valor de aptidão, será calculada pelo número de bits do gene iguais ao do resultado final
        private void GernerateAptitude()
        {
            string finalResult = Algorithm.FinalResult;
            
            for (int i = 0; i < finalResult.Length; i++)
            {
                try
                {
                    if (_genes[i] == finalResult[i])
                        _aptitude++;
                }
                catch { }
            }
        }


    }
}
