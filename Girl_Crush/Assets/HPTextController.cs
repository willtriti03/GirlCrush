using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class HPTextController : MonoBehaviour {

	[SerializeField]
	private PlayerController player;

	private Text text;

	// Use this for initialization
	void Awake () 
	{
		text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = player.hp.ToString();
	}
}
