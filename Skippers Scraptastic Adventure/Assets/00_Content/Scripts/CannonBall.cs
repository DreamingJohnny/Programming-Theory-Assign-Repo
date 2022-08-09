using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float damage;

	private Rigidbody rigidBody;

	private void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	private void OnEnable() {
		GameManager.OnGameStopped += OnDestroy;
	}

	private void OnDisable() {
		GameManager.OnGameStopped -= OnDestroy;
	}

	private void FixedUpdate() {
		rigidBody.AddForce(Vector3.forward * speed * Time.deltaTime);		
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.TryGetComponent(out PirateShip pirateShip)) {
			pirateShip.TakeDamage(damage);
			OnDestroy();
		}
	}

	public void OnDestroy() {
		Destroy(gameObject);
	}
}