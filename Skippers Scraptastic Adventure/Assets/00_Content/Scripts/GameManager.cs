using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject ship;
	[SerializeField] private Spawner pirateSpawner;
	[SerializeField] private Spawner cargoSpawner;
	[SerializeField] private Engine engine;

	private void OnEnable() {
		TitleScreen.OnStartButtonPressed += HandleOnStartButtonPressed;
		TitleScreen.OnQuitButtonPressed += HandleOnQuitButtonPressed;
	}

	private void OnDisable() {
		TitleScreen.OnStartButtonPressed -= HandleOnStartButtonPressed;
		TitleScreen.OnQuitButtonPressed -= HandleOnQuitButtonPressed;
	}

	private void HandleOnStartButtonPressed() {
		Debug.Log("Start game...");
		StartGame();
	}

	private void HandleOnQuitButtonPressed() {
		Debug.Log("Now the game should quit...");
		Application.Quit();
	}

	private void StartGame() {
		ship.gameObject.SetActive(true);
		pirateSpawner.gameObject.SetActive(true);
		cargoSpawner.gameObject.SetActive(true);
		engine.gameObject.SetActive(true);

		//TODO: Add starting the various objects, such as cargoSpawner, pirateSpawner, cannonSpawner, etc.
		//Will also need functionality later on for resetting a lot of values, destroying existing cargo etc.
	}
}
