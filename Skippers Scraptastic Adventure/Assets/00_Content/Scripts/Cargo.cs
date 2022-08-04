using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Cargo : MonoBehaviour {

	[SerializeField] private GameObject[] contentIcons;

	[SerializeField] private Sprite unknownContentIcon;
	[SerializeField] private Sprite knownContentIcon;

	[SerializeField] private Material standardMat;
	[SerializeField] private Material selectableMat;

	[SerializeField] private string content;
	[SerializeField] private CargoType cargoType;

	[SerializeField] private float flammability;
	[SerializeField] private float ballistic;
	[SerializeField] private float value;

	public bool IsRevealed;

	public bool IsSelected;
	public float GetFlammability { get { return flammability; } }
	public float GetBallistic { get { return ballistic; } }
	public float GetValue { get { return value; } }

	private void Start() {
		GetComponent<MeshRenderer>().material = standardMat;
		SetContentIcons();
	}

	private void OnMouseEnter() {
		GetComponent<MeshRenderer>().material = selectableMat;
	}

	private void OnMouseExit() {
		GetComponent<MeshRenderer>().material = standardMat;
	}

	private void SetContentIcons() {
		if (!IsRevealed) {
			foreach (GameObject gameObject in contentIcons) {
				gameObject.GetComponent<SpriteRenderer>().sprite = unknownContentIcon;
			}
		}
		else {
			foreach (GameObject gameObject in contentIcons) {
				gameObject.GetComponent<SpriteRenderer>().sprite = knownContentIcon;
			}
		}
	}

	private void OnDestroy() {
		Debug.Log("This object will now be destroyed...");
	}
}
