using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CargoUI : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI cargoText;

	private float timeShown;
	private float timeShowingText = 5f;

	private void OnEnable() {
		Cargo.OnCargoDestroyed += SetCargoText;
		cargoText.text = "";
	}

	private void OnDisable() {
		Cargo.OnCargoDestroyed -= SetCargoText;
		cargoText.text = "";
	}

	private void SetCargoText(string content) {
		timeShown = 0f;
		cargoText.text = content;
	}

	private void Update() {
		if (timeShown <= timeShowingText) timeShown += Time.deltaTime;
		else {
			cargoText.text = "";
		}
	}
}
