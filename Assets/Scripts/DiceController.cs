using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
	public GameObject[] dice;
	public int framesPerRoll;
	public int rolls;
	int rollFrameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rollFrameCount > 0)
		{
			if (rollFrameCount % framesPerRoll == 0)
			{
				Debug.Log("rolled");
				foreach (GameObject die in dice)
				{
					die.transform.position = transform.position;
				}
			}
			rollFrameCount--;
		}
    }

	public void RollDice()
	{
		rollFrameCount = rolls * framesPerRoll;
	}
}
