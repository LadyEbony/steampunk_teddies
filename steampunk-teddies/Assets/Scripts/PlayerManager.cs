﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

  public Bat bat;
  private int invincibility = 0;

  public static PlayerManager instance;

  private void Awake() {
    instance = this;
  }


  private void Update() {
    if (gunInHand != null) { 
      gunInHand.UpdateProcedure();
      if (Input.GetMouseButton(0))
        gunInHand.Fire();
    }
     
    if (bat != null) { 
      bat.UpdateProcedure();
      if (Input.GetKey(KeyCode.F))
        bat.Attack();
    }

    if (rb2D.velocity.x != 0)
      animator.SetFloat("Direction", rb2D.velocity.x);
    animator.SetFloat("Health", currentHealth);

    if (rb2D.velocity.y > 1) {
      animator.Play("jump");
    }
    // else if (rb2D.velocity.y < -1) {
    //   animator.Play("fall");
    // }
    else {
      if (rb2D.velocity.x != 0) {
        animator.Play("run");
      }
      else {
        animator.Play("idle");
      }
    }
  }

	protected override void StartProcedure() {
		base.StartProcedure();
		if(gunInHand != null) {
			gunInHand.friendly = true;
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
