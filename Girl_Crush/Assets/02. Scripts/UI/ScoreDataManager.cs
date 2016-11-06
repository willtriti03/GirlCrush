using UnityEngine;
using System.Collections;

public class ScoreDataManager : MonoBehaviour {

	public int score = 0;


	public void AddScore()
	{
		score += 20;
	}

	public void MinusScore()
	{
		score -= 5;
	}
}
