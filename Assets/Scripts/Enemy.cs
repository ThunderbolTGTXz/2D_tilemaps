using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Header("Enemy Properties")]
	public float health;
	public ParticleSystem deathParticle;
	[Space]
	[Header("Healthbar Properties")]
	public Transform healthbar;
	public float healthbarScale;
	public float remainhealth;

	private void Start()
	{
		healthbarScale = healthbar.transform.localScale.x;
		remainhealth = health;
	}

	public void TakeDamage(float damage)
	{
		remainhealth -= damage;
		Healthbar();
		if (remainhealth <= 0)
		{
			Death();
		}
	}

	void Healthbar()
	{
		healthbar.transform.localScale = new Vector3((remainhealth/health) * healthbarScale, healthbar.transform.localScale.y, healthbar.transform.localScale.z);
		//Debug.Log(healthbar.transform.localScale.x);
	}

	void Death()
	{
		var effect = Instantiate(deathParticle, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
