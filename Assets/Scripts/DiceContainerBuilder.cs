using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DiceContainerBuilder : MonoBehaviour
{
	public float width;
	public float height;
	public float length;

    // Start is called before the first frame update
    void Start()
	{
		BoxCollider left = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
		BoxCollider right = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
		BoxCollider front = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
		BoxCollider back = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;
		BoxCollider top = gameObject.AddComponent(typeof(BoxCollider)) as BoxCollider;

		left.size = new Vector3(1, height, length);
		left.center = transform.position + (Vector3.left * width / 2);

		right.size = new Vector3(1, height, length);
		right.center = transform.position + (Vector3.right * width / 2);

		front.size = new Vector3(width, height, 1);
		front.center = transform.position + (Vector3.forward * length / 2);

		back.size = new Vector3(width, height, 1);
		back.center = transform.position + (Vector3.back * length / 2);

		top.size = new Vector3(width, 1, length);
		top.center = transform.position + (Vector3.up * height / 2);
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	private void OnDrawGizmosSelected ()
	{
		Gizmos.DrawCube(transform.position, new Vector3(width, height, length));
	}
}
