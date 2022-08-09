using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : Spawner {

	[SerializeField] private GameObject[] gameObjects;

	protected override void SpawnObject() {
		GameObject clone = Instantiate(GetRandomSpawn());
		clone.transform.SetPositionAndRotation(transform.position, transform.rotation);
	}

	private GameObject GetRandomSpawn() {

		int index = Random.Range(0, gameObjects.Length);

		return gameObjects[index];
	}
}
