using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Transform mainPos;
	public Transform playerPos;
	public Transform enemyPos;
	public PlayerController player;
	public EnemyController enemy;
	public DiceController dice;
	AudioListener audio;

    // Start is called before the first frame update
    void Start()
    {
		audio = GetComponent<AudioListener>();
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
		dice.ResetDicePosition();
	}

	public IEnumerator Turn()
	{
		yield return new WaitForSeconds(0.2f);
		yield return StartCoroutine(MoveToPosition(enemyPos, 20));
		if (dice.Damage > 0)
		{
			enemy.Health -= dice.Damage;
			yield return StartCoroutine(enemy.HitFlash());
		}
		yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine(MoveToPosition(playerPos, 20));
		player.block += dice.Blocking;
		yield return new WaitForSeconds(0.2f);
		player.Health += dice.Healing;
		yield return new WaitForSeconds(0.2f);
		player.Hit(5);
		yield return StartCoroutine(player.HitFlash());
		yield return new WaitForSeconds(0.5f);
		yield return StartCoroutine(MoveToPosition(mainPos, 20));
		dice.ResetDicePosition();
	}
}
