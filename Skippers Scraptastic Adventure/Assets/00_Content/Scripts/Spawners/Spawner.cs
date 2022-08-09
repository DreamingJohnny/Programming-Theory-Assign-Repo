using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	private bool isSpawning;

	[SerializeField] protected GameObject toSpawn;
	[SerializeField] private float spawnSpan;
	private float timeSinceSpawn;

	private void OnEnable() {
		GameManager.OnGameStopped += HandleGameStopped;
		GameManager.OnGameStarted += HandleGameStarted;
	}

	private void OnDisable() {
		GameManager.OnGameStarted -= HandleGameStarted;
		GameManager.OnGameStopped -= HandleGameStopped;
	}

	protected virtual void HandleGameStarted() {
		isSpawning = true;
		timeSinceSpawn = 0f;
	}

	private void HandleGameStopped() {
		isSpawning = false;
	}

	private void Update() {
		if (!isSpawning) return;
		if (timeSinceSpawn <= spawnSpan) {
			timeSinceSpawn += Time.deltaTime;
		}
		else {
			timeSinceSpawn = 0;
			SpawnObject();
		}
	}

	protected virtual void SpawnObject() {
		GameObject clone = Instantiate(toSpawn);
		clone.transform.SetPositionAndRotation(transform.position, transform.rotation);
	}
}