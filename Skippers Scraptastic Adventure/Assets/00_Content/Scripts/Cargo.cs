using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cargo : MonoBehaviour {

	[SerializeField] private CargoType cargoType;

	[SerializeField] private float flammability;
	[SerializeField] private float ballistic;
	[SerializeField] private float value;

	public float GetFlammability { get { return flammability; } }
	public float GetBallistic { get { return ballistic; } }
	public float GetValue { get { return value; } }


}
