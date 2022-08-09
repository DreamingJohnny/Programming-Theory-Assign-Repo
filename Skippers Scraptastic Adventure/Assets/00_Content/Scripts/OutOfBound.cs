using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBound : MonoBehaviour {

private void OnCollisionEnter(Collision collision) {
		if (TryGetComponent(out Cargo cargo)) {
			Destroy(cargo.gameObject);
		}
		else if (TryGetComponent(out CannonBall cannonBall)) {
			cannonBall.OnDestroy();
		}
		else {
			Debug.Log($"{collision.gameObject.name} crossed the bounds of {name}, and will now be destroyed");
			Destroy(collision.gameObject);
		}
	}
}