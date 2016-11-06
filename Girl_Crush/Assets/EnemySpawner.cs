using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;

	// Use this for initialization
	void Start () 
	{
		Invoke("Spawn", 4.0f);
	}

	void Spawn()
	{
		Vector3 direction = new Vector3();
		// X
		if(Random.Range(0,4) <= 1)
			direction.x = Random.Range(10.0f, 20.0f);
		else
			direction.x = Random.Range(-10.0f, -20.0f);

		// Y
		if (Random.Range(0, 4) <= 1)
			direction.y = Random.Range(10.0f, 20.0f);
		else
			direction.y = Random.Range(-10.0f, -20.0f);

		GameObject.Instantiate(enemy).transform.position = new Vector3(direction.x, direction.y, 0.0f);

		Invoke("Spawn", 1.0f);
	}
}
