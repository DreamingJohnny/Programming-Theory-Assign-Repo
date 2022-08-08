using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public bool IsSpawning;

	[SerializeField] private GameObject toSpawn;
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

	private void HandleGameStarted() {
		IsSpawning = true;
		timeSinceSpawn = 0f;
	}

	private void HandleGameStopped() {
		IsSpawning = false;
	}

	private void Update() {
		if (!IsSpawning) return;
		if (timeSinceSpawn <= spawnSpan) {
			timeSinceSpawn += Time.deltaTime;
		}
		else {
			timeSinceSpawn = 0;
			SpawnObject();
		}
	}

	public virtual void SpawnObject() {
		GameObject clone = Instantiate(toSpawn);
		clone.transform.SetPositionAndRotation(transform.position, transform.rotation);
	}
}
