using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour {

	public delegate void ShipAction();
	public static event ShipAction OnShipReachedGoal;

	[SerializeField] private Engine engine;

	//TODO: Need a better name on travelDistanceComplete
	//TODO: Check that thing about, if these won't change during runtime, call them something.
	//Two that also need some sort of range/clamps.
	//TODO: Check so that range means that it cannot be set to that later either.
	[SerializeField] [Min(0)] private float travelDistanceComplete;

	[SerializeField] private float distanceLeft;
	public float DistanceLeft { get { return distanceLeft; } set { distanceLeft = Mathf.Max(0, value); } }

	[Tooltip("Amount of distance the ship moves every s.")]
	//Pretty sure I could just replace this with a getter that looks at the output of the engine no?
	[SerializeField] [Min(0)] private float currentSpeed;
	public float CurrentSpeed { get { return currentSpeed; } }

	private bool hasReachedGoal;
	public bool HasReachedGoal { get { return hasReachedGoal; } }

	void Start() {
		distanceLeft = travelDistanceComplete;
		Debug.Assert(engine != null);
	}

	void Update() {
		if(distanceLeft <= 0) {
			OnShipReachedGoal();
			return;
		}

		if(engine.isActiveAndEnabled && engine.IsRunning) {
			currentSpeed = engine.Speed * Time.deltaTime;
			distanceLeft -= currentSpeed;
		}
	}
}
