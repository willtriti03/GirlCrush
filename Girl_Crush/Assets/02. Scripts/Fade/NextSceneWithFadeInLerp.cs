using UnityEngine;

using System.Collections;

using Fade;

namespace NextScene
{
	public class NextSceneWithFadeInLerp : MonoBehaviour {
		
		public int 			_SceneIndex;				// Scene Index
		
		// Update is called once per frame
		private void Update () {
			
			if( FadeCheck ())
			{
				this.gameObject.GetComponent<FadeInLerp>()._CompleteAction = false;
				Application.LoadLevel(_SceneIndex);
			}
		}
		
		private bool FadeCheck()
		{
			if(this.GetComponent<FadeInLerp>())
			{
				
				return this.gameObject.GetComponent<FadeInLerp>()._CompleteAction;
			}

			else
			{
				return false;
			}
		}
	}
}
