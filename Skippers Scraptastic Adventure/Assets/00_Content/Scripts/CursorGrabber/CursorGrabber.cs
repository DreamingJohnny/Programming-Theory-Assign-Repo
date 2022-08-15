using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGrabber : MonoBehaviour {

	private GameObject selectedObject;
	
	private GameObject heldObject;

	private Vector3 targetPosition;

	public const float zMax = 4.0f;
	public const float zMin = -4.0f;

	public const float XMax = 6.0f;
	public const float XMin = -6.0f;

	public const float YOffset = 2.0f;

	private void FixedUpdate() {
		RaycastHit hit = CastRay();

		if (hit.collider != null) {
			if (hit.collider.TryGetComponent<Cargo>(out Cargo cargo)) selectedObject = cargo.gameObject;
			else {
				selectedObject = null;
			}
		}

		if (heldObject != null) {
			Rigidbody rigid = heldObject.GetComponent<Rigidbody>();
			rigid.MovePosition(targetPosition);
		}
	}

	private void Update() {

		if (Input.GetMouseButtonDown(0) && selectedObject != null) {
			heldObject = selectedObject;
			heldObject.GetComponent<Rigidbody>().isKinematic = true;
			heldObject.GetComponent<Cargo>().IsHeld = true;
		}
		else if (Input.GetMouseButtonUp(0) && heldObject != null) {
			heldObject.GetComponent<Rigidbody>().isKinematic = false;
			heldObject.GetComponent<Cargo>().IsHeld = false;
			heldObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
			heldObject = null;
		}

		if (heldObject != null) {
			Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(heldObject.transform.position).z);
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(position);
			worldPos.z = Mathf.Clamp(worldPos.z, zMin, zMax);
			worldPos.x = Mathf.Clamp(worldPos.x, XMin, XMax);
			targetPosition = new Vector3(worldPos.x, YOffset, worldPos.z);
		}
	}

	//ABSTRACTION
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