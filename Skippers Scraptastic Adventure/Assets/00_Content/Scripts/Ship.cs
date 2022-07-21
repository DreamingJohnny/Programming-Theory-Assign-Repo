using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public delegate void ShipAction();
	public static event ShipAction OnShipBoarded;

	void Start() {

	}

	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Does this collision even trigger?");
		if (other.TryGetComponent<PirateShip>(out PirateShip pirateShip)) {
			Debug.Log("A pirate ship managed to board us!");
			OnShipBoarded();
		}
		
	}
}
