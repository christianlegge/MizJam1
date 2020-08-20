using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public Image bar;
	public Text text;

	[HideInInspector]
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
			text.text = health.ToString() + "/" + maxHealth.ToString();
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		health = maxHealth;
		text.text = health.ToString() + "/" + maxHealth.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
