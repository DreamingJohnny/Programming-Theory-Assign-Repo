using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TitleScreen : MonoBehaviour {

	public delegate void ButtonAction();
	public static event ButtonAction OnStartButtonPressed;
	public static event ButtonAction OnQuitButtonPressed;
	
	public void StartPressed() {
		Debug.Log("StartPressed function activated...");
		OnStartButtonPressed();
	}
	
	public void QuitPressed() {
		Debug.Log("QuitPressed function activated...");
		OnQuitButtonPressed();
	}
}