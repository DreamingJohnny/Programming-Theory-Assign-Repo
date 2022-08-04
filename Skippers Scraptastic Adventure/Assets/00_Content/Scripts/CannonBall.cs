using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private float damage;

	//Needs to be able to move,
	//Be destroyed when/if it hits PirateShips
	//Give notice when it hits PirateShips
	//Needs some way to be completely destroyed if you restart level or whatever
	//Gives its damage to the pirateship?

	void Start() {

	}

	private void FixedUpdate() {
		GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);		
	}

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.TryGetComponent<PirateShip>(out PirateShip pirateShip)) {
			Debug.Log($"{name} just hit a pirate ship!");
		}
	}
}
