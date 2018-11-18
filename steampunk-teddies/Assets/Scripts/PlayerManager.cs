using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

	public Bat bat;
	private int invincibility = 0;

  public static PlayerManager instance;

  private void Awake() {
    instance = this;
  }

  protected override void StartProcedure() {
		base.StartProcedure();
		if(gunInHand != null) {
			gunInHand.friendly = true;
		}
	}
	private void Update() {
		if (gunInHand != null) { 
				gunInHand.UpdateProcedure();
			if (Input.GetMouseButton(0))
				gunInHand.Fire();
			if (Input.GetKeyDown(KeyCode.R))
				gunInHand.ReloadGun();
		}
	     
	    if (bat != null) { 
				bat.UpdateProcedure();
				if (Input.GetKey(KeyCode.F))
					bat.Attack();
	    }
	}
	public void FixedUpdate()  {
		if (invincibility-- > 0) {
			GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, Mathf.Cos ((Mathf.Pow(invincibility, 2) / 3) * Mathf.PI));
		}
	}
  public void SwitchGun(Gun nearbyGun)
  {
    if (gunInHand != null)
      Destroy(gunInHand.gameObject);

    gunInHand = nearbyGun;
    gunInHand.friendly = true;
    gunInHand.Audio.PlayOneShot(gunInHand.PickupSound);
    gunInHand.transform.SetParent(hand);
    gunInHand.transform.localPosition = Vector3.zero;
    gunInHand.transform.localRotation = Quaternion.identity;
  }

	public override void TakeDamage(int damage) {
		if (invincibility > 0)
			return;
		invincibility = 60;
		base.TakeDamage (damage);
	}
}
