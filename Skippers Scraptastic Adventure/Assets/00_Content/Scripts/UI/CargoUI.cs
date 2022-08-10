using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CargoUI : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI cargoText;

	private float timeShown;
	public float TimeShown { get { return timeShown; } set { timeShown = Mathf.Max(value, 0f); } }

	[SerializeField] private float timeShowingText = 5f;

	private void OnEnable() {
		Cargo.OnCargoDestroyed += SetCargoText;
		cargoText.text = "";
	}

	private void OnDisable() {
		Cargo.OnCargoDestroyed -= SetCargoText;
		cargoText.text = "";
	}

	private void SetCargoText(string content, float value) {
		TimeShown = 0f;
		cargoText.SetText(content.Trim());
	}

	private void Update() {
		if (TimeShown <= timeShowingText) TimeShown += Time.deltaTime;
		else {
			cargoText.text = "";
		}
	}
}
