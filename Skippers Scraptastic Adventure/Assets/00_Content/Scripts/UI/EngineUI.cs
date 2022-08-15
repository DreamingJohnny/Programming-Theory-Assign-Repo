using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EngineUI : MonoBehaviour {

	[SerializeField] private Engine engine;

	[SerializeField] private TextMeshProUGUI engineButtonText;

	[SerializeField] private Slider fuelSlider;

	[SerializeField] private string startText;
	[SerializeField] private string stopText;

	private void OnEnable() {
		engineButtonText.text = startText;

		if (engine) fuelSlider.maxValue = engine.MaxFuel;
		else {
			Debug.Log($"{this} seems to be missing a reference to the engine, and will inactivate itself.");
			gameObject.SetActive(false);
		}
	}

	void Update() {
		fuelSlider.value = engine.FuelAmount;

		if(engine.IsRunning == false) { ChangeButtonText(false); }

	}

	public void ChangeButtonText(bool toggle) {
		if (toggle) engineButtonText.text = stopText;
		else engineButtonText.text = startText;
	}
}
