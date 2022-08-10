using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scorer : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI scoreTextBox;

	private float totalValue;

	public float TotalValue { get { return totalValue; } set { totalValue = Mathf.Max(0, Mathf.FloorToInt(value)); } }

	private void OnEnable() {
		Cargo.OnCargoDestroyed += ScoreCargo;
		totalValue = 0f;
		scoreTextBox.text = "";
	}

	private void OnDisable() {
		Cargo.OnCargoDestroyed -= ScoreCargo;
		scoreTextBox.text = "";
	}

	private void ScoreCargo(string content, float value) {
		totalValue += value;
	}

	public void ShowTotalValue() {
		scoreTextBox.text = TotalValue.ToString();
	}
}
