using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
	public RectTransform bar;
	public Text text;

	[HideInInspector]
	public int maxHealth;
	int health;
	float maxWidth = 0;

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
			if (maxWidth > 0)
			{
				bar.sizeDelta = new Vector2(maxWidth * health / maxHealth, bar.sizeDelta.y);
			}
		}
	}

    // Start is called before the first frame update
    void Start()
    {
		health = maxHealth;
		maxWidth = bar.sizeDelta.x;
		text.text = health.ToString() + "/" + maxHealth.ToString();
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
