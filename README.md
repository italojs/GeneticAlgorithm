# GeneticAlgorithm
A simple genetic algorithm that simule the string evolution by a lot generations making crossover betwen the genes(strings) for each generation.

##PseudoCode
```
	S(t) is the chromosomes population in t generation
	t ? 0
	initialize S(t)
	eveluate S(t)
	while(false) 
	t ? t+ 1
	select S(t) from S(t- 1)
	apply crossover at S(t)
 	apply mutation at S(t)
 	eveluate S(t)
	end (or repeat)
```

## Getting Started

Just Dowlaod this and run.

You can change some values to test more settings at Program Class(when have the Main Method)
```
	    //result that program must find
            Algorithm.FinalResult = "Ola Mundo";
            //letters the program can use
            Algorithm.Characters = "!,.:;?·¡„√‚¬ı’Ù‘Û”ÈÍ… ÌQWERTYUIOPASDFGHJKL«ZXCVBNMqwertyuiopasdfghjklÁzxcvbnm1234567890 ";
            Algorithm.CrossoverRate = 0.6;
            Algorithm.MutationRate = 0.3;
            //just set true
            bool eltism = true;
            //Population Lenth for each generation
            int PopulationLenth = 100;
            long MaxGenerations = 10000;
```

### Prerequisites

Visual Studio only

### Installing

Just dowload the project and set a double-click into Geneticalgorithm.sln


## Contributing

soon...

