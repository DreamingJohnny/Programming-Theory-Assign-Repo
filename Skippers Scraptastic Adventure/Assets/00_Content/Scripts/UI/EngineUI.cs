using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngineUI : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI engineButton;

	[SerializeField] private string startText;
	[SerializeField] private string stopText;

	public void ChangeButtonText(bool toggle) {
		if (toggle) {
			engineButton.text = startText;
			//engineButton.GetComponent<TextMeshProUGUI>().text = startText;
			}
		else {
				//engineButton.GetComponent<TextMeshProUGUI>().text = stopText;
				//engineButton.GetComponent<TMP_Text>().text = stopText;
				engineButton.text = stopText;
		}
	}

}
