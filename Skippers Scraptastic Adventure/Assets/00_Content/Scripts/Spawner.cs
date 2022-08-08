using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	//Make this a more general spawner then, that you can apply on both the PirateSpawner and on the CargoSpawner. So they can spawn both kinds of things maybe?
	//private List<GameObject> spawnedObjects = new List<GameObject>();

	[SerializeField] private GameObject toSpawn;
	[SerializeField] private float spawnSpan;
	private float timeSinceSpawn;

	private void Update() {
		if (timeSinceSpawn <= spawnSpan) {
			timeSinceSpawn += Time.deltaTime;
		}
		else {
			timeSinceSpawn = 0;
			SpawnObject();
		}
	}

	private void SpawnObject() {
		GameObject clone = Instantiate(toSpawn);
		clone.transform.SetPositionAndRotation(transform.position, transform.rotation);
}
