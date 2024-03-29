using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {

	public delegate void ShipAction();
	public static event ShipAction OnShipReachedGoal;

	[SerializeField] private Engine engine;

	[SerializeField] private bool isTravelling;

	//TODO: Check that thing about, if these won't change during runtime, call them something.
	//Two that also need some sort of range/clamps.
	//TODO: Check so that range means that it cannot be set to that later either.
	[SerializeField][Min(0)] private float routeLength;
	public float RouteLength { get { return routeLength; } }

	[SerializeField] private float routeLeft;
	// ENCAPSULATION
	public float RouteLeft { get { return routeLeft; } set { routeLeft = Mathf.Max(0, value); } }
	// ENCAPSULATION
	public float RouteTravelled {	get {	return Mathf.Max(0f, (routeLength - routeLeft));	}	}

	[Tooltip("Amount of distance the ship moves every s.")]
	[SerializeField][Min(0)] private float currentSpeed;
	// ENCAPSULATION
	public float CurrentSpeed { get { return currentSpeed; } }

	private bool hasReachedGoal;
	public bool HasReachedGoal { get { return hasReachedGoal; } }

	[Min(1)] private float speedBoost = 1.0f;
	// ENCAPSULATION
	public float SpeedBoost { get { return speedBoost; } set { speedBoost = Mathf.Max(value, 1.0f); } }

	private void OnEnable() {
		GameManager.OnGameStarted += HandleGameStarted;
		GameManager.OnGameStopped += HandleGameStopped;

		speedBoost = 1.0f;
	}

	private void OnDisable() {
		GameManager.OnGameStarted -= HandleGameStarted;
		GameManager.OnGameStopped -= HandleGameStopped;
	}

	private void HandleGameStarted() {
		isTravelling = true;
		RouteLeft = routeLength;
	}

	private void HandleGameStopped() {
		isTravelling = false;
		currentSpeed = 0f;
	}

	void Update() {
		if (!isTravelling) return;

		if (routeLeft <= 0) {
			OnShipReachedGoal();
			isTravelling = false;
			return;
		}

		if (engine.isActiveAndEnabled && engine.IsRunning) {
			currentSpeed = engine.Speed * Time.deltaTime * SpeedBoost;
			routeLeft -= currentSpeed;
		}

		SpeedBoost -= Time.deltaTime;
	}
}