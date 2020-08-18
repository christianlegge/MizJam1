using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupController : MonoBehaviour
{
	public LayerMask tableLayer;
	bool holding = false;
	Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
		body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (holding)
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, Mathf.Infinity, tableLayer))
			{
				//body.AddForce(((hit.point + Vector3.up * 2) - transform.position) * 600);
				body.velocity = (((hit.point + Vector3.up * 2) - transform.position) * 100) * Time.fixedDeltaTime * 7;
				body.MoveRotation(Quaternion.Euler(-90, 0, 0));
				body.angularVelocity = Vector3.zero;
			}
			
		}
    }

	void OnMouseDown()
	{
		holding = true;
	}

	void OnMouseUp()
	{
		holding = false;
	}
}
