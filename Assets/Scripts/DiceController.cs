using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Face
{
	Sword,
	Shield,
	Potion
}

public class DiceController : MonoBehaviour
{
	public DieController[] dice;
	public int framesPerRoll;
	public int rolls;
	public LayerMask dieLayer;
	public GameObject[] holdBoxes;
	List<Face> heldDice;
	int finishedDice = 0;
	int rollFrameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
		heldDice = new List<Face>();
		foreach (DieController die in dice)
		{
			die.diceController = this;
		}
    }

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, dieLayer))
			{
				DieController dc = hit.transform.gameObject.GetComponent<DieController>();
				if (dc.Hold(holdBoxes[heldDice.Count].transform.position))
				{
					heldDice.Add(Face.Sword);
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

	public void TryEndTurn()
	{
		finishedDice++;
		if (finishedDice == 5)
		{
			finishedDice = 0;
			for (int i = 0; i < 5; i++)
			{
				dice[i].Reset();
				dice[i].transform.position = transform.position + Vector3.right * (i - 2) * 2 + Vector3.up * 2;

			}
			heldDice.Clear();
		}
	}
}
