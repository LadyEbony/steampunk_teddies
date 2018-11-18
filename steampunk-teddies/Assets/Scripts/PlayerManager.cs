using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

  public Bat bat;

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

  public void SwitchGun(Gun nearbyGun)
  {
      Destroy(gunInHand.gameObject);
      gunInHand = nearbyGun;
      gunInHand.transform.SetParent(transform);
  }
}
