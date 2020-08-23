using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
	public HealthBarController healthBar;
	public Animator fadeout;
	public int maxHealth;
	int health;
	SpriteRenderer sprite;
	public int Health
	{
		get
		{
			return health;
		}
		set
		{
			health = value;
			if (health < 0)
			{
				health = 0;
			}
			else if (health > maxHealth)
			{
				health = maxHealth;
			}
			healthBar.Health = health;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		sprite = GetComponent<SpriteRenderer>();
		healthBar.maxHealth = maxHealth;
		healthBar.Health = maxHealth;
		health = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {

	}

	public IEnumerator HitFlash()
	{
		for (int i = 0; i < (health == 0 ? 11 : 6); i++)
		{
			if (i == 0 && health == 0)
			{
				StartCoroutine(LoadNextScene());
			}
			sprite.enabled = !sprite.enabled;
			yield return new WaitForSeconds(0.05f);
		}

	}

	IEnumerator LoadNextScene()
	{
		fadeout.SetTrigger("FadeOut");
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(1);
	}
}
