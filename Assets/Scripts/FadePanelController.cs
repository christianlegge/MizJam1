using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadePanelController : MonoBehaviour
{
	public Animator animator;
	public float animationTime = 1f;

    public void FadeOutScene()
	{
		StartCoroutine(LoadLevel());
	}

	IEnumerator LoadLevel()
	{
		animator.SetTrigger("FadeOut");
		yield return new WaitForSeconds(animationTime);
		SceneManager.LoadScene(1);
	}
}
