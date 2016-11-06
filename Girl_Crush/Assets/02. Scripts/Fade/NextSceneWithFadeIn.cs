using UnityEngine;

using System.Collections;

using Fade;

namespace NextScene
{
	public class NextSceneWithFadeIn : MonoBehaviour {

		public int 			_SceneIndex;				// Scene Index

		// Update is called once per frame
		private void Update () {

			if( FadeCheck ())
			{
				Application.LoadLevel(_SceneIndex);
			}
		}

		private bool FadeCheck()
		{
			if(this.GetComponent<FadeIn>())
				return this.gameObject.GetComponent<FadeIn>()._CompleteAction;
			else
				return false;
		}
	}
}

