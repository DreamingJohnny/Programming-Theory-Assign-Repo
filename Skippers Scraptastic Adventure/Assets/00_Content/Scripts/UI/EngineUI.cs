using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngineUI : MonoBehaviour {

	[SerializeField] private Toggle engineButton;

	[SerializeField] private string startText;
	[SerializeField] private string stopText;

	public void ChangeButtonText(bool toggle) {
		if (toggle) { engineButton.GetComponent<TextMeshProUGUI>().text = startText; }
		else {
			engineButton.GetComponent<TextMeshProUGUI>().text = stopText;
		}
	}

}
