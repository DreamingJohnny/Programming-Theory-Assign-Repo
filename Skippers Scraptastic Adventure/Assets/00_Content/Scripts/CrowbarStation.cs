using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowbarStation : MonoBehaviour {

	[SerializeField] private Light dropSpotLight;

	private Cargo held;


	private void OnTriggerEnter(Collider other) {
		//If the station already holds a piece of carg it won't show that it is ready to accept a new one.
		if (held != null) return;

		if (other.TryGetComponent<Cargo>(out Cargo cargo)) {
			Debug.Log("cargo enters collider...");
			dropSpotLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent<Cargo>(out Cargo cargo)) {
			dropSpotLight.gameObject.SetActive(false);
			Debug.Log("cargo exits collider...");
			held = null;
		}
	}

	private void OnTriggerStay(Collider other) {
		if (held != null) return;

		if (other.TryGetComponent<Cargo>(out Cargo cargo)) {
			if (cargo.IsSelected == false) {
				held = cargo;
			}
		}
	}

	public void RevealContent() {
		if (held != null) {
			if (held.IsRevealed != true) {
				held.SetContentIcons(true);
				Debug.Log("cargo has been revealed...");
			}
		}
	}
}
