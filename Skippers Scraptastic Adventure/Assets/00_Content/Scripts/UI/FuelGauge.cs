using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {

	[SerializeField] private Engine engine;

	private void OnEnable() {
		if (engine) GetComponent<Slider>().maxValue = engine.MaxFuel;
		else {
			Debug.Log($"{this} seems to be missing a reference to the engine, and will inactivate itself.");
			gameObject.SetActive(false);
		}
	}

	void Update() {
		if (engine) GetComponent<Slider>().value = engine.FuelAmount;
	}
}
