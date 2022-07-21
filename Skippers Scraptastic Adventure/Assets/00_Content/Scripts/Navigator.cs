using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {

	public delegate void ShipAction();
	public static event ShipAction OnShipReachedGoal;

	[SerializeField] private Engine engine;

	//TODO: Check that thing about, if these won't change during runtime, call them something.
	//Two that also need some sort of range/clamps.
	//TODO: Check so that range means that it cannot be set to that later either.
	[SerializeField][Min(0)] private float routeLength;
	public float RouteLength { get { return routeLength; } }

	[SerializeField] private float routeLeft;
	public float RouteLeft { get { return routeLeft; } set { routeLeft = Mathf.Max(0, value); } }

	[SerializeField][Min(0)] private float routeTravelled;
	public float RouteTravelled { get { return routeTravelled; } }

	[Tooltip("Amount of distance the ship moves every s.")]
	[SerializeField] [Min(0)] private float currentSpeed;
	public float CurrentSpeed { get { return currentSpeed; } }

	private bool hasReachedGoal;
	public bool HasReachedGoal { get { return hasReachedGoal; } }

	void Start() {
		routeLeft = routeLength;
		routeTravelled = routeLength - routeLeft;
		Debug.Assert(engine != null);


	}

	void Update() {
		if(routeLeft <= 0) {
			OnShipReachedGoal();
			return;
		}

		if(engine.isActiveAndEnabled && engine.IsRunning) {
			currentSpeed = engine.Speed * Time.deltaTime;
			routeLeft -= currentSpeed;
			routeTravelled += currentSpeed;
		}
	}
}
