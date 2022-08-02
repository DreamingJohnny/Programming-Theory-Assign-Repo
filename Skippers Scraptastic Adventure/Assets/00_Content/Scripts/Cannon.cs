using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	[SerializeField] private Light dropPointLight;

	private void Start() {
		dropPointLight.gameObject.SetActive(false);
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

}
