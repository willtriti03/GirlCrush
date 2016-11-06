using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour
{

	// Be Chased Object
	public GameObject _ChasedObject;

	// Chasing Speed
	public float _Speed;

	public Vector3 _Offset;


	// StartDelay Time		
	[SerializeField]
	private float _DelayTime;

	// Be Move
	public bool _Move;

	// Is Completed
	public bool _CompleteAction = false;

	// is Staring
	private bool _Start = false;


	private void Awake()
	{
		this._Offset = this.transform.position -_ChasedObject.transform.position;
	}

	// Update pre End Frame
	private void FixedUpdate()
	{
		if (_Move && !_Start)
			Invoke("StartMove", _DelayTime);

		// Move
		UpdatePosition();
	}


	// Turn On Start Property
	private void StartMove()
	{
		_Start = true;
	}


	// Calculating and Move
	private bool UpdatePosition()
	{
		if (_Start && _Move)
		{

			// Almost Attach
			if (Mathf.Abs(this.transform.position.x - _ChasedObject.transform.position.x) <= 0.1f &&
			   Mathf.Abs(this.transform.position.y - _ChasedObject.transform.position.y) <= 0.1f)
			{
				_CompleteAction = true;
				return true;		// Completed Action
			}

			this.transform.position = Vector3.Lerp(this.transform.position, _ChasedObject.transform.position + _Offset, _Speed * Time.deltaTime);
		}
		_CompleteAction = false;
		return false;		// Not Yet
	}
}
