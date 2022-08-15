using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySpawner : Spawner {

	[SerializeField] private GameManager gameManager;

	[SerializeField] private GameObject[] spawnObjects;

	// POLYMORPHISM
	protected override void HandleGameStarted() {
		//INHERITANCE
		base.HandleGameStarted();
		//Resets what to spawn when a new game starts.
		toSpawn = spawnObjects[0];
	}

	/// <summary>
	/// After having spawned it looks at the UpdateDifficulty() function to see if it should increase the Difficulty.
	/// </summary>
	// POLYMORPHISM
	protected override void SpawnObject() {
		//INHERITANCE
		base.SpawnObject();
		UpdateDifficulty();
	
	}
	/// <summary>
	/// Looks at the Difficulty variable on the GameManager,
	/// and changes the object it spawns into one higher up on it's index of enemies.
	/// </summary>
	private void UpdateDifficulty() {
		int difficulty = gameManager.Difficulty;
		if (difficulty >= spawnObjects.Length) difficulty = spawnObjects.Length -1;
		else if (difficulty < 0) difficulty = 0;

		toSpawn = spawnObjects[difficulty];	
	}
}
