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
		OnStartButtonPressed();
	}
	
	public void QuitPressed() {
		OnQuitButtonPressed();
	}
}
