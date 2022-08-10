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
	[Range(0, 40)][SerializeField] private float fuelAmount;

	public float FuelAmount { get { return fuelAmount; } set { fuelAmount = Mathf.Clamp(value, 0f, maxFuelAmount); } }

	public const float HighFuelTreshold = 30f;
	public const float LowFuelTreshold = 10f;
	public const float NoFuelTreshold = 0f;

	[Tooltip("Amount of fuel consumed by engine per s.")]
	[Min(0)][SerializeField] private float fuelConsumption;
	public float FuelConsumption { get { return fuelConsumption; } }

	public const float TopSpeed = 3f;
	public const float HalfSpeed = 2f;
	public const float LowSpeed = 0.5f;
	public const float NoSpeed = 0f;

	public float Speed {
		get {
			if (fuelAmount >= HighFuelTreshold) return TopSpeed;
			else if (fuelAmount >= LowFuelTreshold) return HalfSpeed;
			else if (fuelAmount <= NoFuelTreshold) return NoSpeed;
			else return LowSpeed;
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

	private void Update() {
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
		if (other.TryGetComponent(out Cargo _)) {
			dropPointLight.gameObject.SetActive(true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.TryGetComponent(out Cargo _)) {
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