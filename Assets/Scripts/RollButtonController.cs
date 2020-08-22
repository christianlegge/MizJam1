using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButtonController : MonoBehaviour
{
	public GameObject[] buttons;
	int activeButtons = 3;

    public void RemoveButton()
	{
		if (activeButtons > 0)
		{
			buttons[3 - activeButtons].SetActive(false);
			activeButtons--;
		}
	}

	public void ReplaceButtons()
	{
		for (int i = 0; i < 3; i++)
		{
			buttons[i].SetActive(true);
		}
		activeButtons = 3;
	}

}
