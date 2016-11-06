using UnityEngine;
using UnityEngine.UI;

using System.Collections;

namespace Fade
{
	public class FadeInLerp : MonoBehaviour {
		
		public bool			_FadeIn;					// ON OFF
		
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
			
			
			if(_FadeIn && !_Start)
				Invoke("StartFade", _Delaytime);
		}
		
		// Update is called once per frame
		private void Update () 
		{	
			if(_FadeIn && !_Start && !_isChange)
			{
				this.GetComponent<FadeOutLerp>()._FadeOut = false;		// Disable

				Invoke("StartFade", _Delaytime);
				_isChange = true;
			}

			if(_FadeIn && _Start)
				_CompleteAction = UpdateFade();
			
			if(_CompleteAction)
			{
				_FadeIn = false;
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
			
			if (alpha >= 0.95f)
			{
				if(this.GetComponent<Renderer>())
					this.GetComponent<Renderer>().material.color =  new Color(_R, _G, _B, 1.0f);
				else
					this.GetComponent<Image>().color = new Color(_R, _G, _B, 1.0f);
				
				return true;
			}
			else
			{
				if(this.GetComponent<Renderer>())
					this.GetComponent<Renderer>().material.color =  new Color(_R, _G, _B, Mathf.Lerp(alpha, 1.0f, _Speed * Time.deltaTime));
				else
					this.GetComponent<Image>().color = new Color(_R, _G, _B, Mathf.Lerp(alpha, 1.0f, _Speed * 0.1f * Time.deltaTime));
				
				return false;
			}
		}
	}
}
