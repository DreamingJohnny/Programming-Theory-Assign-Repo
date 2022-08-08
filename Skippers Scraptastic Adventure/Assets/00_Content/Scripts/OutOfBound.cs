using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour {

	private void OnCollisionEnter(Collision collision) {
		if (TryGetComponent<Cargo>(out Cargo cargo)) {
			cargo.HandleOnDestruction();
		}
		else if (TryGetComponent<CannonBall>(out CannonBall cannonBall)) {
			cannonBall.HandleOnDestruction();
		}
		else {
			Debug.Log($"{collision.gameObject.name} crossed the bounds of {name}, and will now be destroyed");
			Destroy(collision.gameObject);
		}
	}
}