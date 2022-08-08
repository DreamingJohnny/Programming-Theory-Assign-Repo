using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private UIHandler uiHandler;

	[SerializeField] private Ship ship;
	[SerializeField] private Spawner pirateSpawner;
	[SerializeField] private Spawner cargoSpawner;

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
		SetObjectsState(true);
		OnGameStarted();
	}

	private void HandleOnQuitButtonPressed() {
		Application.Quit();
	}

	private void HandleOnGameWon() {
		uiHandler.ShowVictory();
		OnGameStopped();
		SetObjectsState(false);
	}

	private void HandleOnGameOver() {
		uiHandler.ShowGameOver();
		OnGameStopped();
		SetObjectsState(false);
	}

	private void SetObjectsState(bool state) {
		ship.gameObject.SetActive(state);
	}
}