using UnityEngine;
using System.Collections;

public enum EnemyMoveType
{
	Move,

	Hovering,
};

public class EnemyController : MonoBehaviour 
{
	EnemyMoveType moveType = EnemyMoveType.Move;

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private GameObject effect;

	[SerializeField]
	private GameObject deadEffect;

	private Transform playerTransform;

    public Vector3 enemyPos;

    public Vector3 moveAmount;

	public int hp;

	public int attackPower;

	public float shootDelay;

	private float shootDelta = 0.0f;

	public float attackDistance;
	
	public float speed;

	private ScoreDataManager scoreDataManager;

	private bool isLeft = true;


	void Awake()
	{
        // Get Component]
        moveAmount = new Vector3(1.5f, 0f, 0);

		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

		scoreDataManager = GameObject.FindGameObjectWithTag("DataManager").GetComponent<ScoreDataManager>();
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Process();
	
		Attack();

		if (hp <= 0)
		{
			scoreDataManager.AddScore();

			if (deadEffect != null)
				GameObject.Instantiate(deadEffect);

			Destroy(this.gameObject);
		}
	}

	// Processing Section
	void Process()
	{
		switch (moveType)
		{
			// Move
			case EnemyMoveType.Move:
				this.Move();
				break;

			// Hovering
			case EnemyMoveType.Hovering:
				this.Hovering();
				break;

			// Default - Except
			default:
				Debug.Break();
				break;
		}
	}

	// Move Section
	void Move()
	{
		if (Vector3.Magnitude(playerTransform.position - this.transform.position) <= attackDistance)
		{
			moveType = EnemyMoveType.Hovering;
		}


		// Calculating Distance, Direction, Direction2D
		Vector3 distance = playerTransform.position - this.transform.position;
		Vector3 direction = distance.normalized;
		Vector2 direction2D = new Vector2(direction.x, direction.y);

		if (direction2D.x >= 0.0f)
			this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f));
		else
			this.transform.rotation = Quaternion.Euler(new Vector3(0.0f, 180.0f, 0.0f));

		// Add Velocity
		this.GetComponent<Rigidbody2D>().velocity += speed * direction2D * Time.deltaTime;
        enemyPos = this.transform.position;
	}

	// Hovering Section
	void Hovering()
	{
        Vector3 distance = enemyPos-playerTransform.position;
        Vector3 direction = distance.normalized;
        
       if(Vector3.Magnitude(playerTransform.position - this.transform.position) > attackDistance)
        this.moveType = EnemyMoveType.Move;


    }

    // Attack Section
    void StartAttack()
	{
		if (Vector3.Magnitude(playerTransform.position - this.transform.position) <= attackDistance)
		{
			this.GetComponent<Animator>().SetBool("Attack", false);
		}
	}

	public void Attack()
	{
		shootDelta += Time.deltaTime;

		if (Vector3.Magnitude(playerTransform.position - this.transform.position) <= attackDistance &&
			shootDelay <= shootDelta)
		{
			shootDelta = 0.0f;

			this.GetComponent<Animator>().SetBool("Attack", false);

			if (effect != null)
				GameObject.Instantiate(effect).transform.position = this.transform.position + new Vector3(0.0f, 0.0f, 0.0f);

			Instantiate(
				bullet,
				this.transform.position,
				Quaternion.Euler(new Vector3(0.0f, 0.0f, 0.0f)));
		}
	}
}

