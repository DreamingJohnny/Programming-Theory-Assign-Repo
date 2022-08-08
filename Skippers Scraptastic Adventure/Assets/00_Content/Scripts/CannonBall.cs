using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float damage;

	//Needs some way to be completely destroyed if you restart level or whatever

	private void OnEnable() {
		GameManager.OnGameStopped += HandleOnDestruction;
	}

	private void OnDisable() {
		GameManager.OnGameStopped -= HandleOnDestruction;
	}

	private void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);		
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.TryGetComponent<PirateShip>(out PirateShip pirateShip)) {
			pirateShip.TakeDamage(damage);
			Debug.Log($"{name} about to be destroyed.");
			HandleOnDestruction();
		}
	}

	public void HandleOnDestruction() {
		Destroy(gameObject);
	}
}
