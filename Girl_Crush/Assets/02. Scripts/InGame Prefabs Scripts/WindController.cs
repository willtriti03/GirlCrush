using UnityEngine;

using System.Collections.Generic;

public class WindController : MonoBehaviour
{
	public Vector3 direction;

	public GameObject effect;

	public int attackPower;

	public float speed;

	private List<EnemyController> enemies;


	void Awake()
	{
		Invoke("DestorySelf", 10.0f);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Move();

		Rotate();
	}

	// Move
	void Move()
	{
		this.transform.localPosition += direction * speed * Time.deltaTime;
	}

	// Rotate
	void Rotate()
	{
		float rotation = Mathf.Atan2(direction.y, direction.x);

		this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotation));
	}

	// Collision Enter 2D
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			foreach (var enemy in enemies)
			{
				enemy.hp -= attackPower;
			}

			if (effect != null)
				GameObject.Instantiate(effect).transform.position = this.transform.position;

			Destroy(this.gameObject);
		}
	}

	// OnTrigger Enter 2D
	void OnTriggerEnter2D(Collider2D other)
	{
		// if Enemy
		if (other.gameObject.CompareTag("Enemy"))
		{
			// Contains Check
			if (enemies.Contains(other.GetComponent<EnemyController>()) == false)
			{
				// Add
				enemies.Add(other.GetComponent<EnemyController>());
			}
		}
	}


	// OnTrigger Exit 2D
	void OnTriggerExit2D(Collider2D other)
	{
		// if Enemy
		if (other.gameObject.CompareTag("Enemy"))
		{
			// Contains Check
			if (enemies.Contains(other.GetComponent<EnemyController>()))
			{
				// Add
				enemies.Remove(other.GetComponent<EnemyController>());
			}
		}
	}

	void DestroySelf()
	{
		Destroy(this.gameObject);
	}

}



