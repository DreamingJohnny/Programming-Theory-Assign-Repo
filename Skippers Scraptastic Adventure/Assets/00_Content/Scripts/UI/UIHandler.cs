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
	[SerializeField] private Slider travelLog;
	[SerializeField] private Slider fuelGauge;

	public delegate void ButtonAction();
	public static event ButtonAction OnStartButtonPressed;
	public static event ButtonAction OnQuitButtonPressed;

	//TODO: Needs better name;
	//TODO: Also add the invoked event here that GM should listen to to start everything right?
	//Because this function is infact for when the StartButton is pressed, even when it happens the first time.
	public void OnStartPressed() {
		Debug.Log("StartPressed function activated...");
		OnStartButtonPressed();

		titlePanel.SetActive(false);
		victoryPanel.SetActive(false);
		gameOverPanel.SetActive(false);

		start.gameObject.SetActive(false);
		retry.gameObject.SetActive(false);
		travelLog.gameObject.SetActive(true);
	}

	public void QuitPressed() {
		Debug.Log("QuitPressed function activated...");
		OnQuitButtonPressed();
	}

	public void ShowGameOver() {
		Debug.Log($"{this.name} was just told that the game was lost.");
		gameOverPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		travelLog.gameObject.SetActive(false);
		//Also, remember to add to travelLog that it needs check its' values again when enabled.
	}

	public void ShowVictory() {
		victoryPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		travelLog.gameObject.SetActive(false);
	}
}
