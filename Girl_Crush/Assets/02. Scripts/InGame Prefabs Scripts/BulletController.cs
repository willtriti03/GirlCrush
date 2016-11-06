using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public GameObject effect;
	
	public float speed;		// Speed;

	public int attackPower;

	public Vector3 direction;

	private Transform playerTransform;

	void Awake()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		Vector3 distance = playerTransform.position - this.transform.position; ;
		direction = distance.normalized;

		this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f));

		Invoke("DestroySelf", 10.0f);
	}

	// Update is called once per frame
	void Update ()
	{
		// Move
		this.transform.localPosition += direction * speed * Time.deltaTime;
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
		// Effect
		string tagName = other.gameObject.tag;
		if(tagName == "Player" ||
			tagName == "Trap")
		{
			Destroy(this.gameObject);	
		}
		if (tagName == "Player")
		{
			other.gameObject.GetComponent<PlayerController>().hp -= this.attackPower;
		}
	}

	void DestroySelf()
	{
		Destroy(this.gameObject);
	}
}

