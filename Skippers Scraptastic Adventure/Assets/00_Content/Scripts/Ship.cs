using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

	public delegate void ShipAction();
	public static event ShipAction OnShipBoarded;

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out PirateShip pirateShip)) OnShipBoarded();
	}
}
