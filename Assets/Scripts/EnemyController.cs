using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
	public HealthBarController healthBar;
	public int maxHealth;
	int health;
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
		healthBar.maxHealth = maxHealth;
		healthBar.Health = maxHealth;
		health = maxHealth;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
