using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private UIHandler uiHandler;

	[SerializeField] private GameObject ship;
	[SerializeField] private Spawner pirateSpawner;
	[SerializeField] private Spawner cargoSpawner;
	[SerializeField] private Engine engine;

	private void OnEnable() {
		UIHandler.OnStartButtonPressed += HandleOnStartButtonPressed;
		UIHandler.OnQuitButtonPressed += HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal += HandleOnGameWon;
	}

	private void OnDisable() {
		TitleScreen.OnStartButtonPressed -= HandleOnStartButtonPressed;
		TitleScreen.OnQuitButtonPressed -= HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal -= HandleOnGameWon;
	}

	private void HandleOnStartButtonPressed() {
		Debug.Log("Start game...");
		StartGame();
	}

	private void HandleOnQuitButtonPressed() {
		Debug.Log("Now the game should quit...");
		Application.Quit();
	}

	private void HandleOnGameWon() {
		Debug.Log("Horray! You reached safe harbor! The game is won!");
		uiHandler.ShowVictory();
	}

	private void HandleOnGameOver() {
		Debug.Log("Oh no! You lost the game!");
		uiHandler.ShowGameOver();
		//Stop all other activities, like spawner etc,
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
