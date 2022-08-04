using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonUI : MonoBehaviour {

	private void OnEnable() {
		Cannon.OnAmmunitionChanged += SetAmmoState;
	}

	private void OnDisable() {
		Cannon.OnAmmunitionChanged -= SetAmmoState;
	}

	private void SetAmmoState(float ammo) {

		if(ammo <= 0) {
			GetComponent<Button>().interactable = false;
		}
		else {
			GetComponent<Button>().interactable = true;
		}
	}

}
