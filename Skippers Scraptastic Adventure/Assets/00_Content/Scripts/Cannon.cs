using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	[SerializeField] private Light dropPointLight;
	//TODO: Give this a Tooltip.
	[SerializeField] private GameObject spawnPoint;

	[SerializeField] private GameObject cannonBall;

	[SerializeField] private float ammunition;

	public delegate void CannonAction(float ammo);
	public static event CannonAction OnAmmunitionChanged;

	private void OnEnable() {
		dropPointLight.gameObject.SetActive(false);
		ammunition = 0f;
	}

	public void FireCannon() {
		if(ammunition <= 0f) return;
		ammunition = 0f;
		GameObject clone = Instantiate(cannonBall);
		clone.transform.position = spawnPoint.transform.position;

		OnAmmunitionChanged(ammunition);
	}

	private void SetAmmunition(float addedAmmo) {
		ammunition += addedAmmo;
		OnAmmunitionChanged(ammunition);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Cargo _)) {
			dropPointLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent(out Cargo _)) {
			dropPointLight.gameObject.SetActive(false);
		}
	}

	private void OnTriggerStay(Collider other) {
		if(other.TryGetComponent(out Cargo cargo)) {
			if (cargo.IsHeld == false) {
				SetAmmunition(cargo.GetBallistic);
				cargo.OnDestroy();
				dropPointLight.gameObject.SetActive(false);
			}
		}
	}
}