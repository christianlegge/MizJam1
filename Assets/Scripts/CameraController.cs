using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform mainPos;
	public Transform playerPos;
	public Transform enemyPos;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(IntroSequence());
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	IEnumerator MoveToPosition(Transform pos, float moveSpeed)
	{
		while (transform.position != pos.position || transform.localRotation != pos.localRotation)
		{
			transform.position = Vector3.MoveTowards(transform.position, pos.position, (Time.deltaTime * moveSpeed) * Mathf.Clamp(Vector3.Distance(transform.position, pos.position), 0.5f, 10));
			transform.localRotation = Quaternion.RotateTowards(transform.localRotation, pos.localRotation, Time.deltaTime * moveSpeed * 10);
			yield return null;
		}
	}

	IEnumerator IntroSequence()
	{
		yield return new WaitForSeconds(1.0f);
		yield return StartCoroutine(MoveToPosition(enemyPos, 5));
		yield return new WaitForSeconds(2.0f);
		yield return StartCoroutine(MoveToPosition(mainPos, 5));
	}

	public IEnumerator Turn()
	{
		yield return StartCoroutine(MoveToPosition(enemyPos, 20));
		yield return new WaitForSeconds(1.0f);
		yield return StartCoroutine(MoveToPosition(playerPos, 20));
		yield return new WaitForSeconds(1.0f);
		yield return StartCoroutine(MoveToPosition(mainPos, 20));
	}
}
