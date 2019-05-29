using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticIndividual : Individual
{

	public GeneticIndividual(int[] topology) : base(topology)
	{
	}

	public override void Initialize()
	{
		//Implementar
		for (int i = 0; i < totalSize; i++)
		{
			genotype[i] = topology[i];
		}
	}

	public override void Crossover(Individual partner, float probability)
	{
		//Implementar
		GeneticIndividual tmp = (GeneticIndividual)partner.Clone();
		if (Random.Range(0.0f, 1.0f) < probability)
		{
			for (int i = 0; i < totalSize/2; i++)
			{
				genotype[i] = tmp.genotype[i];
			}
		}
	}

	public override void Mutate(float probability)
	{
		//Implementar
		for (int i = 0; i < totalSize; i++)
		{
			if (Random.Range(0.0f, 1.0f) < probability)
			{
				genotype[i] = Random.Range(-1.0f, 1.0f);
			}
		}
	}

	public override Individual Clone()
	{
		GeneticIndividual new_ind = new GeneticIndividual(this.topology);
		genotype.CopyTo(new_ind.genotype, 0);
		new_ind.fitness = this.Fitness;
		new_ind.evaluated = false;

		return new_ind;
	}

}
