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

	private void Start() {
		dropPointLight.gameObject.SetActive(false);

		//So that the UI-element is up to date.
		//TODO: Move and fix this later
		//OnAmmunitionChanged(ammunition);
	}

	public void FireCannon() {
		if(ammunition <= 0f) { return; }
		Debug.Log($"Cannon fired with {ammunition} value!");
		ammunition = 0f;
		//TODO: Go thorugh and look at this later please, because I'm unsure if this means that:
		//1) I wouldn't actually need this to be serialized, couldn't I just create it in the script?
		//2) Will this make new copies all of the time then? Or will it be the same cannonBall?
		GameObject clone = Instantiate(cannonBall);
		clone.transform.position = spawnPoint.transform.position;

		OnAmmunitionChanged(ammunition);
	}

	private void SetAmmunition(float addedAmmo) {
		ammunition += addedAmmo;
		Debug.Log($"{name} now has a ballistics value of: {ammunition}.");
		OnAmmunitionChanged(ammunition);
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
				//ShowName(cargo.GetContent);
				cargo.HandleOnDestruction();
			}
		}
	}

}
