using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour {

	[SerializeField] private float boardingSpeed;
	[SerializeField] private float health;

	private Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	private void OnEnable() {
		GameManager.OnGameStopped += HandleOnDestruction;
	}

	private void OnDisable() {
		GameManager.OnGameStopped -= HandleOnDestruction;
	}

	void Update() {
		rigidBody.MovePosition(rigidBody.position += Vector3.back * boardingSpeed * Time.deltaTime);
	}

	public void TakeDamage(float damage) {
		health -= damage;
		CheckDeath();
	}

	private void CheckDeath() {
		if(health <= 0f) {
			HandleOnDestruction();
		}
	}

	private void HandleOnDestruction() {
		Debug.Log("Pirateship about to be destroyed");
		Destroy(gameObject);
	}
}
