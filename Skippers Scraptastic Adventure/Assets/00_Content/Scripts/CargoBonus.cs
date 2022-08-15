using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoBonus : Cargo {

	public delegate void BonusAction(float bonus);
	public static event BonusAction OnCargoBonusShown;

	[SerializeField] private float bonus;

	public float Bonus { get { return bonus; } }

	public override void SetContentIcons(bool state) {
		base.SetContentIcons(state);

		if (state) {
			OnCargoBonusShown(Bonus);
			Destroy(gameObject);
		}
	}
}
