using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Cargo : MonoBehaviour {

	public delegate void CargoAction(string content);
	public static event CargoAction OnCargoDestroyed;

	[SerializeField] private GameObject[] contentIcons;

	private MeshRenderer meshRenderer;

	[SerializeField] private Sprite unknownContentIcon;
	[SerializeField] private Sprite knownContentIcon;

	[SerializeField] private Material standardMat;
	[SerializeField] private Material selectableMat;

	[SerializeField] private string content;

	[SerializeField] private float flammability;
	[SerializeField] private float ballistic;
	[SerializeField] private float value;

	public bool IsRevealed;

	public bool IsHeld;

	public string GetContent { get { return content; } }
	public float GetFlammability { get { return flammability; } }
	public float GetBallistic { get { return ballistic; } }
	public float GetValue { get { return value; } }

	private void Start() {
		meshRenderer = GetComponent<MeshRenderer>();
		meshRenderer.material = standardMat;
		SetContentIcons(false);
	}

	private void OnEnable() {
		GameManager.OnGameStopped += OnDestroy;	
	}

	private void OnDisable() {
		GameManager.OnGameStopped -= OnDestroy; 
	}

	public void OnDestroy() {
		OnCargoDestroyed(content);
		Destroy(gameObject);
	}

	private void OnMouseEnter() {
		meshRenderer.material = selectableMat;
	}

	private void OnMouseExit() {
		meshRenderer.material = standardMat;
	}

	public void SetContentIcons(bool state) {
		IsRevealed = state;

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
}