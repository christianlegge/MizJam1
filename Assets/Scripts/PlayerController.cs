using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public HealthBarController healthBar;
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
			healthBar.Health = value;
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
		for (int i = 0; i < 6; i++)
		{
			sprite.enabled = !sprite.enabled;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
