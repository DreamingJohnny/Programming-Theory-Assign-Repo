using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHandler : MonoBehaviour {

	[SerializeField] private GameObject titlePanel;
	[SerializeField] private GameObject victoryPanel;
	[SerializeField] private GameObject gameOverPanel;

	[SerializeField] private Button retry;
	[SerializeField] private Button start;
	[SerializeField] private Button quit;

	[SerializeField] private CannonUI cannonUI;
	[SerializeField] private EngineUI engineUI;
	[SerializeField] private GameObject fuelGauge;
	[SerializeField] private CrowbarUI crowbarUI;
	[SerializeField] private CargoUI cargoUI;
	[SerializeField] private Slider travelLog;

	public delegate void ButtonAction();
	public static event ButtonAction OnStartButtonPressed;
	public static event ButtonAction OnQuitButtonPressed;

	public void OnStartPressed() {
		OnStartButtonPressed();

		titlePanel.SetActive(false);
		victoryPanel.SetActive(false);
		gameOverPanel.SetActive(false);

		start.gameObject.SetActive(false);
		retry.gameObject.SetActive(false);

		SetHUD(true);
	}

	private void SetHUD(bool state) {
		travelLog.gameObject.SetActive(state);
		engineUI.gameObject.SetActive(state);
		cannonUI.gameObject.SetActive(state);
		crowbarUI.gameObject.SetActive(state);
	}

	public void QuitPressed() {
		OnQuitButtonPressed();
	}

	public void ShowGameOver() {
		gameOverPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		SetHUD(false);
	}

	public void ShowVictory() {
		victoryPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		SetHUD(false);
	}
}