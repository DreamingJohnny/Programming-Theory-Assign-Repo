using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	[SerializeField] private Light dropPointLight;

	[SerializeField] private float ammunition;

	private void Start() {
		dropPointLight.gameObject.SetActive(false);
	}

	public void FireCannon() {
		Debug.Log($"Cannon fired with {ammunition} value!");
		ammunition = 0f;
	}

	private void SetAmmunition(float addedAmmo) {
		ammunition += addedAmmo;
		Debug.Log($"{name} now has a ballistics value of: {ammunition}.");
	}

	private void OnTriggerEnter(Collider other) {
		if(other.TryGetComponent<Cargo>(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.TryGetComponent<Cargo>(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(false);
		}
	}

	private void OnTriggerStay(Collider other) {
		if(other.TryGetComponent<Cargo>(out Cargo cargo)) {
			if(cargo.IsSelected == false) {
				SetAmmunition(cargo.GetBallistic);
				Destroy(cargo.gameObject);
			}
		}
	}

}
