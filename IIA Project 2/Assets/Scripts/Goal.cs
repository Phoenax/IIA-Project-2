﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

	public GameObject ballSpawner;
	public GameObject ball;
	public GameObject BluePlayer;
	public GameObject RedPlayer;
	public ScoreKeeper scoreKeeper;

	public enum WhichGoal
	{
		Blue,
		Red,

	}
	public WhichGoal whichGoal;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "ball")
		{
			//set the ball's position equal to the ball spawner's position; i.e., reset the ball position
			ball.transform.position = ballSpawner.transform.position;
			//cancel out the ball's velocity
			ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
			//cancel out the ball's angular velocity
			ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			//call the ScoreGoal() method to add a poin
			scoreKeeper.ScoreGoal((int)whichGoal);

			if ((int)whichGoal == 0)
			{
				if (RedPlayer != null && RedPlayer.GetComponent<NeuralController>().lastHit == true)
					RedPlayer.GetComponent<NeuralController>().autoGoals++;
			}
			else
			{
				if (BluePlayer != null && BluePlayer.GetComponent<NeuralController>().lastHit == true)
					BluePlayer.GetComponent<NeuralController>().autoGoals++;
			}

		}
	}

}
