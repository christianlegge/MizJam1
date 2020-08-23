using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
	public Sprite[] sprites;
	public HealthBarController healthBar;
	public Animator fadeout;
	public AudioClip hitsound;
	public AudioClip deathsound;
	public Text attackText;
	int maxHealth;
	int health;
	int attack;
	SpriteRenderer sprite;
	AudioSource sound;

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
			if (health == 0)
			{
				sound.clip = deathsound;
			}
			else
			{
				sound.clip = hitsound;
			}
			sound.Play();
		}
	}

	public int Attack
	{
		get
		{
			return attack;
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		sound = GetComponent<AudioSource>();
		System.Random r = new System.Random();
		sprite = GetComponent<SpriteRenderer>();
		sprite.sprite = sprites[r.Next(0, sprites.Length)];
		maxHealth = r.Next(20, 101);
		healthBar.maxHealth = maxHealth;
		healthBar.Health = maxHealth;
		health = maxHealth;
		attack = r.Next(5, 21);
		attackText.text = attack.ToString();
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
		GameObject.FindGameObjectWithTag("PersistentData").GetComponent<PersistentData>().enemiesKilled++;
		yield return new WaitForSeconds(1.0f);
		SceneManager.LoadScene(1);
	}
}
