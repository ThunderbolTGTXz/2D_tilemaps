using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
	public GameObject enemy;
	public List<GameObject> spawnarea = new List<GameObject>();
	List<GameObject> enemylist = new List<GameObject>();

	GameObject[] spawn;
	private void Awake()
	{
		spawn = GameObject.FindGameObjectsWithTag("spawnArea");
		for (int i = 0; i < spawn.Length; i++)
		{
			spawnarea.Add(spawn[i]);
		}
	}

	void Start()
    {
		Spawn();
    }

	void Spawn()
	{
		for (int i = 0; i < spawnarea.Count; i++)
		{
			var enemys = Instantiate(enemy, spawnarea[i].transform.position, spawnarea[i].transform.rotation);
			enemylist.Add(enemys);
		}
	}
}
