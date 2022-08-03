using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

	//Needs a place where it can pick up the cargo that you drop into it...
	//And then a way to burn that cargo then, so, give away a certain amount of speed, based on it's "heat" or "output" or whatever...
	[SerializeField] private Light dropPointLight;
	[SerializeField] private Light engineLight;
	[SerializeField] private ParticleSystem fireParticle;

	//Hm, I do wonder if I should change this one to just simply looking at the values of fuel instead, and in that case, might as well just have the public one?
	[Tooltip("Checks if the engine currently has any fuel.")]
	private bool isRunning;
	public bool IsRunning { get { return isRunning; } }

	//TODO: Add tooltip here, but also, this should probably be turned into a static, and must be connected to the max on "Range" on fuelAmount,
	[SerializeField] private float maxFuelAmount;
	public float MaxFuel { get { return maxFuelAmount; } }

	[Tooltip("Amount of fuel held in engine, is also the output the engine produces.")]
	//TODO: Fix this so that there is an actual working max and min here.
	[SerializeField][Range(0, 40)] private float fuelAmount;
	public float FuelAmount { get { return fuelAmount; } }

	//TODO: Turns these into something static maybe?
	//TODO: These, use them on UI element to change the color on the slider?
	private float highFuelTreshold = 30f;
	private float lowFuelTreshold = 10f;
	private float noFuelTreshold = 0f;

	[Tooltip("Amount of fuel consumed by engine per s.")]
	[SerializeField][Min(0)] private float fuelConsumption;
	public float FuelConsumption { get { return fuelConsumption; } }

	//TODO: Turn these into something static maybe?
	private float topSpeed = 3f;
	private float halfSpeed = 2f;
	private float lowSpeed = 0.5f;
	private float noSpeed = 0f;

	//TODO: Have to check with someone how okay OR not okay this is later
	//TODO: Add clear tooltip here, after checking if this allowed.
	//TODO: Think about renaming these to something output, since speed might be something the ship should modify for?
	public float Speed {
		get {
			if (fuelAmount >= highFuelTreshold) return topSpeed;
			else if (fuelAmount >= lowFuelTreshold) return halfSpeed;
			else if (fuelAmount <= noFuelTreshold) return noSpeed;
			else return lowSpeed;
		}
	}

	void Start() {
		//TODO: Later on, add a button that sends a signal to attempt to start the engine, then remove this bool from Start.
		isRunning = true;
		dropPointLight.gameObject.SetActive(false);
	}

	void Update() {
		if (isRunning) RunEngine();
		SetEngineLight();
	}

	private void RunEngine() {

		if (fuelAmount <= 0) {
			isRunning = false;
			Debug.Log("The engine has no fuel.");
		}
		else {
			fuelAmount -= fuelConsumption * Time.deltaTime;
		}
	}

	private void SetEngineLight() {
		engineLight.enabled = isRunning;

		if (isRunning) { fireParticle.Play(); }
		else {
			fireParticle.Stop();
		}
	}

	public void SetFuel(Cargo cargo) {
		fuelAmount += cargo.GetFlammability;
		Debug.Log("About now would be a good time to destroy the cargo...");
		//TODO: Might make a new function if there should be more stuff that should happen in Destroy-function.
		Destroy(cargo.gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent<Cargo>(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if(other.TryGetComponent<Cargo>(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(false);
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.TryGetComponent<Cargo>(out Cargo cargo)) {
			if(cargo.IsSelected == false) { SetFuel(cargo); }
		}
	}

}
