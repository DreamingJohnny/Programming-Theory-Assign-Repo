using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour {

	[SerializeField] private Light dropPointLight;
	[SerializeField] private Light engineLight;
	[SerializeField] private ParticleSystem fireParticle;

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

	private void OnEnable() {
		GameManager.OnGameStarted += HandleGameStarted;
		GameManager.OnGameStopped += HandleGameStopped;
	}

	private void OnDisable() {
		GameManager.OnGameStarted -= HandleGameStarted;
		GameManager.OnGameStopped -= HandleGameStopped;
	}

	private void HandleGameStopped() {
		isRunning = false;
		dropPointLight.gameObject.SetActive(false);
	}

	private void HandleGameStarted() {
		isRunning = false;
		dropPointLight.gameObject.SetActive(false);
	}

	void Update() {
		if (isRunning) RunEngine();
		SetEngineLight();
	}

	private void RunEngine() {

		if (fuelAmount <= 0) {
			isRunning = false;
		}
		else {
			fuelAmount -= fuelConsumption * Time.deltaTime;
		}
	}

	public void StartEngine(bool toggle) {
		Debug.Log($"{toggle}");
		isRunning = toggle;
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
			if(cargo.IsSelected == false) { 
				SetFuel(cargo);
				dropPointLight.gameObject.SetActive(false);
			}
		}
	}
}