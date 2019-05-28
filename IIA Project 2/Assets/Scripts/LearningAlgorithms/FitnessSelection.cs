using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FitnessSelection : SelectionMethod
{
	public override List<Individual> selectIndividuals(List<Individual> oldpop, int tournamentSize, float tournamentProbability)
	{
		List<Individual> tmp = oldpop;
		while(tmp.Count > tournamentSize)
		{
			Individual contestant1 = tmp[Random.Range(0, tmp.Count)];
			tmp.Remove(contestant1);
			Individual contestant2 = tmp[Random.Range(0, tmp.Count)];
			tmp.Remove(contestant2);
			
			if(Random.value > tournamentProbability)
			{
				if (contestant1.Fitness < contestant2.Fitness)
					tmp.Add(contestant1);
				else
					tmp.Add(contestant2);
			}
			else
			{
				if (contestant1.Fitness > contestant2.Fitness)
					tmp.Add(contestant1);
				else
					tmp.Add(contestant2);
			}

		}

		return tmp;
	}
}