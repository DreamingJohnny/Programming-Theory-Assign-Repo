using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBonus : Cargo {

	public delegate void BonusAction(float bonus);
	public static event BonusAction OnCargoBonusShown;

	[SerializeField] private float bonus;

	// ENCAPSULATION
	public float Bonus { get { return bonus; } }

	/// <summary>
	/// If the argument it true. It sends the bonus on as an event and destroys itself.
	/// </summary>
	/// <param name="state"></param>
	// POLYMORPHISM
	public override void SetContentIcons(bool state) {
		//INHERITANCE
		base.SetContentIcons(state);

		if (state) {
			OnCargoBonusShown(Bonus);
			Destroy(gameObject);
		}
	}
}
