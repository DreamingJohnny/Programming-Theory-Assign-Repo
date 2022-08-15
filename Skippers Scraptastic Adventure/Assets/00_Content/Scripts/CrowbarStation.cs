using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarStation : MonoBehaviour {

	[SerializeField] private Light dropSpotLight;

	private Cargo held;

	private void OnEnable() {
		dropSpotLight.enabled = false;
		held = null;
	}

	private void OnTriggerEnter(Collider other) {
		//If the station already holds a piece of cargo it won't show that it is ready to accept a new one.
		if (held != null) return;
		//TODO: Check if these should by "try" can "GetComponent return treat as bool?
		if (other.TryGetComponent(out Cargo _)) {
			dropSpotLight.enabled = true;
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent(out Cargo _)) {
			dropSpotLight.enabled = false;
			held = null;
		}
	}

	private void OnTriggerStay(Collider other) {
		if (held != null) return;

		if (other.TryGetComponent(out Cargo cargo)) {
			if (cargo.IsHeld == false) {
				held = cargo;
			}
		}
	}

	public void RevealContent() {
		if (held != null) {
			if (held.IsRevealed != true) {
				held.SetContentIcons(true);
			}
		}
	}
}