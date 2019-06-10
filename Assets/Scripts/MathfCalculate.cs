using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathfCalculate : MonoBehaviour
{
	public static float DegreeFromVector2(Vector2 dir)
	{
		if (dir.x < 0)
		{
			return Mathf.Atan2(dir.x, dir.y) * -Mathf.Rad2Deg * 1;
		}
		else
		{
			return Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg * -1;
		}
	}
}
