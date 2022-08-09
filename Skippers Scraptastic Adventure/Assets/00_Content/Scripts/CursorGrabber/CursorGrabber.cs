using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGrabber : MonoBehaviour {

	private GameObject selectedObject;

	[SerializeField] private float yOffset;

	void Update() {

		RaycastHit hit = CastRay();

		//Checks so that cursor can only lift up cargo objects.
		if (hit.collider != null) {
			if (hit.collider.TryGetComponent<Cargo>(out Cargo cargo) == false) return;
		}

		if (Input.GetMouseButtonDown(0)) {
			//Drops object if cursor is holding it.
			if (selectedObject != null) {
				//selectedObject.GetComponent<Rigidbody>().useGravity = true;
				selectedObject.GetComponent<Cargo>().IsSelected = false;
				selectedObject = null;
			}
			//Picks up object if you aren't currently holding one.
			else {
				selectedObject = hit.collider.gameObject;
				//selectedObject.GetComponent<Rigidbody>().useGravity = false;
				selectedObject.GetComponent<Cargo>().IsSelected = true;
			}
		}

		if (selectedObject != null) {
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
			selectedObject.GetComponent<Rigidbody>().MovePosition(new Vector3(worldPos.x, yOffset, worldPos.z));
			//selectedObject.transform.position = new Vector3(worldPos.x, yOffset, worldPos.z);
		}
	}

	private RaycastHit CastRay() {
		Vector3 screenCursorPosFar = new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			Camera.main.farClipPlane);
		Vector3 screenCursorPosNear = new Vector3(
			Input.mousePosition.x,
			Input.mousePosition.y,
			Camera.main.nearClipPlane);
		Vector3 worldCursorPosFar = Camera.main.ScreenToWorldPoint(screenCursorPosFar);
		Vector3 worldCursorPosNear = Camera.main.ScreenToWorldPoint(screenCursorPosNear);

		RaycastHit raycastHit;
		Physics.Raycast(worldCursorPosNear, worldCursorPosFar - worldCursorPosNear, out raycastHit);

		return raycastHit;
	}
}
