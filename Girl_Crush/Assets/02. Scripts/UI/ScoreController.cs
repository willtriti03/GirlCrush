using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class ScoreController : MonoBehaviour 
{
	[SerializeField]
	private ScoreDataManager scoreManager = null;		// Score Manager

	// Text
	private Text text;

	// Awake
	private void Awake()
	{
		text = this.GetComponent<Text>();
	}

	// Update is called once per frame
	void Update ()
	{
		text.text = scoreManager.score.ToString();
	}
}

