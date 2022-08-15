using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	[SerializeField] private UIHandler uiHandler;
	[SerializeField] private Navigator navigator;
	[SerializeField] private Ship ship;

	public delegate void GameAction();
	public static event GameAction OnGameStopped;
	public static event GameAction OnGameStarted;

	[Min(0)] [SerializeField] private float difficultyRaiseSpan;
	private float timeSinceDifficultyRaised = 0f;
	private int difficulty = 0;

	public int Difficulty { get { return difficulty; } }

	private void OnEnable() {
		UIHandler.OnStartButtonPressed += HandleOnStartButtonPressed;
		UIHandler.OnQuitButtonPressed += HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal += HandleOnGameWon;
		Ship.OnShipBoarded += HandleOnGameOver;

		CargoBonus.OnCargoBonusShown += GiveCargoBonus;
	}


	private void OnDisable() {
		TitleScreen.OnStartButtonPressed -= HandleOnStartButtonPressed;
		TitleScreen.OnQuitButtonPressed -= HandleOnQuitButtonPressed;

		Navigator.OnShipReachedGoal -= HandleOnGameWon;
		Ship.OnShipBoarded -= HandleOnGameOver;

		CargoBonus.OnCargoBonusShown -= GiveCargoBonus;
	}

	private void Update() {
		if (timeSinceDifficultyRaised >= difficultyRaiseSpan) {
			timeSinceDifficultyRaised = 0f;
			difficulty++;
		}
		else {
			timeSinceDifficultyRaised += Time.deltaTime;
		}
	}

	private void HandleOnStartButtonPressed() {
		SetObjectsState(true);
		ResetDifficulty();
		OnGameStarted();
	}

	private void ResetDifficulty() {
		timeSinceDifficultyRaised = 0f;
		difficulty = 0;
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
	private void GiveCargoBonus(float bonus) {
		Debug.Log("GameManager sends bonus to navigator...");
		navigator.SpeedBoost += bonus;
	}

	private void SetObjectsState(bool state) {
		ship.gameObject.SetActive(state);
	}
}