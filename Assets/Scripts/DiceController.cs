using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
	public GameObject[] dice;
	public int framesPerRoll;
	public int rolls;
	public LayerMask dieLayer;
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
				hit.transform.gameObject.GetComponent<DieController>().Hold();
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
				Debug.Log("rolled");
				foreach (GameObject die in dice)
				{
					die.transform.rotation = Quaternion.Euler(Random.onUnitSphere * 360);
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
