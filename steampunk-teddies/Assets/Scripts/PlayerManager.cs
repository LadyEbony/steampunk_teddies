using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

  private void Update() {
    if (gunInHand != null) { 
      gunInHand.UpdateProcedure();
      gunInHand.UpdateRotation();
    }
    if (Input.GetMouseButton(0)) {
      gunInHand.Fire();
    }
  }

}
