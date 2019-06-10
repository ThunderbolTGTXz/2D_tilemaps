using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 30f;
	public float damage = 10f;
	Rigidbody2D rb;

	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
		rb.velocity = transform.up * speed;
    }

	private void OnTriggerEnter2D(Collider2D hitInfo)
	{
		if (hitInfo.gameObject.CompareTag("Enemy"))
		{
			Enemy enemy = hitInfo.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(damage);
			}
			Destroy(gameObject);
		}
		else
			Destroy(gameObject,5f);
	}
}
