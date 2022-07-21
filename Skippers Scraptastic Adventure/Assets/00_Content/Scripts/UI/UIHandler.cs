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

	public delegate void ButtonAction();
	public static event ButtonAction OnStartButtonPressed;
	public static event ButtonAction OnQuitButtonPressed;

	//Needs better name;
	//Also add the invoked event here that GM should listen to to start everything right?
	public void OnStartPressed() {
		Debug.Log("StartPressed function activated...");
		OnStartButtonPressed();

		start.gameObject.SetActive(false);
		titlePanel.SetActive(false);
		travelLog.gameObject.SetActive(true);
	}

	//Check so that GM still listens to this event.
	public void QuitPressed() {
		Debug.Log("QuitPressed function activated...");
		OnQuitButtonPressed();
	}

	public void ShowGameOver() {
		Debug.Log($"{this.name} was just told that the game was lost.");
		gameOverPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		travelLog.gameObject.SetActive(false);
		//TODO: Also turn of the travelLog here
		//Also, remember to add to travelLog that it needs check its' values again when enabled.
	}

	public void ShowVictory() {
		Debug.Log($"{this.name} was just told that the game was won!");
		victoryPanel.SetActive(true);
		retry.gameObject.SetActive(true);
		travelLog.gameObject.SetActive(false);
	}
}
