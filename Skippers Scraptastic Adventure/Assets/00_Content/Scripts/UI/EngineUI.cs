using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngineUI : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI engineButton;

	[SerializeField] private string startText;
	[SerializeField] private string stopText;

	private void Start() {
		engineButton.text = startText;
	}
	public void ChangeButtonText(bool toggle) {
		if (toggle) {	engineButton.text = stopText;	}
		else {	engineButton.text = startText;	}
	}
}
