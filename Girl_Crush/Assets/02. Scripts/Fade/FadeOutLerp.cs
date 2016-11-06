using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace Fade
{
	public class FadeOutLerp : MonoBehaviour {
		
		public bool			_FadeOut;					// ON OFF
		
		public float		_Speed;						// SPEED
		
		public float 		_Delaytime;					// DELAY TIME
		
		public bool			_CompleteAction = false;	// Completed Action
		
		private bool		_Start = false;				// IS START

		public bool			_isChange = false;
		
		private float		_R, _G, _B;					// RGB
		
		// Use this for initialization
		private void Start () {
			
			if(this.GetComponent<Renderer>())
			{
				_R = this.GetComponent<Renderer>().material.color.r;
				_G = this.GetComponent<Renderer>().material.color.g;
				_B = this.GetComponent<Renderer>().material.color.b;
			}
			else
			{
				_R = this.GetComponent<Image>().color.r;
				_G = this.GetComponent<Image>().color.g;
				_B = this.GetComponent<Image>().color.b;
			}
		}
		
		// Update is called once per frame
		private void Update () 
		{
			if(_FadeOut && !_Start && !_isChange)
			{
				this.GetComponent<FadeInLerp>()._FadeIn = false;		// Disable

				Invoke("StartFade", _Delaytime);
				_isChange = true;
			}


			if(_FadeOut && _Start)
				_CompleteAction = UpdateFade();

			if (_CompleteAction)
			{
				_FadeOut = false;
			}
		}
		
		private void StartFade()
		{
			_Start = true;
		}
		
		// FadeIn Update
		private bool UpdateFade()
		{
			float alpha;
			
			if(this.GetComponent<Renderer>())
				alpha = this.GetComponent<Renderer>().material.color.a;
			else
				alpha = this.GetComponent<Image>().color.a;
			
			if (alpha <= 0.05f)
			{
				if(this.GetComponent<Renderer>())
					this.GetComponent<Renderer>().material.color =  new Color(_R, _G, _B, 0.0f);
				else
					this.GetComponent<Image>().color = new Color(_R, _G, _B, 0.0f);

				return true;
			}
			else
			{
				if(this.GetComponent<Renderer>())
					this.GetComponent<Renderer>().material.color =  new Color(_R, _G, _B, Mathf.Lerp(alpha, 0.0f, _Speed * Time.deltaTime));
				else
					this.GetComponent<Image>().color = new Color(_R, _G, _B, Mathf.Lerp(alpha, 0.0f, _Speed * 0.1f * Time.deltaTime));
				
				return false;
			}
		}
	}
}

