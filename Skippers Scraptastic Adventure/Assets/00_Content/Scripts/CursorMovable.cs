using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMovable : MonoBehaviour {

	private Vector3 cursorOffset;
	private float cursorZCoord;

	private void OnMouseDown() {
		cursorZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
		cursorOffset = gameObject.transform.position - GetCursorsWorldPoint();
	}

	private Vector3 GetCursorsWorldPoint() {
		Vector3 mousePoint = Input.mousePosition;

		mousePoint.z = cursorZCoord;

		return Camera.main.ScreenToWorldPoint(mousePoint);
	}

	private void OnMouseDrag() {
		transform.position = GetCursorsWorldPoint() + cursorOffset;
	}
}
