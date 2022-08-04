using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CargoTextNotice : MonoBehaviour {



	void Start() {

	}

	private void OnEnable() {
		Cargo.OnCargoDestroyed += ShowContent;
	}

	private void OnDisable() {
		Cargo.OnCargoDestroyed -= ShowContent;
	}

	private void ShowContent(string content) {
		this.GetComponent<TextMeshProUGUI>().text = content;
	}
}
