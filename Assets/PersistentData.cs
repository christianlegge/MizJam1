using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
	public int maxHealth;
	[HideInInspector]
	public int health;
	[HideInInspector]
	public int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
		DontDestroyOnLoad(gameObject);
		health = maxHealth;
    }
}
