using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateShip : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float boardingSpeed;

	private Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	void Update() {
		rigidBody.position += Vector3.back * boardingSpeed * Time.deltaTime;
	}
}
