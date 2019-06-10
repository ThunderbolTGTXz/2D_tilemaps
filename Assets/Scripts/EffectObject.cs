using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectObject : MonoBehaviour
{
	ParticleSystem effect;
    void Start()
    {
		effect = GetComponent<ParticleSystem>();
    }

    void Update()
    {
		if (!effect.IsAlive())
		{
			Destroy(gameObject);
		}
    }
}
