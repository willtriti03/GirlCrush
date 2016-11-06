using UnityEngine;
using System.Collections;

public class TrapController : MonoBehaviour 
{
	public int attackPower;

	public float nuckBackPower;

	public void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			//Debug.Log("ASDF");

			other.gameObject.GetComponent<PlayerController>().hp -= attackPower;

			other.gameObject.GetComponent<PlayerController>().GetRed();

			Vector3 distance = other.transform.position - this.transform.position;
			Vector2 direction = new Vector2(distance.normalized.x, distance.normalized.y);

			other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * nuckBackPower);	
		}
	}
}
