using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private UIHandler uiHandler;

	[SerializeField] private Ship ship;
	[SerializeField] private Spawner pirateSpawner;
	[SerializeField] private Spawner cargoSpawner;
	//[SerializeField] private Engine engine;

	public delegate void GameAction();
	public static event GameAction OnGameStopped;
	public static event GameAction OnGameStarted;

	private void OnEnable() {
		UIHandler.OnStartButtonPressed += HandleOnStartButtonPressed;
		UIHandler.OnQuitButtonPressed += HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal += HandleOnGameWon;
		Ship.OnShipBoarded += HandleOnGameOver;
	}

	private void OnDisable() {
		TitleScreen.OnStartButtonPressed -= HandleOnStartButtonPressed;
		TitleScreen.OnQuitButtonPressed -= HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal -= HandleOnGameWon;
		Ship.OnShipBoarded -= HandleOnGameOver;
	}

	private void HandleOnStartButtonPressed() {
		Debug.Log("Start game...");
		SetObjectsState(true);
	}

	private void HandleOnQuitButtonPressed() {
		Debug.Log("Now the game should quit...");
		Application.Quit();
	}

	private void HandleOnGameWon() {
		Debug.Log("Horray! You reached safe harbor! The game is won!");
		uiHandler.ShowVictory();
		SetObjectsState(false);
		OnGameStopped();
	}

	private void HandleOnGameOver() {
		Debug.Log("Oh no! You lost the game!");
		uiHandler.ShowGameOver();
		SetObjectsState(false);
		OnGameStopped();
	}

	private void SetObjectsState(bool state) {
		ship.gameObject.SetActive(state);
		pirateSpawner.gameObject.SetActive(state);
		cargoSpawner.gameObject.SetActive(state);
		//TODO: Check if engine needs to be turned on/off on its own, isn't it part of the ship?
		//engine.gameObject.SetActive(state);

		//TODO: Will also need functionality later on for resetting a lot of values, destroying existing cargo etc.
		//Actually don't think I will need that if these objects just have detailed in their onEnable & disable what they should do.
		//TODO: Include of course in spawners that they'll need to destroy all of the objects that they've already created.
		//TODO: Also, spawners must child the objects they instantiate, and make array of them, and then remove themselves from array when/if destroyed? Or listen to event...?
	}
}