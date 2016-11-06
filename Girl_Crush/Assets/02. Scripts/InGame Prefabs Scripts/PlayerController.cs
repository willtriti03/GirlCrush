using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour 
{
	public JoyStick joystick;

	public int hp;

	public int attackPower;

	public Vector2 attackDirection;

	private float dashDelta;

	public float dashDelay;

	public float speed;

	public float dashPower;

	public GameObject[] winds;

	public int currentWind;

	

	// Use this for initialization
	void FixedUpdate ()
	{
		dashDelta += Time.deltaTime;
		Move ();

		if (joystick.ReturnPos().x != 0.0f ||
			joystick.ReturnPos().y != 0.0f)
		{
			attackDirection = joystick.ReturnPos();
		}
	}
	
	// Update is called once per frame
	void Move ()
	{
		Vector2 direction = joystick.ReturnPos();

		// RIGHT
		if (attackDirection.x >= 0)		
			this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
		
		// LEFT
		else						
			this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));

		this.GetComponent<Rigidbody2D>().velocity += direction * speed * Time.deltaTime;
	}

	// ATTACK
	public void Attack()
	{
		this.GetComponent<Animator>().SetBool("Attack", true);

		Vector2 direction = joystick.ReturnPos();
		Vector3 direction3 = new Vector3(direction.x, direction.y, 0.0f);

		GameObject.Instantiate(winds[currentWind]).GetComponent<WindController>().direction = direction3;

		currentWind++;

		if (currentWind >= winds.Length)
			currentWind = 0;
	}

	public void Dash()
	{
		if (dashDelta >= dashDelay)
		{
			dashDelta = 0.0f;

			this.GetComponent<Rigidbody2D>().AddForce(attackDirection * dashPower);

			this.GetComponent<Animator>().SetBool("Dash", true);
		}
	}

	public void EndAttack()
	{
		this.GetComponent<Animator>().SetBool("Attack", false);
	}

	public void OnCollisionEnter2D(Collision2D other)
	{
		// Bullet
		if (other.gameObject.CompareTag("Bullet"))
		{
			// Reduce HP
			hp -= other.gameObject.GetComponent<BulletController>().attackPower;
		}

		// Trap
		else if (other.gameObject.CompareTag("Trap"))
		{
			hp -= other.gameObject.GetComponent<TrapController>().attackPower;
		}
	}


	public void EndDash()
	{
		this.GetComponent<Animator>().SetBool("Dash", false);
	}




	public void GetRed()
	{
		this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
		Invoke("GetOrigin", 1.0f);
	}
	void GetOrigin()
	{
		this.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
	}
}


