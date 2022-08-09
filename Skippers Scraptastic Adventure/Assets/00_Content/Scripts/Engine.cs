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

	[SerializeField] private float maxFuelAmount;
	public float MaxFuel { get { return maxFuelAmount; } }

	[Tooltip("Amount of fuel held in engine, is also the output the engine produces.")]
	//TODO: Fix this so that there is an actual working max and min here.
	[SerializeField][Range(0, 40)] private float fuelAmount;
	public float FuelAmount { get { return fuelAmount; } set { fuelAmount = Mathf.Min(maxFuelAmount, value); } }

	private const float highFuelTreshold = 30f;
	private const float lowFuelTreshold = 10f;
	private const float noFuelTreshold = 0f;

	[Tooltip("Amount of fuel consumed by engine per s.")]
	[SerializeField][Min(0)] private float fuelConsumption;
	public float FuelConsumption { get { return fuelConsumption; } }

	private const float topSpeed = 3f;
	private const float halfSpeed = 2f;
	private const float lowSpeed = 0.5f;
	private const float noSpeed = 0f;

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
		if (isRunning) {
			RunEngine();
			SetEngineLight();
		}
	}

	private void RunEngine() {

		if (FuelAmount <= 0) {
			isRunning = false;
		}
		else {
			FuelAmount -= FuelConsumption * Time.deltaTime;
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
		FuelAmount += cargo.GetFlammability;
		cargo.OnDestroy();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent(out Cargo cargo)) {
			dropPointLight.gameObject.SetActive(false);
		}
	}

	private void OnTriggerStay(Collider other) {
		if (other.TryGetComponent(out Cargo cargo)) {
			if (cargo.IsHeld == false) {
				SetFuel(cargo);
				dropPointLight.gameObject.SetActive(false);
			}
		}
	}
}