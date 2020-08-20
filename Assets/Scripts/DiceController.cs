using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
	public DieController[] dice;
	public int framesPerRoll;
	public int rolls;
	public LayerMask dieLayer;
	public GameObject[] holdBoxes;
	int heldDice = 0;
	int rollFrameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, dieLayer))
			{
				if (hit.transform.gameObject.GetComponent<DieController>().Hold(holdBoxes[heldDice].transform.position))
				{
					heldDice++;
				}
			}
		}
	}

	// Update is called once per frame
	void FixedUpdate()
    {
        if (rollFrameCount > 0)
		{
			if (rollFrameCount % framesPerRoll == 0)
			{
				foreach (DieController die in dice)
				{
					if (!die.Held)
					{
						die.Roll(transform.position);
					}
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
