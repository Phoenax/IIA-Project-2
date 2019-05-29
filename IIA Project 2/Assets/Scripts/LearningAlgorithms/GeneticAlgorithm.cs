using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GeneticAlgorithm : MetaHeuristic
{
	public float mutationProbability;
	public float crossoverProbability;
	public int tournamentSize;
	public float tournamentProbability;
	public bool elitist;
	public int elitistSize;
	protected FitnessSelection fitnessSelect;

	public override void InitPopulation()
	{
		//You should implement the code to initialize the population here
		population = new List<Individual>();
		while (population.Count < populationSize)
		{
			GeneticIndividual new_ind = new GeneticIndividual(topology);
			new_ind.Initialize();
			population.Add(new_ind);
		}
	}

	//The Step function assumes that the fitness values of all the individuals in the population have been calculated.
	public override void Step()
	{
		System.Random random = new System.Random();
		//You should implement the code runs in each generation here
		List<Individual> new_pop = new List<Individual>();
		updateReport();

		population.Sort((x, y) => x.Fitness.CompareTo(y.Fitness));
		population.Reverse();

		if (elitist == true)
		{
			for(int i = 0; i < elitistSize; i++)
			{
				new_pop.Add(population[i].Clone());
			}
		}

		if (tournamentSize > 0)
		{
			List<Individual> winners = fitnessSelect.selectIndividuals(population,tournamentSize,tournamentProbability);

			for(int i = new_pop.Count; i < population.Count; i++)
			{
				Individual parent1 = winners[Random.Range(0, winners.Count)];
				winners.Remove(parent1);
				Individual parent2 = winners[Random.Range(0, winners.Count)].Clone();

				parent2.Crossover(parent1, crossoverProbability);
				parent2.Mutate(mutationProbability);

				winners.Add(parent1);

				new_pop.Add(parent2);
			}
		}
		else
		{
			for(int i = new_pop.Count; i < populationSize; i++)
			{
				GeneticIndividual tmp = (GeneticIndividual)overallBest.Clone();
				tmp.Mutate(mutationProbability);
				new_pop.Add(tmp);
			}
		}
		population = new_pop;
		generation++;
	}
}
