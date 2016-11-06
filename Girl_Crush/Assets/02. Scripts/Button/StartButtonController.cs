using UnityEngine;
using UnityEngine.UI;
using System.Collections;

using Fade;
using NextScene;

public class StartButtonController : MonoBehaviour 
{
	[SerializeField]
	private FadeInLerp fadeInLerp;

	[SerializeField]
	private NextSceneWithFadeInLerp nextSceneWithLerp;


	public void StartButton()
	{
		fadeInLerp._FadeIn = true;

		nextSceneWithLerp._SceneIndex = 2;
	}
}


