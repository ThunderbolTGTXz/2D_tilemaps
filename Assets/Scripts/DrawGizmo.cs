using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmo : MonoBehaviour
{
	IsometricPlayerMovementController isoRenderer;

	void Start()
	{
		isoRenderer = GameObject.FindGameObjectWithTag("Player").
					  GetComponentInChildren<IsometricPlayerMovementController>();
	}

	private void OnDrawGizmos()
	{
		if (this != null)
		{
			Vector2 diraxis = isoRenderer.diraxis;
			Vector2 dir = new Vector2(transform.position.x + isoRenderer.diraxis.x, transform.position.y + isoRenderer.diraxis.y);
			Gizmos.color = Color.yellow;
			Gizmos.DrawLine(this.transform.position, dir);

			//DegreeFromVector2(diraxis);

		}
	}

	public static float DegreeFromVector2(Vector2 dir)
	{
		if (dir.x < 0)
		{
			Debug.Log(dir);
			return 360 - (Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1);
		}
		else
		{
			return Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
		}
	}
}
