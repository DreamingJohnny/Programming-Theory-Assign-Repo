using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

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
		//TODO: Add starting the various objects, such as cargoSpawner, pirateSpawner, cannonSpawner, etc.
		//Will also need functionality later on for resetting a lot of values, destroying existing cargo etc.
	}
}
