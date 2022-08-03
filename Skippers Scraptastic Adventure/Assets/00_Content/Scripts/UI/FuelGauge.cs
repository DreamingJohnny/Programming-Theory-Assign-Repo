using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour {

	[SerializeField] private Engine engine;

	void Start() {
		//TODO: Later on, think this through, should this have some sort of "lookforObjectinScene"? function? Also, should this be moved from "Start()"
		//to some other function, one that UIHandler can call, so that this happens late enough so that everything exists, but also is attempted every time UIHandler wants it to.
		if (engine) {
			GetComponent<Slider>().maxValue = engine.MaxFuel;
		}
		else {
			Debug.Log($"{this} seems to be missing a reference to the engine, and will inactivate itself.");
			this.gameObject.SetActive(false);
		}
	}


	void Update() {
		if (engine) GetComponent<Slider>().value = engine.FuelAmount;
	}
}
