using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {
	[SerializeField] private Light dropPointLight;
	//TODO: Give this a Tooltip.
	[SerializeField] private GameObject spawnPoint;

	[SerializeField] private GameObject cannonBall;

	private float ammunition;

	public float Ammunition { get { return ammunition; } set { ammunition = Mathf.Max(value, 0f); } }

	public delegate void CannonAction(float ammo);
	public static event CannonAction OnAmmunitionChanged;

	private void OnEnable() {
		dropPointLight.gameObject.SetActive(false);
		Ammunition = 0f;
	}

	public void FireCannon() {
		if (Ammunition <= 0f) return;
		Ammunition = 0f;
		GameObject clone = Instantiate(cannonBall);
		clone.transform.position = spawnPoint.transform.position;

		OnAmmunitionChanged(ammunition);
	}

	private void SetAmmunition(float addedAmmo) {
		Ammunition += addedAmmo;
		OnAmmunitionChanged(Ammunition);
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
		if (other.TryGetComponent(out Cargo cargo)) {
			if (cargo.IsHeld == false) {
				SetAmmunition(cargo.GetBallistic);
				cargo.OnDestroy();
				dropPointLight.gameObject.SetActive(false);
			}
		}
	}
}