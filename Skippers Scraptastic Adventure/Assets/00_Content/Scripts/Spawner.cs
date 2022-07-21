using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	//Make this a more general spawner then, that you can apply on both the PirateSpawner and on the CargoSpawner. So they can spawn both kinds of things maybe?
	private List<GameObject> spawnedObjects = new List<GameObject>();

	[SerializeField] private GameObject toSpawn;

	private void SpawnObject() {
		Instantiate(toSpawn);
		spawnedObjects.Add(toSpawn);
	}

	private void OnDisable() {

			foreach (GameObject gameObject in spawnedObjects) {
				Destroy(gameObject);
				Debug.Log("Destroyed one pirateship...");
			}
		}
}
