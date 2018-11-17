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
  }

  public void SwitchGun(Gun nearbyGun)
  {
      Destroy(gunInHand.gameObject);
      gunInHand = nearbyGun;
      gunInHand.transform.SetParent(transform);
  }
}
