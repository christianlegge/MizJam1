using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public enum Face
{
	Sword,
	Shield,
	Potion
}

public class DiceController : MonoBehaviour
{
	public PlayerController player;
	public EnemyController enemy;
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
		System.Random r = new System.Random();
		Array faceTypes = Enum.GetValues(typeof(Face));
		foreach (DieController die in dice)
		{
			die.diceController = this;
			for (int i = 0; i < 6; i++)
			{
				die.SetFace((Face)faceTypes.GetValue(r.Next(faceTypes.Length)), i);
			}
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
					heldDice.Add(dc.GetUpwardFace());
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
				if (heldDice[i].Equals(Face.Sword))
				{
					Debug.Log("hitting enemy");
					enemy.Health--;
				}
				else if (heldDice[i].Equals(Face.Potion))
				{
					player.Health++;
				}
				dice[i].Reset();
				dice[i].transform.position = transform.position + Vector3.right * (i - 2) * 2 + Vector3.up * 2;
				

			}
			Debug.Log("hitting player");
			player.Health -= 5;
			heldDice.Clear();
		}
	}
}
