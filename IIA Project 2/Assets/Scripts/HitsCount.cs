using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitsCount : MonoBehaviour
{

    public GameObject BluePlayer;
    public GameObject RedPlayer;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BluePlayer")
        {
			if (BluePlayer != null)
			{
				BluePlayer.GetComponent<NeuralController>().hitTheBall++;
				BluePlayer.GetComponent<NeuralController>().lastHit = true;
				RedPlayer.GetComponent<NeuralController>().lastHit = false;
				RedPlayer.GetComponent<NeuralController>().possession += RedPlayer.GetComponent<NeuralController>().possessionTime;
				RedPlayer.GetComponent<NeuralController>().possessionTime = 0;
			}
        }
        else
        {
            if (other.gameObject.tag == "RedPlayer")
            {
				if (RedPlayer != null)
				{
					RedPlayer.GetComponent<NeuralController>().hitTheBall++;
					RedPlayer.GetComponent<NeuralController>().lastHit = true;
					BluePlayer.GetComponent<NeuralController>().lastHit = false;
					BluePlayer.GetComponent<NeuralController>().possession += BluePlayer.GetComponent<NeuralController>().possessionTime;
					BluePlayer.GetComponent<NeuralController>().possessionTime = 0;
				}
            }
        }
    }

}
