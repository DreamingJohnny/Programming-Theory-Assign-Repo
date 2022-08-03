using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cargo : MonoBehaviour {

	[SerializeField] private GameObject contentIcon;

	[SerializeField] private Material standardMat;
	[SerializeField] private Material selectableMat;

	[SerializeField] private string content;
	[SerializeField] private CargoType cargoType;

	[SerializeField] private float flammability;
	[SerializeField] private float ballistic;
	[SerializeField] private float value;

	public bool isRevealed;

	public bool IsSelected;
	public float GetFlammability { get { return flammability; } }
	public float GetBallistic { get { return ballistic; } }
	public float GetValue { get { return value; } }

	private void Start() {
		GetComponent<MeshRenderer>().material = standardMat;
		contentIcon.SetActive(true);
	}

	private void OnMouseEnter() {
		GetComponent<MeshRenderer>().material = selectableMat;
		if(isRevealed) { contentIcon.SetActive(true); }
	}

	private void OnMouseExit() {
		GetComponent<MeshRenderer>().material = standardMat;
		contentIcon.SetActive(false);
	}

	private void OnDestroy() {
		Debug.Log("This object will now be destroyed...");
	}
}
