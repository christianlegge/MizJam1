using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public HealthBarController healthBar;
	public Text blockText;
	public int maxHealth;
	int health;
	[HideInInspector]
	public int block = 0;
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
		for (int i = 0; i < 6; i++)
		{
			sprite.enabled = !sprite.enabled;
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void Hit(int damage)
	{
		if (block > 0)
		{
			block -= damage;
			if (block < 0)
			{
				Health += block;
				block = 0;
			}
			blockText.text = block.ToString();
		}
		else
		{
			Health -= damage;
		}
		if (health == 0)
		{
			Debug.Log("dead");
		}
	}
}
