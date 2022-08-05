using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float boardingSpeed;
	[SerializeField] private float health;

	private Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update() {
		rigidBody.position += Vector3.back * boardingSpeed * Time.deltaTime;
	}

	public void TakeDamage(float damage) {
		health -= damage;
		Debug.Log($"{this.name} takes damage, health is now {health}");
		CheckDeath();
	}

	private void CheckDeath() {
		if(health <= 0f) {
			Debug.Log("Pirateship about to be destroyed");
			Destroy(this.gameObject);
		}
	}
}
