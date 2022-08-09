using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCursorGrabPoint : MonoBehaviour {

	//So, needs to look for where the cursor is...
	//Has a constant value for how high of the ground it should be that is Y

	//In X it can more or less take the value from cursor
	//And in Z, there we need to clamp it pretty hard then.

	//And then, when you have this Vector3, then it should be public,
	//with getter, so that things with the grabbable script can look for it, and try to move towards it.

	//So, I suppose this will need to look at if you are having mouse down or not then? Yeees?

	private Vector3 grabPoint;
	public Vector3 GrabPoint { get { return grabPoint; } }

	void Update() {
		
	}
}
