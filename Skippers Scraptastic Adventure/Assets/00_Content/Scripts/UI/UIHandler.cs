using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour {

	[SerializeField] private TitleScreen titleScreen;

	private void OnEnable() {
		TitleScreen.OnStartButtonPressed += HandleOnStartButtonPressed;
	}

	private void HandleOnStartButtonPressed() {
		Debug.Log($"{this.gameObject.name} turns of the title screen now...");
		titleScreen.gameObject.SetActive(false);
	}
}
