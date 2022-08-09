using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour {

	[Range(0,15)] [SerializeField] private float boardingSpeed;
	[Min(0)] [SerializeField] private float health;

	public float Health { get { return health; } set { health = Mathf.Max(value, 0f); } }

	public float BoardingSpeed { get { return boardingSpeed; } set { boardingSpeed = Mathf.Max(value, 0f); } }

	private Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	private void OnEnable() {
		GameManager.OnGameStopped += OnDestroy;
	}

	private void OnDisable() {
		GameManager.OnGameStopped -= OnDestroy;
	}

	void FixedUpdate() {
		rigidBody.MovePosition(rigidBody.position += Vector3.back * BoardingSpeed * Time.deltaTime);
	}

	public void TakeDamage(float damage) {
		Health -= damage;
		CheckDeath();
	}

	private void CheckDeath() {
		if(Health <= 0f) OnDestroy();
	}

	private void OnDestroy() {
		Destroy(gameObject);
	}
}
