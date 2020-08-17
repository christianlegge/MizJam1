using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceController : MonoBehaviour
{
	public float upForce;
	public float spinForce;


	int tilesheetW = 48;
	int tilesheetH = 22;
	Mesh mesh;
	Rigidbody body;
	int count = 0;
	int tile = 0;

	float x;
	float z;

	void SetFace(int tileX, int tileY, int face)
	{
		Vector2[] tileCoords = {
			new Vector2((float)tileX / tilesheetW, (float)tileY / tilesheetH),
			new Vector2((float)(tileX + 1) / tilesheetW, (float)tileY / tilesheetH),
			new Vector2((float)tileX / tilesheetW, (float)(tileY + 1) / tilesheetH),
			new Vector2((float)(tileX + 1) / tilesheetW, (float)(tileY + 1) / tilesheetH),
		};

		Vector2[] uvs = mesh.uv;


		if (face == 0)
		{
			// Front
			uvs[0] = tileCoords[0];
			uvs[1] = tileCoords[1];
			uvs[2] = tileCoords[2];
			uvs[3] = tileCoords[3];
		}
		else if (face == 1)
		{
			// Top
			uvs[8] = tileCoords[0];
			uvs[9] = tileCoords[1];
			uvs[4] = tileCoords[2];
			uvs[5] = tileCoords[3];
		}
		else if (face == 2)
		{
			// Back
			uvs[7] = tileCoords[0];
			uvs[6] = tileCoords[1];
			uvs[11] = tileCoords[2];
			uvs[10] = tileCoords[3];
		}
		else if (face == 3)
		{
			// Bottom
			uvs[13] = tileCoords[0];
			uvs[12] = tileCoords[1];
			uvs[14] = tileCoords[2];
			uvs[15] = tileCoords[3];
		}
		else if (face == 4)
		{
			// Left
			uvs[17] = tileCoords[0];
			uvs[16] = tileCoords[1];
			uvs[18] = tileCoords[2];
			uvs[19] = tileCoords[3];
		}
		else
		{
			// Right        
			uvs[21] = tileCoords[0];
			uvs[20] = tileCoords[1];
			uvs[22] = tileCoords[2];
			uvs[23] = tileCoords[3];
		}

		mesh.uv = uvs;
	}

	// Start is called before the first frame update
	void Start()
	{
		body = GetComponent<Rigidbody>();
		var mf = GetComponent<MeshFilter>();
		mesh = mf.mesh;

		SetFace(20, 2, 0);
		SetFace(21, 2, 1);
		SetFace(22, 2, 2);
		SetFace(23, 2, 3);
		SetFace(24, 2, 4);
		SetFace(25, 2, 5);

	}

	void OnMouseDown()
	{
		body.AddForce(Vector3.up * Random.Range(upForce / 2, upForce * 1.5f));
		Vector2 torque = Random.insideUnitCircle.normalized;
		body.AddTorque(new Vector3(torque.x, Random.Range(-0.5f, 0.5f), torque.y) * Random.Range(spinForce/2, spinForce * 1.5f));
	}
}
