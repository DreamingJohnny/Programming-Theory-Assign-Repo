using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelLog : MonoBehaviour {

	[SerializeField] private Navigator navigator;

	private float maxDistance;
	private float currentDistance;

	void Start() {
		if (navigator) {
			maxDistance = navigator.RouteLength;
			currentDistance = navigator.RouteLength - navigator.RouteLeft;
			GetComponent<Slider>().maxValue = maxDistance;
			GetComponent<Slider>().value = currentDistance;
		}
		else {
			Debug.Log($"{this} seems to be missing a reference to the navigator, and will inactivate itself.");
			this.gameObject.SetActive(false);
		}
	}

	
	void Update() {
		if (navigator) GetComponent<Slider>().value = navigator.RouteTravelled;
	}
}
