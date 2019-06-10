using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public Transform firePoint;
	public Rigidbody2D bulletPrefab;
	public float angle;

	IsometricPlayerMovementController isoRenderer;

	void Awake()
	{
		isoRenderer = GameObject.FindGameObjectWithTag("Player").
					  GetComponentInChildren<IsometricPlayerMovementController>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.E) && isoRenderer.diraxis.x !=0)
		{
			Shoot();
		}
	}

	public void Shoot()
	{
		// set firepoint direction
		Vector3 firepointDir = new Vector3(firePoint.position.x + isoRenderer.diraxis.x, firePoint.position.y + isoRenderer.diraxis.y, firePoint.position.z);
		// set angle bullet
		angle = MathfCalculate.DegreeFromVector2(isoRenderer.diraxis);
		var firepointRot = Quaternion.AngleAxis(angle, Vector3.forward + new Vector3(0.1f,0,0.1f));
		// instantiate bullet
		var firedBullet = Instantiate(bulletPrefab, firepointDir, firepointRot);
	}
}
